using UnityEngine;

public class EnemyPatrolPath : EnemyPatrol
{
	[SerializeField]
	private Transform[] pathNodes;

	[SerializeField]
	private float nodeRadius;

	[SerializeField]
	private bool loop;

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

	private void GCIHHFFEIAD(Vector3 EBEICGFALNG, Vector3 OGINPOLMPBC, bool BJMDDCIHNOC)
	{
	}
}
