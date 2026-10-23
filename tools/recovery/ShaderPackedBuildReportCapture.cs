using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.Build.Reporting;
using UnityEngine;

// Capture actual Unity2020 API values, without inferring native PathID semantics.
// The pure mapper must corroborate every selected record against Class48 tables.
public static class ShaderPackedBuildReportCapture
{
    [Serializable] public sealed class FileRecord { public string id, path; }
    [Serializable] public sealed class ShaderRecord
    {
        public string file_id, short_path, id, offset, packed_size;
        public string source_guid, source_path, type;
    }
    [Serializable] public sealed class Data
    {
        public string schema = "Unity2020-actual-packed-Shader-API-records/v1";
        public FileRecord[] files;
        public ShaderRecord[] shaders;
        public bool native_identity_or_offset_semantics_assumed = false;
    }
    public static Data Capture(BuildReport report)
    {
        if (report == null) throw new ArgumentNullException("report");
        var files = new List<FileRecord>();
        foreach (BuildFile file in report.files)
            files.Add(new FileRecord { id = file.id.ToString(CultureInfo.InvariantCulture), path = file.path });
        var shaders = new List<ShaderRecord>();
        foreach (PackedAssets packed in report.packedAssets)
            foreach (PackedAssetInfo asset in packed.contents)
            {
                if (asset.type != typeof(Shader)) continue;
                shaders.Add(new ShaderRecord {
                    file_id = packed.file.ToString(CultureInfo.InvariantCulture), short_path = packed.shortPath,
                    id = asset.id.ToString(CultureInfo.InvariantCulture), offset = asset.offset.ToString(CultureInfo.InvariantCulture),
                    packed_size = asset.packedSize.ToString(CultureInfo.InvariantCulture), source_guid = asset.sourceAssetGUID.ToString(),
                    source_path = asset.sourceAssetPath, type = asset.type.FullName
                });
            }
        return new Data { files = files.ToArray(), shaders = shaders.ToArray() };
    }
}
