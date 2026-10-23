using UnityEngine;

public class BattleRoyaleCableCarPathGenerator : MonoBehaviour
{
	[SerializeField]
	private float initialPointRingRadius;

	[SerializeField]
	private float maxRandomPathAngle;

	[SerializeField]
	private float pathLength;

	private static BattleRoyaleCableCarPathGenerator EGAIHCNFOEN;

public static BattleRoyaleCableCarPathGenerator Instance
{
get 	{
		return null;
	}

private set {
	}
}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public Vector3[] GeneratePath()
	{
		return null;
	}

	private void OnDrawGizmosSelected()
	{
	}
}
