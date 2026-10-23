"""Exact stock-writer ParsedForm subtree comparison. No YAML normalization."""
from pathlib import Path
import argparse,hashlib,json
def field_lines(path,name):
 inside=False;base=None;result=[]
 with Path(path).open(encoding='utf-8-sig',newline=None) as stream:
  for line in stream:
   line=line.rstrip('\n')
   if not inside:
    if line=='--- '+name+':':
     base=0;inside=True;result.append(name+':')
    elif line.lstrip(' ')==name+':':
     base=len(line)-len(line.lstrip(' '));inside=True;result.append(line[base:])
   else:
    indent=len(line)-len(line.lstrip(' '))
    if line and indent<=base:break
    result.append(line[base:])
 if not inside or len(result)<2:raise ValueError('Missing/empty exact field '+name)
 return result
def sha(p):return hashlib.file_digest(Path(p).open('rb'),'sha256').hexdigest()
def compare(original_form,current_asset):
 a=field_lines(original_form,'m_ParsedForm');b=field_lines(current_asset,'m_ParsedForm')
 digest=lambda rows:hashlib.sha256(('\n'.join(rows)+'\n').encode()).hexdigest()
 differences=[{'line':i+1,'original_line_sha256':hashlib.sha256(x.encode()).hexdigest(),'current_line_sha256':hashlib.sha256(y.encode()).hexdigest()} for i,(x,y) in enumerate(zip(a,b)) if x!=y]
 return {'schema':'exact-shader-parsed-form-comparison/v1','status':'exact' if a==b else 'different',
   'original':{'path':str(Path(original_form).resolve()),'sha256':sha(original_form),'lines':len(a),'subtree_sha256':digest(a)},
   'current':{'path':str(Path(current_asset).resolve()),'sha256':sha(current_asset),'lines':len(b),'subtree_sha256':digest(b)},
   'first_differences':differences[:16], 'differences_in_common_line_range':len(differences),
   'allowed_text_adjustments':['Uniform outer field indentation','Standalone diagnostic document start marker','CRLF/LF line terminator representation'],
   'numeric_values_or_field_order_normalized':False,'Main_modified':False}
def main():
 p=argparse.ArgumentParser();p.add_argument('original_form',type=Path);p.add_argument('current_asset',type=Path);p.add_argument('output',type=Path);a=p.parse_args()
 if a.output.exists():raise FileExistsError(a.output)
 result=compare(a.original_form,a.current_asset);a.output.write_text(json.dumps(result,indent=2)+'\n');print(json.dumps({'status':result['status'],'report':str(a.output)}))
 return 0 if result['status']=='exact' else 1
if __name__=='__main__':raise SystemExit(main())
