using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableButton : MonoBehaviour
{
	private sealed class GDOMAJNGDKO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ConsumableButton _003C_003E4__this;

		public int seconds;

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
		public GDOMAJNGDKO(int _003C_003E1__state)
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
	private ToggleButton3D toggle;

	[SerializeField]
	private Tooltip tooltip;

	[SerializeField]
	private float localImposterRadius;

	[SerializeField]
	private Transform consumableRoot;

	[SerializeField]
	private Text consumableName;

	[SerializeField]
	private Text count;

	[SerializeField]
	private Text timeLeft;

	[SerializeField]
	private GameObject useText;

	private IELGHJEOPKB HJJLIFBGFDP;

	private CancellationTokenSource BGAGMFECJMM;

public IELGHJEOPKB CurrentConsumable
{
get 	{
		return null;
	}

private set {
	}
}

public ToggleButton3D.OnToggleButton3DClick ButtonAction
{
get 	{
		return null;
	}

}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OOLNPOEFCJA(IELGHJEOPKB KIJHICGIKFM, bool GNGKKJPOAPJ)
	{
	}

	public void SetConsumable(IELGHJEOPKB KIJHICGIKFM, StackedUIBase HMDIBMJHHLN)
	{
	}

	private void KBFHPFHLNAJ()
	{
	}

	private IEnumerator ODLJPIPLGJO(int BGGBEMDBOHE)
	{
		return null;
	}

	private string BFHMKGHMCKB(int BGGBEMDBOHE)
	{
		return null;
	}

	[CompilerGenerated]
	private void AFLBMHEGEIC(bool NCPDDNBABLF)
	{
	}

	[CompilerGenerated]
	private Task<GameObject> MDFAAPKDILC(CancellationToken IALNODEHBNN)
	{
		return null;
	}
}
