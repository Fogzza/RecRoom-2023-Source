using System;
using System.Collections.Generic;
using UnityEngine;

public class ToolBasedPickupRestriction : GenericPickupRestriction<Tool>
{
	[Serializable]
	public class SpecificEnablersConfig
	{
		[SerializeField]
		public List<Tool> pickupEnablers;
	}

	[Serializable]
	public class SpecificDisablersConfig
	{
		[SerializeField]
		public List<Tool> pickupDisablers;
	}

	[SerializeField]
	private SpecificEnablersConfig specificEnablersConfig;

	[SerializeField]
	private SpecificDisablersConfig specificDisablersConfig;

private bool EAOGAONPNFL
{
get 	{
		return false;
	}

}

private bool BFMKFCLNAKB
{
get 	{
		return false;
	}

}

protected override List<Tool> FODGLMOAFBK
{
get 	{
		return null;
	}

}

protected override List<Tool> GFDKCOJDEPB
{
get 	{
		return null;
	}

}

	protected override bool HOLPBAFAJDI(Player FOCKAEINGKG)
	{
		return false;
	}

	protected override bool GBLPEFNPIMP(Player FOCKAEINGKG, Tool IEGMBEPJMGC)
	{
		return false;
	}

	protected override bool JCCJOJAFFLC(Tool IEGMBEPJMGC)
	{
		return false;
	}
}
