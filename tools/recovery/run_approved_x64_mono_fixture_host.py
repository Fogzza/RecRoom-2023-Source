"""Invoke only the parent-reviewed fixed-path nongame matching-Mono x64 host."""
import ctypes,hashlib,json,sys
from pathlib import Path
from run_win32_abi_compat_fixture import phase,need,ROOT
APPROVED_PLAN_SHA='27b03e68eb4d4059c9a73d42e50bd320956e951f4c496ec54ee00120040f1403'
APPROVED_SOURCE_SHA='15e6932c060ba075bafadfda653d048c22788ea68c2b64628ad3681f492e9cae'
def sha(p):
 with p.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def main():
 folder=Path(sys.argv[1]);need(folder==ROOT/'Validation/MonoX64MarshalCompatibility-20261022T142400Z','Exact reviewed fixture host only');path=folder/'plan.json';need(sha(path)==APPROVED_PLAN_SHA,'Approved host plan drift');plan=json.loads(path.read_bytes());need(plan['status']=='compiled_not_invoked' and plan['source']['sha256']==APPROVED_SOURCE_SHA and not plan['host_invoked'],'Exact reviewed compiled source required')
 for row in plan['inputs']+[plan['source'],plan['host']]:need(sha(Path(row['path']))==row['sha256'],'Reviewed host/runtime/fixture input drift')
 out=folder/'x64-runtime-abi-proof.json';need(not out.exists(),'Fresh owned fixture run required');report={'schema':'matching-Unity2020-x64-Mono-own-native-ABI-fixture/v1','plan':{'path':str(path),'sha256':sha(path)},'scope':'Only parent-reviewed own managed probe + own no-import nativeDLL via matching Editor x64 EmbedRuntime','actual_RR23_or_harness_modified':False,'Windows_trust_device_game_or_vendor_API_invoked':False,'original_lost_marshal_descriptor_blobs_recovered':False};kernel=ctypes.WinDLL('kernel32',use_last_error=True);kernel.SetErrorMode.argtypes=[ctypes.c_uint];kernel.SetErrorMode.restype=ctypes.c_uint;prior=kernel.SetErrorMode(0x8003)
 try:
  report['run']=phase([Path(plan['host']['path'])],folder,'matching-Mono-x64-run',256*1024**2,15);text=(folder/'matching-Mono-x64-run/output.log').read_text(errors='replace');need('U4_OUT_ALL_BITS_OK DEADBEEF' in text and 'LPSTRUCT_GUID_ALL16_BYTES_OK 16_NEGATIVES_REJECTED' in text and 'INERT_NATIVE_ABI_COMPATIBILITY_OK' in text,'Expected ABI proof markers missing');report.update(status='passed',uint32_full_bit_pattern_preserved=True,Guid_all16_bytes_preserved=True,mutated_Guid_variants_rejected=16)
 except Exception as error:report.update(status='failed',error=repr(error))
 finally:kernel.SetErrorMode(prior)
 report['log']={'path':str(folder/'matching-Mono-x64-run/output.log'),'sha256':sha(folder/'matching-Mono-x64-run/output.log')};out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out),'sha256':sha(out),'error':report.get('error')}));return 0 if report['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
