"""Stage fixed reviewed AOT runner derivative only, never invoke it."""
from pathlib import Path
import hashlib,json
HERE=Path(__file__).resolve().parent
def main():
 source=HERE/'run_reviewed_mono64_core_signature_i18n.py';text=source.read_text();changes={"FOLDER=ROOT/'Validation/Mono64CoreSignatureI18N-20261022T152916Z-f45af857';REVIEW_SHA='8fc397247513bcc50753b01f795716da329bc0ed27563857ee7a0275e6a94c9a'":"FOLDER=ROOT/'Validation/Mono64CoreSignatureAOT-20261022T154205Z-cb91a4de';REVIEW_SHA='fa19177ba3db2dad4bd128f78de5e0fbb6730d1cb6aad4bfd013132d9f314f0b'","str(ROOT/'Validation/Mono64CoreSignature-20261022T151506Z-476ee90a/diagnostic-run-report-r2.json')":"str(ROOT/'Validation/Mono64CoreSignatureI18N-20261022T152916Z-f45af857/diagnostic-run-report-r1.json')"}
 for old,new in changes.items():
  if text.count(old)!=1:raise ValueError('Exact reviewed runner delta not found')
  text=text.replace(old,new)
 target=HERE/'run_reviewed_mono64_core_signature_aot.py'
 if target.exists():raise ValueError('New runner only')
 target.write_text(text);print(json.dumps({'runner':str(target),'sha256':hashlib.sha256(target.read_bytes()).hexdigest(),'source_delta':'Only fixed reviewedfolder/sourceReviewSHA/prior-failure path changed','host_invoked':False}))
if __name__=='__main__':main()
