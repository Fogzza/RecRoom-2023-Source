using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using AssetRipper.Assets;
using AssetRipper.Assets.Bundles;
using AssetRipper.Assets.IO.Writing;
using AssetRipper.Assets.Metadata;
using AssetRipper.IO.Endian;
using AssetRipper.Primitives;
using AssetRipper.SourceGenerated.Classes.ClassID_48;
using AssetRipper.SourceGenerated.Subclasses.PPtr_Shader;
using AssetRipper.Export.UnityProjects;
using AssetRipper.Yaml;

// Exact generated-model IO only. No Unity/native API, game assembly, external
// PPtr resolution or remapping. Reflection below reads pinned generated fields
// solely to report the typed source namespace; it never sets any field.
internal static class ConvertOriginalShaderPairToEditor
{
    static void Need(bool value,string message) { if(!value)throw new InvalidDataException(message); }
    static string Sha(byte[] b)=>Convert.ToHexString(SHA256.HashData(b)).ToLowerInvariant();
    static readonly BindingFlags Flags=BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic;
    static object Field(object value,string name)
    {
        var f=value.GetType().GetField(name,Flags);Need(f!=null,"Pinned generated field absent: "+name);return f.GetValue(value);
    }
    static byte[] Serialize(IShader shader,bool editor)
    {
        using var memory=new MemoryStream();
        using(var writer=new AssetWriter(memory,shader.Collection))
        { if(editor)shader.WriteEditor(writer);else shader.WriteRelease(writer); }
        return memory.ToArray();
    }
    static object Shape(object value)
    {
        if(value is IEnumerable items && !(value is string))
        { var result=new List<object>();foreach(var item in items)result.Add(Shape(item));return result; }
        return value;
    }
    static Dictionary<string,object> ProgramFields(IShader shader)
    {
        var result=new Dictionary<string,object>();
        foreach(string key in new[]{"Platforms","Offsets_AssetList_AssetList_UInt32","CompressedLengths_AssetList_AssetList_UInt32","DecompressedLengths_AssetList_AssetList_UInt32"})
        {var property=typeof(IShader).GetProperty(key);Need(property!=null,"Exact program field absent: "+key);result[key]=Shape(property.GetValue(shader));}
        result["compressedBlob"]=new{bytes=shader.CompressedBlob.Length,sha256=Sha(shader.CompressedBlob)};return result;
    }
    static object Dependencies(IShader shader)
    {
        var result=new List<object>();
        foreach(var item in (IEnumerable)Field(shader,"m_Dependencies"))
        {
            Need(item is PPtr_Shader_5,"Exact generated typed Shader dependency required");
            var file=Field(item,"m_FileID_");var path=Field(item,"m_PathID_");
            Need(file is int && path is long,"Typed Int32 FileID / Int64 PathID required");
            result.Add(new{concrete_type=item.GetType().FullName,file_id=(int)file,path_id=(long)path});
        }
        int textures=0;foreach(var item in (IEnumerable)Field(shader,"m_NonModifiableTextures"))textures++;
        Need(textures==0,"Two-shader fixture does not authorize texture binding conversion");
        var baked=Field(shader,"m_ShaderIsBaked");Need(baked is bool,"Exact baked field type required");
        return new{dependencies=result,nonmodifiable_texture_count=textures,shader_is_baked=(bool)baked};
    }
    static string ParsedForm(IShader shader,UnityVersion version)
    {
        var walker=new NoPointerWalker();walker.WithUnityVersion(version);
        var document=new YamlDocument();document.CreateMappingRoot().Add("m_ParsedForm",walker.ExportYamlNode(shader.ParsedForm));
        var writer=new YamlWriter();writer.AddDocument(document);using var output=new StringWriter();writer.Write(output);return output.ToString();
    }
    static int NameEnd(byte[] bytes)
    {
        Need(bytes.Length>=4,"NamedObject header absent");int length=BitConverter.ToInt32(bytes,0);
        Need(length>=0 && length<=256 && 4+length<=bytes.Length,"Bounded NamedObject string required");
        return (4+length+3)&~3;
    }
    static void One(JsonElement spec,string output)
    {
        string source=spec.GetProperty("path").GetString(),expected=spec.GetProperty("sha256").GetString(),name=spec.GetProperty("name").GetString();
        long pathID=spec.GetProperty("path_id").GetInt64();
        Need(new FileInfo(source).Length==spec.GetProperty("bytes").GetInt32() && new FileInfo(source).Length<=8*1024*1024,"Pinned source size bound");
        byte[] original=File.ReadAllBytes(source);Need(Sha(original)==expected,"Pinned original release SHA mismatch");
        Need(!Directory.Exists(output),"Fresh per-shader conversion output required");Directory.CreateDirectory(output);
        var version=UnityVersion.Parse("2020.3.33f1");var bundle=new ProcessedBundle("OriginalTwoShaderEditorDataConversion");
        var collection=bundle.AddNewProcessedCollection("source-namespace-retained",version);
        IShader shader=Shader.Create(new AssetInfo(collection,pathID,48),version);
        var reader=new EndianSpanReader(original,EndianType.LittleEndian);shader.ReadRelease(ref reader);
        Need(reader.Position==reader.Length && shader.GetType().Name=="Shader_2020_3_16" && shader.Name_R.ToString()==name,"Entire exact original release model/name required");
        Need(shader.CompressedBlob.Length==spec.GetProperty("blob_bytes").GetInt32() && Sha(shader.CompressedBlob)==spec.GetProperty("blob_sha256").GetString(),"Original compiled blob must match manifest");
        string formBefore=ParsedForm(shader,version),programBefore=JsonSerializer.Serialize(ProgramFields(shader)),depsBefore=JsonSerializer.Serialize(Dependencies(shader));
        byte[] editorBytes=Serialize(shader,true);
        IShader editor=Shader.Create(new AssetInfo(collection,pathID,48),version);var reread=new EndianSpanReader(editorBytes,EndianType.LittleEndian);editor.ReadEditor(ref reread);
        Need(reread.Position==reread.Length && editor.Name_R.ToString()==name,"Entire generated Editor layout consumption required");
        string formAfter=ParsedForm(editor,version),programAfter=JsonSerializer.Serialize(ProgramFields(editor)),depsAfter=JsonSerializer.Serialize(Dependencies(editor));
        Need(formBefore==formAfter && programBefore==programAfter && depsBefore==depsAfter,"ParsedForm, programs or typed dependency namespace changed");
        byte[] release=Serialize(editor,false);
        int oldEnd=NameEnd(original),newEnd=NameEnd(release),oldLength=BitConverter.ToInt32(original,0),newLength=BitConverter.ToInt32(release,0);
        string oldName=Encoding.UTF8.GetString(original,4,oldLength),newName=Encoding.UTF8.GetString(release,4,newLength);
        Need(oldName=="" && newName==name,"Only stripped leading name to exact original ParsedForm name is authorized");
        Need(release.Skip(4+newLength).Take(newEnd-4-newLength).All(b=>b==0),"Normalized name padding must be zero");
        Need(original.AsSpan(oldEnd).SequenceEqual(release.AsSpan(newEnd)),"Every original byte after aligned NamedObject must remain exact");
        Need(release.Length-original.Length==newEnd-oldEnd,"No second release serialization edit is allowed");
        File.WriteAllBytes(Path.Combine(output,"EditorShaderObject.bin"),editorBytes);
        File.WriteAllBytes(Path.Combine(output,"ReleaseReserialized.bin"),release);
        File.WriteAllBytes(Path.Combine(output,"OriginalCompiledBlob.bin"),editor.CompressedBlob);
        File.WriteAllText(Path.Combine(output,"ParsedForm.yaml"),formAfter,new UTF8Encoding(false));
        File.WriteAllText(Path.Combine(output,"report.json"),JsonSerializer.Serialize(new{
            schema="generalized-original-shader-generated-Editor-layout-roundtrip/v1",status="exact_except_proven_leading_NamedObject_normalization",
            engine=version.ToString(),model=shader.GetType().FullName,name,original_source_path_id=pathID,
            source_sha256=Sha(original),source_bytes=original.Length,release_consumed_bytes=reader.Position,
            editor_sha256=Sha(editorBytes),editor_bytes=editorBytes.Length,editor_consumed_bytes=reread.Position,
            release_reserialized_sha256=Sha(release),release_reserialized_bytes=release.Length,
            entire_ParsedForm_equal=true,all_five_original_program_fields_equal=true,typed_dependencies_equal=true,
            all_bytes_after_aligned_NamedObject_equal=true,original_NamedObject_name=oldName,normalized_NamedObject_name=newName,
            original_aligned_name_end=oldEnd,normalized_aligned_name_end=newEnd,name_padding_zero=true,
            parsed_form_utf8_sha256=Sha(Encoding.UTF8.GetBytes(formAfter)),original_program_fields=ProgramFields(editor),typed_source_dependencies=Dependencies(editor),
            external_IDs_remapped=false,source_external_namespace_resolved_or_loaded=false,Main_modified=false,Unity_launched=false,native_api_executed=false,
            Editor_import_or_BuildPlayer_retention_or_GPU_rendering_claimed=false
        },new JsonSerializerOptions{WriteIndented=true}));
    }
    static void Main(string[] args)
    {
        Need(args.Length==2,"Pinned two-shader spec JSON and fresh output required");
        using var spec=JsonDocument.Parse(File.ReadAllBytes(args[0]));var rows=spec.RootElement.GetProperty("shaders");
        Need(rows.GetArrayLength()==2 && !Directory.Exists(args[1]),"Exactly two fresh shader data conversions required");Directory.CreateDirectory(args[1]);
        foreach(var row in rows.EnumerateArray())One(row,Path.Combine(args[1],row.GetProperty("key").GetString()));
    }
    sealed class NoPointerWalker:YamlWalker
    {
        public override YamlNode CreateYamlNodeForPPtr<TAsset>(PPtr<TAsset> ptr){throw new InvalidDataException("ParsedForm unexpectedly contains PPtrs");}
    }
}
