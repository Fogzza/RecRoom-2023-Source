"""Exact native TMP_Settings product-version getter; not UPM version proof."""
from pathlib import Path
import datetime as dt,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder
from inventory_recroom_game_root_native import region
from prove_container_binding_tail_native import literal

def decode(code,va):
    d=Decoder(code,va);d.literal('48 83 ec 28');flag=d.relative('80 3d','00');skip=d.short('75');usage=d.relative('48 8d 0d');init=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at;loaded=d.relative('48 8b 05');d.literal('48 83 c4 28 c3');d.end()
    need(flag==written and skip==ready and usage==loaded and init==0x1806c01e0 and len(code)==44,'Exact metadata guard/load/ret constant getter')
    return usage

def main():
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Exact original source SHA')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);m=v.find_method('TMPro.TMP_Settings',0x06000355);va=v.method_pointer(m);w=region(v,va);code=bytes.fromhex(w['bytes']);slot=decode(code,va);u=v.usage(slot);need(u['kind']==5,'Exact original string-literal usage');value=literal(v,u['index'])
    controls=[]
    for label,off in [('guard_branch_target',12),('metadata_guard_write',31),('load_constant_slot',34),('stack_restore_size',42)]:
        changed=bytearray(code);changed[off]^=1
        try:decode(bytes(changed),va)
        except (ValueError,struct.error):controls.append({'mutation':label,'offset':off,'rejected':True})
        else:raise ValueError('Incorrect TMP getter mutation accepted')
    out=ROOT/'Validation'/('TMPNativeProductVersion-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    r={'schema':'exact-native-TMP-Settings-product-version-constant/v1','status':'product_version_proved_not_package_version','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'original_method':m,'original_pointer':hex(va),'original_complete44byte_CFG':w,'original_usage':u,'original_literal':value,'unchanged_official_package3_0_6_source_returns_same_product_literal':value['value']=='1.4.0','original_UPM_version_proved':False,'warning':'TMP3.0.6 still returns1.4.0; this getter cannot distinguish the original UPM release','negative_controls':controls,'Main_changed':False,'managed_or_native_game_code_executed':False}
    p=out/'report.json';p.write_text(json.dumps(r,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'product_version':value['value'],'negative_controls':len(controls)}))

if __name__=='__main__':main()
