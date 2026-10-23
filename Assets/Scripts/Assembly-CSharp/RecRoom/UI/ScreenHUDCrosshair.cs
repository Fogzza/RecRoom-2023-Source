using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.UI
{
	public class ScreenHUDCrosshair : ScreenHUDElement
	{
		public enum IKNLFLEALLL
		{
			NONE = 0,
			TOP = 2,
			BOTTOM = 4,
			LEFT = 8,
			RIGHT = 16,
			LEFT_AND_RIGHT = 24,
			TOP_AND_BOTTOM = 6,
			ALL = 30
		}

		private enum GNFBBINMBLI
		{
			TOP = 1,
			BOTTOM = 2,
			LEFT = 3,
			RIGHT = 4
		}

		[SerializeField]
		private RectTransform topTickRoot;

		[SerializeField]
		private RectTransform bottomTickRoot;

		[SerializeField]
		private RectTransform leftTickRoot;

		[SerializeField]
		private RectTransform rightTickRoot;

		private Image[] MPFPPOBFIIO;

		private void Awake()
		{
		}

		public void EnableTicks(IKNLFLEALLL PPMLMNLJAAE)
		{
		}

		private void DIKJAMPNDCP(RectTransform AGPCNAEOEHI, IKNLFLEALLL EBBNMKKOLJD, GNFBBINMBLI BANBDDNFHBL)
		{
		}

		public void SetTickDistance(float IGDCJONJNON)
		{
		}

		public void SetTickColor(Color HMCAFGCGFJF)
		{
		}
	}
}
