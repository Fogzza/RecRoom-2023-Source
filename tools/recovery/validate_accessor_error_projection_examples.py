"""Prove representative compile-only names/contracts from static pinned evidence.
No compiler, CLR, Mono, target assembly loader, or target method invocation.
"""
from pathlib import Path
import copy, datetime as dt, hashlib, json, re, uuid
from audit_accessor_error_projection_static import ROOT, WS, sha

INPUT=ROOT/'Validation/AccessorErrorStaticAudit-20261022T171547Z-c68fd138/report.json'
def need(condition,message):
    if not condition: raise ValueError(message)

def validate(row,native,bindings):
    key=(row['owner'],row['plan']['original']['canonical_signature'])
    method=row['plan']; witness=native[key]; bound=bindings[key]
    need(witness['error'] is None and witness['original_token_from_initial_attribute'] and witness['raw_cli_token_not_used_as_native'],'Exact original native token witness unavailable')
    need(witness['flags']==method['original_attributes'] and witness['impl_flags']==method['original_impl_attributes'],'Original native flags differ')
    need(bound['compiled']==method['compiled']['canonical_signature'],'Exact compiler selector differs from actual emitted binding')
    need(bound['raw_attributes']==witness['flags'] and bound['raw_impl_attributes']==witness['impl_flags'],'Raw/actual compiler binding flags disagree')
    need(method['original_semantics']==(2 if row['kind']=='get' else 1),'Original getter/setter semantic ownership differs')
    if row['owner']=='AFFPGEJLDGB':
        overrides=method['original_overrides'];need(len(overrides)==1 and overrides[0]['assembly']=='Assembly-CSharp' and overrides[0]['declaring_type']=='NNBAJLCGAOK','Exact original interface MethodImpl owner absent')
        target=('NNBAJLCGAOK',overrides[0]['canonical_signature']);need(target in native and target in bindings,'Original interface declaration has no native/binding witness')
        need(overrides[0]['name']==row['interface_original_accessor'],'Wrong original MethodImpl target for owning interface property')
    else:need(not method['original_overrides'],'Unexpected interface MethodImpl override')
    return {'owner':row['owner'],'interface_property':row['interface_property'],'kind':row['kind'],'original_native_token':witness['original_native_token'],'original_accessor':method['original']['name'],'compiled_accessor':method['compiled']['name'],'original_flags':witness['flags'],'original_impl_flags':witness['impl_flags'],'original_semantics':method['original_semantics'],'exact_methodimpl':method['original_overrides'],'original_property_name':row['original_property_name'],'compiled_property_name':row['compiled_property_name']}

def body(source,name,return_type):
    matches=re.findall(r'\bprivate\s+'+return_type+r'\s+'+re.escape(name)+r'\([^{}]*\)\s*\{([^{}]*)\}',source)
    need(len(matches)==1,'Unique original simple accessor body required: '+name)
    return re.sub(r'\s+','',matches[0])

def main():
    need(sha(INPUT)=='dbf53bdbdc6ba78aecc3e7544c65183c5bccd503fa6f9a061347c4bf0af65e94','Collected evidence drift')
    data=json.loads(INPUT.read_text());native={};bindings={}
    for r in data['native_original_method_witnesses']:
        key=(r['owner'],r['canonical_signature']);need(key not in native,'Ambiguous original native method');native[key]=r
    for r in data['all_class_and_interface_original_method_bindings']:
        key=(r['original_owner'],r['original']);need(key not in bindings,'Ambiguous original compiled binding');bindings[key]=r
    need(len(native)==len(bindings)==276 and set(native)==set(bindings),'All original class/interface methods must be accounted exactly')
    props={r['owner']:r['properties'] for r in data['selected_projection_rows']};interface={p['original_name']:p for p in props['NNBAJLCGAOK']}
    rows=[]
    for owner in ('AFFPGEJLDGB','NNBAJLCGAOK'):
        for prop in props[owner]:
            name=prop['compiled_name'].split('.')[-1];need(name in interface,'Expected exactly selected interface properties')
            for kind,plan in zip(('get','set'),prop['methods']):
                original_interface=interface[name]['original_getter' if kind=='get' else 'original_setter']['name']
                rows.append({'owner':owner,'interface_property':name,'kind':kind,'plan':plan,'interface_original_accessor':original_interface,'original_property_name':prop['original_name'],'compiled_property_name':prop['compiled_name']})
    need(len(rows)==8,'Exactly eight selected original accessors required');accepted=[validate(r,native,bindings) for r in rows]
    sources={Path(r['project_relative_path']).stem:r for r in data['source_replacements']}
    need(set(sources)=={'AFFPGEJLDGB','NNBAJLCGAOK'},'Exact real source projection rows required')
    for s in sources.values():need(sha(WS/'RR23'/s['project_relative_path'])==s['original_sha256'] and sha(s['candidate_path'])==s['candidate_sha256'],'Main or candidate source changed')
    original=(WS/'RR23'/sources['AFFPGEJLDGB']['project_relative_path']).read_text();candidate=Path(sources['AFFPGEJLDGB']['candidate_path']).read_text()
    bodies=[]
    for prop in props['AFFPGEJLDGB']:
        name=prop['compiled_name'].split('.')[-1]
        match=re.findall(r'bool\s+global::NNBAJLCGAOK\.'+re.escape(name)+r'\s*\{\s*get\s*\{([^{}]*)\}\s*set\s*\{([^{}]*)\}\s*\}',candidate)
        need(len(match)==1,'Unique projected explicit interface property required')
        get_body=body(original,prop['original_getter']['name'],'bool');set_body=body(original,prop['original_setter']['name'],'void')
        need(get_body==re.sub(r'\s+','',match[0][0])=='returnfalse;' and set_body==re.sub(r'\s+','',match[0][1])=='','Original getter/setter stub bodies not preserved byte-token equivalently')
        bodies.append({'property':name,'getter_original_body':'return false;','setter_original_body':'empty','candidate_bodies_token_identical':True,'original_native_runtime_behavior_recovered':False})
    for field in data['original_field_rows']:
        need(field['original']['name']==field['compiled']['name'] and not field['ambiguous'] and 'LFLJMKKAPMC' in field['original']['field_type'],'Exact original wrapper field must remain unrenamed')
    negatives=[]
    for label in ('wrong_native_flags','wrong_compiled_selector','wrong_interface_methodimpl'):
        bad=copy.deepcopy(next(r for r in rows if r['owner']=='AFFPGEJLDGB'))
        if label=='wrong_native_flags':bad['plan']['original_attributes']^=16
        elif label=='wrong_compiled_selector':bad['plan']['compiled']['canonical_signature']+='WRONG'
        else:bad['plan']['original_overrides'][0]['name']='DifferentOriginalMethod'
        try:validate(bad,native,bindings)
        except ValueError:negatives.append({'mutation':label,'rejected':True})
        else:raise AssertionError('Contract mutation accepted')
    report={'schema':'representative-accessor-compile-normalization-original-contract-proof/v1','status':'passed_static_original_contract_and_same_stub_bodies','input':{'path':str(INPUT),'sha256':sha(INPUT)},'selected_original_accessors':accepted,'all_class_and_interface_original_methods_accounted':276,'method_bindings_missing_or_ambiguous':0,'source_body_preservation':bodies,'negative_controls':negatives,'original_readonly_wrapper_fields_preserved':True,'CSharp_explicit_properties_are_compile_only':True,'production_ILPP_restores_original_accessor_property_names_flags_semantics_and_MethodImpl':True,'numeric_CLI_tokens_not_claimed_preserved_after_PE_reindex':True,'new_gameplay_logic_added':False,'missing_native_runtime_body_recovery_claimed':False,'main_sources_or_metadata_modified':False,'CLR_or_game_code_invoked':False}
    out=ROOT/'Validation'/('AccessorErrorExampleProof-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'report':str(rp),'sha256':sha(rp),'status':report['status'],'accessors':accepted,'negative_controls':len(negatives)}))

if __name__=='__main__':main()
