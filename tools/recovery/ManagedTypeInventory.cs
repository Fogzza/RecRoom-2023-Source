// Reads the CLR metadata tables directly; no assembly load or inspected IL.
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

static class ManagedTypeInventory
{
    static int Main(string[] args)
    {
        if(args.Length!=2||File.Exists(args[1]))throw new ArgumentException("input-managed.dll fresh-jsonl-output");
        using var input=File.OpenRead(args[0]);using var pe=new PEReader(input);var metadata=pe.GetMetadataReader();
        string Full(TypeDefinitionHandle handle,int depth=0){if(depth>64)throw new InvalidDataException("Nested type depth bound");var t=metadata.GetTypeDefinition(handle);var name=metadata.GetString(t.Name);var parent=t.GetDeclaringType();if(!parent.IsNil)return Full(parent,depth+1)+"/"+name;var ns=metadata.GetString(t.Namespace);return ns.Length==0?name:ns+"."+name;}
        using var stream=new StreamWriter(new FileStream(args[1],FileMode.CreateNew,FileAccess.Write));
        var count=0;foreach(var handle in metadata.TypeDefinitions){var t=metadata.GetTypeDefinition(handle);stream.WriteLine(JsonSerializer.Serialize(new{full_name=Full(handle),attributes=(uint)t.Attributes,fields=t.GetFields().Count,methods=t.GetMethods().Count}));count++;}
        Console.WriteLine("Read "+count+" managed TypeDef identities without loading inspected assemblies or bodies.");return 0;
    }
}
