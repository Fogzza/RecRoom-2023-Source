using UnityEngine;

namespace RecRoom.Core.GameManagement
{
	public abstract class CurrencyTool : HoldToInteractPortal
	{
		[SerializeField]
		protected Tool tool;

		[SerializeField]
		protected PulsingBeam pulsingBeam;

public Tool Tool
{
get 		{
			return null;
		}

}

public CHILKDJABBF OwnerOrAuthority
{
get 		{
			return null;
		}

}

public override string DefaultInteractionLabel
{
get 		{
			return null;
		}

}

public override bool RequiresHoldToInteract
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Use(Player EKOFNPFCLMO, bool CANNMAJLOHD = false)
		{
		}

		public override bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}

		protected virtual void MBIOLEBFOOM(Tool IEGMBEPJMGC, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		protected abstract void BMAJDOLNIPC();
	}
}
