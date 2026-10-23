using System;
using System.IO;
using Mono.Cecil;
using RR23.MetadataRestoration;
static class MetadataRoundTripDiagnosticsFixtures
{
 static int passed;
 static ModuleDefinition Make(){var m=ModuleDefinition.CreateModule("DiagnosticFixture",ModuleKind.Dll);var t=new TypeDefinition("Fixture","Owner",TypeAttributes.Public,m.TypeSystem.Object);m.Types.Add(t);var f=new FieldDefinition("value",FieldAttributes.Private,m.TypeSystem.Int32);f.Constant=42;t.Fields.Add(f);t.Fields.Add(new FieldDefinition("other",FieldAttributes.Private,m.TypeSystem.Int32));var method=new MethodDefinition("Method",MethodAttributes.Public,m.TypeSystem.Void);var p=new ParameterDefinition("parameter",ParameterAttributes.Optional,m.TypeSystem.Int32);p.Constant=7;method.Parameters.Add(p);t.Methods.Add(method);return m;}
 static TypeDefinition Owner(ModuleDefinition m){return m.Types[1];}
 static void Need(bool ok,string message){if(!ok)throw new InvalidDataException(message);}
 static void Change(string component,Action<ModuleDefinition> mutate){using(var m=Make()){var before=MetadataRoundTripDiagnostics.Capture(m);mutate(m);var text=MetadataRoundTripDiagnostics.Difference(before,m);Need(text.Contains(component)&&!text.Contains("changed=0 added=0 missing=0"),"Missing component diagnostic: "+component+" "+text);Need(!text.Contains("sensitive-literal-constant"),"Literal data leaked");passed++;}}
 public static int Main(){using(var m=Make()){var before=MetadataRoundTripDiagnostics.Capture(m);Need(before.Count>0&&MetadataRoundTripDiagnostics.Difference(before,m).Contains("changed=0 added=0 missing=0"),"Equal metadata reported different");passed++;}
  Change(".flags-offset",m=>Owner(m).Fields[0].IsStatic=true);
  Change(".hasconstant-value",m=>Owner(m).Fields[0].Constant=43);
  Change(".parameter-name-flags",m=>Owner(m).Methods[0].Parameters[0].IsOptional=false);
  Change(".parameter-hasconstant-values",m=>Owner(m).Methods[0].Parameters[0].Constant=9);
  Change(".flags-impl-semantics",m=>Owner(m).Methods[0].IsSpecialName=true);
  Change(".return-name-flags",m=>Owner(m).Methods[0].MethodReturnType.Name="result");
  Change(".initial-data",m=>Owner(m).Fields[0].InitialValue=new byte[]{1,2,3,4});
  Change(".name-type",m=>Owner(m).Fields[0].FieldType=m.TypeSystem.Int64);
  Change("assembly.references-order",m=>m.AssemblyReferences.Add(new AssemblyNameReference("Extra",new Version(1,0))));
  Change(".flags-layout-base",m=>Owner(m).IsExplicitLayout=true);
  Change(".attrs",m=>{var ctor=new MethodReference(".ctor",m.TypeSystem.Void,new TypeReference("Fixture","Marker",m,m)){HasThis=true};Owner(m).Fields[0].CustomAttributes.Add(new CustomAttribute(ctor,new byte[]{1,0,0,0}));});
  Change(".signature",m=>Owner(m).Methods[0].ReturnType=m.TypeSystem.Int32);
  Change(".hasconstant-value",m=>Owner(m).Fields[0].Constant="sensitive-literal-constant");
  using(var m=Make()){var before=MetadataRoundTripDiagnostics.Capture(m);var fields=Owner(m).Fields;var f=fields[0];fields.RemoveAt(0);fields.Add(f);Need(!MetadataRoundTripDiagnostics.Difference(before,m).Contains("changed=0 added=0 missing=0"),"Field ordering ignored");passed++;}
  Console.WriteLine("PASS "+passed+" narrow metadata-row diagnostic fixtures; no client code executed.");return 0;}
}
