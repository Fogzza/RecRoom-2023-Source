using System;

namespace RecRoom.Core
{
	public abstract class BaseOpenableChest : HoldToInteractPortal
	{
		public delegate void MJNBGADOJMG(BaseOpenableChest BHJOAPIABAC);

		[NonSerialized]
		public CHILKDJABBF OnlyInteractionAllowedPlayer;

		private global::MOBDJNEDDKC<bool> AFIHKIFCDHB;

		public MJNBGADOJMG CloseEvent;

		public MJNBGADOJMG OpeningEvent;

		public MJNBGADOJMG OpenEvent;

public bool IsNotInteracted
{
get 		{
			return false;
		}

}

public bool IsHoldingForInteraction
{
get 		{
			return false;
		}

}

public bool IsInteracted
{
get 		{
			return false;
		}

}

public bool HasBeenOpened
{
get 		{
			return false;
		}

set {
		}
}

public override string DefaultInteractionLabel
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void MasterReset()
		{
		}

		public override void Use(Player EKOFNPFCLMO, bool CANNMAJLOHD = false)
		{
		}

		private void LOMNBOJPBHH()
		{
		}

		private void KNNOGPNEIBI()
		{
		}

		private void NLPFHOHPHDP()
		{
		}

		public override bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}
	}
}
