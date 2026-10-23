// Synthetic parser-only fixtures. No inspected game/SDK code is executed.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using RR23.MetadataRestoration;

internal static class ManifestStreamingFixtures
{
    private static int checks;
    private static long streamedObjects;
    private static void Need(bool value, string message)
    { if (!value) throw new InvalidDataException(message); }

    private static string Value(object item)
    {
        if (item == null) return "null;";
        var type = item.GetType();
        if (item is string text) return "S" + text.Length + ":" + text;
        if (type.IsPrimitive) return type.FullName + ":" + Convert.ToString(item, System.Globalization.CultureInfo.InvariantCulture) + ";";
        if (type.IsArray)
        {
            var result = new StringBuilder("[");
            foreach (object child in (Array)item) result.Append(Value(child));
            return result.Append("]").ToString();
        }
        Need(type.Namespace == "RR23.MetadataRestoration", "Only production manifest record objects allowed");
        var output = new StringBuilder(type.FullName + "{");
        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance).OrderBy(f => f.Name, StringComparer.Ordinal))
            output.Append(field.Name).Append(":").Append(Value(field.GetValue(item)));
        return output.Append("}").ToString();
    }

    private static void StreamValue(TextWriter output, object item)
    {
        streamedObjects++;
        if (item == null) { output.Write("null;"); return; }
        var type = item.GetType();
        if (item is string text) { output.Write('S'); output.Write(text.Length); output.Write(':'); output.Write(text); return; }
        if (type.IsPrimitive) { output.Write(type.FullName); output.Write(':'); output.Write(Convert.ToString(item, System.Globalization.CultureInfo.InvariantCulture)); output.Write(';'); return; }
        if (type.IsArray)
        {
            output.Write('[');
            foreach (object child in (Array)item) StreamValue(output, child);
            output.Write(']'); return;
        }
        Need(type.Namespace == "RR23.MetadataRestoration", "Only production manifest record objects allowed");
        output.Write(type.FullName); output.Write('{');
        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance).OrderBy(f => f.Name, StringComparer.Ordinal))
        { output.Write(field.Name); output.Write(':'); StreamValue(output, field.GetValue(item)); }
        output.Write('}');
    }

    private static int Full(string mode, string output)
    {
        WholeMetadataManifest manifest; long consumed, length;
        if (mode == "legacy")
        {
            // Invoke the actual unchanged production baseline Resource helper.
            var resource = typeof(WholeMetadataRestorer).GetMethod("Resource", BindingFlags.Static | BindingFlags.NonPublic);
            Need(resource != null, "Production baseline resource helper absent");
            var bytes = (byte[])resource.Invoke(null, new object[] { "RR23.GeneralManifest" });
            using (var stream = new MemoryStream(bytes))
            { manifest = WholeMetadataManifest.Read(stream); consumed = stream.Position; length = stream.Length; }
        }
        else
        {
            Need(mode == "direct", "Unknown full fixture mode");
            using (var stream = typeof(WholeMetadataRestorer).Assembly.GetManifestResourceStream("RR23.GeneralManifest"))
            {
                if (stream == null) throw new InvalidDataException("Missing pinned resource: RR23.GeneralManifest");
                manifest = WholeMetadataManifest.Read(stream); consumed = stream.Position; length = stream.Length;
            }
        }
        Need(consumed == length && length == 43088714, "Actual full embedded manifest consumption differs");
        string digest;
        using (var hash = SHA256.Create())
        using (var sink = new CryptoStream(Stream.Null, hash, CryptoStreamMode.Write))
        {
            using (var writer = new StreamWriter(sink, new UTF8Encoding(false), 4096, true)) StreamValue(writer, manifest);
            sink.FlushFinalBlock(); digest = BitConverter.ToString(hash.Hash).Replace("-", "").ToLowerInvariant();
        }
        string result = "{\"status\":\"passed\",\"mode\":\"" + mode + "\",\"production_reader_unchanged\":true,\"model_sha256\":\"" + digest
            + "\",\"model_values\":" + streamedObjects + ",\"exact_byte_consumption\":" + consumed + ",\"types\":" + manifest.Types.Length
            + ",\"methods\":" + manifest.Methods.Length + ",\"fields\":" + manifest.Fields.Length + ",\"definitions\":" + manifest.Definitions.Length + "}";
        File.WriteAllText(output, result + "\n"); Console.WriteLine(result); return 0;
    }

    private static Stream Resource(string name)
    {
        var stream = typeof(ManifestStreamingFixtures).Assembly.GetManifestResourceStream(name);
        if (stream == null) throw new InvalidDataException("Missing pinned resource: " + name);
        return stream;
    }

    private static WholeMetadataManifest Direct(string name, out long consumed)
    {
        // Same direct acquisition/guard/parser/disposal as the one-block candidate.
        WholeMetadataManifest manifest;
        using (var stream = typeof(ManifestStreamingFixtures).Assembly.GetManifestResourceStream(name))
        {
            if (stream == null) throw new InvalidDataException("Missing pinned resource: " + name);
            manifest = WholeMetadataManifest.Read(stream);
            consumed = stream.Position;
            Need(consumed == stream.Length, "Direct resource consumption differs");
        }
        return manifest;
    }

    private static WholeMetadataManifest Copied(string name, out long consumed)
    {
        byte[] bytes;
        using (var source = Resource(name)) using (var copy = new MemoryStream())
        { source.CopyTo(copy); bytes = copy.ToArray(); }
        using (var stream = new MemoryStream(bytes))
        { var value = WholeMetadataManifest.Read(stream); consumed = stream.Position; return value; }
    }

    private sealed class ShortReads : Stream
    {
        private readonly Stream inner;
        private readonly int maximum;
        private readonly bool seekable;
        public bool Disposed;
        public ShortReads(Stream value, int max, bool seek = true) { inner = value; maximum = max; seekable = seek; }
        public override bool CanRead => true;
        public override bool CanSeek => seekable;
        public override bool CanWrite => false;
        public override long Length { get { if (!seekable) throw new NotSupportedException(); return inner.Length; } }
        public override long Position { get { if (!seekable) throw new NotSupportedException(); return inner.Position; } set { if (!seekable) throw new NotSupportedException(); inner.Position = value; } }
        public override int Read(byte[] bytes, int offset, int count) => inner.Read(bytes, offset, Math.Min(count, maximum));
        public override int ReadByte() => inner.ReadByte();
        public override long Seek(long offset, SeekOrigin origin) { if (!seekable) throw new NotSupportedException(); return inner.Seek(offset, origin); }
        public override void Flush() { }
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] bytes, int offset, int count) => throw new NotSupportedException();
        protected override void Dispose(bool disposing) { Disposed = true; if (disposing) inner.Dispose(); base.Dispose(disposing); }
    }

    private static void Reject(string name, Type expected)
    {
        try { long ignored; Direct(name, out ignored); }
        catch (Exception error) { Need(error.GetType() == expected, "Unexpected refusal type for " + name + ":" + error.GetType().FullName); checks++; return; }
        throw new InvalidDataException("Malformed resource accepted: " + name);
    }

    public static int Main(string[] args)
    {
        try
        {
            if (args.Length == 3 && args[0] == "--full") return Full(args[1], args[2]);
            long directBytes, copiedBytes;
            var direct = Direct("Fixture.Valid", out directBytes);
            var copied = Copied("Fixture.Valid", out copiedBytes);
            string canonical = Value(direct);
            Need(canonical == Value(copied) && directBytes == copiedBytes && directBytes == Int64.Parse(args[0]), "Copied/direct semantic or byte-consumption mismatch"); checks++;
            Need(direct.AssemblyName == "FixtureCore_Ω😀" && direct.Types.Length == 1 && direct.Methods.Length == 1 && direct.Fields.Length == 1
                && direct.Definitions.Length == 1 && direct.ReadonlyAttributes.Length == 1 && direct.UnrecoveredMethods.Length == 1
                && direct.CompilerAdapters.Length == 1 && direct.CompilerAddedConstructors.Length == 1 && direct.EmptyExterns.Length == 1
                && direct.SerializationFieldWitnesses.Length == 1, "Full V6 branch coverage fixture differs"); checks++;
            foreach (int chunk in new[] { 1, 3, 7 })
            {
                var shortStream = new ShortReads(Resource("Fixture.Valid"), chunk);
                using (shortStream)
                {
                    Need(Value(WholeMetadataManifest.Read(shortStream)) == canonical && shortStream.Position == directBytes, "Short read semantic/consumption mismatch");
                }
                Need(shortStream.Disposed, "Resource wrapper not disposed"); checks++;
            }
            foreach (string name in new[] { "WrongSchema", "NegativeTypeCount", "TooManyTypes", "NegativeStringCount", "TooManyStrings", "NegativeBlobCount", "TooLargeBlobCount", "TruncatedBlob", "TrailingByte" })
                Reject("Fixture." + name, typeof(InvalidDataException));
            Reject("Fixture.Truncated", typeof(EndOfStreamException));
            Reject("Fixture.Missing", typeof(InvalidDataException));
            var nonseekable = new ShortReads(Resource("Fixture.Valid"), 3, false);
            try { using (nonseekable) WholeMetadataManifest.Read(nonseekable); throw new InvalidDataException("Nonseekable bypassed strict end check"); }
            catch (NotSupportedException) { Need(nonseekable.Disposed, "Refused resource not disposed"); checks++; }
            string result = "{\"status\":\"passed\",\"checks\":" + checks + ",\"full_V6_semantics_equal\":true,\"exact_byte_consumption\":" + directBytes + ",\"game_or_SDK_code_executed\":false}";
            File.WriteAllText(args[1], result + "\n"); Console.WriteLine(result); return 0;
        }
        catch (Exception error) { Console.Error.WriteLine(error); return 1; }
    }
}
