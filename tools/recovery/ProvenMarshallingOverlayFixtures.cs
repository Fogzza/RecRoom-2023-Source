// Trusted parser/identity fixtures only; no inspected assembly is loaded or run.
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using RR23.MetadataRestoration;
static class ProvenMarshallingOverlayFixtures
{
    static string Hash(byte[] b){using(var h=SHA256.Create())return BitConverter.ToString(h.ComputeHash(b)).Replace("-","").ToLowerInvariant();}
    static int Main(string[] args)
    {
        try
        {
            if(args.Length!=2)throw new ArgumentException("binary-plan mutation-cases.txt");
            var read=typeof(ProvenMarshallingOverlay).GetMethod("Read",BindingFlags.NonPublic|BindingFlags.Static);
            var original=File.ReadAllBytes(args[0]);int passed=0;
            Action<byte[],string,bool> check=(data,hash,fail)=>{
                bool refused=false;
                try {var call=new object[]{data,hash,null};var rows=(Array)read.Invoke(null,call);if(rows.Length!=1312||((string)call[2]).Length!=64)throw new Exception("Incomplete parsed overlay");}
                catch(TargetInvocationException e){if(!(e.InnerException is InvalidDataException)&&!(e.InnerException is EndOfStreamException)&&!(e.InnerException is NotSupportedException))throw;refused=true;}
                if(refused!=fail)throw new Exception("Parser fixture did not enforce exact expectation");passed++;
            };
            check(original,Hash(original),false);check(original,new string('0',64),true);
            check(original.Concat(new byte[]{0}).ToArray(),Hash(original.Concat(new byte[]{0}).ToArray()),true);
            check(original.Take(original.Length-1).ToArray(),Hash(original.Take(original.Length-1).ToArray()),true);
            foreach(var line in File.ReadAllLines(args[1]))
            {
                if(line.Length==0)continue;var pieces=line.Split(' ');var changed=(byte[])original.Clone();int offset=int.Parse(pieces[0]),value=int.Parse(pieces[2]);
                if(pieces[1]=="i32")Buffer.BlockCopy(BitConverter.GetBytes(value),0,changed,offset,4);else if(pieces[1]=="byte")changed[offset]=(byte)value;else throw new Exception("Unknown fixture mutation");
                check(changed,Hash(changed),true);
            }
            Console.WriteLine("PASS: "+passed+" bounded production overlay-parser controls; no game/SDK code executed");return 0;
        }
        catch(Exception e){Console.Error.WriteLine(e.ToString());return 1;}
    }
}
