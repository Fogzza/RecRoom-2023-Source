"""Prepare/Root-run exact twelve-body Core+testedURP7 candidate staging.

Pure preparation predicts one finite writer definition map, regressed against
the already-observed URP map. No Param omission is authorized in either input.
All semantic metadata and every unselected full scoped CIL body stay exact.
"""
from pathlib import Path
import argparse, collections, copy, datetime as dt, json, os, re, shutil, uuid
import run_custom_urp_initializer_prerequisite_controls_v2 as controls
import stage_custom_urp_factory_cache_bodies_v3 as ancestry
import stage_custom_urp_factory_cache_bodies_v2 as resolver
from run_custom_urp_factory_cache_controls import HERE,WS,ROOT,guard,pin,check,need,save,GUARD_SHA,LAUNCH_SHA
import audit_custom_urp_cecil_reindex as raw
import audit_custom_urp_cecil_reindex_v2 as cil

TEST=ROOT/'Validation/CustomUrpInitializerPrerequisiteBindingEffectsV2-20261023T104211Z-f2e47736/run-report.json'
TEST_SHA='341959bba58115716d5b20222ec15b5926e32dc2da198939264703a49d82d793'
STAGE=ROOT/'Validation/CustomUrpSevenBodyStageV3-20261023T095100Z-057fd079/plan.json'
STAGE_SHA='5ed5889980e5126e7bd95e659bbe11c9eb74678563ad87d6ba4707202c4ff0f1'
SCHEMA='prepared-twelve-tested-original-custom-URP-initializer-stage/v1'
CORE='Unity.RenderPipelines.Core.Runtime';URP='Unity.RenderPipelines.Universal.Runtime'
CAPTURE='UnityEngine.Rendering.CameraCaptureBridge';ASSET='UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset'
CALLBACK='UnityEngine.Rendering.Universal.UniversalRenderPipeline/<>c';ALIAS='UnityEngine.Rendering.Universal.UniversalRenderPipeline/OriginalCallbackBindings'
MAP_SCHEMA='exact-pinned-twelve-prerequisite-definition-bijection-zero-omissions/v1'

def tested():
    need(pin(TEST)['sha256']==TEST_SHA,'Actual Root12bindings+31effects success');r=json.loads(TEST.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['status']==controls.SUCCESS and len(r['phases'])==3 and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] and x['launcher']['membership_verified_before_resume'] for x in r['phases']),'Three actual bounded successful control phases')
    need(r['selected_members']==12 and r['controlled_effect_cases']==31 and not r['Main_modified'] and not r['production_donors_or_Unity_loaded_or_executed'],'Only exact metadata bindings and controlled effects')
    for row in [r[k] for k in ['compiled_Core_donor','compiled_URP_donor','compiled_effects']]:check(row)
    for row in [p[k] for k in ['source','actual_Core_target','actual_URP_target','Main_URP_unchanged','Main_Core_meta','Main_URP_meta','native_proof','genuine_Unity']]+p['member_fragments']:check(row)
    need(pin(STAGE)['sha256']==STAGE_SHA,'Frozen tested7 staging ancestry');return r,p

def prediction(model,omitted=()):
    c=model.c;parents={};children={}
    for ri in range(1,c.rows[41]+1):
        at=c.row(41,ri);child=c.value(at,c.index(2));parent=c.value(at+c.index(2),c.index(2));need(child not in parents,'Unique actual nested owner');parents[child]=parent;children.setdefault(parent,[]).append(child)
    order=[]
    def walk(t):
        need(t not in order,'No nested cycle');order.append(t)
        for child in sorted(children.get(t,[])):walk(child)
    for ti in range(1,c.rows[2]+1):
        if ti not in parents:walk(ti)
    need(sorted(order)==list(range(1,c.rows[2]+1)),'Entire actual type tree covered')
    maps={2:{old:new for new,old in enumerate(order,1)}}
    for table,inventory in [(4,model.field),(6,model.method)]:
        ids=[]
        for ti in order:ids.extend(i for i in sorted(inventory) if inventory[i]['owner']==model.names[2,ti])
        need(len(ids)==c.rows[table],'Every field/method in exact owned order');maps[table]={old:new for new,old in enumerate(ids,1)}
    params=[]
    for mi in sorted(maps[6],key=maps[6].get):params.extend(pi for pi,(owner,seq) in sorted(model.param.items()) if owner==mi and (8<<24|pi) not in omitted)
    maps[8]={old:new for new,old in enumerate(params,1)}
    for table in [20,23]:
        ids=[]
        for ti in order:ids.extend(i for (t,i),value in sorted(model.values.items()) if t==table and value['owner']==model.names[2,ti])
        need(len(ids)==c.rows[table],'Entire owned event/property map');maps[table]={old:new for new,old in enumerate(ids,1)}
    generics=[]
    for ri in range(1,c.rows[42]+1):
        at=c.row(42,ri);coded=c.value(at+4,c.coded(1,[2,6]));table=6 if coded&1 else 2;newcoded=maps[table][coded>>1]<<1|(coded&1);generics.append((newcoded,c.u16(at),ri))
    maps[42]={old:new for new,(_,_,old) in enumerate(sorted(generics),1)}
    return {'schema':MAP_SCHEMA,'tables':[{'table':t,'original_count':c.rows[t],'emitted_count':len(maps[t]),'rows':[{'original_token':t<<24|a,'emitted_token':t<<24|b} for a,b in sorted(maps[t].items())]} for t in [2,4,6,8,20,23,42]],'omitted_empty_Param_tokens':list(omitted),'prediction_authority':'Pinned Mono.Cecil writer AttachTypeToken/AttachNestedTypesToken/AttachFieldsToken/AttachMethodsToken/AddParameters plus observed exact URP regression; emitted actual map must match every row.'}

def map_gate(spec,before,after):
    need(spec['schema']==MAP_SCHEMA and [x['table'] for x in spec['tables']]==[2,4,6,8,20,23,42] and spec['omitted_empty_Param_tokens']==[],'Only seven exact tables and ZERO omitted Params')
    seen_a=set();seen_b=set()
    for table in spec['tables']:
        t=table['table'];need(sum(a>>24==t for a in before)==table['original_count'] and sum(b>>24==t for b in after)==table['emitted_count'],'Exact table counts')
        need(table['original_count']==table['emitted_count']==len(table['rows']),'Complete bijection, no additions or omissions')
        for row in table['rows']:
            a,b=row['original_token'],row['emitted_token'];need(a>>24==t and b>>24==t and a not in seen_a and b not in seen_b and before[a]==after[b],'Exact scoped definition at exact pinned emitted row');seen_a.add(a);seen_b.add(b)
    need(set(before)==seen_a and set(after)==seen_b,'Entire definition set covered')

def maps_and_controls(modules):
    d=ancestry.diagnostic();original=raw.Model(raw.ORIGINAL);reg=prediction(original,ancestry.OMITTED)
    for table in reg['tables']:
        actual=d['definition_maps'][str(table['table'])];expected={int(r['original_token'],16):int(r['emitted_token'],16) for r in actual['bijection']};need({r['original_token']:r['emitted_token'] for r in table['rows']}==expected and table['original_count']==actual['original_count'] and table['emitted_count']==actual['emitted_count'],'Writer predictor exactly regresses every prior actual URP definition map')
    cases=['prior_observed_URP_6091_to_6087_all_definition_maps_regressed'];result=[]
    for module in modules:
        model=raw.Model(Path(module['original']['path']));need(all(v['name']!='' or v['flags']!=0 for (t,i),v in model.values.items() if t==8),'Actual inputs have NO empty unnamed ordinary Params to omit')
        spec=prediction(model);need(spec['omitted_empty_Param_tokens']==[],'Zero omissions');before={t<<24|i:k for (t,i),k in model.names.items() if t in [2,4,6,8,20,23,42]};after={row['emitted_token']:before[row['original_token']] for table in spec['tables'] for row in table['rows']};map_gate(spec,before,after);cases.append(module['assembly']+'_full_finite_bijection_admitted')
        mutations=[('wrong_token',lambda s,b,a:s['tables'][0]['rows'][0].update(emitted_token=s['tables'][0]['rows'][1]['emitted_token'])),('missing_row',lambda s,b,a:s['tables'][2]['rows'].pop()),('Param_omission',lambda s,b,a:s['omitted_empty_Param_tokens'].append(0x08000001)),('wrong_count',lambda s,b,a:s['tables'][0].update(original_count=9999)),('scoped_identity_changed',lambda s,b,a:a.update({next(iter(a)):'wrong scoped identity'})),('extra_definition',lambda s,b,a:a.update({0x0600ffff:'extra'}))]
        for label,mutate in mutations:
            s,b,a=copy.deepcopy(spec),dict(before),dict(after);mutate(s,b,a)
            try:map_gate(s,b,a)
            except (ValueError,KeyError):cases.append(module['assembly']+'_'+label+'_refused')
            else:raise ValueError('Negative definition-map control accepted')
        result.append(spec)
    return result,{'schema':'pure-prerequisite-finite-definition-map-controls/v1','status':'passed','controls':len(cases),'cases':cases,'actual_prior_URP_diagnosis':pin(ancestry.DIAG),'managed_writer_executed':False,'new_emitted_bijections_not_yet_observed':True}

def metadata_references(modules):
    wanted={}
    import audit_hashable_scoped_vtable as signatures
    for module in modules:
        c=raw.Model(Path(module['original']['path'])).c
        for i in range(1,c.rows[35]+1):
            row=signatures.m.identity(c,35,i);need(row['name'] not in wanted or wanted[row['name']]['full_name']==row['full_name'],'No ambiguous original external full identities');wanted[row['name']]=row
    editor=WS/'Tools/Editors/2020.3.33f1/Editor';managed=editor/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed';mono=editor/'Data/MonoBleedingEdge/lib/mono';result=[]
    for name,row in sorted(wanted.items()):
        if name.startswith('UnityEngine.') and (managed/(name+'.dll')).is_file():path=managed/(name+'.dll')
        elif name=='mscorlib':path=mono/'4.7.1-api/mscorlib.dll'
        elif name in ['System','System.Core','System.Xml']:path=mono/'unityaot'/(name+'.dll')
        else:path=WS/'RR23/Assets/Plugins'/(name+'.dll')
        need(resolver.identity(path)==row['full_name'],'Exact actual original metadata authority '+name);result.append({**pin(path),'full_name':row['full_name']})
    return result

def helper_source():
    original=HERE/'FiniteOriginalDefinitionReindex.cs';need(pin(original)['sha256']=='c5e6d17f223f5d5ba79405a12226312e80fadce46b19de6b67f49660c493b2dd','Exact frozen definition capture helper')
    text=original.read_text();start=text.index('    public static void Verify(');capture=text[:start].replace('FiniteOriginalDefinitionReindex','PinnedPrerequisiteDefinitionMap').replace('// Exact finite metadata-row amendment for one frozen original URP assembly.','// Exact pinned definition bijection for two frozen prerequisite input assemblies.')
    verify='''    public static void Verify(Dictionary<uint,string> before,ModuleDefinition emitted,JsonElement spec)
    {
        Need(spec.GetProperty("schema").GetString()=="exact-pinned-twelve-prerequisite-definition-bijection-zero-omissions/v1","Exact finite prerequisite map schema");
        Need(spec.GetProperty("omitted_empty_Param_tokens").GetArrayLength()==0,"ZERO omitted raw Param records authorized");
        var after=Capture(emitted);var oldSeen=new HashSet<uint>();var newSeen=new HashSet<uint>();var tables=spec.GetProperty("tables").EnumerateArray().ToArray();
        Need(tables.Select(t=>t.GetProperty("table").GetInt32()).SequenceEqual(new[]{2,4,6,8,20,23,42}),"Exactly seven definition tables");
        foreach(var table in tables)
        {
            uint t=table.GetProperty("table").GetUInt32();int count=table.GetProperty("original_count").GetInt32();var rows=table.GetProperty("rows").EnumerateArray().ToArray();
            Need(count==table.GetProperty("emitted_count").GetInt32()&&count==rows.Length&&before.Keys.Count(k=>k>>24==t)==count&&after.Keys.Count(k=>k>>24==t)==count,"Exact complete bijection counts, zero omissions/additions");
            foreach(var row in rows){uint a=row.GetProperty("original_token").GetUInt32(),b=row.GetProperty("emitted_token").GetUInt32();Need(a>>24==t&&b>>24==t&&oldSeen.Add(a)&&newSeen.Add(b)&&before.TryGetValue(a,out var x)&&after.TryGetValue(b,out var y)&&x==y,"Exact finite scoped identity and original/emitted row");}
        }
        Need(before.Count==oldSeen.Count&&before.Keys.All(oldSeen.Contains)&&after.Count==newSeen.Count&&after.Keys.All(newSeen.Contains),"Every original/emitted definition accounted for");
    }
}
'''
    target=HERE/'PinnedPrerequisiteDefinitionMap.cs';expected=(capture+verify).encode()
    if target.exists():need(target.read_bytes()==expected,'Never overwrite existing helper')
    else:target.write_bytes(expected)
    return target

def members(assembly):
    if assembly==CORE:return [(CAPTURE,n,CAPTURE,n) for n in ['get_enabled','set_enabled','.cctor']]
    return [(ASSET,n,ASSET,n) for n in ['get_renderFeatureset','get_postProcessing','get_supportsHDR','get_msaaSampleCount','get_renderScale','get_RecRoomQualityConfig']]+[('UnityEngine.Rendering.Universal.RenderingUtils','ClearSystemInfoCache','UnityEngine.Rendering.Universal.RenderingUtils','ClearSystemInfoCache'),(CALLBACK,'<.ctor>b__32_0',ALIAS,'OriginalComparison'),(CALLBACK,'<.cctor>b__73_0',ALIAS,'OriginalLights')]

def mapped_donor_body(original,donor,request):
    mi=next(i for i,m in donor.method.items() if m['owner'].endswith(']'+request['donor_owner']) and m['name']==request['donor_name']);value=copy.deepcopy(cil.decode(donor,mi))
    if request['owner']==CAPTURE and request['name']=='.cctor':
        old_type=next(f['type'] for f in original.field.values() if f['owner'].endswith(']'+CAPTURE) and f['name']=='actionDict');new_type=next(f['type'] for f in donor.field.values() if f['owner'].endswith(']'+CAPTURE) and f['name']=='actionDict')
        need(old_type!=new_type and old_type.replace('PublicKeyToken=7cec85d7bea7798e','PublicKeyToken=b77a5c561934e089')==new_type,'Only exact proven original HashSet full-scope difference')
        count=0
        for ins in value['instructions']:
            if isinstance(ins['operand'],str) and new_type in ins['operand']:
                need(ins['opcode'] in ['0x73','0x80'],'Only newobj and actionDict stsfld typed authority windows');ins['operand']=ins['operand'].replace(new_type,old_type);count+=1
        need(count==2,'Exactly dictionary constructor and field TypeSpec scoped mappings')
    return value

def raw_validate(module,path):
    original=raw.Model(Path(module['original']['path']));emitted=raw.Model(path);donor=raw.Model(Path(module['donor']['path']));need(original.r.asm==emitted.r.asm,'Exact assembly identity')
    before={t<<24|i:k for (t,i),k in original.names.items() if t in [2,4,6,8,20,23,42]};after={t<<24|i:k for (t,i),k in emitted.names.items() if t in [2,4,6,8,20,23,42]};map_gate(module['definition_map'],before,after)
    aa=original.associations();bb=emitted.associations();need({k:collections.Counter(map(raw.key,v)) for k,v in aa.items()}=={k:collections.Counter(map(raw.key,v)) for k,v in bb.items()},'Every full scoped metadata association/attribute/constant/definition exact')
    selected={r['current_token']&0xffffff:r for r in module['members']};emitted_methods={value:i for (t,i),value in emitted.names.items() if t==6};count=0;expected_bodies=[]
    for mi in original.method:
        target=emitted_methods[original.names[6,mi]];actual=cil.decode(emitted,target)
        expected=mapped_donor_body(original,donor,selected[mi]) if mi in selected else cil.decode(original,mi)
        need(actual==expected,'Full scoped CIL/local/maxstack/EH/branch equality '+original.method[mi]['name']);count+=mi not in selected
        if mi in selected:expected_bodies.append(expected)
    # Old reference metadata may only gain identities actually reachable from
    # the exact selected bodies. No old identity is dropped or scope retargeted.
    texts=raw.key(expected_bodies);allowed_operands=set();allowed_locals=set()
    for body in expected_bodies:
        if body['locals']:allowed_locals.add(body['locals'])
        for ins in body['instructions']:
            if isinstance(ins['operand'],str):allowed_operands.add(ins['operand'])
    reference_deltas={}
    for table in [1,10,17,27,43]:
        delta=raw.differences([original.token(table<<24|i) for i in range(1,original.c.rows[table]+1)],[emitted.token(table<<24|i) for i in range(1,emitted.c.rows[table]+1)])
        need(not delta['removed'],'No original scoped reference identity removed')
        for value in delta['added']:
            if table==1:need(value in texts,'Added TypeRef must be an exact selected-body dependency')
            elif table==10:need(value in allowed_operands,'Added MemberRef must be an exact selected instruction operand')
            elif table==17:need(value in allowed_locals,'Added StandaloneSig must be an exact selected local signature')
            elif table==27:need(value in texts,'Added TypeSpec must be exact selected-body type/owner')
            else:need(False,'No MethodSpec authorized in selected12')
        reference_deltas[str(table)]=delta
    return {'assembly':module['assembly'],'original':module['original'],'candidate':pin(path),'all_unselected_entire_scoped_CIL_equal':count,'selected_entire_scoped_CIL_equal':len(selected),'all_semantic_metadata_associations_exact':True,'all_definition_rows_exact_pinned':True,'omitted_Param_records':0,'reference_deltas':reference_deltas,'original_Core_HashSet_TypeSpec_mapping_count':2 if module['assembly']==CORE else 0,'managed_code_loaded':False,'Main_modified':False}

def prepare():
    r,p=tested();old_plan=json.loads(STAGE.read_bytes());out=ROOT/'Validation'/('CustomUrpInitializerTwelveBodyStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();modules=[]
    for assembly,original,donor,meta in [(CORE,p['actual_Core_target'],r['compiled_Core_donor'],p['Main_Core_meta']),(URP,p['actual_URP_target'],r['compiled_URP_donor'],p['Main_URP_meta'])]:
        model=raw.Model(Path(original['path']));requests=[]
        for owner,name,donor_owner,donor_name in members(assembly):
            mi=next(i for i,m in model.method.items() if m['owner'].endswith(']'+owner) and m['name']==name);requests.append({'owner':owner,'name':name,'donor_owner':donor_owner,'donor_name':donor_name,'current_token':6<<24|mi})
        modules.append({'assembly':assembly,'original':original,'donor':donor,'meta':meta,'members':requests})
    maps,control=maps_and_controls(modules)
    for module,mapping in zip(modules,maps):module['definition_map']=mapping
    authorities=metadata_references(modules);spec={'schema':'twelve-tested-custom-URP-initializer-body-import/v1','modules':modules,'metadata_references':authorities};sp=out/'inputs.json';save(sp,spec);cp=out/'offline-controls.json';save(cp,control)
    helper=helper_source();source=HERE/'StageCustomUrpInitializerPrerequisiteBodies.cs';sources=[source]+[Path(x['path']) for x in old_plan['sources'][1:-1]]+[helper]
    refs=old_plan['references'];[check(x) for x in refs];cecil=next(Path(x['path']) for x in refs if Path(x['path']).name=='Mono.Cecil.dll');shutil.copyfile(cecil,out/cecil.name)
    output=out/'StageCustomUrpInitializerPrerequisiteBodies.dll';rsp=out/'compile.rsp';rsp.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+x['path']+'"\n' for x in refs)+''.join('"'+str(x)+'"\n' for x in sources),encoding='utf-8',newline='\n');shutil.copyfile(Path(old_plan['output']).with_suffix('.runtimeconfig.json'),output.with_suffix('.runtimeconfig.json'))
    plan={'schema':SCHEMA,'status':'prepared_no_child_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'tested_receipt':pin(TEST),'tested_plan':r['plan'],'ancestry_stage_plan':pin(STAGE),'native_proof':p['native_proof'],'spec':pin(sp),'offline_controls':pin(cp),'sources':[pin(x) for x in sources],'references':refs,'metadata_references':authorities,'modules':modules,'response':pin(rsp),'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'output':str(output),'compiler':old_plan['compiler'],'dotnet':old_plan['dotnet'],'guard':old_plan['guard'],'launcher':old_plan['launcher'],'framework_authority':old_plan['framework_authority'],'Main_URP_unchanged':p['Main_URP_unchanged'],'changed_bodies':12,'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'Main_apply_supported':False,'automatic_reference_addition_supported':False,'Param_omission_authorized':False,'constructor_or_frame_closure_claimed':False};target=out/'plan.json';save(target,plan)
    print(json.dumps({'plan':pin(target),'controls':pin(cp),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed12body plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpInitializerTwelveBodyStage-') and p['changed_bodies']==12 and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and not p['Main_apply_supported'] and not p['automatic_reference_addition_supported'] and not p['Param_omission_authorized'],'Exact isolated finite12body scope')
    for row in [p[k] for k in ['runner','tested_receipt','tested_plan','ancestry_stage_plan','native_proof','spec','offline_controls','response','compiler','dotnet','guard','launcher','Main_URP_unchanged']]+p['sources']+p['references']+p['runtime']+p['framework_authority']:check(row)
    for module in p['modules']:
        for k in ['original','donor','meta']:check(module[k])
    for row in p['metadata_references']:check({k:row[k] for k in ['path','bytes','sha256']});need(resolver.identity(row['path'])==row['full_name'],'Exact metadata authority full identity')
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA and p['output']==str(out/'StageCustomUrpInitializerPrerequisiteBodies.dll'),'Fixed runner, frozen guard, fresh output')
    tested();maps,control=maps_and_controls(p['modules']);need([m['definition_map'] for m in p['modules']]==maps and json.loads(Path(p['offline_controls']['path']).read_bytes())==control,'Repeated actual-regressed finite mapping and negative controls');need(json.loads(Path(p['spec']['path']).read_bytes())=={'schema':'twelve-tested-custom-URP-initializer-body-import/v1','modules':p['modules'],'metadata_references':p['metadata_references']},'Exact complete input schema')
    if not run:print(json.dumps({'status':'verified_no_child_no_Main_apply','changed_bodies':12,'offline_controls':control['controls']}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh outputs only, preserve failures');report={'schema':'guarded-twelve-original-custom-URP-initializer-body-stage/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_Unity_network_launched':False,'constructor_or_frame_closure_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-exact12body-prerequisite-importer',report)
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-readback12body-Core-and-testedURP7-candidates',report,env)
        result=out/'Candidates/report.json';value=json.loads(result.read_bytes());need(value['schema']=='twelve-tested-custom-URP-initializer-staged-candidates/v1' and value['status']=='twelve_tested_bodies_staged_semantic_metadata_other_bodies_preserved' and value['changed_method_bodies']==12 and len(value['modules'])==2 and not value['Main_modified'],'Full C# strict emitted semantic metadata/body gates')
        proofs=[]
        for module in p['modules']:
            candidate=out/'Candidates'/(module['assembly']+'.dll');row=next(x for x in value['modules'] if x['candidate']['path']==str(candidate));check(row['candidate']);need(row['assembly_references_appended']==[] and row['omitted_Param_records']==0 and row['original_scope_and_callback_identity_preserved'] and row['entire_tested_donor_IL_equal'],'Exact no-addition/no-omission and scope witnesses');proofs.append(raw_validate(module,candidate))
        pp=out/'independent-raw-CLI-validation.json';save(pp,{'schema':'independent-pure12body-scoped-CLI-audit/v1','status':'passed','modules':proofs,'Main_modified':False})
        for module in p['modules']:check(module['original']);check(module['meta'])
        check(p['Main_URP_unchanged']);report.update(status='twelve_tested_bodies_staged_full_scoped_metadata_other_bodies_preserved',result=pin(result),independent_raw_CLI_validation=pin(pp),candidates=[x['candidate'] for x in value['modules']],Main_plugin_and_meta_unchanged=True,raw_Core_RID_reindex_explicit=True,raw_Param_omissions=0)
    except BaseException as e:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(e))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='twelve_tested_bodies_staged_full_scoped_metadata_other_bodies_preserved' else 1

def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--plan',type=Path);p.add_argument('--plan-sha256');p.add_argument('--run',action='store_true');a=p.parse_args()
    if a.plan:need(a.plan_sha256,'Explicit reviewed plan SHA');return execute(a.plan,a.plan_sha256,a.run)
    need(not a.run and not a.plan_sha256,'Prepare first without child');prepare();return 0

if __name__=='__main__':raise SystemExit(main())
