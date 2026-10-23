// Exact in-memory instruction identity plus emitted normalized IL/PDB checks.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace RR23.MetadataRestoration
{
    public sealed class BodyAndSymbolSafety
    {
        private sealed class Snapshot
        {
            public MethodDefinition Method;
            public MethodBody Body;
            public Instruction[] Instructions;
            public Code[] Codes;
            public object[] Operands;
            public Instruction[][] SwitchTargets;
            public VariableDefinition[] Variables;
            public TypeReference[] VariableTypes;
            public ExceptionHandler[] Handlers;
            public string HandlerIdentity;
            public int MaxStack;
            public bool InitLocals;
            public string Debug;
        }
        private readonly Snapshot[] snapshots;
        private BodyAndSymbolSafety(Snapshot[] values) { snapshots = values; }
        private static string Hash(string value)
        {
            using (var sha = SHA256.Create()) return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "");
        }
        private static string Identity(object value) { return value == null ? "null" : RuntimeHelpers.GetHashCode(value).ToString(CultureInfo.InvariantCulture); }
        private static string HandlerIdentity(MethodBody body)
        {
            return string.Join("|", body.ExceptionHandlers.Select(h => (int)h.HandlerType + ":" + Identity(h.TryStart) + ":" + Identity(h.TryEnd)
                + ":" + Identity(h.HandlerStart) + ":" + Identity(h.HandlerEnd) + ":" + Identity(h.FilterStart) + ":" + Identity(h.CatchType)));
        }
        private static void Scope(StringBuilder output, ScopeDebugInformation scope, int codeSize, bool identity)
        {
            if (scope == null) { output.Append("no-scope"); return; }
            output.Append(scope.Start.Offset).Append(':').Append(scope.End.IsEndOfMethod ? codeSize : scope.End.Offset).Append('|');
            foreach (var variable in scope.Variables) output.Append(variable.Index).Append(':').Append(variable.Name).Append(':').Append((int)variable.Attributes).Append('|');
            foreach (var constant in scope.Constants) output.Append(constant.Name).Append(':').Append(identity ? Identity(constant.ConstantType) : constant.ConstantType.FullName).Append(':')
                .Append(Convert.ToString(constant.Value, CultureInfo.InvariantCulture)).Append('|');
            Import(output, scope.Import, identity);
            foreach (var child in scope.Scopes) Scope(output, child, codeSize, identity);
        }
        private static void Import(StringBuilder output, ImportDebugInformation import, bool identity)
        {
            if (import == null) return;
            foreach (var target in import.Targets)
                output.Append((int)target.Kind).Append(':').Append(target.Alias).Append(':').Append(target.Namespace).Append(':')
                    .Append(target.Type == null ? "" : identity ? Identity(target.Type) : target.Type.FullName).Append(':')
                    .Append(target.AssemblyReference == null ? "" : target.AssemblyReference.FullName).Append('|');
            Import(output, import.Parent, identity);
        }
        private static string Debug(MethodDefinition method, bool identity)
        {
            var output = new StringBuilder();
            foreach (var point in method.DebugInformation.SequencePoints)
            {
                var document = point.Document;
                output.Append(point.Offset).Append(':').Append(point.StartLine).Append(':').Append(point.StartColumn).Append(':')
                    .Append(point.EndLine).Append(':').Append(point.EndColumn).Append(':').Append(document.Url).Append(':')
                    .Append(document.Language).Append(':').Append(document.LanguageVendor).Append(':').Append(document.Type).Append(':')
                    .Append(document.HashAlgorithm).Append(':').Append(BitConverter.ToString(document.Hash)).Append('|');
            }
            string pointsHash = Hash(output.ToString()); output.Clear();
            Scope(output, method.DebugInformation.Scope, method.HasBody ? method.Body.CodeSize : 0, identity);
            string scopeHash = Hash(output.ToString()); output.Clear();
            foreach (var custom in method.DebugInformation.CustomDebugInformations)
            {
                var binary = custom as BinaryCustomDebugInformation;
                if (binary == null) throw new InvalidDataException("PDB custom debug data needs an explicit audit: " + custom.GetType().FullName);
                output.Append(custom.Identifier).Append(':').Append(BitConverter.ToString(binary.Data)).Append('|');
            }
            return pointsHash + ":" + scopeHash + ":" + Hash(output.ToString());
        }
        public static BodyAndSymbolSafety Capture(MethodDefinition[] methods)
        {
            return new BodyAndSymbolSafety(methods.Select(method => {
                var value = new Snapshot { Method = method, Body = method.HasBody ? method.Body : null, Debug = Debug(method, true) };
                if (value.Body == null) return value;
                value.Instructions = value.Body.Instructions.ToArray(); value.Codes = value.Instructions.Select(i => i.OpCode.Code).ToArray();
                value.Operands = value.Instructions.Select(i => i.Operand).ToArray();
                value.SwitchTargets = value.Operands.Select(o => o is Instruction[] ? ((Instruction[])o).ToArray() : null).ToArray();
                value.Variables = value.Body.Variables.ToArray(); value.VariableTypes = value.Variables.Select(v => v.VariableType).ToArray();
                value.Handlers = value.Body.ExceptionHandlers.ToArray(); value.HandlerIdentity = HandlerIdentity(value.Body);
                value.InitLocals = value.Body.InitLocals; value.MaxStack = value.Body.MaxStackSize;
                return value;
            }).ToArray());
        }
        public void VerifyObjectIdentity(MethodDefinition[] methods)
        {
            if (!snapshots.Select(s => s.Method).SequenceEqual(methods)) throw new InvalidDataException("Method inventory/order changed");
            foreach (var value in snapshots)
            {
                var method = value.Method;
                if (!ReferenceEquals(value.Body, method.HasBody ? method.Body : null)) throw new InvalidDataException("Method body replaced");
                if (value.Debug != Debug(method, true)) throw new InvalidDataException("Portable PDB information changed during restoration");
                if (value.Body == null) continue;
                if (!value.Instructions.SequenceEqual(value.Body.Instructions) || !value.Codes.SequenceEqual(value.Body.Instructions.Select(i => i.OpCode.Code))
                    || !value.Variables.SequenceEqual(value.Body.Variables) || !value.VariableTypes.SequenceEqual(value.Body.Variables.Select(v => v.VariableType))
                    || !value.Handlers.SequenceEqual(value.Body.ExceptionHandlers) || value.HandlerIdentity != HandlerIdentity(value.Body)
                    || value.InitLocals != value.Body.InitLocals || value.MaxStack != value.Body.MaxStackSize)
                    throw new InvalidDataException("Instruction/local/exception-region structure changed");
                for (int i = 0; i < value.Instructions.Length; i++)
                {
                    object actual = value.Instructions[i].Operand;
                    if (!ReferenceEquals(value.Operands[i], actual) && !Equals(value.Operands[i], actual)) throw new InvalidDataException("Instruction operand replaced");
                    if (value.SwitchTargets[i] != null && !value.SwitchTargets[i].SequenceEqual((Instruction[])actual))
                        throw new InvalidDataException("Switch branch targets changed");
                }
            }
        }
        private static string Normalized(MethodDefinition method)
        {
            var output = new StringBuilder();
            output.Append(method.HasBody).Append('|');
            if (!method.HasBody) return output.ToString();
            var body = method.Body; output.Append(body.InitLocals).Append('|');
            foreach (var variable in body.Variables) output.Append(variable.Index).Append(':').Append(ScopedMetadataSignatures.Type(variable.VariableType)).Append('|');
            foreach (var instruction in body.Instructions)
            {
                output.Append((int)instruction.OpCode.Code).Append(':'); object operand = instruction.Operand;
                if (operand is Instruction branch) output.Append("branch:").Append(body.Instructions.IndexOf(branch));
                else if (operand is Instruction[] branches) output.Append("switch:").Append(string.Join(",", branches.Select(b => body.Instructions.IndexOf(b))));
                else if (operand is ParameterDefinition parameter) output.Append("arg:").Append(parameter.Index);
                else if (operand is VariableDefinition variable) output.Append("local:").Append(variable.Index);
                else if (operand is MethodReference call) output.Append(ScopedMetadataSignatures.Type(call.DeclaringType)).Append(':').Append(ScopedMetadataSignatures.Method(call));
                else if (operand is FieldReference field) output.Append(ScopedMetadataSignatures.Type(field.DeclaringType)).Append(':').Append(field.Name).Append(':').Append(ScopedMetadataSignatures.Type(field.FieldType));
                else if (operand is TypeReference type) output.Append(ScopedMetadataSignatures.Type(type));
                else if (operand is Mono.Cecil.CallSite site) output.Append(site.FullName);
                else if (operand != null) output.Append(operand.GetType().FullName).Append(':').Append(Convert.ToString(operand, CultureInfo.InvariantCulture));
                output.Append('|');
            }
            foreach (var handler in body.ExceptionHandlers) output.Append((int)handler.HandlerType).Append(':')
                .Append(body.Instructions.IndexOf(handler.TryStart)).Append(':').Append(body.Instructions.IndexOf(handler.TryEnd)).Append(':')
                .Append(body.Instructions.IndexOf(handler.HandlerStart)).Append(':').Append(body.Instructions.IndexOf(handler.HandlerEnd)).Append(':')
                .Append(body.Instructions.IndexOf(handler.FilterStart)).Append(':').Append(handler.CatchType == null ? "" : ScopedMetadataSignatures.Type(handler.CatchType)).Append('|');
            return Hash(output.ToString());
        }
        public string[] CaptureNormalized(MethodDefinition[] methods) { return methods.Select(m => Normalized(m) + "@" + Debug(m, false)).ToArray(); }
        public void VerifyEmitted(string[] expected, MethodDefinition[] emitted)
        {
            if (emitted.Length != snapshots.Length) throw new InvalidDataException("Emitted method count differs");
            for (int i = 0; i < emitted.Length; i++)
            {
                if (expected[i] != Normalized(emitted[i]) + "@" + Debug(emitted[i], false))
                    throw new InvalidDataException("Emitted IL/PDB semantic roundtrip failed: " + emitted[i].FullName);
            }
        }
    }
}
