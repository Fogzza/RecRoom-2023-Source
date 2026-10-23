"""Prepare two genuine SDK DLLs, never install them or change runtime hash maps."""
from pathlib import Path
from datetime import datetime, timezone
import argparse
import hashlib
import importlib.util
import json
import shutil
import struct
import uuid

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
EDITOR = WORKSPACE / 'Tools/Editors/2020.3.33f1/Editor'
spec = importlib.util.spec_from_file_location('sdk_proposal_guard',HERE/'build_stage_guarded.py')
guard = importlib.util.module_from_spec(spec);spec.loader.exec_module(guard)


def sha(path):
    with path.open('rb') as stream:return hashlib.file_digest(stream,'sha256').hexdigest()


def checked_inverse(data, expected_sha, Cli):
    if hashlib.sha256(data).hexdigest()!=expected_sha:raise ValueError('Exact candidate PE hash required')
    view=Cli(data);found=[]
    for rid in range(1,view.rows[2]+1):
        at=view.row(2,rid)
        if view.string(view.value(at+4,view.strw))=='<PrivateImplementationDetails>' and view.string(view.value(at+4+view.strw,view.strw))=='':found.append((rid,at))
    if len(found)!=1:raise ValueError('Unique exact compiler-private native type required')
    rid,at=found[0]
    if view.u32(at)!=0x100:raise ValueError('Unreviewed source TypeAttributes')
    for nr in range(1,view.rows[41]+1):
        if view.value(view.row(41,nr),view.index(2))==rid:raise ValueError('Compiler-private target unexpectedly nested')
    method_at=at+4+2*view.strw+view.coded(2,[2,1,27])+view.index(4)
    first=view.value(method_at,view.index(6))
    end=view.value(view.row(2,rid+1)+4+2*view.strw+view.coded(2,[2,1,27])+view.index(4),view.index(6)) if rid<view.rows[2] else view.rows[6]+1
    if first!=end:raise ValueError('No constructor or other body may belong to the compiler-private target')
    result=bytearray(data);struct.pack_into('<I',result,at,0x100100)
    changes=[i for i,(a,b) in enumerate(zip(data,result)) if a!=b]
    if changes!=[at+2]:raise ValueError('Expected exactly one flag byte; all bodies/PDB/tokens untouched')
    return bytes(result),{'candidate_type_token':hex(0x02000000|rid),'file_offset':at,'original_flags':0x100,'restored_native_flags':0x100100,'changed_byte_offsets':changes,'methods_owned':0}


def main():
    p=argparse.ArgumentParser();p.add_argument('--candidate',type=Path,required=True);args=p.parse_args();candidate=args.candidate.resolve(strict=True)
    proof=json.loads((candidate/'report.json').read_text())
    if proof['status']!='compiled-and-contract-audited-no-apply':raise ValueError('Compiled, native-audited candidate required')
    output=ROOT/'RuntimeSDKRecovery'/('GenuineAddressablesProposal-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);output.mkdir()
    (output/'PlayerWindows').mkdir();(output/'ToolInputs').mkdir()
    helper=HERE/'audit_cli_marshal_contracts.py';snapshot=output/'ToolInputs'/helper.name;shutil.copyfile(helper,snapshot)
    spec=importlib.util.spec_from_file_location('sdk_cli_snapshot',snapshot);cli=importlib.util.module_from_spec(spec);spec.loader.exec_module(cli)
    report={'schema':'genuine-addressables-two-DLL-staged-proposal/v1','status':'preparing-no-apply','phases':[],
            'project_changed':False,'runtime_hash_map_changed':False,'SDK_or_game_methods_executed':False,'target_profile':'original-April2023-Windows-PC-branch',
            'all_platform_source_preserved':True,'other_platform_runtime_validation_pending':True,
            'source_candidate':{'path':str(candidate/'report.json'),'sha256':sha(candidate/'report.json')},'files':[]}
    try:
        for assembly in ('Unity.ResourceManager','Unity.Addressables'):
            src=candidate/'PlayerWindows'/(assembly+'.dll');dst=output/'PlayerWindows'/src.name
            audit=json.loads(src.with_suffix('.native-identity.json').read_text())
            if audit['candidate_dll_sha256']!=sha(src) or not audit['tool_helper_absent_from_original_native']:raise ValueError('Native candidate/helper proof changed')
            for inp in audit['source_inputs']:
                if sha(Path(inp['path']))!=inp['sha256']:raise ValueError('Original native identity input changed')
            if assembly=='Unity.ResourceManager':
                if audit['errors']!=[{'kind':'type-flags','owner':'<PrivateImplementationDetails>','native':1048832,'candidate':256,'native_token':'0x2000063'}]:raise ValueError('More than the single reviewed compiler-private flag delta')
                native=[t for t in audit['native_types'] if t['owner']=='<PrivateImplementationDetails>']
                if len(native)!=1 or native[0]['flags']!=0x100100 or native[0]['methods'] or len(native[0]['fields'])!=1:raise ValueError('Exact native private header/no-body witness required')
                before=src.read_bytes();after,inverse=checked_inverse(before,sha(src),cli.Cli);dst.write_bytes(after)
                controls=[]
                for name,mutate in [('wrong-sha',lambda d:d[:-1]+bytes([d[-1]^1])),('wrong-header',lambda d:d[:inverse['file_offset']]+struct.pack('<I',0x101)+d[inverse['file_offset']+4:])]:
                    try:checked_inverse(mutate(before),sha(src),cli.Cli)
                    except ValueError:controls.append(name)
                    else:raise ValueError('Inverse negative fixture accepted '+name)
                wrong=bytearray(before);wrong[inverse['file_offset']]=0x01
                try:checked_inverse(bytes(wrong),hashlib.sha256(wrong).hexdigest(),cli.Cli)
                except ValueError:controls.append('wrong-flags-with-rebound-hash')
                else:raise ValueError('Unreviewed flags accepted')
                report['compiler_private_inverse']={**inverse,'native_type':native[0],'source_sha256':sha(src),'candidate_sha256':sha(dst),'byte_identity_except_single_TypeDef_flag':True,'negative_controls_rejected':controls}
            else:
                if audit['errors']:raise ValueError('Addressables has original native contract gaps')
                shutil.copyfile(src,dst)
            pdb=src.with_suffix('.pdb');shutil.copyfile(pdb,dst.with_suffix('.pdb'))
            meta=WORKSPACE/'RR23/Assets/Plugins'/(assembly+'.dll.meta');meta_copy=output/'PlayerWindows'/meta.name;shutil.copyfile(meta,meta_copy)
            report['files'].append({'assembly':assembly,'candidate':str(dst),'sha256':sha(dst),'source_dll':str(src),'source_sha256':sha(src),'pdb':str(dst.with_suffix('.pdb')),'pdb_sha256':sha(pdb),'original_project_meta':str(meta),'original_meta_sha256':sha(meta),'proposed_meta_copy':str(meta_copy),'meta_bytes_GUID_and_all_platform_filters_unchanged':True})
            rows=dst.with_suffix('.native-rows.json')
            guard.reserved_phase([EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',candidate/'SDKContractAudit.exe','--native-rows',dst,rows],output,'proposed-native-rows-'+assembly,report,maximum=60,cap=.5)
            native_report=dst.with_suffix('.native-identity.json')
            guard.reserved_phase(['C:/Python314/python.exe',HERE/'audit_official_sdk_native_identity.py','--rows',rows,'--output',native_report],output,'proposed-native-identity-'+assembly,report,maximum=90,cap=.5)
            result=json.loads(native_report.read_text())
            if result['status']!='passed' or result['errors']:raise ValueError('Proposed original native identity must pass')
            contract=dst.with_suffix('.contract-audit.json')
            original=next(r for r in proof['profiles'] if r['profile']=='PlayerWindows' and r['assembly']==assembly)
            raw=json.loads(Path(original['contract_audit']['path']).read_text())['assembly']
            guard.reserved_phase([EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',candidate/'SDKContractAudit.exe',raw['native_metadata']['path'],raw['current_runtime']['path'],dst,contract],output,'proposed-full-contract-'+assembly,report,maximum=60,cap=.5)
            if not json.loads(contract.read_text())['assembly']['all_original_contracts_match']:raise ValueError('Proposed complete SDK contract comparison must pass')
        inputs=Path(candidate/'explicit-current-core-and-runtime-inputs.txt').read_text().splitlines()
        replacements={str(candidate/'PlayerWindows'/(r['assembly']+'.dll')):r['candidate'] for r in report['files']}
        new_inputs=output/'explicit-current-core-and-runtime-inputs.txt';new_inputs.write_text('\n'.join(replacements.get(p,p) for p in inputs)+'\n')
        closure=output/'target-sdk-reference-closure.json'
        guard.reserved_phase([EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',candidate/'SDKReferenceAudit.exe',new_inputs,output/'PlayerWindows',EDITOR,closure],output,'proposed-complete-sdk-reference-closure',report,maximum=90,cap=.5)
        if json.loads(closure.read_text())['unresolved']!=0:raise ValueError('Proposed SDK reference closure must pass')
        report.update(status='native-contracts-and-reference-closure-passed-not-installed',sdk_reference_closure={'path':str(closure),'sha256':sha(closure)},genuine_managed_method_bodies=1342,
                      required_next_gates=['SDK-only reviewed original texture bundle runtime load','fresh test-only runtime hash-map/core ILPP + Mono signature gate after native marshal gaps fixed','per-platform package integration/compilation validation'])
    except Exception as error:report.update(status='failed-no-apply',error=str(error))
    report['tool_inputs']=[{'path':str(x),'sha256':sha(x)} for x in (Path(__file__).resolve(),snapshot,HERE/'audit_official_sdk_native_identity.py')]
    (output/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(output/'report.json'),'error':report.get('error')}))
    return 0 if report['status']!='failed-no-apply' else 1


if __name__=='__main__':raise SystemExit(main())
