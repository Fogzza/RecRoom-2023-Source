using System;
using System.Collections.Generic;
using RecRoom.Core;
using UnityEngine;

public class SeatBasedPickupRestriction : GenericPickupRestriction<SeatManagement>
{
	[Serializable]
	public class SpecificEnablersConfig
	{
		[SerializeField]
		public List<SeatManagement> pickupEnablers;
	}

	[Serializable]
	public class SpecificDisablersConfig
	{
		[SerializeField]
		public List<SeatManagement> pickupDisablers;
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

protected override List<SeatManagement> FODGLMOAFBK
{
get 	{
		return null;
	}

}

protected override List<SeatManagement> GFDKCOJDEPB
{
get 	{
		return null;
	}

}

	protected override bool GBLPEFNPIMP(Player FOCKAEINGKG, SeatManagement HGHEJNOMIJN)
	{
		return false;
	}

	protected override bool HOLPBAFAJDI(Player FOCKAEINGKG)
	{
		return false;
	}

	protected override bool JCCJOJAFFLC(SeatManagement HGHEJNOMIJN)
	{
		return false;
	}
}
