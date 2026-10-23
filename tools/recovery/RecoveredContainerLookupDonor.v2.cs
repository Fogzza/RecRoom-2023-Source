// Thin original-owner context only; never import declarations/stubs wholesale.
using System;
public interface NJAICAFMPBE { object AIKLEKDPIFH(); }
public struct CPAMAFPANDM { public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;} }
public sealed class MNALHHOLFGL
{
    private bool KBDIBPJIHNN;
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

    public void LNFNAIMOFOF(){throw new NotImplementedException("Unselected original preparation context");}
    private bool CPBMOKFMMMK<TType>(CPAMAFPANDM key,out NJAICAFMPBE provider) {throw new NotImplementedException("Unselected original provider discovery context");}
}
internal static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){throw new NotImplementedException("Unselected original disposed guard context");}
}
