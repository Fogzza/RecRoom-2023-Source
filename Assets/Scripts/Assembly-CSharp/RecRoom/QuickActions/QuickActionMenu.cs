using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace RecRoom.QuickActions
{
	public class QuickActionMenu : MonoBehaviour
	{
		public enum AEKKCJLBGNF
		{
			None = 0,
			Clipboard = 1,
			Eyedropper = 2
		}

		[Serializable]
		public class IconSpriteDictionary : SerializedDictionary<AEKKCJLBGNF, Sprite, IconSpriteDictionary.KeyVal>
		{
			[Serializable]
			public class KeyVal : SerializedKeyVal<AEKKCJLBGNF, Sprite>
			{
			}
		}

		private enum KJBMAAIHPIF
		{
			Closed = 0,
			Hint = 1,
			Open = 2,
			SelectionFeedback = 3
		}

		private sealed class NHKOIMFEENI
		{
			public Action onClick;

			internal global::NCOKFFGPIJM<string> _003CAddButton_003Eb__0()
			{
				return null;
			}
		}

		private sealed class OIGBPNEIHNN
		{
			private sealed class _003C_003CAnimateCanvas_003Eg__Animate_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public OIGBPNEIHNN _003C_003E4__this;

				private float _003CstartAlpha_003E5__2;

				private float _003CanimTime_003E5__3;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CAnimateCanvas_003Eg__Animate_007C0_003Ed(int _003C_003E1__state)
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

			public float targetAlpha;

			public QuickActionMenu _003C_003E4__this;

			internal IEnumerator<EGGPGCCKPCO> _003CAnimateCanvas_003Eg__Animate_007C0()
			{
				return null;
			}

			internal void _003CAnimateCanvas_003Eg__Finish_007C1()
			{
			}
		}

		[SerializeField]
		private QuickActionButton buttonPrefab;

		[SerializeField]
		private Transform buttonsParent;

		[SerializeField]
		private Canvas canvas;

		[SerializeField]
		private GameObject feedbackObject;

		[SerializeField]
		private QuickActionButton hintPrefab;

		[SerializeField]
		private float feedbackTime;

		[SerializeField]
		private float hintDelay;

		[SerializeField]
		private AnimationCurve hydrationCurve01;

		[SerializeField]
		private float hydrationTime;

		[SerializeField]
		private Vector3 menuOffset;

		[SerializeField]
		private float menuScaleScreens;

		[SerializeField]
		private float menuScaleVR;

		[SerializeField]
		private bool updateScaleEveryFrame;

		[SerializeField]
		private IconSpriteDictionary sprites;

		private const float KNMBNKGIIDG = 0f;

		private const float OIGBKADEAAA = 1f;

		private JKHCJAJHGAO DGMKGLPGNAE;

		private List<QuickActionButton> JJLLNJIBDOO;

		private CanvasGroup IILCFJEBGAE;

		private float ODFGKAAENKG;

		private TMP_Text DLLHFKENCBA;

		private RaycastHit FFNNKMFECFP;

		private bool CMIEHJACBJD;

		private bool MJLBBJNLONK;

		private QuickActionButton NKEIJEGHIEO;

		private MDEJADHJOEJ MMLKPPOCHHN;

		private Vector3 PIODDFMLBEH;

		private static readonly (float, float) BKPEAEHHAAK;

		private static readonly (float, float) PNFIFMHAGLA;

public Vector3 LastShowMenuHintPosition
{
get 		{
			return default;
		}

private set {
		}
}

private KJBMAAIHPIF MBHNCCMHIPK
{
get 		{
			return KJBMAAIHPIF.Closed;
		}

}

		public Sprite TryGetSprite(AEKKCJLBGNF MDECPMJIFKB)
		{
			return null;
		}

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDisable()
		{
		}

		private void OnEnable()
		{
		}

		private void PGHOICPFDBL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GAFNLFFAEEM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void JFIMNKNKMDA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GKADLLEJHBO(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void DOOAKDGFNMI(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void KMIEOOFCKFO(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void DADAKNEBDGN(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		public void AddButton(string AICBAMHEBBB, Func<global::NCOKFFGPIJM<string>> CCLGFCNAFEB, Sprite AMPHJGGNDIF = null)
		{
		}

		public void AddButton(string AICBAMHEBBB, Action CCLGFCNAFEB, Sprite AMPHJGGNDIF = null)
		{
		}

		public void AddButton(string AICBAMHEBBB, AEKKCJLBGNF NAMBNOHMAHM, Func<global::NCOKFFGPIJM<string>> CCLGFCNAFEB)
		{
		}

		public void AddButtonTree(CFONBKGDGHJ KLCMEDDGHME)
		{
		}

		public void ClearAllButtons(bool NHIAIFNHHND = true)
		{
		}

		public void CloseMenu()
		{
		}

		public void OpenMenu()
		{
		}

		public void SetLayerDefault()
		{
		}

		public void SetLayerHideInFirstPerson()
		{
		}

		public void ShowMenuHint(Vector3 INLGLHIPOMC, float? FHFDDKOBFLG = null, Vector3? MLGPOLAAHHP = null)
		{
		}

		public bool TryClick()
		{
			return false;
		}

		public bool UpdateHover(Ray HAAAJDJGEFF, out RaycastHit KNFIEECFHPI, float KEDBAELNJIE)
		{
			KNFIEECFHPI = default;
			return false;
		}

		public static float GetScaleFactorForCameraDistance(Camera DHMMMIGPMIK, Vector3 ADJINPMOILO)
		{
			return 0f;
		}

		private static bool DINMGPJFBKH()
		{
			return false;
		}

		private LAHBDKNMNHN CFJPBAAEJEN(float FFGCFINAEMG)
		{
			return null;
		}

		private QuickActionButton CCPFKBAIMBD(QuickActionButton EEDNNPBFGKA, CFONBKGDGHJ KLCMEDDGHME)
		{
			return null;
		}

		private void OELMHKOGKHM(QuickActionButton HHDMPJJAPJJ, string EJHOFMJNGEO)
		{
		}

		private void DMHNCPDNBMC(Vector3 INLGLHIPOMC, Vector3 MLGPOLAAHHP)
		{
		}

		private void MKBOJDKLDGG()
		{
		}

		private void MEPKAFLAFOE(bool GJGODIHKAHN)
		{
		}

		[CompilerGenerated]
		private void MKFMGMDDIKM()
		{
		}

		[CompilerGenerated]
		private void IGEAEFPACCJ()
		{
		}
	}
}
