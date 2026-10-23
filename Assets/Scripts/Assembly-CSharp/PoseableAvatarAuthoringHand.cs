using UnityEngine;

[ExecuteInEditMode]
public class PoseableAvatarAuthoringHand : MonoBehaviour
{
	public enum HOKODIDBPGB
	{
		Neutral = 0,
		Pointing = 1,
		ThumbsUp = 2
	}

	private static readonly int FAHKEDKPPJM;

	private static readonly int CNIJHCFOGNM;

	private static readonly int GMAIOAOPLDP;

	[SerializeField]
	private Animator handAnimator;

	[SerializeField]
	private GameObject pointingMesh;

	[SerializeField]
	private GameObject defaultMesh;

	private HOKODIDBPGB ANLCMDCPMOD;

public float OpenClosedAxis
{
get 	{
		return 0f;
	}

}

public bool IsThumbsUp
{
get 	{
		return false;
	}

}

public bool IsNeutral
{
get 	{
		return false;
	}

}

public bool IsPointing
{
get 	{
		return false;
	}

}

public HOKODIDBPGB CurrentHandState
{
get 	{
		return HOKODIDBPGB.Neutral;
	}

private set {
	}
}

	private void Awake()
	{
	}

	public void SetHandState(HOKODIDBPGB DADHJJNJEFA)
	{
	}

	public void SetHandCurl(float ABDAHLLLJKC)
	{
	}
}
