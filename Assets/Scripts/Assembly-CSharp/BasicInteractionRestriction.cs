using System;
using System.Collections.Generic;
using AGUI;
using UnityEngine.UI;

public class BasicInteractionRestriction : UIInteractionRestriction
{
	private bool CPGDBMOHCFG;

	private bool CIDEPKDBMFB;

	private Action<bool> AKDCHOKPCDB__BackingField;

	private HashSet<Selectable> GINPODGEOEP;

	private HashSet<Selectable> BBKLABONJBC;

public bool HasAnyActiveRestrictions
{
get 	{
		return false;
	}

}

public bool OpeningRestricted
{
get 	{
		return false;
	}

set {
	}
}

public bool AllElementsRestricted
{
get 	{
		return false;
	}

set {
	}
}

public Selectable AllowOnlyThisItem
{
set {
	}
}

public event Action<bool> OnRestrictionUpdated {
add {
	}
remove {
	}
}

	private void IGMGHHDAAIA()
	{
	}

	public void AddToAllowedSet(Selectable OFFJPOMOLDJ)
	{
	}

	public void RemoveFromAllowedSet(Selectable OFFJPOMOLDJ)
	{
	}

	public void RestrictElement(Selectable OFFJPOMOLDJ, bool LAPONHMPGON)
	{
	}

	public override bool CanInteract(Selectable DNPIJEOOLKB)
	{
		return false;
	}
}
