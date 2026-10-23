using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.UI
{
	[DisallowMultipleComponent]
	public class ScreenHUDElementGroup : MonoBehaviour
	{
		private sealed class MDHHIFAICEI : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ScreenHUDElementGroup _003C_003E4__this;

			public float targetAlpha;

			private float _003CstartAlpha_003E5__2;

			private float _003CstartTime_003E5__3;

			private AnimationCurve _003CfadeCurve_003E5__4;

			private float _003CelapsedTime_003E5__5;

			private float _003CfadeDuration_003E5__6;

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
			public MDHHIFAICEI(int _003C_003E1__state)
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

		public const float ENABLED_ALPHA = 1f;

		public const float DISABLED_ALPHA = 0.35f;

		public const float ALPHA_LERP_DURATION = 0.2f;

		[SerializeField]
		private ScreenHUDElement screenHUDElement;

		[SerializeField]
		private bool usesCustomDisabledAlpha;

		[SerializeField]
		private float customDisabledAlpha;

		[SerializeField]
		protected bool fadeInOnActivate;

		[SerializeField]
		private bool alwaysFade;

		[SerializeField]
		private AnimationCurve fadeInCurve;

		[SerializeField]
		private AnimationCurve fadeOutCurve;

		private JKHCJAJHGAO IPGFEAJFGPJ;

		private float IOJOECECBDO;

		private bool DEDDMBBMILB;

		[SerializeField]
		protected CanvasGroup canvasGroup;

		protected ScreenHUDElement[] OANIODOFJMM;

public ScreenHUDElement ScreenHUDElement
{
get 		{
			return null;
		}

}

private bool IHOJLOKDIED
{
get 		{
			return false;
		}

}

private float AHHDACLLCGC
{
get 		{
			return 0f;
		}

}

private float JKDAJIPMFKD
{
get 		{
			return 0f;
		}

}

		protected void Awake()
		{
		}

		protected void OnDestroy()
		{
		}

		private void CHAFJFDDMOE(bool BFDBCMGIOBG)
		{
		}

		public void SetEnabled(bool EPDJDCDHLMP)
		{
		}

		public void SetAlpha(float MEGHPOMLDMP)
		{
		}

		public void FadeAlpha(float MEGHPOMLDMP)
		{
		}

		private void HHCKKFFCLCC(float MEGHPOMLDMP)
		{
		}

		[CompilerGenerated]
		private IEnumerator<EGGPGCCKPCO> LGDNNIBEHEI(float FFGCFINAEMG)
		{
			return null;
		}

		[CompilerGenerated]
		private void KKOEGIKFKJC()
		{
		}
	}
}
