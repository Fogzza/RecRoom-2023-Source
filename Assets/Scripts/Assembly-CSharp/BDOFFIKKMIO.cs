using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class BDOFFIKKMIO<T> : global::MOBDJNEDDKC<T[]>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private sealed class DKCMCIHINLI : IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		public global::BDOFFIKKMIO<T> _003C_003E4__this;

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
		public DKCMCIHINLI(int _003C_003E1__state)
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

public T this[int GMEHLIHLGEH] {
get 	{
		return default;
	}

set {
	}
}

	public unsafe BDOFFIKKMIO(JPEAKDKPCGM DELCOFCGDFF, CHILKDJABBF EKOFNPFCLMO, string FDAIMOMOHIG, DILMPKDFOOO OBGIDDDNPCM, Action ONAFALABHKI = null)
		: base(DELCOFCGDFF, EKOFNPFCLMO, FDAIMOMOHIG, MKGECPHFGMH, OBGIDDDNPCM, ONAFALABHKI, null)
	{
	}

	public unsafe BDOFFIKKMIO(JPEAKDKPCGM DELCOFCGDFF, string FDAIMOMOHIG, DILMPKDFOOO OBGIDDDNPCM, Action ONAFALABHKI = null)
		: base(DELCOFCGDFF, FDAIMOMOHIG, MKGECPHFGMH, OBGIDDDNPCM, ONAFALABHKI, null)
	{
	}

	public unsafe BDOFFIKKMIO(JPEAKDKPCGM DELCOFCGDFF, string FDAIMOMOHIG, T GFLAEOLMKMC, DILMPKDFOOO OBGIDDDNPCM, bool PGDJAPOCMPG, Action ONAFALABHKI = null)
		: base(DELCOFCGDFF, FDAIMOMOHIG, MKGECPHFGMH, OBGIDDDNPCM, PGDJAPOCMPG, ONAFALABHKI, null)
	{
	}

	public void Add(T PPIIEEAFCFI)
	{
	}

	public void Insert(int GMEHLIHLGEH, T PPIIEEAFCFI)
	{
	}

	public void RemoveAt(int GMEHLIHLGEH)
	{
	}

	public bool Remove(T PPIGKFBEHGA)
	{
		return false;
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

	public int IndexOf(T ONCGIPFNENB)
	{
		return 0;
	}

	public List<T> DOFDJIGHFLC()
	{
		return null;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}

	private void OADJAFLNLBF()
	{
	}
}
