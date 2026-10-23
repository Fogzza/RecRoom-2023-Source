"""Pure CLI diagnosis of a failed diagnostic-consumer Cecil readback gate."""
from pathlib import Path
import datetime as dt,json,mmap,uuid
from audit_original_rendering_sdk_candidates import h
from run_projected_generic_name_player_binding import ROOT,pin,need
PLAN=ROOT/'Validation/ReversedGenericNamePlayerBinding-20261023T091439Z-7d320125/plan.json'
FAILED=PLAN.parent/'Run-20261023T091548Z-35a88278/run-report.json'

def read(path):
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=h.m.cli.Cli(b);r=h.Read(c);at=c.row(0,1);index=c.value(at+2+c.strw,c.guidw);start=c.streams['#GUID'][0]+(index-1)*16;defs=[]
        for i in range(1,c.rows[2]+1):
            at=c.row(2,i);methods=r.methods(i)
            for m in methods:m['signature'].pop('blob')
            defs.append({'token':hex(0x02000000|i),'full_name':r.definition(i),'flags':c.u32(at),'methods':methods})
        return {'module':pin(path),'MVID_bytes':bytes(b[start:start+16]).hex(),'assembly_identity':r.asm,'table_counts':c.rows,'definitions_and_method_contracts':defs,'TypeRefs':[{'row':i,'scoped_identity':r.typeref(i)} for i in range(1,c.rows[1]+1)],'AssemblyRefs':[h.m.identity(c,35,i) for i in range(1,c.rows[35]+1)]}

def main():
    need(pin(FAILED)['sha256']=='9eb95afa02a93cc7948b77be7b7e3b41db3bcc631ad61cfb38f9e6d86a2264aa','Frozen actual emitted readback refusal');p=json.loads(PLAN.read_bytes());a=read(Path(p['same_original_compiled_consumer']['path']));b=read(Path(p['consumer_output']));old='[RecRoom.Datastructures.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]HHOBPMOCKMJ`1';new=old[:-2];expected=[x['scoped_identity'].replace(old,new) for x in a['TypeRefs']];actual=[x['scoped_identity'] for x in b['TypeRefs']];need(expected.count(new)==1 and len(expected)==len(set(expected))==9 and len(actual)==len(set(actual))==9,'Exact nine distinct consumer TypeRefs and one existing alias');mapping=[{'original_row':x['row'],'emitted_row':actual.index(name)+1,'scoped_identity_after_one_manifest_inverse':name} for x,name in zip(a['TypeRefs'],expected)];gates={'MVID_unchanged':a['MVID_bytes']==b['MVID_bytes'],'assembly_identity_unchanged':a['assembly_identity']==b['assembly_identity'],'all_table_counts_unchanged':a['table_counts']==b['table_counts'],'all_definitions_MethodDef_tokens_flags_and_scoped_signatures_unchanged':a['definitions_and_method_contracts']==b['definitions_and_method_contracts'],'ordered_AssemblyRefs_unchanged':a['AssemblyRefs']==b['AssemblyRefs'],'TypeRef_scoped_identity_bijection_after_one_inverse':sorted(expected)==sorted(actual),'TypeRef_original_row_order_preserved':expected==actual};need(all(value for name,value in gates.items() if name!='TypeRef_original_row_order_preserved') and gates['TypeRef_original_row_order_preserved'] is False,'Only the demonstrated reference-row reindex is expected among these gates');out=ROOT/'Validation'/('ProjectedConsumerEmissionDiagnosis-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'pure-CLI-consumer-TypeRef-row-reindex-diagnosis/v1','status':'exact_nine_reference_permutation_and_one_name_inverse_proven_full_Cecil_gates_pending','failed_receipt':pin(FAILED),'failed_plan':pin(PLAN),'original':a,'emitted':b,'individual_pure_CLI_gates':gates,'exact_TypeRef_row_bijection':mapping,'full_MetadataRoundTripSafety_and_BodyAndSymbolSafety_still_required':True,'Main_modified':False,'managed_game_Unity_network_executed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'gates':gates,'row_mapping':[(x['original_row'],x['emitted_row']) for x in mapping]}))
if __name__=='__main__':main()
