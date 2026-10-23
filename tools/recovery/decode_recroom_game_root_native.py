"""Use already-built trusted Iced decoder on bounded original byte records only."""
from pathlib import Path
import hashlib,json,sys
from run_win32_abi_compat_fixture import phase,ROOT,need
HERE=Path(__file__).resolve().parent
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def main():
 folder=ROOT/'Validation/RecRoomGameRootNative-20261022T162444Z-d9c732b7';report=folder/'report.json';need(sha(report)=='9492989fb0f23794155b1e0bd6e9ae25eeae2fc86687a9e1016abfb14617d7f6','Pinned originalstartup inventory');r=json.loads(report.read_text());inp=folder/'bounded-decoder-input.json';need(not inp.exists(),'Fresh input');rows=[x for x in r['methods'] if 'runtime_function'in x];inp.write_text(json.dumps({'methods':rows})+'\n');decoder=HERE/'PInvokeDisassembler-20261022T124000Z/DisassemblePInvokeWrappers.dll';need(decoder.is_file(),'Alreadybuiltdecoder required');out=folder/'decoded-instructions.jsonl';need(not out.exists(),'Fresh decoded output');receipt={'schema':'bounded-native-startup-static-decode/v1','input':{'path':str(inp),'sha256':sha(inp)},'decoder':{'path':str(decoder),'sha256':sha(decoder)},'game_or_native_code_executed':False}
 try:
  receipt['guard']=phase([r'C:\Program Files\dotnet\dotnet.exe',decoder,inp,out],folder,'decode-inert-native-bytes',64*1024**2,15);receipt.update(status='passed',output={'path':str(out),'sha256':sha(out)})
 except BaseException as e:receipt.update(status='failed',error=repr(e))
 target=folder/'decode-receipt.json';target.write_text(json.dumps(receipt,indent=2)+'\n');print(json.dumps({'report':str(target),'sha256':sha(target),'status':receipt['status'],'error':receipt.get('error')}));return 0 if receipt['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
