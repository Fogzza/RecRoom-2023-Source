using System;
using UnityEngine;

namespace RecRoom.Core
{
	public abstract class InteractablePortal : MonoBehaviour, LMFLCFFHNOF, MMFBEHDCJBH
	{
		private sealed class ANLCOENECLM
		{
			public Renderer renderer;

			internal bool _003CRemoveHighlightRenderer_003Eb__0(Renderer x)
			{
				return false;
			}
		}

		[SerializeField]
		protected Renderer[] highlightRenderers;

		[SerializeField]
		private bool hasScreensInteractionLabel;

		[SerializeField]
		private string screensInteractionLabel;

		[SerializeField]
		protected Collider _collider;

		[SerializeField]
		protected Animator _animator;

		private IDisposable JBIHOLPCHMC;

		private Action DHJJLHPGPME__BackingField;

		private Action ABNHLBIGNNP__BackingField;

		private static readonly int BINCPFAKENN;

		protected bool ABCJLNLLLCJ;

		private bool CMKCMDDFOBD;

		private bool NBGDNKMMKPD;

		private readonly FIHGBEHGLGB NCBCPLBNGPG;

		private bool LNLOIHFGINB;

		private Collider NEIINKGCINI;

protected Collider LNDKNKKNELC
{
get 		{
			return null;
		}

}

protected Animator CIOPHAMGMHB
{
get 		{
			return null;
		}

}

public virtual string InteractionLabel
{
get 		{
			return null;
		}

}

public virtual Vector3 DestinationPosition
{
get 		{
			return default;
		}

}

public virtual Vector3 DestinationForward
{
get 		{
			return default;
		}

}

public abstract string DefaultInteractionLabel
{
get ;
}

protected virtual bool BLIGOAKBHLK
{
get 		{
			return false;
		}

}

public virtual bool IsLocked
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

public LMFLCFFHNOF Interactable
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

public abstract bool CanBeInteracted
{
get ;
}

public abstract bool CanBeTargetedForInteraction
{
get ;
}

public virtual bool CanBeTargetedWhileOccluded
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

public bool IgnoreTargetingDirection
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool ShouldPlayInteractAnimation
{
get 		{
			return false;
		}

}

public virtual bool MaintainInteractionAfterCompletionUntilInputReleased
{
get 		{
			return false;
		}

}

public virtual bool RequiresHoldToInteract
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

public event Action HighlightStartedEvent {
add {
		}
remove {
		}
}

public event Action HighlightEndedEvent {
add {
		}
remove {
		}
}

		public abstract void Use(Player EKOFNPFCLMO, bool CANNMAJLOHD = false);

		public virtual bool OccludesTargetingForPlayer(Player EKOFNPFCLMO)
		{
			return false;
		}

		public bool IsPreferredHandForInteraction(PlayerHand KOMMPCGEMAP)
		{
			return false;
		}

		public void HoverStart(object IALNODEHBNN)
		{
		}

		public void HoverEnd(object IALNODEHBNN)
		{
		}

		public void AddHighlightRenderer(Renderer LPCBHIEOFOB)
		{
		}

		public void RemoveHighlightRenderer(Renderer LPCBHIEOFOB)
		{
		}

		private void PMNDBHMKLNO()
		{
		}

		public virtual void RenderOutline(LMKFOACECEG? IEMMIFODLAI = null, bool CLHNEFFBGPD = true)
		{
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

		public virtual Sprite GetInteractionSprite(PIHMPBGNBHB IFEOGBCJEBI)
		{
			return null;
		}

		public PIHMPBGNBHB GetInteractionType(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, BCPOPPHNIMF ADGJKMNMFAC)
		{
			return PIHMPBGNBHB.Use;
		}

		public virtual bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}

		public virtual bool CanBeInteractedByTargetingHand(Player BBHMKAPPKOD, PlayerHand GHODAKHBECE)
		{
			return false;
		}

		public LMFLCFFHNOF GetForwardedInteractable()
		{
			return null;
		}

		public float SquareDistanceToTransform(Collider ADMCDJKKCIA, Vector3 JJFGOCBHLOH, Quaternion CADNEKFKMNC, out bool MPFJOMFHPCA)
		{
			MPFJOMFHPCA = default;
			return 0f;
		}

		public virtual void Interact(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN, bool CAEGKCMDDNC)
		{
		}

		public virtual void StartHoldingForInteraction(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI)
		{
		}

		public virtual void CancelHoldingForInteraction()
		{
		}

		public virtual float GetHoldToInteractProgress()
		{
			return 0f;
		}

		protected bool EKEOLEEMJCG()
		{
			return false;
		}
	}
}
