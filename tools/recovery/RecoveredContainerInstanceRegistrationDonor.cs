// Thin original-owner declaration context. ONLY three selected bodies.
// This compiled donor is read via Cecil and is NEVER executed or substituted.
using System;
public interface CKAJONGONMK{}
public interface MOANAJANOIL<TImpl>{}
public abstract class NPILHMLGJCC<TImpl>:CKAJONGONMK
{
    protected NPILHMLGJCC(){throw new NotImplementedException("Unselected original base constructor");}
}
internal class PLIPHMBIGMM<TImpl>:MOANAJANOIL<TImpl>
{
    public PLIPHMBIGMM(TImpl value){throw new NotImplementedException("Unselected original value-provider constructor");}
}
internal class IKGLJOBBAAC<TImpl>:NPILHMLGJCC<TImpl>
{
    private readonly MOANAJANOIL<TImpl> JPEDOBINBHH;
public IKGLJOBBAAC(TImpl CMDPMJBEBAB) : base()
{
    this.JPEDOBINBHH = new PLIPHMBIGMM<TImpl>(CMDPMJBEBAB);
}
}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string id){throw new NotImplementedException("Unselected original key constructor");}
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Unselected original key ordering");}
}
public sealed class MNALHHOLFGL
{
    private bool KBDIBPJIHNN;
public MNALHHOLFGL PHJOGIEDKPN<TClass>(TClass CMDPMJBEBAB, string OGLHPPMJANF = null) where TClass : class
{
    MKECFLEMHEL.GFKAFPHLKMJ(this.KBDIBPJIHNN, "You should not try to bind to a disposed container!");
    MKECFLEMHEL.GFKAFPHLKMJ(typeof(TClass).IsInterface, "You should not try to bind an instance of an interface!");
    this.JONINBOMMEP<TClass, TClass>(OGLHPPMJANF, new IKGLJOBBAAC<TClass>(CMDPMJBEBAB));
    return this;
}
internal void JONINBOMMEP<TFrom, TTo>(string OGLHPPMJANF, CKAJONGONMK MMNOGBABODM) where TTo : TFrom
{
    CPAMAFPANDM interfaceKey = new CPAMAFPANDM(typeof(TFrom), OGLHPPMJANF);
    CPAMAFPANDM implementationKey = new CPAMAFPANDM(typeof(TTo), null);
    this.JONINBOMMEP(interfaceKey, implementationKey, MMNOGBABODM);
}
    private void JONINBOMMEP(CPAMAFPANDM from,CPAMAFPANDM to,CKAJONGONMK provider){throw new NotImplementedException("Unselected original private registration");}
}
public static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){throw new NotImplementedException("Unselected original guard context");}
}
