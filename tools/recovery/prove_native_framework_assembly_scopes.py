"""Independent original v27.1 AssemblyName+TypeDef witness for scope reversal."""
from pathlib import Path
import datetime as dt,hashlib,importlib.util,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'));from native_metadata import NativeMetadata
SCOPE=ROOT/'Validation/CoreTypeRefAssemblyScopes-20261022T154753Z-eab50e94/report.json'
SOURCE=HERE.parent/'Cpp2IL-development-b5ad444b-SSAEvidence/Source/Cpp2IL-b5ad444b82267cb1e4b88b8b373c008105bdea52/LibCpp2IL/Metadata'
def need(x,s):
 if not x:raise ValueError(s)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def main():
 need(sha(SCOPE)=='a5e6a61bbae1471141919ed23697b6f9e7a3cb82be7a5dacfc7d4973fc47184c','Pinned scope witness');scope=json.loads(SCOPE.read_text());binary=ROOT/'CodeSource/GameAssembly.dll';meta=ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat';pins={binary:'ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b',meta:'1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474'}
 for p,d in pins.items():need(sha(p)==d,'Original input hash')
 with binary.open('rb') as bf,meta.open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as d:
  v=NativeMetadata(b,d);need(v.count('assemblies',64)==279,'Exact original AssemblyDef64 count');assemblies={}
  for i in range(279):
   at=v.row('assemblies',i,64);image,token,start,count=struct.unpack_from('<iIii',d,at);an=at+16;ni,ci,pi,alg,hlen,flags,major,minor,build,revision=struct.unpack_from('<iiiIiIiiii',d,an);name=v.string(ni);culture=v.string(ci);pkt=bytes(d[an+40:an+48]).hex();full=name+', Version='+'.'.join(map(str,[major,minor,build,revision]))+', Culture='+(culture or 'neutral')+', PublicKeyToken='+(pkt if int(pkt,16) else 'null');need(v.images[image]['name']==name+'.dll','Native Assembly/image name join');assemblies[name]={'index':i,'native_token':hex(token),'image_index':image,'full_name':full,'row_bytes':bytes(d[at:at+64]).hex(),'flags':flags,'public_key_index':pi,'referenced_start':start,'referenced_count':count}
  rows=[]
  for item in scope['scope_mismatches']:
   full=item['original_scope'];name=full.split(',')[0];a=assemblies[name];need(a['full_name']==full,'Native full AssemblyName differs');image=v.images[a['image_index']];hits=[i for i in range(image['start'],image['start']+image['count']) if v.full_name(i)==item['actual']['name']];need(len(hits)==1,'Unique native scoped TypeDef');rows.append({'current_TypeRef':item['actual'],'original_raw_TypeRef_tokens':item['original_reference_tokens'],'native_assembly':a,'native_type':v.type_info(hits[0])})
  need(len(rows)==22,'Exact22 native scope witnesses');core=assemblies['Assembly-CSharp'];refids=[struct.unpack_from('<i',d,v.row('referencedAssemblies',core['referenced_start']+i,4))[0] for i in range(core['referenced_count'])];need(all(assemblies[n]['index'] in refids for n in ['System','System.Core']),'Originalcore reference list lacks framework images')
 for p,digest in pins.items():need(sha(p)==digest,'Native evidence input changed')
 out=ROOT/'Validation'/('NativeFrameworkAssemblyScopes-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();r=out/'report.json';report={'schema':'original-native-v27-assemblyname-and-typedef-scope-witness/v1','status':'all22_exact_native_scopes_proven','inputs':[{'path':str(p),'sha256':s} for p,s in pins.items()],'layouts':[{'path':str(SOURCE/n),'sha256':sha(SOURCE/n)} for n in ['Il2CppAssemblyDefinition.cs','Il2CppAssemblyNameDefinition.cs']],'source_scope_audit':{'path':str(SCOPE),'sha256':sha(SCOPE)},'native_Assembly_row_size':64,'native_assembly_count':279,'native_core_references_both_framework_images':True,'rows':rows,'original_game_or_managed_code_invoked':False,'project_modified':False};r.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(r),'sha256':sha(r),'native_scope_witnesses':len(rows)}))
if __name__=='__main__':main()
