"""Inspect installed native metadata/disassembler help with tiny owned guard."""
from pathlib import Path
import datetime as dt,json,uuid
from run_win32_abi_compat_fixture import phase,ROOT
def main():
 folder=ROOT/'Validation'/('NativeDisassemblerHelp-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);folder.mkdir();tool=Path(r'C:\Program Files\Microsoft Visual Studio\18\Community\VC\Tools\MSVC\14.51.36231\bin\Hostx64\x64\dumpbin.exe')
 try:report={'status':'passed','guard':phase([tool,'/help'],folder,'native-help-only',32*1024**2,10)}
 except BaseException as e:report={'status':'failed','error':repr(e)}
 (folder/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'folder':str(folder),**report}))
if __name__=='__main__':main()
