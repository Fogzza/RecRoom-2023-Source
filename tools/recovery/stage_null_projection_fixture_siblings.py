"""Create NEW fixture siblings from pinned reviewed fixtures; never edits originals."""
from pathlib import Path
import ast
import hashlib

HERE=Path(__file__).resolve().parent


def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()


def replace(text,old,new):
    if text.count(old)!=1:raise ValueError('Unique source anchor required: '+old[:80])
    return text.replace(old,new)


def builder():
    source=HERE/'BuildOriginalShaderBuiltinIdentityFixture.cs'
    if sha(source)!='99afdb63efa0579d31330ecd50c0b61c8ece2d9d56e3f8ddd4bdd7a4fffcd24c':raise ValueError('Pinned original builder changed')
    text=source.read_text().replace('BuildOriginalShaderBuiltinIdentityFixture','BuildOriginalShaderNullDependencyFixture').replace('OriginalShaderBuiltinIdentityFixture-','OriginalShaderNullDependencyFixture-').replace('OriginalShaderBuiltinIdentityDiagnostic','OriginalShaderNullDependencyDiagnostic')
    text=replace(text,'public Input[] shaders; public bool include_alpha_clip;','public Input[] shaders; public bool include_alpha_clip, Editor_dependency_projection; public BuiltinMaterialWitness[] copied_materials;')
    text=replace(text,'public bool Main_modified = false, original_game_code_executed = false, GPU_tested = false;',
        'public bool Main_modified = false, original_game_code_executed = false, GPU_tested = false;\n        public bool Editor_only_null_dependency_projection = true, original_dependencies_restored_in_player = false;')
    text=replace(text,'Need(row.dependencies != null && !inputs.ContainsKey(row.guid), "Unique explicit inputs required");',
        'Need(row.dependencies != null && row.dependencies.Length == 0 && !inputs.ContainsKey(row.guid), "Every projected Editor Shader has an explicitly empty resolved dependency graph");')
    start=text.index('    static BuiltinMaterialWitness[] CreateBuiltinWitnesses()')
    end=text.index('    static PackedMaterials CaptureMaterials',start)
    text=text[:start]+'''    static BuiltinMaterialWitness[] ReadCopiedBuiltinWitnesses(Config config)
    {
        Need(config.copied_materials != null && config.copied_materials.Length == 4, "Exactly four already-native copied Material inputs required");
        var ids = new HashSet<string>(); var guids = new HashSet<string>();
        foreach (BuiltinMaterialWitness row in config.copied_materials)
        {
            Need(row.builtin_guid == "0000000000000000f000000000000000" && ids.Add(row.builtin_local_id) && guids.Add(row.material_guid), "Exact unique builtin and copied Material identities");
            long expectedId = long.Parse(row.builtin_local_id, System.Globalization.CultureInfo.InvariantCulture);
            Need(row.material_source_path == "Assets/Resources/BuiltinIdentityWitnesses/Builtin-" + row.builtin_local_id + ".mat", "Exact copied native Material path");
            Need(Sha(row.material_source_path) == row.asset_sha256 && Sha(row.material_source_path + ".meta") == row.meta_sha256, "Copied native Material bytes/meta changed");
            Material material = AssetDatabase.LoadAssetAtPath<Material>(row.material_source_path);
            string guid; long local; string shaderGuid; long shaderLocal;
            Need(material != null && material.shader != null && AssetDatabase.TryGetGUIDAndLocalFileIdentifier(material, out guid, out local)
                 && guid == row.material_guid && local.ToString(System.Globalization.CultureInfo.InvariantCulture) == row.material_local_id, "Actual copied Material identity");
            Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(material.shader, out shaderGuid, out shaderLocal)
                 && shaderGuid == row.builtin_guid && shaderLocal == expectedId, "Actual copied Material.m_Shader must bind exact genuine builtin GUID/localID");
            Need(!builtinShaders.ContainsKey(expectedId) || builtinShaders[expectedId] == material.shader, "One actual builtin object per exact identity");
            builtinShaders[expectedId] = material.shader;
            row.shader_instance_equal_after_native_import = true;
        }
        Need(ids.SetEquals(new[] { "6", "7", "46", "10490" }), "Exact four proven builtin localIDs");
        return config.copied_materials;
    }
''' +text[end:]
    text=replace(text,'Need(config.shaders != null && config.shaders.Length == (config.include_alpha_clip ? 8 : 7), "Exact explicitly selected Shader count required");',
        'Need(config.Editor_dependency_projection && config.include_alpha_clip && config.shaders != null && config.shaders.Length == 8, "Exactly eight explicit Editor-only null-dependency projections required");')
    text=replace(text,'result.builtin_shader_material_witnesses = CreateBuiltinWitnesses();','result.builtin_shader_material_witnesses = ReadCopiedBuiltinWitnesses(config);')
    return text


def runner():
    source=HERE/'run_original_shader_builtin_identity_fixture.py'
    if sha(source)!='1ba8406a60d8ad13daad819240f1717d8ade7bd5a50561b11222c024279a56db':raise ValueError('Pinned original runner changed')
    text=source.read_text().replace('BuildOriginalShaderBuiltinIdentityFixture','BuildOriginalShaderNullDependencyFixture').replace('OriginalShaderBuiltinIdentityFixture-','OriginalShaderNullDependencyFixture-').replace('OriginalShaderBuiltinIdentityDiagnostic','OriginalShaderNullDependencyDiagnostic')
    text=text.replace('prepared-selected-original-Shader-builtin-Material-import-build/v1','prepared-eight-original-Shader-null-Editor-projection-build/v1')
    text=text.replace('guarded-selected-original-Shader-builtin-Material-import-build/v1','guarded-eight-original-Shader-null-Editor-projection-build/v1')
    text=replace(text,'import run_windows_development_define_probe as guard','import run_windows_development_define_probe as guard\nimport prepare_original_shader_null_dependency_projection as projection')
    start=text.index('def select_inputs(');end=text.index('\ndef query_final_job',start)
    text=text[:start]+'''def select_inputs(manifest, wrappers, manifest_sha, include_alpha_clip=False):
    guard.need(include_alpha_clip and manifest['schema'] == 'resolved-original-Shader-Editor-collection/v1'
               and manifest['Editor_projection_only'] is True and manifest['shipping_null_dependencies_authorized'] is False
               and tuple(r['guid'] for r in manifest['shaders']) == projection.GUIDS, 'Exact eight Editor-only projected identities required')
    authority_pin = manifest['original_Release_authority']
    guard.checked(authority_pin)
    guard.need(authority_pin['sha256'] == projection.AUTHORITY_SHA, 'Unchanged canonical original Release authority')
    authority = json.loads(Path(authority_pin['path']).read_bytes())
    original = {r['guid']: r for r in authority['shaders']}
    projected = {r['guid']: r for r in manifest['shaders']}
    for guid in projection.GUIDS: projection.validate(original[guid], projected[guid])
    guard.need(wrappers['schema'] == 'original-Shader-Editor-wrapper-collection/v1'
               and wrappers['status'] == 'all_mapped_original_Shader_Editor_wrappers_verified_native_import_unproven'
               and wrappers['manifest']['sha256'] == manifest_sha and wrappers['count'] == len(wrappers['shaders']) == 8, 'Actual successful fresh8 projection wrappers')
    wrapped = {r['guid']: r for r in wrappers['shaders']}
    guard.need(len(wrapped) == 8 and set(wrapped) == set(projected), 'Exact projected wrapper identity set')
    rows = [wrapped[g] for g in projection.GUIDS]
    for row in rows:
        p = projected[row['guid']]
        guard.need(row['name'] == p['name'] and row['meta']['sha256'] == p['meta']['sha256']
                   and row['expected_direct_shader_dependencies'] == [], 'Exact original names/metas and projected empty Editor graph')
        guard.checked(row['proof'])
        proof = json.loads(Path(row['proof']['path']).read_bytes())
        guard.need(proof['entire_ParsedForm_equal'] and proof['all_original_program_fields_equal']
                   and proof['all_Release_bytes_outside_name_and_manifest_typed_PPtr_windows_equal']
                   and proof['output_shape']['external_rows'] == [], 'All original programs/ParsedForm preserved and no Editor external rows')
    guard.need(sum(r['asset']['bytes'] for r in rows) <= 5*1024**2, 'Bounded original8 wrappers')
    return projected, rows

''' +text[end:]
    text=replace(text,"    by_guid, selected = select_inputs(manifest, wrappers, args.manifest_sha256, args.include_alpha_clip)",'''    by_guid, selected = select_inputs(manifest, wrappers, args.manifest_sha256, args.include_alpha_clip)
    guard.need(args.projection_plan and guard.sha(args.projection_plan) == args.projection_plan_sha256, 'Reviewed projection plan required')
    projection_plan = json.loads(args.projection_plan.read_bytes())
    guard.need(projection_plan['manifest']['sha256'] == args.manifest_sha256 and projection_plan['status'] == 'prepared_no_managed_Editor_or_player_started', 'Exact reviewed8 projection plan')
    for source_pin in [projection_plan['manifest'], projection_plan['canonical_authority'], projection_plan['offline_controls'], projection_plan['actual_prior_builtin_identity_proof']]: guard.checked(source_pin)''')
    text=replace(text,"    original_inputs = {Path(row['path']).relative_to(TEMPLATE / 'Project').as_posix(): row for row in base['inputs']}","    sources += [pin(args.projection_plan), pin(Path(projection.__file__)), projection_plan['offline_controls'], projection_plan['actual_prior_builtin_identity_proof']]\n    original_inputs = {Path(row['path']).relative_to(TEMPLATE / 'Project').as_posix(): row for row in base['inputs']}")
    text=replace(text,"    config = out / 'config.json'\n    save(config, {'project': str(project), 'graphics_sha256': guard.sha(graphics_path), 'shaders': shaders, 'include_alpha_clip': args.include_alpha_clip})",'''    copied_materials = []
    for material in projection_plan['copied_native_Material_sources']:
        witness = material['witness']
        guard.need(witness['material_source_path'] == 'Assets/Resources/BuiltinIdentityWitnesses/Builtin-' + witness['builtin_local_id'] + '.mat', 'Exact native Material destination')
        copy(Path(material['asset']['path']), witness['material_source_path'], material['asset']['sha256'])
        copy(Path(material['meta']['path']), witness['material_source_path'] + '.meta', material['meta']['sha256'])
        copied_materials.append(witness)
    guard.need(len(copied_materials) == 4 and {r['builtin_local_id'] for r in copied_materials} == {'6','7','46','10490'}, 'Exact four native Material inputs')
    config = out / 'config.json'
    save(config, {'project': str(project), 'graphics_sha256': guard.sha(graphics_path), 'shaders': shaders, 'include_alpha_clip': True,
                  'Editor_dependency_projection': True, 'copied_materials': copied_materials})''')
    text=replace(text,"            'include_alpha_clip': args.include_alpha_clip, 'final_owned_job_telemetry_enabled': True,", "            'include_alpha_clip': True, 'final_owned_job_telemetry_enabled': True,\n            'projection_plan': pin(args.projection_plan), 'material_witnesses': copied_materials, 'Editor_only_null_dependency_projection': True,")
    text=replace(text,"               and plan['final_owned_job_telemetry_enabled'],", "               and plan['final_owned_job_telemetry_enabled'] and plan['Editor_only_null_dependency_projection'] is True,")
    text=replace(text,"               and config['include_alpha_clip'] == plan['include_alpha_clip'],", "               and config['include_alpha_clip'] == plan['include_alpha_clip'] and config['Editor_dependency_projection'] is True\n               and config['copied_materials'] == plan['material_witnesses'] and len(config['copied_materials']) == 4,")
    text=replace(text,"    out = path.parent / ('Run-'", "    path = path.resolve(strict=True)\n    out = path.parent / ('Run-'")
    text=replace(text,"                   and built['four_builtin_material_witnesses_verified'] and built['serialization_mode'] == 'Mixed'", "                   and built['four_builtin_material_witnesses_verified'] and built['Editor_only_null_dependency_projection']\n                   and not built['original_dependencies_restored_in_player'] and built['serialization_mode'] == 'Mixed'")
    text=text.replace('Out of memory\', line','Out of memory|StackOverflowException\', line')
    text=replace(text,"    parser.add_argument('--include-alpha-clip', action='store_true',", "    parser.add_argument('--projection-plan', type=Path)\n    parser.add_argument('--projection-plan-sha256')\n    parser.add_argument('--include-alpha-clip', action='store_true', default=True,")
    text=replace(text,""""Prepare/review seven original Shaders and four builtin Material witnesses.""", """"Prepare/review eight Editor-only dependency projections and four native Materials.""")
    ast.parse(text)
    return text


def main():
    outputs={'BuildOriginalShaderNullDependencyFixture.cs':builder(),'run_original_shader_null_dependency_fixture.py':runner()}
    for name,text in outputs.items():
        target=HERE/name
        with target.open('x',encoding='utf-8',newline='\n') as stream:stream.write(text)
        print(name+' '+sha(target))


if __name__=='__main__':main()
