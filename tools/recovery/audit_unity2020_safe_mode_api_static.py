"""Read matching Editor CLI definitions for SafeMode/import control APIs only."""
from pathlib import Path
import datetime as dt,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE))
from audit_cli_marshal_contracts import Cli,need
from audit_accessor_error_projection_static import sha

def audit(path):
    methods=[];types=[]
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b);owners=[];parent={}
        for rid in range(1,c.rows[2]+1):
            at=c.row(2,rid);name=c.string(c.value(at+4,c.strw));ns=c.string(c.value(at+4+c.strw,c.strw));start=c.value(at+4+2*c.strw+c.coded(2,[2,1,27])+c.index(4),c.index(6));owners.append({'rid':rid,'name':name,'ns':ns,'start':start,'flags':c.u32(at)})
        for rid in range(1,c.rows[41]+1):
            at=c.row(41,rid);parent[c.value(at,c.index(2))]=c.value(at+c.index(2),c.index(2))
        def fullname(rid):
            r=owners[rid-1];return fullname(parent[rid])+'/'+r['name'] if rid in parent else (r['ns']+'.' if r['ns'] else '')+r['name']
        control_owners={'UnityEditor.EditorApplication','UnityEditor.EditorUtility','UnityEditor.AssetDatabase','UnityEditor.AssetDatabaseExperimental','UnityEditor.Experimental.AssetDatabaseExperimental'}
        for t in owners:
            owner=fullname(t['rid']);safe_type='safemode' in owner.casefold();end=owners[t['rid']]['start'] if t['rid']<len(owners) else c.rows[6]+1
            if safe_type:types.append({'name':owner,'token':hex(0x02000000|t['rid']),'flags':t['flags']})
            for rid in range(t['start'],end):
                at=c.row(6,rid);name=c.string(c.value(at+8,c.strw));lookup=name.casefold()
                selected=safe_type or 'safemode' in lookup or (owner in control_owners and any(s in lookup for s in ('requestscriptreload','refresh','assetediting','updating','import','reloading','reloadassembl')))
                if not selected:continue
                rva=c.u32(at);sig=c.blob(c.value(at+8+c.strw,c.blobw));body=None
                if rva:
                    raw=c.raw(rva,1);lead=b[raw]
                    if lead&3==2:size=lead>>2;start=c.raw(rva+1,size)
                    else:need(lead&3==3,'Known IL header');head=(c.u16(raw)>>12)*4;size=c.u32(raw+4);start=c.raw(rva+head,size)
                    need(size<=65536,'Bounded Editor method');body=bytes(b[start:start+size]).hex()
                methods.append({'owner':owner,'name':name,'token':hex(0x06000000|rid),'flags':c.u16(at+6),'impl_flags':c.u16(at+4),'signature_blob':sig.hex(),'is_public':(c.u16(at+6)&7)==6,'is_static':bool(c.u16(at+6)&16),'RVA':rva,'IL_hex':body})
    return {'path':str(path),'sha256':sha(path),'SafeMode_named_types':types,'selected_methods':methods}

def main():
    editor=WS/'Tools/Editors/2020.3.33f1/Editor/Data/Managed';paths=[editor/'UnityEditor.dll',editor/'UnityEngine/UnityEditor.CoreModule.dll'];results=[audit(p) for p in paths]
    out=ROOT/'Validation'/('Unity2020SafeModeAPI-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'exact-matching-2020-Editor-SafeMode-and-import-API-definitions/v1','status':'metadata_only_API_inventory_no_Editor_invocation','editor_version':'2020.3.33f1','assemblies':results,'main_or_preferences_or_Editor_changed':False,'CLR_or_native_Editor_method_invoked':False,'API_presence_does_not_prove_can_run_before_initial_import':True}
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'safe_types':[t for r in results for t in r['SafeMode_named_types']],'methods':[{'owner':m['owner'],'name':m['name'],'public':m['is_public'],'sig':m['signature_blob'],'impl':m['impl_flags']} for r in results for m in r['selected_methods']]}))

if __name__=='__main__':main()
