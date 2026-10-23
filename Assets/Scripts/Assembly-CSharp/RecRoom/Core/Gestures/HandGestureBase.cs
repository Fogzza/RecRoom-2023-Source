using Photon.Pun;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Core.Gestures
{
	public abstract class HandGestureBase : MonoBehaviourPun
	{
		protected static RaycastHit[] OGIJNNPEKIF;

		[SerializeField]
		protected PlayerHandGestures playerHandGestures;

public abstract bool IsBlockingOtherGestures
{
get ;
}

public virtual bool IgnoreGestureCooldown
{
get 		{
			return false;
		}

}

protected bool ELMHLJABLGJ
{
get 		{
			return false;
		}

}

public PlayerHand Hand
{
get 		{
			return null;
		}

}

public VRInputHandler LocalInputHandler
{
get 		{
			return null;
		}

}

		public virtual void ProcessHandCollision(PlayerHand MCGMBMMJMBM)
		{
		}

		public virtual void ProcessNonPlayerHandCollision(NonPlayerGestureTarget GFCPAMJILIO)
		{
		}

		public virtual void Cancel()
		{
		}
	}
}
