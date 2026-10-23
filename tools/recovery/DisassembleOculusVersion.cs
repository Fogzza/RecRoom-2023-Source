using System;using System.IO;using System.Text;using System.Text.Json;using System.Collections.Generic;using Iced.Intel;
sealed class Output:FormatterOutput{public StringBuilder Text=new();public override void Write(string value,FormatterTextKind kind)=>Text.Append(value);}
static class Program
{
 static int Main(string[] args)
 {
  using var document=JsonDocument.Parse(File.ReadAllBytes(args[0]));var body=document.RootElement.GetProperty("version_cctor");var code=Convert.FromHexString(body.GetProperty("native_bytes").GetString());if(code.Length>16384)throw new InvalidDataException("Bounded original method required");ulong start=Convert.ToUInt64(body.GetProperty("native_pointer").GetString().Substring(2),16);var reader=new ByteArrayCodeReader(code);var decoder=Iced.Intel.Decoder.Create(64,reader);decoder.IP=start;var formatter=new IntelFormatter();var output=new Output();var instructions=new List<object>();
  while(reader.CanReadByte){decoder.Decode(out var ins);if(ins.Code==Code.INVALID)throw new InvalidDataException("Invalid original decode");output.Text.Clear();formatter.Format(ins,output);int offset=checked((int)(ins.IP-start));instructions.Add(new{offset,asm=output.Text.ToString(),bytes=Convert.ToHexString(code.AsSpan(offset,ins.Length)).ToLowerInvariant(),flow=ins.FlowControl.ToString(),branch_target="0x"+ins.NearBranchTarget.ToString("x"),memory_base=ins.MemoryBase.ToString(),memory_displacement="0x"+ins.MemoryDisplacement64.ToString("x")});}
  File.WriteAllText(args[1],JsonSerializer.Serialize(new{schema="original-oculus-version-cctor-disassembly/v1",original=body,native_code_executed=false,complete_decode=true,instructions},new JsonSerializerOptions{WriteIndented=true}));return 0;
 }
}
