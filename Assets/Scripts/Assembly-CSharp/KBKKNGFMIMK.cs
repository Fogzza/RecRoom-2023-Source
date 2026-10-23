using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public static class KBKKNGFMIMK
{
	private sealed class HFPPMECLIAA<T, U> : IEnumerable<global::HBBHKKBNKHE<T, U>>, IEnumerable, IEnumerator<global::HBBHKKBNKHE<T, U>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private global::HBBHKKBNKHE<T, U> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> first;

		public IEnumerable<T> _003C_003E3__first;

		private IEnumerable<U> second;

		public IEnumerable<U> _003C_003E3__second;

		private IEnumerator<T> _003Citr1_003E5__2;

		private IEnumerator<U> _003Citr2_003E5__3;

		global::HBBHKKBNKHE<T, U> IEnumerator<global::HBBHKKBNKHE<T, U>>.Current
		{
			[DebuggerHidden]
			get
			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CTuple_003CT_002CU_003E_003E_002Eget_Current();
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public HFPPMECLIAA(int _003C_003E1__state)
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
		private global::HBBHKKBNKHE<T, U> System_002ECollections_002EGeneric_002EIEnumerator_003CTuple_003CT_002CU_003E_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<global::HBBHKKBNKHE<T, U>> IEnumerable<global::HBBHKKBNKHE<T, U>>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public static IEnumerable<global::HBBHKKBNKHE<T, U>> KGDKNEJOBLF<T, U>(this IEnumerable<T> GLCCEMCHGPH, IEnumerable<U> GCJFHODBCEA)
	{
		return null;
	}

	public static IEnumerable<(T, U)> APINLMPOMKF<T, U>(this IEnumerable<T> GLCCEMCHGPH, IEnumerable<U> GCJFHODBCEA)
	{
		return null;
	}

	public static MemoT LNCALKLBEJG<SrcT, MemoT>(this IEnumerable<SrcT> BDOOEFOAMLK, MemoT ALPNLFFKHCA, Func<SrcT, MemoT, MemoT> EIPKJNCLLDO)
	{
		return default;
	}

	public static MemoT LNCALKLBEJG<SrcT, MemoT>(this IEnumerable<SrcT> BDOOEFOAMLK, MemoT ALPNLFFKHCA, Func<SrcT, MemoT, int, MemoT> EIPKJNCLLDO)
	{
		return default;
	}
}
