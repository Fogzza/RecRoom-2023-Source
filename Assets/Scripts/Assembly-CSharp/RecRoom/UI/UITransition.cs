using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.UI
{
	[Serializable]
	public class UITransition
	{
		[Serializable]
		private abstract class ComponentTransition
		{
			[SerializeField]
			public AnimationCurve curve;

			[SerializeField]
			public float durationScalar;

			[NonSerialized]
			public float linearTime;

			public abstract void OEIFAPBIBLG();

			public abstract void KFIHMLODGME(float OKBAJEAPIHG);

			public float ICEFENBCHPC(float OKBAJEAPIHG)
			{
				return 0f;
			}

			public void BLCKBNPODKB(float KKPEJNBKHML)
			{
			}
		}

		[Serializable]
		private class GraphicTransition : ComponentTransition
		{
			public Graphic graphic;

			public Color color;

			private Color initialColor;

			public override void OEIFAPBIBLG()
			{
			}

			public override void KFIHMLODGME(float OKBAJEAPIHG)
			{
			}
		}

		[Serializable]
		private class CanvasGroupTransition : ComponentTransition
		{
			public CanvasGroup canvasGroup;

			public float alpha;

			private float initialAlpha;

			public override void OEIFAPBIBLG()
			{
			}

			public override void KFIHMLODGME(float OKBAJEAPIHG)
			{
			}
		}

		[Serializable]
		private class TransformTransition : ComponentTransition
		{
			public Transform transform;

			public float localUniformScale;

			public Vector2 positionOffset;

			private Vector3 localSignedScale;

			private Vector3 initialLocalScale;

			private Vector3 initialLocalPosition;

			public override void OEIFAPBIBLG()
			{
			}

			public override void KFIHMLODGME(float OKBAJEAPIHG)
			{
			}
		}

		private sealed class JOGLJGDJIBF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float totalDuration;

			public UITransition _003C_003E4__this;

			private float _003Ct_003E5__2;

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
			public JOGLJGDJIBF(int _003C_003E1__state)
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
		private GraphicTransition[] graphics;

		[SerializeField]
		private CanvasGroupTransition[] canvasGroups;

		[SerializeField]
		private TransformTransition[] transforms;

		[SerializeField]
		private float duration;

		private LKGILLBEJEK runningTransitionPromise;

		[NonSerialized]
		public bool reverse;

		public bool HasValues => false;

		public bool IsPlayingForward => false;

		public bool IsPlayingReverse => false;

		public void IHEKMEOIBOI()
		{
		}

		public void NOIOGEDNFDJ(Behaviour DELCOFCGDFF, bool FBHDABEFLKL)
		{
		}

		private void HEGKMOPCGBF(Behaviour DELCOFCGDFF)
		{
		}

		public void PAKIMOKGMBI(float APHIMLCOKAM = 0f)
		{
		}

		private void PLADCIJPCEP()
		{
		}

		private IEnumerator<EGGPGCCKPCO> HDEOGPNNLLE(float LMBDMHHBDON)
		{
			return null;
		}

		private void KFIHMLODGME(float IHPJCBCPLCM)
		{
		}

		private void BLCKBNPODKB(float KKPEJNBKHML)
		{
		}
	}
}
