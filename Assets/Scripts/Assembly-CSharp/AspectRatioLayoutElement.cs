using UnityEngine;
using UnityEngine.UI;

public class AspectRatioLayoutElement : MonoBehaviour, ILayoutElement
{
	public enum ABJEBDEJOJL
	{
		None = 0,
		WidthControlsHeight = 1,
		HeightControlsWidth = 2
	}

	[SerializeField]
	private ABJEBDEJOJL aspectMode;

	[SerializeField]
	private float aspectRatio;

	[SerializeField]
	private RectTransform rectTransform;

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
