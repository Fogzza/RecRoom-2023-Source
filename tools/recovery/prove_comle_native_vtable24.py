"""Original v27 virtual slot witness for COMLE/base; no virtual calls executed."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'));from native_metadata import NativeMetadata
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def need(x,s):
 if not x:raise ValueError(s)
def main():
 binary=ROOT/'CodeSource/GameAssembly.dll';meta=ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat';pins={binary:'ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b',meta:'1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474'}
 for p,s in pins.items():need(sha(p)==s,'Pinned originalsourcehash')
 with binary.open('rb') as bf,meta.open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as d:
  v=NativeMetadata(b,d);rows=[]
  for owner,image in [('COMLEJJIPLL','Assembly-CSharp.dll'),('LMENEPLIBDK','RecRoom.Networking.SynchronizedFields.Runtime.dll')]:
   im=next(x for x in v.images if x['name']==image)
   hits=[i for i in range(im['start'],im['start']+im['count']) if v.full_name(i)==owner]
   need(len(hits)==1,'Unique native owner');ti=hits[0];at=v.row('typeDefinitions',ti,88)
   start=v.i32(d,at+36);count=v.u16(d,at+64);vstart=v.i32(d,at+56);vcount=v.u16(d,at+74)
   matches=[mi for mi in range(start,start+count) if v.string(v.i32(d,v.row('methods',mi,32)))=='HLMGIKNDNEG']
   need(len(matches)==1,'ExactnativeHLM');mi=matches[0];method=v.method_info(mi);slot=v.u16(d,v.row('methods',mi,32)+28)
   need(slot!=65535 and slot<vcount,'OriginalHLMslot in nativevtable bounds')
   encoded=v.u32(d,v.row('vtableMethods',vstart+slot,4));kind=encoded>>29&7;index=(encoded&0x1fffffff)>>1
   print(json.dumps({'diagnostic_only':True,'owner':owner,'native_slot':slot,'vtable_start':vstart,'vtable_count':vcount,'encoded':hex(encoded),'kind':kind,'decoded_index':index}))
   need(kind in (3,6) or method['flags']&1024 and encoded==0,'Unsupported native vtable entry '+hex(encoded))
   if encoded==0:target=None;args=None
   elif kind==3:target=v.method_info(index);args=None
   else:
    definition,ci,midx=struct.unpack_from('<iii',b,v.method_specs+index*12);target=v.method_info(definition);args={'class':[v.typename(t) for t in v.inst(ci)],'method':[v.typename(t) for t in v.inst(midx)]}
   need(target is None and method['flags']&1024 or target is not None and target['name']=='HLMGIKNDNEG' and target['owner']==owner,'NativevtableHLMtarget');rows.append({'original_type':v.type_info(ti),'method':method,'original_MethodDef_slot':slot,'vtable_start':vstart,'vtable_count':vcount,'vtable_entry_index':vstart+slot,'vtable_encoded':hex(encoded),'decoded_kind':kind,'decoded_index':index,'target':target,'abstract_unresolved_generic_definition_vtable_entry_is_zero':target is None,'instantiation':args})
  need(rows[0]['original_MethodDef_slot']==rows[1]['original_MethodDef_slot'],'Native override and base slot differ');need(not rows[0]['method']['flags']&1024 and rows[1]['method']['flags']&1024,'Concrete derived/abstract base flags')
 for p,s in pins.items():need(sha(p)==s,'Originalsourcechanged')
 out=ROOT/'Validation'/('COMLENativeVirtualSlot-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();r=out/'report.json';report={'schema':'original-native-COMLE-LMENE-HLM-virtual-slot-witness/v1','status':'passed','scope':'Original native virtual table binds concrete COMLE.HLMGIKNDNEG to the same MethodDef slot as the abstract base contract. Base generic-definition vtable entry is explicitly zero, no target inferred. The CLR reported slot24 is not assumed to equal the IL2CPP native slot.','inputs':[{'path':str(p),'sha256':s} for p,s in pins.items()],'owners':rows,'game_or_managed_assemblies_invoked':False,'project_changed':False};r.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(r),'sha256':sha(r),'rows':[(x['original_type']['name'],x['original_MethodDef_slot'],x['target']['token'] if x['target'] else None) for x in rows]}))
if __name__=='__main__':main()
