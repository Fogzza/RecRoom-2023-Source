using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;

// Observation only: no Cecil dependency, PE/PDB edit, custom define, or code rewrite.
public sealed class WindowsDevelopmentDefineRecorder : ILPostProcessor
{
    public override ILPostProcessor GetInstance() { return new WindowsDevelopmentDefineRecorder(); }
    public override bool WillProcess(ICompiledAssembly assembly) { return assembly.Name == "RR23.WindowsDevelopment.DefineWitness"; }

    private static string Quote(string value)
    {
        var result = new StringBuilder("\"");
        foreach (char c in value)
        {
            if (c == '\\' || c == '"') result.Append('\\').Append(c);
            else if (c < 32) result.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
            else result.Append(c);
        }
        return result.Append('"').ToString();
    }

    private static string Hash(byte[] bytes)
    {
        if (bytes == null) return null;
        using (var algorithm = SHA256.Create()) return BitConverter.ToString(algorithm.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
    }

    public override ILPostProcessResult Process(ICompiledAssembly assembly)
    {
        try
        {
            var directory = Environment.GetEnvironmentVariable("RR23_DEFINE_PROBE_RECORD_DIRECTORY");
            if (string.IsNullOrEmpty(directory) || !Path.IsPathRooted(directory)) throw new InvalidOperationException("Absolute inherited record destination required");
            Directory.CreateDirectory(directory);
            var defines = assembly.Defines.OrderBy(d => d, StringComparer.Ordinal).ToArray();
            string text = "{\n  \"schema\": \"genuine-unity-ilpp-assembly-defines/v1\",\n  \"assembly_name\": " + Quote(assembly.Name) +
                ",\n  \"defines\": [" + string.Join(", ", defines.Select(Quote).ToArray()) +
                "],\n  \"pe_sha256\": " + Quote(Hash(assembly.InMemoryAssembly.PeData)) +
                ",\n  \"pdb_sha256\": " + (assembly.InMemoryAssembly.PdbData == null ? "null" : Quote(Hash(assembly.InMemoryAssembly.PdbData))) +
                ",\n  \"returned_original_in_memory_assembly\": true,\n  \"metadata_mutated\": false\n}\n";
            string path = Path.Combine(directory, (defines.Contains("UNITY_EDITOR") ? "Editor-" : "Player-") + Guid.NewGuid().ToString("N") + ".json");
            using (var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
            using (var writer = new StreamWriter(stream, new UTF8Encoding(false))) writer.Write(text);
            return new ILPostProcessResult(assembly.InMemoryAssembly);
        }
        catch (Exception error)
        {
            return new ILPostProcessResult(null, new List<DiagnosticMessage> { new DiagnosticMessage {
                DiagnosticType = DiagnosticType.Error, MessageData = "Define observation failed: " + error.ToString() } });
        }
    }
}
