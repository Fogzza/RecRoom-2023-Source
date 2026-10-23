"""Fresh seven-body staging with exact pinned enum/constant metadata resolver.

V1 emit failure remains frozen. No scopes, constants, definitions or safety
gates are relaxed; only metadata readers gain the existing exact resolver.
"""
from pathlib import Path
import argparse,datetime as dt,difflib,json,mmap,os,re,shutil,uuid
import stage_custom_urp_factory_cache_bodies as old
from stage_custom_urp_factory_cache_bodies import HERE,WS,ROOT,SUPPORT,PREVIOUS,GUARD_SHA,LAUNCH_SHA,guard,pin,check,need,save,tested
from audit_hashable_scoped_vtable import Read
from audit_cli_marshal_contracts import Cli
import audit_hashable_scoped_vtable as signatures
SCHEMA='prepared-seven-tested-original-custom-URP-body-only-import-exact-resolver/v2'
FAILED=ROOT/'Validation/CustomUrpSevenBodyStage-20261023T092441Z-547039e3/run-report.json'
FAILED_SHA='1ef48e11410d9453ce0ecd3e2a8d9bc7d94036235db01ad19f72409c5898d1d0'
BASE_SHA='068349b92acc98f4013aa2deedd3ea20284c856b9c85985606ce53449d577c75'
RESOLVER=WS/'RR23/Assets/Editor/OriginalMetadataRestoration/ExactMetadataReferenceResolver.cs'
FRAMEWORK=WS/'RR23/Assets/Editor/OriginalMetadataRestoration/OriginalFrameworkMetadataReferenceInputs.cs'

def replace_once(text,before,after):
    need(text.count(before)==1,'Exact single v2 resolver amendment anchor');return text.replace(before,after)

def make_source():
    original=HERE/'StageCustomUrpFactoryCacheBodies.cs';need(pin(original)['sha256']==BASE_SHA,'Frozen executed v1 importer')
    text=original.read_text();text=replace_once(text,'static class StageCustomUrpFactoryCacheBodies','static class StageCustomUrpFactoryCacheBodiesV2')
    text=replace_once(text,'seven-tested-custom-URP-body-only-import-input/v1','seven-tested-custom-URP-body-only-import-input/v2')
    anchor='var rows=spec.GetProperty("modules").EnumerateArray().ToArray();'
    inserted='''var resolverRows=spec.GetProperty("metadata_references").EnumerateArray().ToArray();
        Need(resolverRows.Length==11&&resolverRows.Select(r=>Path.GetFileName(r.GetProperty("path").GetString())).Distinct(StringComparer.Ordinal).Count()==11,"Exact eleven explicit original SDK/engine/reference identities, no directory search");
        foreach(var metadata in resolverRows)
        {
            string path=metadata.GetProperty("path").GetString();Need(Sha(path)==metadata.GetProperty("sha256").GetString(),"Pinned exact enum/constant metadata bytes");
            using var authority=AssemblyDefinition.ReadAssembly(path,new ReaderParameters{ReadSymbols=false,InMemory=true});Need(authority.Name.FullName==metadata.GetProperty("full_name").GetString(),"Pinned exact enum/constant full identity");
        }
        using var resolver=new ExactMetadataReferenceResolver(resolverRows.Select(r=>r.GetProperty("path").GetString()),resolverRows.Select(r=>new CuratedRuntimeMetadataReference(Path.GetFileNameWithoutExtension(r.GetProperty("path").GetString()),r.GetProperty("sha256").GetString())),OriginalFrameworkMetadataReferenceInputs.Values);
        '''+anchor
    text=replace_once(text,anchor,inserted)
    need(text.count('new ReaderParameters{ReadSymbols=false,InMemory=true}')==4,'Exactly target/donor/emitted plus standalone identity-only metadata reader')
    # Identity-only authority read does not resolve types. The three body readers
    # share only the explicit exact metadata resolver, never a search resolver.
    text=replace_once(text,'ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true})','ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver})')
    text=replace_once(text,'ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true})','ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver})')
    text=replace_once(text,'ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true})','ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver})')
    text=replace_once(text,'seven-tested-original-custom-URP-body-only-staged-candidates/v1','seven-tested-original-custom-URP-body-only-staged-candidates/v2')
    text=replace_once(text,'modules=results,changed_method_bodies=7,','modules=results,exact_pinned_metadata_resolver_used=true,metadata_references=resolverRows,changed_method_bodies=7,')
    target=HERE/'StageCustomUrpFactoryCacheBodies.v2.cs';data=text.encode('utf-8')
    if target.exists():need(target.read_bytes()==data,'Never replace a frozen existing v2 source')
    else:
        with target.open('xb') as f:f.write(data)
    return original,target

def identity(path):
    with Path(path).open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b);return signatures.m.identity(c,32,1)['full_name']

def metadata_references(original):
    with Path(original).open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b);wanted=[signatures.m.identity(c,35,i) for i in range(1,c.rows[35]+1)]
    need(len(wanted)==11,'Exact current original URP reference inventory')
    editor=WS/'Tools/Editors/2020.3.33f1/Editor';managed=editor/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed';mono=editor/'Data/MonoBleedingEdge/lib/mono';out=[]
    for row in wanted:
        name=row['name'];need(re.fullmatch(r'[A-Za-z0-9_.]+',name),'Literal reference basename')
        if name.startswith('UnityEngine.'):
            path=managed/(name+'.dll');authority='Genuine matching2020.3.33f1 Windows Mono engine metadata; same full assembly identity'
        elif name=='mscorlib':
            path=mono/'4.7.1-api/mscorlib.dll';authority='Genuine matching Editor Mono framework metadata'
        elif name=='System':
            path=mono/'unityaot/System.dll';authority='Existing native-framework curated7cec identity; exact resolver also validates pinned framework inventory'
        else:
            path=WS/'RR23/Assets/Plugins'/(name+'.dll');authority='Actual recovered original SDK metadata, not readable compiler facade'
        actual=identity(path);need(actual==row['full_name'],'Exact original external identity, no retargeting '+name)
        out.append({**pin(path),'full_name':actual,'authority':authority})
    return out

def prepare():
    r,p=tested();need(pin(FAILED)['sha256']==FAILED_SHA,'Preserve exact failed original emit receipt');failed=json.loads(FAILED.read_bytes());need(failed['status']=='failed_or_guard_refused_preserve_outputs' and len(failed['phases'])==2 and failed['phases'][0]['exit_code']==0,'Original importer compiled; metadata emit alone failed')
    base,source=make_source();need(pin(RESOLVER)['sha256']=='f6d4a3c706e9d23764e6f4869eae4695d26d512ac2fea3b1d6a46aba1f348638' and pin(FRAMEWORK)['sha256']=='4fe70dc5f7913709a5e911e7a439b07e3029d33cace0e44357a2792381a5cd69','Existing reviewed exact resolver/framework authority sources')
    references=metadata_references(p['current_original_DLL']['path']);out=ROOT/'Validation'/('CustomUrpSevenBodyStageV2-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    old_plan=json.loads(Path(failed['plan']['path']).read_bytes());spec_data=json.loads(Path(old_plan['spec']['path']).read_bytes());spec_data['schema']='seven-tested-custom-URP-body-only-import-input/v2';spec_data['metadata_references']=references;spec=out/'inputs.json';save(spec,spec_data)
    diff=out/'exact-resolver-amendment.diff';diff.write_text(''.join(difflib.unified_diff(base.read_text().splitlines(True),source.read_text().splitlines(True),fromfile=str(base),tofile=str(source))),encoding='utf-8')
    sources=[source]+[SUPPORT/n for n in ['CanonicalMetadataSignatures.cs','MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']]+[RESOLVER,FRAMEWORK]
    previous=(PREVIOUS/'compile.rsp').read_text(encoding='utf-8-sig');refs=[Path(s) for s in re.findall(r'(?m)^/reference:"([^"]+)"$',previous) if '/packs/Microsoft.NETCore.App.Ref/' in s.replace('\\','/')];need(len(refs)>=100,'Exact existing .NET framework pack');cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs.append(cecil);shutil.copyfile(cecil,out/cecil.name)
    output=out/'StageCustomUrpFactoryCacheBodiesV2.dll';rsp=out/'compile.rsp';rsp.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(s)+'"\n' for s in refs)+''.join('"'+str(s)+'"\n' for s in sources),encoding='utf-8',newline='\n');shutil.copyfile(PREVIOUS/'OriginalShaderObjectProbe.runtimeconfig.json',output.with_suffix('.runtimeconfig.json'))
    mono=WS/'Tools/Editors/2020.3.33f1/Editor/Data/MonoBleedingEdge/lib/mono/unityaot';framework_authority=[pin(mono/n) for n in ['System.Core.dll','System.dll','System.Xml.dll']]
    plan={'schema':SCHEMA,'status':'prepared_no_child_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(old.__file__)),'failed_v1_receipt':pin(FAILED),'failed_v1_plan':failed['plan'],'frozen_v1_source':pin(base),'resolver_amendment':pin(diff),'test_receipt':pin(old.TEST),'test_plan':r['plan'],'native_proofs':p['native_proofs'],'spec':pin(spec),'sources':[pin(s) for s in sources],'tested_donor_source':p['source'],'response':pin(rsp),'references':[pin(s) for s in refs],'metadata_references':references,'framework_authority':framework_authority,'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'modules':spec_data['modules'],'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),'output':str(output),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'Main_modified':False,'Main_apply_supported':False,'changed_bodies':7,'all_original_metadata_reference_scopes_constants_and_other_bodies_preservation_gates_unchanged':True,'automatic_reference_addition_supported':False,'constructor_disposal_frame_closure_claimed':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Frozen owned guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed exact-resolver body stage plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpSevenBodyStageV2-') and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['changed_bodies']==7 and not p['Main_apply_supported'] and not p['automatic_reference_addition_supported'],'Exact seven-body resolver-only amendment scope')
    for row in [p[k] for k in ['runner','base_runner','failed_v1_receipt','failed_v1_plan','frozen_v1_source','resolver_amendment','test_receipt','test_plan','spec','tested_donor_source','response','guard','launcher','dotnet','compiler']]+p['native_proofs']+p['sources']+p['references']+p['framework_authority']+p['runtime']:check(row)
    for row in p['metadata_references']:check({k:row[k] for k in ['path','bytes','sha256']});need(identity(row['path'])==row['full_name'],'Exact metadata authority identity')
    for row in p['modules']:
        for key in ['original','donor','meta']:check(row[key])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Fixed reviewed v2 runner and guard');tested()
    need(p['output']==str(out/'StageCustomUrpFactoryCacheBodiesV2.dll'),'Fixed fresh importer output')
    if not run:print(json.dumps({'status':'verified_no_child_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh v2 outputs only; preserve v1 partial candidate')
    report={'schema':'guarded-seven-original-custom-URP-body-stage-exact-resolver/v2','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_Unity_network_launched':False,'constructor_disposal_frame_closure_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-seven-URP-exact-resolver-importer',report)
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-readback-seven-original-URP-exact-resolver-candidate',report,env)
        result=out/'Candidates/report.json';proof=json.loads(result.read_bytes());need(proof['schema']=='seven-tested-original-custom-URP-body-only-staged-candidates/v2' and proof['status']=='seven_tested_URP_bodies_imported_all_original_metadata_other_bodies_preserved' and proof['exact_pinned_metadata_resolver_used'] and proof['changed_method_bodies']==7 and len(proof['modules'])==1 and not proof['Main_modified'],'Full original enum/constants/metadata and other-body proof')
        for row in proof['modules']:check(row['candidate']);need(row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'] and row['changed_methods']==7 and row['assembly_references_appended']==[],'Unchanged donor,token,reference gates')
        for row in p['modules']:check(row['original']);check(row['meta'])
        report.update(status='seven_tested_URP_bodies_staged_exact_resolver_all_metadata_constants_other_bodies_preserved',result=pin(result),candidates=[row['candidate'] for row in proof['modules']],Main_plugin_and_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='seven_tested_URP_bodies_staged_exact_resolver_all_metadata_constants_other_bodies_preserved' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed Root plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0

if __name__=='__main__':raise SystemExit(main())
