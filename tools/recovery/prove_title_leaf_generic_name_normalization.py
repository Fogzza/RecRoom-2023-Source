"""Pure metadata proof of the single HHOBPMOCKMJ arity-name projection."""
from pathlib import Path
import datetime as dt,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from collect_title_page_route_native import pin
from audit_original_rendering_sdk_candidates import h
FAILED=ROOT/'Validation/TitleDependencyLeafBindingEffects-20261023T083551Z-b9009d63/run-report.json'

def definition(path,name):
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=h.m.cli.Cli(b);r=h.Read(c);ts=[i for i in range(1,c.rows[2]+1) if r.definition(i)==name];need(len(ts)==1,'One exact SDK type');ti=ts[0];gps=[]
        for i in range(1,c.rows[42]+1):
            a=c.row(42,i)
            if c.value(a+4,c.coded(1,[2,6]))==ti<<1:gps.append({'number':c.u16(a),'flags':c.u16(a+2),'name':c.string(c.value(a+4+c.coded(1,[2,6]),c.strw))})
        return {'module':pin(path),'assembly_identity':r.asm,'type_name':name,'TypeDef_token':hex(0x02000000|ti),'generic_parameters':gps}

def main():
    need(pin(FAILED)['sha256']=='ecdaa19bb0f0e920c11da8253a3da779e5ca9722e1735dbc96760c9385054a60','Frozen exact original whole-sequence inspector failure');f=json.loads(FAILED.read_bytes());need([x['exit_code'] for x in f['phases']]==[0,0,1] and f['full_assembly']['sha256']=='582d9c456cb52a9aa43bb29871151aef1df69673fd759263a24dcf639743f595','Actual full5095 compile passed; only metadata inspector refused')
    raw=definition(WS/'RR23/Assets/Plugins/RecRoom.Datastructures.Runtime.dll','HHOBPMOCKMJ');projected=definition(WS/'RR23/CompilerSupport/References/RecRoom.Datastructures.Runtime.dll','HHOBPMOCKMJ`1');need(raw['TypeDef_token']==projected['TypeDef_token']=='0x2000032' and raw['assembly_identity']==projected['assembly_identity']=='RecRoom.Datastructures.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' and raw['generic_parameters']==projected['generic_parameters']==[{'number':0,'flags':0,'name':'T'}],'Exact same SDK identity/token and sole generic parameter; only metadata name gains arity suffix')
    paths=[ROOT/'CodeSource'/x for x in ['GameAssembly.dll','RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat']];inputs=[pin(x) for x in paths];need(inputs[0]['sha256']=='ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b' and inputs[1]['sha256']=='1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474','Genuine original native metadata authority')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);native=v.type_info(6824);need(native['name']=='HHOBPMOCKMJ' and native['token']=='0x2000032' and native['image']=='RecRoom.Datastructures.Runtime.dll' and native['generic_container_index']==1831,'Exact original native declaring type token/name/image');a=v.row('genericContainers',1831,16);gc={'owner':v.i32(md,a),'type_argc':v.i32(md,a+4),'is_method':v.i32(md,a+8),'parameter_start':v.i32(md,a+12)};need(gc=={'owner':6824,'type_argc':1,'is_method':0,'parameter_start':3137},'Exact native type arity1')
    out=ROOT/'Validation'/('TitleLeafGenericNameProof-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'exact-single-title-owner-field-generic-name-projection/v1','status':'same_original_type_token_assembly_arity_proven_for_one_field_only','native_inputs':inputs,'native_type':native,'native_generic_container':gc,'raw_runtime_contract':raw,'projected_compiler_contract':projected,'only_permitted_field':{'owner':'RecRoom.Core.UI.UIInputModule','ordinal':15,'name':'onPointerPressed','original_element_type':'HHOBPMOCKMJ','projected_element_type':'HHOBPMOCKMJ`1','generic_arguments':['UnityEngine.GameObject'],'argument_scope':'UnityEngine.CoreModule','generic_type_scope':'RecRoom.Datastructures.Runtime'},'failed_receipt':pin(FAILED),'successful_full_assembly':f['full_assembly'],'all_other_fields_require_exact_type_full_name':True,'no_generic_suffix_stripping_rule_introduced':True,'Main_modified':False,'managed_compiler_Unity_game_network_executed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'permitted_named_field_exceptions':1,'Main_modified':False}))
if __name__=='__main__':main()
