"""Freeze exact prior tool inputs, accepting reconstructions only by pinned SHA."""
from pathlib import Path
import hashlib,json
HERE=Path(__file__).resolve().parent
ROOT=HERE.parents[2]/'Recovery/RecRoom-2023-04-18'
candidate=ROOT/'RuntimeSDKRecovery/Addressables-1.20.5/Candidate-20261022T140449Z-3b2b5cb0'
report=json.loads((candidate/'report.json').read_text())
output=candidate/'PinnedToolSourceSnapshots'
output.mkdir(exist_ok=False)
rows=[]
for row in report['inputs']:
    source=Path(row['path']);data=source.read_bytes()
    if hashlib.sha256(data).hexdigest()!=row['sha256']:
        text=data.decode()
        if source.name=='SDKReferenceAudit.cs':
            text=text.replace('internal static partial class SDKReferenceAudit','internal static class SDKReferenceAudit')
            text=text.replace('        if(args.Length==3&&args[0]=="--fixtures")return ReferenceFixtures(args[1],args[2]);\n','')
        elif source.name=='build_official_addressables.py':
            text=text.replace(",'\"'+str(HERE/'SDKReferenceFixtures.cs')+'\"'",'')
            text=text.replace(", HERE/'SDKReferenceFixtures.cs'",'')
        data=text.encode()
        if hashlib.sha256(data).hexdigest()!=row['sha256']:raise ValueError('Unable to archive exact original tool input '+source.name)
    target=output/source.name;target.write_bytes(data)
    rows.append({'original_path':str(source),'expected_sha256':row['sha256'],'immutable_snapshot':str(target),'snapshot_sha256':hashlib.sha256(data).hexdigest()})
(output/'manifest.json').write_text(json.dumps({'status':'all_original_tool_input_hashes_archived_exactly','source_report':str(candidate/'report.json'),'source_report_sha256':hashlib.sha256((candidate/'report.json').read_bytes()).hexdigest(),'inputs':rows},indent=2)+'\n')
print('Archived exact original SDK audit source inputs:',len(rows))
