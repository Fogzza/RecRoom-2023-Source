// Thin original-owner context only. Import only the selected two bodies.
using System;using System.Collections.Generic;
public interface NJAICAFMPBE{object AIKLEKDPIFH();}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;}
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Unselected original key context");}
// CPAMAFPANDM only. This type implements IComparable<CPAMAFPANDM>,
// not IEquatable<CPAMAFPANDM>. Do not introduce a new interface or rename OFPE.
public bool OFPEIHMPLIL(CPAMAFPANDM HNPEBINPOBO)
{
    return this.AFJAGKNNCBE == HNPEBINPOBO.AFJAGKNNCBE
        && string.Equals(this.FEKLPCPODAH, HNPEBINPOBO.FEKLPCPODAH);
}
public override bool Equals(object ICHBECDKHOJ)
{
    if (!(ICHBECDKHOJ is CPAMAFPANDM))
        return false;
    CPAMAFPANDM other = (CPAMAFPANDM)ICHBECDKHOJ;
    return this.AFJAGKNNCBE == other.AFJAGKNNCBE
        && string.Equals(this.FEKLPCPODAH, other.FEKLPCPODAH);
}
public override int GetHashCode()
{
    int typeHash = this.AFJAGKNNCBE.GetHashCode();
    string name = this.FEKLPCPODAH;
    int nameHash = (object)name != null ? name.GetHashCode() : 0;
    return unchecked((typeHash * 397) ^ nameHash);
}

}
public sealed class MNALHHOLFGL
{
    private readonly Dictionary<CPAMAFPANDM,NJAICAFMPBE> AAHKPPMHGFI;
    private readonly MNALHHOLFGL DDFCHDGPJBN;private bool KBDIBPJIHNN;
// Selected body within original MNALHHOLFGL only, outside Assets compilation.
// Keep the original internal member, reference constraint, fields and dependencies.
internal bool NGBMOPMLJCM<TType>(CPAMAFPANDM FDAIMOMOHIG, out TType FAEPBILJHEE) where TType : class
{
    MKECFLEMHEL.GFKAFPHLKMJ(this.KBDIBPJIHNN, "You should not try to retrieve bindings from a disposed container!");
    this.LNFNAIMOFOF();
    NJAICAFMPBE provider;
    if (!this.CPBMOKFMMMK<TType>(FDAIMOMOHIG, out provider))
    {
        FAEPBILJHEE = default(TType);
        return false;
    }
    FAEPBILJHEE = (TType)provider.AIKLEKDPIFH();
    return true;
}
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

    public void LNFNAIMOFOF(){throw new NotImplementedException("Unselected original preparation context");}
}
internal static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){throw new NotImplementedException("Unselected original disposed guard context");}
}
