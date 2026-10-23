"""Read-only genuine same-Editor uGUI source and dummy runtime inventory."""
from pathlib import Path
import datetime as dt,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from audit_textmeshpro_recovery_candidate import cli_inventory
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
PKG=WS/'Tools/Editors/2020.3.33f1/Editor/Data/Resources/PackageManager/BuiltInPackages/com.unity.ugui'

def main():
    package=json.loads((PKG/'package.json').read_bytes());need(package['name']=='com.unity.ugui' and package['version']=='1.0.0','Exact same-Editor builtin source package')
    inventory=[]
    for p in sorted((PKG/'Runtime').rglob('*')):
        if p.is_file() and p.suffix in ('.cs','.asmdef','.meta'):inventory.append({'relative':p.relative_to(PKG).as_posix(),'sha256':sha(p),'bytes':p.stat().st_size})
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Exact original native source SHA')
    native=[];total_methods=0;total_fields=0
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);im=next(r for r in v.images if r['name']=='UnityEngine.UI.dll')
        for ti in range(im['start'],im['start']+im['count']):
            at=v.row('typeDefinitions',ti,88);mc=v.u16(md,at+64);fc=v.u16(md,at+68);native.append({**v.type_info(ti),'method_count':mc,'field_count':fc});total_methods+=mc;total_fields+=fc
    staged=cli_inventory(ROOT/'NativeGameplayRepairs/RuntimePluginMonoCompatibility-20261022T100750Z/UnityEngine.UI.dll');current=cli_inventory(WS/'RR23/Assets/Plugins/UnityEngine.UI.dll')
    asmdef=next((PKG/'Runtime').rglob('UnityEngine.UI.asmdef'));definition=json.loads(asmdef.read_bytes())
    out=ROOT/'Validation'/('UGUIRecoveryAudit-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'read-only-original-UGUI-and-genuine-same-Editor-builtin-source-candidate/v1','status':'same_Editor_builtin_source_available_runtime_logic_unrecovered_exact_contract_compile_pending','package_fields':package,'package_root':str(PKG),'package_json_sha256':sha(PKG/'package.json'),'license':{'path':str(PKG/'LICENSE.md'),'sha256':sha(PKG/'LICENSE.md')},'assembly_definition':{'path':str(asmdef),'sha256':sha(asmdef),'definition':definition},'runtime_source_inventory':inventory,'runtime_CSharp_files':sum(r['relative'].endswith('.cs') for r in inventory),'same_editor_version':'2020.3.33f1','original_upm_version_1_0_0_alone_not_exact_build_proof':True,'native_original_image':im,'native_original_counts':{'types':len(native),'methods':total_methods,'fields':total_fields},'native_original_types':native,'staged_runtime_UGUI':staged,'current_Main_UGUI':current,'no_duplicate_UPM_installation':True,'existing_engine_UIModule_is_distinct_from_highlevel_UnityEngine_UI_runtime':True,'next_gates':['compile unchanged same-Editor builtin source with exactPACKAGE_PHYSICS/PHYSICS2D/TILEMAP/ANIMATION versionDefines fromoriginal native API scope','compare every original native TypeDef/field/MethodDef token/flags/type shapes plus original layouts/constraints/overrides/property-event contracts','retain exact existingDLLmetaGUID/platformfilters; do not introduce parallelUnityEngine.UI UPMassembly','test genuineUI+TMP subset outsideMain before changing fixed225runtime-pinned maps'],'managed_child_or_Unity_launched':False,'Main_UPM_or_backend_modified':False}
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'native_counts':report['native_original_counts'],'stub_bodies':staged['body_classification'],'genuine_runtime_CS':report['runtime_CSharp_files'],'current_matches_stage':current['sha256']==staged['sha256']}))

if __name__=='__main__':main()
