"""Read PE export names as data; never load or invoke native libraries."""
from pathlib import Path
import hashlib,json,struct,sys,collections
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
def need(b,s):
 if not b:raise ValueError(s)
def sha(path):return hashlib.sha256(Path(path).read_bytes()).hexdigest()
def exports(path):
 b=Path(path).read_bytes();need(b[:2]==b'MZ','Not PE');pe=struct.unpack_from('<I',b,60)[0];need(b[pe:pe+4]==b'PE\0\0','Invalid PE');machine,nsections=struct.unpack_from('<HH',b,pe+4);opt=pe+24;magic=struct.unpack_from('<H',b,opt)[0];need(machine==0x8664 and magic==0x20b,'Expected original/current AMD64 native library');sizeopt=struct.unpack_from('<H',b,pe+20)[0];sections=[]
 for n in range(nsections):
  at=opt+sizeopt+n*40;_,rva,size,start=struct.unpack_from('<IIII',b,at+8);need(start+size<=len(b),'Unbacked section');sections.append((rva,size,start))
 def raw(rva,size):
  values=[start+rva-base for base,length,start in sections if base<=rva and rva+size<=base+length];need(len(values)==1,'Export RVA unbacked/ambiguous');return values[0]
 def cstr(rva):
  start=raw(rva,1);end=b.find(b'\0',start,min(start+1024,len(b)));need(end>=0,'Bounded export string required');return b[start:end].decode('ascii')
 rva,size=struct.unpack_from('<II',b,opt+112);need(rva and 40<=size<=4*1024*1024,'Bounded export directory required');at=raw(rva,40);_,_,_,_,_,base,nfun,nnames,ft,nt,ot=struct.unpack_from('<IIHHIIIIIII',b,at);need(nnames<=65536 and nfun<=131072,'Export count bound');result={}
 for n in range(nnames):
  name=cstr(struct.unpack_from('<I',b,raw(nt+n*4,4))[0]);ordinal=struct.unpack_from('<H',b,raw(ot+n*2,2))[0];need(ordinal<nfun and name not in result,'Export ordinal/name ambiguity');address=struct.unpack_from('<I',b,raw(ft+ordinal*4,4))[0];result[name]={'rva':hex(address),'ordinal':base+ordinal,'forwarder':cstr(address) if rva<=address<rva+size else None}
 return result
def main():
 proof=Path(sys.argv[1]);out=Path(sys.argv[2]);need(not out.exists(),'Fresh output required');d=json.loads(proof.read_text());need(d['proven_count']==846 and not d['unresolved'],'Complete native binding evidence prerequisite')
 verification=ROOT/'Verification/Source-20261022T005137Z-c3395374.json';verified=json.loads(verification.read_text());need(verified['file_count']==7103 and verified['all_public_hashes_match'],'Verified original source inventory required');native_entries=collections.defaultdict(list)
 for r in verified['files']:
  if r['path'].lower().endswith('.dll'):native_entries[Path(r['path']).name.casefold()].append(r)
 grouped=collections.defaultdict(list)
 for r in d['methods']:grouped[r['effective_binding']['module']['value']].append(r)
 rows=[]
 for module,methods in sorted(grouped.items()):
  filename=module if module.lower().endswith('.dll') else module+'.dll';matches=native_entries.get(filename.casefold(),[]);need(len(matches)<=1,'Original native DLL basename is ambiguous');entry=matches[0] if matches else None;path=None;status='not_present_in_verified_Windows_client_inventory'
  if entry:
   path=Path(verified['source'])/entry['path'];need(sha(path)==entry['sha256'],'Original native vendor bytes differ');status='original_vendor_DLL_verified_archive_hash'
  elif module.lower() in ('kernel32.dll','psapi.dll','user32.dll','setupapi.dll','wintrust.dll'):
   path=Path('C:/Windows/System32')/module;need(path.is_file(),'Current OS dependency not found');status='current_PC_OS_export_check_only_not_original_2023_OS_proof'
  if path:
   table=exports(path);matched=[];unmatched=[]
   for m in methods:
    binding=m['effective_binding'];name=binding['entry_point']['value'];candidates=[name]
    if not binding['is_no_mangle']:
     if binding['char_set']['native_name']=='CHARSET_UNICODE':candidates=[name+'W',name]
     else:candidates=[name,name+'A']
    found=next((n for n in candidates if n in table),None);row={'native_method_token':m['original']['token'],'owner':m['original']['owner'],'method':m['original']['name'],'literal_entry':name,'candidate_names':candidates,'matched_export':found,'export':table.get(found)}
    (matched if found else unmatched).append(row)
   rows.append({'module':module,'status':status,'path':str(path),'sha256':sha(path),'original_verification_row':entry,'export_count':len(table),'requested_bindings':len(methods),'matched':matched,'unmatched':unmatched,'library_loaded_or_invoked':False})
  else:rows.append({'module':module,'status':status,'requested_bindings':len(methods),'original_entry_names':[m['effective_binding']['entry_point']['value'] for m in methods],'not_a_new_global_runtime_requirement':True,'note':'An import can be unused or platform-gated in the original client. No library is invented/downloaded/enabled and original platform paths remain unchanged.'})
 report={'schema':'original-effective-import-native-dependency-export-audit/v1','binding_proof':{'path':str(proof),'sha256':sha(proof)},'original_source_verification':{'path':str(verification),'sha256':sha(verification)},'tool':{'path':str(Path(__file__).resolve()),'sha256':sha(Path(__file__))},'modules':rows,'matching_policy':'AMD64 exact name then matching Unity charset suffix candidates; data-only availability check, not ABI/callability or original Mono ImplMap restoration. Forwarders retained as evidence.','game_code_executed':False,'native_libraries_loaded_or_invoked':False,'project_modified':False};out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'modules':[{k:r.get(k) for k in ('module','status','requested_bindings','export_count')}|({'matched':len(r['matched']),'unmatched':len(r['unmatched'])} if 'matched' in r else {}) for r in rows]}))
if __name__=='__main__':main()
