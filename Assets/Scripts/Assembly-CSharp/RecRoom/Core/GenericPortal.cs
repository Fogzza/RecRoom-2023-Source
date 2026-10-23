using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core
{
	public class GenericPortal : InteractablePortal
	{
		public delegate bool HCAHADDAGOM(GenericPortal DHMIOEJLHNL, Player FOCKAEINGKG);

		[SerializeField]
		protected string defaultInteractionLabel;

		private readonly List<HCAHADDAGOM> PLMAPLADAGF;

		private Action<GenericPortal, Player> GAGNMMFHNLO__BackingField;

public override string DefaultInteractionLabel
{
get 		{
			return null;
		}

}

public override bool CanBeInteracted
{
get 		{
			return false;
		}

}

public override bool CanBeTargetedForInteraction
{
get 		{
			return false;
		}

}

public event Action<GenericPortal, Player> UseEvent {
add {
		}
remove {
		}
}

		public void AddUseCondition(HCAHADDAGOM NHJPBHJLFOD)
		{
		}

		public void RemoveUseCondition(HCAHADDAGOM NHJPBHJLFOD)
		{
		}

		public override void Use(Player EKOFNPFCLMO, bool CANNMAJLOHD = false)
		{
		}

		public override bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}
	}
}
