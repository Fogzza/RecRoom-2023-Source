using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public class DiscGolfGoal : MonoBehaviourPun
{
	[SerializeField]
	private MFCPKKGGLNF hole;

	[SerializeField]
	private int par;

	[SerializeField]
	private Renderer beamRenderer;

	[SerializeField]
	public UnityEvent OnGoalHitEvent;

public MFCPKKGGLNF Hole
{
get 	{
		return MFCPKKGGLNF.HOLE_1;
	}

}

public int Par
{
get 	{
		return 0;
	}

}

public bool BeamEnabled
{
get 	{
		return false;
	}

set {
	}
}

	private void OnCollisionEnter(Collision KDGCDLJEAMD)
	{
	}
}
