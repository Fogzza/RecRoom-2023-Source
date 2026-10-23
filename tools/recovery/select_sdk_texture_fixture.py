"""Select/prove one original tiny script-free texture bundle as inert data."""
from pathlib import Path
from datetime import datetime, timezone
import hashlib
import importlib.util
import json
import struct
import uuid

HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
INV=ROOT/'BundleInventory/Run-20261022T005620Z-05f26ec1'
RAW=ROOT/'RawUnityFSRecovery/VerifiedAll-20261022T133109Z-2e17e8f8'
CONTAINERS=ROOT/'AddressablesAudit/Run-20261022T013413Z-e0b9b83a/bundle-containers.json'


def sha(path):
    with path.open('rb') as stream:return hashlib.file_digest(stream,'sha256').hexdigest()


def texture_prefix(path, expected_path):
    if path.stat().st_size>1024*1024:raise ValueError('Tiny serialized node required')
    data=path.read_bytes();version=struct.unpack_from('>I',data,8)[0]
    if version!=22 or data[16]!=0:raise ValueError('Exact Unity2020 little-endian v22 node required')
    meta_size=struct.unpack_from('>I',data,20)[0];data_start=struct.unpack_from('>Q',data,32)[0]
    if meta_size>512*1024:raise ValueError('Bounded metadata required')
    meta=data[48:48+meta_size];pos=0
    def read(fmt):
        nonlocal pos
        value=struct.unpack_from('<'+fmt,meta,pos);pos+=struct.calcsize('<'+fmt);return value[0] if len(value)==1 else value
    def text():
        nonlocal pos
        end=meta.index(0,pos);value=meta[pos:end].decode();pos=end+1;return value
    engine=text();platform=read('i');has_tree=read('B');count=read('i')
    if engine!='2020.3.33f1' or platform!=19 or not has_tree or not 1<=count<=4:raise ValueError('Unexpected texture metadata header')
    trees=[];ids=[];common={49:'Array',55:'Base',81:'char',106:'data',222:'int',427:'m_Name',795:'size',814:'SInt64',840:'string',921:'UInt64',928:'UInt8',981:'vector'}
    for _ in range(count):
        cid=read('i');ids.append(cid);read('B');read('h');pos+=16
        nodes=read('i');strings=read('i');start=pos;buffer=meta[start+nodes*32:start+nodes*32+strings]
        if not 0<nodes<512 or not 0<=strings<65536:raise ValueError('Unexpected type tree bound')
        def resolve(offset):
            if offset&0x80000000:return common.get(offset&0x7fffffff,'common:'+str(offset&0x7fffffff))
            end=buffer.index(0,offset);return buffer[offset:end].decode()
        rows=[]
        for i in range(nodes):
            row=struct.unpack_from('<HBBIIiiI',meta,start+i*32);rows.append({'level':row[1],'type':resolve(row[3]),'name':resolve(row[4]),'size':row[5],'flags':row[7]})
        trees.append(rows);pos+=nodes*32+strings;deps=read('i');pos+=deps*4
    if set(ids)!={28,142}:raise ValueError('Texture fixture must contain exactly Texture2D and AssetBundle classes')
    count=read('i');objects=[]
    for _ in range(count):
        pos=(pos+3)&~3;pid=read('q');off=read('q');size=read('I');ti=read('i');objects.append({'path_id':pid,'offset':data_start+off,'size':size,'class_id':ids[ti],'tree':trees[ti]})
    if read('i')!=0:raise ValueError('No script identifier table allowed')
    if read('i')!=0:raise ValueError('No serialized external/CAB dependency allowed')
    targets=[o for o in objects if o['class_id']==28 and o['path_id']==expected_path]
    if len(targets)!=1:raise ValueError('Unique exact container Texture2D required')
    obj=targets[0];at=obj['offset'];fields=[];values={}
    for node in obj['tree'][1:]:
        if node['level']!=1:continue
        before=at
        if node['type']=='string':
            size=struct.unpack_from('<i',data,at)[0]
            if not 0<=size<4096:raise ValueError('Texture name bounds')
            values[node['name']]=data[at+4:at+4+size].decode();at=(at+4+size+3)&~3
        elif node['size'] in (1,2,4,8):
            values[node['name']]=int.from_bytes(data[at:at+node['size']],'little',signed=True);at+=node['size']
        else:raise ValueError('Unsupported pre-dimension texture field '+node['name'])
        if node['flags']&0x4000:at=(at+3)&~3
        fields.append({**node,'file_offset':before,'value':values[node['name']]})
        if 'm_Width' in values and 'm_Height' in values:break
    if not {'m_Name','m_Width','m_Height'}<=values.keys() or not 1<=values['m_Width']<=4096 or not 1<=values['m_Height']<=4096:raise ValueError('Dimensions/name not proven by original type tree')
    return {'name':values['m_Name'],'width':values['m_Width'],'height':values['m_Height'],'original_path_id':str(obj['path_id']),'original_object_bytes':obj['size'],'serialized_class_ids':ids,'serialized_objects':[{k:v for k,v in o.items() if k!='tree'} for o in objects],'type_tree_prefix_fields':fields,'no_script_identifiers':True,'no_serialized_externals':True}


def main():
    raw_report=json.loads((RAW/'report.json').read_text())
    if raw_report['status']!='complete_raw_archive_verified_not_Unity_editable' or raw_report['errors'] or sha(INV/'catalog.json')!=raw_report['catalog_sha256']:raise ValueError('Full original raw verification/catalog proof required')
    deps={r['file']:r['dependencies'] for r in json.loads((INV/'dependencies.json').read_text())['bundles']}
    cat=json.loads((INV/'catalog.json').read_text());bundle_rows=cat['bundles'];choices=[]
    for row in bundle_rows:
        ids={cid for node in row['nodes'] if node.get('metadata') for cid in node['metadata']['class_ids']}
        if ids=={28,142} and not deps[row['bundle']] and row['bytes']<=128*1024 and all(not n.get('metadata',{}).get('externals') for n in row['nodes']):choices.append(row)
    choices.sort(key=lambda r:r['bytes']);del cat,bundle_rows
    containers={r['source_bundle']:r for r in json.loads(CONTAINERS.read_text())['containers']}
    nodes={}
    with (RAW/'verified-nodes.jsonl').open() as stream:
        for line in stream:
            row=json.loads(line)
            if row['serialized']:nodes[(row['source_bundle'],row['source_file'])]=row
    chosen=None
    for row in choices[:100]:
        container=containers[row['bundle']]
        if len(container['entries'])!=1:continue
        entry=container['entries'][0]
        if entry['file_id']!=0 or entry['target_serialized_file']!=container['serialized_file']:continue
        node=nodes[(row['bundle'],container['serialized_file'])];node_path=Path(node['path'])
        if sha(node_path)!=node['sha256']:raise ValueError('Verified raw node changed')
        texture=texture_prefix(node_path,int(entry['path_id']))
        if not (16<=texture['width']<=256 and 16<=texture['height']<=256):continue
        chosen={'bundle':row,'container':container,'verified_node':node,'texture':texture};break
    if chosen is None:raise ValueError('No tiny original texture fixture satisfied all gates')
    source=ROOT/'VerifiedSource'/chosen['bundle']['relative_path']
    if sha(source)!=chosen['bundle']['sha256']:raise ValueError('Original bundle changed')
    source_objects=[]
    with (RAW/'original-objects.jsonl').open() as stream:
        for line in stream:
            row=json.loads(line)
            if row['source_bundle']==chosen['bundle']['bundle']:source_objects.append(row)
    if len(source_objects)!=len(chosen['texture']['serialized_objects']) or set(r['class_id'] for r in source_objects)!={28,142}:raise ValueError('Independent all-original-object index disagrees')
    if any(r['class_id'] in (114,115) for r in source_objects):raise ValueError('Scripts cannot be invoked by fixture')
    output=ROOT/'RuntimeSDKRecovery'/('TextureFixturePlan-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);output.mkdir()
    report={'schema':'original-texture-only-genuine-sdk-fixture-input/v1','status':'prepared-not-executed','project_changed':False,'original_client_or_game_code_executed':False,'source_bundle':str(source),'source_bundle_sha256':sha(source),'closure':[chosen['bundle']['bundle']],'no_cross_bundle_dependencies':True,'no_native_resource_externals':True,'all_class_ids':[28,142],'independent_original_objects':source_objects,'selection':chosen,'inputs':[{'path':str(p),'sha256':sha(p)} for p in (RAW/'report.json',RAW/'original-objects.jsonl',RAW/'verified-nodes.jsonl',INV/'catalog.json',INV/'dependencies.json',CONTAINERS,Path(__file__).resolve())]}
    (output/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(output/'report.json'),'texture':chosen['texture']['name'],'dimensions':[chosen['texture']['width'],chosen['texture']['height']],'bundle_bytes':chosen['bundle']['bytes']}))


if __name__=='__main__':main()
