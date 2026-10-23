"""Diagnostic-only classification, never an equivalence acceptance gate."""
import collections,difflib,hashlib,json
from pathlib import Path
from compare_shader_parsed_form import field_lines
WS=Path(__file__).resolve().parents[3]
OUT=WS/'Recovery/RecRoom-2023-04-18/AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
original=OUT/'Object/ParsedForm.yaml';current=WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_StencilDeferred.asset'
a=field_lines(original,'m_ParsedForm');b=field_lines(current,'m_ParsedForm')
def classify(line):
 # Known scalar presentation differences are exposed separately, not discarded
 # from the strict comparison and not used to authorize a patch.
 return line.rstrip().replace("'<noninit>'",'<noninit>')
x=list(map(classify,a));y=list(map(classify,b));hunks=[]
for op,i,j,k,l in difflib.SequenceMatcher(None,x,y,autojunk=False).get_opcodes():
 if op=='equal':continue
 hunks.append({'operation':op,'original_start_line':i+1,'current_start_line':k+1,'original_lines':a[i:j],'current_lines':b[k:l]})
report={'schema':'shader-parsed-form-difference-classification/v1','status':'parsed_form_differs',
 'strict_comparison':str(OUT/'parsed-form-comparison.json'),
 'diagnostic_scalar_adjustments':['Trailing whitespace','Quotes around exact literal <noninit> only'],
 'diagnostic_classification_is_not_equivalence_acceptance':True,
 'substantive_hunks':hunks,'substantive_hunk_count':len(hunks),
 'five_program_fields_only_repair_accepted':False,
 'next_candidate_scope':'Original full pointer-free ParsedForm plus exact original five program fields, staged only; preserve every other current byte including dependency PPtrs and .meta GUID.',
 'Main_modified':False}
path=OUT/'parsed-form-difference-classification.json';path.write_text(json.dumps(report,indent=2)+'\n')
print(json.dumps({'report':str(path),'substantive_hunk_count':len(hunks),'preview':hunks[:5]}))
