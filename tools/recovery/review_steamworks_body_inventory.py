"""Independent review of exploratory inventory, not a transplant acceptance tool."""
from pathlib import Path
import collections,hashlib,json
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
path=ROOT/'Validation/SteamworksManagedBodyInventory-20261022T142813Z-dcb5b741/inventory.json';source=HERE/'SteamworksBodyInventory.cs';x=json.loads(path.read_text());types={t['type']:t for t in x['types']};candidates=[m for m in x['methods'] if not m['issues']]
changed=[t for t in x['types'] if not t['base_type_matches'] or not t['interfaces_match'] or not t['layout_matches'] or t['sdk_flags']!=t['raw_flags'] or t['sdk_fields']!=t['fields_exact_name_type_flags']]
dangerous={'Steamworks.Callback`1','Steamworks.CallResult`1'};affected=[]
for m in candidates:
 refs=m['self_references'];dependent=sorted({n for n in dangerous if m['owner']==n or any(('|'+n+'|') in r or ('|'+n+'/') in r or r=='T|'+n for r in refs)})
 if dependent:affected.append({'owner':m['owner'],'signature':m['signature'],'callback_implementation_dependencies':dependent})
pure=[]
for m in candidates:
 if m['self_reference_count']==0 and m['exception_handlers']==0 and m['il_instruction_count']<=12:pure.append({'owner':m['owner'],'signature':m['signature'],'sdk_token':m['sdk_token'],'raw_metadata_token':m['raw_metadata_token'],'instructions':m['il_instruction_count'],'external_references':m['external_references']})
report={'schema':'independent-Steamworks14-body-inventory-review/v1','status':'review_only_no_transplant_accepted','input':{'path':str(path),'sha256':hashlib.sha256(path.read_bytes()).hexdigest()},'tool_reviewed':{'path':str(source),'sha256':hashlib.sha256(source.read_bytes()).hexdigest()},'managed_sdk_bodies':x['managed_bodies'],'issue_free_unscoped_candidates':len(candidates),'issue_counts':dict(collections.Counter(i.split(':')[0] for m in x['methods'] for i in m['issues'])),'high_impact_type_contract_differences':changed,'issue_free_callback_dependent_methods':affected,'small_no_self_reference_candidates_for_native_leaf_comparison':pure,'mandatory_additional_gates':[
 'Exact original native image/owner/token and scoped canonical return/parameter signatures; positional generic parameters, instance/calling convention and all modifiers preserved.',
 'Recursive root-namespace inventory for nested types. Current immediate DeclaringType.Namespace filter can omit third-level nested Steamworks types.',
 'Source MethodKey and FieldKey FullName omit assembly scope; never import source OfficialSteamworks14-scoped self refs into target.',
 'Reject unmapped source types/fields/methods; do not synthesize the44 stripped/missing SDK types or callback infrastructure.',
 'Callback<T> and CallResult<T> have actual different base classes and only3/8 matching fields; do not replace their bodies solely on version constants.',
 'Inspect generic instance owner substitution, GenericParameter owner/position, generic constraints, MethodImpl targets, local pinned/InitLocals, EH endpoints and full instruction operand categories.',
 'TypeSpecification recursion must inspect modifier types, exact array rank/bounds and function-pointer signature, not only ElementType.',
 'Full closure must identify every SDK call as a proven imported body, existing real runtime implementation, delegate Runtime contract or proven PInvoke; matched signatures alone can still call original stubs.',
 'Preserve all target declarations/attributes/marshal/layout/member access, only transplant verified IL/body-owned operands; validate body/PDB remap independently.',
 'Same SDK14.0.0 provenance proves source origin, not original RecRoom native-body equality. Label source restoration separately from native-proved bodies.'],
 'meaningful_negative_fixtures':['Same namespace/type/fullname from different assemblyscope must reject','Swapped!0/!!0 or wrong generic owner must reject','Nested depth3 missing type must reject','Changed callback base class or removedfield must reject','Unmapped generic delegate target/FieldRef must reject','CallSite/calli or unsupported modifier/functionpointer must reject','Wrong native token with same methodname must reject','Stale EH branch/local/parameter remap must reject','External MethodRef flags/callconv or virtual/nonvirtual opcode change must reject','Matched SDKversion but native leaf bytes differ: classify source restoration only'],
 'project_modified':False,'sdk_or_game_code_executed':False}
out=path.parent/'independent-review.json';out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'sha256':hashlib.sha256(out.read_bytes()).hexdigest(),'candidate_count':len(candidates),'callback_dependent_issuefree':len(affected),'small_leaf_comparison_targets':len(pure)}))
