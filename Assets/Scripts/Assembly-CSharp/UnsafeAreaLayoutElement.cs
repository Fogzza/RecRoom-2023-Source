using UnityEngine;
using UnityEngine.UI;

public class UnsafeAreaLayoutElement : MonoBehaviour, ILayoutElement
{
	public enum BDLNPIJJAPC
	{
		None = 0,
		Top = 1
	}

	[SerializeField]
	private BDLNPIJJAPC screenEdge;

public float minWidth
{
get 	{
		return 0f;
	}

}

public float preferredWidth
{
get 	{
		return 0f;
	}

}

public float flexibleWidth
{
get 	{
		return 0f;
	}

}

public float minHeight
{
get 	{
		return 0f;
	}

}

public float preferredHeight
{
get 	{
		return 0f;
	}

}

public float flexibleHeight
{
get 	{
		return 0f;
	}

}

public int layoutPriority
{
get 	{
		return 0;
	}

}

	public void CalculateLayoutInputHorizontal()
	{
	}

	public void CalculateLayoutInputVertical()
	{
	}
}
