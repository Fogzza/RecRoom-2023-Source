using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
	public Player Player;

	[SerializeField]
	private FollowBillboard followBillboard;

	[SerializeField]
	private TextMesh textMesh;

public int Score
{
set {
	}
}

public Transform PlayerHead
{
set {
	}
}

public Camera LocalCamera
{
set {
	}
}
}
