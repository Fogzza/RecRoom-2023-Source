"""Pin final production core review in a fresh copy of the approved runner."""
from pathlib import Path
import hashlib,json
HERE=Path(__file__).resolve().parent
def main():
 source=HERE/'run_reviewed_mono64_core_signature_native22.py';text=source.read_text();old="FOLDER=ROOT/'Validation/Mono64Native22CoreSignatures-20261022T161129Z-eb2619a1';REVIEW_SHA='24d8c075827a1da99d2503da9a325b96759003b981b3925ab0719e122c363ce4'";new="FOLDER=ROOT/'Validation/Mono64Native22CoreSignatures-20261022T162544Z-b62af215';REVIEW_SHA='da6ad120b69f6ae96e970fee6feb9d06d514d1dba6073cd8fcdfac74d70f411a'"
 if text.count(old)!=1:raise ValueError('Exact runnerdelta')
 text=text.replace(old,new);target=HERE/'run_reviewed_mono64_core_signature_final.py'
 if target.exists():raise ValueError('Fresh fixed runneronly')
 target.write_text(text);print(json.dumps({'runner':str(target),'sha256':hashlib.sha256(target.read_bytes()).hexdigest(),'invoked':False}))
if __name__=='__main__':main()
