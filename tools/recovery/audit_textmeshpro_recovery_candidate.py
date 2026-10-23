"""Read-only TMP native/API/body inventory and genuine local UPM provenance.
Package cache existence/version is not falsely treated as original version proof.
"""
from pathlib import Path
from collections import Counter
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_cli_marshal_contracts import Cli
from inventory_recroom_game_root_native import region

CACHE=Path('C:/Users/andre/AppData/Local/Unity/cache/packages/packages.unity.com/com.unity.textmeshpro@3.0.6')
STAGED=ROOT/'NativeGameplayRepairs/RuntimePluginMonoCompatibility-20261022T100750Z/Unity.TextMeshPro.dll'

def cli_inventory(path):
    before=sha(path);hist=Counter();rows=[];selected=[]
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b);types=[];parents={}
        for rid in range(1,c.rows[2]+1):
            at=c.row(2,rid);name=c.string(c.value(at+4,c.strw));ns=c.string(c.value(at+4+c.strw,c.strw));first=c.value(at+4+2*c.strw+c.coded(2,[2,1,27])+c.index(4),c.index(6));types.append({'rid':rid,'name':name,'namespace':ns,'first_method':first})
        for rid in range(1,c.rows[41]+1):
            at=c.row(41,rid);parents[c.value(at,c.index(2))]=c.value(at+c.index(2),c.index(2))
        def full(rid):
            t=types[rid-1];return full(parents[rid])+'/'+t['name'] if rid in parents else (t['namespace']+'.' if t['namespace'] else '')+t['name']
        ti=0
        for rid in range(1,c.rows[6]+1):
            while ti+1<len(types) and types[ti+1]['first_method']<=rid:ti+=1
            at=c.row(6,rid);rva=c.u32(at);name=c.string(c.value(at+8,c.strw));flags=c.u16(at+6);body=b''
            if rva:
                raw=c.raw(rva,1);lead=b[raw]
                if lead&3==2:size=lead>>2;start=c.raw(rva+1,size)
                else:
                    need(lead&3==3,'Exact IL header');head=(c.u16(raw)>>12)*4;size=c.u32(raw+4);need(size<=65536,'Bounded stub/body size');start=c.raw(rva+head,size)
                body=bytes(b[start:start+size])
            kind='unverified_other_body'
            if not rva:kind='no_IL_body'
            elif body==b'\x2a':kind='exact_ret_only_original_emptiness_not_proven'
            elif body==b'\x14\x2a':kind='exact_unconditional_null_return'
            elif body==b'\x14\x7a':kind='exact_null_throw'
            elif body in (b'\x16\x2a',b'\x16\x6a\x2a',bytes.fromhex('22000000002a'),bytes.fromhex('2300000000000000002a')):kind='zero_constant_return_original_value_not_proven'
            elif len(body)==7 and body[:2]==b'\x02\x28' and body[-1:]==b'\x2a':kind='base_call_only_constructor_original_equivalence_not_proven'
            elif len(body)==10 and body[:4]==bytes.fromhex('1200fe15') and body[-2:]==bytes.fromhex('062a'):kind='initobj_default_local_return'
            hist[kind]+=1;owner=full(types[ti]['rid'])
            if owner in ('TMPro.TMP_Settings','TMPro.TMP_Text','TMPro.TextMeshPro','TMPro.TextMeshProUGUI') and name in ('get_version','Awake','Start','OnEnable','OnDisable','GenerateTextMesh','Rebuild','OnPreRenderCanvas'):
                selected.append({'owner':owner,'name':name,'current_not_native_token':hex(0x06000000|rid),'flags':flags,'body_bytes':len(body),'IL':body.hex(),'classification':kind})
        need(c.rows[32]==1,'One exact assembly definition');ar=c.row(32,1);version='.'.join(str(c.u16(ar+4+i*2)) for i in range(4));aname=c.string(c.value(ar+16+c.blobw,c.strw))
        references=[]
        for rid in range(1,c.rows[35]+1):
            at=c.row(35,rid);references.append({'name':c.string(c.value(at+12+c.blobw,c.strw)),'version':'.'.join(str(c.u16(at+i*2)) for i in range(4)),'public_key_or_token':c.blob(c.value(at+12,c.blobw)).hex()})
        counts={'TypeDefs_including_Module':c.rows[2],'MethodDefs':c.rows[6],'FieldDefs':c.rows[4],'PropertyDefs':c.rows[23],'EventDefs':c.rows[20]}
    need(sha(path)==before,'TMP DLL changed during read; no mixed snapshot admitted')
    return {'path':str(path),'sha256':before,'assembly_name':aname,'assembly_version_not_UPM_version':version,'counts':counts,'body_classification':dict(hist),'selected_methods':selected,'AssemblyRefs':references,'method_presence_not_counted_as_recovered':True}

def main():
    package_path=CACHE/'package.json';package=json.loads(package_path.read_bytes());need(package['name']=='com.unity.textmeshpro' and package['version']=='3.0.6','Exact local cache identity')
    pins=[]
    for p in sorted((CACHE/'Scripts/Runtime').rglob('*')):
        if p.is_file() and p.suffix in ('.cs','.asmdef','.meta'):pins.append({'relative':p.relative_to(CACHE).as_posix(),'sha256':sha(p),'bytes':p.stat().st_size})
    package_evidence={k:package.get(k) for k in ('name','version','unity','unityRelease','dependencies','repository','upmCi')};package_evidence.update(path=str(CACHE),package_json_sha256=sha(package_path),runtime_source_inventory=pins,license={'path':str(CACHE/'LICENSE.md'),'sha256':sha(CACHE/'LICENSE.md')},version_getter_source={'path':str(CACHE/'Scripts/Runtime/TMP_Settings.cs'),'sha256':sha(CACHE/'Scripts/Runtime/TMP_Settings.cs'),'literal':'1.4.0','warning':'Product version getter is 1.4.0 even in official package3.0.6; must not infer package version from this getter alone'},official_documentation='https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0/manual/index.html')
    staged=cli_inventory(STAGED);mainpath=WS/'RR23/Assets/Plugins/Unity.TextMeshPro.dll';current=cli_inventory(mainpath)
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source SHA differs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);im=next(i for i in v.images if i['name']=='Unity.TextMeshPro.dll');native_types=[];versions=[];mc=0;fc=0
        for ti in range(im['start'],im['start']+im['count']):
            at=v.row('typeDefinitions',ti,88);start=v.i32(md,at+36);count=v.u16(md,at+64);fcount=v.u16(md,at+68);owner=v.full_name(ti);native_types.append({'index':ti,'owner':owner,'native_type_token':hex(v.u32(md,at+84)),'native_flags':v.u32(md,at+28),'method_count':count,'field_count':fcount});mc+=count;fc+=fcount
            if owner=='TMPro.TMP_Settings':
                for mi in range(start,start+count):
                    m=v.method_info(mi)
                    if m['name']=='get_version':
                        pointer=v.method_pointer(m);item={'original':m,'pointer':hex(pointer)}
                        try:item['first_pdata_not_assumed_complete']=region(v,pointer)
                        except ValueError as e:
                            raw=v.raw(pointer,96);item.update(pdata_gap=str(e),bounded96bytes_not_assumed_complete=bytes(b[raw:raw+96]).hex())
                        versions.append(item)
    out=ROOT/'Validation'/('TextMeshProRecoveryAudit-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    r={'schema':'read-only-original-TMP-recovery-and-local-official-UPM-candidate/v1','status':'genuine_local_package_available_original_exact_UPM_version_not_yet_proven','staged_runtime_TMP':staged,'current_Main_TMP':current,'native_original_image':im,'native_original_counts':{'types':len(native_types),'methods':mc,'fields':fc},'native_original_types':native_types,'native_version_method':versions,'local_UPM_candidate':package_evidence,'current_packages_manifest_has_TMP':False,'replacement_requires':['prove exact original API/type/field/layout contract against compiled3.0.6 with same2020Editor/defines; distinguish engine stripping from edits','compare native original selected method bodies and constants against genuine samepackage source; package version match alone is insufficient','preserve existing DLLmeta GUID/classfileIDs/platformfilters; avoid duplicate UPM+DLL assembly','test nonexecuting metadata/IL binding and bounded genuine framework load before staging runtime replacement'],'package_installed_or_Editor_launched':False,'Main_or_backend_changed':False,'managed_game_code_loaded_or_executed':False}
    p=out/'report.json';p.write_text(json.dumps(r,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'native_counts':r['native_original_counts'],'stage_counts':staged['counts'],'bodies':staged['body_classification'],'cache_package':package_evidence['version'],'native_version':versions}))

if __name__=='__main__':main()
