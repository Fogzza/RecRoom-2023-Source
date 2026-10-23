// Only these explicit test subjects execute. Actual game/provider assemblies
// are read with Cecil, never loaded or invoked. Exact getter bodies inserted.
using System;
using System.Linq;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
namespace RecoveryTitleLeafEffects
{
    class FakeObject
    {
        public bool Alive=true;
        public static bool operator ==(FakeObject a,FakeObject b){throw new Exception("unexpected Unity fake-null normalization");}
        public static bool operator !=(FakeObject a,FakeObject b){throw new Exception("unexpected Unity comparison");}
        public override bool Equals(object x){throw new Exception("unexpected Equals");}
        public override int GetHashCode(){return 1;}
    }
    sealed class Camera:FakeObject{}
    sealed class ScreenWorldSpaceUIAnchor:FakeObject{}
    sealed class GameObject:FakeObject{}
    sealed class InputSubject
    {
        private Camera COMLJLOEGCA;
        public Camera ControllerCamera {get {/*LEAF0_BODY*/}}
        public void Set(Camera value){COMLJLOEGCA=value;}
    }
    sealed class HUDSubject
    {
        private ScreenWorldSpaceUIAnchor worldSpaceUIAnchor;
        public ScreenWorldSpaceUIAnchor WorldSpaceUIAnchor {get {/*LEAF1_BODY*/}}
        public void Set(ScreenWorldSpaceUIAnchor value){worldSpaceUIAnchor=value;}
    }
    sealed class AnchorSubject
    {
        private GameObject CDLPNIKNKPB;
        public GameObject AttachedGameObject {get {/*LEAF2_BODY*/}}
        public void Set(GameObject value){CDLPNIKNKPB=value;}
    }
    static class Program
    {
        static int cases;
        static void Need(bool x,string why){if(!x)throw new Exception(why);}
        static bool Same(object a,object b){return System.Object.ReferenceEquals(a,b);}
        static void Done(){cases++;}
        static void Cases<TSubject,TValue>(Func<TSubject> create,Action<TSubject,TValue> set,Func<TSubject,TValue> get,Func<TValue> value) where TValue:FakeObject
        {
            var x=create();Need(Same(get(x),null),"same null field reference");Done();
            var a=value();set(x,a);Need(Same(get(x),a)&&Same(get(x),a),"same stored live reference, no field mutation");Done();
            a.Alive=false;Need(Same(get(x),a),"destroyed-style non-null object must remain raw reference");Done();
            var y=create();var b=value();set(y,b);Need(Same(get(x),a)&&Same(get(y),b),"separate original instance fields");Done();
            set(x,b);Need(Same(get(x),b),"fresh field read after replacement");set(x,null);Need(Same(get(x),null),"fresh field read after clearing");Done();
        }
        static void Effects()
        {
            Cases(()=>new InputSubject(),(x,v)=>x.Set(v),x=>x.ControllerCamera,()=>new Camera());
            Cases(()=>new HUDSubject(),(x,v)=>x.Set(v),x=>x.WorldSpaceUIAnchor,()=>new ScreenWorldSpaceUIAnchor());
            Cases(()=>new AnchorSubject(),(x,v)=>x.Set(v),x=>x.AttachedGameObject,()=>new GameObject());
            Need(cases==15,"exact finite15 raw-reference cases");Console.WriteLine("{\"status\":\"fifteen_exact_title_leaf_raw_reference_effect_cases_passed\",\"cases\":15,\"Unity_or_game_invoked\":false}");
        }
        sealed class Row
        {
            public string Owner,Property,RawProperty,RawField,Field,Return;public uint MethodToken,FieldToken;public ulong Rva;public int Offset;
            public Row(string o,string p,string rp,string rf,string f,string r,uint mt,uint ft,ulong va,int offset){Owner=o;Property=p;RawProperty=rp;RawField=rf;Field=f;Return=r;MethodToken=mt;FieldToken=ft;Rva=va;Offset=offset;}
        }
        static readonly Row[] Rows={new Row("RecRoom.Core.UI.UIInputModule","ControllerCamera","JDIMEJBGLOD","<COMLJLOEGCA>k__BackingField","COMLJLOEGCA","UnityEngine.Camera",0x06012701,0x0400c015,0x91e5a0,136),new Row("RecRoom.Core.ScreenHUD","WorldSpaceUIAnchor","DHLENCINJNN","worldSpaceUIAnchor","worldSpaceUIAnchor","RecRoom.Core.ScreenWorldSpaceUIAnchor",0x06011563,0x0400b155,0x6fa000,24),new Row("RecRoom.Core.ScreenWorldSpaceUIAnchor","AttachedGameObject","IBIOIDDEFIG","<CDLPNIKNKPB>k__BackingField","CDLPNIKNKPB","UnityEngine.GameObject",0x060115c6,0x0400b19b,0x75c700,48)};
        static uint OriginalToken(ICustomAttributeProvider provider)
        {
            var attr=provider.CustomAttributes.Single(x=>x.AttributeType.FullName=="Cpp2IlInjected.TokenAttribute");return Convert.ToUInt32(attr.Fields.Single(x=>x.Name=="Token").Argument.Value.ToString(),16);
        }
        static string Injected(ICustomAttributeProvider provider,string attribute,string name)
        {var attr=provider.CustomAttributes.Single(x=>x.AttributeType.FullName=="Cpp2IlInjected."+attribute);return attr.Fields.Single(x=>x.Name==name).Argument.Value.ToString();}
        static string Scope(TypeReference t)
        {if(t.Scope is AssemblyNameReference a)return a.Name;if(t.Scope is ModuleDefinition m)return m.Assembly.Name.Name;throw new Exception("unsupported original field/return scope");}
        static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
        static int normalizations;
        static bool ExactOwnerFieldTypes(TypeDefinition old,TypeDefinition actual,ModuleDefinition rawSdk,ModuleDefinition projectedSdk)
        {
            if(old.Fields.Count!=actual.Fields.Count)return false;
            for(int i=0;i<old.Fields.Count;i++)
            {
                var a=old.Fields[i];var b=actual.Fields[i];if(a.FieldType.FullName==b.FieldType.FullName)continue;
                Need(old.FullName=="RecRoom.Core.UI.UIInputModule"&&i==15&&a.Name=="onPointerPressed"&&b.Name==a.Name&&a.Attributes==b.Attributes&&OriginalToken(a)==0x0400c013u,"only exact original UI field15 may use proven generic name projection");
                var x=a.FieldType as GenericInstanceType;var y=b.FieldType as GenericInstanceType;
                Need(x!=null&&y!=null&&x.ElementType.FullName=="HHOBPMOCKMJ"&&y.ElementType.FullName=="HHOBPMOCKMJ`1"&&!x.ElementType.IsValueType&&!y.ElementType.IsValueType&&Scope(x.ElementType)=="RecRoom.Datastructures.Runtime"&&Scope(y.ElementType)=="RecRoom.Datastructures.Runtime"&&x.GenericArguments.Count==1&&y.GenericArguments.Count==1&&x.GenericArguments[0].FullName=="UnityEngine.GameObject"&&y.GenericArguments[0].FullName=="UnityEngine.GameObject"&&Scope(x.GenericArguments[0])=="UnityEngine.CoreModule"&&Scope(y.GenericArguments[0])=="UnityEngine.CoreModule","exact sole named generic element/argument/scopes");
                Need(rawSdk.Assembly.Name.FullName==projectedSdk.Assembly.Name.FullName&&rawSdk.Assembly.Name.FullName=="RecRoom.Datastructures.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null","same original/projected SDK identity");
                var raw=Types(rawSdk.Types).Single(t=>t.FullName=="HHOBPMOCKMJ");var projection=Types(projectedSdk.Types).Single(t=>t.FullName=="HHOBPMOCKMJ`1");
                Need(raw.MetadataToken.ToUInt32()==0x02000032u&&projection.MetadataToken.ToUInt32()==0x02000032u&&raw.GenericParameters.Count==1&&projection.GenericParameters.Count==1&&raw.GenericParameters[0].Position==0&&projection.GenericParameters[0].Position==0&&raw.GenericParameters[0].Name=="T"&&projection.GenericParameters[0].Name=="T"&&(int)raw.GenericParameters[0].Attributes==0&&(int)projection.GenericParameters[0].Attributes==0,"same native-proved TypeDef32 and sole original T arity/flags");normalizations++;
            }
            return true;
        }
        static void Inspect(string originalPath,string fullPath,string rawSdkPath,string projectedSdkPath)
        {
            using(var original=ModuleDefinition.ReadModule(originalPath,new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false}))using(var compiled=ModuleDefinition.ReadModule(fullPath,new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false}))using(var rawSdk=ModuleDefinition.ReadModule(rawSdkPath,new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false}))using(var projectedSdk=ModuleDefinition.ReadModule(projectedSdkPath,new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false}))
            {
                foreach(var r in Rows)
                {
                    var old=Types(original.Types).Single(x=>x.FullName==r.Owner);var actual=Types(compiled.Types).Single(x=>x.FullName==r.Owner);var om=old.Methods.Single(x=>x.Name=="get_"+r.Property&&x.Parameters.Count==0);var of=old.Fields.Single(x=>x.Name==r.RawField);
                    Need(OriginalToken(om)==r.MethodToken&&OriginalToken(of)==r.FieldToken&&Convert.ToUInt64(Injected(om,"AddressAttribute","RVA"),16)==r.Rva&&Convert.ToInt32(Injected(of,"FieldOffsetAttribute","Offset"),16)==r.Offset,"original provider getter/field tokens, RVA and offset exactly match native table");Need(old.Properties.Single(x=>x.Name==r.RawProperty).GetMethod==om&&om.ReturnType.FullName==r.Return&&of.FieldType.FullName==r.Return&&Scope(om.ReturnType)==Scope(of.FieldType),"original PropertyDef getter ownership and field/return identity+scope");
                    if(r.RawField!=r.Field)
                    {
                        Need(of.CustomAttributes.Any(x=>x.AttributeType.FullName=="System.Runtime.CompilerServices.CompilerGeneratedAttribute")&&r.RawField=="<"+r.Field+">k__BackingField"&&!old.Properties.Any(x=>x.Name==r.Field)&&!old.Fields.Any(x=>x.Name==r.Field),"exact published export rename branch, no original enclosed-name field/property collision");
                    }
                    var p=actual.Properties.Single(x=>x.Name==r.Property);var m=p.GetMethod;var field=actual.Fields.Single(x=>x.Name==r.Field);Need(!actual.Properties.Any(x=>x.Name==r.Field)&&!field.IsStatic&&field.IsPrivate&&field.FieldType.FullName==r.Return&&m.ReturnType.FullName==r.Return&&m.Parameters.Count==0&&!m.IsStatic&&m.IsPublic,"exact current source property and declared private field");
                    Need(old.Fields.Count==actual.Fields.Count&&old.Fields.IndexOf(of)==actual.Fields.IndexOf(field)&&ExactOwnerFieldTypes(old,actual,rawSdk,projectedSdk),"complete original/export owner field count/type sequence and selected field ordinal");Need(Scope(field.FieldType)==Scope(m.ReturnType)&&Scope(field.FieldType)==Scope(of.FieldType),"actual compiled original logical field/return assembly scope");
                    var il=m.Body.Instructions.ToArray();Need(il.Select(x=>x.OpCode.Code).SequenceEqual(new[]{Code.Nop,Code.Ldarg_0,Code.Ldfld,Code.Stloc_0,Code.Br_S,Code.Ldloc_0,Code.Ret})&&Same(il[4].Operand,il[5]),"exact debug Csc raw field return IL, no call/comparison/cache/extra effect");var read=(FieldReference)il[2].Operand;Need(read.DeclaringType.FullName==r.Owner&&read.Name==r.Field&&read.FieldType.FullName==r.Return&&read.Resolve()==field,"actual getter binds same exact declared original field");Need(m.Body.Variables.Count==1&&m.Body.Variables[0].VariableType.FullName==r.Return&&m.Body.ExceptionHandlers.Count==0,"only return local and no handlers");
                }
                Need(normalizations==1,"exactly one proven metadata arity-name projection, every other field type exact");
                Console.WriteLine("{\"status\":\"three_title_leaf_original_provider_rename_and_full_file_field_bindings_verified\",\"getters\":3,\"game_invoked\":false}");
            }
        }
        static int Main(string[] args){try{if(args.Length==0)Effects();else if(args.Length==5&&args[0]=="--inspect")Inspect(args[1],args[2],args[3],args[4]);else throw new Exception("invalid fixture arguments");return 0;}catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}}
    }
}
