"""Check name-only GetMethod reflection lookups without executing reflection."""
from pathlib import Path
import json,mmap
from audit_cli_marshal_contracts import Cli,need
from audit_accessor_error_projection_static import ROOT,WS,sha
from audit_boot_candidate_dependency_closure import method_shape
editor=WS/'Tools/Editors/2020.3.33f1/Editor/Data/Managed/UnityEditor.dll'
wanted={('UnityEditor.Audio.AudioMixerEffectController','PreallocateGUIDs'):False,('UnityEditor.Audio.MixerEffectDefinitions','GetAudioEffectNames'):True};matches={k:[] for k in wanted}
with editor.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
 c=Cli(b);types=[]
 for rid in range(1,c.rows[2]+1):
  at=c.row(2,rid);name=c.string(c.value(at+4,c.strw));ns=c.string(c.value(at+4+c.strw,c.strw));start=c.value(at+4+2*c.strw+c.coded(2,[2,1,27])+c.index(4),c.index(6));types.append({'name':(ns+'.' if ns else '')+name,'first':start})
 for index,t in enumerate(types):
  keys=[k for k in wanted if k[0]==t['name']]
  if not keys:continue
  last=types[index+1]['first'] if index+1<len(types) else c.rows[6]+1
  for rid in range(t['first'],last):
   at=c.row(6,rid);name=c.string(c.value(at+8,c.strw));flags=c.u16(at+6);key=(t['name'],name)
   if key in wanted and flags&7==6 and bool(flags&16)==wanted[key]:matches[key].append({'CLI_token':'0x%08x'%(0x06000000|rid),'flags':flags,**method_shape(c.blob(c.value(at+8+c.strw,c.blobw)))})
need(all(len(v)==1 and v[0]['parameter_count']==0 and v[0]['generic_arity']==0 for v in matches.values()),'Name-only reflection lookup has an unexpected public overload')
out=ROOT/'Validation/MainARHelpersStaticAPI-20261022T174619Z-e979f732/reflection-name-lookup.json';need(not out.exists(),'Fresh addendum required');r={'schema':'static-Editor-helper-name-only-reflection-overload-check/v1','status':'passed','Editor':{'path':str(editor),'sha256':sha(editor)},'lookups':[{'owner':k[0],'name':k[1],'public_static':wanted[k],'matching_declared_methods':v} for k,v in matches.items()],'managed_code_or_reflection_invoked':False,'project_modified':False};out.write_text(json.dumps(r,indent=2)+'\n');print(json.dumps({'report':str(out),'sha256':sha(out),'status':r['status']}))
