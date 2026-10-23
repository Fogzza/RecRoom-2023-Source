"""Run the already compiled pure Class21 reader on four exact native Material objects."""
from pathlib import Path
import argparse
import contextlib
import io
import json
import sys
import material_shader_pointer_probe as probe

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--material-map', type=Path, required=True)
    parser.add_argument('--material-map-sha256', required=True)
    parser.add_argument('--plan', type=Path, required=True)
    parser.add_argument('--plan-sha256', required=True)
    parser.add_argument('--output', type=Path, required=True)
    parser.add_argument('--run', action='store_true')
    args = parser.parse_args()
    source = args.material_map.resolve(strict=True)
    probe.guard.need(source.is_relative_to(probe.ROOT) and probe.guard.sha(source) == args.material_map_sha256, 'Exact actual native Material map required')
    material_map = json.loads(source.read_bytes())
    probe.guard.need(material_map['status'] == 'all_four_Editor_builtin_origin_Material_GUID_Class21_ranges_corroborated'
                     and len(material_map['materials']) == 4 and {r['builtin_local_id'] for r in material_map['materials']} == {'6', '7', '46', '10490'}, 'Four exact Material identity witnesses required')
    probe.guard.need(probe.guard.sha(args.plan) == args.plan_sha256, 'Exact compiled reader plan required')
    output = args.output.resolve()
    probe.guard.need(output.parent.is_relative_to(probe.ROOT) and output.parent.is_dir() and not output.exists(), 'Fresh isolated output pin-list path required')
    for row in material_map['materials']:
        probe.guard.checked(row['raw'])
    if not args.run:
        print(json.dumps({'status': 'verified_four_native_Material_inputs_no_child_started'}))
        return 0
    pins = []
    old_argv = sys.argv
    try:
        for row in material_map['materials']:
            sys.argv = [str(probe.__file__), '--plan', str(args.plan), '--plan-sha256', args.plan_sha256,
                        '--object', row['raw']['path'], '--object-sha256', row['raw']['sha256'], '--path-id', row['native_material_path_id']]
            buffer = io.StringIO()
            with contextlib.redirect_stdout(buffer):
                code = probe.main()
            result = json.loads(buffer.getvalue())
            probe.guard.need(code == 0 and result['status'] == 'full_generated_Class21_pointer_read_verified', 'Entire actual Class21 read and exact roundtrip required')
            probe.guard.checked(result['receipt'])
            receipt = json.loads(Path(result['receipt']['path']).read_bytes())
            probe.guard.checked(receipt['result'])
            pins.append(receipt['result'])
        with output.open('x', encoding='utf-8') as stream:
            json.dump(pins, stream, indent=2)
            stream.write('\n')
    finally:
        sys.argv = old_argv
    print(json.dumps({'status': 'four_actual_generated_Class21_reads_and_roundtrips_verified', 'typed_report_pins': probe.native.pin(output), 'reports': len(pins)}))
    return 0

if __name__ == '__main__':
    raise SystemExit(main())
