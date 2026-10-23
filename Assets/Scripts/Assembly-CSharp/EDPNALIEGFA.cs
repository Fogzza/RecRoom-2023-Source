using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;

public class EDPNALIEGFA<T> : global::MOBDJNEDDKC<T[]>, ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private sealed class MHCGMKIPNGO : IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		public global::EDPNALIEGFA<T> _003C_003E4__this;

		private T[] _003ColdArray_003E5__2;

		private T[] _003C_003E7__wrap2;

		private int _003C_003E7__wrap3;

 T global::System.Collections.Generic.IEnumerator<T>.Current
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
		public MHCGMKIPNGO(int _003C_003E1__state)
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

	private static readonly T[] MKGECPHFGMH = global::System.Array.Empty<T>();

public int Count
{
get 	{
		return 0;
	}

}

 bool global::System.Collections.Generic.ICollection<T>.IsReadOnly
{
get => false;
}

	// C# has no syntax for parameterized property 'POFBPBHJKPE'.
	public T get_POFBPBHJKPE(int GMEHLIHLGEH)
	{
		return PGNPFMMCBMF(GMEHLIHLGEH);
	}

	public void set_POFBPBHJKPE(int GMEHLIHLGEH, T IPMIIEAGJKC)
	{
		CKEMHNCIAFB(GMEHLIHLGEH, IPMIIEAGJKC);
	}

	public unsafe EDPNALIEGFA(MonoBehaviourPun KLEOIMLJIAC, CHILKDJABBF EKOFNPFCLMO, string FDAIMOMOHIG, DILMPKDFOOO OBGIDDDNPCM, Action ONAFALABHKI = null)
		: base(KLEOIMLJIAC, EKOFNPFCLMO, FDAIMOMOHIG, MKGECPHFGMH, OBGIDDDNPCM, ONAFALABHKI, null)
	{
		OADJAFLNLBF();
	}

	public unsafe EDPNALIEGFA(MonoBehaviourPun KLEOIMLJIAC, string FDAIMOMOHIG, DILMPKDFOOO OBGIDDDNPCM, Action ONAFALABHKI = null)
		: base(KLEOIMLJIAC, FDAIMOMOHIG, MKGECPHFGMH, OBGIDDDNPCM, ONAFALABHKI, null)
	{
		OADJAFLNLBF();
	}

	public unsafe EDPNALIEGFA(MonoBehaviourPun KLEOIMLJIAC, string FDAIMOMOHIG, T GFLAEOLMKMC, DILMPKDFOOO OBGIDDDNPCM, bool PGDJAPOCMPG, Action ONAFALABHKI = null)
		: base(KLEOIMLJIAC, FDAIMOMOHIG, MKGECPHFGMH, OBGIDDDNPCM, PGDJAPOCMPG, ONAFALABHKI, null)
	{
		OADJAFLNLBF();
	}

	public bool Add(T PPIIEEAFCFI)
	{
		return false;
	}

	void ICollection<T>.Add(T PPIIEEAFCFI)
	{
	}

	public void Clear()
	{
	}

	public bool Contains(T ONCGIPFNENB)
	{
		return false;
	}

	public void CopyTo(T[] HAHPMNMCEBD, int PBNJDHGCIFC)
	{
	}

	public IEnumerator<T> GetEnumerator()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}

	public void ExceptWith(IEnumerable<T> HNPEBINPOBO)
	{
	}

	public void IntersectWith(IEnumerable<T> HNPEBINPOBO)
	{
	}

	public bool IsProperSubsetOf(IEnumerable<T> HNPEBINPOBO)
	{
		return false;
	}

	public bool IsProperSupersetOf(IEnumerable<T> HNPEBINPOBO)
	{
		return false;
	}

	public bool IsSubsetOf(IEnumerable<T> HNPEBINPOBO)
	{
		return false;
	}

	public bool IsSupersetOf(IEnumerable<T> HNPEBINPOBO)
	{
		return false;
	}

	public bool Overlaps(IEnumerable<T> HNPEBINPOBO)
	{
		return false;
	}

	public bool SetEquals(IEnumerable<T> HNPEBINPOBO)
	{
		return false;
	}

	public void SymmetricExceptWith(IEnumerable<T> HNPEBINPOBO)
	{
	}

	public void UnionWith(IEnumerable<T> HNPEBINPOBO)
	{
	}

	public bool Remove(T PPIGKFBEHGA)
	{
		return false;
	}

	public int JEBHMABMKPB(T ONCGIPFNENB)
	{
		return 0;
	}

	public List<T> DOFDJIGHFLC()
	{
		return null;
	}

	public T PGNPFMMCBMF(int GMEHLIHLGEH)
	{
		return default;
	}

	public void CKEMHNCIAFB(int GMEHLIHLGEH, T IPMIIEAGJKC)
	{
	}

	private void OADJAFLNLBF()
	{
	}
}
