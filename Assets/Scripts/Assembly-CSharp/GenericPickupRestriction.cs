using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPickupRestriction<T> : MonoBehaviour
{
	public enum PAMNNBHKINO
	{
		Enabled = 0,
		Disabled = 1,
		UsingAnyDisablesPickup = 2,
		UsingAnyEnablesPickup = 3,
		UsingSpecificDisablesPickup = 4,
		UsingSpecificEnablesPickup = 5,
		AnyoneUsingSpecificDisablesPickup = 6,
		AnyoneUsingSpecificEnablesPickup = 7
	}

	[SerializeField]
	protected Tool tool;

	public PAMNNBHKINO RestrictionMode;

	private readonly Dictionary<object, T> KMPDNKPJDKF;

	private readonly Dictionary<object, T> EBFDCLIIOAF;

protected abstract List<T> FODGLMOAFBK
{
get ;
}

protected abstract List<T> GFDKCOJDEPB
{
get ;
}

	protected void Awake()
	{
	}

	protected void OnDestroy()
	{
	}

	public void AddPickupEnabler(T IPBIAAMEJDB, object IALNODEHBNN)
	{
	}

	public void RemovePickupEnabler(object IALNODEHBNN)
	{
	}

	public void AddPickupDisabler(T IPBIAAMEJDB, object IALNODEHBNN)
	{
	}

	public void RemovePickupDisabler(object IALNODEHBNN)
	{
	}

	protected abstract bool GBLPEFNPIMP(Player FOCKAEINGKG, T IPBIAAMEJDB);

	protected abstract bool HOLPBAFAJDI(Player FOCKAEINGKG);

	protected abstract bool JCCJOJAFFLC(T IPBIAAMEJDB);

	private bool CBDHPAKJJDJ(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
	{
		return false;
	}
}
