"""Record current recovery evidence without changing project or backend files."""
from datetime import datetime, timezone
import hashlib
import json
from pathlib import Path
import uuid


ROOT = Path(__file__).resolve().parents[3] / 'Recovery/RecRoom-2023-04-18'


def digest(data):
    return hashlib.sha256(data).hexdigest()


def main():
    target = ROOT / 'RECOVERY_STATUS.json'
    before = target.read_bytes()
    status = json.loads(before)
    validation = ROOT / 'Validation'
    latest = max(validation.glob('FullWindowsBuild-*/run-report.json'))
    build = json.loads(latest.read_bytes())
    result = build.get('build_report') or {}
    built = build['status'] == 'built_gameplay_unverified'
    final_build_report = result.get('status') in ('Succeeded', 'Failed', 'Cancelled')
    status['updated_utc'] = datetime.now(timezone.utc).isoformat()
    status['completion_status'] = 'incomplete'
    status['windows_build_created'] = built
    status['windows_build_current'] = {
        'status': build['status'],
        'attempt': str(latest.parent.relative_to(ROOT)),
        'report': str(latest.relative_to(ROOT)),
        'scope': 'all107_original_enabled_scenes',
        'requested_build': 'Windows64 Mono Development StrictMode',
        'output': build['output'],
        'errors': result.get('totalErrors') if final_build_report else None,
        'warnings': result.get('totalWarnings') if final_build_report else None,
        'final_unity_build_report_received': final_build_report,
        'player_created': build.get('player_created', False),
        'runtime_content_complete': True,
        'job_limit_mib': build['job_cap_bytes'] // 1024**2,
        'system_commit_reserve_mib': build['minimum_available_commit_bytes'] // 1024**2,
        'scenes_and_settings_byte_unchanged': build.get('scenes_and_settings_byte_unchanged'),
        'gameplay_verified': False, 'login_verified': False, 'dorm_verified': False,
    }
    cleanup_path = latest.parent / 'post-abort-cleanup-recovery.json'
    if cleanup_path.is_file():
        cleanup = json.loads(cleanup_path.read_bytes())
        if cleanup.get('status') == 'owned_abort_cleanup_recovered':
            status['windows_build_current'].update(
                post_abort_cleanup_receipt=str(cleanup_path.relative_to(ROOT)),
                scenes_and_settings_byte_unchanged=cleanup.get('all_original_scenes_and_settings_SHA256_restored') is True,
                operator_Photon_configuration_preserved=cleanup.get('current_user_Photon_configuration_SHA256_unchanged') is True)
    if build.get('status') in ('failed', 'stopped', 'built_gameplay_unverified'):
        log_path = latest.parent / 'Editor.log'
        if log_path.is_file():
            log = log_path.read_text(encoding='utf-8', errors='replace')
            status['windows_build_current'].update(
                logged_CS_errors=log.count('error CS'),
                logged_partial_constant_buffer_errors=log.count('Partial constant buffer not found.'))
        status['windows_build_current']['elapsed_seconds'] = build.get('seconds')
        status['windows_build_current']['peak_owned_job_bytes'] = max(
            (sample['peak_job_memory'] for sample in build.get('samples', [])), default=0)
    status['current_focus'] = ('Build the recovered original Windows player, recover missing startup/gameplay bodies, '
        'and configure operator-owned Photon apps. Compilation and configuration do not prove login or dorm gameplay.')
    status['interactive_Unity_progress']['status'] = 'prior_interactive_session_closed_before_guarded_build'
    if 'pid' in status['interactive_Unity_progress']:
        status['interactive_Unity_progress']['historical_pid'] = status['interactive_Unity_progress'].pop('pid')
    status['backend_target_status'] = ('Existing https://ns.nerlz.com remains the requested backend. '
        'Exact 20230414 auth compatibility exception is staged with 21 local controls; '
        'not deployed. Current ns/api/auth/match source was captured read-only from the verified existing account; '
        'gate analysis and end-to-end access remain unverified.')
    status['backend_server_modified'] = False
    backend_runs = list((ROOT.parents[1] / 'Rebuild/LiveCloudflareSnapshot').glob(
        'active-version-plan-*/ExactGateDeployPlan-v2-*/Run-20*/redacted-summary.json'))
    if backend_runs:
        backend_receipt = max(backend_runs)
        backend = json.loads(backend_receipt.read_bytes())
        if backend.get('status') == 'deployed_exact20230414_gate_exceptions_source_and_configuration_verified':
            status['backend_target_status'] = ('Existing https://ns.nerlz.com remains the requested backend. '
                'Exact 20230414 exceptions were deployed to its existing auth and api Workers; '
                'both active versions, exact candidate sources, and unchanged configuration were verified. '
                'Other services, Photon routing, accounts, rooms, and migration remain unchanged. '
                'No account login or recovered game runtime is verified.')
            status['backend_server_modified'] = True
            status['backend_version_compatibility'] = {
                'protocol_version': '20230414', 'status': backend['status'],
                'receipt': str(backend_receipt), 'receipt_sha256': digest(backend_receipt.read_bytes()),
                'workers': ['auth', 'api'], 'other_version_gates_unchanged': True,
                'configuration_and_binding_values_preserved': True,
                'actual_extracted_predicate_checks': 41,
                'offline_transaction_and_scope_checks': 15,
                'end_to_end_login_verified': False, 'migration_performed': False,
                'Photon_routing_modified': False,
            }
            public_probes = list(backend_receipt.parent.parent.glob('PublicVersionCheck-*/report.json'))
            if public_probes:
                public_receipt = max(public_probes)
                public = json.loads(public_receipt.read_bytes())
                if public.get('status') == 'both_public_version_results_verified':
                    status['backend_version_compatibility'].update(
                        public_versioncheck_verified=True,
                        public_receipt=str(public_receipt),
                        public_receipt_sha256=digest(public_receipt.read_bytes()),
                        public_results=[{k: row[k] for k in ('case', 'HTTP_status', 'observed_VersionStatus')}
                            for row in public['cases']])
    status['backend_current_source_capture'] = {
        'status': 'captured_read_only_existing_account_13_GET_requests',
        'redacted_receipt': str(ROOT.parents[1] / 'Rebuild/LiveCloudflareSnapshot/current-source-refresh-20261022T205414Z-a85f3d3f/redacted-summary.json'),
        'services': ['ns', 'api', 'auth', 'match'], 'deployment_or_migration_performed': False,
    }
    status['shader_import_validation'] = {
        'Main_shader_candidates_applied': False,
        'original_compiled_data_available_for_four_empty_shaders': True,
        'candidate_fixture': 'AssetRecovery/OriginalStencilImportFixture-20261022T194521Z-be9d6ebe/Run-20261022T204112Z-e43d90cf/run-report.json',
        'known_serialized_nonempty_control': 'AssetRecovery/OriginalKnownNonemptyShaderControl-20261022T204739Z-fd7e5da6/Run-20261022T205647Z-71a0c665/run-report.json',
        'result': 'SerializedObject readback was inconclusive. A real diagnostic Windows build then emitted empty GPU program data for all three extracted YAML Shader inputs; its built-in positive control retained eight genuine DXBC programs.',
        'interpretation': 'The diagnostic build succeeded, but native output inspection disproved original GPU program retention. It is not a usable game build. No Shader replacements have been applied to the main project.',
        'real_windows_build_fidelity_report': 'AssetRecovery/OriginalShaderWindowsBuildFixture-20261022T210316Z-7924a487/NativePostprocess-20261022T210722Z-92f4ffd2/run-report.json',
        'builtin_positive_control': 'AssetRecovery/OriginalShaderWindowsBuildFixture-20261022T210316Z-7924a487/BuiltinProgramControl-20261022T210840Z-7b0010d2/run-report.json',
        'native_binary_import_attempt': {
            'report': 'AssetRecovery/OriginalShaderWindowsBuildFixture-Binary-20261022T211417Z-3eca2ea8/Run-20261022T211520Z-7f7876ca/run-report.json',
            'result': 'Editor rejected the staged singleton native container as corrupted; no native load, build, or program fidelity proved.',
        },
        'Editor_layout_conversion': {
            'receipt': 'AssetRecovery/OriginalShaderEditorConversion-20261022T212623Z-fde1a98d/run-report.json',
            'result': 'Entire original data after the stripped NamedObject name, all five program fields, and four original DXBC programs survived managed Editor-layout roundtrip. Only the exact original ParsedForm name was restored.',
            'native_Editor_load_succeeded': True,
        },
        'direct_binary_import_attempt': {
            'receipt': 'AssetRecovery/OriginalShaderWindowsBuildFixture-DirectBinary-20261022T213422Z-9845f81f/Run-20261022T213511Z-27a1c1d6/run-report.json',
            'result': 'Unity automatically rewrote the binary Shader to YAML under ForceText. Asset hash changed, meta stayed exact, and the guard stopped before building. Zero constant-buffer log messages in this attempt.',
            'native_build_fidelity_proven': False,
        },
        'Mixed_mode_binary_build_attempt': {
            'receipt': 'AssetRecovery/OriginalShaderWindowsBuildFixture-Mixed-20261022T214413Z-51ccf456/Run-20261022T214438Z-0aae461b/run-report.json',
            'final_program_retention_receipt': 'AssetRecovery/OriginalShaderWindowsBuildFixture-Mixed-20261022T214413Z-51ccf456/FinalProgramRetentionControl-20261022T214751Z-c6acd585/run-report.json',
            'final_program_retention_receipt_sha256': '7630452613e6b72afe2899373847500eba625db9fbaf2a121054018609555243',
            'original_binary_meta_GUID_and_local_file_ID_preserved': True,
            'isolated_Windows_build_succeeded': True,
            'build_errors': 0, 'build_warnings': 0, 'partial_constant_buffer_log_messages': 0,
            'result': 'BuildPlayer completed, but packaged Shader inspection found no structurally valid DXBC program chunks. Original GPU-program retention failed despite intact source binary data.',
            'original_Fallback_DXBC_programs': 4, 'packaged_Fallback_DXBC_programs': 0,
            'same_build_builtin_positive_control_DXBC_programs': 8,
            'diagnostic_executable_is_a_game_build': False,
            'native_build_fidelity_proven': False,
        },
        'GPU_rendering_verified': False,
    }
    status['remaining_playable_build_blockers'] = [
        'Scale the isolated, GPU-proven original Shader packaging workaround to all required Shader assets and dependency references; the main project is not yet updated.',
        'RecRoomGameRoot startup methods and substantial BootSequence/login/gameplay methods still contain empty or null-returning bodies.',
        'The original custom URP runtime includes missing implementations; stock local 10.8.1 sources do not implement its custom API.',
        'Photon app IDs are configured, but client transport and operator-owned matchmaking routing are not verified.',
    ]
    shader_runtime = ROOT / 'AssetRecovery/OriginalShaderRuntimePatchFixture-20261023T024141Z-2a543430/Run-20261023T024141Z-06257a67/run-report.json'
    clean_bundle = ROOT / 'AssetRecovery/OriginalShaderOnlyBundleRuntimeInput-20261023T024041Z-94c09341/Runtime-20261023T024823Z-2e259544/run-report.json'
    if shader_runtime.is_file() and clean_bundle.is_file():
        first, second = json.loads(shader_runtime.read_bytes()), json.loads(clean_bundle.read_bytes())
        if (digest(shader_runtime.read_bytes()) == 'c78a2385429ac165141ebb577d7200362ae65782c70959b9baca5c7f676a60ab'
                and digest(clean_bundle.read_bytes()) == '7416a7b0ffd2049e310f6cbdc765e7b9a6ff1af87d458981624bf7ae4083e7b2'
                and first.get('status') == 'exact_original_release_shader_patch_passed_D3D11_runtime_positive_and_negative_controls'
                and second.get('status') == 'exact_original_shader_only_bundle_loaded_and_rendered_D3D11_without_reemission'
                and not second.get('full_log_shader_diagnostics')
                and not second['clean-patched-player-green-control'].get('full_log_shader_diagnostics')):
            status['shader_import_validation'].update(
                GPU_rendering_verified=True,
                GPU_rendering_scope='Two isolated original Shader diagnostics only; no room, material set or game rendering verified',
                packaging_workaround_applied_to_Main=False,
                original_release_post_build_patch={
                    'receipt': str(shader_runtime.relative_to(ROOT)), 'receipt_sha256': digest(shader_runtime.read_bytes()),
                    'original_shader': 'Hidden/Universal Render Pipeline/FallbackError',
                    'packaged_DXBC_before_patch': 0, 'exact_original_DXBC_after_patch': 4,
                    'actual_D3D11_runtime_supported_SetPass_and_magenta_readback_verified': True,
                    'whole_patched_player_log_checked_by_supplement': 'AssetRecovery/RuntimeShaderProofSupplement-20261023T024917Z-26d72acf/report.json',
                    'all_nontarget_native_object_rows_ranges_and_payloads_preserved': True,
                    'scope': 'Pointer-free Fallback32 Shader; not yet a generic shader/dependency patcher'},
                exact_original_bundle_runtime={
                    'receipt': str(clean_bundle.relative_to(ROOT)), 'receipt_sha256': digest(clean_bundle.read_bytes()),
                    'original_shader': 'AG/ShareCameraOverwriteAlpha', 'original_DXBC_programs': 16,
                    'bundle_bytes': 18205, 'shader_properties': 9, 'material_passes': 1,
                    'actual_D3D11_load_support_SetPass_render_readback_verified': True,
                    'independent_green_GPU_control_in_clean_patched_player': True,
                    'complete_player_logs_shader_and_constant_buffer_errors': 0,
                    'original_bundle_bytes_unchanged': True, 'pixel_visual_fidelity_claimed': False})
            status['current_focus'] = ('Scale original compiled Shader preservation from the successful D3D11 diagnostics '
                'to room shaders with original dependency identities, then retry the original Windows build. '
                'Startup, login, dorm gameplay, custom URP implementation and Photon transport remain incomplete.')
    operator_input = ROOT / 'Configuration/photon-operator-apps.json'
    status['photon_configuration'] = {
        'requested': True, 'operator_has_own_app_ids': True,
        'operator_app_id_values_received': operator_input.is_file(),
        'configuration_status': 'operator_ids_received_staged_pending_build_exit' if operator_input.is_file() else 'prepared_waiting_for_operator_realtime_and_voice_ids',
        'audit': 'Validation/PhotonConfigurationAudit-20261022T202400Z/configuration-and-flow.json',
        'transport_methods_recovered': False, 'runtime_networking_verified': False,
        'original_export_app_ids_must_not_be_reused': True,
    }
    applied_photon = list(validation.glob('OwnPhotonConfigurationPlan-*/Staged-*/applied.json'))
    if applied_photon:
        photon_receipt = max(applied_photon)
        photon = json.loads(photon_receipt.read_bytes())
        resource = Path(photon['after']['path'])
        if resource.is_file() and digest(resource.read_bytes()) == photon['after']['sha256']:
            status['photon_configuration'].update(
                configuration_status='own_realtime_and_voice_ids_applied',
                applied_receipt=str(photon_receipt.relative_to(ROOT)))
    status['windows_development_marshalling_scope'] = {
        'status': 'applied_after_matching_compile_and_50_controls',
        'receipt': 'CompilerRepairs/AppliedWindowsMonoDevelopmentScope-20261022T201106Z-bb1b5d7e/report.json',
        'scope': 'Windows x64 Editor or non-Editor Windows64 Mono Development only',
    }
    status['unneeded_native_EAC'] = {
        'status': 'Win64_importer_disabled_original_binary_preserved',
        'receipt': 'CompilerRepairs/AppliedUnneededNativeEACExclusion-20261022T201627Z-3b702c48/report.json',
        'required_CodeStage_types_preserved': True,
    }
    status['method_recovery']['protocol_version_getter_recovery'] = {
        'status': 'two_original_getter_bodies_applied_matching_compile_and_six_managed_controls_passed',
        'network_version': '20230414',
        'receipt': 'Validation/OriginalProtocolGettersCompileApply-20261022T202304Z-5cbf410e/report.json',
    }
    stamp = datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    out = validation / ('StatusRefresh-' + stamp)
    out.mkdir()
    backup = out / 'RECOVERY_STATUS.before.json'
    backup.write_bytes(before)
    after = (json.dumps(status, indent=2) + '\n').encode('utf-8')
    temporary = out / 'RECOVERY_STATUS.updated.json'
    temporary.write_bytes(after)
    if target.read_bytes() != before:
        raise RuntimeError('Recovery status changed during refresh; preserved all files without replacing it')
    temporary.replace(target)
    receipt = {'status': 'current_evidence_recorded', 'backup': str(backup),
        'before_sha256': digest(before), 'after_sha256': digest(target.read_bytes()),
        'latest_build_report': str(latest), 'project_or_backend_modified': False}
    (out / 'report.json').write_text(json.dumps(receipt, indent=2) + '\n', encoding='utf-8')
    print(json.dumps(receipt))


if __name__ == '__main__':
    main()
