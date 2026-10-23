// Isolated tool fixtures. Client assemblies and gameplay code are never executed.
using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using RR23.MetadataRestoration;

static class SerializationFieldWitnessFixtures
{
 sealed class Fixture:IDisposable
 {
  public ModuleDefinition Raw,Old;public FieldDefinition RawField,OldField;public SerializationFieldWitnessPlan Plan;
  public Fixture(){Raw=Make(false);Old=Make(true);RawField=Raw.Types.Single(t=>t.Name=="RolePermissionEditableBase`3").Fields.Single();OldField=Old.Types.Single(t=>t.Name=="RolePermissionEditableBase`3").Fields.Single();Plan=new SerializationFieldWitnessPlan{OriginalType=RawField.DeclaringType.FullName,OriginalField="permission",RawCanonicalType="!2;",LegacyCanonicalType="!1;",RawProviderFieldToken=RawField.MetadataToken.ToUInt32(),LegacyProviderFieldToken=OldField.MetadataToken.ToUInt32(),OriginalNativeFieldToken=0x04007553,OriginalNativeOwnerToken=0x02002086};}
  public void Dispose(){Raw.Dispose();Old.Dispose();}
  static CustomAttribute Token(ModuleDefinition module,uint token){var owner=new TypeReference("Cpp2IlInjected","TokenAttribute",module,module);var ctor=new MethodReference(".ctor",module.TypeSystem.Void,owner){HasThis=true};var a=new CustomAttribute(ctor);a.Fields.Add(new CustomAttributeNamedArgument("Token",new CustomAttributeArgument(module.TypeSystem.String,"0x"+token.ToString("x8"))));return a;}
  static ModuleDefinition Make(bool old){using(var module=ModuleDefinition.CreateModule("Assembly-CSharp",ModuleKind.Dll)){var type=new TypeDefinition("RecRoom.Systems.PlayerRoles.UI","RolePermissionEditableBase`3",TypeAttributes.Public,module.TypeSystem.Object);module.Types.Add(type);for(int i=0;i<3;i++)type.GenericParameters.Add(new GenericParameter("T"+i,type));var field=new FieldDefinition("permission",FieldAttributes.Family,type.GenericParameters[old?1:2]);type.Fields.Add(field);if(old){type.CustomAttributes.Add(Token(module,0x02002086));field.CustomAttributes.Add(Token(module,0x04007553));}using(var stream=new MemoryStream()){module.Write(stream);return ModuleDefinition.ReadModule(new MemoryStream(stream.ToArray()),new ReaderParameters{ReadingMode=ReadingMode.Immediate});}}}
 }
 static void Need(bool value,string message){if(!value)throw new InvalidDataException(message);}
 static int count;
 static void Reject(string name,Action<Fixture> mutate){using(var f=new Fixture()){mutate(f);try{SerializationFieldIdentityWitness.Resolve(f.Old,f.RawField,"!2;",new[]{f.Plan});}catch(Exception e)when(e is InvalidDataException||e is FormatException||e is ArgumentException||e is NotSupportedException){count++;return;}throw new InvalidDataException("Invalid serialization witness accepted: "+name);}}
 public static int Main(){using(var f=new Fixture()){var rawType=f.RawField.FieldType;var oldType=f.OldField.FieldType;var old=SerializationFieldIdentityWitness.Resolve(f.Old,f.RawField,"!2;",new[]{f.Plan});Need(ReferenceEquals(old,f.OldField)&&ReferenceEquals(rawType,f.RawField.FieldType)&&ReferenceEquals(oldType,f.OldField.FieldType)&&CanonicalMetadataSignatures.Type(f.RawField.FieldType)=="!2;"&&CanonicalMetadataSignatures.Type(old.FieldType)=="!1;","Exact attribute-owner selection changed either provider TypeSpec");count++;}
  Reject("raw CLI token",f=>f.Plan.RawProviderFieldToken++);
  Reject("old CLI token",f=>f.Plan.LegacyProviderFieldToken++);
  Reject("original native field token",f=>f.Plan.OriginalNativeFieldToken++);
  Reject("original native owner token",f=>f.Plan.OriginalNativeOwnerToken++);
  Reject("wrong native field table",f=>f.Plan.OriginalNativeFieldToken=0x06007553);
  Reject("wrong native owner table",f=>f.Plan.OriginalNativeOwnerToken=0x04002086);
  Reject("raw canonical",f=>f.Plan.RawCanonicalType="!1;");
  Reject("old canonical",f=>f.Plan.LegacyCanonicalType="!2;");
  Reject("raw actual TypeSpec",f=>f.RawField.FieldType=f.RawField.DeclaringType.GenericParameters[1]);
  Reject("old actual TypeSpec",f=>f.OldField.FieldType=f.OldField.DeclaringType.GenericParameters[2]);
  Reject("field plan name",f=>f.Plan.OriginalField="permissionX");
  Reject("owner plan name",f=>f.Plan.OriginalType+="X");
  Reject("old field name",f=>f.OldField.Name+="X");
  Reject("old owner name",f=>f.OldField.DeclaringType.Name+="X");
  Reject("raw field name",f=>f.RawField.Name+="X");
  Reject("raw owner name",f=>f.RawField.DeclaringType.Name+="X");
  Reject("absent original field TokenAttribute",f=>f.OldField.CustomAttributes.Clear());
  Reject("absent original owner TokenAttribute",f=>f.OldField.DeclaringType.CustomAttributes.Clear());
  Reject("duplicate original field TokenAttribute",f=>f.OldField.CustomAttributes.Add(f.OldField.CustomAttributes[0]));
  Reject("duplicate original Token named field",f=>f.OldField.CustomAttributes[0].Fields.Add(f.OldField.CustomAttributes[0].Fields[0]));
  Reject("nonhex original Token",f=>{var a=f.OldField.CustomAttributes[0];a.Fields.Clear();a.Fields.Add(new CustomAttributeNamedArgument("Token",new CustomAttributeArgument(f.Old.TypeSystem.String,"bad")));});
  using(var f=new Fixture()){foreach(var plans in new[]{new SerializationFieldWitnessPlan[0],new[]{f.Plan,f.Plan}}){try{SerializationFieldIdentityWitness.Resolve(f.Old,f.RawField,"!2;",plans);}catch(InvalidDataException){count++;continue;}throw new InvalidDataException("Missing/duplicate witness rows accepted");}try{SerializationFieldIdentityWitness.Resolve(f.Old,f.RawField,"!0;",new[]{f.Plan});}catch(InvalidDataException){count++;goto Passed;}throw new InvalidDataException("Wrong expected raw TypeSpec accepted");}
 Passed:Console.WriteLine("PASS "+count+" production serialization-field resolver fixtures; metadata-only, no inspected/game code executed.");return 0;
 }
}
