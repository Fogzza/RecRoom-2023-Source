// Thin original-owner compile context; never import this DLL wholesale.
// Only four named bodies are selected. Context ctor/CompareTo are unselected.
using System;
public sealed class MNALHHOLFGL
{
    internal MNALHHOLFGL(MNALHHOLFGL parent,string name){throw new NotImplementedException("Unselected original ctor context");}
// Exact selected-member recovery source. Outside Assets compilation.
// Preserve original fields, names, signatures, flags and all other members.
// MNALHHOLFGL.MJHONDPGJFA only:
public MNALHHOLFGL MJHONDPGJFA(string MIJDIKJDKAN)
{
    return new MNALHHOLFGL(this, MIJDIKJDKAN);
}


}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;}
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Unselected original context");}
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
