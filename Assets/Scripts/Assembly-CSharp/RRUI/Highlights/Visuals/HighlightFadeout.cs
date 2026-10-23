using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Highlights.Visuals
{
	public class HighlightFadeout : MonoBehaviour
	{
		public enum PHAKCILPNCL
		{
			Left = 0,
			Right = 1,
			Top = 2,
			Bottom = 3,
			BottomLeft = 4,
			TopLeft = 5,
			TopRight = 6,
			BottomRight = 7
		}

		private sealed class AJCGKGMADNE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RectTransform highlight;

			public RectTransform elementShape;

			public Graphic shape;

			public HighlightFadeout _003C_003E4__this;

			public string id;

			public float sizeOffset;

			public bool allowDiagonalTextPositioning;

			public PHAKCILPNCL? positionOverride;

			private RoundedCorners _003ChighlightRoundedCorners_003E5__2;

			private RoundedCorners _003CshapeRoundedCorners_003E5__3;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public AJCGKGMADNE(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private Image fadeoutImage;

		[SerializeField]
		private Graphic[] highlights;

		[SerializeField]
		private bool applyZOffsetToHighlights;

		[SerializeField]
		private float highlightsZOffset;

		[SerializeField]
		private Canvas labelCanvas;

		[SerializeField]
		private CanvasGroup labelCanvasGroup;

		[SerializeField]
		private RectTransform labelTransform;

		[SerializeField]
		private RectTransform labelBackgroundTransform;

		[SerializeField]
		private TextMeshProUGUI textLabel;

		[SerializeField]
		private RectTransform labelConnectionLine;

		[SerializeField]
		private float lineLength;

		private bool HOCFFNMCCJJ;

		private string KFEFAFEHLNM;

		private float BJLPEAGHBMC;

		private float MEGHPOMLDMP;

		private float MPFHEOGOHJF;

		private Canvas IPOPMPDKMCM;

		private global::CDPCNDNECPP<Graphic> GNJPBHGJNJI;

		private BFABKMNDMMP PNNJHAOONEN;

		private readonly Dictionary<string, Graphic> JNAEAHLIBKG;

		private readonly HashSet<string> GPLEAEEGEFO;

		private readonly HashSet<string> LENNCNCMIJO;

		private readonly HashSet<Graphic> GLPJMPMLANC;

		private readonly Vector3[] CJJACJJNMJL;

		private readonly Dictionary<string, LKGILLBEJEK> CJKLGDNOIDF;

public Graphic BlockerGraphics
{
get 		{
			return null;
		}

}

		private void Start()
		{
		}

		private void LLLPMINBGLL()
		{
		}

		public bool AddHighlight(string IKHNIJKGJFD, string HLIGBKANEEA, Graphic NBGOLMPJOHO, bool BPNIEKFCIGC, bool PNNBFPCIIKM, bool KAIKHJKDPBO, float KCGHBHCPDJE, float? JOLMHNFODGO = null, PHAKCILPNCL? GNBODNIAKLK = null)
		{
			return false;
		}

		public void RemoveHighlight(string IKHNIJKGJFD, Graphic NBGOLMPJOHO)
		{
		}

		public bool BlocksRay(Ray HAAAJDJGEFF)
		{
			return false;
		}

		public void OnClick()
		{
		}

		private IEnumerator<EGGPGCCKPCO> DLAMOMOJLAN(string IKHNIJKGJFD, Graphic NBGOLMPJOHO, RectTransform KAKMMGMBFOP, RectTransform BNEAFJOIPLC, bool KAIKHJKDPBO, float KCGHBHCPDJE, PHAKCILPNCL? GNBODNIAKLK = null)
		{
			return null;
		}

		private void GKIGOJFAJEA(bool BMGEHFPFCBJ)
		{
		}

		private void FJCDACMGKLC()
		{
		}

		private void HPMCODFLOHI(RectTransform GPFOBMFKHNB, bool LKKBOLACKHP = false, PHAKCILPNCL? GNBODNIAKLK = null)
		{
		}

		private bool BNKBEHJANJJ(PHAKCILPNCL? GNBODNIAKLK, bool LKKBOLACKHP, Vector2 KNGAEDPENOJ)
		{
			return false;
		}

		private bool BPMIPLGPPCJ(PHAKCILPNCL? GNBODNIAKLK, Vector2 KNGAEDPENOJ)
		{
			return false;
		}

		private Vector3 IODCOGBDPNB(RectTransform GPFOBMFKHNB, PHAKCILPNCL JCAGHOHEPMO)
		{
			return default;
		}

		private void GLPPNLBOEDN(RectTransform OFFJPOMOLDJ, RectTransform BNEAFJOIPLC, float KCGHBHCPDJE)
		{
		}

		private PHAKCILPNCL BPIOCBDEHAN(PHAKCILPNCL JCAGHOHEPMO, bool MFFKPOIEJLA, bool LLLNEOONOEK)
		{
			return PHAKCILPNCL.Left;
		}
	}
}
