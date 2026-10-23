"""Render existing inert original-action evidence; no game methods executed."""
import json,sys
from pathlib import Path
def main():
 folder=Path(sys.argv[1]);inventory=json.loads((folder/'login-action-disassembly-input.json').read_bytes());methods={r['original']['index']:r['original'] for r in inventory['methods']};proof=json.loads((folder/'login-action-dependencies.json').read_bytes());targets={int(r['native_target'],16):r for r in proof['native_target_registration_matches']};lines=[]
 for row in map(json.loads,(folder/'login-action-instructions-v2.jsonl').read_text().splitlines()):
  m=methods[row['native_method_index']];lines.append('\n'+m['owner']+'.'+m['name']+' '+m['token'])
  for ins in row['instructions']:
   extra=''
   if ins['operands']:
    target=targets.get(ins['operands'][0]['target'])
    if target:
     labels=[x.get('owner','?')+'.'+x.get('name','?') for x in target['direct_methods'][:5]]+[x.get('method',{}).get('owner','?')+'.'+x.get('method',{}).get('name','?')+'<'+','.join(x.get('class_arguments',[])+x.get('method_arguments',[]))+'>' for x in target['generic_methods'][:5]]
     extra=' ; direct='+str(target['direct_count'])+' generic='+str(target['generic_count'])+' '+', '.join(labels)
   lines.append(hex(ins['ip'])+' '+ins['text']+extra)
 out=folder/'login-action-instruction-summary.txt';out.write_text('\n'.join(lines)+'\n');print(str(out))
if __name__=='__main__':main()
