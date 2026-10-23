using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;

public class LACGBOPLMDD<TKey, TValue>
{
	private sealed class OLKEPIBFLDA : IEnumerable<TKey>, IEnumerable, IEnumerator<TKey>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private TKey _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public global::LACGBOPLMDD<TKey, TValue> _003C_003E4__this;

		private int _003CkeyCount_003E5__2;

		private int _003Ci_003E5__3;

 TKey global::System.Collections.Generic.IEnumerator<TKey>.Current
{
get 			{
				return default;
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public OLKEPIBFLDA(int _003C_003E1__state)
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
		IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private sealed class GLPIHMANMPC : IEnumerable<TValue>, IEnumerable, IEnumerator<TValue>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private TValue _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public global::LACGBOPLMDD<TKey, TValue> _003C_003E4__this;

		private int _003CvalueCount_003E5__2;

		private int _003Ci_003E5__3;

 TValue global::System.Collections.Generic.IEnumerator<TValue>.Current
{
get 			{
				return default;
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public GLPIHMANMPC(int _003C_003E1__state)
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
		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private global::BDOFFIKKMIO<TKey> LLNNCEMACKC;

	private global::BDOFFIKKMIO<TValue> MKPAEINNGNE;

	// C# has no syntax for parameterized property 'POFBPBHJKPE'.
	public TValue get_POFBPBHJKPE(TKey FDAIMOMOHIG)
	{
		return PGNPFMMCBMF(FDAIMOMOHIG);
	}

	public void set_POFBPBHJKPE(TKey FDAIMOMOHIG, TValue IPMIIEAGJKC)
	{
		CKEMHNCIAFB(FDAIMOMOHIG, IPMIIEAGJKC);
	}

public ICollection<TKey> MDKPNDACNBE
{
get 	{
		return null;
	}

}

public ICollection<TValue> PAMDCECBKIB
{
get 	{
		return null;
	}

}

public int BPIIJGBNBGB
{
get 	{
		return 0;
	}

}

public bool NNJLEOOEELM
{
get 	{
		return false;
	}

}

	public LACGBOPLMDD(MonoBehaviourPun KLEOIMLJIAC, string FDAIMOMOHIG, DILMPKDFOOO OBGIDDDNPCM, Action ONAFALABHKI = null)
	{
	}

	public TValue PGNPFMMCBMF(TKey FDAIMOMOHIG)
	{
		return default;
	}

	public void CKEMHNCIAFB(TKey FDAIMOMOHIG, TValue IPMIIEAGJKC)
	{
	}

	public void CPCILMEHKPA(TKey FDAIMOMOHIG, TValue IPMIIEAGJKC)
	{
	}

	public bool OPHJCIKACBI(TKey FDAIMOMOHIG)
	{
		return false;
	}

	public bool MILDLLFOGOM(TKey FDAIMOMOHIG)
	{
		return false;
	}

	public bool HOAIDNCFMEI(TKey FDAIMOMOHIG, out TValue IPMIIEAGJKC)
	{
		IPMIIEAGJKC = default;
		return false;
	}

	public void GLBPPAIACJF()
	{
	}

	private IEnumerable<TKey> ODKMDOKCBOP()
	{
		return null;
	}

	private IEnumerable<TValue> GAKOHDMMDBC()
	{
		return null;
	}

	private void ANKMEDCPGKP()
	{
	}
}
