// Original private MNALHHOLFGL member; no new declarations or helpers.
// Preserve the native-inlined null assertion, including out assignment order.
private bool CPBMOKFMMMK<TType>(CPAMAFPANDM FDAIMOMOHIG, out NJAICAFMPBE FAEPBILJHEE)
{
    MKECFLEMHEL.GFKAFPHLKMJ(this.KBDIBPJIHNN, "You should not try to retrieve bindings from a disposed container!");
    this.LNFNAIMOFOF();
    NJAICAFMPBE localProvider;
    if (this.AAHKPPMHGFI.TryGetValue(FDAIMOMOHIG, out localProvider))
    {
        FAEPBILJHEE = localProvider;
        if (localProvider == null)
            throw new System.InvalidOperationException(string.Format("Null dependency detected in: {0} for key {1}. It should have been unregistered!", this, FDAIMOMOHIG));
        return true;
    }
    MNALHHOLFGL parent = this.DDFCHDGPJBN;
    NJAICAFMPBE parentProvider;
    if (parent != null && parent.CPBMOKFMMMK<TType>(FDAIMOMOHIG, out parentProvider))
    {
        FAEPBILJHEE = parentProvider;
        return true;
    }
    FAEPBILJHEE = null;
    return false;
}
