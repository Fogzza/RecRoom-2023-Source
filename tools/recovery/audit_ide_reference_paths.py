"""Evaluate the exact literal Exists HintPath conditions in SolarNet projects.

This is an XML/path/hash audit, not a claim of MSBuild or IntelliSense success.
No inspected DLL is loaded and no project file is changed.
"""
import json,re,uuid,xml.etree.ElementTree as ET
from pathlib import Path
from datetime import datetime,timezone
import prepare_marshalling_integration as p
PROJECT=p.WORKSPACE/'RR23';NS={'m':'http://schemas.microsoft.com/developer/msbuild/2003'}
def expand(s):
 s=s.replace('$(SolarNetProjectRoot)',str(PROJECT)+'\\').replace('$(UnityEditorRoot)',str(p.WORKSPACE/'Tools/Editors/2020.3.33f1/Editor')+'\\')
 p.need('$(' not in s,'Unsupported MSBuild property in exact HintPath');return Path(s).resolve()
def run():
 out=p.ROOT/'Validation'/('SolarNetIDEReferencePaths-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();rows=[]
 for name in ('Assembly-CSharp.csproj','Assembly-CSharp-firstpass.csproj'):
  file=PROJECT/name;xml=ET.parse(file);refs=[]
  for reference in xml.findall('.//m:Reference',NS):
   hints=[];selected=None
   for hint in reference.findall('m:HintPath',NS):
    condition=hint.get('Condition');active=True
    if condition:
     match=re.fullmatch(r"(!?)Exists\('([^']+)'\)",condition);p.need(match is not None,'Only exact literal Exists hint conditions admitted');active=expand(match[2]).exists();active=not active if match[1] else active
    path=expand(hint.text);hints.append({'condition':condition,'active':active,'path':str(path),'exists':path.is_file()})
    if active:selected=path
   p.need(selected is not None,'Every explicit reference must select a path');refs.append({'name':reference.get('Include'),'effective_path':str(selected),'exists':selected.is_file(),'sha256':p.sha(selected) if selected.is_file() else None,'conditional_paths':hints})
  sources=[(PROJECT/x.get('Include')).resolve() for x in xml.findall('.//m:Compile',NS)]
  rows.append({'project':p.pinned(file),'references':refs,'reference_count':len(refs),'effective_missing':sum(not r['exists'] for r in refs),'effective_Recovery_fallbacks':sum('/Recovery/' in r['effective_path'].replace('\\','/') for r in refs),'source_files':len(sources),'missing_source_files':[str(s) for s in sources if not s.is_file()]})
 report={'schema':'conditional-MSBuild-HintPath-literal-XML-audit/v1','status':'static_paths_evaluated_not_design_time_built','props':p.pinned(PROJECT/'SolarNet.Unity2020.props'),'solution':p.pinned(PROJECT/'SolarNet.sln'),'projects':rows,'project_modified':False,'game_code_loaded_or_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'summary':[{k:r[k] for k in ('reference_count','effective_missing','effective_Recovery_fallbacks','source_files','missing_source_files')} for r in rows]}))
if __name__=='__main__':run()
