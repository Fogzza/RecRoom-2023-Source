"""Prepare or Root-run the exact two title/login caller binding/effect checks.

Preparation only reads Main, writes a new Validation folder and starts no child.
Execution compiles the actual full candidate files with the current captured
Unity Windows Mono Development response. A separately named test-only subject
uses exact candidate spans with controlled effects, never production callees.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';PROJECT=WS/'RR23'
SLICE=ROOT/'Validation/TitleLoginTransitionSlice-20261023T063256Z-6f66a375/report.json'
SLICE_SHA='878cf0dce6af57c57f82b96b36da885c992474d0550a2150f61abe000fa4425a'
RESPONSE=PROJECT/'Temp/UnityTempFile-7163ab0657ae4ce4a9313330c2ec7d47'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-exact-original-title-login-two-member-binding-effects/v1'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def check(row):need(pin(row['path'])==row,'Pinned binding/effect input changed: '+row['path'])
def candidate_spans(proof):
    need(proof['candidate_method_count']==2 and len(proof['sources'])==2,'Exact two-member source slice required')
    spans={}
    for row in proof['sources']:
        check(row['source']);check(row['source_meta']);check(row['candidate']);need(len(row['byte_edits'])==1 and row['all_other_source_bytes_equal'],'One exact edit per full original source')
        edit=row['byte_edits'][0];old=base64.b64decode(edit['original_base64'],validate=True);new=base64.b64decode(edit['replacement_base64'],validate=True)
        before=Path(row['source']['path']).read_bytes();after=Path(row['candidate']['path']).read_bytes();start=edit['start']
        need(len(old)==edit['length'] and before[start:start+len(old)]==old and after==before[:start]+new+before[start+len(old):],'Exact two original-to-candidate spans and all other bytes')
        need(edit['original_method_token'] not in spans,'Unique method token');spans[edit['original_method_token']]=new
    need(set(spans)=={'0x0600089B','0x060089A7'},'Exact original UI method tokens')
    return spans
def response(snapshot,output,replacements):
    rows=[];inputs=[];used=set();outs=0
    allowed={'/target:library','/unsafe','/debug:portable','/optimize-','/nostdlib+','/preferreduilang:en-US','/langversion:8.0'}
    for line in snapshot.splitlines():
        if not line:continue
        if line.startswith('/out:'):
            need(line=='/out:Temp/Assembly-CSharp.dll','Actual core compiler response output');outs+=1;rows.append('/out:"'+str(output)+'"');continue
        if line.startswith('/define:') or line in allowed:rows.append(line);continue
        ref=line.startswith('/reference:');value=line[11:] if ref else line
        need(ref or not line.startswith(('/','@')),'Unexpected compiler flag/nested response')
        p=Path(value.strip('"'));p=(p if p.is_absolute() else PROJECT/p).resolve(strict=True)
        record=pin(p);inputs.append(record)
        if str(p).casefold() in replacements:used.add(str(p).casefold());p=replacements[str(p).casefold()]
        rows.append(('/reference:' if ref else '')+'"'+str(p)+'"')
    need(outs==1 and used==set(replacements),'Both actual full candidate sources must occur once')
    text='\n'.join(rows)+'\n';defs={x[8:] for x in rows if x.startswith('/define:')}
    need({'UNITY_STANDALONE_WIN','UNITY_64','ENABLE_MONO','DEVELOPMENT_BUILD'}<=defs and not({'UNITY_EDITOR','ENABLE_IL2CPP'}&defs),'Actual Windows64 Mono development input, no Editor/IL2CPP defines')
    return text,inputs
def prepare():
    need(pin(SLICE)['sha256']==SLICE_SHA,'Reviewed source slice changed');proof=json.loads(SLICE.read_bytes());spans=candidate_spans(proof)
    need(pin(HERE/'original_shader_pair_editor_conversion.py')['sha256']==GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCH_SHA,'Reviewed owned resource guard required')
    out=ROOT/'Validation'/('TitleLoginBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    snapshot=out/'Unity-emitted-WindowsDevelopment-Assembly-CSharp.rsp';shutil.copyfile(RESPONSE,snapshot)
    replacements={r['source']['path'].casefold():Path(r['candidate']['path']) for r in proof['sources']}
    text,inputs=response(snapshot.read_text(encoding='utf-8-sig'),out/'Assembly-CSharp.dll',replacements)
    need(sum(not x.startswith('/') for x in text.splitlines())==5095,'Exact current Unity core source count')
    rsp=out/'full-candidate-binding.rsp';rsp.write_text(text,encoding='utf-8',newline='\n')
    template=HERE/'TitleLoginSliceEffects.template.cs';data=template.read_bytes()
    for marker,value in [(b'/*EXACT_FLOWMODEL_GETTER*/',spans['0x0600089B']),(b'/*EXACT_GOTOLOGIN_METHOD*/',spans['0x060089A7'])]:
        need(data.count(marker)==1,'Unique controlled fixture substitution');data=data.replace(marker,value)
    source=out/'ExactCandidateControlledEffects.cs';source.write_bytes(data)
    fxrefs=[EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'/n for n in ['mscorlib.dll','System.dll','System.Core.dll']]
    cecil=PROJECT/'Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';fxrefs.append(cecil)
    shutil.copyfile(cecil,out/'Mono.Cecil.dll')
    effectrsp=out/'controlled-effects.rsp';effectrsp.write_text('/nologo\n/noconfig\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(out/'ExactCandidateControlledEffects.exe')+'"\n'+''.join('/reference:"'+str(p)+'"\n' for p in fxrefs)+'"'+str(source)+'"\n',encoding='utf-8')
    manifest=out/'full-compiler-inputs.json';save(manifest,inputs)
    plan={'schema':SCHEMA,'status':'prepared_no_compiler_or_test_started','fixture':str(out),'slice':pin(SLICE),'runner':pin(Path(__file__)),'template':pin(template),'captured_Unity_response_origin':pin(RESPONSE),'captured_Unity_response':pin(snapshot),'compiler_inputs':pin(manifest),'full_response':pin(rsp),'effect_response':pin(effectrsp),'effect_source':pin(source),'effect_references':[pin(p) for p in fxrefs],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'full_compile_cap_bytes':1024**3,'helper_and_effect_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'source_count':5095,'reference_count':sum(x.startswith('/reference:') for x in text.splitlines()),'candidate_span_sha256':{k:hashlib.sha256(v).hexdigest() for k,v in spans.items()},'effect_cases':8,'actual_game_types_compiled_in_full_files':True,'effect_subjects_are_explicitly_test_only':True,'Main_writes':False,'working_boot_or_login_claimed':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'status':plan['status'],'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed harness plan hash required');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleLoginBindingEffects-'),'Exact isolated harness output scope')
    need(p['full_compile_cap_bytes']==1024**3 and p['helper_and_effect_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Fixed owned phase bounds')
    fixed=['slice','runner','template','captured_Unity_response','compiler_inputs','full_response','effect_response','effect_source','copied_Cecil','compiler','mono','guard','launcher']
    for row in [p[k] for k in fixed]+p['effect_references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Reviewed runner/guard unchanged')
    proof=json.loads(Path(p['slice']['path']).read_bytes());spans=candidate_spans(proof)
    need(p['candidate_span_sha256']=={k:hashlib.sha256(v).hexdigest() for k,v in spans.items()},'Exact actual candidate body hashes')
    allinputs=json.loads(Path(p['compiler_inputs']['path']).read_bytes())
    for row in allinputs:check(row)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected,'source_count':p['source_count'],'reference_count':p['reference_count']}));return 0
    need(all(not(out/n).exists() for n in ['run-report.json','Assembly-CSharp.dll','Assembly-CSharp.pdb','ExactCandidateControlledEffects.exe']),'Fresh harness only; no overwrite/retry')
    report={'schema':'guarded-exact-original-title-login-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_or_network_launched':False,'production_game_callees_invoked':False,'working_boot_or_login_claimed':False}
    try:
        guard.CAP=p['full_compile_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['full_response']['path']],out,'compile-actual-full-candidate-files',report)
        need((out/'Assembly-CSharp.dll').is_file(),'Actual full source output required');report['full_assembly']=pin(out/'Assembly-CSharp.dll')
        guard.CAP=p['helper_and_effect_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effect_response']['path']],out,'compile-controlled-effects-and-metadata-reader',report)
        guard.bounded([p['mono']['path'],str(out/'ExactCandidateControlledEffects.exe'),'--inspect',str(out/'Assembly-CSharp.dll')],out,'inspect-real-member-binding-metadata-only',report)
        guard.bounded([p['mono']['path'],str(out/'ExactCandidateControlledEffects.exe')],out,'execute-exact-bodies-with-controlled-effects',report)
        for row in allinputs:check(row)
        candidate_spans(proof)
        report.update(status='actual_full_file_binding_and_eight_controlled_effect_cases_passed',actual_full_files_compiled=True,metadata_binding_verified=True,controlled_effect_cases=8,all_Main_sources_and_selected_metas_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_file_binding_and_eight_controlled_effect_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without starting children');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
