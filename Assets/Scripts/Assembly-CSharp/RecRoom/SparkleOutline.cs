using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom
{
	public class SparkleOutline : MonoBehaviour
	{
		private sealed class HEECNANOBEK : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SparkleOutline _003C_003E4__this;

			private float _003CstartTime_003E5__2;

			private float _003CendTime_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public HEECNANOBEK(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private VisibleInCamera visibleInCamera;

		[SerializeField]
		private float minSparklePeriod;

		[SerializeField]
		private float maxSparklePeriod;

		[SerializeField]
		private Material overrideMaterialTemplate;

		private Material GGBIGPNHCGA;

		[SerializeField]
		private MeshRenderer[] ignoredRenderers;

		private KBJKDKFNFIA LIJGJGIGLOD;

		private Coroutine CJAGEMPFJFE;

		private List<MeshRenderer> KJJMMGMBOFO;

		private static readonly float FPOFFKDIMID;

		private static readonly AnimationCurve ONACFKPJNOD;

		private static readonly AnimationCurve PDPDFNKBIML;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private static void FPAJJDFOLEA(float IHPJCBCPLCM, out float ENCHDILOAHG, out float INKNGDFNONJ)
		{
			ENCHDILOAHG = default;
			INKNGDFNONJ = default;
		}

		private void IENJGOJCBFN()
		{
		}

		private void ALBKLBJODAF()
		{
		}

		private void KADIJCKFFAJ()
		{
		}

		private void DEDMBNNLEIJ()
		{
		}

		private IEnumerator DABPHPCBDGJ()
		{
			return null;
		}
	}
}
