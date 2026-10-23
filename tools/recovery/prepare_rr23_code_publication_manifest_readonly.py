"""Prepare a pinned source-only publication manifest. No copying or network."""
from pathlib import Path
from collections import Counter, defaultdict
import datetime as dt
import hashlib
import json
import re
import subprocess
import uuid

WS=Path(__file__).resolve().parents[3]
PROJECT=WS/'RR23'
BASE=WS/'Recovery/RecRoom-2023-04-18/SourcePublicationAudit'
SOURCE_SUFFIXES={'.cs','.shader','.hlsl','.cginc','.glsl','.compute','.asmdef','.asmref','.rsp','.uxml','.uss','.shadergraph','.shadersubgraph'}
STRONG={
    'private_key_header':rb'-----BEGIN (?:RSA |EC |DSA |OPENSSH |ENCRYPTED )?PRIVATE KEY-----',
    'github_token_format':rb'(?:gh[pousr]_[A-Za-z0-9]{30,255}|github_pat_[A-Za-z0-9_]{30,255})',
    'aws_access_key_id_format':rb'(?:AKIA|ASIA)[A-Z0-9]{16}',
    'cloudflare_token_assignment':rb'(?i)(?:cf_api_token|CLOUDFLARE_API_TOKEN|CLOUDFLARE_API_KEY)\s*[=:]\s*[\"\x27]?[A-Za-z0-9_-]{20,255}',
    'slack_token_format':rb'xox[baprs]-[A-Za-z0-9-]{20,255}',
    'jwt_literal_format':rb'eyJ[A-Za-z0-9_-]{8,2048}\.[A-Za-z0-9_-]{8,4096}\.[A-Za-z0-9_-]{16,512}',
    'credential_in_url':rb'https?://[^\s/\"\x27:@]{1,100}:[^\s/\"\x27@]{1,200}@',
    'discord_webhook_format':rb'https://(?:(?:canary|ptb)\.)?discord(?:app)?\.com/api/webhooks/[0-9]{12,30}/[A-Za-z0-9_-]{25,255}',
}
GENERIC=re.compile(rb'(?i)(?:password|passwd|client_?secret|secret_?key|api_?secret|api_?key|access_?token|refresh_?token|auth_?token|authorization|private_?key|signing_?key|jwt_?secret)[A-Za-z0-9_]{0,64}[\"\x27]?\s*[:=]\s*[\"\x27]([^\"\x27\r\n]{8,500})[\"\x27]')
RX={k:re.compile(v) for k,v in STRONG.items()}
TEXT_SUFFIXES=SOURCE_SUFFIXES|{'.json','.txt','.md','.xml','.config','.ini','.yaml','.yml','.asset','.meta','.props','.html','.js','.ts','.py','.ps1','.bat','.cmd','.csv'}
def sha(p):
    with p.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def save(p,v):
    with p.open('x',encoding='utf-8') as f:json.dump(v,f,indent=2);f.write('\n')
def require(v,msg):
    if not v:raise RuntimeError(msg)

def main():
    names=subprocess.run(['rg','--files','--hidden','--no-ignore','Assets','Packages','ProjectSettings','CompilerSupport'],cwd=PROJECT,capture_output=True,text=True,encoding='utf-8',check=True).stdout.splitlines()
    available={n.replace('\\','/') for n in names}
    selected={}; omitted_json=[]
    def add(n,why):
        require(n in available or n=='SolarNet.Unity2020.props','Missing selected input')
        selected.setdefault(n,set()).add(why)
    for n in sorted(available):
        p=Path(n);suffix=p.suffix.lower()
        if n.startswith(('Assets/Plugins/','Assets/OriginalOpenVR/','Assets/Editor/OriginalMetadataDependencies/')):
            add(n,'complete_required_SDK_plugin_subtree')
        elif n.startswith('CompilerSupport/'):
            add(n,'required_compiler_metadata_or_reference')
        elif n.startswith('ProjectSettings/'):
            add(n,'Unity_project_setting')
        elif n in ('Packages/manifest.json','Packages/packages-lock.json'):
            add(n,'Unity_package_manifest')
        elif n.startswith('Assets/') and suffix in SOURCE_SUFFIXES:
            add(n,'actual_code_or_source_definition')
        elif n.startswith(('Assets/Scripts/','Assets/Editor/')) and suffix=='.json':
            add(n,'source_adjacent_JSON_requires_credential_scan')
        elif n.startswith('Assets/') and suffix=='.json':
            omitted_json.append(n)
    if (PROJECT/'SolarNet.Unity2020.props').is_file():add('SolarNet.Unity2020.props','existing_custom_compiler_property_source')
    # Every retained asset and every retained parent folder keeps its exact GUID meta.
    for n in list(selected):
        if not n.startswith('Assets/') or n.endswith('.meta'):continue
        if n+'.meta' in available:add(n+'.meta','matching_original_asset_meta')
        parent=Path(n).parent
        while parent.as_posix()!='Assets' and parent.as_posix()!='.':
            meta=parent.as_posix()+'.meta'
            require(meta in available,'Missing source parent-folder meta')
            add(meta,'matching_original_parent_folder_meta')
            parent=parent.parent
    rows=[];findings=[];changed=[];counts=Counter();groups=defaultdict(lambda:{'files':0,'bytes':0});unscanned=[]
    for n in sorted(selected):
        p=PROJECT/n
        require(not p.is_symlink(),'Symlink publication input refused')
        before=p.stat();suffix=p.suffix.lower();binary=suffix not in TEXT_SUFFIXES
        row={'path':n,'bytes':before.st_size,'sha256':sha(p),'reasons':sorted(selected[n])};rows.append(row)
        group='/'.join(Path(n).parts[:2]) if n.startswith('Assets/') else Path(n).parts[0]
        groups[group]['files']+=1;groups[group]['bytes']+=before.st_size
        modes={'raw':0}; seen=set()
        # Large bodies are scanned with a bounded8KiB overlap, never interpreted.
        with p.open('rb') as f:
            consumed=0;carry=b''
            while True:
                chunk=f.read(1024*1024)
                if not chunk:break
                data=carry+chunk;start=consumed-len(carry)
                variants=[('raw',data,0)]
                if binary:
                    for encoding,pattern in [('UTF16LE',rb'(?:[\x20-\x7e]\x00){16,4096}'),('UTF16BE',rb'(?:\x00[\x20-\x7e]){16,4096}')]:
                        for m in re.finditer(pattern,data):
                            variants.append((encoding,m.group(0).decode('utf-16-le' if encoding=='UTF16LE' else 'utf-16-be').encode('ascii'),m.start()))
                for encoding,content,offset in variants:
                    for rule,rx in RX.items():
                        for m in rx.finditer(content):
                            byte_offset=start+offset+(m.start()*(2 if encoding!='raw' else 1));key=(rule,byte_offset)
                            if key in seen:continue
                            seen.add(key);counts[rule]+=1
                            findings.append({'path':n,'rule':rule,'encoding':encoding,'byte_offset':byte_offset,'classification':'candidate_context_review_required_no_value_saved'})
                if not binary:
                    for m in GENERIC.finditer(data):
                        value=m.group(1).strip();key=('possible_literal_secret_assignment',start+m.start())
                        if key in seen:continue
                        if value.lower() in {b'password',b'xxxxxxxx',b'your_api_key',b'your-api-key',b'changeme',b'********'} or value.startswith((b'http://',b'https://',b'{',b'{{',b'$(',b'REPLACE_',b'YOUR_')):continue
                        seen.add(key);counts[key[0]]+=1;findings.append({'path':n,'rule':key[0],'encoding':'raw','byte_offset':key[1],'classification':'candidate_context_review_required_no_value_saved'})
                consumed+=len(chunk);carry=data[-8192:]
        after=p.stat()
        if (before.st_size,before.st_mtime_ns)!=(after.st_size,after.st_mtime_ns):changed.append(n)
        if binary and suffix!='.dll':unscanned.append({'path':n,'coverage':'strong_prefix_patterns_raw_ASCII_UTF16_only_no_generic_secret_inference'})
    require(not changed,'Publication source changed during scan')
    sourcefiles=[r for r in rows if Path(r['path']).suffix.lower() in SOURCE_SUFFIXES]
    required_metas=[r for r in rows if r['path'].endswith('.meta')]
    out=BASE/('CodeManifest-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir(parents=True)
    (out/'.gitignore').write_text('*\n!.gitignore\n',encoding='utf-8')
    manifest={'schema':'reviewed-Unity-code-only-publication-inputs/v1','project':str(PROJECT),'status':'pinned_source_inputs_credential_candidates_require_review_no_copy', 'files':rows,'count':len(rows),'bytes':sum(r['bytes'] for r in rows),'exclude_all_unlisted':True,'includes_original_metas':True,'source_modified':False,'copied':False,'remote_mutation':False}
    save(out/'manifest.json',manifest)
    save(out/'credential-candidates-redacted.json',{'findings':findings,'counts':dict(counts),'no_values_saved':True,'limitations':['Pattern matching is not proof of secret absence.','DLL and other binary inputs scan only strong credential-prefix formats in raw ASCII and extracted UTF16; no reflection, load, execution, or native calls.'],'other_binary_coverage':unscanned})
    report={'schema':'read-only-Unity-code-publication-audit/v1','status':'credential_candidates_require_context_review' if findings else 'no_pattern_candidates_source_still_requires_portability_review','manifest':{'path':str(out/'manifest.json'),'sha256':sha(out/'manifest.json')},'files':len(rows),'bytes':manifest['bytes'],'source_file_count':len(sourcefiles),'meta_file_count':len(required_metas),'dll_count':sum(r['path'].lower().endswith('.dll') for r in rows),'groups':dict(sorted(groups.items())),'credential_scan_counts':dict(counts),'credential_candidate_files':len({r['path'] for r in findings}),'credential_scan':{'path':str(out/'credential-candidates-redacted.json'),'sha256':sha(out/'credential-candidates-redacted.json')},'omitted_Assets_JSON_not_known_source_config':omitted_json,'over50MiB':[{'path':r['path'],'bytes':r['bytes']} for r in rows if r['bytes']>50*1024**2],'git_lfs_required_by_per_file_size':any(r['bytes']>100*1024**2 for r in rows),'Unity_game_assets_scenes_art_audio_streaming_assets_remain_local':True,'runtime_complete_or_build_verified_by_publication':False,'source_changes_during_scan':changed,'source_modified':False,'copied':False,'network_or_remote_mutation':False,'absolute_Editor_reference_requires_staging_portability_review':['Assets/Editor/OriginalMetadataRestoration/csc.rsp','SolarNet.Unity2020.props']}
    save(out/'report.json',report)
    print(json.dumps({'report':str(out/'report.json'),'report_sha256':sha(out/'report.json'),'manifest':report['manifest'],'files':len(rows),'bytes':manifest['bytes'],'source_file_count':len(sourcefiles),'meta_file_count':len(required_metas),'candidate_count':len(findings),'candidate_files':report['credential_candidate_files'],'by_rule':dict(counts),'groups':report['groups']}))

if __name__=='__main__':main()
