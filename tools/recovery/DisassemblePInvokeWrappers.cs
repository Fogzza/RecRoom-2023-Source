// Bounded original bytes -> inert instruction records. No target assembly load.
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using Iced.Intel;
internal sealed class NativeText : FormatterOutput
{
    public readonly StringBuilder Value=new();
    public override void Write(string text,FormatterTextKind kind)=>Value.Append(text);
}
internal static class DisassemblePInvokeWrappers
{
    static object Operand(Instruction i,int index)
    {
        var kind=i.GetOpKind(index); string k=kind.ToString();
        return new {kind=k,register=kind==OpKind.Register?i.GetOpRegister(index).ToString():null,
            immediate=k.StartsWith("Immediate",StringComparison.Ordinal)?i.GetImmediate(index):0,
            target=k.StartsWith("NearBranch",StringComparison.Ordinal)?i.NearBranchTarget:0};
    }
    public static int Main(string[] args)
    {
        if(File.Exists(args[1]))throw new IOException("Fresh disassembly required");
        using var json=JsonDocument.Parse(File.ReadAllBytes(args[0]));
        var factory=new InstructionInfoFactory();var formatter=new IntelFormatter();var text=new NativeText();
        using var output=new StreamWriter(args[1],false,new UTF8Encoding(false));int methods=0,total=0;
        foreach(var row in json.RootElement.GetProperty("methods").EnumerateArray())
        {
            ulong va=Convert.ToUInt64(row.GetProperty("native_pointer").GetString().Substring(2),16);
            byte[] bytes=Convert.FromHexString(row.GetProperty("runtime_function").GetProperty("bytes").GetString());
            if(bytes.Length>65536)throw new InvalidDataException("Wrapper byte bound");
            var reader=new ByteArrayCodeReader(bytes);var decoder=Iced.Intel.Decoder.Create(64,reader);decoder.IP=va;
            var instructions=new List<object>();int consumed=0;
            while(reader.CanReadByte)
            {
                decoder.Decode(out var i);if(i.Code==Code.INVALID)throw new InvalidDataException("Invalid instruction inside complete wrapper range");
                text.Value.Clear();formatter.Format(i,text);var info=factory.GetInfo(i);
                var operands=Enumerable.Range(0,i.OpCount).Select(n=>Operand(i,n)).ToArray();
                instructions.Add(new {ip=i.IP,length=i.Length,code=i.Code.ToString(),mnemonic=i.Mnemonic.ToString(),flow=i.FlowControl.ToString(),text=text.Value.ToString(),operands,
                    memory=new {base_register=i.MemoryBase.ToString(),index=i.MemoryIndex.ToString(),scale=i.MemoryIndexScale,displacement=i.MemoryDisplacement64,ip_relative=i.IsIPRelativeMemoryOperand,ip_relative_address=i.IsIPRelativeMemoryOperand?i.IPRelativeMemoryAddress:0,size=i.MemorySize.GetSize()},
                    written_registers=info.GetUsedRegisters().Where(r=>r.Access is OpAccess.Write or OpAccess.CondWrite or OpAccess.ReadWrite or OpAccess.ReadCondWrite).Select(r=>r.Register.ToString()).ToArray(),
                    memory_accesses=info.GetUsedMemory().Select(m=>new {access=m.Access.ToString(),size=m.MemorySize.GetSize()}).ToArray()});
                consumed+=i.Length;if(instructions.Count>20000)throw new InvalidDataException("Instruction count bound");
            }
            if(consumed!=bytes.Length)throw new InvalidDataException("Incomplete disassembly");
            output.WriteLine(JsonSerializer.Serialize(new{native_method_index=row.GetProperty("original").GetProperty("index").GetInt32(),native_pointer=va,instructions}));methods++;total+=instructions.Count;
        }
        Console.WriteLine(JsonSerializer.Serialize(new{methods,instructions=total,no_game_or_fixture_code_executed=true}));return 0;
    }
}
