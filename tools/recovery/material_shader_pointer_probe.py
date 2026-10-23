"""Prepare the pure Class21 reader; compile/probe require explicit switches.

Uses exact existing net10/AssetRipper references. Every compiler or data child
is assigned to its owned256MiB job while suspended, plus1.5GiB reserve.
"""
from pathlib import Path
import argparse
import datetime as dt
import json
import re
import shutil
import sys
import uuid
import run_windows_development_define_probe as guard
import map_shader_buildreport as native

HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]
ROOT=WS/'Recovery/RecRoom-2023-04-18/AssetRecovery'
BASE=ROOT/'OriginalShaderCollectionEditorConversion-20261023T030625Z-b13c1f0d/plan.json'
BASE_SHA='1ef005434acee2445e846ecdaabf34f2b11a533be2f59abb591e70acabcabecd'


def save(path,obj):
    with path.open('x',encoding='utf-8') as stream:
        json.dump(obj,stream,indent=2);stream.write('\n')


def prepare():
    guard.need(guard.sha(BASE)==BASE_SHA,'Proven matching pure converter plan changed')
    base=json.loads(BASE.read_bytes())
    for row in base['runtime']+base['references']+[base[k] for k in ('dotnet','compiler','response')]:guard.checked(row)
    out=ROOT/('OriginalMaterialShaderPointerProbe-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    source=out/'OriginalMaterialShaderPointerProbe.cs'
    shutil.copyfile(HERE/source.name,source)
    assembly=out/'OriginalShaderObjectProbe.dll'
    text=Path(base['response']['path']).read_text()
    text,count=re.subn(r'(?m)^/out:.*$',lambda _:'/out:"'+str(assembly)+'"',text)
    guard.need(count==1 and text.count('"'+base['source']['path']+'"')==1,'Exact proven response anchors required')
    text=text.replace('"'+base['source']['path']+'"','"'+str(source)+'"')
    response=out/'compile.rsp';response.write_text(text,encoding='utf-8',newline='\n')
    runtime=[]
    for row in base['runtime']:
        dest=out/Path(row['path']).name
        shutil.copyfile(row['path'],dest)
        guard.need(guard.sha(dest)==row['sha256'],'Exact pure runtime copy required')
        runtime.append(native.pin(dest))
    plan={'schema':'prepared-full-generated-Material-Shader-pointer-probe/v1','status':'prepared_no_child_started',
        'fixture':str(out),'source':native.pin(source),'source_original':native.pin(HERE/source.name),
        'response':native.pin(response),'output':str(assembly),'runtime':runtime,'references':base['references'],
        'dotnet':base['dotnet'],'compiler':base['compiler'],'runner':native.pin(Path(__file__)),
        'guard':native.pin(HERE/'run_windows_development_define_probe.py'),'launcher':native.pin(HERE/'owned_suspended_launch.py'),
        'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'Main_modified':False,'Unity_launched':False,
        'genuine_factory_API_source':native.pin(WS/'AR23Tool/Source/Source/AssetRipper.Import/AssetCreation/GameAssetFactory.cs')}
    path=out/'plan.json';save(path,plan)
    return path


def main():
    ap=argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--plan',type=Path)
    ap.add_argument('--plan-sha256')
    ap.add_argument('--compile',action='store_true')
    ap.add_argument('--object',type=Path)
    ap.add_argument('--object-sha256')
    ap.add_argument('--path-id')
    args=ap.parse_args()
    if not args.plan:
        guard.need(not args.compile and not args.object,'Prepare reviewed plan before any child launch')
        path=prepare()
        print(json.dumps({'status':'prepared_no_child_started','plan':native.pin(path)}));return 0
    path=args.plan.resolve(strict=True)
    guard.need(guard.sha(path)==args.plan_sha256,'Explicit reviewed plan pin required')
    plan=json.loads(path.read_bytes());fixture=Path(plan['fixture']).resolve(strict=True)
    guard.need(plan['schema']=='prepared-full-generated-Material-Shader-pointer-probe/v1'
               and fixture==path.parent and fixture.is_relative_to(ROOT)
               and fixture.name.startswith('OriginalMaterialShaderPointerProbe-'),'Exact isolated pure probe fixture required')
    for row in [plan[k] for k in ('source','source_original','response','dotnet','compiler','runner','guard','launcher','genuine_factory_API_source')]+plan['runtime']+plan['references']:guard.checked(row)
    out=fixture/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-full-generated-Class21-Shader-pointer/v1','status':'starting','plan':native.pin(path),
            'phases':[],'Main_modified':False,'Unity_launched':False,'game_or_native_code_executed':False}
    try:
        if args.compile:
            guard.need(not args.object and not Path(plan['output']).exists(),'Fresh compile only required')
            command=[plan['dotnet']['path'],plan['compiler']['path'],'/noconfig','@'+plan['response']['path']]
            guard.bounded(command,fixture,out,'compile-pure-Class21-reader',256*1024**2,30,report)
            report.update(status='compiled_full_generated_Class21_reader',assembly=native.pin(plan['output']))
            save(fixture/'compile-report.json',report)
        else:
            compiled=json.loads((fixture/'compile-report.json').read_bytes());guard.checked(compiled['assembly'])
            guard.need(compiled['status']=='compiled_full_generated_Class21_reader' and compiled['phases'][-1]['exit_code']==0,'Actual successful owned compilation required')
            raw=args.object.resolve(strict=True)
            guard.need(raw.is_relative_to(ROOT) and guard.sha(raw)==args.object_sha256 and raw.stat().st_size<=1024**2
                       and args.path_id is not None,'Exact isolated native Material input required')
            output=out/'material-pointer-report.json'
            command=[plan['dotnet']['path'],plan['output'],str(raw),args.object_sha256,args.path_id,str(output)]
            guard.bounded(command,fixture,out,'full-generated-Class21-read',256*1024**2,30,report)
            proof=json.loads(output.read_bytes())
            guard.need(proof['status']=='entire_Class21_read_and_exact_Release_roundtrip_verified','Actual full generated reader proof required')
            report.update(status='full_generated_Class21_pointer_read_verified',result=native.pin(output))
    except BaseException as exc:report.update(status='failed_or_guard_refused',error=repr(exc))
    finally:
        guard.save(out,report)
        print(json.dumps({'status':report['status'],'receipt':native.pin(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status']!='failed_or_guard_refused' else 1


if __name__=='__main__':raise SystemExit(main())
