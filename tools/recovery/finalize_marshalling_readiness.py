"""Pin a passed offline stage and directly verify emitted CLI marshal tables.

This never marks Unity signature loading or gameplay as passed.
"""
import argparse,collections,json,mmap,sys
from pathlib import Path
import prepare_marshalling_integration as prep
from audit_cli_marshal_contracts import Cli

def audit(path):
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as data:
        cli=Cli(data);result=cli.audit()
        prep.need(result['malformed_field_count']==result['malformed_parameter_count']==0,'Dangling marshal owner flags')
        prep.need(len(result['FieldMarshal_rows'])==493 and len(result['flagged_fields'])==111 and len(result['flagged_parameters'])==382,'Exact complete descriptor coverage')
        prep.need(all(r['has_FieldMarshal_flag'] and r['FieldMarshal_table_rid'] for r in result['flagged_fields']+result['flagged_parameters']),'Orphan/flagless marshal row')
        modules={rid:cli.string(cli.value(cli.row(26,rid),cli.strw)) for rid in range(1,cli.rows[26]+1)}
        prep.need(set(modules.values())=={'steam_api64','sdkencryptedappticket64'} and len(modules)==2,'Exact two source SDK ModuleRefs')
        imports=[]
        for rid in range(1,cli.rows[28]+1):
            at=cli.row(28,rid);flags=cli.u16(at);parent=cli.value(at+2,cli.coded(1,[4,6]));entry=cli.string(cli.value(at+2+cli.coded(1,[4,6]),cli.strw));module=cli.value(at+2+cli.coded(1,[4,6])+cli.strw,cli.index(26))
            prep.need(parent&1 and 0<parent>>1<=cli.rows[6] and flags==512 and module in modules,'Exact source SDK MethodDef ImplMap shape')
            imports.append({'module':modules[module],'entry':entry,'attributes':flags})
        expected=[r['pinvoke'] for r in prep.read(prep.OVERLAY)['records']['imports']]
        key=lambda r:(r['module'],r['entry'],r['attributes'])
        prep.need(collections.Counter(map(key,imports))==collections.Counter(map(key,expected)) and len(imports)==819,'Complete per-entry SDK import multiset')
        return {'schema':'direct-cli-complete-marshal-overlay-emission/v1','status':'passed','input':prep.pinned(path),'field_descriptors':111,'parameter_descriptors':64,'genuine_source_return_descriptors':318,'FieldMarshal_rows':493,'ImplMap_rows':819,'ModuleRef_rows':2,'dangling_flags':0,'orphan_rows':0,'flag_clears':0,'native_original_blob_equality_claim':False,'game_code_loaded_or_executed':False}

def main():
    p=argparse.ArgumentParser();p.add_argument('--build-report',required=True,type=Path);p.add_argument('--overlay-fixtures',required=True,type=Path);args=p.parse_args()
    report=prep.read(args.build_report);prep.need(report['status']=='built_and_tested' and report['actual_core_roundtrip_executed'] and report['contract_tests_passed']==32,'Passed whole-current-core report required')
    stage_plan=Path(report['stage_plan']['path']);prep.pinned(stage_plan,report['stage_plan']['sha256']);stage=stage_plan.parent;plan=prep.read(stage_plan)
    prep.need(plan['marshalling_overlay']['shipping_supported'] is False and plan.get('body_only_source_rebase'),'Current body-aware explicit compatibility stage required')
    fixtures=prep.read(args.overlay_fixtures);prep.need(fixtures['status']=='passed' and fixtures['sdk_identity_controls_passed']==20 and fixtures['parser_controls_passed']==28,'Focused overlay controls required')
    prep.need(prep.sha(stage/'Package/Assets/Editor/OriginalMetadataRestoration/ProvenMarshallingOverlay.cs')==fixtures['overlay_helper']['sha256'] and prep.sha(stage/'Package/Assets/Editor/OriginalMetadataRestoration/CanonicalMarshallingContracts.cs')==fixtures['canonical_helper']['sha256'],'Production source must match independently exercised helpers')
    output=Path(report['actual_core_roundtrip']['path']).parent;receipt=prep.read(output/'receipt.json');core=output/'Assembly-CSharp.dll';pdb=output/'Assembly-CSharp.pdb'
    prep.pinned(core,receipt['output_pe_sha256']);prep.pinned(pdb,receipt['output_pdb_sha256']);direct=audit(core);direct_path=args.build_report.parent/'direct-cli-overlay-proof.json';prep.need(not direct_path.exists(),'Fresh direct proof required');direct_path.write_text(json.dumps(direct,indent=2)+'\n')
    package=[]
    for f in sorted((stage/'Package').rglob('*')):
        if f.is_file():package.append({'project_relative_path':str(f.relative_to(stage/'Package')).replace('\\','/'),'path':str(f.resolve()),'sha256':prep.sha(f)})
    gates=[prep.pinned(args.build_report),prep.pinned(args.overlay_fixtures),prep.pinned(direct_path),prep.pinned(prep.ROOT/'Validation/CanonicalMarshalFixtures-20261022T144229Z-36916ede/report.json'),prep.pinned(prep.ROOT/'Validation/CanonicalMarshalRawBlobProof-20261022T144434Z-ac7e4717/report.json')]
    ready={'schema':'rr23-current-core-marshalling-integration-readiness/v1','status':'offline_passed_requires_actual_Unity_compile_load','project_modified':False,'game_code_executed':False,'stage_plan':prep.pinned(stage_plan),'offline_build_report':prep.pinned(args.build_report),'offline_roundtrip_receipt':prep.pinned(output/'receipt.json'),'restored_core':prep.pinned(core),'restored_pdb':prep.pinned(pdb),'gate_checks':gates,'package_files':package,'proposed_project_response':plan['proposed_project_response'],'marshalling_overlay':plan['marshalling_overlay'],'preserved':{'retained_method_instruction_semantics':True,'portable_PDB_symbols_documents_and_hashes':True,'original_metadata_except_explicit_source_and_ABI_overlay':True,'native_methods_recovered_by_metadata_pipeline':0,'numeric_tokens_and_RVAs_may_relocate':True},'explicit_original_recovery_gaps':{'missing_original_generated_types':709,'missing_original_methods':683,'unresolved_original_import_maps':27,'Windows_x64_parameters_with_compatibility_not_original_blob_authority':2,'source_return_descriptors_without_native_blob_equality_claim':318,'gameplay_playability_verified':False},'actual_Unity_pipeline_discovery_and_signature_load_verified':False,'SDK_only_texture_load_is_not_main_game_playability':True}
    ready_path=args.build_report.parent/'integration-readiness.json';prep.need(not ready_path.exists(),'Fresh readiness required');ready_path.write_text(json.dumps(ready,indent=2)+'\n');print(json.dumps({'readiness':str(ready_path),'sha256':prep.sha(ready_path),'direct_cli':str(direct_path),'package_files':len(package)}))
if __name__=='__main__':main()
