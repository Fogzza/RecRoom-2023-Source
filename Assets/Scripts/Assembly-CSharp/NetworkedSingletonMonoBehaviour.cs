using Photon.Pun;

public class NetworkedSingletonMonoBehaviour<T> : MonoBehaviourPun where T : NetworkedSingletonMonoBehaviour<T>
{
	private static T CMDPMJBEBAB;

public static T Instance
{
get 	{
		return null;
	}

}

public static bool IsInitialized
{
get 	{
		return false;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}
}
