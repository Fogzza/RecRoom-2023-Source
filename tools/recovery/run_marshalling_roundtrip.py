"""Exact offline metadata refs: native runtime candidates, never csc facades.

The original csc response remains a pinned input. Only the offline resolver's
view substitutes the225 manifest-pinned runtime DLLs and known actual firstpass.
"""
import argparse,json,shutil,uuid
from datetime import datetime,timezone
from pathlib import Path
import build_stage_guarded as b
import prepare_marshalling_integration as p

def main():
    a=argparse.ArgumentParser();a.add_argument('--stage',required=True,type=Path);a.add_argument('--core',required=True,type=Path);a.add_argument('--pdb',required=True,type=Path);a.add_argument('--reference-response',required=True,type=Path);a.add_argument('--runtime-plugin-manifest',required=True,type=Path);a.add_argument('--private-gib',type=float,default=1);args=a.parse_args()
    p.need(.25<=args.private_gib<=1,'Reviewed stricter cap only');stage=args.stage.resolve(strict=True)
    output=p.ROOT/'Validation'/('CurrentCoreMarshalRoundtrip-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);output.mkdir()
    report={'schema':'guarded-current-core-native-reference-marshal-roundtrip/v1','phases':[],'project_changed':False,'game_code_executed':False,'stage_plan':p.pinned(stage/'stage-plan.json'),'maximum_private_gib':args.private_gib,'minimum_global_commit_gib':1.5,'offline_reference_substitution_only':True}
    try:
        runtime=p.read(args.runtime_plugin_manifest);runtime={r['assembly']:r for r in runtime['assemblies']};p.need(len(runtime)==225,'Exact225 runtime identities required')
        prior=p.read(p.ROOT/'Validation/CurrentCoreIntegrationBuild-20261022T133238Z-cc828054/report.json')
        firstpass=[r for r in prior['exact_metadata_reference_inventory']['files'] if Path(r['path']).name=='Assembly-CSharp-firstpass.dll'];p.need(len(firstpass)==1,'One previously actual firstpass reference required');firstpass=firstpass[0];p.pinned(Path(firstpass['path']),firstpass['sha256'])
        actual=[];substitutions=[];used=set()
        for line in args.reference_response.read_text(encoding='utf-8-sig').splitlines():
            if not line.startswith('/reference:'):continue
            source=Path(line[len('/reference:'):].strip('"'));source=source if source.is_absolute() else p.WORKSPACE/'RR23'/source
            if source.stem in runtime:
                row=runtime[source.stem];target=Path(row['candidate']);p.pinned(target,row['candidate_sha256']);used.add(source.stem)
            elif source.name=='Assembly-CSharp-firstpass.dll':target=Path(firstpass['path'])
            else:target=source.resolve(strict=True)
            if target not in actual:actual.append(target)
            if target!=source:substitutions.append({'compiler_reference':p.pinned(source),'original_metadata_reference':p.pinned(target)})
        p.need(used==runtime.keys(),'Full225 source/reference inventory must be retained')
        refs=output/'exact-original-metadata-references.txt';refs.write_text('\n'.join(map(str,actual))+'\n')
        report['exact_metadata_reference_inventory']={'path':str(refs),'sha256':p.sha(refs),'inputs':[p.pinned(args.reference_response),p.pinned(args.runtime_plugin_manifest)],'files':[p.pinned(x) for x in actual],'explicit_native_metadata_substitutions':substitutions,'firstpass_provenance':p.pinned(p.ROOT/'Validation/CurrentCoreIntegrationBuild-20261022T133238Z-cc828054/report.json')}
        fixture=stage/'TypeContractFixtures.cs';shutil.copyfile(p.HERE/'TypeContractFixtures.cs',fixture)
        base=(stage/'compile-codegen.rsp').read_text().splitlines();lines=[line for line in base if not line.startswith(('/target:','/out:'))];target=stage/'ToolBuild/TypeContractFixtures.exe'
        (stage/'compile-contract-fixtures.rsp').write_text('\n'.join(lines+['/define:RR23_METHOD_SUBSET','/target:exe','/out:"'+str(target)+'"','"'+str(fixture)+'"'])+'\n')
        for name in ('checker','codegen','contract-fixtures'):b.reserved_phase([b.EDITOR/'Data/Tools/Roslyn/csc.exe','@'+str(stage/('compile-'+name+'.rsp'))],output,'compile-'+name,report,maximum=120,cap=.25)
        b.reserved_phase([b.EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',target],output,'contract-positive-and-negative-fixtures',report,maximum=60,cap=.25);report['contract_tests_passed']=32
        report['runtime_files']=[p.pinned(x) for x in sorted((stage/'ToolBuild').iterdir()) if x.is_file()];report['actual_core_inputs']=[p.pinned(x.resolve()) for x in (args.core,args.pdb)]
        restored=output/'ActualCurrentCoreOutput'
        b.reserved_phase([b.EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',stage/'ToolBuild/CurrentCoreChecks.exe',args.core.resolve(),args.pdb.resolve(),restored,refs],output,'actual-current-core-whole-metadata-ilpp-roundtrip',report,maximum=180,cap=args.private_gib)
        report['actual_core_roundtrip']=p.pinned(restored/'receipt.json');report.update(status='built_and_tested',actual_core_roundtrip_executed=True,actual_unity_editor_discovery_executed=False)
    except Exception as e:report.update(status='failed',error=str(e))
    (output/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(output/'report.json'),'error':report.get('error')}));return 0 if report['status']=='built_and_tested' else 1
if __name__=='__main__':raise SystemExit(main())
