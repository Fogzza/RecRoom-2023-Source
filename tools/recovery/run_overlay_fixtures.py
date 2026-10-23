"""Exercise the production overlay reader and exact SDK identity gates."""
import argparse,copy,json,struct,sys,uuid
from datetime import datetime,timezone
from pathlib import Path
import build_stage_guarded as build
import prepare_marshalling_integration as prep

def offsets(data):
    at=0;cases=[];descriptors=[]
    def i():
        nonlocal at
        v=struct.unpack_from('<i',data,at)[0];at+=4;return v
    def s():
        nonlocal at
        n=0;shift=0
        while True:
            v=data[at];at+=1;n|=(v&127)<<shift
            if v<128:break
            shift+=7
        start=at;at+=n;return start,n
    schema=s();source=s();assembly=s();cases.extend([(schema[0],'byte',88),(assembly[0],'byte',88)])
    counts=[]
    for maximum in (111,64,318,819):
        p=at;counts.append(i());cases.extend([(p,'i32',0),(p,'i32',maximum+1)])
    def descriptor():
        nonlocal at
        p=at;kind=data[at];at+=1;native_at=at;i();descriptors.append((kind,p,native_at,at))
        if kind==1:i()
        if kind==2:i();i()
        if kind==3:i();i();i();i()
    for _ in range(counts[0]):
        for x in range(4):s()
        i();s();i();i();s();descriptor()
    for _ in range(counts[1]+counts[2]):
        for x in range(4):s()
        i();s();i()
        for x in range(i()):s()
        i();i();s();s();descriptor()
    families=set()
    for kind,p,native,fields in descriptors:
        if kind in families:continue
        families.add(kind)
        cases.append((p,'byte',255));cases.append((native,'i32',999))
        if kind==1:cases.append((fields,'i32',-1))
        elif kind==2:cases.extend([(fields,'i32',80),(fields+4,'i32',-1)])
        elif kind==3:cases.extend([(fields,'i32',999),(fields+8,'i32',-1),(fields+12,'i32',-2)])
    prep.need(families=={0,1,2,3},'All genuine descriptor families covered')
    return cases

def main():
    p=argparse.ArgumentParser();p.add_argument('--stage',required=True,type=Path);args=p.parse_args();stage=args.stage.resolve(strict=True)
    out=prep.ROOT/'Validation'/('MarshallingOverlayFixtures-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'production-marshal-overlay-controls/v1','phases':[],'game_code_executed':False,'project_changed':False,'stage_plan':prep.pinned(stage/'stage-plan.json')}
    try:
        # SDK token/owner/signature/descriptor mutation gates are independent of
        # the binary hash gate. No whole metadata inventory is loaded here.
        overlay=prep.read(prep.OVERLAY);sdk=prep.read(prep.SDK/'marshal-records.json');field={r['token']:r for r in sdk['fields']};method={r['token']:r for r in sdk['methods']};passed=0
        for kind in ('fields','parameters','returns','imports'):
            row=overlay['records'][kind][0];witness=(field if kind=='fields' else method)[row['sdk_cli_token']];prep.exact_sdk(row,witness,kind);passed+=1
            for key,value in [('owner','Wrong.Owner'),('name','WrongMember'),('type' if kind=='fields' else 'return','System.UInt64')]:
                changed=copy.deepcopy(row);changed[key]=value
                try:prep.exact_sdk(changed,witness,kind)
                except ValueError:passed+=1
                else:raise ValueError('SDK identity mutation accepted: '+kind+key)
            changed=copy.deepcopy(row)
            if kind=='imports':changed['pinvoke']['entry']='WrongEntry'
            else:changed['marshal']['native_type']=8
            try:prep.exact_sdk(changed,witness,kind)
            except ValueError:passed+=1
            else:raise ValueError('SDK descriptor/import mutation accepted: '+kind)
        report['sdk_identity_controls_passed']=passed
        data=(stage/'proven-marshalling-overlay.bin').read_bytes();cases=offsets(data)
        # Bound repetitions; parser family mutations must remain readable.
        cases=list(dict.fromkeys(cases));cases=cases[:64]
        mutations=out/'mutations.txt';mutations.write_text('\n'.join(' '.join(map(str,c)) for c in cases)+'\n')
        source=prep.HERE/'ProvenMarshallingOverlayFixtures.cs';target=out/'ProvenMarshallingOverlayFixtures.exe'
        base=(stage/'compile-codegen.rsp').read_text().splitlines();lines=[l for l in base if not l.startswith(('/target:','/out:'))]
        rsp=out/'compile.rsp';rsp.write_text('\n'.join(lines+['/target:exe','/out:"'+str(target)+'"','"'+str(source)+'"'])+'\n')
        for dependency in prep.read(stage/'stage-plan.json')['tool_dependencies']:
            import shutil
            shutil.copyfile(dependency['path'],out/Path(dependency['path']).name)
        build.reserved_phase([build.EDITOR/'Data/Tools/Roslyn/csc.exe','@'+str(rsp)],out,'compile',report,cap=.25,maximum=60)
        build.reserved_phase([build.EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',target,stage/'proven-marshalling-overlay.bin',mutations],out,'production-reader-controls',report,cap=.25,maximum=60)
        report.update(status='passed',parser_controls_passed=len(cases)+4,canonical_helper=prep.pinned(prep.HERE/'CanonicalMarshallingContracts.cs'),overlay_helper=prep.pinned(prep.HERE/'ProvenMarshallingOverlay.cs'))
    except Exception as e:report.update(status='failed',error=str(e))
    (out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'error':report.get('error')}));return 0 if report['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
