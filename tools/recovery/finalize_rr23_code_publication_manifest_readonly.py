"""Freeze additive SDK closure and reviewed symbolic-label scan findings."""
from pathlib import Path
from collections import defaultdict
import datetime as dt, hashlib, json, re, uuid
import prepare_rr23_code_publication_manifest_readonly as scan

BASE=scan.BASE/'CodeManifest-20261023T051544Z-0676fc11'
SIZE=scan.BASE/'Sizes-20261023T050941Z-fd30f20e/report.json'
def main():
    scan.require(scan.sha(BASE/'manifest.json')=='dd7097445ff0f1def53f56b0e3d5a19e235ad700206f7783e84b6722808f4456','Frozen first scan changed')
    scan.require(scan.sha(BASE/'report.json')=='71085e314af55d387e1b40f12818cebc1a950870bb349651bee403e381742167','Frozen first report changed')
    scan.require(scan.sha(SIZE)=='b5b7a506031213590ea8e60dfd45b8bd58a9a96dcce8a3034fe2d274325f9de4','Frozen source-size inventory changed')
    prior=json.loads((BASE/'manifest.json').read_bytes());oldreport=json.loads((BASE/'report.json').read_bytes());candidates=json.loads((BASE/'credential-candidates-redacted.json').read_bytes())
    rows={r['path']:r for r in prior['files']};available={r['path'] for r in json.loads(SIZE.read_bytes())['source_files']}
    added={n for n in available if n.startswith(('Assets/OriginalOpenVR/','Assets/Editor/OriginalMetadataDependencies/'))}
    for n in list(added):
        p=Path(n).parent
        while p.as_posix() not in ('Assets','.'):
            if p.as_posix()+'.meta' in available:added.add(p.as_posix()+'.meta')
            p=p.parent
    added_findings=[];actually_added=[]
    for n in sorted(added-set(rows)):
        p=scan.PROJECT/n;before=p.stat();data=p.read_bytes()
        variants=[('raw',data,0)]
        for encoding,pat in [('UTF16LE',rb'(?:[\x20-\x7e]\x00){16,4096}'),('UTF16BE',rb'(?:\x00[\x20-\x7e]){16,4096}')]:
            for m in re.finditer(pat,data):variants.append((encoding,m.group(0).decode('utf-16-le' if encoding=='UTF16LE' else 'utf-16-be').encode('ascii'),m.start()))
        for encoding,content,offset in variants:
            for rule,rx in scan.RX.items():
                for m in rx.finditer(content):added_findings.append({'path':n,'rule':rule,'encoding':encoding,'no_value_saved':True})
        if p.suffix.lower() in scan.TEXT_SUFFIXES:
            for m in scan.GENERIC.finditer(data):added_findings.append({'path':n,'rule':'possible_literal_secret_assignment','encoding':'raw','no_value_saved':True})
        after=p.stat();scan.require((before.st_size,before.st_mtime_ns)==(after.st_size,after.st_mtime_ns),'Added SDK source changed during scan')
        rows[n]={'path':n,'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest(),'reasons':['required_existing_SDK_dependency_outside_Plugins' if not n.endswith('.meta') else 'matching_original_SDK_asset_or_folder_meta']};actually_added.append(n)
    scan.require(not added_findings,'Additional SDK credential prefix requires review')
    # Review exact two findings using structural equalities; never save literals.
    review=[]
    expected={
        'Assets/Scripts/Assembly-CSharp/TitleScreenManager.cs':('RESET_PASSWORD','symbolic_password_reset_label'),
        'Assets/Scripts/Assembly-CSharp/RRUI/Data/TitleScreenFlowModel.cs':('PASSWORD_BYPASS_ARG_PREFIX','symbolic_named_commandline_argument_prefix'),
    }
    scan.require(len(candidates['findings'])==2 and {r['path'] for r in candidates['findings']}==set(expected),'Unexpected candidate set')
    norm=lambda s:re.sub('[^A-Za-z0-9]','',s).lower()
    for path,(identifier,classification) in expected.items():
        p=scan.PROJECT/path;scan.require(scan.sha(p)==rows[path]['sha256'],'Reviewed candidate source changed')
        text=p.read_text(encoding='utf-8');m=re.search(r'public const string '+identifier+r'\s*=\s*"([^"\r\n]*)"\s*;',text);scan.require(m is not None,'Exact public symbolic constant required')
        literal=m.group(1)
        if identifier=='RESET_PASSWORD':ok=norm(literal)==norm('_'.join(reversed(identifier.split('_'))))
        else:ok=bool(re.fullmatch(r'\+[A-Za-z_]+:',literal)) and norm(identifier.split('_BYPASS_ARG_PREFIX')[0]) in norm(literal)
        scan.require(ok,'Candidate is not the exact symbolic label/marker shape')
        review.append({'path':path,'rule':'possible_literal_secret_assignment','classification':classification,'actual_credential':False,'exact_structural_constant_comparison_passed':True,'value_never_saved_or_printed':True})
    # Include every original matching meta and every retained folder meta.
    for n in rows:
        if not n.startswith('Assets/') or n.endswith('.meta'):continue
        if n+'.meta' in available:scan.require(n+'.meta' in rows,'Missing matching original file meta')
        p=Path(n).parent
        while p.as_posix() not in ('Assets','.'):
            meta=p.as_posix()+'.meta';scan.require(meta in available and meta in rows,'Missing original folder meta');p=p.parent
    forbidden=[];config_candidates=[]
    for n,row in rows.items():
        scan.require(not Path(n).is_absolute() and '..' not in Path(n).parts,'Nonrelative publication path')
        if n.endswith('.unity') or n.startswith(('Library/','Temp/','Logs/','UserSettings/','.vs/','Assets/StreamingAssets/','Assets/Texture2D/','Assets/AudioClip/')):forbidden.append(n)
        if not n.startswith('ProjectSettings/') and n not in ('Packages/manifest.json','Packages/packages-lock.json'):continue
        p=scan.PROJECT/n;scan.require(scan.sha(p)==row['sha256'],'Settings/package config changed')
        for number,line in enumerate(p.read_text(encoding='utf-8',errors='replace').splitlines(),1):
            m=re.match(r'\s*([A-Za-z_][A-Za-z0-9_]*(?:password|passwd|secret|access_?token|refresh_?token|private_?key|signing_?key)[A-Za-z0-9_]*)\s*:\s*(.*?)\s*$',line,re.I)
            if m and m.group(2).strip('"\x27 ') not in ('','0','false','False','{}','[]'):config_candidates.append({'path':n,'rule':'nonempty_credential_named_YAML_setting','line':number,'no_value_saved':True})
    scan.require(not forbidden and not config_candidates,'Unexpected excluded asset or credential-named settings require review')
    final=sorted(rows.values(),key=lambda r:r['path']);groups=defaultdict(lambda:{'files':0,'bytes':0})
    for r in final:
        group='/'.join(Path(r['path']).parts[:2]) if r['path'].startswith('Assets/') else Path(r['path']).parts[0];groups[group]['files']+=1;groups[group]['bytes']+=r['bytes']
    out=scan.BASE/('CodeManifestFinal-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir(parents=True);(out/'.gitignore').write_text('*\n!.gitignore\n',encoding='utf-8')
    manifest={'schema':'reviewed-Unity-code-only-publication-inputs/v1','project':str(scan.PROJECT),'status':'code_only_inputs_pinned_credential_candidates_reviewed_no_copy','files':final,'count':len(final),'bytes':sum(r['bytes'] for r in final),'exclude_all_unlisted':True,'includes_original_metas':True,'source_modified':False,'copied':False,'remote_mutation':False}
    scan.save(out/'manifest.json',manifest)
    scan.save(out/'credential-review-redacted.json',{'schema':'credential-pattern-candidate-context-review/v1','prior_scan':oldreport['credential_scan'],'initial_generic_candidates':2,'reviewed_symbolic_noncredential_candidates':review,'additional_SDK_prefix_candidates':added_findings,'nonempty_credential_named_setting_candidates':config_candidates,'unresolved_detected_candidates':0,'no_secret_values_saved_or_printed':True,'limitations':candidates['limitations']})
    report={'schema':'final-reviewed-Unity-code-only-publication-inventory/v1','status':'ready_for_Root_manifest_only_copy_NO_COPY_OR_PUSH_PERFORMED','manifest':{'path':str(out/'manifest.json'),'sha256':scan.sha(out/'manifest.json')},'files':len(final),'bytes':manifest['bytes'],'source_files':sum(Path(r['path']).suffix.lower() in scan.SOURCE_SUFFIXES for r in final),'meta_files':sum(r['path'].endswith('.meta') for r in final),'dll_files':sum(r['path'].lower().endswith('.dll') for r in final),'groups':dict(sorted(groups.items())),'additive_existing_required_SDK_inputs':actually_added,'credential_review':{'path':str(out/'credential-review-redacted.json'),'sha256':scan.sha(out/'credential-review-redacted.json')},'all_source_and_parent_folder_metas_included':True,'unresolved_detected_credential_candidates':0,'initial_generic_candidates_resolved_as_symbolic_labels':2,'strong_prefix_credential_candidates':0,'all_approved_actual_source_suffixes_included':True,'no_source_file_over50MiB':all(r['bytes']<=50*1024**2 for r in final),'no_LFS_required_by_per_file_size':all(r['bytes']<=100*1024**2 for r in final),'paid_LFS_or_storage_actions':False,'source_preparer':{'path':str(Path(scan.__file__).resolve()),'sha256':scan.sha(Path(scan.__file__))},'finalizer':{'path':str(Path(__file__).resolve()),'sha256':scan.sha(Path(__file__))},'prior_complete_targeted_scan':{'path':str(BASE/'report.json'),'sha256':scan.sha(BASE/'report.json')},'copy_instructions':'Copy only manifest.files rows relative to project; rehash every source and destination before commit; fresh staging repository only, no existing LunarNet history.','known_portability_issues':['Assets/Editor/OriginalMetadataRestoration/csc.rsp contains a local absolute UnityEditor reference','SolarNet.Unity2020.props expects local Editor/runtime layout'],'README_required_limitations':['Source-only snapshot; scene/art/audio/StreamingAssets and other game assets remain local.','Many recovered runtime method bodies remain stubs; no playable client or successful full game build claim.','Original compiled Shader assets remain local; no new Shader source recovery claim.'],'project_modified':False,'project_copied':False,'network_or_remote_mutation':False}
    scan.save(out/'report.json',report)
    print(json.dumps({'report':str(out/'report.json'),'sha256':scan.sha(out/'report.json'),'manifest':report['manifest'],'files':len(final),'bytes':manifest['bytes'],'source_files':report['source_files'],'meta_files':report['meta_files'],'dll_files':report['dll_files'],'strong_prefix_candidates':0,'unresolved_candidates':0,'groups':report['groups']}))
if __name__=='__main__':main()
