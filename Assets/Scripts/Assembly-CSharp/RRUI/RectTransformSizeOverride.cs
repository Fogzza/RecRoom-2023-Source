using UnityEngine;
using UnityEngine.UI;

namespace RRUI
{
	[ExecuteInEditMode]
	public class RectTransformSizeOverride : MonoBehaviour, ILayoutElement
	{
		[SerializeField]
		private bool overrideWidth;

		[SerializeField]
		private float width;

		[SerializeField]
		private bool overrideHeight;

		[SerializeField]
		private float height;

public float minWidth
{
get 		{
			return 0f;
		}

}

public float preferredWidth
{
get 		{
			return 0f;
		}

}

public float flexibleWidth
{
get 		{
			return 0f;
		}

}

public float minHeight
{
get 		{
			return 0f;
		}

}

public float preferredHeight
{
get 		{
			return 0f;
		}

}

public float flexibleHeight
{
get 		{
			return 0f;
		}

}

public int layoutPriority
{
get 		{
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
}
