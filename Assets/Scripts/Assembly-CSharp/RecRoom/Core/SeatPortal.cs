using RecRoom.Core.DataStructures;
using UnityEngine;

namespace RecRoom.Core
{
	public class SeatPortal : InteractablePortal
	{
		[SerializeField]
		private SeatManagement seatManager;

		[SerializeField]
		private RigidbodyEx parentingRigidbodyEx;

		[SerializeField]
		private ReferencePoint anchorPoint;

		[SerializeField]
		private ReferencePoint standingAnchorPoint;

		[SerializeField]
		private Renderer defaultBoxHighlightRenderer;

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

public override Vector3 DestinationPosition
{
get 		{
			return default;
		}

}

public override Vector3 DestinationForward
{
get 		{
			return default;
		}

}

public RigidbodyEx ParentingRigidbodyEx
{
get 		{
			return null;
		}

}

public ReferencePoint StandingAnchorPoint
{
get 		{
			return null;
		}

}

public ReferencePoint AnchorPoint
{
get 		{
			return null;
		}

}

public Collider SeatCollider
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

public override bool ShouldPlayInteractAnimation
{
get 		{
			return false;
		}

}

		protected void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public override void Use(Player EKOFNPFCLMO, bool CANNMAJLOHD = false)
		{
		}

		public override bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}

		public override void RenderOutline(LMKFOACECEG? IEMMIFODLAI = null, bool CLHNEFFBGPD = true)
		{
		}

		private void AGHCBNKFKHK(RigidbodyEx NEJMOIPCOAO)
		{
		}

		public override Sprite GetInteractionSprite(PIHMPBGNBHB IFEOGBCJEBI)
		{
			return null;
		}
	}
}
