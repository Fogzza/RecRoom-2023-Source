using System;

[Serializable]
public class RestrictedTypeConfig<SelectorType, ContentType, SetType, SingleType> where SelectorType : IComparable where SetType : SpecificRestrictionConfigSet<SelectorType, SingleType, ContentType> where SingleType : SpecificRestrictionConfig<SelectorType, ContentType>
{
	public bool RestrictionSpecific;

	public SetType Set;

	public ContentType Default;

	public ContentType LFLBEBNFOBJ(SelectorType JFOHKIGNEKH)
	{
		return default;
	}
}
