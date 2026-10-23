using System;
using UnityEngine;

[Serializable]
public abstract class SpecificRestrictionConfig<SelectorType, ContentType> where SelectorType : IComparable
{
	[SerializeField]
	private string name;

	public SelectorType Selector;

	public ContentType Content;
}
