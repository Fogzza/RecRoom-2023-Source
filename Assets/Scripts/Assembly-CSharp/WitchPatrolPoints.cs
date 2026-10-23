using UnityEngine;

public class WitchPatrolPoints : EnemyPatrol
{
	[SerializeField]
	private Transform initialWitchPoint;

	[SerializeField]
	private Transform finalWitchPoint;

	[SerializeField]
	private Transform retreatPoint;

	[SerializeField]
	private Transform[] randomWitchPoints;

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

	public Vector3 GetRandomWitchPoint()
	{
		return default;
	}

	public Vector3 GetInitialWitchPoint()
	{
		return default;
	}

	public Vector3 GetFinalWitchPoint()
	{
		return default;
	}

	public Vector3 GetRetreatWitchPoint()
	{
		return default;
	}

	private void OnDrawGizmosSelected()
	{
	}
}
