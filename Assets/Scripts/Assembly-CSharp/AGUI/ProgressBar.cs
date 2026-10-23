using UnityEngine;
using UnityEngine.UI;

namespace AGUI
{
	[DisallowMultipleComponent]
	public class ProgressBar : MonoBehaviour
	{
		public enum OGAOHNPJFLK
		{
			LEFT = 0,
			RIGHT = 1,
			TOP = 2,
			BOTTOM = 3
		}

		[SerializeField]
		private Image _image;

		[SerializeField]
		private OGAOHNPJFLK _origin;

		[SerializeField]
		private float _fillAmount;

public Image Image
{
get 		{
			return null;
		}

}

public OGAOHNPJFLK Origin
{
get 		{
			return OGAOHNPJFLK.LEFT;
		}

set {
		}
}

public float FillAmount
{
get 		{
			return 0f;
		}

set {
		}
}

		private void Start()
		{
		}

		public void UpdateFill()
		{
		}
	}
}
