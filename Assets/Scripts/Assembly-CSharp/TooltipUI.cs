using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
	[Serializable]
	public class FontConfig
	{
		public float FontSize;
	}

	private sealed class AENABGFHEBJ : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TooltipUI _003C_003E4__this;

		private float _003Ct_003E5__2;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public AENABGFHEBJ(int _003C_003E1__state)
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

	private const float FMDHEHGLEEF = 0.015f;

	private const float AICMAGENIAM = 0.52f;

	private const float PMHNDGBJKDI = 0.55f;

	private const int NKEHCNLBCGO = 3;

	private const int ICDGIANAPIN = 2;

	public static readonly List<TooltipUI> All;

	[SerializeField]
	private TMP_Text textMesh;

	[SerializeField]
	private Transform background;

	[SerializeField]
	private Vector2 backgroundHorizontalPadding;

	[SerializeField]
	private AnimationCurve sizeOverDistanceCurve;

	private Renderer HOJMHDKKBIB;

	private Renderer PJCDHKMAICD;

	private float FBCIDJNFJEM;

	private float AJBLACFCJDI;

	private FontConfig PCMJELOOIJA;

	private float NEHKJEEFBKG;

public string Message
{
get 	{
		return null;
	}

set {
	}
}

public FontConfig CurrentFontConfig
{
set {
	}
}

public Vector3 Position
{
set {
	}
}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	private void OBKGKMPFECN()
	{
	}

	public static TooltipUI Acquire(string OFCFPGACNJB, Vector3 PEJEOHJJKBA, Quaternion JMDALKJDKBF, FontConfig FPJKGKBOAOA)
	{
		return null;
	}

	public void Release()
	{
	}

	private IEnumerator AGFLJKDGPLO()
	{
		return null;
	}

	public void RecomputeEdgeOffset()
	{
	}

	private void EAGBOGPFMNJ(float BJLPEAGHBMC, float HEDPOHEBBKF)
	{
	}
}
