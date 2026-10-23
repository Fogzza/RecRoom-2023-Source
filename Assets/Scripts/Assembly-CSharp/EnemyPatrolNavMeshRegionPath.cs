using UnityEngine;

public class EnemyPatrolNavMeshRegionPath : EnemyPatrol
{
	[SerializeField]
	private NavMeshRegion[] pathNodes;

	[SerializeField]
	private float nodeRadius;

	private static readonly Color OGEPEGEDHLJ;

	private static readonly Color KJEBDNIOIMM;

	public override bool HasReachedTarget(Vector3 EKIKCEJLBPA, Vector3 INKGHPCDMCG)
	{
		return false;
	}

	public override bool HasFinishedPatrol(int NAIHAOELGNO)
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

	private void OnDrawGizmos()
	{
	}

	private void GCIHHFFEIAD(NavMeshRegion EBEICGFALNG, NavMeshRegion OGINPOLMPBC)
	{
	}
}
