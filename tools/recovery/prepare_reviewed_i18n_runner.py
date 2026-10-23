from pathlib import Path
import ast,hashlib,json
HERE=Path(__file__).resolve().parent
source=HERE/'run_reviewed_mono64_core_signature.py';target=HERE/'run_reviewed_mono64_core_signature_i18n.py';text=source.read_text()
changes=[("Mono64CoreSignature-20261022T151506Z-476ee90a';REVIEW_SHA='f892e8357b7e5602b16a0caffded88f5de475e9846ced6c3b2ba68303019bfbd","Mono64CoreSignatureI18N-20261022T152916Z-f45af857';REVIEW_SHA='8fc397247513bcc50753b01f795716da329bc0ed27563857ee7a0275e6a94c9a"),("suffix='-r2'","suffix='-r1'"),("'prior_compile_only_failure_preserved':str(FOLDER/'diagnostic-run-report.json')","'prior_whitelist_failure_preserved':str(ROOT/'Validation/Mono64CoreSignature-20261022T151506Z-476ee90a/diagnostic-run-report-r2.json')")]
for before,after in changes:
 if text.count(before)!=1:raise ValueError('Exact expected runner fragment changed')
 text=text.replace(before,after)
if target.exists():raise ValueError('Fresh runner required')
ast.parse(text);target.write_text(text);print(json.dumps({'runner':str(target),'sha256':hashlib.sha256(target.read_bytes()).hexdigest(),'only_root_approved_plan_and_fresh_attempt_paths_changed':True}))
