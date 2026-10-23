using Photon.Pun;
using RecRoom;
using UnityEngine;

public class PlayerHead : MonoBehaviourPun
{
	[SerializeField]
	private CapsuleCollider worldOverlapCapsule;

	[SerializeField]
	private PhotonView propAnchorView;

	[SerializeField]
	private Player player;

	[SerializeField]
	private RigidbodyEx rigidbodyEx;

	[SerializeField]
	private NetworkTransform networkTransform;

	private NDNDHMIKFJI ODKCGNGAGIM;

public PhotonView PropAnchorView
{
get 	{
		return this.propAnchorView;
	}

}

public Player Player
{
get 	{
		return this.player;
	}

}

public NetworkTransform NetworkTransform
{
get 	{
		return this.networkTransform;
	}

}

public RigidbodyEx RigidbodyEx
{
get 	{
		return this.rigidbodyEx;
	}

}

public PlayerCollider HeadPlayerCollider
{
get 	{
		return null;
	}

}

public Bounds Bounds
{
get 	{
		return default;
	}

}

public Vector3 HeightOffset
{
get 	{
		return default;
	}

}

public bool IsOutOfGameBounds
{
get 	{
		return false;
	}

}

public bool IsOverlappingWorld
{
get 	{
		return false;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void OnTransformParentChanged()
	{
	}
}
