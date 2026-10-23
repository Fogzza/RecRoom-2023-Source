"""Exact public-package identity joins to original v27.1 tables, never execution."""
from pathlib import Path
import argparse
import hashlib
import importlib.util
import json
import mmap
import struct

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
NATIVE_HELPER = HERE.parent / 'ConstructorEvidence/native_metadata.py'
spec = importlib.util.spec_from_file_location('sdk_readonly_native_metadata', NATIVE_HELPER)
native = importlib.util.module_from_spec(spec); spec.loader.exec_module(native)
PRIMITIVES = dict(native.PRIMITIVES, **{})
PRIMITIVES.update({24:'System.IntPtr',25:'System.UIntPtr'})


def sha(path):
    with path.open('rb') as stream: return hashlib.file_digest(stream, 'sha256').hexdigest()


def shape(n, t, depth=0):
    if depth > 16 or t['num_mods'] or t['pinned']: raise ValueError('Unsupported modified/deep SDK native TypeSpec')
    kind, data = t['kind'], t['data']
    if kind in PRIMITIVES: value = '[mscorlib]' + PRIMITIVES[kind]
    elif kind in (17,18): value = '[' + n.image_of_type(data)['name'].removesuffix('.dll') + ']' + n.full_name(data)
    elif kind in (19,30): value = ('!' if kind == 19 else '!!') + str(n.u16(n.m,n.row('genericParameters',data,16)+12))
    elif kind == 21:
        at = n.raw(data,24)
        value = shape(n,n.type_at(n.u64(n.b,at)),depth+1) + '<' + ','.join(shape(n,a,depth+1) for a in n.inst_at(n.u64(n.b,at+8))) + '>'
    elif kind in (15,29): value = shape(n,n.type_at(data),depth+1) + ('*' if kind == 15 else '[:]')
    else: raise ValueError('Unsupported SDK native type kind ' + str(kind))
    return value + ('&' if t['byref'] else '')


def inventory(n, name):
    images = [image for image in n.images if image['name'] == name + '.dll']
    if len(images) != 1: raise ValueError('Original SDK image must be unique')
    image = images[0]; result = []
    for ti in range(image['start'], image['start'] + image['count']):
        at = n.row('typeDefinitions',ti,88); owner = n.full_name(ti)
        if owner == '<Module>': continue
        fields = []
        first = n.i32(n.m,at+32)
        for fi in range(first, first + n.u16(n.m,at+68)):
            fa = n.row('fields',fi,12); ft = n.native_type(n.i32(n.m,fa+4))
            fields.append({'name': n.string(n.i32(n.m,fa)), 'type': shape(n,ft), 'flags': ft['attributes'], 'native_token': hex(n.u32(n.m,fa+8))})
        methods = []
        first = n.i32(n.m,at+36)
        for mi in range(first, first + n.u16(n.m,at+64)):
            ma = n.row('methods',mi,32); argc = n.u16(n.m,ma+30); parameter_start = n.i32(n.m,ma+12)
            parameters = [n.native_type(n.i32(n.m,n.row('parameters',parameter_start+i,12)+8)) for i in range(argc)]
            rt = n.native_type(n.i32(n.m,ma+8)); gc = n.i32(n.m,ma+16)
            ga = n.i32(n.m,n.row('genericContainers',gc,16)+4) if gc >= 0 else 0
            signature = n.string(n.i32(n.m,ma)) + '``' + str(ga) + '(' + ','.join(shape(n,p) for p in parameters) + ')->' + shape(n,rt)
            methods.append({'signature':signature, 'flags':n.u16(n.m,ma+24), 'impl_flags':n.u16(n.m,ma+26),
                            'parameter_flags':[p['attributes'] for p in parameters], 'return_flags':rt['attributes'], 'native_token':hex(n.u32(n.m,ma+20))})
        result.append({'owner':owner, 'flags':n.u32(n.m,at+28), 'native_token':hex(n.u32(n.m,at+84)), 'native_index':ti, 'fields':fields, 'methods':methods})
    return result


def compare(original, candidate):
    current = {t['owner']:t for t in candidate['types']}
    if len(current) != len(candidate['types']): raise ValueError('Duplicate candidate type owner')
    errors = []; totals = {'types':0,'fields':0,'methods':0}; bindings = []
    for raw in original:
        actual = current.pop(raw['owner'],None)
        if actual is None: errors.append({'kind':'missing-type','owner':raw['owner']}); continue
        totals['types'] += 1
        if raw['flags'] != actual['flags']: errors.append({'kind':'type-flags','owner':raw['owner'],'native':raw['flags'],'candidate':actual['flags'],'native_token':raw['native_token']})
        fs = {f['name']:f for f in actual['fields']}
        if len(fs) != len(actual['fields']): raise ValueError('Duplicate candidate field name within exact SDK owner')
        for field in raw['fields']:
            found = fs.pop(field['name'],None)
            if found is None or any(field[k] != found[k] for k in ('name','type','flags')): errors.append({'kind':'field','owner':raw['owner'],'native':field,'candidate':found})
            else: totals['fields'] += 1
        if fs: errors.append({'kind':'extra-fields','owner':raw['owner'],'names':list(fs)})
        ms = {m['signature']:m for m in actual['methods']}
        if len(ms) != len(actual['methods']): raise ValueError('Duplicate candidate full SDK method shape')
        for method in raw['methods']:
            found = ms.pop(method['signature'],None)
            if found is None or any(method[k] != found[k] for k in ('signature','flags','impl_flags','parameter_flags','return_flags')): errors.append({'kind':'method','owner':raw['owner'],'native':method,'candidate':found})
            else:
                totals['methods'] += 1
                bindings.append({'owner':raw['owner'],'signature':method['signature'],'original_method_token':method['native_token'],'original_type_token':raw['native_token']})
        if ms: errors.append({'kind':'extra-methods','owner':raw['owner'],'signatures':list(ms)})
    if current: errors.append({'kind':'extra-types','owners':list(current)})
    return {'errors':errors,'totals':totals,'method_native_token_bindings':bindings}


def main():
    parser = argparse.ArgumentParser(); parser.add_argument('--rows',type=Path,required=True); parser.add_argument('--output',type=Path,required=True)
    args = parser.parse_args()
    if args.output.exists(): raise ValueError('Fresh SDK native identity output required')
    candidate = json.loads(args.rows.read_text())
    binary = ROOT/'VerifiedSource/GameAssembly.dll'
    metadata = ROOT/'VerifiedSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat'
    with binary.open('rb') as bf, metadata.open('rb') as mf, mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        n = native.NativeMetadata(b,m); original = inventory(n,candidate['assembly']); compared = compare(original,candidate)
    report = {'schema':'genuine-sdk-original-v27-identity/v1','status':'passed' if not compared['errors'] else 'differences-found-no-apply',
              'assembly':candidate['assembly'],'candidate_rows':{'path':str(args.rows.resolve()),'sha256':sha(args.rows)},
              'candidate_dll_sha256':candidate['sha256'],'source_inputs':[{'path':str(p),'sha256':sha(p)} for p in (binary,metadata,NATIVE_HELPER,Path(__file__).resolve())],
              'native_types':original,'tool_helper_absent_from_original_native':all(t['owner']!='Cpp2ILInjected.Cpp2ILHelpers' for t in original),
              'project_changed':False,'game_or_sdk_code_executed':False,**compared}
    args.output.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'status':report['status'],'assembly':candidate['assembly'],'counts':report['totals'],'errors':len(report['errors']),'report':str(args.output)}))


if __name__ == '__main__': main()
