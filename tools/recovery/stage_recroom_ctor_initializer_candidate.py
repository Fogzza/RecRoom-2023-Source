"""Prove original89-byte constructor and stage its exact field initialization.

Uses the already SHA-pinned original native inventory. It does not execute native
code or mutate any project; final original-byte regeneration and C# IL proof
remain acceptance gates before application.
"""
from pathlib import Path
import base64, datetime as dt, hashlib, json, struct, sys, uuid
HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from audit_ogpeg_constructors import Decoder
from collect_all_pinvoke_native import ROOT, WORKSPACE, need
from audit_forwarding import sha

INV=ROOT/'Validation/RecRoomGameRootNative-20261022T162444Z-d9c732b7/report.json'
PRIOR=ROOT/'Validation/RecRoomBootCallbacksCandidate-20261022T165119Z-3719e254/report.json'

def decode(code,va):
    d=Decoder(code,va);d.literal('40 53 48 83 ec 20')
    flag=d.relative('80 3d','00');d.literal('48 8b d9');skip=d.short('75')
    klass=d.relative('48 8d 0d');setup=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at
    d.literal('c7 43 20 00 00 70 c2');loaded=d.relative('48 8b 0d')
    d.literal('f6 81 33 01 00 00 04');done1=d.short('74')
    d.literal('83 b9 e0 00 00 00 00');done2=d.short('75');cctor=d.relative('e8');base_at=va+d.at
    d.literal('33 d2 48 8b cb 48 83 c4 20 5b');base=d.relative('e9');d.end()
    need(len(code)==89 and flag==written and skip==ready and klass==loaded and done1==done2==base_at,'Exact constructor initialization/class-init branch graph')
    need(setup==0x1806c01e0 and cctor==0x180640f10 and base==0x18680df10,'Anchored metadata/runtime-class-init helpers and exact original base ctor')
    return {'metadata_class_usage':hex(klass),'runtime_metadata_setup':hex(setup),'runtime_class_init_helper':hex(cctor),'base_constructor_tail_call':hex(base),'original_field_offset':32,'exact_float32_bits':'0xc2700000','original_float32_value':struct.unpack('<f',bytes.fromhex('000070c2'))[0],'instance_store_precedes_original_base_constructor':True,'all89_bytes_and_both_class_init_branches_and_stack_checked':True}

def main():
    need(sha(INV)=='9492989fb0f23794155b1e0bd6e9ae25eeae2fc86687a9e1016abfb14617d7f6','Pinned original inventory changed')
    need(sha(PRIOR)=='3ac8088174f89b846366a4055f5f35f1ecd7a6420a788f8c2407948721b363fa','Two-callback candidate changed')
    inventory=json.loads(INV.read_text());prior=json.loads(PRIOR.read_text())
    row=next(r for r in inventory['methods'] if r['original']['owner']=='RecRoomGameRoot' and r['original']['name']=='.ctor')
    need(row['original']['token']=='0x60026c4' and row['original']['return']=='System.Void' and not row['original']['parameters'] and not row['original']['flags']&16,'Exact original noarg instance constructor')
    code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);shape=decode(code,va)
    field=next(f for f in inventory['original_fields'] if f['original_owner']['name']=='RecRoomGameRoot' and f['name']=='HKLOLBJDDDL')
    need(field['type']=='System.Single' and field['instance_or_static_offset']==32 and field['native_type']['kind']==12 and not field['native_type']['byref'] and not field['native_type']['pinned'] and not field['native_type']['num_mods'] and not field['native_type']['attributes']&16,'Exact original unmodified instance Single field32')
    base=next(r for r in inventory['methods'] if r['original']['owner']=='GameRoot' and r['original']['name']=='.ctor')
    need(base['native_pointer']==shape['base_constructor_tail_call'] and base['original']['image']=='RecRoom.Datastructures.Singletons.Runtime.dll' and not base['original']['parameters'] and base['original']['return']=='System.Void' and not base['original']['flags']&16,'Exact external GameRoot base constructor identity')
    source=Path(prior['source']);need(sha(source)==prior['source_sha256'] and sha(str(source)+'.meta')==prior['source_meta_sha256'],'Same unmodified project source/meta baseline')
    raw=source.read_bytes();declaration=b'private float HKLOLBJDDDL;';need(raw.count(declaration)==1,'Unique original literal field declaration')
    start=raw.index(declaration)+len(declaration)-1
    edit={'start':start,'length':0,'original_base64':'','replacement_base64':base64.b64encode(b' = -60f').decode(),'original_method_token':'0x060026c4','original_field_token':field['token'],'reason':'original instance field initializer precedes base .ctor; not an invented explicit post-base assignment'}
    edits=prior['byte_edits']+[edit];spans=sorted(edits,key=lambda e:e['start']);need(all(a['start']+a['length']<=b['start'] for a,b in zip(spans,spans[1:])),'Nonoverlapping field-initializer/callback byte edits')
    candidate=raw
    for e in reversed(spans):
        need(raw[e['start']:e['start']+e['length']]==base64.b64decode(e['original_base64']),'Original source span changed')
        candidate=candidate[:e['start']]+base64.b64decode(e['replacement_base64'])+candidate[e['start']+e['length']:]
    controls=[]
    for label,offset in [('metadata_skip_opcode',16),('field_offset',39),('float_constant_bits',41),('original_base_tail_opcode',84),('base_receiver_register',78)]:
        changed=bytearray(code);changed[offset]^=1
        try:decode(bytes(changed),va)
        except (ValueError,struct.error):controls.append({'mutation':label,'offset':offset,'rejected':True})
        else:raise AssertionError('Changed native constructor accepted '+label)
    out=ROOT/'Validation'/('RecRoomBootThreeMethodCandidate-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();target=out/'RecRoomGameRoot.cs';target.write_bytes(candidate)
    report={'schema':'original-RecRoomGameRoot-constructor-and-two-callback-source-candidate/v1','status':'native_closed_CFG_proved_CSharp_compile_and_fresh_native_revalidation_pending','source':str(source),'source_sha256':sha(source),'source_meta_sha256':sha(str(source)+'.meta'),'candidate':str(target),'candidate_sha256':sha(target),'byte_edits':edits,'input_proof':[{'path':str(p),'sha256':sha(p)} for p in [INV,PRIOR]],'constructor_native_shape':shape,'exact_original_field':field,'exact_original_base_ctor':base['original'],'constructor_original_native_code':code.hex(),'constructor_native_code_sha256':hashlib.sha256(code).hexdigest(),'constructor_native_pointer':row['native_pointer'],'constructor_negative_controls':controls,'runtime_class_initialization_is_managed_runtime_responsibility_not_recreated_gamecode':True,'source_field_or_method_names_types_flags_changed':False,'candidate_method_count':3,'native_base_constructor_and_BootSequence_bodies_recovered':False,'CSharp_binding_and_compiled_effects_proven':False,'native_code_executed':False,'main_or_harness_changed':False}
    path=out/'report.json';path.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(path),'sha256':sha(path),'candidate_sha256':sha(target),'method_count':3,'status':report['status']}))

if __name__=='__main__':main()
