// Isolated metadata candidate only. No SDK/client assembly execution or IL edits.
using System;using System.IO;using System.Linq;using System.Text;using System.Text.Json;
using System.Collections.Generic;using System.Security.Cryptography;using System.Text.Json.Nodes;using Mono.Cecil;
using RR23.MetadataRestoration;
static class Program
{
 static IEnumerable<TypeDefinition> Types(TypeDefinition t){yield return t;foreach(var n in t.NestedTypes)foreach(var x in Types(n))yield return x;}
 static void Need(bool ok,string why){if(!ok)throw new InvalidDataException(why);}
 static string Hash(string path){using(var f=File.OpenRead(path))using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(f)).Replace("-","").ToLowerInvariant();}
 static string Text(JsonElement r,string key)=>r.GetProperty(key).GetString();
 static uint Token(JsonElement r,string key)=>r.GetProperty(key).GetUInt32();
 static JsonElement nativeRoot;
 static string Signature(MethodDefinition m)=>m.ReturnType.FullName+" "+m.Name+"("+string.Join(",",m.Parameters.Select(p=>p.ParameterType.FullName))+")";
 static IMarshalInfoProvider Owner(ModuleDefinition module,JsonElement row,bool source)
 {
  string typeName=Text(row,source?"sdk_owner":"owner");var t=module.Types.SelectMany(Types).SingleOrDefault(x=>x.FullName==typeName);Need(t!=null,"Owner type missing/ambiguous");
  if(Text(row,"kind")=="field")
  {
   var fields=t.Fields.Where(f=>f.MetadataToken.ToUInt32()==Token(row,source?"sdk_cli_token":"target_cli_token")&&f.Name==Text(row,source?"sdk_name":"name")&&f.FieldType.FullName==Text(row,source?"sdk_type":"type")).ToArray();Need(fields.Length==1,"Exact field token/name/type mismatch");var f=fields[0];Need((int)f.Attributes==row.GetProperty("flags").GetInt32(),"Field flags mismatch");Need(f.FieldType.Scope.Name==(source?Text(row,"sdk_type_scope"):Text(row,"target_type_scope")),"Field scoped type mismatch");return f;
  }
  Need(Text(row,"kind")=="parameter","Unsupported marshal owner");var methods=t.Methods.Where(m=>m.MetadataToken.ToUInt32()==Token(row,source?"sdk_cli_token":"target_cli_token")&&Signature(m)==Text(row,source?"sdk_signature":"signature")).ToArray();Need(methods.Length==1,"Exact method token/signature mismatch");var method=methods[0];Need((int)method.Attributes==row.GetProperty("method_flags").GetInt32()&&(int)method.ImplAttributes==row.GetProperty("method_impl_flags").GetInt32(),"Method flags mismatch");int index=row.GetProperty("sequence").GetInt32()-1;Need(index>=0&&index<method.Parameters.Count,"Parameter index mismatch");var p=method.Parameters[index];Need(p.Name==Text(row,source?"sdk_parameter_name":"name")&&p.ParameterType.FullName==Text(row,source?"sdk_type":"type")&&(int)p.Attributes==row.GetProperty("flags").GetInt32(),"Parameter name/type/flags mismatch");Need(p.ParameterType.Scope.Name==(source?Text(row,"sdk_type_scope"):Text(row,"target_type_scope")),"Parameter scoped type mismatch");return p;
 }
 sealed class Binding{public IMarshalInfoProvider Source,Target;public string Expected;public int Flags;}
 static void Native(JsonElement row)
 {
  var types=nativeRoot.GetProperty("types").EnumerateArray().Where(t=>Text(t,"name")==Text(row,"owner")&&Token(t,"token")==Token(row,"native_owner_token")).ToArray();Need(types.Length==1,"Native owner token/name mismatch");var owner=types[0];
  if(Text(row,"kind")=="field")
  {
   var fields=owner.GetProperty("fields").EnumerateArray().Where(f=>Token(f,"token")==Token(row,"native_field_token")&&Text(f,"name")==Text(row,"name")&&Text(f,"type")==Text(row,"type")&&f.GetProperty("flags").GetInt32()==row.GetProperty("flags").GetInt32()).ToArray();Need(fields.Length==1,"Native field token/name/type/flags mismatch");return;
  }
  var methods=owner.GetProperty("methods").EnumerateArray().Where(m=>Token(m,"token")==Token(row,"native_method_token")).ToArray();Need(methods.Length==1,"Native method token mismatch");var method=methods[0];string signature=Text(method,"return_type")+" "+Text(method,"name")+"("+string.Join(",",method.GetProperty("parameters").EnumerateArray().Select(p=>Text(p,"type")))+")";Need(signature==Text(row,"signature")&&method.GetProperty("flags").GetInt32()==row.GetProperty("method_flags").GetInt32()&&method.GetProperty("impl_flags").GetInt32()==row.GetProperty("method_impl_flags").GetInt32(),"Native method full contract mismatch");int sequence=row.GetProperty("sequence").GetInt32();var pars=method.GetProperty("parameters").EnumerateArray().Where(p=>p.GetProperty("sequence").GetInt32()==sequence&&Token(p,"token")==Token(row,"native_parameter_token")&&Text(p,"name")==Text(row,"name")&&Text(p,"type")==Text(row,"type")&&p.GetProperty("flags").GetInt32()==row.GetProperty("flags").GetInt32()).ToArray();Need(pars.Length==1,"Native parameter ownership mismatch");
 }
 static List<Binding> Bind(ModuleDefinition target,ModuleDefinition sdk,JsonElement manifest)
 {
  Need(target.Assembly.Name.Name=="Oculus.VR","Unexpected target assembly identity");var result=new List<Binding>();var seen=new HashSet<IMarshalInfoProvider>();
  foreach(var row in manifest.GetProperty("bindings").EnumerateArray())
  {
   Native(row);var source=Owner(sdk,row,true);var actual=Owner(target,row,false);Need(seen.Add(actual),"Duplicate owner row");Need(!actual.HasMarshalInfo&&actual.MarshalInfo==null,"Target descriptor already exists");Need(source.HasMarshalInfo&&source.MarshalInfo!=null,"SDK descriptor absent");string descriptor=CanonicalMarshallingContracts.MarshalDescriptor(source.MarshalInfo);Need(descriptor==Text(row,"descriptor"),"SDK descriptor differs");Need(source.MarshalInfo.GetType()==typeof(MarshalInfo),"Only proven scalar descriptor shapes allowed");result.Add(new Binding{Source=source,Target=actual,Expected=descriptor,Flags=row.GetProperty("flags").GetInt32()});
  }
  Need(result.Count==335&&result.Count(b=>b.Target is FieldDefinition)==332&&result.Count(b=>b.Target is ParameterDefinition)==3,"Exact335 owner inventory required");
  var dangling=Providers(target).Where(p=>Flag(p)&&!p.HasMarshalInfo).ToArray();var unresolved=manifest.GetProperty("unresolved").EnumerateArray().ToArray();Need(unresolved.Length==20,"Expected20 unresolved owners");
  foreach(var row in unresolved){Native(row);var type=target.Types.SelectMany(Types).Single(t=>t.FullName==Text(row,"owner"));IMarshalInfoProvider owner;
   if(Text(row,"kind")=="field"){var f=type.Fields.Single(x=>x.MetadataToken.ToUInt32()==Token(row,"target_cli_token"));Need(f.Name==Text(row,"name")&&f.FieldType.FullName==Text(row,"type")&&(int)f.Attributes==row.GetProperty("flags").GetInt32(),"Unresolved field changed");owner=f;}
   else{var m=type.Methods.Single(x=>x.MetadataToken.ToUInt32()==Token(row,"target_cli_token"));Need(Signature(m)==Text(row,"signature"),"Unresolved method signature differs");var x=m.Parameters[row.GetProperty("sequence").GetInt32()-1];Need(x.Name==Text(row,"name")&&x.ParameterType.FullName==Text(row,"type")&&(int)x.Attributes==row.GetProperty("flags").GetInt32(),"Unresolved param changed");owner=x;}
   Need(!owner.HasMarshalInfo&&owner.MarshalInfo==null&&Flag(owner)&&seen.Add(owner),"Unresolved owner duplicated/changed");}
  Need(dangling.Length==355&&dangling.All(seen.Contains),"Native355target gap inventory differs");return result;
 }
 static IEnumerable<IMarshalInfoProvider> Providers(ModuleDefinition m){foreach(var t in m.Types.SelectMany(Types)){foreach(var f in t.Fields)yield return f;foreach(var method in t.Methods){yield return method.MethodReturnType;foreach(var p in method.Parameters)yield return p;}}}
 static bool Flag(IMarshalInfoProvider p)=>p is FieldDefinition f?((int)f.Attributes&4096)!=0:p is ParameterDefinition a?((int)a.Attributes&8192)!=0:((int)((MethodReturnType)p).Attributes&8192)!=0;
 static string PartialCanonical(IMarshalInfoProvider p)=>Flag(p)&&!p.HasMarshalInfo?"proven-unresolved-original-flag":CanonicalMarshallingContracts.Canonical(p);
 static string MarshalFingerprint(ModuleDefinition m){var b=new StringBuilder();foreach(var t in m.Types.SelectMany(Types)){foreach(var f in t.Fields)b.Append(t.FullName).Append('/').Append(f.Name).Append(':').Append(PartialCanonical(f)).Append('|');foreach(var x in t.Methods){b.Append(t.FullName).Append('/').Append(Signature(x)).Append(':').Append(PartialCanonical(x.MethodReturnType)).Append('|');foreach(var p in x.Parameters)b.Append(p.Index).Append(':').Append(PartialCanonical(p)).Append('|');}}using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(b.ToString()))).Replace("-","");}
 static int NegativeControls(ModuleDefinition target,ModuleDefinition sdk,JsonElement manifest)
 {
  string before=MetadataRoundTripSafety.Fingerprint(target);int count=0;var cases=new[]{"owner","name","type","flags","target_cli_token","sdk_cli_token","sdk_type_scope","target_type_scope","descriptor","native_owner_token","native_field_token","native_method_token","native_parameter_token","method_flags","method_impl_flags","signature","sequence","missing","duplicate","sdk_owner","sdk_name","sdk_type","sdk_signature","sdk_parameter_name"};
  foreach(string name in cases)
  {
   var copy=JsonNode.Parse(manifest.GetRawText()).AsObject();var rows=copy["bindings"].AsArray();bool parameter=new[]{"native_method_token","native_parameter_token","method_flags","method_impl_flags","signature","sequence","sdk_signature","sdk_parameter_name"}.Contains(name);int index=parameter?rows.Select((x,i)=>new{x,i}).First(x=>x.x["kind"].GetValue<string>()=="parameter").i:0;var row=rows[index].AsObject();
   if(name=="missing")rows.RemoveAt(rows.Count-1);
   else if(name=="duplicate")rows[rows.Count-1]=rows[0].DeepClone();
   else if(new[]{"flags","method_flags","method_impl_flags"}.Contains(name))row[name]=row[name].GetValue<int>()^1;
   else if(new[]{"target_cli_token","sdk_cli_token","native_owner_token","native_field_token","native_method_token","native_parameter_token"}.Contains(name))row[name]=row[name].GetValue<uint>()^1u;
   else if(name=="sequence")row[name]=0;
   else row[name]=row[name].GetValue<string>()+"__WRONG";
   bool rejected=false;try{using(var changed=JsonDocument.Parse(copy.ToJsonString()))Bind(target,sdk,changed.RootElement);}catch(InvalidDataException){rejected=true;}
   Need(rejected,"Production negative control accepted: "+name);Need(before==MetadataRoundTripSafety.Fingerprint(target)&&Providers(target).All(p=>!p.HasMarshalInfo),"Rejected control mutated target");count++;
  }
  return count;
 }
 static int Main(string[] args)
 {
  using(var document=JsonDocument.Parse(File.ReadAllText(args[0])))
  {
   var manifest=document.RootElement;string input=Text(manifest,"target_path"),sdkPath=Text(manifest,"sdk_path");Need(Hash(input)==Text(manifest,"target_sha256")&&Hash(sdkPath)==Text(manifest,"sdk_sha256"),"Pinned input hash differs");Need(!File.Exists(args[1]),"Fresh staged DLL required");string nativePath=Text(manifest,"native_report_path");Need(Hash(nativePath)==Text(manifest,"native_report_sha256"),"Native authority report hash differs");using(var nativeDocument=JsonDocument.Parse(File.ReadAllText(nativePath))){nativeRoot=nativeDocument.RootElement;
   using(var target=ModuleDefinition.ReadModule(input,new ReaderParameters{ReadingMode=ReadingMode.Deferred}))using(var sdk=ModuleDefinition.ReadModule(sdkPath,new ReaderParameters{ReadingMode=ReadingMode.Deferred}))
   {
    var methods=target.Types.SelectMany(Types).SelectMany(t=>t.Methods).ToArray();var bodies=BodyAndSymbolSafety.Capture(methods);var bindings=Bind(target,sdk,manifest);int negativeControls=NegativeControls(target,sdk,manifest);string before=MetadataRoundTripSafety.Fingerprint(target);
    // Bind every row before mutation. Metadata fingerprints deliberately exclude
    // marshal blobs; their separate exact canonical fingerprint follows Apply.
    foreach(var binding in bindings){binding.Target.MarshalInfo=CanonicalMarshallingContracts.Clone(binding.Source.MarshalInfo);Need(CanonicalMarshallingContracts.MarshalDescriptor(binding.Target.MarshalInfo)==binding.Expected,"Clone changed descriptor");}
    Need(before==MetadataRoundTripSafety.Fingerprint(target),"Non-marshaling metadata changed in memory");bodies.VerifyObjectIdentity(methods);string[] il=bodies.CaptureNormalized(methods);string marshal=MarshalFingerprint(target);string metadata=MetadataRoundTripSafety.Fingerprint(target);
    using(CanonicalMarshallingContracts.BeginWrite(target))target.Write(args[1]);
    using(var emitted=ModuleDefinition.ReadModule(args[1],new ReaderParameters{ReadingMode=ReadingMode.Deferred})){Need(metadata==MetadataRoundTripSafety.Fingerprint(emitted),"Non-marshaling metadata emission differs");Need(marshal==MarshalFingerprint(emitted),"Marshal emission differs");bodies.VerifyEmitted(il,emitted.Types.SelectMany(Types).SelectMany(t=>t.Methods).ToArray());Need(Providers(emitted).Count(p=>p.HasMarshalInfo)==335&&Providers(emitted).Count(p=>Flag(p)&&!p.HasMarshalInfo)==20,"Emitted marshal owner count differs");}
    Need(Hash(input)==Text(manifest,"target_sha256")&&Hash(sdkPath)==Text(manifest,"sdk_sha256"),"Input changed");File.WriteAllText(args[2],JsonSerializer.Serialize(new{schema="oculus335-isolated-partial-marshal-stage/v1",status="passed",input_sha256=Hash(input),output=args[1],output_sha256=Hash(args[1]),marshal_owners=335,fields=332,parameters=3,unresolved_owners=20,methods=methods.Length,method_bodies=methods.Count(m=>m.HasBody),metadata_fingerprint=metadata,marshal_fingerprint=marshal,negative_controls=negativeControls,non_marshaling_metadata_preserved=true,all_method_body_instruction_objects_and_emitted_il_preserved=true,project_modified=false,sdk_or_game_code_executed=false},new JsonSerializerOptions{WriteIndented=true}));
   }}
  }
  return 0;
 }
}
