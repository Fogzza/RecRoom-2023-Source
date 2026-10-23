// Audit all existing IL MemberRefs into the two candidate SDK assemblies.
// Cecil reads metadata only; neither inputs nor SDK methods execute.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using Mono.Cecil;

internal static partial class SDKReferenceAudit
{
    static string Sha(string path){using(var s=File.OpenRead(path))using(var h=SHA256.Create())return BitConverter.ToString(h.ComputeHash(s)).Replace("-","").ToLowerInvariant();}
    static readonly HashSet<string> Targets=new HashSet<string>(new[]{"Unity.ResourceManager","Unity.Addressables"},StringComparer.Ordinal);
    static string Scope(TypeReference type){while(type is TypeSpecification)type=((TypeSpecification)type).ElementType;while(type.DeclaringType!=null)type=type.DeclaringType;var scope=type.Scope as AssemblyNameReference;return scope==null?null:scope.Name;}
    static int Main(string[] args){
        if(args.Length==3&&args[0]=="--fixtures")return ReferenceFixtures(args[1],args[2]);
        try{
            if(args.Length!=4||File.Exists(args[3]))throw new ArgumentException("input-files.txt candidate-sdk-dir matching-editor fresh-report");
            string[] files=File.ReadAllLines(args[0]).Where(x=>!String.IsNullOrWhiteSpace(x)).Select(Path.GetFullPath).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
            if(files.Length==0||files.Length>300)throw new InvalidDataException("Bounded explicit input files required.");
            string sdk=Path.GetFullPath(args[1]),editor=Path.GetFullPath(args[2]);var rows=new List<object>();int missing=0,totalTypes=0,totalMethods=0,totalFields=0;
            foreach(string file in files){
                string before=Sha(file);int types=0,methods=0,fields=0;var errors=new List<object>();
                using(var resolver=new DefaultAssemblyResolver()){
                    foreach(var d in resolver.GetSearchDirectories())resolver.RemoveSearchDirectory(d);
                    foreach(var d in new[]{sdk,Path.Combine(editor,"Data/Managed/UnityEngine"),Path.Combine(editor,"Data/Managed"),Path.Combine(editor,"Data/MonoBleedingEdge/lib/mono/4.7.1-api"),Path.Combine(editor,"Data/MonoBleedingEdge/lib/mono/4.7.1-api/Facades")})resolver.AddSearchDirectory(d);
                    using(var a=AssemblyDefinition.ReadAssembly(file,new ReaderParameters{AssemblyResolver=resolver,ReadingMode=ReadingMode.Deferred,ReadSymbols=false})){
                        Action<TypeReference> checkScope=t=>{var target=t.Scope as AssemblyNameReference;if(target==null||!Targets.Contains(target.Name))return;var resolved=resolver.Resolve(target);if(resolved.Name.FullName!=target.FullName||!String.Equals(Path.GetFullPath(resolved.MainModule.FileName),Path.Combine(sdk,target.Name+".dll"),StringComparison.OrdinalIgnoreCase))throw new InvalidDataException("Wrong SDK assembly identity/path.");};
                        foreach(var r in a.MainModule.AssemblyReferences.Where(r=>Targets.Contains(r.Name))){try{var target=resolver.Resolve(r);if(target.Name.FullName!=r.FullName||!String.Equals(Path.GetFullPath(target.MainModule.FileName),Path.Combine(sdk,r.Name+".dll"),StringComparison.OrdinalIgnoreCase))throw new InvalidDataException("Wrong target SDK scope.");}catch(Exception e){missing++;errors.Add(new{kind="assembly",reference=r.FullName,error=e.Message});}}
                        foreach(var r in a.MainModule.GetTypeReferences().Where(t=>Targets.Contains(Scope(t)))){try{var target=r.Resolve();if(target==null||!Targets.Contains(target.Module.Assembly.Name.Name))throw new InvalidDataException("Missing target SDK type.");types++;}catch(Exception e){missing++;if(errors.Count<64)errors.Add(new{kind="type",reference=r.FullName,error=e.Message});}}
                        foreach(var r in a.MainModule.GetMemberReferences().Where(m=>Targets.Contains(Scope(m.DeclaringType)))){
                            try{var mr=r as MethodReference;var fr=r as FieldReference;if(mr!=null){var target=mr.Resolve();if(target==null||!Targets.Contains(target.Module.Assembly.Name.Name))throw new InvalidDataException("Missing target SDK method.");methods++;}else if(fr!=null){var target=fr.Resolve();if(target==null||!Targets.Contains(target.Module.Assembly.Name.Name))throw new InvalidDataException("Missing target SDK field.");fields++;}else throw new InvalidDataException("Unexpected SDK MemberRef kind.");}
                            catch(Exception e){missing++;if(errors.Count<64)errors.Add(new{kind="member",reference=r.FullName,error=e.Message});}
                        }
                    }
                }
                if(Sha(file)!=before)throw new InvalidDataException("Read-only input changed.");
                totalTypes+=types;totalMethods+=methods;totalFields+=fields;rows.Add(new{path=file,sha256=before,types,methods,fields,errors});
            }
            var report=new{schema="genuine-sdk-target-member-reference-closure/v1",status=missing==0?"passed":"failed",project_changed=false,game_or_sdk_code_executed=false,explicit_input_assemblies=files.Length,candidate_sdk=sdk,total_resolved_types=totalTypes,total_resolved_methods=totalMethods,total_resolved_fields=totalFields,unresolved=missing,inputs=rows};
            File.WriteAllText(args[3],new JavaScriptSerializer{MaxJsonLength=32*1024*1024,RecursionLimit=100}.Serialize(report));Console.WriteLine("SDK refs resolved="+(totalTypes+totalMethods+totalFields)+", missing="+missing+"; no SDK or game method invoked.");return missing==0?0:2;
        }catch(Exception error){Console.Error.WriteLine(error);return 1;}
    }
}
