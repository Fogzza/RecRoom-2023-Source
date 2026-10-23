"""Join the final richer binder's missing subset to independent SRM witnesses.

The broad SRM diagnostic is NOT accepted as missing-body policy. Only the
independently bound subset (escaped names/in modifiers resolved) is admitted.
"""
import argparse
from collections import Counter
import json
from pathlib import Path
import re
import sys

HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE.parent))
from metadata_projection_subset import sha


def main():
    p=argparse.ArgumentParser();p.add_argument('--binding-audit',type=Path,required=True);p.add_argument('--srm-report',type=Path,required=True);p.add_argument('--output',type=Path,required=True);args=p.parse_args()
    if args.output.exists():raise FileExistsError('Fresh explicit subset file required')
    audit=json.loads(args.binding_audit.read_text());srm=json.loads(args.srm_report.read_text());rows_path=args.binding_audit.parent/'missing-originals.json'
    source=json.loads(rows_path.read_text());srm_rows={}
    with Path(srm['missing_rows']['path']).open() as stream:
        for line in stream:
            row=json.loads(line);srm_rows[(row['original_type'],row['original_canonical_signature'])]=row
    actual=[r for r in srm['inputs'] if Path(r['path']).name=='Assembly-CSharp.dll' and r['sha256']==audit['actual_sha256']]
    if len(actual)!=1 or sha(Path(audit['actual']))!=audit['actual_sha256'] or sha(Path(audit['raw']))!=audit['raw_sha256']:raise ValueError('Independent binder/SRM raw+actual inputs differ')
    enriched=[]
    for row in source:
        original=srm_rows[(row['owner'],row['original'])]
        match=re.fullmatch(r'\[Method:0x([0-9a-fA-F]+)\]',row['raw_CLI_token'])
        if not match or 0x06000000|int(match[1],16)!=int(original['original_provider_method_token'],16):raise ValueError('Independent original method RID differs')
        if original['original_semantics']!=0:raise ValueError('Missing accessor/event requires separate ownership plan')
        enriched.append({**original,'expected_compiled_canonical_signature':row['expected_compiled'],'binding_original_provider_token':row['raw_CLI_token'],
                         'scope':'Explicitly unrecovered original method; not emitted, no default body manufactured'})
    if len(enriched)!=audit['missing_originals'] or len({(r['original_type'],r['original_canonical_signature']) for r in enriched})!=len(enriched):raise ValueError('Missing subset count/identity differs')
    report={'schema':'reviewed-emitted-original-method-gap-subset/v1','raw_metadata':{'path':audit['raw'],'sha256':audit['raw_sha256']},'compiled_input':{'path':audit['actual'],'sha256':audit['actual_sha256']},
            'binding_audit':{'path':str(args.binding_audit.resolve()),'sha256':sha(args.binding_audit)},'binding_missing_rows':{'path':str(rows_path.resolve()),'sha256':sha(rows_path)},
            'independent_srm_report':{'path':str(args.srm_report.resolve()),'sha256':sha(args.srm_report)},'methods':enriched,'counts':dict(Counter(r['classification'] for r in enriched)),
            'body_invention_permitted':False,'numeric_output_token_preservation_claimed':False,'game_code_executed':False,'project_changed':False,
            'extra_adapter_acceptance_is_separate':True}
    args.output.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'output':str(args.output),'methods':len(enriched),'counts':report['counts']}))


if __name__=='__main__':main()
