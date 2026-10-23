"""Read-only exact declaration-graph candidate refinement; never assign marshal data.

Names stripped by obfuscation are not guessed. Sequential instance field order
is an ABI constraint; auto/explicit layout fields and methods use perfect
bipartite matching. Ambiguities remain explicit and no project is changed.
"""
import collections,datetime as dt,hashlib,json,re,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';TOKEN=re.compile(r'[A-Za-z_][A-Za-z0-9_`./]*|[^\s]')
SOURCE=ROOT/'Validation/CompiledEmbeddedOpenVrCandidate-20261022T160757Z-b58e3c05/inventory.json';TARGET=ROOT/'Validation/OculusProviderInventory-20261022T155054Z-65d1ecc8/inventory.json'
source=json.loads(SOURCE.read_text())['modules'][0];target=json.loads(TARGET.read_text())['modules'][0];ss={t['name']:t for t in source['types'] if t['name']!='<Module>'};tt={t['name']:t for t in target['types'] if t['name']!='<Module>'}
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def tokens(text):return TOKEN.findall(text)
def skeleton(text,own):return tuple('LOCAL' if x in own else x for x in tokens(text))
def constant(f):return (f['has_constant'],json.dumps(f['constant'],sort_keys=True,separators=(',',':')) if f['has_constant'] else None)
def fieldkey(f,own):return(f['flags'],constant(f),skeleton(f['type'],own))
def category(m):return m['name'] if m['name'] in ('.ctor','.cctor','Invoke','BeginInvoke','EndInvoke') else 'ordinary'
def methodkey(m,own):return(category(m),m['flags'],m['impl_flags'],m['return_flags'],skeleton(m['return_type'],own),tuple((p['flags'],skeleton(p['type'],own)) for p in m['parameters']))
def sequential(t):return t['flags']&0x18==8
def feature(t,own):
 fields=[fieldkey(f,own) for f in t['fields']]
 return(t['flags'],t['packing'],t['size'],tuple(fields) if sequential(t) else tuple(sorted(fields,key=repr)),tuple(sorted((methodkey(m,own) for m in t['methods']),key=repr)))
features=collections.defaultdict(set)
for name,t in tt.items():features[feature(t,tt)].add(name)
domains={name:set(features.get(feature(t,ss),())) for name,t in ss.items()};initial={k:len(v) for k,v in domains.items()};initial_missing=[k for k,v in domains.items() if not v]
def type_pairs(a,b):
 aa=tokens(a);bb=tokens(b)
 if len(aa)!=len(bb):return None
 pairs=[]
 for x,y in zip(aa,bb):
  if x in ss:
   if y not in tt:return None
   pairs.append((x,y))
  elif x!=y:return None
 return pairs
def type_ok(a,b):
 pairs=type_pairs(a,b);return pairs is not None and all(y in domains[x] for x,y in pairs)
def field_ok(a,b):return fieldkey(a,ss)==fieldkey(b,tt) and type_ok(a['type'],b['type'])
def method_ok(a,b):return methodkey(a,ss)==methodkey(b,tt) and type_ok(a['return_type'],b['return_type']) and all(type_ok(x['type'],y['type']) for x,y in zip(a['parameters'],b['parameters']))
def perfect(left,right,predicate):
 if len(left)!=len(right):return False
 options=[[j for j,b in enumerate(right) if predicate(a,b)] for a in left]
 if any(not v for v in options):return False
 assigned={}
 def visit(i,seen):
  for j in options[i]:
   if j in seen:continue
   seen.add(j)
   if j not in assigned or visit(assigned[j],seen):assigned[j]=i;return True
  return False
 return all(visit(i,set()) for i in sorted(range(len(left)),key=lambda i:len(options[i])))
def parent(name):return name.rsplit('/',1)[0] if '/' in name else None
def compatible(a,b):
 pa,pb=parent(a['name']),parent(b['name'])
 if bool(pa)!=bool(pb) or pa is not None and pb not in domains.get(pa,set()):return False
 if sequential(a):
  if not all(field_ok(x,y) for x,y in zip(a['fields'],b['fields'])):return False
 elif not perfect(a['fields'],b['fields'],field_ok):return False
 return perfect(a['methods'],b['methods'],method_ok)
iterations=[]
for iteration in range(40):
 removed=0
 for name in ss:
  bad={n for n in domains[name] if not compatible(ss[name],tt[n])};domains[name]-=bad;removed+=len(bad)
 # Reverse arc constraints from already unique source owners. Explicit/auto
 # layout fields are never resolved by ordinal or source spelling.
 for name,values in list(domains.items()):
  if len(values)!=1:continue
  actual=tt[next(iter(values))];original=ss[name]
  if parent(name):
   p=parent(name);allowed={parent(actual['name'])};old=len(domains[p]);domains[p]&=allowed;removed+=old-len(domains[p])
  for index,f in enumerate(original['fields']):
   candidates=[actual['fields'][index]] if sequential(original) else [g for g in actual['fields'] if field_ok(f,g)]
   pair_options=[type_pairs(f['type'],g['type']) for g in candidates];refs={x for x in tokens(f['type']) if x in ss}
   for ref in refs:
    allowed={y for pairs in pair_options if pairs is not None for x,y in pairs if x==ref};old=len(domains[ref]);domains[ref]&=allowed;removed+=old-len(domains[ref])
  for m in original['methods']:
   candidates=[n for n in actual['methods'] if method_ok(m,n)];sources=[m['return_type']]+[p['type'] for p in m['parameters']]
   for pos,part in enumerate(sources):
    pair_options=[type_pairs(part,([n['return_type']]+[p['type'] for p in n['parameters']])[pos]) for n in candidates];refs={x for x in tokens(part) if x in ss}
    for ref in refs:
     allowed={y for pairs in pair_options if pairs is not None for x,y in pairs if x==ref};old=len(domains[ref]);domains[ref]&=allowed;removed+=old-len(domains[ref])
 singles={next(iter(v)) for v in domains.values() if len(v)==1}
 for name,values in domains.items():
  if len(values)>1:old=len(values);values-=singles;removed+=old-len(values)
 iterations.append({'iteration':iteration,'removed':removed,'unique':sum(len(v)==1 for v in domains.values()),'missing':sum(not v for v in domains.values()),'ambiguous':sum(len(v)>1 for v in domains.values())})
 if not removed:break
mapping={k:next(iter(v)) for k,v in domains.items() if len(v)==1};reverse=collections.Counter(mapping.values());collisions={k:n for k,n in reverse.items() if n>1};out=ROOT/'Validation'/('EmbeddedOpenVrGraphCandidates-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'obfuscated-embedded-openvr-declaration-graph-candidates/v1','status':'candidate_graph_not_native_binding_proof','source_inventory':{'path':str(SOURCE),'sha256':sha(SOURCE)},'target_inventory':{'path':str(TARGET),'sha256':sha(TARGET)},'source_types':len(ss),'target_types':len(tt),'initial_missing':initial_missing,'iterations':iterations,'mapping':mapping,'collisions':collisions,'unmatched':{k:sorted(v) for k,v in domains.items() if len(v)!=1},'method_or_field_names_not_used_for_mapping':True,'auto_and_explicit_layout_fields_not_matched_by_ordinal':True,'marshal_descriptor_assignments':0,'project_modified':False,'sdk_or_game_code_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'source_types':len(ss),'initial_missing':initial_missing[:20],'unique':len(mapping),'collisions':collisions,'missing':sum(not v for v in domains.values())}),flush=True)
