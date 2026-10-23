using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using TMPro;
using UnityEngine;

public class Punchkeyboard : MonoBehaviour
{
	private sealed class HAFKHPDGJBD : IEnumerable<Event>, IEnumerable, IEnumerator<Event>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Event _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Punchkeyboard _003C_003E4__this;

		private Punchkey key;

		public Punchkey _003C_003E3__key;

		private char[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		Event IEnumerator<Event>.Current
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
		public HAFKHPDGJBD(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<Event> IEnumerable<Event>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[SerializeField]
	private Punchkey shiftKey;

	[SerializeField]
	private Punchkey altKey;

	[SerializeField]
	private RecRoomAudioClip keyPressedSuccess;

	public Transform EmailKeysRoot;

	[SerializeField]
	private Transform standardKeyboard;

	[SerializeField]
	private Transform numericKeyboard;

	private Punchkey[] ANBEMJBCFCO;

	private Punchkey[] LBABIOLGBKL;

	private TMP_InputField EDGLGHDEFKM;

	private int DEHBCPEDKPH;

	private bool JLEAGCGLHCC;

	public Action OnAnyKeyPressed;

	private static bool DBHIILMNFJK;

	private bool JGLGJFCLFFF;

private int MNFAMFIEBNL
{
get 	{
		return 0;
	}

set {
	}
}

public bool ShiftPressed
{
get 	{
		return false;
	}

}

public bool AltPressed
{
get 	{
		return false;
	}

}

public static bool TypingRestricted
{
get 	{
		return false;
	}

set {
	}
}

public bool KeysEnabled
{
get 	{
		return false;
	}

set {
	}
}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void DOKBPNELMKG()
	{
	}

	private void JINPPPNIGNG(Punchkey FDAIMOMOHIG)
	{
	}

	private void KMCFDHACAKL(Punchkey FDAIMOMOHIG)
	{
	}

	public void SimulateKeyPress(Punchkey FDAIMOMOHIG)
	{
	}

	private bool DFJHOEDBJOJ(TMP_InputField KAEDAICECGN)
	{
		return false;
	}

	private IEnumerable<Event> MKMOPJGOMAB(Punchkey FDAIMOMOHIG)
	{
		return null;
	}
}
