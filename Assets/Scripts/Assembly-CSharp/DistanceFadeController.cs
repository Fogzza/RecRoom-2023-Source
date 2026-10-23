using UnityEngine;

public class DistanceFadeController : MonoBehaviour
{
	[SerializeField]
	private Renderer[] renderers;

	[SerializeField]
	private Collider collider;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}
}
