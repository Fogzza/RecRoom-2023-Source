"""Static matching Editor build APIs + unchanged RR23 settings/scene inventory."""
from pathlib import Path
import datetime as dt,json,mmap,re,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE))
from audit_cli_marshal_contracts import Cli,need
from audit_accessor_error_projection_static import sha

def inspect(path):
    type_names={'UnityEditor.BuildPipeline','UnityEditor.BuildPlayerOptions','UnityEditor.BuildOptions','UnityEditor.BuildTarget','UnityEditor.BuildTargetGroup','UnityEditor.ScriptingImplementation','UnityEditor.EditorBuildSettings','UnityEditor.EditorBuildSettingsScene','UnityEditor.Build.Reporting.BuildReport','UnityEditor.Build.Reporting.BuildSummary','UnityEditor.Build.Reporting.BuildResult','UnityEditor.Build.Reporting.BuildStep','UnityEditor.Build.Reporting.BuildStepMessage','UnityEditor.PlayerSettings','UnityEditor.ShaderUtil','UnityEditor.EditorSettings'}
    names={'BuildPlayer','GetBuildTargetGroup','IsBuildTargetSupported','GetPlaybackEngineDirectory','GetScriptingBackend','get_scenes','get_enabled','get_path','get_summary','get_steps','get_files','get_platform','get_options','get_outputPath','get_totalSize','get_totalErrors','get_totalWarnings','get_result','get_duration','get_buildStartedAt','get_buildEndedAt','get_messages','get_name','get_logWhenShaderIsCompiled','set_logWhenShaderIsCompiled','get_allowAsyncCompilation'}
    wanted_enum_fields={'StrictMode','None','Development','AutoRunPlayer','StandaloneWindows64','Standalone','Mono2x','IL2CPP','Unknown','Succeeded','Failed','Cancelled','Default'}
    rows=[];selectedfields=[];constants={};foundtypes=[]
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b)
        for rid in range(1,c.rows[11]+1):
            at=c.row(11,rid);kind=b[at];owner=c.value(at+2,c.coded(2,[4,8,23]));value=c.blob(c.value(at+2+c.coded(2,[4,8,23]),c.blobw));constants[(owner&3,owner>>2)]={'element_type':kind,'blob':value.hex(),'signed_int32':struct.unpack('<i',value)[0] if len(value)==4 else None}
        typedefs=[]
        for rid in range(1,c.rows[2]+1):
            at=c.row(2,rid);name=c.string(c.value(at+4,c.strw));ns=c.string(c.value(at+4+c.strw,c.strw));field=c.value(at+4+2*c.strw+c.coded(2,[2,1,27]),c.index(4));method=c.value(at+4+2*c.strw+c.coded(2,[2,1,27])+c.index(4),c.index(6));typedefs.append({'rid':rid,'name':(ns+'.' if ns else '')+name,'fields':field,'methods':method,'flags':c.u32(at)})
        for i,t in enumerate(typedefs):
            if t['name'] not in type_names:continue
            foundtypes.append(t);end=typedefs[i+1]['methods'] if i+1<len(typedefs) else c.rows[6]+1
            for rid in range(t['methods'],end):
                at=c.row(6,rid);name=c.string(c.value(at+8,c.strw));flags=c.u16(at+6)
                if name not in names:continue
                rows.append({'owner':t['name'],'name':name,'token':hex(0x06000000|rid),'flags':flags,'impl_flags':c.u16(at+4),'signature_blob':c.blob(c.value(at+8+c.strw,c.blobw)).hex(),'public':flags&7==6,'static':bool(flags&16)})
            fend=typedefs[i+1]['fields'] if i+1<len(typedefs) else c.rows[4]+1
            for rid in range(t['fields'],fend):
                at=c.row(4,rid);name=c.string(c.value(at+2,c.strw))
                if t['name'] not in ('UnityEditor.BuildPlayerOptions','UnityEditor.Build.Reporting.BuildStepMessage') and name not in wanted_enum_fields:continue
                selectedfields.append({'owner':t['name'],'name':name,'token':hex(0x04000000|rid),'flags':c.u16(at),'signature_blob':c.blob(c.value(at+2+c.strw,c.blobw)).hex(),'constant':constants.get((0,rid))})
    return {'path':str(path),'sha256':sha(path),'found_types':foundtypes,'methods':rows,'fields':selectedfields}

def main():
    project=WS/'RR23';build=project/'ProjectSettings/EditorBuildSettings.asset';settings=project/'ProjectSettings/ProjectSettings.asset';before={p:sha(p) for p in (build,settings)};text=build.read_text();scenes=[]
    for match in re.finditer(r'(?m)^  - enabled: (\d+)\r?\n    path: (.+?)\r?\n    guid: ([0-9a-f]{32})\r?$',text):
        enabled,path,guid=match.groups();p=project/path;meta=p.with_name(p.name+'.meta');meta_guids=re.findall(r'(?m)^guid: ([0-9a-f]{32})\r?$',meta.read_text()) if meta.is_file() else []
        scenes.append({'enabled':enabled=='1','path':path,'build_settings_guid':guid,'exists':p.is_file(),'bytes':p.stat().st_size if p.is_file() else None,'meta_exists':meta.is_file(),'meta_sha256':sha(meta) if meta.is_file() else None,'meta_guid':meta_guids[0] if len(meta_guids)==1 else None,'guid_matches':meta_guids==[guid]})
    need(len(scenes)==text.count('  - enabled:'),'All build scenes parsed exactly')
    player=settings.read_text();backend=re.search(r'(?m)^  scriptingBackend:([^\r\n]*)',player);apilevel=re.search(r'(?m)^  apiCompatibilityLevel:([^\r\n]*)',player)
    editor=WS/'Tools/Editors/2020.3.33f1/Editor';api=inspect(editor/'Data/Managed/UnityEditor.dll');variations=editor/'Data/PlaybackEngines/windowsstandalonesupport/Variations';available=sorted(p.name for p in variations.iterdir() if p.is_dir())
    for p,h in before.items():need(sha(p)==h,'Project settings changed during read-only audit')
    out=ROOT/'Validation'/('WindowsBuildAPI2020-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    r={'schema':'actual-Unity2020-Windows-build-API-and-unchanged-scene-settings/v1','status':'static_audit_only_no_build_or_Editor_launch','matching_version':'2020.3.33f1','Editor_API':api,'unchanged_settings':[{'path':str(p),'sha256':h} for p,h in before.items()],'scriptingBackend_serialized_line':backend.group(0) if backend else None,'runtime_backend_query_required':'PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone); empty serialized dictionary is not a runtime-query result','API_compatibility_serialized_line':apilevel.group(0) if apilevel else None,'build_scenes':scenes,'enabled_scene_count':sum(s['enabled'] for s in scenes),'all_enabled_scene_files_exist':all(s['exists'] for s in scenes if s['enabled']),'all_enabled_GUIDs_match_metas':all(s['guid_matches'] for s in scenes if s['enabled']),'matching_installed_windows_playback_variations':available,'IL2CPP_windows_support_installed':any('il2cpp' in n.casefold() for n in available),'Mono_windows64_support_installed':'win64_nondevelopment_mono' in available,'helper_contract':['query existing Standalone scripting backend without setting it; fail if current required playback engine absent','BuildPlayerOptions.scenes = EditorBuildSettings.scenes.Where(s=>s.enabled).Select(s=>s.path).ToArray() preserving order','target=StandaloneWindows64,targetGroup=Standalone,options=StrictMode with noAutoRunPlayer; explicit freshoutputlocation','BuildPipeline.BuildPlayer(options) -> BuildReport; require nonnull summary.result==Succeeded and totalErrors==0','record summary.outputPath,totalSize,totalErrors,totalWarnings and boundedstep messages; preserveactual failure report/log','recheck settings andscene/meta input hashes afterwards; do notSaveAssets or changebackend/graphics/platform/scenes','build outputs and user test are separate proof; stubbed startup/gameplay SDKs remain incomplete'],'Main_changed':False,'Unity_build_or_managed_job_launched':False}
    p=out/'report.json';p.write_text(json.dumps(r,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'scenes':len(scenes),'enabled':r['enabled_scene_count'],'all_exists':r['all_enabled_scene_files_exist'],'guid_match':r['all_enabled_GUIDs_match_metas'],'backend':r['scriptingBackend_serialized_line'],'playback':available,'public_buildplayer':[m for m in api['methods'] if m['name']=='BuildPlayer' and m['public']]}))

if __name__=='__main__':main()
