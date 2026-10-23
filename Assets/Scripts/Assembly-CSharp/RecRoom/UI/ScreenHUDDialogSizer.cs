using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.UI
{
	[ExecuteInEditMode]
	public class ScreenHUDDialogSizer : MonoBehaviour
	{
		[Flags]
		private enum JEENFIOGBLO
		{
			None = 0,
			Horizontal = 1,
			Vertical = 2,
			Both = Horizontal | Vertical
		}

		[SerializeField]
		private Image dialogImage;

		[SerializeField]
		private TMP_Text dialogText;

		[SerializeField]
		private bool resizeTextObject;

		[SerializeField]
		private Vector2 padding;

		[SerializeField]
		private Vector2 maxSize;

		[SerializeField]
		private Vector2 minSize;

		[SerializeField]
		private JEENFIOGBLO controlAxes;

		private bool OEAONLGBBPN;

		private string COGOOCKIHNL;

		private JEENFIOGBLO OILDFOPCLPJ;

		private Vector2 EDNEFEOOKAE;

		private bool KAGIMFAPGOG;

		private bool PKOKCFDDNKP;

		private RectTransform CGPBNIDAGED;

		private RectTransform NHACMHCBNFK;

private float LIHLEPBIIFK
{
get 		{
			return 0f;
		}

}

private float KNIPLHJKNIH
{
get 		{
			return 0f;
		}

}

private float HFDFLLFJKCC
{
get 		{
			return 0f;
		}

}

private float CONHANIHMMA
{
get 		{
			return 0f;
		}

}

		private void Awake()
		{
		}

		private void IHEKMEOIBOI()
		{
		}

		private void Update()
		{
		}

		private void OnValidate()
		{
		}

		public void Refresh()
		{
		}
	}
}
