"""Bounded SDK target-reference closure over the latest exact225+core inputs."""
import argparse,json,uuid
from pathlib import Path
from datetime import datetime,timezone
import prepare_marshalling_integration as p
import build_stage_guarded as b
def main():
    a=argparse.ArgumentParser();a.add_argument('--runtime-plan',required=True,type=Path);a.add_argument('--core',required=True,type=Path);args=a.parse_args()
    output=p.ROOT/'RuntimeSDKRecovery'/('TestedSDKCurrentClosure-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);output.mkdir();runtime=p.read(args.runtime_plan)
    receipt=p.ROOT/'RuntimeSDKRecovery/ReferenceFixtureControls-20261022T142458Z-adfc2e45/report.json';controls=p.read(receipt);p.need(controls['status']=='passed' and controls['synthetic_controls']==8,'Pinned SDK reference controls must pass')
    helper=receipt.parent/'SDKReferenceAudit.exe';files=[Path(r['candidate']) for r in runtime['assemblies']]+[args.core.resolve()];p.need(len(files)==226 and len(set(files))==226,'Exact225 runtime+one latest restored core inputs')
    paths=output/'exact226-inputs.txt';paths.write_text('\n'.join(map(str,files))+'\n');target=[Path(r['candidate']).parent for r in runtime['assemblies'] if r['assembly'] in {'Unity.Addressables','Unity.ResourceManager'}];p.need(len(target)==2 and target[0]==target[1],'Exact tested SDK directory')
    report={'schema':'fresh226-runtime-core-genuine-SDK-closure/v1','phases':[],'inputs':[p.pinned(args.runtime_plan),p.pinned(args.core),p.pinned(receipt),p.pinned(helper)],'project_changed':False,'game_or_SDK_code_executed':False}
    try:
        for row in runtime['assemblies']:p.pinned(Path(row['candidate']),row['candidate_sha256'])
        closure=output/'closure.json';b.reserved_phase([b.EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',helper,paths,target[0],b.EDITOR,closure],output,'current226-target-SDK-reference-closure',report,maximum=90,cap=.0625)
        actual=p.read(closure);p.need(actual['status']=='passed' and actual['unresolved']==0 and actual['explicit_input_assemblies']==226,'Full exact current-input closure required')
        report.update(status='passed',explicit_assembly_count=226,unresolved=0,closure=p.pinned(closure),target_SDKs=2)
    except Exception as e:report.update(status='failed',error=str(e))
    (output/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(output/'report.json'),'error':report.get('error')}));return 0 if report['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
