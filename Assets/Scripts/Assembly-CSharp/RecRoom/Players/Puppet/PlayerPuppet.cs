using System.Collections.Generic;
using RecRoom.Avatars;
using RecRoom.Avatars.Face;
using RecRoom.Avatars.Outfit;
using UnityEngine;

namespace RecRoom.Players.Puppet
{
	public abstract class PlayerPuppet : MonoBehaviour
	{
		[SerializeField]
		protected Transform visualRoot;

		[SerializeField]
		protected PlayerAvatarDisplay playerAvatarDisplay;

		[SerializeField]
		protected Transform head;

		[SerializeField]
		protected Transform body;

		[SerializeField]
		protected PlayerPuppetHand leftHand;

		[SerializeField]
		protected PlayerPuppetHand rightHand;

		[SerializeField]
		protected bool hideHandWhenHoldingTool;

		private List<OutfitPrefab> KJGOKIGNIKP;

public Transform Root
{
get 		{
			return null;
		}

}

public PlayerAvatarDisplay PlayerAvatarDisplay
{
get 		{
			return null;
		}

}

public Transform Head
{
get 		{
			return null;
		}

}

public Transform Body
{
get 		{
			return null;
		}

}

public PlayerPuppetHand LeftHand
{
get 		{
			return null;
		}

}

public PlayerPuppetHand RightHand
{
get 		{
			return null;
		}

}

public bool HideHandWhenHoldingTool
{
get 		{
			return false;
		}

set {
		}
}

public PlayerFacialAnimator FacialAnimator
{
get 		{
			return null;
		}

}

protected virtual bool BFIEHNHHOCI
{
get 		{
			return false;
		}

}

protected abstract HDPAHKBCHKD DFFGLFMJPMI
{
get ;
}

public virtual Player TargetPlayer
{
get 		{
			return null;
		}

set {
		}
}

protected virtual PlayerAvatarDisplay.HBPOPOJNDKJ AJMLAKMJGOL
{
get 		{
			return PlayerAvatarDisplay.HBPOPOJNDKJ.All;
		}

}

		protected virtual void LateUpdate()
		{
		}

		protected virtual void CDOHIFIHFDE()
		{
		}

		protected virtual void EDOAIHADJJA()
		{
		}

		public virtual void Refresh()
		{
		}

		protected virtual void GHGDLJCIFMN()
		{
		}

		protected virtual void DDMNBCGHGGD()
		{
		}

		protected virtual PlayerPuppetHand BODBPJKPOGM(PlayerHand.ICBKGDOJNDN NIFOGEBEDNG)
		{
			return null;
		}

		private void GHBGPGKKDJG(PlayerHand.ICBKGDOJNDN NIFOGEBEDNG, HLLELILGEBM PCPEJHIMHJJ, bool JCKJPDHHFPO = false)
		{
		}

		protected virtual void IEMCFFKNPCN(JKKOCBGMDKF PCPEJHIMHJJ, Transform PKIECNLLHKE)
		{
		}

		protected virtual void HNDHLPMBBLF()
		{
		}

		protected void LCILBGILEKI()
		{
		}

		protected void CJKDFELJEHB()
		{
		}

		protected void MLGEELFGBFP()
		{
		}

		protected void PFFNHHKKAOM()
		{
		}

		protected void DJANKCFBMMK()
		{
		}

		protected void NDBHBJNNLFP()
		{
		}

		protected void EJHMPBLLHEO()
		{
		}

		protected void BGKCFJKDDHB()
		{
		}

		protected void EJPMPPADEAE()
		{
		}
	}
}
