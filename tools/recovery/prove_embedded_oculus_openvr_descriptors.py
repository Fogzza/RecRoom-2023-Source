"""Read-only native/official descriptor ownership proof. No inspected code runs.

Only the uniquely matched sequential-layout descriptor owners are eligible.
Ambiguous POD descendants are disclosed, not renamed or used as descriptor owners.
"""
import copy, datetime as dt, hashlib, json, re, uuid
from pathlib import Path

WS = Path(__file__).resolve().parents[3]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
V = ROOT / 'Validation'
PATHS = {
    'source': V/'CompiledEmbeddedOpenVrCandidate-20261022T160757Z-b58e3c05/inventory.json',
    'target': V/'OculusProviderInventory-20261022T155054Z-65d1ecc8/inventory.json',
    'native': V/'NativeOculusContracts-20261022T155520Z-0cceb379/report.json',
    'graph': V/'EmbeddedOpenVrGraphCandidates-20261022T161233Z-6b5c6413/report.json',
    'official': V/'OfficialEmbeddedOpenVrCandidate-20261022T160201Z-fd55842b/report.json',
    'compiled': V/'CompiledEmbeddedOpenVrCandidate-20261022T160757Z-b58e3c05/report.json',
    'version': V/'OculusWrapperVersionProof-20261022T160555Z-d6310247/report.json',
}
TOKEN = re.compile(r'[A-Za-z_][A-Za-z0-9_`./]*|[^\s]')
def sha(p): return hashlib.sha256(Path(p).read_bytes()).hexdigest()
def need(ok, why):
    if not ok: raise ValueError(why)
def unique(rows, predicate, label):
    matches = [r for r in rows if predicate(r)]
    need(len(matches) == 1, 'Exact unique ' + label + ' required: ' + str(len(matches)))
    return matches[0]
def category(m): return m['name'] if m['name'] in ('.ctor','.cctor','Invoke','BeginInvoke','EndInvoke') else 'ordinary'

def run(mutate=None):
    reports = {k: json.loads(p.read_text()) for k,p in PATHS.items()}
    if mutate is not None: mutate(reports)
    source = reports['source']['modules'][0]; target = reports['target']['modules'][0]
    ss = {t['name']: t for t in source['types']}; tt = {t['name']: t for t in target['types']}
    nn = {t['name']: t for t in reports['native']['types']}; mapping = reports['graph']['mapping']
    domains = {**{k:[v] for k,v in mapping.items()}, **reports['graph']['unmatched']}
    need(not reports['graph']['collisions'], 'Graph has collisions')
    need(reports['compiled']['status']=='passed' and reports['version']['status']=='proven', 'Compiler/version proof absent')
    need(reports['compiled']['official_source_report']['sha256']==sha(PATHS['official']), 'Official source provenance changed')
    need(all(sha(r['path'])==r['sha256'] for r in reports['official']['files']), 'Official source bytes changed')
    need(reports['compiled']['inventory']['sha256']==sha(PATHS['source']), 'Compiled inventory hash mismatch')
    need(sha(source['path'])==reports['compiled']['compiled_witness']['sha256'], 'Compiled source witness changed')
    need(sha(PATHS['source']) == reports['graph']['source_inventory']['sha256'], 'Source graph identity changed')
    need(sha(PATHS['target']) == reports['graph']['target_inventory']['sha256'], 'Target graph identity changed')
    need(sha(target['path']) == '184c1dd8fe50aa778517e386ec4a877a75962b550ef0ab99d76e7cb39a4bce8a', 'Target changed')
    def translated(text):
        parts=TOKEN.findall(text)
        need(all(x not in ss or x in mapping for x in parts), 'Direct descriptor contract contains ambiguous source type: '+text)
        return ''.join(mapping.get(x,x) for x in parts)
    def same(a,b): return translated(a) == ''.join(TOKEN.findall(b))
    def method_contract(a,b):
        return category(a)==category(b) and a['flags']==b['flags'] and a['impl_flags']==b['impl_flags'] and a['return_flags']==b['return_flags'] and same(a['return_type'],b['return_type']) and len(a['parameters'])==len(b['parameters']) and all(p['flags']==q['flags'] and same(p['type'],q['type']) for p,q in zip(a['parameters'],b['parameters']))
    def target_native(st, nt):
        need(st['flags']==nt['flags'], 'Native owner flags differ')
        need(st['token']==nt['token'], 'Original owner token differs')
        need(len(st['fields'])==len(nt['fields']), 'Native field inventory differs')
        for f,nf in zip(st['fields'],nt['fields']):
            need((f['token'],f['name'],f['type'],f['flags'])==(nf['token'],nf['name'],nf['type'],nf['flags']), 'Native exact field inventory differs')
        for m in st['methods']:
            unique(nt['methods'], lambda n:(m['name'],m['return_type'],m['flags'],m['impl_flags'],m['return_flags'],[(p['type'],p['flags']) for p in m['parameters']])==(n['name'],n['return_type'],n['flags'],n['impl_flags'],n['return_flags'],[(p['type'],p['flags']) for p in n['parameters']]), 'native method contract')
    # Primitive unmanaged widths, never CLR Marshal.OffsetOf or inspected-code execution.
    primitive={'System.Boolean':(1,1),'System.Byte':(1,1),'System.SByte':(1,1),'System.Int16':(2,2),'System.UInt16':(2,2),'System.Char':(2,2),'System.Int32':(4,4),'System.UInt32':(4,4),'System.Single':(4,4),'System.Int64':(8,8),'System.UInt64':(8,8),'System.Double':(8,8),'System.IntPtr':(8,8),'System.UIntPtr':(8,8)}
    layout_cache={}
    def layout(name):
        if name in primitive:return (*primitive[name],None)
        if name in layout_cache:return layout_cache[name]
        t=ss[name]
        if any(f['name']=='value__' for f in t['fields']):
            u=unique(t['fields'], lambda f:f['name']=='value__','enum storage');return layout(u['type'])
        if t['name'].rsplit('/',1)[-1].startswith('_') and any(m['name']=='Invoke' for m in t['methods']):return (8,8,None)
        need(t['flags']&0x18==8,'Layout must be sequential: '+name)
        pack=t['packing'] if t['packing']>0 else 8;offset=0;alignment=1;offsets=[]
        for f in t['fields']:
            if f['flags']&16:continue
            size,align,_=layout(f['type']);align=min(align,pack);offset=(offset+align-1)//align*align;offsets.append(offset);offset+=size;alignment=max(alignment,align)
        size=(offset+alignment-1)//alignment*alignment
        if t['size']>0:size=max(size,t['size'])
        layout_cache[name]=(size,alignment,offsets);return layout_cache[name]
    bindings=[]; owner_proofs=[];callback_proofs=[]
    roots=[t for t in source['types'] if any(f['has_marshal'] for f in t['fields']) or any(p['has_marshal'] for m in t['methods'] for p in m['parameters'])]
    for st in roots:
        need(st['name'] in mapping,'Marshal owner ambiguous')
        target_name=mapping[st['name']];at=tt[target_name];nt=nn[target_name];target_native(at,nt)
        need(st['flags']==at['flags'] and st['packing']==at['packing'] and st['size']==at['size'], 'Source owner layout flags differ')
        need(len(st['fields'])==len(at['fields']) and len(st['methods'])==len(at['methods']), 'Owner count differs')
        need(all(any(method_contract(m,n) for n in at['methods']) for m in st['methods']), 'Full owner method contract mismatch: '+st['name'])
        field_offsets=layout(st['name'])[2] if st['fields'] else None
        for ordinal,(sf,tf,nf) in enumerate(zip(st['fields'],at['fields'],nt['fields'])):
            need(st['flags']&0x18==8,'Field owner must be sequential')
            need(sf['flags']==tf['flags'] and same(sf['type'],tf['type']), 'Exact translated field contract mismatch')
            need(nf['offset'] is not None and nf['offset']==16+field_offsets[ordinal], 'Native boxed field offset differs: '+st['name']+' '+str(ordinal))
            if not sf['has_marshal']:continue
            need(sf['marshal']['kind']=='MarshalInfo' and sf['marshal']['native_type'] in (3,38), 'Unsupported source descriptor')
            need((sf['marshal']['native_type']==3 and sf['type']=='System.Boolean') or (sf['marshal']['native_type']==38 and sf['type'] in ss and any(m['name']=='Invoke' for m in ss[sf['type']]['methods'])), 'Descriptor does not match exact Boolean/delegate contract')
            need(nf['flags']&4096 and not tf['has_marshal'], 'Original missing owner flag differs')
            if sf['marshal']['native_type']==38:
                ct=ss[sf['type']];cat=tt[mapping[sf['type']]];cnt=nn[cat['name']];target_native(cat,cnt)
                need(ct['flags']==cat['flags'] and len(ct['methods'])==len(cat['methods'])==4, 'Callback type mismatch')
                for cm in ct['methods']:
                    unique(cat['methods'],lambda m:method_contract(cm,m),'exact callback full signature')
                callback_proofs.append({'sdk_owner':ct['name'],'native_owner':cnt['name'],'native_token':cnt['token'],'invoke':unique(cnt['methods'],lambda m:m['name']=='Invoke','native Invoke')})
            bindings.append({'kind':'field','owner':nt['name'],'native_owner_token':nt['token'],'native_field_token':nf['token'],'native_field_index':nf['metadata_index'],'native_ordinal':ordinal,'native_boxed_offset':nf['offset'],'sdk_owner':st['name'],'sdk_name':sf['name'],'sdk_type':sf['type'],'sdk_cli_token':sf['token'],'target_cli_token':tf['token'],'name':tf['name'],'type':tf['type'],'flags':tf['flags'],'sdk_type_scope':sf['scope'],'target_type_scope':tf['scope'],'descriptor':'base:'+str(sf['marshal']['native_type'])})
        for sm in st['methods']:
            if not any(p['has_marshal'] for p in sm['parameters']):continue
            tm=unique(at['methods'],lambda m:method_contract(sm,m),'source marshal method signature');nm=unique(nt['methods'],lambda m:m['name']==tm['name'] and m['token']==tm['token'],'original marshal method token')
            for sp,tp,np in zip(sm['parameters'],tm['parameters'],nm['parameters']):
                if not sp['has_marshal']:continue
                need(sp['marshal']=={'kind':'MarshalInfo','native_type':20},'Only genuine LPStr parameter permitted')
                need(sp['flags']==tp['flags']==np['flags'] and np['flags']&8192 and not tp['has_marshal'], 'Original param flags mismatch')
                bindings.append({'kind':'parameter','owner':nt['name'],'native_owner_token':nt['token'],'native_method_token':nm['token'],'native_parameter_token':np['token'],'target_cli_token':tm['token'],'sdk_cli_token':sm['token'],'sdk_owner':st['name'],'sdk_name':sm['name'],'sdk_signature':sm['return_type']+' '+sm['name']+'('+','.join(p['type'] for p in sm['parameters'])+')','signature':tm['return_type']+' '+tm['name']+'('+','.join(p['type'] for p in tm['parameters'])+')','method_flags':tm['flags'],'method_impl_flags':tm['impl_flags'],'sequence':sp['sequence'],'name':tp['name'],'sdk_parameter_name':sp['name'],'sdk_type':sp['type'],'type':tp['type'],'flags':tp['flags'],'sdk_type_scope':sp['scope'],'target_type_scope':tp['scope'],'descriptor':'base:20'})
        owner_proofs.append({'sdk_owner':st['name'],'native_owner':nt['name'],'native_owner_token':nt['token'],'flags':st['flags'],'sequential_field_offsets':field_offsets,'fields':len(st['fields']),'methods':len(st['methods'])})
    need(len(bindings)==335 and sum(b['kind']=='field' for b in bindings)==332,'Expected335 owner coverage')
    seen={(b['kind'],b['owner'],b.get('native_field_token'),b.get('native_method_token'),b.get('sequence')) for b in bindings};need(len(seen)==335,'Owner collision')
    unresolved=[]
    for nt in reports['native']['types']:
        for f in nt['fields']:
            if f['flags']&4096 and ('field',nt['name'],f['token'],None,None) not in seen:
                tf=unique(tt[nt['name']]['fields'],lambda x:(x['token'],x['name'],x['type'],x['flags'])==(f['token'],f['name'],f['type'],f['flags']),'unresolved target field')
                need(not tf['has_marshal'],'Unresolved target descriptor unexpectedly present')
                unresolved.append({'kind':'field','owner':nt['name'],'native_owner_token':nt['token'],'name':f['name'],'type':f['type'],'flags':f['flags'],'native_field_token':f['token'],'target_cli_token':tf['token']})
        for m in nt['methods']:
            for p in m['parameters']:
                if p['flags']&8192 and ('parameter',nt['name'],None,m['token'],p['sequence']) not in seen:
                    tm=unique(tt[nt['name']]['methods'],lambda x:x['token']==m['token'] and x['name']==m['name'],'unresolved target method');tp=tm['parameters'][p['sequence']-1]
                    need((tp['name'],tp['type'],tp['flags'])==(p['name'],p['type'],p['flags']) and not tp['has_marshal'],'Unresolved target parameter differs')
                    unresolved.append({'kind':'parameter','owner':nt['name'],'native_owner_token':nt['token'],'name':p['name'],'type':p['type'],'flags':p['flags'],'native_method_token':m['token'],'native_parameter_token':p['token'],'sequence':p['sequence'],'target_cli_token':tm['token'],'signature':tm['return_type']+' '+tm['name']+'('+','.join(a['type'] for a in tm['parameters'])+')','method_flags':tm['flags'],'method_impl_flags':tm['impl_flags']})
    need(len(unresolved)==20 and sum(x['kind']=='field' for x in unresolved)==17,'Remaining20 inventory differs')
    return reports,source,target,bindings,owner_proofs,callback_proofs,unresolved

if __name__=='__main__':
    out=V/('EmbeddedOculusOpenVrProof-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'native-obfuscated-oculus-embedded-openvr335-descriptor-proof/v1','project_modified':False,'sdk_or_game_code_executed':False}
    try:
        reports,source,target,bindings,owners,callbacks,unresolved=run()
        report.update(status='native_source_descriptor_ownership_proven',inputs={k:{'path':str(p),'sha256':sha(p)} for k,p in PATHS.items()},target_path=target['path'],target_sha256=sha(target['path']),sdk_path=source['path'],sdk_sha256=sha(source['path']),native_report_path=str(PATHS['native']),native_report_sha256=sha(PATHS['native']),fields=332,parameters=3,bindings=bindings,owner_proofs=owners,callback_proofs=callbacks,unresolved=unresolved,limitations=['Only335 native flagged descriptor owners are covered. Twenty Oculus-specific owners remain unmodified and unresolved.','Obfuscated identities use uniquely refined full declaration graphs plus exact native tokens, sequential field order and physical offsets; SDK names are not substituted.','Non-marshal descendants with structurally indistinguishable POD contracts remain explicitly ambiguous in graph report; no descriptors or type identities are assigned to them.','Oculus managed wrapper version1.78.0 is proven separately; overall original package version is unknown. No SDK bodies or platform settings are substituted.'])
    except BaseException as e:report.update(status='failed',error=str(e))
    (out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
