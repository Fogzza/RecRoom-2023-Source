"""Independent raw ECMA metadata check of partial335 overlay; no managed load."""
import argparse,datetime as dt,hashlib,importlib.util,json,mmap,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';spec=importlib.util.spec_from_file_location('raw_cli',HERE/'audit_cli_marshal_contracts.py');raw=importlib.util.module_from_spec(spec);spec.loader.exec_module(raw)
def sha(p):return hashlib.sha256(Path(p).read_bytes()).hexdigest()
def need(ok,why):
    if not ok:raise ValueError(why)
def inventory(path):
    with Path(path).open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:return raw.Cli(b).audit()
def owners(report):
    blobs={r['table_rid']:r['blob_hex'] for r in report['FieldMarshal_rows']};result={}
    for row in report['flagged_fields']:
        key=('field',row['owner']['display_owner'],row['name']);need(key not in result,'Duplicate field');result[key]={'blob':blobs.get(row['FieldMarshal_table_rid']),'flags':row['flags'],'token':row['current_field_token']}
    for row in report['flagged_parameters']:
        key=('parameter',row['method']['owner']['display_owner'],row['method']['name'],row['sequence'],row['parameter_name']);need(key not in result,'Ambiguous parameter');result[key]={'blob':blobs.get(row['FieldMarshal_table_rid']),'flags':row['flags'],'token':row['current_parameter_token']}
    return result
def main():
    parser=argparse.ArgumentParser();parser.add_argument('--stage-report',required=True,type=Path);args=parser.parse_args();stage=json.loads(args.stage_report.read_text());need(stage['status']=='passed','Stage has not passed');overlay_path=Path(stage['overlay']['path']);need(sha(overlay_path)==stage['overlay']['sha256'],'Overlay changed');overlay=json.loads(overlay_path.read_text());candidate=Path(stage['candidate']['path']);need(sha(candidate)==stage['candidate']['sha256'],'Candidate changed');a=inventory(overlay['sdk_path']);b=inventory(candidate);old=inventory(overlay['target_path']);aa=owners(a);bb=owners(b);oo=owners(old);need(len(a['FieldMarshal_rows'])==len(b['FieldMarshal_rows'])==335,'335raw rows required');need(len(bb)==len(oo)==355,'All355 original flagged owners must remain');need(b['malformed_field_count']==17 and b['malformed_parameter_count']==3,'Unresolved20 inventory changed');rows=[];seen=set()
    for row in overlay['bindings']:
        if row['kind']=='field':sk=('field',row['sdk_owner'],row['sdk_name']);tk=('field',row['owner'],row['name'])
        else:sk=('parameter',row['sdk_owner'],row['sdk_name'],row['sequence'],row['sdk_parameter_name']);tk=('parameter',row['owner'],row['signature'].split(' ',1)[1].split('(',1)[0],row['sequence'],row['name'])
        need(sk in aa and tk in bb and tk in oo,'Exact source/target raw owner absent');left,right,original=aa[sk],bb[tk],oo[tk];expected=bytes([int(row['descriptor'].split(':')[1])]).hex();need(left['blob']==right['blob']==expected and original['blob'] is None,'Exact source raw descriptor differs');need(left['flags']==right['flags']==original['flags']==row['flags'],'Native flags changed');need(tk not in seen,'Duplicate native owner');seen.add(tk);rows.append({'sdk_owner':sk,'native_owner':tk,'blob_hex':right['blob'],'original_native_token':row.get('native_field_token',row.get('native_parameter_token')),'sdk_cli_token':left['token'],'candidate_cli_token':right['token']})
    need(len(seen)==335 and set(oo)==set(bb),'Unexpected original owner inventory');unresolved=[]
    for k in set(bb)-seen:
        need(oo[k]['blob'] is None and bb[k]['blob'] is None and oo[k]['flags']==bb[k]['flags'],'Unresolved owner modified');unresolved.append({'owner':k,'flags':bb[k]['flags']})
    need(len(unresolved)==20 and len({r['blob_hex'] for r in b['FieldMarshal_rows']})==3,'Exact unresolved20/descriptor count differs')
    out=ROOT/'Validation'/('OculusEmbeddedRawMarshalProof-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'independent-direct-cli-oculus335-partial-descriptor-blob-proof/v1','status':'passed','candidate':stage['candidate'],'stage_report':{'path':str(args.stage_report),'sha256':sha(args.stage_report)},'overlay':{'path':str(overlay_path),'sha256':sha(overlay_path)},'parser':{'path':str(HERE/'audit_cli_marshal_contracts.py'),'sha256':sha(HERE/'audit_cli_marshal_contracts.py')},'field_marshal_rows':335,'all_original_flagged_owners':355,'restored_field_owners':332,'restored_parameter_owners':3,'unresolved_field_owners':17,'unresolved_parameter_owners':3,'raw_scalar_blob_counts':{v:sum(x['blob_hex']==v for x in rows) for v in sorted({x['blob_hex'] for x in rows})},'all_restored_raw_blobs_equal_genuine_compiled_source':True,'all_native_owner_flags_preserved':True,'unresolved_owners_unchanged':True,'rows':rows,'unresolved':unresolved,'runtime_safe_or_playable_claim':False,'project_modified':False,'sdk_or_game_code_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':'passed','restored':335,'unresolved':20}),flush=True)
if __name__=='__main__':main()
