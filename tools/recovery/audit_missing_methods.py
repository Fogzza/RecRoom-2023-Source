"""Bounded original-method subset inventory; never load/execute inspected code."""
import argparse
from collections import Counter
from datetime import datetime, timezone
import importlib.util
import json
from pathlib import Path
import sys
import uuid

HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('missing_method_guard',HERE.parent/'MovementRequestEvidence/run_guarded.py');guard=importlib.util.module_from_spec(spec);spec.loader.exec_module(guard)
def main():
    p=argparse.ArgumentParser();p.add_argument('--stage',type=Path,required=True);p.add_argument('--core',type=Path,required=True);args=p.parse_args()
    out=ROOT/'Validation'/('MissingOriginalMethods-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'current-emitted-original-method-subset-inventory/v1','phases':[],'project_changed':False,'game_code_executed':False}
    try:
        stage=args.stage.resolve();plan=json.loads((stage/'stage-plan.json').read_text());source=HERE/'MissingOriginalMethods.cs';host=out/'MissingOriginalMethods.dll';rsp=out/'compile.rsp'
        rsp.write_text('\n'.join(['/nologo','/target:exe','/nullable:enable','/langversion:latest',f'/out:"{host}"']+[f'/reference:"{x}"' for x in sorted(guard.REF.glob('*.dll'))]+[f'"{source}"'])+'\n')
        guard.phase([guard.DOTNET,guard.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-signature-reader',report,maximum=60,cap=.2)
        host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}))
        target=out/'missing-original-methods.jsonl';raw=Path(plan['original_metadata']['path']);manifest=Path(plan['manifest']['path'])
        guard.phase([guard.DOTNET,host,raw,args.core.resolve(),manifest,target],out,'read-signatures-and-explicit-missing-subset',report,maximum=120,cap=.25)
        counts=Counter();count=0
        with target.open() as s:
            for line in s:row=json.loads(line);counts[row['classification']]+=1;count+=1
        report.update(status='inventoried',missing_original_methods=count,classifications=dict(counts),missing_rows={'path':str(target),'sha256':guard.sha(target)},inputs=[{'path':str(x),'sha256':guard.sha(x)} for x in (raw,args.core.resolve(),manifest)],reader={'path':str(source),'sha256':guard.sha(source)})
    except Exception as e:report.update(status='failed',error=str(e))
    result=out/'report.json';result.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(result),'missing':report.get('missing_original_methods'),'classifications':report.get('classifications'),'error':report.get('error')}));return 0 if report['status']=='inventoried' else 1
if __name__=='__main__':raise SystemExit(main())
