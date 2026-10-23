"""Read-only original Start interface slot, delegate and UI field identities."""
from pathlib import Path
import datetime as dt,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from collect_nameserver_request_factory_native import fields
from collect_title_page_route_native import pin
from inventory_recroom_game_root_native import region
from prove_nameserver_request_factory_cfg import no_chained_entries
INPUT=ROOT/'Validation/TitleStartTypedJoins-20261023T074947Z-228b743e/report.json'
def main():
    need(pin(INPUT)['sha256']=='13d28a4c53718afc9d2c7d484e4ddcb6da54d4152486e4df34eae09920e230ff','Exact complete Start typed inventory')
    p=json.loads(INPUT.read_bytes());s=json.loads(Path(p['original_region_input']['path']).read_bytes());paths=[Path(x['path']) for x in s['original_inputs']]
    for x in s['original_inputs']:need(pin(x['path'])==x,'Original input pin')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);owners={}
        for name in ['CPBPJLLMKDB','DCCDAPLPICN','RecRoom.Core.UI.UIInputModule','JHIKKDDFDGA']:
            ti=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)==name];need(len(ti)==1,'Exact unique original owner '+name);ti=ti[0];td=v.row('typeDefinitions',ti,88);start=v.i32(md,td+36);count=v.u16(md,td+64)
            methods=[]
            if name!='RecRoom.Core.UI.UIInputModule':
                for i in range(start,start+count):
                    m=v.method_info(i);a=v.row('methods',i,32);m['original_virtual_slot']=v.u16(md,a+28);methods.append(m)
            events=[];es=v.i32(md,td+40);ec=v.u16(md,td+70)
            for i in range(es,es+ec):
                a=v.row('events',i,24);events.append({'name':v.string(v.i32(md,a)),'type':v.typename(v.native_type(v.i32(md,a+4))),'add_method':v.method_info(start+v.i32(md,a+8)) if v.i32(md,a+8)>=0 else None,'remove_method':v.method_info(start+v.i32(md,a+12)) if v.i32(md,a+12)>=0 else None,'token':hex(v.u32(md,a+20))})
            owners[name]={'type':v.type_info(ti),'methods':methods,'fields':fields(v,ti),'events':events}
        helpers=[region(v,x) for x in (0x180157240,0x180156f80,0x1801570e0)];chains=no_chained_entries(v,helpers)
    out=ROOT/'Validation'/('TitleStartDispatchJoins-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();target=out/'report.json'
    report={'schema':'original-TitleScreenManager-Start-interface-and-field-joins/v1','complete_caller_typed_inventory':pin(INPUT),'original_owners':owners,'interface_helper_regions':helpers,'no_chained_regions':chains,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'producer':pin(Path(__file__))};target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'report':pin(target),'interfaces':{k:{'methods':[{'name':m['name'],'token':m['token'],'slot':m['original_virtual_slot'],'return':m['return'],'parameters':[x['type'] for x in m['parameters']],'image':m['image']} for m in a['methods']],'events':a['events']} for k,a in owners.items() if k!='RecRoom.Core.UI.UIInputModule'},'UI_fields':[x for x in owners['RecRoom.Core.UI.UIInputModule']['fields'] if x['offset'] in (0,136)],'helper_regions':helpers}))
if __name__=='__main__':main()
