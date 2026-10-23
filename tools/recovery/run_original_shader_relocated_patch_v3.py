"""Root-only owned pure data patch phase; no compiler, Editor or player launch."""
from pathlib import Path
import argparse,json,sys
import run_windows_development_define_probe as guard


def main():
    ap=argparse.ArgumentParser(description=__doc__);ap.add_argument('--plan',required=True,type=Path);ap.add_argument('--plan-sha256',required=True);ap.add_argument('--output',required=True,type=Path);args=ap.parse_args()
    plan=args.plan.resolve(strict=True);out=args.output.resolve(strict=True);here=Path(__file__).resolve().parent
    guard.need(guard.sha(here/'patch_original_shader_collection_with_external_relocation.py')=='62b39e2d5d273870bb43d4415f8840a91bd8b6e2f4bb5700a747b37289ef69eb'
        and guard.sha(here/'run_windows_development_define_probe.py')=='685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc'
        and guard.sha(here/'owned_suspended_launch.py')=='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958',
        'Exact reviewed relocation patcher, unchanged guard and assign-before-resume launcher')
    guard.need(plan.is_relative_to(guard.ROOT/'AssetRecovery'),'Recovery-only explicit relocated patch plan')
    guard.need(guard.sha(plan)==args.plan_sha256 and out.parent==plan.parent and out.name=='PatchedNativeFiles-v3' and not any(out.iterdir()),'Fresh explicitly reviewed relocation plan/output')
    diagnostics=plan.parent/'PatchDiagnostics-v3'
    guard.need(not diagnostics.exists(),'Fresh one-shot diagnostics sibling required')
    diagnostics.mkdir()
    receipt={'schema':'Root-owned-179-original-Shader-native-relocation-patch/v1','status':'starting','phases':[],'Main_modified':False,'compiler_Unity_player_network_launched':False}
    try:
        guard.bounded([sys.executable,'-B',str(here/'patch_original_shader_collection_with_external_relocation.py'),'--plan',str(plan),'--plan-sha256',args.plan_sha256,'--output',str(out)],guard.WS,diagnostics,'pure179-original-payload-and-proven-native-data-relocation',512*1024**2,180,receipt);receipt['status']='passed'
    except BaseException as error:receipt.update(status='held',error=repr(error))
    guard.save(diagnostics,receipt);print(json.dumps({'status':receipt['status'],'receipt':str(diagnostics/'run-report.json'),'sha256':guard.sha(diagnostics/'run-report.json'),'error':receipt.get('error')}));return 0 if receipt['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
