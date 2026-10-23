using Photon.Pun;
using UnityEngine;

public class SoccerGoal : MonoBehaviourPun
{
	[SerializeField]
	private BoxCollider goalCollider;

	[SerializeField]
	private GIBEGHKMCIE team;

public GIBEGHKMCIE Team
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

}

	private void OnDrawGizmos()
	{
	}
}
