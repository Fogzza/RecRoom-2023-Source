// Trusted metadata processing/checks only; never load/execute inspected code.
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Mono.Cecil;
using RR23.MetadataRestoration;
using Unity.CompilationPipeline.Common.ILPostProcessing;

sealed class CurrentCompiledAssembly : ICompiledAssembly
{
    public InMemoryAssembly InMemoryAssembly { get; set; }
    public string Name { get { return "Assembly-CSharp"; } }
    public string[] References { get; set; }
    public string[] Defines { get { return new string[0]; } }
}
static class CurrentCoreChecks
{
    static string Hash(byte[] bytes) { using(var s=SHA256.Create())return BitConverter.ToString(s.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant(); }
    static int Main(string[] args)
    {
        try
        {
            if(args.Length!=4)throw new ArgumentException("actual-compiled-core.dll portable.pdb fresh-output-directory exact-reference-paths.txt");
            var output=Path.GetFullPath(args[2]);if(Directory.Exists(output)||File.Exists(output))throw new IOException("Fresh isolated output required");
            var pe=File.ReadAllBytes(args[0]);var pdb=File.ReadAllBytes(args[1]);if(pdb.Length<4||pdb[0]!=66||pdb[1]!=83||pdb[2]!=74||pdb[3]!=66)throw new InvalidDataException("Actual portable PDB required; no symbols may be silently dropped");
            var processor=new GeneralRR23MetadataPostProcessor();var input=new CurrentCompiledAssembly { InMemoryAssembly=new InMemoryAssembly(pe,pdb), References=File.ReadAllLines(args[3]).Where(s=>s.Length!=0).ToArray() };
            if(!processor.WillProcess(input))throw new InvalidDataException("Current core processor selection failed");
            var result=processor.Process(input);
            if(result.InMemoryAssembly==null||result.Diagnostics.Count!=0)throw new InvalidDataException("Whole-current-core V5 refused: "+string.Join(";",result.Diagnostics.Select(d=>d.MessageData)));
            if(result.InMemoryAssembly.PdbData.Length==0)throw new InvalidDataException("Current core symbols disappeared");
            Directory.CreateDirectory(output);
            File.WriteAllBytes(Path.Combine(output,"Assembly-CSharp.dll"),result.InMemoryAssembly.PeData);
            File.WriteAllBytes(Path.Combine(output,"Assembly-CSharp.pdb"),result.InMemoryAssembly.PdbData);
            File.WriteAllText(Path.Combine(output,"receipt.json"),"{\"schema\":\"actual-current-core-ilpp-roundtrip/v1\",\"input_pe_sha256\":\""+Hash(pe)+"\",\"input_pdb_sha256\":\""+Hash(pdb)+"\",\"output_pe_sha256\":\""+Hash(result.InMemoryAssembly.PeData)+"\",\"output_pdb_sha256\":\""+Hash(result.InMemoryAssembly.PdbData)+"\",\"actual_unity_ilpp_interface\":true,\"game_code_executed\":false,\"project_modified\":false}\n");
            Console.WriteLine("PASS: full CURRENT core exact-inventory metadata/reference reversal + original type/generic contract gate + unchanged IL/PDB semantics. Numeric tokens/RVAs may relocate. No gameplay execution.");return 0;
        }
        catch(Exception e) { Console.Error.WriteLine(e.ToString());return 1; }
    }
}
