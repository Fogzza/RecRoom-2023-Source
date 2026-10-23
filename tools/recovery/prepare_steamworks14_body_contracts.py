"""Pinned native SDK14 contracts for a source-body proposal; never execute code."""
from pathlib import Path
import datetime as dt, hashlib, json, mmap, struct, sys, uuid
HERE=Path(__file__).resolve().parent; WS=HERE.parents[2]; ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from native_metadata import NativeMetadata
from audit_forwarding import EXPECTED,sha
from audit_official_sdk_native_identity import shape


def main():
    paths=[ROOT/'CodeSource'/x for x in EXPECTED]
    for p in paths:
        if sha(p)!=EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()]: raise ValueError('Original input changed')
    out=ROOT/'Validation'/('Steamworks14NativeBodyContracts-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    with paths[0].open('rb')as f, paths[1].open('rb')as g, mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ)as b, mmap.mmap(g.fileno(),0,access=mmap.ACCESS_READ)as m:
        v=NativeMetadata(b,m);types=[];failures=[]
        for ti in range(v.count('typeDefinitions',88)):
            owner=v.full_name(ti)
            if not owner.startswith('Steamworks.'):continue
            a=v.row('typeDefinitions',ti,88)
            if v.image_of_type(ti)['name']!='Assembly-CSharp.dll':raise ValueError('SDK namespace belongs to unexpected original image')
            parent=v.i32(m,a+16);gc=v.i32(m,a+24);ifirst=v.i32(m,a+52)
            row={'owner':owner,'native_type_token':hex(v.u32(m,a+84)),'native_type_index':ti,'flags':v.u32(m,a+28),'bitfield':v.u32(m,a+80),'generic_arity':v.i32(m,v.row('genericContainers',gc,16)+4)if gc>=0 else 0,'base_type':shape(v,v.native_type(parent))if parent>=0 else None,'interfaces':[shape(v,v.native_type(v.i32(m,v.row('interfaces',ifirst+i,4))))for i in range(v.u16(m,a+76))],'fields':[],'methods':[]}
            first=v.i32(m,a+32)
            for fi in range(first,first+v.u16(m,a+68)):
                fa=v.row('fields',fi,12);ft=v.native_type(v.i32(m,fa+4))
                try: fs=shape(v,ft)
                except ValueError as e:fs=None;failures.append({'owner':owner,'field_index':fi,'reason':str(e)})
                row['fields'].append({'name':v.string(v.i32(m,fa)),'type':fs,'flags':ft['attributes'],'native_field_token':hex(v.u32(m,fa+8)),'native_field_index':fi})
            first=v.i32(m,a+36)
            for mi in range(first,first+v.u16(m,a+64)):
                ma=v.row('methods',mi,32);pc=v.u16(m,ma+30);ps=v.i32(m,ma+12);gc=v.i32(m,ma+16);ga=v.i32(m,v.row('genericContainers',gc,16)+4)if gc>=0 else 0
                pars=[v.native_type(v.i32(m,v.row('parameters',ps+i,12)+8))for i in range(pc)];rt=v.native_type(v.i32(m,ma+8));name=v.string(v.i32(m,ma))
                try: sig=name+'``'+str(ga)+'('+','.join(shape(v,p)for p in pars)+')->'+shape(v,rt)
                except ValueError as e:sig=None;failures.append({'owner':owner,'method_index':mi,'reason':str(e)})
                row['methods'].append({'name':name,'signature':sig,'flags':v.u16(m,ma+24),'impl_flags':v.u16(m,ma+26),'parameter_flags':[p['attributes']for p in pars],'parameter_names':[v.string(v.i32(m,v.row('parameters',ps+i,12)))for i in range(pc)],'return_flags':rt['attributes'],'native_method_token':hex(v.u32(m,ma+20)),'native_method_index':mi,'pointer':hex(v.method_pointer({'token':hex(v.u32(m,ma+20)),'image':'Assembly-CSharp.dll'}))if not ga and sig else None})
            types.append(row)
    report={'schema':'native-steamworks14-source-body-contracts/v1','status':'native-contracts-staged-no-source-body-accepted','native_assembly':'Assembly-CSharp','types':types,'unsupported_shapes':failures,'input':[{'path':str(p),'sha256':sha(p)}for p in paths+[Path(__file__).resolve()]],'project_modified':False,'SDK_or_game_code_executed':False}
    (out/'native-contracts.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'path':str(out/'native-contracts.json'),'types':len(types),'methods':sum(len(t['methods'])for t in types),'unsupported':len(failures)}))


if __name__=='__main__':main()
