"""Prove both original version getter bodies and stage an uninstalled C# patch."""
from pathlib import Path
import datetime as dt
import difflib
import hashlib
import json
import mmap
import struct
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / "Recovery/RecRoom-2023-04-18"
sys.path[:0] = [str(HERE), str(HERE.parent / "ConstructorEvidence")]
from collect_all_pinvoke_native import ExternMetadata
from inventory_recroom_game_root_native import region
from audit_ogpeg_constructors import Decoder, fields

SOURCE = WS / "RR23/Assets/Scripts/Assembly-CSharp/IDDIAODMAPP.cs"
SOURCE_SHA = "60c70b6b7af7bdbd9735a0829fe9279a8001e17255cdf3f40cae0bfea70943a2"
PROJECTION = ROOT / "Validation/BodySourceStreamRebase-20261022T150601Z-f74c827a/metadata-restoration.json"
CLASS = 0x1887202A8
LITERAL = 0x1887C6AC8
META_INIT = 0x1806C01E0
CLASS_INIT = 0x180640F10
BARRIER = 0x1806BFD30


def need(value, message):
    if not value:
        raise ValueError(message)


def sha(path):
    with Path(path).open("rb") as stream:
        return hashlib.file_digest(stream, "sha256").hexdigest()


def pin(path):
    return {"path": str(path), "sha256": sha(path), "bytes": Path(path).stat().st_size}


def ready_rcx(d):
    d.literal("f6 81 33 01 00 00 04")
    skip1 = d.short("74")
    d.literal("83 b9 e0 00 00 00 00")
    skip2 = d.short("75")
    call = d.relative("e8")
    reload = d.relative("48 8b 0d")
    need(skip1 == skip2 == d.va + d.at and call == CLASS_INIT and reload == CLASS, "Exact original class initialization guard")


def static_getter(code, va):
    d = Decoder(code, va)
    d.literal("48 83 ec 28")
    flag = d.relative("80 3d", "00")
    loaded = d.short("75")
    klass = d.relative("48 8d 0d")
    init = d.relative("e8")
    written = d.relative("c6 05", "01")
    need(flag == written and loaded == d.va + d.at and klass == CLASS and init == META_INIT, "Exact original getter metadata initialization")
    need(d.relative("48 8b 0d") == CLASS, "Exact original getter class receiver")
    ready_rcx(d)
    d.literal("48 8b 81 b8 00 00 00 48 83 38 00")
    nonnull = d.relative("0f 85")
    ready_rcx(d)
    flag2 = d.relative("80 3d", "00")
    loaded2 = d.short("75")
    klass2 = d.relative("48 8d 0d")
    init2 = d.relative("e8")
    literal = d.relative("48 8d 0d")
    init3 = d.relative("e8")
    reloaded = d.relative("48 8b 0d")
    written2 = d.relative("c6 05", "01")
    need(flag2 == written2 and loaded2 == d.va + d.at and klass2 == reloaded == CLASS and literal == LITERAL and init2 == init3 == META_INIT, "Exact null-cache literal initialization")
    ready_rcx(d)
    d.literal("48 8b 89 b8 00 00 00")
    need(d.relative("48 8b 15") == LITERAL, "Exact original version literal loaded")
    d.literal("48 89 11")
    need(d.relative("e8") == BARRIER, "Exact original static reference store write barrier")
    need(d.relative("48 8b 0d") == CLASS and nonnull == d.va + d.at, "Cached and initialized paths join")
    d.literal("f6 81 33 01 00 00 04")
    fast1 = d.short("74")
    d.literal("83 b9 e0 00 00 00 00")
    fast2 = d.short("75")
    need(d.relative("e8") == CLASS_INIT and d.relative("48 8b 05") == CLASS, "Return path initialization")
    d.literal("48 8b 80 b8 00 00 00 48 8b 00 48 83 c4 28 c3")
    need(fast1 == fast2 == d.va + d.at, "Fast return branch join")
    d.literal("48 8b 81 b8 00 00 00 48 8b 00 48 83 c4 28 c3")
    d.end()
    return {"semantic_body": "if (EOGFAFNNICF == null) EOGFAFNNICF = original literal3451; return EOGFAFNNICF;",
            "cache_static_field_offset": 0, "null_only_test": True, "preexisting_empty_or_nonnull_cache_preserved": True,
            "all_native_bytes_opcodes_registers_branches_runtime_targets_and_stack_balance_checked": len(code)}


def nested_getter(code, va):
    d = Decoder(code, va)
    d.literal("48 83 ec 28")
    flag = d.relative("80 3d", "00")
    loaded = d.short("75")
    klass = d.relative("48 8d 0d")
    init = d.relative("e8")
    written = d.relative("c6 05", "01")
    need(flag == written and loaded == d.va + d.at and klass == CLASS and init == META_INIT, "Exact original adapter metadata initialization")
    need(d.relative("48 8b 0d") == CLASS, "Adapter class receiver")
    d.literal("f6 81 33 01 00 00 04")
    skip1 = d.short("74")
    d.literal("83 b9 e0 00 00 00 00")
    skip2 = d.short("75")
    need(d.relative("e8") == CLASS_INIT and skip1 == skip2 == d.va + d.at, "Adapter class initialization guard")
    d.literal("33 c9 48 83 c4 28")
    target = d.relative("e9")
    d.end()
    need(target == 0x1809148E0, "Adapter tailcalls exact original static getter")
    return {"semantic_body": "return IDDIAODMAPP.OLGKJALIAAI;", "static_tail_target": hex(target),
            "instance_this_not_read": True, "all_native_bytes_opcodes_registers_branches_runtime_targets_and_stack_balance_checked": len(code)}


def binding_records():
    # Stream only the two type objects; do not load the large projection manifest.
    wanted = {"IDDIAODMAPP", "IDDIAODMAPP/ONPIJEFNLPD"}
    result = []
    with PROJECTION.open(encoding="utf-8") as stream:
        for line in stream:
            if not any('"original_full_name": "' + owner + '"' in line for owner in wanted):
                continue
            lines = ["    {\n", line]
            for more in stream:
                lines.append(more)
                if more.startswith("    },") or more.rstrip() == "    }":
                    break
            value = json.loads("".join(lines).strip().rstrip(","))
            owner = value["original_full_name"]
            if owner not in wanted:
                continue
            props = [p for p in value.get("properties", []) if p["original_name"] == "OLGKJALIAAI"]
            need(len(props) == 1 and props[0]["compiled_name"] == "OLGKJALIAAI" and props[0]["original_getter"]["name"] == "PAKNGFLMDPE", "Original PropertyDef-to-current alias binding")
            methods = props[0]["methods"]
            need(len(methods) == 1 and methods[0]["compiled"]["name"] == "get_OLGKJALIAAI" and methods[0]["original"]["name"] == "PAKNGFLMDPE", "Exact compiled getter alias")
            result.append({"owner": owner, "property": props[0]})
            wanted.remove(owner)
            if not wanted:
                break
    need(not wanted and len(result) == 2, "Both source alias bindings required")
    return result


def getter_span(text, declaration, require_stub=True):
    need(text.count(declaration) == 1, "Unique current source property declaration")
    start = text.index(declaration)
    get = text.index("get", start)
    opening = text.index("{", get)
    depth = 1
    at = opening + 1
    while depth:
        depth += (text[at] == "{") - (text[at] == "}")
        at += 1
    if require_stub:
        need(text[opening:at].strip()[1:-1].strip() == "return null;", "Exact original current stub body required")
    return opening, at


def main():
    need(sha(SOURCE) == SOURCE_SHA, "Current Main getter source changed; proposal refused")
    original = SOURCE.read_bytes()
    aliases = binding_records()
    paths = [ROOT / "VerifiedSource/GameAssembly.dll", ROOT / "VerifiedSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat"]
    rows = []
    with paths[0].open("rb") as bf, paths[1].open("rb") as mf, mmap.mmap(bf.fileno(), 0, access=mmap.ACCESS_READ) as binary, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as metadata:
        view = ExternMetadata(binary, metadata)
        klass = view.usage(CLASS)
        literal_usage = view.usage(LITERAL)
        need(klass["kind"] == 1 and klass["type"] == "IDDIAODMAPP" and literal_usage["kind"] == 5 and literal_usage["index"] == 3451, "Exact original class and literal metadata usage")
        at = view.row("stringLiteral", 3451, 8)
        length, offset = struct.unpack_from("<ii", metadata, at)
        start, _ = view.tables["stringLiteralData"]
        need(bytes(metadata[start + offset:start + offset + length]) == b"20230414", "Exact original version literal bytes")
        cache = [f for f in fields(view, "IDDIAODMAPP") if f["name"] == "EOGFAFNNICF"]
        need(len(cache) == 1 and cache[0]["offset"] == 0 and cache[0]["type"] == "System.String" and cache[0]["native_type"]["attributes"] == 17, "Exact original private static String cache field")
        for index, token, owner, static, decoder in [(195787, 0x06001544, "IDDIAODMAPP", True, static_getter), (195794, 0x0600154B, "IDDIAODMAPP/ONPIJEFNLPD", False, nested_getter)]:
            method = view.method_info(index)
            need(method["owner"] == owner and int(method["token"], 16) == token and method["name"] == "PAKNGFLMDPE" and method["return"] == "System.String" and not method["parameters"] and bool(method["flags"] & 0x10) == static and method["generic_container_index"] == -1, "Exact original getter owner/token/signature")
            va = view.method_pointer(method)
            native = region(view, va)
            code = bytes.fromhex(native["bytes"])
            proof = decoder(code, va)
            rejected = 0
            for position in range(len(code)):
                changed = bytearray(code)
                changed[position] ^= 1
                try:
                    decoder(bytes(changed), va)
                except (ValueError, struct.error):
                    rejected += 1
                else:
                    raise RuntimeError("Native mutation accepted at " + str(position))
            rows.append({"original": method, "VA": hex(va), "complete_runtime_function": native, "whole_opcode_controlflow_proof": proof,
                         "negative_controls": {"single_byte_xor1_per_byte": len(code), "all_rejected": rejected == len(code)}})
    text = original.decode("utf-8")
    need('private const string PJHKENLEHPN = "20230414";' in text and "private static string EOGFAFNNICF;" in text, "Exact current literal alias/cache declarations")
    nested = getter_span(text, "public string OLGKJALIAAI")
    static = getter_span(text, "public static string OLGKJALIAAI")
    replacements = [(nested, "{\n\t\t\treturn IDDIAODMAPP.OLGKJALIAAI;\n\t\t}"),
                    (static, "{\n\t\tif (EOGFAFNNICF == null)\n\t\t{\n\t\t\tEOGFAFNNICF = PJHKENLEHPN;\n\t\t}\n\t\treturn EOGFAFNNICF;\n\t}")]
    proposed = text
    for (begin, end), body in sorted(replacements, reverse=True):
        proposed = proposed[:begin] + body + proposed[end:]
    def outside(value, spans):
        for begin, end in sorted(spans, reverse=True):
            value = value[:begin] + value[end:]
        return value
    proposed_spans = [getter_span(proposed, declaration, False) for declaration in ("public string OLGKJALIAAI", "public static string OLGKJALIAAI")]
    need(outside(text, [nested, static]) == outside(proposed, proposed_spans), "All bytes outside two getter bodies must remain exact")
    out = ROOT / "Validation" / ("OriginalProtocolVersionGetters-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    (out / "IDDIAODMAPP.before.cs").write_bytes(original)
    (out / "IDDIAODMAPP.proposed.cs").write_bytes(proposed.encode("utf-8"))
    need((out / "IDDIAODMAPP.proposed.cs").read_bytes() == proposed.encode("utf-8"), "Exact proposed source bytes required")
    (out / "two-original-version-getters.patch").write_bytes("".join(difflib.unified_diff(text.splitlines(keepends=True), proposed.splitlines(keepends=True), fromfile="a/Assets/Scripts/Assembly-CSharp/IDDIAODMAPP.cs", tofile="b/Assets/Scripts/Assembly-CSharp/IDDIAODMAPP.cs")).encode("utf-8"))
    report = {"schema": "two-original-protocol-version-getters-native-proof-and-source-proposal/v1", "status": "native_proven_source_proposed_not_compiled_or_installed",
              "current_source": pin(SOURCE), "current_meta": pin(Path(str(SOURCE) + ".meta")), "source_projection": pin(PROJECTION),
              "current_alias_to_original_property_bindings": aliases, "cache_field": cache[0], "literal_metadata_usage": literal_usage,
              "original_literal_index": 3451, "original_literal": "20230414", "native_proofs": rows,
              "proposed_source": pin(out / "IDDIAODMAPP.proposed.cs"), "patch": pin(out / "two-original-version-getters.patch"),
              "scope": "Only two existing getter bodies; no declarations, fields, method signatures, attributes, meta, auth request factories or UI changed",
              "all_bytes_outside_two_getter_bodies_exact": True,
              "backend_protocol_version": "20230414", "display_bundle_version_remains_root_build_setting": "20261022",
              "limitations": ["No compilation, managed execution, client request, login or network health proof performed.", "This restores only the native default cache and nested forwarding behavior. Other version override methods remain outside this patch.", "Larger router, request factory, authentication and startup stubs remain separate blockers. Metadata restoration must retain both original getter identities as it already does."],
              "Main_source_unchanged": SOURCE.read_bytes() == original, "backend_modified": False, "managed_or_original_native_or_Unity_code_executed": False,
              "network_requests": 0, "compiler_launched": False, "tool": pin(Path(__file__))}
    (out / "report.json").write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"report": str(out / "report.json"), "status": report["status"], "negative_controls": sum(r["negative_controls"]["single_byte_xor1_per_byte"] for r in rows), "Main_source_unchanged": report["Main_source_unchanged"]}))


if __name__ == "__main__":
    main()
