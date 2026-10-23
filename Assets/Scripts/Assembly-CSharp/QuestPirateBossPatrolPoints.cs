using UnityEngine;

public class QuestPirateBossPatrolPoints : EnemyPatrol
{
	[SerializeField]
	private Transform[] orderedPatrolPoints;

	[SerializeField]
	private Transform retreatPoint;

public int PatrolPointCount
{
get 	{
		return 0;
	}

}

public override bool HasValidPatrolPoints
{
get 	{
		return false;
	}

}

	public override bool HasReachedTarget(Vector3 EKIKCEJLBPA, Vector3 INKGHPCDMCG)
	{
		return false;
	}

	public override bool HasFinishedPatrol(int PHIILGICFMI)
	{
		return false;
	}

	public override bool TryGetNextTarget(int PHIILGICFMI, out int ABEGKAKKOLL, out Vector3 INKGHPCDMCG)
	{
		ABEGKAKKOLL = default;
		INKGHPCDMCG = default;
		return false;
	}

	public override Vector3 GetGizmoPosition()
	{
		return default;
	}

	public Transform GetPatrolTransformAtIndex(int GMEHLIHLGEH)
	{
		return null;
	}

	public Transform GetRetreatTransform()
	{
		return null;
	}

	private void OnDrawGizmosSelected()
	{
	}
}
