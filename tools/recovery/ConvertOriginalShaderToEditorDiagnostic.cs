using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;
using AssetRipper.Assets;
using AssetRipper.Assets.Bundles;
using AssetRipper.Assets.IO.Writing;
using AssetRipper.Assets.Metadata;
using AssetRipper.IO.Endian;
using AssetRipper.Primitives;
using AssetRipper.SourceGenerated.Classes.ClassID_48;
using AssetRipper.Export.UnityProjects;
using AssetRipper.Yaml;

// Pure generated-data-model conversion. No Unity/native API, game code or assembly export.
internal static class ConvertOriginalShaderToEditor
{
    static string Sha(byte[] b) => Convert.ToHexString(SHA256.HashData(b)).ToLowerInvariant();
    static void Need(bool value,string message) { if (!value) throw new InvalidDataException(message); }
    static byte[] Serialize(IShader shader, bool editor)
    {
        using var stream = new MemoryStream();
        using (var writer = new AssetWriter(stream,shader.Collection))
        {
            if (editor) shader.WriteEditor(writer); else shader.WriteRelease(writer);
        }
        return stream.ToArray();
    }
    static string Form(IShader shader, UnityVersion version)
    {
        var walker = new NoPointerWalker();walker.WithUnityVersion(version);
        var document = new YamlDocument();document.CreateMappingRoot().Add("m_ParsedForm",walker.ExportYamlNode(shader.ParsedForm));
        var writer = new YamlWriter();writer.AddDocument(document);using var text = new StringWriter();writer.Write(text);return text.ToString();
    }
    static object Shape(object value)
    {
        if (value is IEnumerable items && !(value is string)) { var result=new List<object>();foreach(var item in items)result.Add(Shape(item));return result; }
        return value;
    }
    static Dictionary<string,object> Fields(IShader shader)
    {
        var result = new Dictionary<string,object>();
        foreach(string key in new[]{"Platforms","Offsets_AssetList_AssetList_UInt32","CompressedLengths_AssetList_AssetList_UInt32","DecompressedLengths_AssetList_AssetList_UInt32"})
        {
            var property=typeof(IShader).GetProperty(key);Need(property!=null,"Exact matching original field unavailable:"+key);result[key]=Shape(property.GetValue(shader));
        }
        result["compressedBlob"]=new{bytes=shader.CompressedBlob.Length,sha256=Sha(shader.CompressedBlob)};return result;
    }
    static void Main(string[] args)
    {
        Need(args.Length==4,"releaseObject expectedSHA exactName freshOutput required");
        byte[] original=File.ReadAllBytes(args[0]);Need(original.Length==3656 && Sha(original)==args[1],"Exact original self-contained release object");
        Need(!Directory.Exists(args[3]),"Fresh conversion output required");Directory.CreateDirectory(args[3]);
        var version=UnityVersion.Parse("2020.3.33f1");var bundle=new ProcessedBundle("OriginalShaderEditorLayoutRoundtrip");var collection=bundle.AddNewProcessedCollection("original-shader-only",version);
        IShader shader=Shader.Create(new AssetInfo(collection,4800000,48),version);
        var input=new EndianSpanReader(original,EndianType.LittleEndian);shader.ReadRelease(ref input);
        Need(input.Position==input.Length && shader.Name_R.ToString()==args[2] && shader.GetType().Name=="Shader_2020_3_16","Exact full release model/name proof");
        Need(shader.CompressedBlob.Length==991 && Sha(shader.CompressedBlob)=="9b790d373ca12221c4cc3b81efab7712e70687d0ddf443db242a5dadc4c5cfbc","Exact original compiled program bytes");
        string formBefore=Form(shader,version),fieldsBefore=JsonSerializer.Serialize(Fields(shader));
        byte[] editorBytes=Serialize(shader,true);Need(editorBytes.Length>original.Length,"Editor-only metadata additions expected");
        IShader editor=Shader.Create(new AssetInfo(collection,4800000,48),version);var reread=new EndianSpanReader(editorBytes,EndianType.LittleEndian);editor.ReadEditor(ref reread);
        Need(reread.Position==reread.Length && editor.Name_R.ToString()==args[2],"Entire Editor layout readback/name proof");
        string formAfter=Form(editor,version),fieldsAfter=JsonSerializer.Serialize(Fields(editor));
        Need(formBefore==formAfter && fieldsBefore==fieldsAfter,"Original entire ParsedForm or program fields changed during Editor conversion");
        byte[] releaseAgain=Serialize(editor,false);
        File.WriteAllBytes(Path.Combine(args[3],"ReleaseReserialized.bin"),releaseAgain);
        File.WriteAllBytes(Path.Combine(args[3],"EditorShaderObject.bin"),editorBytes);
        File.WriteAllBytes(Path.Combine(args[3],"OriginalCompiledBlob.bin"),editor.CompressedBlob);
        File.WriteAllText(Path.Combine(args[3],"ParsedForm.yaml"),formAfter);
        int originalNameLength=BitConverter.ToInt32(original,0),newNameLength=BitConverter.ToInt32(releaseAgain,0);
        int originalAfterName=(4+originalNameLength+3)&~3,newAfterName=(4+newNameLength+3)&~3;
        bool rawEqual=original.SequenceEqual(releaseAgain);
        File.WriteAllText(Path.Combine(args[3],"diagnostic-report.json"),JsonSerializer.Serialize(new {
            schema="original-shader-Editor-roundtrip-difference-diagnostic/v1",source_sha256=Sha(original),source_bytes=original.Length,
            editor_bytes=editorBytes.Length,editor_sha256=Sha(editorBytes),release_consumed_bytes=input.Position,editor_consumed_bytes=reread.Position,
            release_reserialized_bytes=releaseAgain.Length,release_reserialized_sha256=Sha(releaseAgain),entire_release_object_byte_exact=rawEqual,
            entire_ParsedForm_equal=formBefore==formAfter,all_five_original_program_fields_equal=fieldsBefore==fieldsAfter,original_program_fields=Fields(editor),
            source_named_object_name=System.Text.Encoding.UTF8.GetString(original,4,originalNameLength),
            reserialized_named_object_name=System.Text.Encoding.UTF8.GetString(releaseAgain,4,newNameLength),
            source_named_object_aligned_end=originalAfterName,reserialized_named_object_aligned_end=newAfterName,
            all_bytes_after_NamedObject_equal=original.Skip(originalAfterName).SequenceEqual(releaseAgain.Skip(newAfterName)),
            source_last32=Convert.ToHexString(original.Skip(original.Length-32).ToArray()).ToLowerInvariant(),
            reserialized_last32=Convert.ToHexString(releaseAgain.Skip(releaseAgain.Length-32).ToArray()).ToLowerInvariant(),
            native_api_executed=false,Main_modified=false
        },new JsonSerializerOptions{WriteIndented=true}));
        Need(rawEqual,"Entire original release object did not roundtrip byte-for-byte; saved diagnostic bytes before gate");
        File.WriteAllBytes(Path.Combine(args[3],"EditorShaderObject.bin"),editorBytes);
        File.WriteAllBytes(Path.Combine(args[3],"OriginalCompiledBlob.bin"),editor.CompressedBlob);
        File.WriteAllText(Path.Combine(args[3],"ParsedForm.yaml"),formAfter);
        File.WriteAllText(Path.Combine(args[3],"report.json"),JsonSerializer.Serialize(new{
            schema="original-shader-generated-Editor-layout-roundtrip/v1",status="all_original_release_bytes_and_program_fields_preserved_in_Editor_roundtrip",
            engine=version.ToString(),model=shader.GetType().FullName,name=args[2],source_sha256=Sha(original),source_bytes=original.Length,
            release_consumed_bytes=input.Position,editor_consumed_bytes=reread.Position,editor_bytes=editorBytes.Length,editor_sha256=Sha(editorBytes),
            release_reserialized_sha256=Sha(releaseAgain),entire_release_object_byte_exact=true,entire_ParsedForm_equal=true,
            parsed_form_utf8_sha256=Sha(System.Text.Encoding.UTF8.GetBytes(formAfter)),original_program_fields=Fields(editor),
            editor_only_fields="Generated constructor defaults serialized by exact matching WriteEditor; original complete release object reserialization remains byte-exact.",
            Main_modified=false,Unity_launched=false,native_api_executed=false,actual_Editor_import_or_rendering_proven=false
        },new JsonSerializerOptions{WriteIndented=true}));
    }
    sealed class NoPointerWalker : YamlWalker
    {
        public override YamlNode CreateYamlNodeForPPtr<TAsset>(PPtr<TAsset> ptr) { throw new InvalidDataException("ParsedForm unexpectedly contains pointer metadata"); }
    }
}
