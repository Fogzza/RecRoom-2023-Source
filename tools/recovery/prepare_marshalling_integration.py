"""Prepare an isolated, explicitly sourced marshal overlay; never deploy it.

Bounded JSONL and indexed native-token joins prove the original native member,
raw-provider CLI member/scoped TypeSpec, and genuine SDK token independently.
"""
from __future__ import annotations
import argparse, collections, copy, hashlib, json, os, shutil, sqlite3, struct, sys, uuid
from datetime import datetime, timezone
from pathlib import Path

HERE=Path(__file__).resolve().parent
WORKSPACE=HERE.parents[2]
ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
OLD=ROOT/'CompilerRepairs/CurrentCoreIntegration-20261022T132957Z-214498f6'
OVERLAY=ROOT/'Validation/CombinedMarshalOverlay-20261022T142900Z/overlay.json'
OVERLAY_SHA='1b79254a32bfd667290e19890f1aba701c873d2c32edd7c5dd4bee37e97d6ebd'
METHODS=ROOT/'Validation/CoreMethodFlagsInventory-20261022T110755Z-0be64abb'
FIELDS=ROOT/'Validation/CoreFieldAttributeWitness-20261022T114004Z-f1c134b5'
SDK=ROOT/'Validation/CompiledOfficialSteamworks14-20261022T141234Z-ba27e76b'

def need(value,why):
    if not value: raise ValueError(why)
def sha(path):
    h=hashlib.sha256()
    with Path(path).open('rb') as f:
        for b in iter(lambda:f.read(1024*1024),b''):h.update(b)
    return h.hexdigest()
def token(value):return f'0x{int(value,0) if isinstance(value,str) else value:08x}'
def read(path):return json.loads(Path(path).read_text(encoding='utf-8-sig'))
def pinned(path,expected=None):
    actual=sha(path)
    need(expected is None or actual==expected,'Pinned input changed: '+str(path))
    return {'path':str(path.resolve()),'sha256':actual}
def selected_rows(path,key,selected):
    found={}
    with path.open(encoding='utf-8-sig') as f:
        for line in f:
            need(len(line)<1024*1024,'Oversized metadata row')
            row=json.loads(line); ident=token(row[key]) if row.get(key) else None
            if ident in selected:
                need(ident not in found,'Duplicate native token row');found[ident]=row
    need(set(found)==selected,'Missing exact native token inventory rows')
    return found
def native_db(path):
    db=sqlite3.connect(path.resolve().as_uri()+'?mode=ro',uri=True)
    db.enable_load_extension(False);db.execute('PRAGMA cache_size=-8192');db.execute('PRAGMA query_only=ON')
    return db

class Binary:
    def __init__(self,path):self.f=path.open('xb')
    def integer(self,v):self.f.write(struct.pack('<i',v))
    def token(self,v):self.f.write(struct.pack('<I',int(v,0) if isinstance(v,str) else v))
    def string(self,v):
        b=v.encode('utf-8');n=len(b);need(n<=8192,'Bounded identity exceeded')
        while n>=128:self.f.write(bytes([(n&127)|128]));n>>=7
        self.f.write(bytes([n]));self.f.write(b)
    def descriptor(self,d):
        kind={'MarshalInfo':0,'FixedSysStringMarshalInfo':1,'FixedArrayMarshalInfo':2,'ArrayMarshalInfo':3}[d['kind']]
        self.f.write(bytes([kind]));self.integer(d['native_type'])
        if kind==1:self.integer(d['size'])
        if kind==2:self.integer(d['element_type']);self.integer(d['size'])
        if kind==3:
            for k in ('element_type','size','size_parameter_index','size_parameter_multiplier'):self.integer(d[k])

def exact_sdk(row,sdk,kind):
    need(row['owner']==sdk['owner'] and row['name']==sdk['name'],'SDK owner/name token mismatch')
    if kind=='fields':
        need(row['type']==sdk['type'] and row['original_flags']==sdk['flags'] and row['marshal']==sdk['marshal'],'SDK field type/flags/descriptor mismatch')
    else:
        need(row['return']==sdk['return'] and row['parameter_types']==[p['type'] for p in sdk['parameters']],'SDK full method signature mismatch')
        if kind=='parameters':
            p=sdk['parameters'][row['sequence']-1]
            need((p['name'],p['type'],p['flags'],p['marshal'])==(row['parameter_name'],row['type'],row['original_flags'],row['marshal']),'SDK parameter identity/descriptor mismatch')
        elif kind=='returns':need(row['sdk_return_flags']==sdk['return_flags'] and row['marshal']==sdk['return_marshal'],'SDK return descriptor mismatch')
        else:need(row['pinvoke']==sdk['pinvoke'] and row['original_method_flags']==sdk['flags'] and row['original_method_impl_flags']==sdk['impl_flags'],'SDK ImplMap/flags mismatch')

def build_plan(output):
    doc=read(OVERLAY);inputs=[pinned(OVERLAY,OVERLAY_SHA)]
    need(doc['target_assembly']=='Assembly-CSharp' and not doc['native_original_descriptor_blob_equality_claim'],'Explicit overlay scope required')
    for row in doc['inputs']:inputs.append(pinned(Path(row['path']),row['sha256']))
    records=doc['records'];need({k:len(v) for k,v in records.items()}=={'fields':111,'parameters':64,'returns':318,'imports':819},'Exact reviewed counts')
    sdk_doc=read(SDK/'marshal-records.json');sdk_fields={r['token']:r for r in sdk_doc['fields']};sdk_methods={r['token']:r for r in sdk_doc['methods']}
    for name in ('marshal-records.json','report.json','source-ownership.json','OfficialSteamworks14.dll'):inputs.append(pinned(SDK/name))
    method_tokens={token(r['native_method_token']) for k in ('parameters','returns','imports') for r in records[k]}
    field_tokens={token(r['native_field_token']) for r in records['fields']}
    methods=selected_rows(METHODS/'raw-core-methods.jsonl','original_native_token',method_tokens)
    fields=selected_rows(FIELDS/'raw-core-fields.jsonl','original_field_token',field_tokens)
    for p in (METHODS/'native-join-report.json',METHODS/'raw-core-methods.jsonl',FIELDS/'provenance.json',FIELDS/'report.json',FIELDS/'raw-core-fields.jsonl'):
        inputs.append(pinned(p))
    mdb=native_db(METHODS/'native-contract-index.sqlite');fdb=native_db(FIELDS/'native-field-index.sqlite')
    bindings=[];sources={};seen=set()
    for kind,rows in records.items():
        for row in rows:
            row=copy.deepcopy(row); native=token(row['native_field_token' if kind=='fields' else 'native_method_token'])
            compat=row['authority']=='Windowsx64_ABI_compatibility_not_original_blob_recovered'
            raw=(fields if kind=='fields' else methods)[native]
            need(raw['owner']==row['owner'] and raw['name']==row['name'] and raw.get('error') is None,'Exact native-token raw owner/name binding')
            if kind=='fields':
                stored=fdb.execute('SELECT row FROM fields WHERE token=?',(native,)).fetchone();need(stored is not None,'Native field token missing');n=json.loads(stored[0])
                need(n['owner']==row['owner'] and n['name']==row['name'] and n['shape']==raw['raw_shape'] and n['flags']==row['original_flags']==raw['raw_flags'] and token(n['owner_token'])==token(row['native_owner_token']),'Native field owner/TypeSpec/flags proof')
                canonical=raw['raw_canonical_type']
            else:
                n=mdb.execute('SELECT owner,name,arity,has_this,returns,parameters,flags,impl,error FROM methods WHERE token=?',(native,)).fetchone()
                need(n is not None and n[0]==row['owner'] and n[1]==row['name'] and n[2]==0 and n[3]==int(raw['has_this']) and n[4]==raw['return_shape'] and json.loads(n[5])==raw['parameters_shape'] and n[6]==raw['flags'] and n[7]==raw['impl_flags'] and n[8] is None,'Native full method TypeSpec/flags proof')
                canonical=raw['canonical_signature']
            if not compat:
                exact_sdk(row,(sdk_fields if kind=='fields' else sdk_methods)[row['sdk_cli_token']],kind)
                witness=row['source_witness'];sp=Path(witness['source_path']);sources[str(sp)]=pinned(sp,witness['source_sha256'])
            else:
                need(kind=='parameters' and row['owner']=='KNBDGFKMGCP' and (row['name'],row['sequence'],row['marshal']['native_type']) in {('AAEPLCHCEAK',3,8),('DLHPCKIHJKB',2,43)},'Only two reviewed compatibility descriptors')
            if kind=='imports':
                p=row['pinvoke'];n=row['native_effective_binding'];need(p['module'] in {'steam_api64','sdkencryptedappticket64'} and p['module']==n['module'] and p['entry']==n['entry_point'] and p['attributes']==512 and n['native_calling_convention']['native_enum']==1,'Exact effective original native import binding')
            ident=(kind,native,row.get('sequence',0));need(ident not in seen,'Duplicate scoped overlay identity');seen.add(ident)
            bindings.append({'kind':kind,'native_original_token':native,'raw_provider_cli_token':raw['raw_cli_token'],'owner':row['owner'],'name':row['name'],'raw_scoped_canonical':canonical,'sdk_cli_token':row.get('sdk_cli_token',0),'authority':row['authority'],'row':row})
    mdb.close();fdb.close();inputs.extend(sources.values())
    result={'schema':'pinned-native-provider-sdk-marshalling-binding/v1','status':'all_exact_identity_joins_proven','source_overlay':inputs[0],'inputs':inputs,'records':bindings,'counts':{k:len(v) for k,v in records.items()},'native_original_blob_equality_claim':False,'project_changed':False}
    (output/'overlay-binding-proof.json').write_text(json.dumps(result,indent=2)+'\n')
    b=Binary(output/'proven-marshalling-overlay.bin');b.string('RR23-MARSHAL-OVERLAY/V1');b.string(OVERLAY_SHA);b.string('Assembly-CSharp')
    for k in ('fields','parameters','returns','imports'):b.integer(len(records[k]))
    for item in bindings:
        row=item['row'];kind=item['kind']
        for value in (row['owner'],row['name'],row['type' if kind=='fields' else 'return'],item['native_original_token']):b.string(value)
        b.token(item['raw_provider_cli_token']);b.string(item['raw_scoped_canonical']);b.token(row.get('sdk_cli_token',0))
        if kind!='fields':
            b.integer(len(row['parameter_types']))
            for a in row['parameter_types']:b.string(a)
        if kind=='fields':b.integer(row['original_flags']);b.string(row['authority']);b.descriptor(row['marshal'])
        elif kind in ('parameters','returns'):
            b.integer(row['sequence']);b.integer(row.get('original_flags',row.get('sdk_return_flags')));b.string(row.get('parameter_name',''));b.string(row['authority']);b.descriptor(row['marshal'])
        else:
            b.integer(row['original_method_flags']);b.integer(row['original_method_impl_flags']);b.string(row['pinvoke']['module']);b.string(row['pinvoke']['entry']);b.integer(row['pinvoke']['attributes']);b.string(row['authority'])
    b.f.close();need((output/'proven-marshalling-overlay.bin').stat().st_size<4*1024*1024,'Bounded binary resource')
    return result

def replace_once(text,old,new):
    need(text.count(old)==1,'Expected exact patch once: '+old[:80]);return text.replace(old,new)
def rebase(value,old,new):
    if isinstance(value,str):return value.replace(str(old),str(new))
    if isinstance(value,list):return [rebase(v,old,new) for v in value]
    if isinstance(value,dict):return {k:rebase(v,old,new) for k,v in value.items()}
    return value

def stage(output,source_rebase=None):
    need(not output.exists() and output.is_relative_to(ROOT/'CompilerRepairs'),'Fresh isolated CompilerRepairs stage required');output.mkdir()
    proof=build_plan(output)
    shutil.copytree(OLD/'Package',output/'Package');(output/'ToolBuild').mkdir()
    shutil.copytree(OLD/'OriginalGaps',output/'OriginalGaps')
    shutil.copyfile(OLD/'current-core-manifest.bin',output/'current-core-manifest.bin')
    for dependency in read(OLD/'stage-plan.json')['tool_dependencies']:
        source=Path(dependency['path']);pinned(source,dependency['sha256']);shutil.copyfile(source,output/'ToolBuild'/source.name)
    for name in ('CurrentCoreChecks.cs','compile-checker.rsp','compile-codegen.rsp','proposed-project-csc.rsp'):
        (output/name).write_text((OLD/name).read_text().replace(str(OLD),str(output)))
    package=output/'Package/Assets/Editor/OriginalMetadataRestoration'
    for name in ('CanonicalMarshallingContracts.cs','ProvenMarshallingOverlay.cs'):
        shutil.copyfile(HERE/name,package/name)
        (package/(name+'.meta')).write_text('fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\n')
    binary=output/'proven-marshalling-overlay.bin';resource=output/'Package/CompilerSupport/Metadata/proven-marshalling-overlay.bin';resource.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(binary,resource)
    generated=package/'ProvenMarshallingOverlayInputs.cs';generated.write_text('namespace RR23.MetadataRestoration { public static class ProvenMarshallingOverlayInputs { public const string ResourceName="RR23.ProvenMarshallingOverlay"; public const string Sha256="'+sha(binary)+'"; } }\n')
    (package/(generated.name+'.meta')).write_text('fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\n')
    path=package/'WholeMetadataRestorer.cs';text=path.read_text()
    text=replace_once(text,'public int Bodies, SequencePoints;','public int Bodies, SequencePoints;\n        public ProvenMarshallingOverlayResult MarshallingOverlay;')
    text=replace_once(text,'string[] referencePaths)','string[] referencePaths, string[] defines)')
    text=replace_once(text,'safety.VerifyObjectIdentity(methods);','var marshallingOverlay = ProvenMarshallingOverlay.Apply(assembly.MainModule, raw.MainModule, Resource(ProvenMarshallingOverlayInputs.ResourceName), ProvenMarshallingOverlayInputs.Sha256, defines);\n                safety.VerifyObjectIdentity(methods);')
    # Existing result uses an object initializer near the only successful return.
    text=replace_once(text,'Definitions = counts, References = references','Definitions = counts, References = references, MarshallingOverlay = marshallingOverlay')
    path.write_text(text)
    path=package/'GeneralPostProcessor.cs';text=path.read_text();text=replace_once(text,'assembly.References)','assembly.References, assembly.Defines)');path.write_text(text)
    path=output/'CurrentCoreChecks.cs';text=path.read_text();text=replace_once(text,'return new string[0];','return new[] { "UNITY_EDITOR", "UNITY_EDITOR_WIN", "UNITY_EDITOR_64" };');path.write_text(text)
    path=package/'MetadataRoundTripSafety.cs';text=path.read_text()
    text=replace_once(text,'Attributes(value, field);','Attributes(value, field); value.Append(CanonicalMarshallingContracts.Canonical(field)).Append("|");')
    text=replace_once(text,'Attributes(value, method.MethodReturnType);','Attributes(value, method.MethodReturnType); value.Append(CanonicalMarshallingContracts.PInvokeDescriptor(method.PInvokeInfo)).Append("|").Append(CanonicalMarshallingContracts.Canonical(method.MethodReturnType)).Append("|");')
    text=replace_once(text,'Attributes(value, parameter);','Attributes(value, parameter); value.Append(CanonicalMarshallingContracts.Canonical(parameter)).Append("|");')
    text=replace_once(text,'foreach (var type in module.Types) Type(value, type);','foreach (var reference in module.ModuleReferences) value.Append(reference.Name).Append("|");\n            foreach (var type in module.Types) Type(value, type);');path.write_text(text)
    path=package/'MetadataRoundTripDiagnostics.cs';text=path.read_text()
    text=replace_once(text,'yield return Row(sha,"assembly.references-order",value); value.Clear();','yield return Row(sha,"assembly.references-order",value); value.Clear();\n                foreach(var reference in module.ModuleReferences)value.Append(reference.Name).Append("|");\n                yield return Row(sha,"module.import-references-order",value);value.Clear();')
    text=replace_once(text,'value.Append((int)field.Attributes).Append(\':\').Append(field.Offset);','value.Append((int)field.Attributes).Append(\':\').Append(field.Offset).Append(\':\').Append(CanonicalMarshallingContracts.Canonical(field));')
    text=replace_once(text,'value.Append(method.MethodReturnType.Name).Append(\':\').Append((int)method.MethodReturnType.Attributes);','value.Append(method.MethodReturnType.Name).Append(\':\').Append((int)method.MethodReturnType.Attributes).Append(\':\').Append(CanonicalMarshallingContracts.Canonical(method.MethodReturnType)).Append(\':\').Append(CanonicalMarshallingContracts.PInvokeDescriptor(method.PInvokeInfo));')
    text=replace_once(text,'value.Append(parameter.Name).Append(\':\').Append((int)parameter.Attributes).Append(\'|\');','value.Append(parameter.Name).Append(\':\').Append((int)parameter.Attributes).Append(\':\').Append(CanonicalMarshallingContracts.Canonical(parameter)).Append(\'|\');');path.write_text(text)
    for name in ('compile-checker.rsp','compile-codegen.rsp'):
        path=output/name;text=path.read_text()
        for added in ('CanonicalMarshallingContracts.cs','ProvenMarshallingOverlay.cs','ProvenMarshallingOverlayInputs.cs'):text+='"'+str(package/added)+'"\n'
        text+='/resource:"'+str(resource)+'",RR23.ProvenMarshallingOverlay\n';path.write_text(text)
    path=package/'csc.rsp';path.write_text(path.read_text()+'/resource:"CompilerSupport/Metadata/proven-marshalling-overlay.bin",RR23.ProvenMarshallingOverlay\n')
    plan=rebase(read(OLD/'stage-plan.json'),OLD,output)
    plan['created_utc']=datetime.now(timezone.utc).isoformat();plan['marshalling_overlay']={'schema':'explicit-sourced-marshal-overlay-stage/v1','authority':'genuine SDK source plus two reviewed Windows-x64 ABI compatibility parameter records','shipping_supported':False,'counts':proof['counts'],'native_original_blob_equality_claim':False,'binding_proof':pinned(output/'overlay-binding-proof.json'),'resource':pinned(resource),'scope':'Windows x64 Editor compile/signature-load validation only','remaining_unmapped_original_imports':27}
    plan['inputs'].extend([pinned(OVERLAY,OVERLAY_SHA),pinned(output/'overlay-binding-proof.json'),pinned(OLD/'stage-plan.json')])
    plan['source_snapshots']=[{'source':str(path),'copy':str(path),'sha256':sha(path)} for path in sorted(package.glob('*.cs'))]
    plan['patched_engine']['sha256']=sha(package/'WholeMetadataRestorer.cs')
    plan['project_relative_editor_support_outside_Assets'].append({'project_relative_path':'CompilerSupport/Metadata/proven-marshalling-overlay.bin','path':str(resource),'sha256':sha(resource)})
    if source_rebase:
        report=read(source_rebase);need(report['status']=='passed' and report['all_other_metadata_bytes_unchanged'] and report['whole_assembly_coverage_preserved'] and report['source_replacements'] in (2290,2291) and report['method_bodies']==7,'Exact body-only source rebase proof required')
        if report['source_replacements']==2291:
            need(report['validation_candidate_count_change']=='2290 ->2291; one original direct-source caller now needs compiler-only spelling' and len(report['updated_replacements'])==3,'Exactly one additional proven caller-only replacement required')
        revised=Path(report['projection']['path']);pinned(revised,report['projection']['sha256']);old_hash=plan['inputs'][0]['sha256'];new_hash=report['projection']['sha256']
        for manifest in (output/'current-core-manifest.bin',output/'Package/CompilerSupport/Metadata/current-core-manifest.bin'):
            with manifest.open('r+b') as f:
                header=f.read(1024);need(header.count(old_hash.encode())==1,'Exact prior source-manifest hash header');offset=header.index(old_hash.encode());f.seek(offset);f.write(new_hash.encode())
            need(sha(manifest)!=plan['manifest']['sha256'],'Source manifest hash must be rebased')
        plan['inputs'][0]=pinned(revised,new_hash);plan['inputs'].append(pinned(source_rebase));plan['body_only_source_rebase']={'proof':pinned(source_rebase),'metadata_plans_unchanged':True,'method_bodies_preserved':7}
        plan['manifest']['sha256']=sha(output/'current-core-manifest.bin')
        plan['project_relative_editor_support_outside_Assets'][0]['sha256']=plan['manifest']['sha256']
    (output/'stage-plan.json').write_text(json.dumps(plan,indent=2)+'\n')
    return output

def main():
    p=argparse.ArgumentParser();p.add_argument('--output',type=Path);p.add_argument('--plan-only',action='store_true');p.add_argument('--source-rebase',type=Path);args=p.parse_args()
    out=args.output or ROOT/'CompilerRepairs'/('CurrentCoreMarshallingIntegration-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8])
    if args.plan_only:
        need(not out.exists(),'Fresh proof output');out.mkdir(parents=True);build_plan(out)
    else:stage(out,args.source_rebase)
    print(json.dumps({'stage':str(out),'project_changed':False,'game_code_executed':False}))
if __name__=='__main__':main()
