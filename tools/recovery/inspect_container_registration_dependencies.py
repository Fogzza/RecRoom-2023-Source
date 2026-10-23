"""Static native generic dependency windows; no selected body guessed or run."""
from pathlib import Path
import datetime as dt,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from inventory_recroom_game_root_native import region

def main():
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source SHA differs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);wanted={47985:'provider_ctor',47876:'register_provider'};specs=[]
        for i in range(v.method_spec_count):
            mi,ci,gi=struct.unpack_from('<iii',b,v.method_specs+i*12)
            if mi in wanted:specs.append({'role':wanted[mi],'method_spec_index':i,'method':v.method_info(mi),'class_arguments':[v.typename(t) for t in v.inst(ci)],'method_arguments':[v.typename(t) for t in v.inst(gi)],'class_inst_index':ci,'method_inst_index':gi})
        registrations=v.generic_targets({r['method_spec_index'] for r in specs});windows={}
        for row in specs:
            targets=registrations[row['method_spec_index']];row['original_registrations']=targets
            for t in targets:
                pointer=int(t['pointer'],16)
                if pointer not in windows:
                    try:windows[pointer]=region(v,pointer)
                    except ValueError as error:windows[pointer]={'region_error':str(error)}
        check=v.find_method('MKECFLEMHEL',0x0600005f);va=v.method_pointer(check);raw=v.raw(va,128)
        check_bytes=bytes(b[raw:raw+128]).hex()
    out=ROOT/'Validation'/('ContainerRegistrationDependencyWindows-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'container-registration-dependencies-original-static-windows/v1','status':'registered_shared_generic_dependency_bodies_not_inflated_MNAL_proof','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'all_retained_specs_for_two_original_definitions':specs,'unique_original_registered_first_pdata_windows':{hex(k):val for k,val in windows.items()},'condition_check':{'original':check,'pointer':hex(va),'bounded128bytes_not_assumed_whole':check_bytes},'closed_MNAL_instantiations_not_assumed_from_shared_pointer':True,'Main_changed':False,'managed_or_game_code_executed':False}
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'specs':len(specs),'registered_specs':sum(bool(r['original_registrations']) for r in specs),'windows':{hex(k):len(bytes.fromhex(val.get('bytes',''))) for k,val in windows.items()},'check':check_bytes}))

if __name__=='__main__':main()
