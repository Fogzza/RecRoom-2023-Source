using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using UnityEngine;

public class Punchkey : MonoBehaviour
{
	public enum PJGDNKMEMHO
	{
		None = 0,
		Space = 1,
		BackSpace = 2,
		Return = 3,
		Alt = 4,
		Shift = 5,
		DecimalSeparator = 6,
		Esc = 7
	}

	private sealed class IKOOLPFFLEK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Punchkey _003C_003E4__this;

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
		public IKOOLPFFLEK(int _003C_003E1__state)
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

	private Action<Punchkey> ELLBMEMKNHK__BackingField;

	[SerializeField]
	private Button3DBase button3d;

	[SerializeField]
	private PJGDNKMEMHO specialKeyType;

	[SerializeField]
	private bool supportsPressAndHold;

	public string KeyCapChar;

	public string KeyCapChar_Shift;

	public string KeyCapChar_Alt;

	private const float IKCHPCOHCPN = 1f;

	private const float LOCIEPOHCMC = 0.1f;

	private float JNLCOFJCOFB;

	private Punchkeyboard MMHOLKPLDFD;

	private Collider[] GHKNKHCKPII;

	private ToggleButton3D FCKKGLMJHJK;

	private Coroutine LPDFKKGPMGD;

	private bool CCPMHDOAIBO;

public PJGDNKMEMHO SpecialKeyType
{
get 	{
		return PJGDNKMEMHO.None;
	}

}

public bool Toggled
{
get 	{
		return false;
	}

set {
	}
}

public bool SupportsShift
{
get 	{
		return false;
	}

}

public bool SupportsAlt
{
get 	{
		return false;
	}

}

public bool KeyPressEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool IsCharKey
{
get 	{
		return false;
	}

}

public event Action<Punchkey> Pressed {
add {
	}
remove {
	}
}

	public void Initialize(Punchkeyboard KMNIAGFPHEN)
	{
	}

	private void DEFMMDLNBII(Button3DBase FGEAOFEFHIE)
	{
	}

	private void AHNEKFAMIPG(bool NCPDDNBABLF)
	{
	}

	private void KDJILLEEHCC()
	{
	}

	public void RefreshKeyCapText()
	{
	}

	private IEnumerator BJNENCOHAFJ()
	{
		return null;
	}
}
