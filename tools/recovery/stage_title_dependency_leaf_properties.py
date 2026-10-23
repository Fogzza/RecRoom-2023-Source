"""Stage three original single-field property getter expressions, data only.

Full original native field/leaf contracts are already pinned. The separate
Root-run full source compile/Cecil helper must prove original attribute-provider
field ownership, exact rename rules, source binding and effect behavior.
"""
from pathlib import Path
import base64,datetime as dt,hashlib,json,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE))
from collect_all_pinvoke_native import need
from collect_title_page_route_native import pin
INLINE=ROOT/'Validation/TitleDisplayInlineContracts-20261023T081354Z-8b00fb68/report.json'
SELECT=[('RecRoom.Core.UI.UIInputModule','ControllerCamera','Camera','COMLJLOEGCA'),('RecRoom.Core.ScreenHUD','WorldSpaceUIAnchor','ScreenWorldSpaceUIAnchor','worldSpaceUIAnchor'),('RecRoom.Core.ScreenWorldSpaceUIAnchor','AttachedGameObject','GameObject','CDLPNIKNKPB')]
def main():
    need(pin(INLINE)['sha256']=='939e9168b5ab6caa294341b9167f6254324ce2d10b7a759f9d821b026d31f0d8','Five frozen original complete inline getter contracts');q=json.loads(INLINE.read_bytes());provider=ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll';need(pin(provider)['sha256']=='15cbc3614b2986da2813cfc82b640199029d8a9b5a60fd8f42db2bdaee7ea9fe','Exact original injected attribute provider')
    title=WS/'RR23/Assets/Scripts/Assembly-CSharp/TitleScreenManager.cs';need(pin(title)['sha256']=='38ac36a43cb3f28f729d2f3d3570cd859d01f53d438dcc7ada3d3cd3c1e9671e','Current applied complete PMNJ/Awake/Start/FlowModel source')
    out=ROOT/'Validation'/('TitleDependencyLeafProperties-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();rows=[]
    for owner,prop,sourceType,field in SELECT:
        native=[x for x in q['complete_inline_getter_contracts'] if x['original']['owner']==owner and x['original']['name']=='get_'+prop];need(len(native)==1,'Unique proved original getter');native=native[0]
        source=WS/'RR23/Assets/Scripts/Assembly-CSharp'/Path(*owner.split('.')).with_suffix('.cs');before=source.read_bytes();prefix=('public '+sourceType+' '+prop+'\n{\nget \t\t{\r\n\t\t\treturn ').encode();need(before.count(prefix)==1,'Exact public source getter prefix with existing mixed line endings preserved');at=before.index(prefix)+len(prefix);need(before[at:at+len(b'null;\r\n\t\t}')] == b'null;\r\n\t\t}','Only exact one-return null getter');declaration=('private '+sourceType+' '+field+';').encode();need(before.count(declaration)==1,'One literal current field declaration');replacement=('this.'+field).encode();after=before[:at]+replacement+before[at+4:];candidate=out/(owner+'.cs');candidate.write_bytes(after)
        raw=native['same_original_field']['name'];rename='literal original field name' if raw==field else 'Original CompilerGenerated backing field exact enclosed identifier; no matching original PropertyDef with that enclosed name; original export renames field to enclosed identifier'
        need(raw==field or raw=='<'+field+'>k__BackingField','Only exact original identity or published backing-name export rule, no name heuristic')
        rows.append({'owner':owner,'property_source_name':prop,'source_field':field,'return_type':native['original']['return'],'original_getter':native,'source':pin(source),'source_meta':pin(str(source)+'.meta'),'candidate':pin(candidate),'byte_edit':{'start':at,'length':4,'original_base64':base64.b64encode(b'null').decode(),'replacement_base64':base64.b64encode(replacement).decode()},'exact_proposed_getter_body_base64':base64.b64encode(b'return '+replacement+b';').decode(),'field_mapping_rule':rename,'original_attribute_and_source_compiler_field_binding_verification_pending':True})
    report={'schema':'original-three-title-single-field-property-source-candidates/v1','status':'three_exact_original_leaf_getter_source_expressions_staged_binding_and_effects_UNVERIFIED','native_inline_evidence':pin(INLINE),'original_attribute_provider':pin(provider),'current_title_checkpoint':pin(title),'reused_policy_sources':[pin(HERE.parent/'NativeGetterSourceRecovery'/f) for f in ['Program.cs','Backing.cs']],'sources':rows,'all_bytes_outside_three_null_expressions_preserved':True,'all_original_script_meta_bytes_preserved':True,'candidate_field_aliases_not_accepted_until_original_provider_and_compiler_proof':True,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'working_startup_title_login_claimed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'candidate_files':len(rows),'methods':3,'current_title_sha256':pin(title)['sha256'],'Main_modified':False,'compiled':False}))
if __name__=='__main__':main()
