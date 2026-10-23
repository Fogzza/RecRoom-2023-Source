using UnityEngine;

namespace RecRoom.Core
{
	public abstract class HoldToInteractPortal : InteractablePortal
	{
		[SerializeField]
		protected SynchronizedHoldToInteractHandler holdToInteractHandler;

		[SerializeField]
		private HoldToInteractPlayerRestrictionHandler playerRestrictionHandler;

		private HGJKAKAIELF MCEBHAAIDFP;

protected HGJKAKAIELF MPJNKLBEONC
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

public override bool RequiresHoldToInteract
{
get 		{
			return false;
		}

}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public override bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}

		public override bool CanBeInteractedByTargetingHand(Player BBHMKAPPKOD, PlayerHand GHODAKHBECE)
		{
			return false;
		}

		public override void Interact(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN, bool CAEGKCMDDNC)
		{
		}

		public override void StartHoldingForInteraction(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI)
		{
		}

		public override void CancelHoldingForInteraction()
		{
		}

		public override float GetHoldToInteractProgress()
		{
			return 0f;
		}

		protected virtual void LOLGAILPNIM(bool AKBGHNBDELA)
		{
		}
	}
}
