"""Prove the one missing logger AssemblyRef from original native ownership.

Pure bounded metadata reads only; no target code, compiler, Unity or network.
This proves reference identity/necessity, not working logger initialization.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata
from prepare_startup_foundation_slice import SOURCE_PINS
from audit_hashable_scoped_vtable import Read,m as audit
FACTORY=ROOT/'Validation/ServiceContainerFactoryCFG-20261022T182105Z-42400f6d/report.json'
FACTORY_SHA='3e6fd771370d7135adb31be3a0c82b10caaf7875b54114a94497fcea186071a3'
EXPECTED='RecRoom.Debugging.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def main():
    need(pin(FACTORY)['sha256']==FACTORY_SHA,'Exact closed native factory proof');proof=json.loads(FACTORY.read_bytes());logger=proof['direct_original_aliases']['0x185673d90'];need(len(logger)==1 and logger[0]['index']==47093 and logger[0]['image']=='RecRoom.Debugging.Runtime.dll' and logger[0]['owner']=='PNAABCMOHGM' and logger[0]['name']=='FPNMONCCAAE' and logger[0]['return']=='System.Void' and [x['type'] for x in logger[0]['parameters']]==['System.Object','System.Nullable`1<HJDBOADFHMC>&'],'Exact native logger method/image/signature')
    original=[ROOT/'CodeSource'/name for name in SOURCE_PINS]
    for path in original:need(pin(path)['sha256']==SOURCE_PINS[path.relative_to(ROOT/'CodeSource').as_posix()],'Fresh original source authority')
    with original[0].open('rb') as bf,original[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);types={}
        for i in range(v.count('typeDefinitions',88)):
            name=v.full_name(i)
            if name in ('PNAABCMOHGM','HJDBOADFHMC'):types[name]=v.type_info(i)
        need(set(types)=={'PNAABCMOHGM','HJDBOADFHMC'} and all(x['image']=='RecRoom.Debugging.Runtime.dll' for x in types.values()),'Both native type owners are the same genuine Debugging assembly')
        need(v.method_info(47093)==logger[0] and v.method_pointer(logger[0])==0x185673d90,'Fresh exact original logger registration')
    sdk=WS/'RR23/Assets/Plugins/RecRoom.Debugging.Runtime.dll';target=WS/'RR23/Assets/Plugins/RecRoom.AgInitialization.Runtime.dll'
    with sdk.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=audit.cli.Cli(b);reader=Read(c);identity=audit.identity(c,32,1)['full_name'];need(identity==EXPECTED,'Exact actual retained Debugging SDK assembly identity')
        owners={name:[i for i in range(1,c.rows[2]+1) if reader.definition(i)==name] for name in types};need(all(len(x)==1 for x in owners.values()),'Actual exact native-owned SDK types')
        methods=[x for x in reader.methods(owners['PNAABCMOHGM'][0]) if x['token']=='0x600000a'];need(len(methods)==1 and methods[0]['name']=='FPNMONCCAAE' and methods[0]['flags']==logger[0]['flags'],'Actual retained original logger MethodDef/signature owner');method=methods[0];need(method['signature']['return']=='void' and method['signature']['parameters'][0]=='object' and len(method['signature']['parameters'])==2 and 'System.Nullable`1' in method['signature']['parameters'][1] and ('['+EXPECTED+']HJDBOADFHMC') in method['signature']['parameters'][1],'Actual logger exact nullable-color/byref scope')
        fa=c.row(4,0x68);field={'token':'0x04000068','flags':c.u16(fa),'name':c.string(c.value(fa+2,c.strw)),'signature_blob':c.blob(c.value(fa+2+c.strw,c.blobw)).hex()};need(field['name']=='LMOLABKFOAB' and field['flags']==54,'Actual retained original public static readonly color field')
    with target.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=audit.cli.Cli(b);references=[audit.identity(c,35,i)['full_name'] for i in range(1,c.rows[35]+1)];need(EXPECTED not in references and not any(x.startswith('RecRoom.Debugging.Runtime,') for x in references),'Proven caller stub lacks this required assembly reference')
    out=ROOT/'Validation'/('ContainerLoggingReferenceScope-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();r={'schema':'native-required-single-container-logger-AssemblyRef-proof/v1','status':'one_exact_native_required_reference_proved_no_metadata_changed','native_factory_proof':pin(FACTORY),'native_logger':logger[0],'native_type_ownership':types,'actual_retained_SDK':pin(sdk),'actual_retained_SDK_meta':pin(str(sdk)+'.meta'),'actual_assembly_identity':identity,'actual_logger':method,'actual_static_color':field,'current_caller':pin(target),'current_caller_meta':pin(str(target)+'.meta'),'original_ordered_references':references,'sole_proposed_append':EXPECTED,'all_original_references_order_and_other_metadata_must_remain_equal':True,'logging_color_cctor_and_logger_bodies_recovered':False,'production_factory_execution_permitted_by_this_proof':False,'Main_modified':False,'compiler_Unity_game_network_or_target_DLL_executed':False}
    path=out/'report.json'
    with path.open('x',encoding='utf-8') as f:json.dump(r,f,indent=2);f.write('\n')
    print(json.dumps({'report':pin(path),'sole_proposed_append':EXPECTED,'Main_modified':False}))
if __name__=='__main__':main()
