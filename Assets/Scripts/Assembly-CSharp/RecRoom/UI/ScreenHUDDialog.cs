using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.UI
{
	public class ScreenHUDDialog : ScreenHUDElement
	{
		public struct PIJJNPBAEAK
		{
			public readonly Sprite DLADPCHJMME;

			public readonly string HLIGBKANEEA;

			public PIJJNPBAEAK(Sprite DLADPCHJMME, string HLIGBKANEEA)
			{
				this.DLADPCHJMME = null;
				this.HLIGBKANEEA = null;
			}
		}

		[SerializeField]
		private Image icon;

		[SerializeField]
		private RawImage rawImage;

		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private TMP_Text subtitle;

		[SerializeField]
		private CircularProgressBar circularProgressBar;

		[SerializeField]
		private RectTransform highlightCard;

		[SerializeField]
		private bool maintainIconAspectRatio;

		[SerializeField]
		private AspectRatioFitter aspectRatioFitter;

		[SerializeField]
		private ScreenHUDElementGroup elementGroup;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		[HideInInspector]
		private Sprite defaultIcon;

		[HideInInspector]
		[SerializeField]
		private string defaultText;

		[SerializeField]
		[HideInInspector]
		private Texture defaultTexture;

		[HideInInspector]
		[SerializeField]
		private float defaultAlpha;

		[HideInInspector]
		[SerializeField]
		private Vector3 defaultIconScale;

public float IconOpacity
{
get 		{
			return 0f;
		}

set {
		}
}

		private void OnDisable()
		{
		}

		public void SetContentForFrame(bool EPDJDCDHLMP, Sprite MDECPMJIFKB, Texture CIONKGJFLOB, string HLIGBKANEEA, string OEEBIOPLOMG = null, float DDKCONDPEJF = -1f)
		{
		}

		public void ResetContentForFrame(bool EPDJDCDHLMP)
		{
		}

		public void SetEnabled(bool EPDJDCDHLMP)
		{
		}

		public void SetIcon(Sprite MDECPMJIFKB)
		{
		}

		public void SetTexture(Texture CIONKGJFLOB)
		{
		}

		public void SetText(string EHHMGBANFNH, string BDDPCJOHDGM)
		{
		}

		private void KHEBPEGKJFH(string BDDPCJOHDGM)
		{
		}

		public void SetProgress(float DDKCONDPEJF)
		{
		}

		public void SetIconHandedness(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
		}

		private void ELIEJGCOLOE(bool OBFHBDLKFPA)
		{
		}
	}
}
