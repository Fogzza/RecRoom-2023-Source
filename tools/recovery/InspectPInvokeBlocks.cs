using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using Iced.Intel;
using Decoder = Iced.Intel.Decoder;
static class InspectPInvokeBlocks
{
 sealed class Output:FormatterOutput{public StringBuilder Text=new();public override void Write(string text,FormatterTextKind kind)=>Text.Append(text);}
 public static int Main(string[] args){using var input=JsonDocument.Parse(File.ReadAllBytes(args[0]));var rows=new List<object>();foreach(var r in input.RootElement.EnumerateArray()){var va=Convert.ToUInt64(r.GetProperty("va").GetString()![2..],16);var bytes=Convert.FromHexString(r.GetProperty("bytes").GetString()!);if(bytes.Length>4096)throw new InvalidDataException("Bounded original runtime range required");var reader=new ByteArrayCodeReader(bytes);var decoder=Decoder.Create(64,reader);decoder.IP=va;var fmt=new IntelFormatter();var text=new Output();var instructions=new List<object>();while(reader.CanReadByte){decoder.Decode(out var i);if(i.Code==Code.INVALID)throw new InvalidDataException("Invalid original opcode");var at=checked((int)(i.IP-va));text.Text.Clear();fmt.Format(i,text);instructions.Add(new{offset=at,va="0x"+i.IP.ToString("x"),length=i.Length,bytes=Convert.ToHexString(bytes.AsSpan(at,i.Length)).ToLowerInvariant(),asm=text.Text.ToString(),flow=i.FlowControl.ToString(),rip_memory=i.IsIPRelativeMemoryOperand?"0x"+i.IPRelativeMemoryAddress.ToString("x"):null,branch_target=i.FlowControl is FlowControl.Call or FlowControl.ConditionalBranch or FlowControl.UnconditionalBranch?"0x"+i.NearBranchTarget.ToString("x"):null});}rows.Add(new{name=r.GetProperty("name").GetString(),va="0x"+va.ToString("x"),instructions});}File.WriteAllText(args[1],JsonSerializer.Serialize(rows,new JsonSerializerOptions{WriteIndented=true}));return 0;}
}
