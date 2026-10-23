"""Bounded source/manifest/native-witness audit; no CLR/game assembly loading."""
from pathlib import Path
import datetime as dt, hashlib, json, sys, uuid
HERE=Path(__file__).resolve().parent; WS=HERE.parents[2]; ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent))
from metadata_projection_subset import array_rows

def sha(p):
    with Path(p).open('rb') as f: return hashlib.file_digest(f,'sha256').hexdigest()

def bare_rows(path):
    decoder=json.JSONDecoder()
    with Path(path).open(encoding='utf-8-sig') as f:
        buffer=f.read(262144).lstrip()
        if not buffer.startswith('['): raise ValueError('Exact JSON array required')
        buffer=buffer[1:]
        while True:
            buffer=buffer.lstrip()
            if buffer.startswith(']'): return
            if buffer.startswith(','): buffer=buffer[1:].lstrip()
            while True:
                buffer=buffer.lstrip()
                if buffer.startswith(']'): return
                if buffer.startswith(','): buffer=buffer[1:].lstrip()
                try:row,end=decoder.raw_decode(buffer);break
                except json.JSONDecodeError:
                    if len(buffer)>16*1024**2: raise ValueError('Bounded JSON row exceeded')
                    block=f.read(262144)
                    if not block: raise
                    buffer+=block
            yield row; buffer=buffer[end:]

def main():
    manifest=ROOT/'Validation/BodySourceStreamRebase-20261022T150601Z-f74c827a/metadata-restoration.json'
    if sha(manifest)!='9914cdfd2af4f5319f94315ae13a948b85d5e1260500f4408bc8ceeaad02e51f':raise ValueError('Final production source plan changed')
    wanted={'AFFPGEJLDGB','NNBAJLCGAOK'}; members={'GDJKLPKICBG','GEKEGCEELCD'}
    types={r['original_full_name']:r for r in array_rows(manifest,'types') if r['original_full_name'] in wanted}
    if set(types)!=wanted:raise ValueError('Both exact class/interface projection types required')
    sources=[r for r in array_rows(manifest,'source_replacements') if Path(r['project_relative_path']).stem in wanted]
    for r in sources:
        if sha(WS/'RR23'/r['project_relative_path'])!=r['original_sha256'] or sha(r['candidate_path'])!=r['candidate_sha256']:raise ValueError('Real original/candidate source drift')
    fields=[r for r in array_rows(manifest,'all_field_identity_mappings') if r['original_type']=='AFFPGEJLDGB']
    bindings_file=ROOT/'Validation/CoreExtraAudit-20261022T105320Z/bindings.json'
    bindings=[r for r in bare_rows(bindings_file) if r['original_owner'] in wanted]
    adapters_file=ROOT/'Validation/CoreExtraAudit-20261022T105320Z/accepted-forwarding-adapters.json'
    adapters=[r for r in bare_rows(adapters_file) if r['compiled_owner'] in wanted]
    native_file=ROOT/'Validation/CoreMethodFlagsInventory-20261022T110755Z-0be64abb/raw-core-methods.jsonl'
    native=[]
    with native_file.open(encoding='utf-8') as f:
        for line in f:
            if len(line)>262144: raise ValueError('Bounded native witness row')
            r=json.loads(line)
            if r['owner'] in wanted:native.append(r)
    selected=[]
    for owner,row in types.items():
        properties=[p for p in row.get('properties',[]) if any(member in json.dumps(p) for member in members)]
        methods=[m for m in row.get('methods',[]) if any(member in json.dumps(m) for member in members)]
        selected.append({'owner':owner,'row_keys':list(row),'properties':properties,'methods':methods})
    input_paths=[manifest,bindings_file,adapters_file,native_file,ROOT/'Validation/CoreMethodFlagsInventory-20261022T110755Z-0be64abb/native-join-report.json',ROOT/'Validation/CurrentCoreMarshalRoundtrip-20261022T162157Z-ad86540f/report.json']
    report={'schema':'representative-original-accessor-compile-repair-static-evidence/v1','status':'source_plan_and_original_native_witnesses_collected','main_or_source_modified':False,'CLR_or_native_game_code_executed':False,'wanted_members':sorted(members),'source_replacements':sources,'selected_projection_rows':selected,'original_field_rows':[f for r in fields for f in r['fields'] if f['original']['name'] in members],'all_class_and_interface_original_method_bindings':bindings,'proven_removed_source_adapter_rows':adapters,'native_original_method_witnesses':native,'inputs':[{'path':str(p),'sha256':sha(p)} for p in input_paths],'compiler_repair_is_new_gameplay_logic':False,'missing_native_bodies_are_not_recovered_by_accessor_repair':True}
    out=ROOT/'Validation'/('AccessorErrorStaticAudit-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'report':str(rp),'sha256':sha(rp),'source_files':len(sources),'type_counts':{t:{'methods':len(types[t].get('methods',[])),'properties':len(types[t].get('properties',[]))} for t in wanted},'native_methods':len(native),'bindings':len(bindings),'adapters':len(adapters),'selected_rows':[{ 'owner':r['owner'],'properties':r['properties'],'methods':r['methods']} for r in selected]}))

if __name__=='__main__':main()
