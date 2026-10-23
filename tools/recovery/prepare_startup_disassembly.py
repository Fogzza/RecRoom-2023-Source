"""Select original login actions for inert disassembly; no target execution."""
import json,sys
from pathlib import Path
def main():
 folder=Path(sys.argv[1]);source=folder/'report.json';r=json.loads(source.read_bytes());wanted={'ManuallyLogin','LaunchGameCachedAccount','LaunchGameAccountCreation','GoToLogin','GoToLoginWithAnotherDevice','get_FlowModel','Update'};rows=[]
 for entry in r['critical_callback_inventory']:
  if entry['original']['name'] not in wanted:continue
  rows.append({'original':entry['original'],'native_pointer':entry['native_pointer'],'runtime_function':entry['native_region']})
 out=folder/'login-action-disassembly-input.json'
 if out.exists():raise ValueError('Fresh evidence required')
 out.write_text(json.dumps({'methods':rows},indent=2)+'\n');print(json.dumps({'methods':len(rows),'output':str(out)}))
if __name__=='__main__':main()
