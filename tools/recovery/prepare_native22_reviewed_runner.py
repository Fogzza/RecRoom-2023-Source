"""Create fixed reviewed Native22 diagnostic runner; no invocation."""
from pathlib import Path
import hashlib,json
HERE=Path(__file__).resolve().parent
def main():
 source=HERE/'run_reviewed_mono64_core_signature_aot.py';text=source.read_text();changes={"FOLDER=ROOT/'Validation/Mono64CoreSignatureAOT-20261022T154205Z-cb91a4de';REVIEW_SHA='fa19177ba3db2dad4bd128f78de5e0fbb6730d1cb6aad4bfd013132d9f314f0b'":"FOLDER=ROOT/'Validation/Mono64Native22CoreSignatures-20261022T161129Z-eb2619a1';REVIEW_SHA='24d8c075827a1da99d2503da9a325b96759003b981b3925ab0719e122c363ce4'","str(ROOT/'Validation/Mono64CoreSignatureI18N-20261022T152916Z-f45af857/diagnostic-run-report-r1.json')":"str(ROOT/'Validation/Mono64CoreSignatureAOT-20261022T154205Z-cb91a4de/diagnostic-run-report-r1.json')"}
 for old,new in changes.items():
  if text.count(old)!=1:raise ValueError('Exact reviewed runner delta missing')
  text=text.replace(old,new)
 target=HERE/'run_reviewed_mono64_core_signature_native22.py'
 if target.exists():raise ValueError('Fresh runner only')
 target.write_text(text);print(json.dumps({'runner':str(target),'sha256':hashlib.sha256(target.read_bytes()).hexdigest(),'invoked':False}))
if __name__=='__main__':main()
