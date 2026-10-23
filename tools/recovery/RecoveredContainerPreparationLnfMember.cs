// Original MNALHHOLFGL public MethodDef0x0600002f, complete1989B CFG.
// Existing raw generated closure identities must use the separately pinned aliases.
// Two foreach finally regions preserve original caught-exception/Dispose ordering.
public void LNFNAIMOFOF()
{
    string cycle=null;
    if((byte)this.MGADLDPDPGK>=1)return;
    this.MGADLDPDPGK=(PFCPCBJDEMB)1;
    if(this.OLGLBMGAHBO.HCILKBKIKOG(out cycle))
        throw new System.InvalidOperationException("Cycle detected in dependency tree!");
    foreach(CPAMAFPANDM key in this.OLGLBMGAHBO.IJAKDIKAJHP())
    {
        if(!this.AAHKPPMHGFI.ContainsKey(key))
        {
            CKAJONGONMK factory;
            if(this.LMAFHCPPMAD.TryGetValue(key,out factory))
            {
                NJAICAFMPBE provider=factory.IBOAFOPAJKI();
                MKECFLEMHEL.LGKIDJCLIAD<CPAMAFPANDM>(provider,"Cannot inject into dead resolved instance for key {0}",key);
                object value=provider.AIKLEKDPIFH();
                this.FIKOCEOODPI(value,new System.Nullable<CPAMAFPANDM>(key));
                this.AAHKPPMHGFI.Add(key,provider);
            }
        }
    }
    System.Collections.Generic.Dictionary<CPAMAFPANDM,NJAICAFMPBE> resolved=this.AAHKPPMHGFI;
    System.Func<System.Collections.Generic.KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>,NJAICAFMPBE> selector=ResolveClosureAlias.CachedSelector;
    if(selector==null)
    {
        selector=new System.Func<System.Collections.Generic.KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>,NJAICAFMPBE>(ResolveClosureAlias.Singleton.SelectProvider);
        ResolveClosureAlias.CachedSelector=selector;
    }
    foreach(NJAICAFMPBE provider in System.Linq.Enumerable.Select(resolved,selector))
    {
        if(provider!=null && !provider.DHABENNNOIJ())
            provider.IHEKMEOIBOI(this);
    }
}
