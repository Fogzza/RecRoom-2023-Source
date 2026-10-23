"""Select AG by full retained data identity, then stage original six fields only."""
from pathlib import Path
import datetime as dt
import hashlib
import json
import re
import struct
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / "Recovery/RecRoom-2023-04-18"
sys.path.insert(0, str(HERE))
from compare_shader_parsed_form import compare, field_lines
from stage_original_stencil_shader import spans, strip_fields, NAMES, uint_hex

MODELS = ROOT / "AssetRecovery/OriginalAGShaderModels-20261022T203556Z-4b62253a"
MAIN = WS / "RR23/Assets/Shader/AG_Standard-Opaque.asset"
MAIN_SHA = "845e08ebc9d2a02256029718e35282bfbecaac9c0912902167b1d0ad33625a88"
META_SHA = "2aec33e50f23c224798affbba08b769a6171162063032e02963bd97560e018f0"


def need(value, message):
    if not value:
        raise RuntimeError(message)


def sha(path):
    with Path(path).open("rb") as stream:
        return hashlib.file_digest(stream, "sha256").hexdigest()


def pin(path):
    return {"path": str(path), "sha256": sha(path), "bytes": Path(path).stat().st_size}


def typed_identity(path):
    lines = field_lines(path, "m_ParsedForm")
    residual, passes, presentation = [], [], {"trailing_YAML_whitespace": 0, "exact_noninit_string_quote_spelling": 0}
    current = None
    at = 0
    while at < len(lines):
        line = lines[at]
        if line.lstrip().startswith("- m_EditorDataHash:"):
            current = {"name_indices": {}, "m_LocalKeywordMask": None, "m_GlobalKeywordMask": None}
            passes.append(current)
        match = re.fullmatch(r"(\s+)(m_(?:Local|Global)KeywordMask):\s*([0-9a-f]*)\s*", line)
        if match:
            need(current is not None and current[match[2]] is None, "Unique per-pass UInt16 mask field required")
            encoded = bytes.fromhex(match[3])
            need(len(encoded) % 2 == 0, "Original mask UInt16 width")
            current[match[2]] = {"hex": match[3], "UInt16_values": [x[0] for x in struct.iter_unpack("<H", encoded)]}
            residual.append(match[1] + match[2] + ":<typed-mask-compared-separately>")
            at += 1
            continue
        match = re.fullmatch(r"(\s+)m_NameIndices:\s*(\{\})?\s*", line)
        if match:
            need(current is not None, "Name-index map must belong to a known pass")
            indent = len(match[1])
            residual.append(match[1] + "m_NameIndices:<typed-map-compared-separately>")
            at += 1
            while at < len(lines) and lines[at] and len(lines[at]) - len(lines[at].lstrip(" ")) > indent:
                pair = re.fullmatch(r"\s+([^:]+): (-?\d+)\s*", lines[at])
                need(pair is not None and pair[1] not in current["name_indices"], "Unique String/Int32 native name-index map required")
                value = int(pair[2])
                need(-2**31 <= value < 2**31, "Native map Int32 range")
                current["name_indices"][pair[1]] = value
                at += 1
            continue
        value = line.rstrip()
        presentation["trailing_YAML_whitespace"] += value != line
        if "'<noninit>'" in value:
            presentation["exact_noninit_string_quote_spelling"] += 1
            value = value.replace("'<noninit>'", "<noninit>")
        residual.append(value)
        at += 1
    need(passes and all(p["m_LocalKeywordMask"] is not None and p["m_GlobalKeywordMask"] is not None for p in passes), "Complete per-pass mask inventory")
    return {"lines": lines, "residual": residual, "passes": passes, "presentation": presentation}


def compatible(original, current):
    findings, omitted = [], []
    if len(original["passes"]) != len(current["passes"]):
        findings.append("pass_count_differs")
    for index, (old, now) in enumerate(zip(original["passes"], current["passes"])):
        for kind in ("m_LocalKeywordMask", "m_GlobalKeywordMask"):
            if now[kind]["hex"] != "" and old[kind]["hex"] != now[kind]["hex"]:
                findings.append({"pass": index, "field": kind, "reason": "existing_nonempty_UInt16_mask_differs"})
            if old[kind]["hex"] != now[kind]["hex"]:
                omitted.append({"pass": index, "field": kind, "original": old[kind], "current": now[kind]})
        for name, value in now["name_indices"].items():
            if old["name_indices"].get(name) != value:
                findings.append({"pass": index, "map_key": name, "current_Int32": value, "original_Int32": old["name_indices"].get(name)})
        missing = {key: value for key, value in old["name_indices"].items() if key not in now["name_indices"]}
        if missing:
            omitted.append({"pass": index, "field": "m_NameIndices", "missing_original_entries": missing})
    residual_equal = original["residual"] == current["residual"]
    if not residual_equal:
        findings.append("retained_non-mask_non-map_serialized_data_differs")
    return {"matches_all_retained_typed_data": not findings, "retained_residual_lines_exact_after_explicit_presentation_only": residual_equal,
            "residual_line_count_original": len(original["residual"]), "residual_line_count_current": len(current["residual"]),
            "residual_sha256_original": hashlib.sha256(("\n".join(original["residual"]) + "\n").encode()).hexdigest(),
            "residual_sha256_current": hashlib.sha256(("\n".join(current["residual"]) + "\n").encode()).hexdigest(),
            "pass_count_original": len(original["passes"]), "pass_count_current": len(current["passes"]),
            "rejected_existing_value_differences": findings[:32], "missing_original_keyword_data": omitted,
            "presentation_only": {"original": original["presentation"], "current": current["presentation"]},
            "numeric_value_or_float_text_normalization": False,
            "omission_policy": "Only absent UInt16 pass masks and absent String/Int32 name-map entries may be restored. Every existing map key/value and all other numeric/text/order data must agree."}


def main():
    need(sha(MAIN) == MAIN_SHA and sha(Path(str(MAIN) + ".meta")) == META_SHA, "Current original Main AG/meta pins changed")
    source_report = json.loads((MODELS / "report.json").read_bytes())
    need(len(source_report["models"]) == 2 and all(x["exit_code"] == 0 for x in source_report["phases"]), "Two complete original model reads required")
    raw = MAIN.read_bytes()
    meta = Path(str(MAIN) + ".meta").read_bytes()
    current = typed_identity(MAIN)
    choices, comparisons = [], []
    for variant in source_report["models"]:
        need(sha(Path(variant["model"]["path"])) == variant["model"]["sha256"] and sha(Path(variant["ParsedForm"]["path"])) == variant["ParsedForm"]["sha256"], "Pinned complete model output changed")
        identity = typed_identity(Path(variant["ParsedForm"]["path"]))
        proof = compatible(identity, current)
        comparisons.append({"variant": variant["variant"], "source": variant["original_provenance"], "proof": proof})
        if proof["matches_all_retained_typed_data"]:
            choices.append((variant, identity))
    need(len(choices) == 1 and choices[0][0]["variant"] == "native", "Unique original retained-data match required; never choose by shader name")
    selected, identity = choices[0]
    model_path = Path(selected["model"]["path"])
    model = json.loads(model_path.read_bytes())
    fields = model["fields"]
    original_object = Path(model["source"])
    original = original_object.read_bytes()
    need(hashlib.sha256(original).hexdigest() == model["source_sha256"] and model["consumed_bytes"] == model["total_bytes"] == len(original) and model["no_pointer_yaml"], "Complete original source model identity")
    blob_info = fields["compressedBlob"]
    needle = struct.pack("<I", blob_info["bytes"])
    matches = []
    start = 0
    while True:
        at = original.find(needle, start)
        if at < 0:
            break
        start = at + 1
        blob = original[at + 4:at + 4 + blob_info["bytes"]]
        if len(blob) == blob_info["bytes"] and hashlib.sha256(blob).hexdigest() == blob_info["sha256"]:
            matches.append((at + 4, blob))
    need(len(matches) == 1, "Unique full length-prefixed original program range required")
    blob_offset, blob = matches[0]
    newline = b"\r\n" if b"\r\n" in raw else b"\n"
    replacements = {"m_ParsedForm": newline.join(("  " + line).encode() for line in identity["lines"]) + newline,
                    "platforms": ("  platforms: " + uint_hex(fields["Platforms"])).encode() + newline,
                    "compressedBlob": ("  compressedBlob: " + blob.hex()).encode() + newline}
    for name, key in [("offsets", "Offsets"), ("compressedLengths", "CompressedLengths"), ("decompressedLengths", "DecompressedLengths")]:
        arrays = fields[key + "_AssetList_AssetList_UInt32"]
        replacements[name] = newline.join([("  " + name + ":").encode()] + [("  - " + uint_hex(row)).encode() for row in arrays]) + newline
    old = spans(raw)
    candidate = raw
    for name in sorted(NAMES, key=lambda n: old[n][0], reverse=True):
        begin, end = old[name]
        candidate = candidate[:begin] + replacements[name] + candidate[end:]
    after = spans(candidate)
    need(strip_fields(candidate) == strip_fields(raw), "All bytes outside exact six fields must stay unchanged")
    for name in NAMES:
        need(candidate[slice(*after[name])] == replacements[name], "Exact original field serialization mismatch: " + name)
    need(raw[slice(*old["m_Dependencies"])] == candidate[slice(*after["m_Dependencies"])], "Original current dependency PPtrs changed")
    out = ROOT / "AssetRecovery" / ("OriginalAGShaderCandidate-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    asset = out / MAIN.name
    asset.write_bytes(candidate)
    Path(str(asset) + ".meta").write_bytes(meta)
    (out / "original-compressedBlob.bin").write_bytes(blob)
    (out / "typed-original-variant-selection.json").write_bytes((json.dumps({"schema": "unique-original-AG-retained-data-selection/v1", "selected": "native", "compared_original_variants": comparisons,
        "export_GUID_to_PathID_receipt_available": False, "selection_is_complete_retained_data_identity_not_GUID_provenance_or_shader_name": True}, indent=2) + "\n").encode())
    exact_form = compare(Path(model["parsed_form"]["path"]), asset)
    need(exact_form["status"] == "exact", "Entire staged ParsedForm differs from original")
    counts = {"properties": sum(x.startswith("    - m_Name:") for x in identity["lines"]), "subshaders": sum(x.startswith("  - m_Passes:") for x in identity["lines"]),
              "passes": len(identity["passes"]), "subprogram_blob_indices": sum(x.lstrip().startswith("m_BlobIndex:") for x in identity["lines"]),
              "partial_CB_rows_original": sum("m_IsPartialCB: 1" in x for x in identity["lines"]), "nonempty_local_keyword_masks_original": sum(bool(x["m_LocalKeywordMask"]["hex"]) for x in identity["passes"]),
              "nonempty_global_keyword_masks_original": sum(bool(x["m_GlobalKeywordMask"]["hex"]) for x in identity["passes"])}
    result = {"schema": "original-AG-six-field-shader-candidate/v1", "status": "original_data_staged_not_import_validated", "source_models": pin(MODELS / "report.json"),
              "selected_original_model": pin(model_path), "selected_original_object": pin(original_object), "selected_original_container_identity": selected["original_provenance"]["source_object"],
              "selection_proof": pin(out / "typed-original-variant-selection.json"), "Main_before": pin(MAIN), "Main_meta_before": pin(Path(str(MAIN) + ".meta")),
              "candidate": pin(asset), "candidate_meta": pin(Path(str(asset) + ".meta")), "entire_original_ParsedForm_exact": exact_form,
              "replaced_fields": list(NAMES), "counts": counts, "platforms": fields["Platforms"], "program_array_dimensions": model["program_array_dimensions"],
              "program_arrays": {key: fields[key + "_AssetList_AssetList_UInt32"] for key in ("Offsets", "CompressedLengths", "DecompressedLengths")},
              "original_program_blob": {"bytes": len(blob), "sha256": hashlib.sha256(blob).hexdigest(), "offset_in_original_object": blob_offset, "unique_length_prefixed_range_matches": True},
              "all_bytes_outside_six_fields_exact": True, "current_dependency_pptr_block_exact": True, "original_meta_all_bytes_preserved": True,
              "no_partial_CB_flags_cleared": True, "no_shader_or_pipeline_substitution": True, "Main_modified": False, "Editor_launched": False,
              "limitations": ["No retained export receipt directly binds Main GUID to original PathID. Selection instead uniquely matches all retained serialized data; bundled alternative fails existing map integers and subprogram data.",
                "Entire original ParsedForm and five program fields are staged. No hand-edited CB flags, guessed HLSL, shader substitution or Main application.",
                "Isolated matching Editor import/native retention/reload and actual graphics support remain unproved. Existing observer100000property walk bound may be too small for this larger shader and needs separately reviewed adjustment."],
              "tool": pin(Path(__file__))}
    need(sha(MAIN) == MAIN_SHA and sha(Path(str(MAIN) + ".meta")) == META_SHA, "Main changed during staging")
    (out / "report.json").write_bytes((json.dumps(result, indent=2) + "\n").encode())
    print(json.dumps({"report": str(out / "report.json"), "status": result["status"], "candidate": str(asset), "counts": counts, "candidate_sha256": result["candidate"]["sha256"]}))


if __name__ == "__main__":
    main()
