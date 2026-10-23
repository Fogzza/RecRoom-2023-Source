using UnityEngine;

public class EnemyPatrolNavMeshRegion : EnemyPatrol
{
	[SerializeField]
	private NavMeshRegion region;

	[SerializeField]
	private float targetArriveDistance;

	private static readonly Color OGEPEGEDHLJ;

	public override bool HasReachedTarget(Vector3 EKIKCEJLBPA, Vector3 INKGHPCDMCG)
	{
		return false;
	}

	public override bool HasFinishedPatrol(int PHIILGICFMI)
	{
		return false;
	}

	public override bool TryGetNextTarget(int PHIILGICFMI, out int ABEGKAKKOLL, out Vector3 GLOKPCBOMNE)
	{
		ABEGKAKKOLL = default;
		GLOKPCBOMNE = default;
		return false;
	}

	public override Vector3 GetGizmoPosition()
	{
		return default;
	}

	public void DrawGizmo()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}

	private void Reset()
	{
	}
}
