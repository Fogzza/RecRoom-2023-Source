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

// Pure generated-model conversion, one original object per process. Each typed
// PPtr change must be listed in an independently resolved manifest. No Unity API,
// game assembly, source reconstruction, keyword editing or native SDK execution.
internal static class ConvertOriginalShaderCollectionToEditor
{
    static void Need(bool value,string message) { if(!value)throw new InvalidDataException(message); }
    static string Sha(byte[] bytes)=>Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
    static string NativeGuid(string text)
    {
        // Same source-backed serialized-file writer: four little-endian UInt32.
        var guid=UnityGuid.Parse(text);Need(guid.ToString()==text,"UnityGuid textual roundtrip");
        byte[] bytes=new byte[16];BitConverter.GetBytes(guid.Data0).CopyTo(bytes,0);
        BitConverter.GetBytes(guid.Data1).CopyTo(bytes,4);BitConverter.GetBytes(guid.Data2).CopyTo(bytes,8);
        BitConverter.GetBytes(guid.Data3).CopyTo(bytes,12);return Convert.ToHexString(bytes).ToLowerInvariant();
    }
    static readonly BindingFlags Flags=BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic;
    static object Field(object value,string name)
    {
        var field=value.GetType().GetField(name,Flags);
        Need(field!=null,"Pinned generated field absent: "+name);return field.GetValue(value);
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
        {var result=new List<object>();foreach(var item in items)result.Add(Shape(item));return result;}
        return value;
    }
    static Dictionary<string,object> ProgramFields(IShader shader)
    {
        var result=new Dictionary<string,object>();
        foreach(string key in new[]{"Platforms","Offsets_AssetList_AssetList_UInt32","CompressedLengths_AssetList_AssetList_UInt32","DecompressedLengths_AssetList_AssetList_UInt32"})
        {var property=typeof(IShader).GetProperty(key);Need(property!=null,"Exact program field absent: "+key);result[key]=Shape(property.GetValue(shader));}
        result["compressedBlob"]=new{bytes=shader.CompressedBlob.Length,sha256=Sha(shader.CompressedBlob)};return result;
    }
    record Dependency(int file_id,long path_id);
    static Dependency Pointer(PPtr_Shader_5 pointer)
    {
        object file=Field(pointer,"m_FileID_"),path=Field(pointer,"m_PathID_");
        Need(file is int && path is long,"Typed Int32 FileID/Int64 PathID required");return new Dependency((int)file,(long)path);
    }
    static PPtr_Shader_5[] Pointers(IShader shader)
    {
        var items=((IEnumerable)Field(shader,"m_Dependencies")).Cast<object>().ToArray();
        Need(items.All(item=>item is PPtr_Shader_5),"Only exact generated Shader PPtr layout permitted");
        return items.Cast<PPtr_Shader_5>().ToArray();
    }
    static bool Baked(IShader shader)
    {
        int textures=0;foreach(var item in (IEnumerable)Field(shader,"m_NonModifiableTextures"))textures++;
        Need(textures==0,"Texture pointer conversion is outside the approved empty-map scope");
        object baked=Field(shader,"m_ShaderIsBaked");Need(baked is bool,"Exact baked field required");return (bool)baked;
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
        Need(length>=0 && length<=1024 && 4+length<=bytes.Length,"Bounded original name required");return (4+length+3)&~3;
    }
    static void Main(string[] args)
    {
        Need(args.Length==2,"Pinned single-shader manifest and fresh output directory required");
        Need(new FileInfo(args[0]).Length<=256*1024,"Bounded manifest required");
        using var document=JsonDocument.Parse(File.ReadAllBytes(args[0]));var spec=document.RootElement;
        Need(spec.GetProperty("schema").GetString()=="resolved-original-Shader-Editor-conversion-input/v1","Explicit resolved manifest schema required");
        string source=spec.GetProperty("source").GetProperty("path").GetString();
        string expected=spec.GetProperty("source").GetProperty("sha256").GetString();
        string name=spec.GetProperty("name").GetString(),guid=spec.GetProperty("guid").GetString();
        Need(guid.Length==32 && guid.All(c=>"0123456789abcdef".Contains(c)),"Exact lowercase original Main GUID required");
        Need(NativeGuid("d2a5536c48f6e914f900eb13ea2f4d68")=="2d5a35c6846f9e419f00be31aef2d486","Actual genuine Editor GUID capture must match source-backed serializer");
        long pathID=spec.GetProperty("original_path_id").GetInt64();
        long size=new FileInfo(source).Length;
        Need(size==spec.GetProperty("source").GetProperty("bytes").GetInt64() && size>=12 && size<=32*1024*1024,"Pinned original source size bound");
        byte[] original=File.ReadAllBytes(source);Need(Sha(original)==expected,"Pinned original Release source SHA mismatch");
        Need(!Directory.Exists(args[1]),"Fresh per-shader output required");Directory.CreateDirectory(args[1]);
        var version=UnityVersion.Parse("2020.3.33f1");var bundle=new ProcessedBundle("ResolvedOriginalShaderEditorConversion");
        var collection=bundle.AddNewProcessedCollection("original-source-namespace",version);
        IShader shader=Shader.Create(new AssetInfo(collection,pathID,48),version);
        var reader=new EndianSpanReader(original,EndianType.LittleEndian);shader.ReadRelease(ref reader);
        Need(reader.Position==reader.Length && shader.GetType().Name=="Shader_2020_3_16" && shader.Name_R.ToString()==name,"Entire exact original Release model/name required");
        string formBefore=ParsedForm(shader,version),programBefore=JsonSerializer.Serialize(ProgramFields(shader));
        Need(Sha(Encoding.UTF8.GetBytes(formBefore))==spec.GetProperty("expected_ParsedForm_sha256").GetString(),"Original ParsedForm must match independent source-model receipt");
        var expectedPrograms=spec.GetProperty("expected_program_fields");
        foreach(var field in ProgramFields(shader))
            Need(JsonSerializer.Serialize(field.Value)==JsonSerializer.Serialize(expectedPrograms.GetProperty(field.Key)),"Independent source program field mismatch: "+field.Key);
        var pointers=Pointers(shader);var originalPointers=pointers.Select(Pointer).ToArray();
        bool bakedBefore=Baked(shader);Need(bakedBefore==spec.GetProperty("expected_shader_is_baked").GetBoolean(),"Original baked state mismatch");
        var mappings=spec.GetProperty("dependencies").EnumerateArray().ToArray();
        Need(mappings.Length==pointers.Length && pointers.Length<=1024,"Every source dependency must have exactly one indexed mapping");
        int tail=original.Length-12-pointers.Length*12;
        Need(tail>=NameEnd(original) && BitConverter.ToInt32(original,tail)==pointers.Length,"Independent typed dependency tail count");
        Need(BitConverter.ToInt32(original,original.Length-8)==0 && original[original.Length-4]==(bakedBefore ? 1 : 0)
             && original.AsSpan(original.Length-3).SequenceEqual(new byte[3]),"Exact empty texture map/baked/padding tail required");
        var windows=new List<object>();
        for(int index=0;index<pointers.Length;index++)
        {
            var mapping=mappings[index];Need(mapping.GetProperty("index").GetInt32()==index,"Dependency mapping order must be explicit");
            var input=new Dependency(mapping.GetProperty("source_file_id").GetInt32(),mapping.GetProperty("source_path_id").GetInt64());
            var output=new Dependency(mapping.GetProperty("output_file_id").GetInt32(),mapping.GetProperty("output_path_id").GetInt64());
            int offset=tail+4+index*12;
            Need(originalPointers[index]==input && BitConverter.ToInt32(original,offset)==input.file_id
                 && BitConverter.ToInt64(original,offset+4)==input.path_id,"Generated typed source PPtr must independently match raw tail and manifest");
            Need((input.path_id!=0 || (output.path_id==0 && output.file_id==0)) && output.file_id>=0,"Null pointers stay null and Editor output FileID is nonnegative");
            byte[] replacement=new byte[12];BitConverter.GetBytes(output.file_id).CopyTo(replacement,0);BitConverter.GetBytes(output.path_id).CopyTo(replacement,4);
            var pointerReader=new EndianSpanReader(replacement,EndianType.LittleEndian);pointers[index].ReadRelease(ref pointerReader);
            Need(pointerReader.Position==12 && Pointer(pointers[index])==output,"Generated typed PPtr remap required");
            windows.Add(new{index,original_offset=offset,bytes=12,source=input,target=output,changed=input!=output});
        }
        var outputPointers=pointers.Select(Pointer).ToArray();
        byte[] editorBytes=Serialize(shader,true);
        IShader editor=Shader.Create(new AssetInfo(collection,pathID,48),version);
        var reread=new EndianSpanReader(editorBytes,EndianType.LittleEndian);editor.ReadEditor(ref reread);
        Need(reread.Position==reread.Length && editor.Name_R.ToString()==name,"Entire generated Editor readback required");
        string formAfter=ParsedForm(editor,version),programAfter=JsonSerializer.Serialize(ProgramFields(editor));
        Need(formBefore==formAfter && programBefore==programAfter && Pointers(editor).Select(Pointer).SequenceEqual(outputPointers)
             && Baked(editor)==bakedBefore,"ParsedForm/programs/mapped dependency order/baked state must remain exact");
        byte[] release=Serialize(editor,false);int oldEnd=NameEnd(original),newEnd=NameEnd(release);
        int oldLength=BitConverter.ToInt32(original,0),newLength=BitConverter.ToInt32(release,0);
        string oldName=Encoding.UTF8.GetString(original,4,oldLength),newName=Encoding.UTF8.GetString(release,4,newLength);
        Need((oldName=="" || oldName==name) && newName==name,"Only stripped-name restoration or unchanged original name is permitted");
        Need(release.Skip(4+newLength).Take(newEnd-4-newLength).All(b=>b==0),"Exact generated name padding required");
        byte[] expectedTail=original.AsSpan(oldEnd).ToArray();
        for(int index=0;index<outputPointers.Length;index++)
        {
            int relative=tail+4+index*12-oldEnd;BitConverter.GetBytes(outputPointers[index].file_id).CopyTo(expectedTail,relative);
            BitConverter.GetBytes(outputPointers[index].path_id).CopyTo(expectedTail,relative+4);
        }
        Need(expectedTail.AsSpan().SequenceEqual(release.AsSpan(newEnd)) && release.Length-original.Length==newEnd-oldEnd,
             "Every Release byte outside leading name and explicitly indexed typed12B PPtr windows must remain original");
        File.WriteAllBytes(Path.Combine(args[1],"EditorShaderObject.bin"),editorBytes);
        File.WriteAllBytes(Path.Combine(args[1],"ReleaseReserialized.bin"),release);
        // Keep original shader source programs once; all emitted bytes are checked.
        File.WriteAllBytes(Path.Combine(args[1],"OriginalCompiledBlob.bin"),editor.CompressedBlob);
        File.WriteAllText(Path.Combine(args[1],"ParsedForm.yaml"),formAfter,new UTF8Encoding(false));
        File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(new{
            schema="resolved-original-Shader-generated-Editor-roundtrip/v1",status="original_bytes_preserved_except_name_and_manifest_typed_PPtrs",
            guid,native_GUID_hex=NativeGuid(guid),name,engine=version.ToString(),model=shader.GetType().FullName,original_source_path_id=pathID,
            source_sha256=Sha(original),source_bytes=original.Length,release_consumed_bytes=reader.Position,
            editor_sha256=Sha(editorBytes),editor_bytes=editorBytes.Length,editor_consumed_bytes=reread.Position,
            release_reserialized_sha256=Sha(release),release_reserialized_bytes=release.Length,
            entire_ParsedForm_equal=true,all_five_original_program_fields_equal=true,
            original_program_fields=ProgramFields(editor),parsed_form_utf8_sha256=Sha(Encoding.UTF8.GetBytes(formAfter)),
            source_dependencies=originalPointers,mapped_dependencies=outputPointers,authorized_typed_PPtr_windows=windows,
            dependency_count=pointers.Length,nonmodifiable_texture_count=0,shader_is_baked=bakedBefore,
            original_aligned_name_end=oldEnd,normalized_aligned_name_end=newEnd,
            original_NamedObject_name=oldName,normalized_NamedObject_name=newName,
            all_bytes_outside_name_and_manifest_typed_PPtr_windows_equal=true,
            Main_modified=false,Unity_launched=false,native_API_or_game_code_executed=false,
            Editor_import_or_BuildPlayer_or_GPU_verified=false
        },new JsonSerializerOptions{WriteIndented=true}));
    }
    sealed class NoPointerWalker:YamlWalker
    {
        public override YamlNode CreateYamlNodeForPPtr<TAsset>(PPtr<TAsset> ptr){throw new InvalidDataException("ParsedForm unexpectedly contains pointers");}
    }
}
