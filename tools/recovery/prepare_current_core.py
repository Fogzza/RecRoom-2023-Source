"""Stage the current emitted-core metadata pipeline OUTSIDE the Unity project.

Large projection manifests are read one row at a time into a bounded SQLite
cache. This prepares exact reverse maps and build responses, never deployment.
It cannot accept a fixture processor or create missing gameplay definitions.
"""
from __future__ import annotations
import argparse
import base64
from datetime import datetime, timezone
import hashlib
import json
from pathlib import Path
import shutil
import sqlite3
import struct
import sys
import uuid
import re

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
EDITOR = WORKSPACE / 'Tools/Editors/2020.3.33f1/Editor'
V5 = ROOT / 'CompilerRepairs/MetadataRestorationV5-20261022T062100Z'
sys.path.insert(0, str(HERE.parent))
from metadata_projection_subset import array_rows, sha

NAMES = ('CanonicalMetadataSignatures.cs', 'ProjectedCanonicalSignatures.cs', 'MetadataReferenceReversal.cs',
         'MetadataDefinitionRestoration.cs', 'ExactInModifierReversal.cs', 'ReadonlyAttributeRestoration.cs',
         'WholeManifest.cs', 'BodyAndSymbolSafety.cs', 'MetadataRoundTripSafety.cs', 'WholeMetadataRestorer.cs', 'GeneralPostProcessor.cs')


def need(value, message):
    if not value:
        raise ValueError(message)


def header(path, key):
    with path.open(encoding='utf-8-sig') as stream:
        text = stream.read(262144)
    marker = '  "' + key + '": '
    need(marker in text, 'Required early projection header absent: ' + key)
    return json.JSONDecoder().raw_decode(text.split(marker, 1)[1])[0]


def key(*values):
    return json.dumps(values, separators=(',', ':'), ensure_ascii=True)


def root_rows(path):
    decoder=json.JSONDecoder()
    with path.open(encoding='utf-8-sig') as stream:
        buffer=stream.read(262144).lstrip()
        need(buffer.startswith('['),'Expected root array');buffer=buffer[1:]
        while True:
            while not buffer.strip():
                block=stream.read(262144);need(block,'Truncated root array');buffer+=block
            buffer=buffer.lstrip()
            if buffer.startswith(']'):return
            if buffer.startswith(','):buffer=buffer[1:].lstrip()
            while True:
                buffer=buffer.lstrip()
                try:row,end=decoder.raw_decode(buffer);break
                except json.JSONDecodeError:
                    need(len(buffer)<=16*1024*1024,'Root array row exceeds16MiB')
                    block=stream.read(262144);need(block,'Truncated root array');buffer+=block
            yield row;buffer=buffer[end:]


class Cache:
    def __init__(self, path):
        self.db = sqlite3.connect(path)
        self.db.enable_load_extension(False)
        self.db.executescript('PRAGMA cache_size=-8192;PRAGMA temp_store=FILE;PRAGMA journal_mode=DELETE;CREATE TABLE rows(kind TEXT NOT NULL,k TEXT NOT NULL,owner TEXT,value TEXT NOT NULL,ordinal INTEGER PRIMARY KEY,UNIQUE(kind,k));CREATE INDEX by_owner ON rows(kind,owner);')

    def insert(self, kind, identity, row):
        data = json.dumps(row, sort_keys=True, separators=(',', ':'), ensure_ascii=True)
        prior = self.db.execute('SELECT value FROM rows WHERE kind=? AND k=?', (kind, identity)).fetchone()
        if prior:
            need(prior[0] == data, 'Conflicting exact identity: ' + kind + ':' + identity)
            return
        self.db.execute('INSERT INTO rows(kind,k,owner,value) VALUES(?,?,?,?)', (kind, identity, row.get('original_type', row.get('original_owner', row.get('original_full_name'))), data))

    def one(self, kind, identity, default=None):
        value = self.db.execute('SELECT value FROM rows WHERE kind=? AND k=?', (kind, identity)).fetchone()
        return json.loads(value[0]) if value else default

    def rows(self, kind):
        for row in self.db.execute('SELECT value FROM rows WHERE kind=? ORDER BY ordinal', (kind,)):
            yield json.loads(row[0])

    def count(self, kind):
        return self.db.execute('SELECT count(*) FROM rows WHERE kind=?', (kind,)).fetchone()[0]

    def for_owner(self, kind, owner):
        for row in self.db.execute('SELECT value FROM rows WHERE kind=? AND owner=? ORDER BY ordinal', (kind, owner)):
            yield json.loads(row[0])


class Binary:
    def __init__(self, path):
        self.stream = path.open('xb')

    def integer(self, value): self.stream.write(struct.pack('<i', value))
    def boolean(self, value): self.stream.write(bytes([bool(value)]))
    def token(self, value): self.stream.write(struct.pack('<I', int(value, 0) if isinstance(value, str) else value))

    def string(self, value):
        encoded = value.encode('utf-8'); length = len(encoded)
        need(length <= 4 * 1024 * 1024, 'Bounded manifest string exceeded')
        while length >= 128:
            self.stream.write(bytes([(length & 127) | 128])); length >>= 7
        self.stream.write(bytes([length])); self.stream.write(encoded)

    def strings(self, values):
        self.integer(len(values))
        for value in values: self.string(value)

    def close(self):
        self.stream.flush(); self.stream.close()


def prepare(args):
    source, references = args.source.resolve(strict=True), args.references.resolve(strict=True)
    output = args.output.absolute()
    need(not output.exists() and not output.is_relative_to(WORKSPACE / 'RR23'), 'Use a fresh stage outside RR23')
    need(header(source, 'schema') == 'recovered-compiler-metadata-restore/v1' and header(source, 'assembly_name') == 'Assembly-CSharp', 'Unexpected current source schema/assembly')
    need(header(references, 'schema') == 'compiler-reference-projection/v1', 'Unexpected compiler facade schema')
    raw, serial = header(source, 'raw_metadata'), header(source, 'serialization_metadata_provider')
    for record in (raw, serial): need(sha(Path(record['path'])) == record['sha256'], 'Pinned original metadata changed')
    output.mkdir(parents=True)
    cache = Cache(output / 'bounded-manifest-cache.sqlite')
    maps = output / 'OriginalGaps'; maps.mkdir()
    input_records = [{'path': str(p), 'sha256': sha(p)} for p in (source, references)]
    counts = {}
    field_amendments={}
    if args.field_bindings:
        field_doc=json.loads(args.field_bindings.read_text())
        need(field_doc['schema']=='proven-native-emitted-field-selector-amendments/v1' and field_doc['status']=='proven' and field_doc['actual_sha256']==sha(Path(field_doc['actual'])),'Incomplete actual field amendment proof')
        need(all(sha(Path(p['path']))==p['sha256'] for p in field_doc['proofs']),'Field amendment proof artifact changed')
        need(all(sha(Path(p['path']))==p['sha256'] and sha(Path(p['meta_path']))==p['meta_sha256'] for p in field_doc['source_files']),'Field amendment source/meta witness changed')
        need(len(field_doc['bindings'])==2,'Expected exactly two independently proven field aliases')
        for row in field_doc['bindings']:
            need(row['exact_native_raw_actual_typespec_proven'] and row['exporter_identity_proven'],'Field alias identity/TypeSpec proof absent')
            identity=key(row['original_owner'],row['original_name']);need(identity not in field_amendments,'Duplicate exact field alias proof');field_amendments[identity]=row
        input_records.append({'path':str(args.field_bindings.resolve()),'sha256':sha(args.field_bindings)})
    specifications = [('source_type_inventory', 'inventory', lambda r: r['original_full_name']),
                      ('types', 'detail', lambda r: r['original_full_name']),
                      ('all_field_identity_mappings', 'fields', lambda r: r['original_type']),
                      ('event_projections', 'event', lambda r: key(r['original_type'], r['original_name'])),
                      ('property_return_attribute_projections', 'readonly', lambda r: key(r['original_type'], r['original_property_name'])),
                      ('additional_method_identity_projections', 'identity', lambda r: key(r['original_type'], r['original']['canonical_signature'])),
                      ('additional_method_access_projections', 'access', lambda r: key(r['original_type'], r['original']['canonical_signature']))]
    for root_key, kind, identity in specifications:
        total = 0
        for row in array_rows(source, root_key):
            cache.insert(kind, identity(row), row); total += 1
        counts[root_key] = total
        cache.db.commit()
    method_audit=None
    witness_path=ROOT/'Validation/CoreFieldAttributeWitness-20261022T114004Z-f1c134b5/type-mismatch-witnesses.json'
    serialization_witnesses=[]
    if args.method_audit:
        method_audit=json.loads(args.method_audit.read_text())
        need(method_audit['status']=='all-extra-methods-proven-forwarders' and method_audit['ambiguous_originals']==0 and method_audit['unexplained_extras']==0,'Incomplete original method binding/adapter proof')
        need(method_audit['raw_sha256']==raw['sha256'] and sha(Path(method_audit['actual']))==method_audit['actual_sha256'],'Original method proof raw/actual hash differs')
        if args.field_bindings:need(field_doc['actual_sha256']==method_audit['actual_sha256'],'Method/field actual-core proofs refer to different assemblies')
        for row in root_rows(args.method_audit.parent/'bindings.json'):
            cache.insert('binding',key(row['original_owner'],row['original']),row)
            if row['raw_attributes']&8192:cache.insert('extern',key(row['original_owner'],row['original']),row)
        for row in root_rows(args.method_audit.parent/'missing-originals.json'):
            row['original_type']=row['owner'];cache.insert('missing',key(row['owner'],row['original']),row)
        need(cache.count('binding')==method_audit['bound_originals'] and cache.count('missing')==method_audit['missing_originals'],'Full original method subset inventory count differs')
        witness_doc=json.loads(witness_path.read_text());need(witness_doc['schema']=='native-proven-old-serialization-field-signature-witnesses/v1','Wrong native serialization witness schema')
        witness_report=json.loads((witness_path.parent/'report.json').read_text());need(witness_report['status']=='completed' and witness_report['summary']['all_contracts_proven'] and witness_report['summary']['mismatch_witness_count']==4 and witness_report['summary']['exact_field_token_owner_name_raw_typespec_and_serialization_matches']==57730,'Native field ownership report is incomplete')
        provider_inputs={Path(r['path']).resolve():r['sha256'] for r in witness_report['inputs']}
        need(provider_inputs.get(Path(raw['path']).resolve())==raw['sha256'] and provider_inputs.get(Path(serial['path']).resolve())==serial['sha256'],'Native field witness providers differ from embedded original resources')
        provenance=json.loads((witness_path.parent/'provenance.json').read_text());need(provenance['schema']=='core-field-witness-provenance/v1','Wrong field witness provenance schema')
        native_expected={'GameAssembly.dll':'ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b','global-metadata.dat':'1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474'}
        need(len(provenance['native_sources'])==2 and all(r['sha256']==native_expected.get(Path(r['path']).name) and sha(Path(r['path']))==r['sha256'] for r in provenance['native_sources']),'Native field witness client hashes differ')
        need(all(sha(Path(r['path']))==r['sha256'] for r in provenance['witness_artifacts']),'Native field witness artifact changed')
        serialization_witnesses=witness_doc['witnesses'];need(len(serialization_witnesses)==4 and all(r['exact_native_token_owner_name_raw_typespec_proven'] and r['old_provider_attribute_ownership_only'] and r['raw_shape']==r['native_shape'] and r['old_original_token_attribute']==r['native_original_field_token'] for r in serialization_witnesses),'Incomplete native serialization witness')
        input_records.extend({'path':str(p),'sha256':sha(p)} for p in (witness_path,witness_path.parent/'report.json',witness_path.parent/'provenance.json'))
        for path in (args.method_audit,args.method_audit.parent/'bindings.json',args.method_audit.parent/'missing-originals.json',args.method_audit.parent/'accepted-forwarding-adapters.json',args.method_audit.parent/'compiler-added-marker-constructor-inverse.json'):
            input_records.append({'path':str(path.resolve()),'sha256':sha(path)})
    cache.insert('inventory', '<Module>', {'original_full_name': '<Module>', 'compiled_full_name': '<Module>', 'expected_original_method_count': 0, 'expected_original_field_count': 0})
    for row in cache.rows('inventory'):
        cache.insert('typealias', key('Assembly-CSharp', row['original_full_name']), {'assembly': 'Assembly-CSharp', 'original_full_name': row['original_full_name'], 'compiled_full_name': row['compiled_full_name']})
    for row in array_rows(references, 'all_original_to_compiled_types'):
        if row['assembly'] != 'Assembly-CSharp': cache.insert('typealias', key(row['assembly'], row['original_full_name']), row)
    # Both original and compiled type identities must be bijective.
    seen = set()
    for row in cache.rows('typealias'):
        identity = key(row['assembly'], row['compiled_full_name']); need(identity not in seen, 'Nonbijective compiled type alias'); seen.add(identity)
    del seen
    def method_alias(assembly, original_type, compiled_type, original, compiled):
        row = {'assembly': assembly, 'original_declaring_type': original_type, 'compiled_declaring_type': compiled_type, 'original': original, 'compiled': compiled}
        cache.insert('methodalias', key(assembly, compiled_type, compiled['canonical_signature']), row)
    for row in array_rows(references, 'all_original_to_compiled_methods'):
        if row['assembly'] != 'Assembly-CSharp':
            method_alias(row['assembly'], row['original_declaring_type'], row['compiled_declaring_type'], row['original'], row['compiled'])
    for item in cache.rows('inventory'):
        name, compiled = item['original_full_name'], item['compiled_full_name']
        detail = cache.one('detail', name, {'properties': [], 'events': []})
        fields = cache.one('fields', name, {'fields': []})['fields']
        for field in fields:
            amendment=field_amendments.get(key(name,field['original']['name']))
            if amendment:
                need(compiled==amendment['compiled_owner'] and field['compiled']['name']==amendment['previous_compiled_name'] and field['original']['canonical_field_type']==amendment['original_canonical_type'] and field['compiled']['canonical_field_type']==amendment['compiled_canonical_type'],'Exact field amendment conflicts with native source plan')
                field['compiled']['name']=amendment['compiled_name'];field['binding_proof']='Exact native original field/token + actual compiled TypeSpec + proven exporter identity'
        need(len(fields) == item['expected_original_field_count'] and all(not f.get('ambiguous') and f.get('compiled') is not None for f in fields), 'Incomplete exact field map: ' + name)
        events = {}
        for row in detail.get('events', []):
            prior = events.setdefault(row['original_name'], row); need(prior == row, 'Conflicting detailed event')
        for row in cache.for_owner('event', name):
            prior = events.setdefault(row['original_name'], row); need(prior == row, 'Conflicting global event')
        methods = {}
        for member in detail.get('properties', []) + list(events.values()):
            for row in member['methods']:
                identity = row['original']['canonical_signature']; prior = methods.setdefault(identity, row); need(prior == row, 'Conflicting property/event MethodDef map')
        # Older fixture preparation omitted these return-type-only overload
        # projections. They are essential exact MethodDef identities too.
        for row in cache.for_owner('identity', name):
            identity = row['original']['canonical_signature']; prior = methods.setdefault(identity, row); need(prior == row, 'Conflicting additional MethodDef identity')
        if method_audit:
            bound={}
            for binding in cache.for_owner('binding',name):
                existing=methods.get(binding['original']);desired=binding['compiled']
                if existing:
                    for left,right in [('original_attributes','raw_attributes'),('original_impl_attributes','raw_impl_attributes'),('original_semantics','raw_semantics')]:need(existing[left]==binding[right],'Exact source/raw method flags conflict')
                bound[binding['original']]={'original':{'canonical_signature':binding['original']},'compiled':{'canonical_signature':desired},'original_attributes':binding['raw_attributes'],'original_impl_attributes':binding['raw_impl_attributes'],'original_semantics':binding['raw_semantics']}
                if desired!=binding['compiled']:cache.insert('bindingamendment',key(name,binding['original']),{**binding,'normalized_compiled':desired})
            need(not set(methods)-set(bound),'Detailed emitted method is not bound by full original proof')
            # The actual compiled MethodImpl/accessor audit is authoritative.
            # Source spellings can contain nested global:: qualifiers that the
            # C# compiler normalizes, so they cannot override emitted selectors.
            methods=bound
            need(len(methods)+len(list(cache.for_owner('missing',name)))==item['expected_original_method_count'],'Original emitted+missing method inventory differs: '+name)
        else:
            for row in methods.values(): method_alias('Assembly-CSharp', name, compiled, row['original'], row['compiled'])
        for row in fields:
            alias = {'assembly': 'Assembly-CSharp', 'original_declaring_type': name, 'compiled_declaring_type': compiled, 'original': row['original'], 'compiled': row['compiled']}
            cache.insert('fieldalias', key('Assembly-CSharp', compiled, row['compiled']['name'], row['compiled']['canonical_field_type']), alias)
        cache.insert('definition', name, {'original': name, 'compiled': compiled, 'method_count': item['expected_original_method_count'], 'field_count': item['expected_original_field_count'],
                                        'methods': list(methods.values()), 'fields': fields, 'properties': [] if method_audit else detail.get('properties', []), 'events': [] if method_audit else list(events.values())})
    for row in cache.rows('readonly'):
        provider = row['provider']
        need(row['attribute_type'] == 'System.Runtime.CompilerServices.IsReadOnlyAttribute' and row['original_property_has_attribute'] and row['compiler_getter_return_has_attribute'] and provider['sha256'] == serial['sha256'], 'Unsupported readonly ownership projection')
        inventory = cache.one('inventory', row['original_type']); need(inventory, 'Readonly type outside emitted inventory')
        method_alias('Assembly-CSharp', row['original_type'], inventory['compiled_full_name'], row['original_getter'], row['compiled_getter'])
    if field_amendments:
        for row in field_amendments.values():
            definition=cache.one('definition',row['original_owner']);need(definition and len([f for f in definition['fields'] if f['original']['name']==row['original_name'] and f['compiled']['name']==row['compiled_name']])==1,'Exact field selector amendment was not applied')
    cache.db.commit()
    omitted, helper = 0, []
    gap_path = maps / 'unrecovered-original-types.json'
    with gap_path.open('x', encoding='utf-8') as stream:
        stream.write('{"scope":"Explicit original definitions absent from current editable source; never implicit runtime exclusions","types":[\n')
        for row in array_rows(source, 'unmatched_raw_types'):
            if omitted: stream.write(',\n')
            json.dump(row, stream); omitted += 1
            if row['original_full_name'] == 'Cpp2ILInjected.Cpp2ILHelpers': helper.append(row['original_full_name'])
        stream.write('\n]}\n')
    manifest = output / 'current-core-manifest.bin'; b = Binary(manifest)
    b.string('RR23-METADATA-RESTORE-6' if method_audit else 'RR23-METADATA-RESTORE-5'); b.string('Assembly-CSharp')
    for value in (raw['sha256'], serial['sha256'], sha(source), sha(references)): b.string(value)
    b.boolean(args.mode == 'whole-original'); b.strings(helper)
    b.integer(cache.count('typealias'))
    for row in cache.rows('typealias'):
        for name in ('assembly', 'original_full_name', 'compiled_full_name'): b.string(row[name])
    b.integer(cache.count('methodalias'))
    for row in cache.rows('methodalias'):
        for name in ('assembly', 'original_declaring_type', 'compiled_declaring_type'): b.string(row[name])
        b.string(row['original']['name']); b.string(row['compiled']['name']); b.string(row['compiled']['canonical_signature'])
        b.string(row['original']['canonical_signature']); b.string(row['original']['canonical_return_type']); b.strings(row['original']['canonical_parameter_types'])
    b.integer(cache.count('fieldalias'))
    for row in cache.rows('fieldalias'):
        for name in ('assembly', 'original_declaring_type', 'compiled_declaring_type'): b.string(row[name])
        b.string(row['original']['name']); b.string(row['compiled']['name']); b.string(row['compiled']['canonical_field_type'])
    b.integer(cache.count('definition'))
    for row in cache.rows('definition'):
        b.string(row['original']); b.string(row['compiled']); b.integer(row['method_count']); b.integer(row['field_count'])
        b.integer(len(row['methods']))
        for m in row['methods']:
            b.string(m['original']['canonical_signature']); b.string(m['compiled']['canonical_signature'])
            for name in ('original_attributes', 'original_impl_attributes', 'original_semantics'): b.integer(m[name])
        b.integer(len(row['fields']))
        for f in row['fields']:
            b.string(f['original']['name']); b.string(f['compiled']['name']); b.string(f['original']['canonical_field_type']); b.string(f['compiled']['canonical_field_type']); b.integer(f['original_attributes'])
        b.integer(len(row['properties']))
        for p in row['properties']:
            for name in ('original_name', 'compiled_name', 'canonical_property_type', 'canonical_compiled_property_type'): b.string(p[name])
            b.strings(p['canonical_parameter_types']); b.strings(p['canonical_compiled_parameter_types']); b.integer(p['original_property_attributes'])
        b.integer(len(row['events']))
        for e in row['events']:
            for name in ('original_name', 'compiled_name', 'canonical_event_type', 'canonical_compiled_event_type'): b.string(e[name])
            b.integer(e['original_attributes'])
    b.integer(cache.count('readonly'))
    for row in cache.rows('readonly'):
        p = row['provider']; inventory = cache.one('inventory', row['original_type'])
        for value in (row['original_type'], inventory['compiled_full_name'], row['original_property_name'], row['compiled_property_name'], row['original_getter']['canonical_signature'], row['compiled_getter']['canonical_signature'], row['compiled_getter']['canonical_return_type']): b.string(value)
        b.strings(row['compiled_getter']['canonical_parameter_types'])
        for value in (p['sha256'], p['attribute_constructor'], p['attribute_constructor_assembly']): b.string(value)
        for name in ('declaring_type_token', 'property_token', 'getter_method_token'): b.token(p[name])
        blob = base64.b64decode(p['attribute_blob_base64'], validate=True); b.integer(len(blob)); b.stream.write(blob)
        b.boolean(row['original_property_has_attribute']); b.boolean(row['original_getter_return_has_attribute'])
    if method_audit:
        b.integer(cache.count('missing'))
        for row in cache.rows('missing'):
            for value in (row['owner'],row['original'],row['expected_compiled']):b.string(value)
            match=re.fullmatch(r'\[Method:0x([0-9a-fA-F]+)\]',row['raw_CLI_token']);need(match,'Original provider token malformed');b.token(0x06000000|int(match[1],16))
            for name in ('raw_attributes','raw_impl_attributes','raw_semantics'):b.integer(row[name])
            b.string('unrecovered-original-static-constructor' if row['original'].startswith('M6:.cctor') else 'unrecovered-original-instance-constructor' if row['original'].startswith('M5:.ctor') else 'unrecovered-original-method')
        adapter_rows=list(root_rows(args.method_audit.parent/'accepted-forwarding-adapters.json'))
        b.integer(len(adapter_rows))
        owner_map={r['compiled_full_name']:r['original_full_name'] for r in cache.rows('inventory')}
        for row in adapter_rows:
            original_owner=owner_map[row['compiled_owner']]
            definition=cache.one('definition',original_owner)
            bound=[m for m in definition['methods'] if m['original']['canonical_signature']==row['retained_target_original']]
            need(len(bound)==1,'Adapter has no unique emitted original plan')
            for value in (original_owner,row['compiled_owner'],row['retained_target_original'],row['adapter'],row['retained_target'],bound[0]['compiled']['canonical_signature']):b.string(value)
        ctor_rows=list(root_rows(args.method_audit.parent/'compiler-added-marker-constructor-inverse.json'))
        b.integer(len(ctor_rows))
        for row in ctor_rows:
            b.string(row['compiled_owner']);b.string(row['adapter'])
        b.integer(cache.count('extern'))
        for row in cache.rows('extern'):
            for value in (row['original_owner'],row['compiled_owner'],row['original'],row['compiled']):b.string(value)
            match=re.fullmatch(r'\[Method:0x([0-9a-fA-F]+)\]',row['raw_CLI_token']);need(match,'Extern provider token malformed');b.token(0x06000000|int(match[1],16))
            for name in ('raw_attributes','raw_impl_attributes','raw_semantics'):b.integer(row[name])
        b.integer(len(serialization_witnesses))
        for row in serialization_witnesses:
            for name in ('owner','name','raw_canonical_type','old_canonical_type'):b.string(row[name])
            for name in ('raw_provider_field_cli_token','old_provider_field_cli_token','native_original_field_token','original_owner_token'):b.token(row[name])
    b.close(); need(manifest.stat().st_size <= (128 if method_audit else 64) * 1024 * 1024, 'Manifest exceeds explicit bounded schema size')
    # Pin and copy the proven V5 source, never any fixture binary/manifest.
    pinned = json.loads((V5 / 'prepared.json').read_text())
    originals = {Path(r['copy']).name: r for r in pinned['copies']}
    package = output / 'Package'; codegen = package / 'Assets/Editor/OriginalMetadataRestoration'; codegen.mkdir(parents=True)
    support_relative = Path('CompilerSupport/Metadata')
    support = package / support_relative; support.mkdir(parents=True)
    support_manifest = support / 'current-core-manifest.bin'; shutil.copyfile(manifest, support_manifest)
    support_raw = support / 'OriginalRawCore.dll'; shutil.copyfile(raw['path'], support_raw)
    support_serial = support / 'OriginalSerializationCore.dll'; shutil.copyfile(serial['path'], support_serial)
    snapshots = []
    for name in NAMES:
        path = V5 / 'Source' / name; need(name in originals and sha(path) == originals[name]['sha256'], 'Pinned V5 source changed: ' + name)
        target = codegen / name; shutil.copyfile(path, target); snapshots.append({'source': str(path), 'copy': str(target), 'sha256': sha(target)})
    # The production acceptance CLI is generic, never the fixture-only CLI with
    # a hardcoded output prefix or AutoScaledText assertions.
    extras=['OriginalTypeContractChecks.cs','ExactOriginalTypeFlagRestoration.cs','ExactMetadataReferenceResolver.cs','OriginalRuntimeMetadataReferenceInputs.cs','MetadataRoundTripDiagnostics.cs']+(['EmittedOriginalMethodSubsetPolicy.cs','EmittedReferencePlanCompletion.cs','CoreCompilerAdapterNormalizer.cs','ExactOriginalPropertyRestoration.cs','OriginalEmptyExternRestoration.cs','SerializationFieldIdentityWitness.cs'] if method_audit else [])
    for name in ['CurrentCoreChecks.cs']+extras:
        shutil.copyfile(HERE.parent/'RuntimeMetadataAudit'/name if name=='CoreCompilerAdapterNormalizer.cs' else HERE/name, output / name)
    cli_source = output / 'CurrentCoreChecks.cs'
    checked_engine = codegen / 'WholeMetadataRestorer.cs'
    text = checked_engine.read_text()
    text=text.replace('public static WholeRestoredBytes Restore(byte[] pe, byte[] pdb)','public static WholeRestoredBytes Restore(byte[] pe, byte[] pdb, string[] referencePaths)')
    text=text.replace('var reader = new ReaderParameters { InMemory = true, ReadSymbols = symbols };','using (var resolver = new ExactMetadataReferenceResolver(referencePaths, OriginalRuntimeMetadataReferenceInputs.Values))\n            {\n            var reader = new ReaderParameters { InMemory = true, ReadSymbols = symbols, AssemblyResolver = resolver };')
    text=text.replace('using (var raw = AssemblyDefinition.ReadAssembly(new MemoryStream(rawBytes, false)))','using (var raw = AssemblyDefinition.ReadAssembly(new MemoryStream(rawBytes, false), new ReaderParameters { AssemblyResolver = resolver }))')
    text=text.replace('using (var serial = AssemblyDefinition.ReadAssembly(new MemoryStream(serialBytes, false)))','using (var serial = AssemblyDefinition.ReadAssembly(new MemoryStream(serialBytes, false), new ReaderParameters { AssemblyResolver = resolver }))')
    text=text.replace('var reread = new ReaderParameters { ReadSymbols = symbols };','var reread = new ReaderParameters { ReadSymbols = symbols, AssemblyResolver = resolver };')
    text=text.replace('var expectedMetadata = MetadataRoundTripSafety.Fingerprint(assembly.MainModule);','var expectedMetadata = MetadataRoundTripSafety.Fingerprint(assembly.MainModule);\n                    var expectedMetadataRows = MetadataRoundTripDiagnostics.Capture(assembly.MainModule);')
    text=text.replace('throw new InvalidDataException("Emitted original metadata did not round-trip exactly");','throw new InvalidDataException("Emitted original metadata did not round-trip exactly: " + MetadataRoundTripDiagnostics.Difference(expectedMetadataRows, verified.MainModule));')
    needle='return result;\n            }\n        }';need(text.count(needle)==1,'Resolver disposal hook changed');text=text.replace(needle,'return result;\n            }\n            }\n        }')
    old = 'var plans = CompletePlans(manifest, assembly.MainModule, raw.MainModule);'
    need(text.count(old) == 1, 'Strict original type-contract hook source changed')
    text = text.replace(old, old + '\n                ExactOriginalTypeFlagRestoration.Apply(assembly.MainModule, raw.MainModule, plans);\n                OriginalTypeContractChecks.VerifyProjected(assembly.MainModule, raw.MainModule, plans, manifest.Types);')
    if method_audit:
        text=text.replace('var detailed = manifest.Definitions.ToDictionary(t => t.OriginalFullName);','var originalScopeNames = new HashSet<string>(own.Select(o => o.OriginalFullName));\n            EmittedOriginalMethodSubsetPolicy.VerifyScope(originals.Values.Where(t => originalScopeNames.Contains(t.FullName)), manifest.UnrecoveredMethods);\n            var detailed = manifest.Definitions.ToDictionary(t => t.OriginalFullName);')
        hook='var methods = Walk(assembly.MainModule.Types).SelectMany(t => t.Methods).ToArray();'
        need(text.count(hook)==1,'Adapter inverse hook changed')
        text=text.replace(hook,'var adapterNormalization = CoreCompilerAdapterNormalizer.Normalize(assembly.MainModule, raw.MainModule, manifest);\n                var originalParameterizedProperties = ExactOriginalPropertyRestoration.Apply(assembly.MainModule, raw.MainModule, manifest);\n                var originalEmptyExterns = OriginalEmptyExternRestoration.Apply(assembly.MainModule, raw.MainModule, manifest.EmptyExterns);\n                '+hook)
        text=text.replace('var rawType = originals[identity.OriginalFullName]; var compiledType = types[identity.CompiledFullName];','var rawType = originals[identity.OriginalFullName]; var compiledType = types[identity.CompiledFullName];\n                var emittedOriginalMethods = EmittedOriginalMethodSubsetPolicy.Select(raw, rawType, compiledType, manifest.UnrecoveredMethods);')
        text=text.replace('foreach (var method in rawType.Methods)','foreach (var method in emittedOriginalMethods)')
        text=text.replace('OriginalMethodCount = plan.OriginalMethodCount, OriginalFieldCount = plan.OriginalFieldCount,','OriginalMethodCount = plan.OriginalMethodCount, OriginalFieldCount = plan.OriginalFieldCount, MissingOriginalMethodCount = rawType.Methods.Count - emittedOriginalMethods.Length,')
        text=text.replace('MetadataReferenceReversal.Reverse(assembly.MainModule, manifest.Types, manifest.Methods, manifest.Fields)','MetadataReferenceReversal.Reverse(assembly.MainModule, manifest.Types, EmittedReferencePlanCompletion.Complete(manifest, raw.MainModule, plans), manifest.Fields)')
        text=text.replace('MetadataDefinitionRestoration.Bind(assembly.MainModule, raw.MainModule, serial.MainModule, plans)','MetadataDefinitionRestoration.Bind(assembly.MainModule, raw.MainModule, serial.MainModule, plans, manifest.SerializationFieldWitnesses)')
    checked_engine.write_text(text, encoding='utf-8')
    for name in extras:shutil.copyfile(output/name,codegen/name)
    if method_audit:
        reversal=codegen/'MetadataReferenceReversal.cs';data=reversal.read_text();needle='if (type.Name != name || type.Namespace != ns) { type.Name = name; type.Namespace = ns; result.TypeReferences++; }';replacement='''bool renamed = type.Name != name || type.Namespace != ns;
                // Cecil caches nested FullName independently of its parent.
                // Reassign the exact reviewed components even when unchanged,
                // invalidating stale child caches after a parent identity edit.
                type.Name = name; type.Namespace = ns;
                if (renamed) result.TypeReferences++;''';need(data.count(needle)==1,'TypeRef cache invalidation hook changed');reversal.write_text(data.replace(needle,replacement))
        diagnostic=codegen/'ExactInModifierReversal.cs';data=diagnostic.read_text().replace('throw new InvalidDataException("TypeSpec differs beyond the audited compiler InAttribute wrapper");','throw new InvalidDataException("TypeSpec differs beyond the audited compiler InAttribute wrapper: compiled=" + CanonicalMetadataSignatures.Type(compiled) + " expected=" + originalCanonicalType);');diagnostic.write_text(data)
        diagnostic=codegen/'GeneralPostProcessor.cs';data=diagnostic.read_text().replace('error.GetType().Name + ": " + error.Message','error.ToString()');data=data.replace('assembly.InMemoryAssembly.PeData, assembly.InMemoryAssembly.PdbData)','assembly.InMemoryAssembly.PeData, assembly.InMemoryAssembly.PdbData, assembly.References)');diagnostic.write_text(data)
        definitions=codegen/'MetadataDefinitionRestoration.cs';data=definitions.read_text();data=data.replace('public int OriginalMethodCount, OriginalFieldCount;','public int OriginalMethodCount, OriginalFieldCount, MissingOriginalMethodCount;');data=data.replace('binding.Compiled.Methods.Count != plan.OriginalMethodCount','binding.Compiled.Methods.Count + plan.MissingOriginalMethodCount != plan.OriginalMethodCount');data=data.replace('method.IsPInvokeImpl || raw.IsPInvokeImpl','method.IsPInvokeImpl != raw.IsPInvokeImpl || (raw.IsPInvokeImpl && (method.PInvokeInfo != null || raw.PInvokeInfo != null))');data=data.replace('throw new InvalidDataException("Unsupported method shape change");','throw new InvalidDataException("Unsupported method shape change: " + raw.FullName + " rawBody=" + raw.HasBody + " compiledBody=" + method.HasBody + " rawPInvoke=" + raw.IsPInvokeImpl + " compiledPInvoke=" + method.IsPInvokeImpl + " rawImpl=" + raw.ImplAttributes + " compiledImpl=" + method.ImplAttributes);');definitions.write_text(data)
        data=definitions.read_text().replace('"original serialization field");','"original serialization field " + plan.OriginalFullName + "::" + fieldPlan.OriginalName + ":" + fieldPlan.OriginalCanonicalType);');definitions.write_text(data)
        data=definitions.read_text().replace('"compiled field");','"compiled field " + plan.OriginalFullName + "::" + fieldPlan.OriginalName + " planned=" + fieldPlan.CompiledName + ":" + fieldPlan.CompiledCanonicalType);');definitions.write_text(data)
        data=definitions.read_text();needle='method.SemanticsAttributes = raw.SemanticsAttributes;';need(data.count(needle)==1,'Original method semantics cache hook changed');data=data.replace(needle,'// Cecil 0.11.4 setter does not mark its image-backed cache ready.\n                        // Materialize the compiled value before assigning the exact raw value.\n                        if (method.SemanticsAttributes != raw.SemanticsAttributes)\n                            method.SemanticsAttributes = raw.SemanticsAttributes;');definitions.write_text(data)
        # Full core has 12k types. Exact-name dictionaries retain uniqueness
        # rejection while avoiding repeated whole-module FullName allocations.
        data=definitions.read_text()
        for variable,module,selector in [('compiledTypes','compiled','plan.CompiledFullName'),('rawTypes','original','plan.OriginalFullName'),('serializationTypes','serialization','plan.OriginalFullName')]:
            data=data.replace('var '+variable+' = Walk('+module+'.Types).ToArray();','var '+variable+' = Walk('+module+'.Types).ToDictionary(t => t.FullName);')
        for variable,selector,label in [('compiledTypes','plan.CompiledFullName','compiled type '),('rawTypes','plan.OriginalFullName','original type '),('serializationTypes','plan.OriginalFullName','serialization type ')]:
            needle='One('+variable+'.Where(t => t.FullName == '+selector+'), "'+label+'" + '+selector+')'
            need(data.count(needle)==1,'Exact type lookup changed');data=data.replace(needle,variable+'['+selector+']')
        definitions.write_text(data)
        data=definitions.read_text().replace('ModuleDefinition serialization, IEnumerable<ExactTypePlan> plans)','ModuleDefinition serialization, IEnumerable<ExactTypePlan> plans, SerializationFieldWitnessPlan[] serializationWitnesses)')
        old_serial='''var serial = One(binding.Serialization.Fields.Where(f => f.Name == fieldPlan.OriginalName
                        && CanonicalMetadataSignatures.Type(f.FieldType) == fieldPlan.OriginalCanonicalType), "original serialization field " + plan.OriginalFullName + "::" + fieldPlan.OriginalName + ":" + fieldPlan.OriginalCanonicalType);'''
        new_serial='''var serialMatches = binding.Serialization.Fields.Where(f => f.Name == fieldPlan.OriginalName
                        && CanonicalMetadataSignatures.Type(f.FieldType) == fieldPlan.OriginalCanonicalType).Take(2).ToArray();
                    var serial = serialMatches.Length == 1 ? serialMatches[0] : SerializationFieldIdentityWitness.Resolve(serialization, raw, fieldPlan.OriginalCanonicalType, serializationWitnesses);'''
        need(data.count(old_serial)==1,'Serialization native-witness hook changed');definitions.write_text(data.replace(old_serial,new_serial))
        reader=codegen/'WholeManifest.cs';data=reader.read_text().replace('"RR23-METADATA-RESTORE-5"','"RR23-METADATA-RESTORE-6"');data=data.replace('public ReadonlyAttributePlan[] ReadonlyAttributes;','public ReadonlyAttributePlan[] ReadonlyAttributes;\n        public UnrecoveredOriginalMethodPlan[] UnrecoveredMethods;\n        public CoreCompilerAdapterPlan[] CompilerAdapters;\n        public CoreCompilerConstructorInversePlan[] CompilerAddedConstructors;\n        public OriginalEmptyExternPlan[] EmptyExterns;\n        public SerializationFieldWitnessPlan[] SerializationFieldWitnesses;');before='if (stream.Position != stream.Length) throw new InvalidDataException("Unexpected trailing general manifest data");';replacement='''result.UnrecoveredMethods = new UnrecoveredOriginalMethodPlan[Count(reader, 1000000)];
                for (int i = 0; i < result.UnrecoveredMethods.Length; i++) result.UnrecoveredMethods[i] = new UnrecoveredOriginalMethodPlan {
                    OriginalType = reader.ReadString(), OriginalCanonicalSignature = reader.ReadString(), ExpectedCompiledCanonicalSignature = reader.ReadString(),
                    OriginalProviderMethodToken = reader.ReadUInt32(), OriginalAttributes = reader.ReadInt32(), OriginalImplAttributes = reader.ReadInt32(), OriginalSemantics = reader.ReadInt32(), Classification = reader.ReadString() };
                result.CompilerAdapters = new CoreCompilerAdapterPlan[Count(reader, 100000)];
                for (int i=0;i<result.CompilerAdapters.Length;i++) result.CompilerAdapters[i]=new CoreCompilerAdapterPlan {
                    OriginalOwner=reader.ReadString(),CompiledOwner=reader.ReadString(),OriginalCanonical=reader.ReadString(),
                    AdapterCanonical=reader.ReadString(),RetainedCanonical=reader.ReadString(),PlannedRetainedCanonical=reader.ReadString() };
                result.CompilerAddedConstructors = new CoreCompilerConstructorInversePlan[Count(reader, 1000)];
                for (int i=0;i<result.CompilerAddedConstructors.Length;i++) result.CompilerAddedConstructors[i]=new CoreCompilerConstructorInversePlan {
                    CompiledOwner=reader.ReadString(),Canonical=reader.ReadString() };
                result.EmptyExterns=new OriginalEmptyExternPlan[Count(reader,100000)];
                for (int i=0;i<result.EmptyExterns.Length;i++) result.EmptyExterns[i]=new OriginalEmptyExternPlan {
                    OriginalType=reader.ReadString(),CompiledType=reader.ReadString(),OriginalCanonical=reader.ReadString(),CompiledCanonical=reader.ReadString(),
                    OriginalProviderMethodToken=reader.ReadUInt32(),OriginalAttributes=reader.ReadInt32(),OriginalImplAttributes=reader.ReadInt32(),OriginalSemantics=reader.ReadInt32() };
                result.SerializationFieldWitnesses=new SerializationFieldWitnessPlan[Count(reader,1000)];
                for(int i=0;i<result.SerializationFieldWitnesses.Length;i++) result.SerializationFieldWitnesses[i]=new SerializationFieldWitnessPlan {
                    OriginalType=reader.ReadString(),OriginalField=reader.ReadString(),RawCanonicalType=reader.ReadString(),LegacyCanonicalType=reader.ReadString(),
                    RawProviderFieldToken=reader.ReadUInt32(),LegacyProviderFieldToken=reader.ReadUInt32(),OriginalNativeFieldToken=reader.ReadUInt32(),OriginalNativeOwnerToken=reader.ReadUInt32() };
                '''+before;need(data.count(before)==1,'V6 missing-method reader hook differs');reader.write_text(data.replace(before,replacement))
    (codegen / 'Unity.RR23.OriginalMetadata.CodeGen.asmdef').write_text(json.dumps({'name': 'Unity.RR23.OriginalMetadata.CodeGen', 'references': [], 'includePlatforms': ['Editor'], 'overrideReferences': True, 'precompiledReferences': ['Mono.Cecil.dll'], 'autoReferenced': False}, indent=2) + '\n')
    cecil = WORKSPACE / 'Tools/RecoveryTools/MetadataProbe/Published/Mono.Cecil.dll'
    common = EDITOR / 'Data/Managed/Unity.CompilationPipeline.Common.dll'
    editor_dep = package / 'Assets/Editor/OriginalMetadataDependencies'; editor_dep.mkdir()
    shutil.copyfile(cecil, editor_dep / cecil.name)
    # Importer AutoReference disabled; CodeGen's asmdef explicitly owns it.
    (editor_dep / 'Mono.Cecil.dll.meta').write_text('fileFormatVersion: 2\nguid: ' + uuid.uuid4().hex + '\nPluginImporter:\n  serializedVersion: 2\n  isExplicitlyReferenced: 1\n  validateReferences: 1\n  platformData:\n  - first:\n      Any:\n    second:\n      enabled: 0\n      settings: {}\n  - first:\n      Editor: Editor\n    second:\n      enabled: 1\n      settings: {}\n')
    (codegen / 'csc.rsp').write_text('\n'.join([f'/reference:"{common}"', f'/resource:"{support_relative / support_manifest.name}",RR23.GeneralManifest', f'/resource:"{support_relative / support_raw.name}",RR23.RawMetadata', f'/resource:"{support_relative / support_serial.name}",RR23.SerializationMetadata']) + '\n')
    api = EDITOR / 'Data/MonoBleedingEdge/lib/mono/4.7.1-api'
    compiled = output / 'ToolBuild'; compiled.mkdir()
    shutil.copyfile(cecil, compiled / cecil.name); shutil.copyfile(common, compiled / common.name)
    lines = ['/noconfig', '/nostdlib+', '/langversion:8.0', '/optimize+', '/debug:portable', '/checksumalgorithm:SHA256']
    lines += [f'/reference:"{api / name}"' for name in ('mscorlib.dll', 'System.dll', 'System.Core.dll', 'Facades/netstandard.dll')]
    lines += [f'/reference:"{cecil}"', f'/reference:"{common}"', f'/resource:"{support_manifest}",RR23.GeneralManifest', f'/resource:"{support_raw}",RR23.RawMetadata', f'/resource:"{support_serial}",RR23.SerializationMetadata']
    lines += [f'"{codegen / name}"' for name in NAMES] + [f'"{codegen / name}"' for name in extras]
    (output / 'compile-checker.rsp').write_text('\n'.join(lines + ['/target:exe', f'/out:"{compiled / "CurrentCoreChecks.exe"}"', f'"{cli_source}"']) + '\n')
    (output / 'compile-codegen.rsp').write_text('\n'.join(lines + ['/target:library', f'/out:"{compiled / "Unity.RR23.OriginalMetadata.CodeGen.dll"}"']) + '\n')
    facade_relative=Path('CompilerSupport/References')
    facade_dir = package / facade_relative; facade_dir.mkdir(parents=True)
    facade_records, firstpass = [], []
    rsp = []
    for row in array_rows(references, 'assemblies'):
        if row['assembly_name'] == 'Assembly-CSharp-firstpass':
            need(not any(row[name] for name in ('types', 'methods', 'properties', 'events')) and row['compiler_only_required_in_modifiers'] == 0, 'Firstpass facade needs unproved special runtime routing')
            firstpass.append(row); continue
        path = Path(row['compiler_reference']['path']); need(sha(path) == row['compiler_reference']['sha256'], 'Compiler facade changed')
        target = facade_dir / path.name; shutil.copyfile(path, target)
        facade_records.append({'assembly_name': row['assembly_name'], 'runtime_reference': row['runtime_reference'], 'compiler_reference': {'path': str(target), 'sha256': sha(target)}})
        rsp.append(f'/reference:"{facade_relative / path.name}"')
    need(len(firstpass) == 1, 'Expected one automatically compiled firstpass assembly')
    existing_rsp = WORKSPACE / 'RR23/Assets/csc.rsp'
    (output / 'proposed-project-csc.rsp').write_text(existing_rsp.read_text() + '\n' + '\n'.join(rsp) + '\n')
    # Every actual staged C# byte must be pinned, including patched readers and
    # separately copied V6 policy/normalization/contract helpers.
    old_snapshots={Path(r['copy']).name:r for r in snapshots}
    snapshots=[{'source':old_snapshots.get(p.name,{}).get('source',str(HERE.parent/'RuntimeMetadataAudit'/p.name if p.name=='CoreCompilerAdapterNormalizer.cs' else HERE/p.name)),'copy':str(p),'sha256':sha(p),
                'upstream_snapshot_sha256':old_snapshots.get(p.name,{}).get('sha256')} for p in sorted(codegen.glob('*.cs'))]
    plan = {'schema': 'current-core-v5-integration-stage/v1', 'status': 'prepared_not_compiled_not_deployed', 'created_utc': datetime.now(timezone.utc).isoformat(),
            'mode': args.mode, 'original_source_type_absences': omitted, 'original_helper_exclusions': helper, 'whole_original_recovery_established': False,
            'method_subset_schema': 6 if method_audit else 5, 'explicit_unrecovered_original_method_count': cache.count('missing'),
            'method_binding_proof': {'path':str(args.method_audit.resolve()),'sha256':sha(args.method_audit)} if method_audit else None,
            'field_selector_amendment_proof': {'path':str(args.field_bindings.resolve()),'sha256':sha(args.field_bindings),'count':len(field_amendments)} if args.field_bindings else None,
            'inputs': input_records, 'original_metadata': raw, 'serialization_metadata': serial,
            'manifest': {'path': str(manifest), 'sha256': sha(manifest), 'bytes': manifest.stat().st_size}, 'counts': {**counts, **{kind: cache.count(kind) for kind in ('inventory', 'typealias', 'methodalias', 'fieldalias', 'definition', 'readonly')}},
            'project_relative_editor_support_outside_Assets': [{'project_relative_path': str(p.relative_to(package)), 'path': str(p), 'sha256': sha(p)} for p in (support_manifest, support_raw, support_serial)],
            'source_snapshots': snapshots, 'patched_engine': {'path': str(checked_engine), 'sha256': sha(checked_engine), 'change': 'Add strict original type/layout/base/interface/generic contract validation; no body changes'},
            'tool_dependencies': [{'path': str(p), 'sha256': sha(p)} for p in (cecil, common)],
            'compiler_facades_outside_Assets': facade_records, 'automatic_firstpass_requires_contract_check_not_facade_duplicate': firstpass,
            'proposed_project_response': {'path': str(output / 'proposed-project-csc.rsp'), 'sha256': sha(output / 'proposed-project-csc.rsp')},
            'runtime_plugin_meta_requirement': 'Disable AutoReference only for each matching runtime plugin while preserving original GUID, binary and platform compatibility; never copy compiler facades into Assets.',
            'editor_only_code_generation': {'name': 'Unity.RR23.OriginalMetadata.CodeGen', 'includePlatforms': ['Editor'], 'autoReferenced': False, 'Cecil_editor_only': True},
            'numeric_metadata_tokens_preserved': False, 'identity_provenance': 'Original canonical type/method/field selectors and original source-token witnesses; Cecil numeric tokens/RVAs relocate.',
            'target_matrix': [{'target': t, 'status': 'requires actual Unity target compiler/ILPP and runtime dependency audit'} for t in ('WindowsPC', 'WindowsPCVR', 'Android', 'MetaQuestAndroid', 'iOS')],
            'installed_playback_engines': [p.name for p in (EDITOR / 'Data/PlaybackEngines').iterdir() if p.is_dir()],
            'no_forced_runtime_platform_defines': True, 'known_gates': ['Full current compiled-core DLL/PDB + unique inventory roundtrip pending zero-error csc', 'Original type/generic metadata mismatches fail closed', 'Firstpass facade-free actual contract check pending', 'Actual Unity CodeGen discovery/player compile needed', 'Platform-specific build modules/SDK/native dependencies need separate validation'],
            'project_changed': False, 'game_code_executed': False, 'cache_policy': {'sqlite_cache_bytes': 8 * 1024 * 1024, 'json_max_row_bytes': 16 * 1024 * 1024}}
    if method_audit:
        plan['schema']='current-core-v6-integration-stage/v1'
        plan['original_method_policy']={'bound_emitted':cache.count('binding'),'explicit_unrecovered':cache.count('missing'),'proven_forwarding_adapters_removed':len(adapter_rows),'proven_implicit_marker_ctor_removed':len(ctor_rows),'no_missing_body_manufactured':True}
        plan['unresolved_original_import_maps']={'exact_emitted_original_count':cache.count('extern'),'original_flags_and_RVA0_preserved':True,'import_maps_invented':False,'native_import_callability_established':False,'Cecil_and_matching_Mono_null_map_fixture':'Validation/NullImportMapProbe-20261022T112336Z-b2174bf7/report.json'}
        plan['serialization_provider_TypeSpec_defect_witnesses']={'count':len(serialization_witnesses),'path':str(witness_path),'sha256':sha(witness_path),'native_raw_types_preserved':True,'legacy_provider_used_for_attributes_only':True}
        proofs=[ROOT/'Validation/TypeContractInventory-20261022T104716Z-17065fb7'/name for name in ('report.json','differences.json','native-type-flag-proof.json')]
        proofs+=[ROOT/'Validation/NativeProvenMetadata-20261022T044738Z-07362349/report.json']
        proofs+=[ROOT/'Validation/CoreMethodFlagsInventory-20261022T110755Z-0be64abb/native-join-report.json']
        proofs+=[ROOT/'Validation/CoreExtraAudit-20261022T111140Z'/name for name in ('report.json','property-metadata-missing.json')]
        proofs+=[ROOT/'Validation/SinglePropertySemantics-20261022T123726Z-8809a4aa'/name for name in ('semantics.json','native-property-ownership.json')]
        proofs+=[ROOT/'Validation/MetadataRoundTripDiagnosticsFixtures-20261022T123330Z-05de3aaf/report.json']
        proofs+=[WORKSPACE/'Tools/RecoveryTools/RuntimeMetadataAudit/NestedTypeCache-20261022T121000Z/proof.json']
        proofs+=[WORKSPACE/'Tools/RecoveryTools/RuntimeMetadataAudit/ExactResolverFixtures-20261022T122500Z/Cases/fixture-proof.json']
        plan['original_metadata_contract_proofs']=[{'path':str(p),'sha256':sha(p)} for p in proofs]
        plan['serialization_provider_equivalence']={'existing_provider_sha256':serial['sha256'],'native_proven_core_sha256':sha(ROOT/'Validation/NativeProvenMetadata-20261022T044738Z-07362349/Managed/Assembly-CSharp.dll'),'identical':True,'no_serialization_attribute_downgrade':True}
        need(plan['serialization_provider_equivalence']['native_proven_core_sha256']==serial['sha256'],'Native-proven serialization provider differs')
    cache.db.close()
    need(all(sha(Path(r['path'])) == r['sha256'] for r in input_records), 'Input manifest changed during staging')
    (output / 'stage-plan.json').write_text(json.dumps(plan, indent=2) + '\n')
    print(json.dumps({'stage': str(output), 'plan': str(output / 'stage-plan.json'), 'manifest_bytes': manifest.stat().st_size, 'original_absences': omitted, 'project_changed': False}))


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, required=True)
    parser.add_argument('--references', type=Path, required=True)
    parser.add_argument('--output', type=Path, required=True)
    parser.add_argument('--mode', choices=['emitted-original-subset', 'whole-original'], required=True)
    parser.add_argument('--method-audit', type=Path)
    parser.add_argument('--field-bindings', type=Path)
    prepare(parser.parse_args())
