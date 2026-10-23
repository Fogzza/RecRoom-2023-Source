using System;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class UGCInteractablePortal : InteractablePortal
	{
		private Action<Player> DFOLPIHDJPN__BackingField;

		private NGJPBEEINBG PGDBGADKAOM;

		private string EMPLIOMOCCD;

public NGJPBEEINBG InteractionFilter
{
get 		{
			return default;
		}

set {
		}
}

public string UGCInteractionLabel
{
get 		{
			return null;
		}

set {
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

public override bool MaintainInteractionAfterCompletionUntilInputReleased
{
get 		{
			return false;
		}

}

public override string DefaultInteractionLabel
{
get 		{
			return null;
		}

}

public override string InteractionLabel
{
get 		{
			return null;
		}

}

public event Action<Player> PlayerInteractedEvent {
add {
		}
remove {
		}
}

		public override Sprite GetInteractionSprite(PIHMPBGNBHB IFEOGBCJEBI)
		{
			return null;
		}

		public override bool OccludesTargetingForPlayer(Player EKOFNPFCLMO)
		{
			return false;
		}

		public override void Use(Player EKOFNPFCLMO, bool CANNMAJLOHD = false)
		{
		}

		public override bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}

		private bool NAKNHFJHKLK(Player JOHIHILPLPJ)
		{
			return false;
		}
	}
}
