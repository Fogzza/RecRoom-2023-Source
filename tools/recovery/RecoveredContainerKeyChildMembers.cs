// Exact selected-member recovery source. Outside Assets compilation.
// Preserve original fields, names, signatures, flags and all other members.
// MNALHHOLFGL.MJHONDPGJFA only:
public MNALHHOLFGL MJHONDPGJFA(string MIJDIKJDKAN)
{
    return new MNALHHOLFGL(this, MIJDIKJDKAN);
}

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
