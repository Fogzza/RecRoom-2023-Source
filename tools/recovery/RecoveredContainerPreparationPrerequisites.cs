// Native-proven selected members only, outside Assets compilation.
// Legal aliases below must map to the existing raw generated metadata exactly.
// Never import declarations wholesale or synthesize production lambda helpers.
using System;
using System.Collections.Generic;
using System.Linq;
public partial class MNALHHOLFGL
{
    // Alias for original MNALHHOLFGL/<>c; its two existing fields are retained.
    internal sealed class ResolveClosureAlias
    {
        public static readonly ResolveClosureAlias Singleton;
        public static Func<KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>,NJAICAFMPBE> CachedSelector;
        // Original47904. The native allocation calls the genuinely empty ctor.
        static ResolveClosureAlias(){Singleton=new ResolveClosureAlias();}
        // Original47905 already has only System.Object construction; keep it.
        public ResolveClosureAlias(){}
        // Original47906; exact inlined MethodSpec200365 KeyValuePair.Value.
        internal NJAICAFMPBE SelectProvider(KeyValuePair<CPAMAFPANDM,NJAICAFMPBE> r)
        {
            return r.Value;
        }
    }
}
public partial class OENEDGPIOFN
{
    // Alias for original OENEDGPIOFN/<>c; other original fields stay untouched.
    internal sealed class SortedClosureAlias
    {
        public static readonly SortedClosureAlias Singleton;
        public static Func<NPDGPDKAHLN,CPAMAFPANDM> CachedSelector;
        // Original47921.
        static SortedClosureAlias(){Singleton=new SortedClosureAlias();}
        // Original47922 is genuinely empty beyond System.Object construction.
        public SortedClosureAlias(){}
        // Original47925; raw reference null behavior and readonly16B key copy.
        internal CPAMAFPANDM SelectKey(NPDGPDKAHLN n)
        {
            return n.HDPNFBMCAHN;
        }
    }
    // Original47914, full383B/three connected native regions.
    // IEPIDJGAOIN and LAEKFDEFKFK remain exact, unrecovered call boundaries.
    public IEnumerable<CPAMAFPANDM> IJAKDIKAJHP()
    {
        List<CPAMAFPANDM> cached=this.OMMELJLAGLB;
        if(cached!=null)return cached;
        List<NPDGPDKAHLN> ordered=LAEKFDEFKFK(this.IEPIDJGAOIN());
        Func<NPDGPDKAHLN,CPAMAFPANDM> selector=SortedClosureAlias.CachedSelector;
        if(selector==null)
        {
            selector=new Func<NPDGPDKAHLN,CPAMAFPANDM>(SortedClosureAlias.Singleton.SelectKey);
            SortedClosureAlias.CachedSelector=selector;
        }
        this.OMMELJLAGLB=Enumerable.ToList(Enumerable.Select(ordered,selector));
        return this.OMMELJLAGLB;
    }
}
