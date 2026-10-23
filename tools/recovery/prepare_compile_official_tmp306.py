"""Prepare reproducible official TMP compile/contract checks, no Main writes.

Default only prepares exact inputs. --run is separately coordinated and uses
256MiB/60s per owned child plus1.5GiB system-commit reserve. Inspected SDK DLLs
are only read by trusted Cecil; no SDK/game method is loaded/invoked.
"""
from pathlib import Path
import argparse,datetime as dt,difflib,importlib.util,json,shutil,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE))
from build_stage_guarded import reserved_phase
from audit_textmeshpro_recovery_candidate import cli_inventory
from audit_official_sdk_native_identity import inventory,compare
from audit_forwarding import EXPECTED,sha
from collect_all_pinvoke_native import ExternMetadata,need
import mmap

OFFICIAL=ROOT/'Validation/OfficialTextMeshPro306-20261022T182833Z-f0f56396/report.json'
OFFICIAL_SHA='3f663e1fa6898229805ab7b652d55fa26c606322837df1faf21051055d1d81e7'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'
STAGED=ROOT/'NativeGameplayRepairs/RuntimePluginMonoCompatibility-20261022T100750Z'

def pin(p):return {'path':str(p),'sha256':sha(p)}
def prepare():
    need(sha(OFFICIAL)==OFFICIAL_SHA,'Pinned official package provenance changed')
    evidence=json.loads(OFFICIAL.read_bytes());cache=Path(evidence['cache_path']);sources=[]
    for row in evidence['matched_runtime_and_package_files']:
        p=cache/row['relative'];need(sha(p)==row['official_sha256'],'Official cached source drift')
        if p.suffix=='.cs':sources.append(p)
    need(len(sources)>40 and all(p.is_relative_to(cache/'Scripts/Runtime') for p in sources),'Runtime-only genuine package sources')
    out=ROOT/'RuntimeSDKRecovery'/('OfficialTMP306Compile-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);(out/'PlayerWindows').mkdir(parents=True);(out/'ToolInputs').mkdir()
    framework=EDITOR/'Data/MonoBleedingEdge/lib/mono/unityaot';refs=[framework/name for name in ('mscorlib.dll','System.dll','System.Core.dll')]
    refs += sorted(p for p in (EDITOR/'Data/Managed/UnityEngine').glob('UnityEngine*.dll') if p.name!='UnityEngine.UI.dll')
    refs += [STAGED/'UnityEngine.UI.dll']
    need(all(p.is_file() for p in refs),'All exact matching Editor/AOT/UI compiler references required')
    defines=['UNITY_2020_3','UNITY_2020_3_OR_NEWER','UNITY_2020_2_OR_NEWER','UNITY_2020_1_OR_NEWER','UNITY_2019_4_OR_NEWER','UNITY_2019_3_OR_NEWER','UNITY_2019_2_OR_NEWER','UNITY_2019_1_OR_NEWER','UNITY_2018_4_OR_NEWER','UNITY_2018_3_OR_NEWER','UNITY_2018_2_OR_NEWER','UNITY_2018_1_OR_NEWER','UNITY_2017_4_OR_NEWER','UNITY_2017_3_OR_NEWER','UNITY_2017_2_OR_NEWER','UNITY_2017_1_OR_NEWER','UNITY_5_3_OR_NEWER','UNITY_STANDALONE_WIN','UNITY_STANDALONE','UNITY_64','ENABLE_IL2CPP','NET_4_6']
    sdk=out/'PlayerWindows/Unity.TextMeshPro.dll';rsp=out/'official-player.rsp'
    rsp.write_text('\n'.join(['/nologo','/noconfig','/nostdlib+','/target:library','/optimize+','/debug:portable','/langversion:8','/define:'+';'.join(defines),'/out:"'+str(sdk)+'"']+['/reference:"'+str(p)+'"' for p in refs]+['"'+str(p)+'"' for p in sources])+'\n')
    # Versioned stricter metadata reader: no source-original generated gaps waived.
    original=HERE/'SDKContractAudit.cs';reader=(original.read_text()).replace('\r\n','\n')
    old='string scope=t.Scope is AssemblyNameReference?((AssemblyNameReference)t.Scope).Name:t.Module.Assembly.Name.Name;'
    new='string scope=t.Scope is AssemblyNameReference?(SimpleScopes?((AssemblyNameReference)t.Scope).Name:((AssemblyNameReference)t.Scope).FullName):(SimpleScopes?t.Module.Assembly.Name.Name:t.Module.Assembly.Name.FullName);'
    need(reader.count(old)==1,'Exact SDK reader scope expression');reader=reader.replace(old,new)
    reader=reader.replace('static string Sha(string path)', 'static bool SimpleScopes;\n    static string Sha(string path)',1)
    reader=reader.replace('if(args.Length==3&&args[0]=="--native-rows") {','if(args.Length==3&&args[0]=="--native-rows") { SimpleScopes=true;',1)
    # Keep generated omissions visible and fatal to equality, preserving original signatures.
    old='if(Generated(raw)) generatedMissing++;else {issues.Add(new {kind="missing-original-type",owner=raw.FullName,original_token=raw.MetadataToken.ToUInt32(),is_public=Public(raw)});if(Public(raw))publicGaps++;}'
    new='if(Generated(raw)) generatedMissing++;issues.Add(new {kind="missing-original-type",owner=raw.FullName,original_token=raw.MetadataToken.ToUInt32(),is_public=Public(raw),compiler_generated=Generated(raw)});if(Public(raw))publicGaps++;'
    need(reader.count(old)==1,'Exact missing-type policy');reader=reader.replace(old,new)
    old='if(!Generated(raw)){issues.Add(new {kind="missing-or-ambiguous-original-method",owner=raw.FullName,signature=shape,token=method.MetadataToken.ToUInt32(),is_public=method.IsPublic});if(pub&&method.IsPublic)publicGaps++;}'
    new='issues.Add(new {kind="missing-or-ambiguous-original-method",owner=raw.FullName,signature=shape,token=method.MetadataToken.ToUInt32(),is_public=method.IsPublic,compiler_generated=Generated(raw)});if(pub&&method.IsPublic)publicGaps++;'
    need(reader.count(old)==1,'Exact missing-method policy');reader=reader.replace(old,new)
    old='if(method.Attributes!=cm.Attributes||method.ImplAttributes!=cm.ImplAttributes'
    new='if(!method.Overrides.Select(Override).OrderBy(s=>s,StringComparer.Ordinal).SequenceEqual(cm.Overrides.Select(Override).OrderBy(s=>s,StringComparer.Ordinal))||method.Attributes!=cm.Attributes||method.ImplAttributes!=cm.ImplAttributes'
    need(reader.count(old)==1,'Exact MethodImpl comparison point');reader=reader.replace(old,new)
    helper='static string Override(MethodReference m) { return T(m.DeclaringType)+"::"+m.Name+"``"+m.GenericParameters.Count+"("+String.Join(",",m.Parameters.Select(p=>T(p.ParameterType)))+")->"+T(m.ReturnType)+":"+m.HasThis+":"+m.ExplicitThis+":"+(int)m.CallingConvention; }\n    '
    reader=reader.replace('static string M(MethodDefinition m)',helper+'static string M(MethodDefinition m)',1)
    snapshot=out/'ToolInputs/TMPStrictContractAudit.cs';snapshot.write_text(reader)
    fixtures=out/'ToolInputs/SDKContractFixtures.cs';shutil.copyfile(HERE/fixtures.name,fixtures)
    diff=out/'ToolInputs/strict-reader.diff';diff.write_text(''.join(difflib.unified_diff(original.read_text().replace('\r\n','\n').splitlines(True),reader.splitlines(True),fromfile='SDKContractAudit.cs',tofile='TMPStrictContractAudit.cs')))
    cecil=EDITOR/'Data/Managed/Unity.Cecil.dll';need(cecil.is_file(),'Genuine matching Editor Cecil required');shutil.copyfile(cecil,out/'Unity.Cecil.dll')
    toolframework=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';toolrefs=[toolframework/x for x in ('mscorlib.dll','System.dll','System.Core.dll','System.Web.Extensions.dll')]+[cecil]
    tool=out/'TMPStrictContractAudit.exe';trsp=out/'metadata-reader.rsp';trsp.write_text('\n'.join(['/nologo','/noconfig','/nostdlib+','/target:exe','/langversion:8','/out:"'+str(tool)+'"']+['/reference:"'+str(p)+'"' for p in toolrefs]+['"'+str(snapshot)+'"','"'+str(fixtures)+'"'])+'\n')
    report={'schema':'official-TMP3.0.6-exact2020-outside-Main-compile-plan/v1','status':'prepared_not_run','official_provenance':pin(OFFICIAL),'sources':[pin(p) for p in sources],'profile_defines':defines,'original_player_development_and_inputsystem_symbols_not_yet_proven':True,'SDK_refs':[pin(p) for p in refs],'SDK_ugui_reference_is_exact_API_stub_body_not_executed':True,'tool_refs':[pin(p) for p in toolrefs],'copied_reader_dependency':pin(out/'Unity.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'matching_Mono_metadata_only_host':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'reader_original_source':pin(original),'reader_snapshot':pin(snapshot),'reader_exact_diff':pin(diff),'fixture_source':pin(fixtures),'response_files':[pin(rsp),pin(trsp)],'compiled_candidate_expected':str(sdk),'metadata_reader_expected':str(tool),'original_layout_reference':pin(STAGED/'Unity.TextMeshPro.dll'),'phases':[],'Main_or_packages_modified':False,'SDK_or_game_methods_executed':False,'automatic_runtime_replacement_permitted':False,'original_LocalizedTmpFont_bridge_explicitly_must_be_preserved':True}
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');return out,p,report

def run(out,path,report):
    compiler=Path(report['compiler']['path']);sdk=Path(report['compiled_candidate_expected']);tool=Path(report['metadata_reader_expected']);mono=Path(report['matching_Mono_metadata_only_host']['path'])
    try:
        for key in ('official_provenance','copied_reader_dependency','compiler','matching_Mono_metadata_only_host','reader_snapshot','fixture_source','original_layout_reference'):
            row=report[key];need(sha(row['path'])==row['sha256'],'Pinned trusted tool/provenance input drift: '+key)
        for section in ('sources','SDK_refs','tool_refs','response_files'):
            for row in report[section]:need(sha(row['path'])==row['sha256'],'Pinned compile input drift: '+section)
        for label,rsp in [('compile-unchanged-official-runtime','official-player.rsp'),('compile-trusted-strict-reader','metadata-reader.rsp')]:reserved_phase([compiler,'@'+str(out/rsp)],out,label,report,maximum=60,cap=.25)
        reserved_phase([mono,tool,'--fixtures',out/'ReaderFixtures'],out,'reader-positive-negative-controls',report,maximum=30,cap=.25)
        rows=out/'genuine-source-native-rows.json';reserved_phase([mono,tool,'--native-rows',sdk,rows],out,'SDK-metadata-no-code-execution',report,maximum=30,cap=.25)
        baseline=STAGED/'Unity.TextMeshPro.dll';comparison=out/'original-contract-comparison.json';reserved_phase([mono,tool,baseline,baseline,sdk,comparison],out,'all-original-type-field-method-property-event-override-contracts',report,maximum=60,cap=.25)
        originalpaths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
        for p in originalpaths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Exact original source SHA')
        with originalpaths[0].open('rb') as bf,originalpaths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
            original=inventory(ExternMetadata(b,md),'Unity.TextMeshPro');compared=compare(original,json.loads(rows.read_bytes()))
        native=out/'direct-original-native-contract-comparison.json';native.write_text(json.dumps({'schema':'native-v27-versus-official-TMP3.0.6-source-compiled-contracts/v1','status':'passed' if not compared['errors'] else 'differences_found_not_replacement_approved','original_native_inputs':[pin(p) for p in originalpaths],'original_types':original,**compared},indent=2)+'\n')
        for row in report['sources']+report['SDK_refs']+report['tool_refs']:
            need(sha(row['path'])==row['sha256'],'SDK source/reference changed during proof')
        report.update(status='compiled_and_contract_audited_no_apply',compiled_candidate=pin(sdk),candidate_body_inventory=cli_inventory(sdk),native_comparison=pin(native),original_fullscope_contract_comparison=pin(comparison),candidate_rows=pin(rows),original_native_contract_errors=len(compared['errors']))
    except BaseException as error:report.update(status='failed_or_admission_refused_no_apply',error=repr(error))
    path.write_text(json.dumps(report,indent=2)+'\n');return report

def main():
    p=argparse.ArgumentParser();p.add_argument('--run',action='store_true');a=p.parse_args();out,path,r=prepare()
    if a.run:r=run(out,path,r)
    print(json.dumps({'report':str(path),'sha256':sha(path),'status':r['status'],'error':r.get('error'),'native_errors':r.get('original_native_contract_errors')}))

if __name__=='__main__':main()
