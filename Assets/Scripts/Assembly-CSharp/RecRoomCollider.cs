using System.Collections.Generic;
using System.Collections.ObjectModel;
using RecRoom;
using UnityEngine;

public abstract class RecRoomCollider : MonoBehaviour
{
	private const float DLPCBNFCHKD = 0.6f;

	[SerializeField]
	protected float kinematicBounciness;

	[SerializeField]
	protected HOJCCCPIHJO impactType;

	[HideInInspector]
	public RigidbodyEx ThisRigidbodyEx;

	private readonly List<Collider> NJLMABKOLAK;

	public global::HHOBPMOCKMJ<Collider> RRColliderDisabledOrDestroyed;

public float KinematicBounciness
{
get 	{
		return 0f;
	}

}

public HOJCCCPIHJO ImpactType
{
get 	{
		return HOJCCCPIHJO.Default;
	}

}

public ReadOnlyCollection<Collider> PhysicsColliders
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

public bool IsTrigger
{
get 	{
		return false;
	}

set {
	}
}

	protected virtual void Awake()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	public void IgnoreCollision(RecRoomCollider[] NHEIICNKKJK, bool CHEHHIMIPCJ)
	{
	}

	public void IgnoreCollision(RecRoomCollider HPPGOLAEDAN, bool CHEHHIMIPCJ)
	{
	}

	public void IgnoreCollision(IEnumerable<Collider> OIJIAPHKAPE, bool CHEHHIMIPCJ)
	{
	}

	public void AddCollider(Collider ADMCDJKKCIA)
	{
	}

	public void RemoveCollider(Collider ADMCDJKKCIA)
	{
	}

	public void ClearColliders()
	{
	}

	public virtual Vector3 GetCollisionNormal(Collision KDGCDLJEAMD)
	{
		return default;
	}

	public bool IsOverlapping(RigidbodyEx FNIOBDIDNJP)
	{
		return false;
	}
}
