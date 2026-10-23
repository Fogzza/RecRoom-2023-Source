"""Read actual Unity2020 API metadata for three existing Editor helper scripts.
No Editor/Mono/CLR target loading, reflection, or compilation is performed.
"""
from pathlib import Path
import datetime as dt, json, mmap, uuid
from audit_boot_candidate_dependency_closure import module_methods, compressed
from audit_cli_marshal_contracts import Cli, need
from audit_accessor_error_projection_static import ROOT, WS, sha

def named_type(c,table,rid):
    at=c.row(table,rid);prefix=4 if table==2 else c.coded(2,[0,26,35,1]);name=c.string(c.value(at+prefix,c.strw));ns=c.string(c.value(at+prefix+c.strw,c.strw));return (ns+'.' if ns else '')+name

def param_class(c,tail):
    b=bytes.fromhex(tail);need(b[:2]==bytes.fromhex('0112'),'Void method with one concrete class parameter required');coded,end=compressed(b,2);need(end==len(b),'Exactly one simple class parameter signature required');tag=coded&3;rid=coded>>2;need(tag in (0,1),'Only exact TypeDef/TypeRef class parameters supported');return named_type(c,2 if tag==0 else 1,rid)

def main():
    editor=WS/'Tools/Editors/2020.3.33f1/Editor/Data/Managed/UnityEditor.dll'
    selectors=[{'owner':'UnityEditor.AssetDatabase','name':'LoadMainAssetAtPath','parameters':1}, {'owner':'UnityEditor.AssetDatabase','name':'LoadAllAssetsAtPath','parameters':1}, {'owner':'UnityEditor.EditorUtility','name':'SetDirty','parameters':1}, {'owner':'UnityEditor.ShaderUtil','name':'RegisterShader','parameters':1}, {'owner':'UnityEditor.Audio.AudioMixerEffectController','name':'PreallocateGUIDs','parameters':0}, {'owner':'UnityEditor.Audio.MixerEffectDefinitions','name':'GetAudioEffectNames','parameters':0}]
    methods=module_methods(editor,selectors);types=[]
    with editor.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b);wanted={'UnityEditor.AssetPostprocessor','UnityEditor.AssetModificationProcessor','UnityEditor.Audio.AudioMixerEffectController','UnityEditor.Audio.MixerEffectDefinitions','UnityEditor.ShaderUtil'}
        for rid in range(1,c.rows[2]+1):
            full=named_type(c,2,rid)
            if full in wanted:types.append({'full_name':full,'TypeDef_token':'0x%08x'%(0x02000000|rid),'flags':c.u32(c.row(2,rid)),'assembly_file':str(editor)})
        need({t['full_name'] for t in types}==wanted,'All reflection/base types must exist in same actual AssetPostprocessor Editor assembly')
        for method in methods:
            need(method['flags']&7==6,'Helper uses only a public method: '+method['owner']+'.'+method['name'])
            expected_static=method['name']!='PreallocateGUIDs';need(bool(method['flags']&16)==expected_static,'Exact BindingFlags/public static or public instance mismatch')
            if method['name']=='PreallocateGUIDs':need(method['return_signature_start_hex']=='01','Exact void/noargs PreallocateGUIDs required')
            if method['name']=='GetAudioEffectNames':need(method['return_signature_start_hex']=='1d0e','Exact string[]/noargs GetAudioEffectNames required')
            if method['name']=='RegisterShader':need(param_class(c,method['return_signature_start_hex'])=='UnityEngine.Shader','Exact RegisterShader(Shader) public void API required')
            if method['name']=='SetDirty':need(param_class(c,method['return_signature_start_hex'])=='UnityEngine.Object','Exact SetDirty(Object) public void API required')
    scripts=WS/'RR23/Assets/Editor/AssetRipperPatches';files=[]
    for p in sorted(scripts.glob('*.cs')):
        files.append({'path':str(p),'sha256':sha(p),'meta':str(p)+'.meta','meta_sha256':sha(str(p)+'.meta')})
    need(len(files)==3,'Exactly three original AssetRipper Editor helpers')
    report={'schema':'actual-Unity2020-existing-AssetRipper-Editor-helper-static-API-audit/v1','status':'all_used_reflection_and_shader_registration_APIs_present_and_accessible','matching_Editor_assembly':{'path':str(editor),'sha256':sha(editor)},'types':types,'methods':methods,'unchanged_Main_helpers':files,'Editor_source_compile_executed':False,'actual_import_or_save_callbacks_executed':False,'helpers_included_in_code_only_harness':False,'reflection_runtime_GUID_retention_semantics_not_proven_by_signature_read':True,'known_asset_import_memory_and_shader_data_issues_not_covered_by_code_only_compile':True,'main_or_harness_modified':False,'CLR_game_or_Editor_code_invoked':False}
    out=ROOT/'Validation'/('MainARHelpersStaticAPI-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'status':report['status'],'methods':[{'owner':r['owner'],'name':r['name'],'flags':r['flags'],'sig':r['signature_blob_hex']} for r in methods]}))

if __name__=='__main__':main()
