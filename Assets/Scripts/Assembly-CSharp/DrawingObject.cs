using UnityEngine;

public class DrawingObject : MonoBehaviour
{
	[SerializeField]
	private MeshFilter meshFilter;

	[SerializeField]
	private MeshRenderer meshRenderer;

public MeshFilter MeshFilter
{
get 	{
		return null;
	}

}

public MeshRenderer Renderer
{
get 	{
		return null;
	}

}

	private void Awake()
	{
	}

	public void ClearMesh()
	{
	}

	private void OnDestroy()
	{
	}
}
