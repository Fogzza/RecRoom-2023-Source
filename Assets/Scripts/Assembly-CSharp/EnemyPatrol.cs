using Photon.Pun;
using UnityEngine;

public abstract class EnemyPatrol : MonoBehaviourPun
{

public virtual bool HasValidPatrolPoints
{
get 	{
		return false;
	}

}

public int Id
{
get 	{
		return 0;
	}

}

	public abstract bool HasReachedTarget(Vector3 EKIKCEJLBPA, Vector3 INKGHPCDMCG);

	public abstract bool HasFinishedPatrol(int PHIILGICFMI);

	public abstract bool TryGetNextTarget(int PHIILGICFMI, out int ABEGKAKKOLL, out Vector3 INKGHPCDMCG);

	public abstract Vector3 GetGizmoPosition();

	public virtual float GetPauseTime(int PHIILGICFMI)
	{
		return 0f;
	}

	public virtual bool TryGetLookTarget(int PHIILGICFMI, out Quaternion ECFAMEOGEAB)
	{
		ECFAMEOGEAB = default;
		return false;
	}
}
