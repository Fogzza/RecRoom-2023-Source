// Isolated prototype. Never copy into RR23 before whole-candidate verification.
using System;
using System.Collections.Generic;
using RR23.MetadataRestoration;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;

public sealed class GeneralRR23MetadataPostProcessor : ILPostProcessor
{
    public override ILPostProcessor GetInstance() { return new GeneralRR23MetadataPostProcessor(); }
    public override bool WillProcess(ICompiledAssembly assembly) { return assembly.Name == "Assembly-CSharp"; }
    public override ILPostProcessResult Process(ICompiledAssembly assembly)
    {
        try
        {
            var result = WholeMetadataRestorer.Restore(assembly.InMemoryAssembly.PeData, assembly.InMemoryAssembly.PdbData, assembly.References, assembly.Defines);
            return new ILPostProcessResult(new InMemoryAssembly(result.Pe, result.Pdb));
        }
        catch (Exception error)
        {
            return new ILPostProcessResult(null, new List<DiagnosticMessage> { new DiagnosticMessage {
                DiagnosticType = DiagnosticType.Error, MessageData = "Original metadata restoration refused: " + error.ToString() } });
        }
    }
}
