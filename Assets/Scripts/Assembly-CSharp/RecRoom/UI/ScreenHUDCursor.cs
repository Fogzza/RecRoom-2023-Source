using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.UI
{
	public class ScreenHUDCursor : ScreenHUDElement
	{
		public enum GFPIGBCFJCF
		{
			NONE = 0,
			INUSE = 1,
			BACKUP = 2
		}

		private GFPIGBCFJCF KLBONOOHBND;

		[SerializeField]
		private Image icon;

		[HideInInspector]
		public bool fadeIn;

		[HideInInspector]
		public bool fadeOut;

		private float FICKJDNBGME;

public Image Icon
{
get 		{
			return null;
		}

}

public GFPIGBCFJCF Role
{
get 		{
			return GFPIGBCFJCF.NONE;
		}

}

public bool IsFading
{
get 		{
			return false;
		}

}

public float IconOpacity
{
get 		{
			return 0f;
		}

set {
		}
}

		private void Update()
		{
		}

		public void SetIcon(Sprite MDECPMJIFKB)
		{
		}

		public void SetRole(GFPIGBCFJCF KLBONOOHBND)
		{
		}

		public void FadeIn(float FGBPJMKCMAO)
		{
		}

		public void FadeOut(float FGBPJMKCMAO)
		{
		}
	}
}
