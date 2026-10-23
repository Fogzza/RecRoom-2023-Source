using Photon.Pun;
using UnityEngine;

namespace RecRoom.Activities.Toys
{
	public abstract class RemoteControllable : MonoBehaviourPun
	{
		[SerializeField]
		private bool allowAuthorityTransferToNonRemoteHolder;

		[SerializeField]
		protected RigidbodyEx _rigidbodyEx;

		[SerializeField]
		protected Tool _tool;

		[SerializeField]
		private TeamColorRenderer teamColorRenderer;

		[SerializeField]
		private RemoteFollowCamera remoteFollowCamera;

public RigidbodyEx RigidbodyEx
{
get 		{
			return null;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

public TeamColorRenderer TeamColorRenderer
{
get 		{
			return null;
		}

}

public RemoteFollowCamera RemoteFollowCamera
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		public virtual void LocalUpdateRemoteControlInput(PlayerHand LIEHAPOPALF, Vector3 FDPINLJAOOP, float FJNAAEFPLBO, bool CDEDFFHMNCD)
		{
		}
	}
}
