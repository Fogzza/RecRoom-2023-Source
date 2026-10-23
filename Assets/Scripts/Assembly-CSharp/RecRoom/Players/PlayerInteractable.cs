using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Players
{
	public class PlayerInteractable : MonoBehaviour, LMFLCFFHNOF
	{
		private sealed class PONLLBNMCOI
		{
			public PlayerInteractable _003C_003E4__this;

			public string truncatedValue;

			internal void _003Cset_InteractionPrompt_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}
		}

		private readonly global::HHOBPMOCKMJ<LMFLCFFHNOF> IIJBHGDEFEG;

		private readonly global::HHOBPMOCKMJ<LMFLCFFHNOF> EMMAIAFKBEI;

		private readonly global::HHOBPMOCKMJ<LMFLCFFHNOF> EPIOIIGOJHB;

		private readonly global::HHOBPMOCKMJ<LMFLCFFHNOF> ANJOKDGPIKA;

		private readonly global::HHOBPMOCKMJ<LMFLCFFHNOF> GIKMJEPGGPM;

		private bool LNLOIHFGINB;

		private Collider NEIINKGCINI;

		private string DKHEOGKHDKK;

		private readonly bool IKHHAPDLLHG;

		private TimeSpan AOGJLAGFMGF;

		private readonly FIHGBEHGLGB NCBCPLBNGPG;

		private IDisposable JBIHOLPCHMC;

		private HGJKAKAIELF BBBEEKGLLLA;

		private bool OGPGPKDFJGO;

		[SerializeField]
		private Player player;

		[SerializeField]
		private List<Collider> colliders;

		private LHMPPJKHCJG KOCMHELAMME;

		private HLNFDOBEGJO CHABDOLEEMD;

		private PlayerHand AJMKOGKHMFK;

		private const int MGPNHINNALF = 32;

public global::HHOBPMOCKMJ<LMFLCFFHNOF> HoverStarted
{
get 		{
			return null;
		}

}

public global::HHOBPMOCKMJ<LMFLCFFHNOF> HoverEnded
{
get 		{
			return null;
		}

}

public global::HHOBPMOCKMJ<LMFLCFFHNOF> InteractionStarted
{
get 		{
			return null;
		}

}

public global::HHOBPMOCKMJ<LMFLCFFHNOF> InteractionCancelled
{
get 		{
			return null;
		}

}

public global::HHOBPMOCKMJ<LMFLCFFHNOF> InteractionCompleted
{
get 		{
			return null;
		}

}

public GameObject GameObject
{
get 		{
			return null;
		}

}

public Bounds Bounds
{
get 		{
			return default;
		}

}

public KENMLGIKKPD Priority
{
get 		{
			return KENMLGIKKPD.Tool;
		}

}

public bool CanBeTargetedForInteraction
{
get 		{
			return false;
		}

}

public bool CanBeTargetedWhileOccluded
{
get 		{
			return false;
		}

}

public bool IgnoreTargetingDirection
{
get 		{
			return false;
		}

set {
		}
}

public bool IsHoverHighlighted
{
get 		{
			return false;
		}

}

public Collider HighlightedCollider
{
get 		{
			return null;
		}

set {
		}
}

public string InteractionPrompt
{
get 		{
			return null;
		}

set {
		}
}

public bool CanBeInteracted
{
get 		{
			return false;
		}

}

public bool CanVRInteractUsingHandPickupAxis
{
get 		{
			return false;
		}

}

public bool ShouldPlayInteractAnimation
{
get 		{
			return false;
		}

}

public bool MaintainInteractionAfterCompletionUntilInputReleased
{
get 		{
			return false;
		}

}

public TimeSpan HoldDuration
{
get 		{
			return default;
		}

set {
		}
}

public bool RequiresHoldToInteract
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private void IDEPPLEJDDM()
		{
		}

		private void Start()
		{
		}

		private void AOOEKMNHFHH(GBAJDOHJDHJ HFEKGOLNKOL)
		{
		}

		private void OnDestroy()
		{
		}

		public void SetInteractivity(bool JBCKBDFGHOG)
		{
		}

		public bool OccludesTargetingForPlayer(Player COLMAMKJPJE)
		{
			return false;
		}

		public void HoverStart(object IALNODEHBNN)
		{
		}

		public void HoverEnd(object IALNODEHBNN)
		{
		}

		private void PMNDBHMKLNO()
		{
		}

		public void RenderOutline(LMKFOACECEG? IEMMIFODLAI = null, bool CLHNEFFBGPD = true)
		{
		}

		public bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}

		public bool IsPreferredHandForInteraction(PlayerHand KOMMPCGEMAP)
		{
			return false;
		}

		public bool GetInteractionPromptString(PIHMPBGNBHB IFEOGBCJEBI, BCPOPPHNIMF HACBGNEIIIL, PlayerHand KOMMPCGEMAP, out string DKHEOGKHDKK)
		{
			DKHEOGKHDKK = null;
			return false;
		}

		public Vector3 GetInteractionPromptPosition()
		{
			return default;
		}

		public Sprite GetInteractionSprite(PIHMPBGNBHB IFEOGBCJEBI)
		{
			return null;
		}

		public PIHMPBGNBHB GetInteractionType(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, BCPOPPHNIMF HACBGNEIIIL)
		{
			return PIHMPBGNBHB.Use;
		}

		public bool CanBeInteractedByTargetingHand(Player BBHMKAPPKOD, PlayerHand GHODAKHBECE)
		{
			return false;
		}

		public void Interact(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN, bool CAEGKCMDDNC)
		{
		}

		public float GetHoldToInteractProgress()
		{
			return 0f;
		}

		public void StartHoldingForInteraction(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI)
		{
		}

		public void CancelHoldingForInteraction()
		{
		}

		public LMFLCFFHNOF GetForwardedInteractable()
		{
			return null;
		}

		public float SquareDistanceToTransform(Collider DHNNLHJMKIH, Vector3 JJFGOCBHLOH, Quaternion CADNEKFKMNC, out bool MPFJOMFHPCA)
		{
			MPFJOMFHPCA = default;
			return 0f;
		}

		private Bounds GDHAFADBCOL(bool AAADJPJJFDJ = false)
		{
			return default;
		}
	}
}
