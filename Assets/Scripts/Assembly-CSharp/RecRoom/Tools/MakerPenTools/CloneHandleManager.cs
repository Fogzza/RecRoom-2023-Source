using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class CloneHandleManager : HandleManagerBase
	{
		private sealed class HJIPHOLMPNM : IEnumerable<MakerPenHandle>, IEnumerable, IEnumerator<MakerPenHandle>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private MakerPenHandle _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CloneHandleManager _003C_003E4__this;

			private CloneAxisHandle[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			MakerPenHandle IEnumerator<MakerPenHandle>.Current
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
			public HJIPHOLMPNM(int _003C_003E1__state)
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
			IEnumerator<MakerPenHandle> IEnumerable<MakerPenHandle>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private bool CEKNGADDPPK;

		private Func<bool?> CGHGEHGEALP;

		private CloneAxisHandle[] BKEFMOFKHLO;

		private CloneAxisHandle HPPABNMHNII;

		private static readonly Vector3[] GMCHBNKPPOJ;

		private static readonly Vector3[] EDAFKAGHPLP;

public override IEnumerable<MakerPenHandle> AllHandles
{
get 		{
			return null;
		}

}

		public static CloneHandleManager Create(bool CEKNGADDPPK, Func<bool?> CGHGEHGEALP)
		{
			return null;
		}

		private void LLLPMINBGLL(bool CEKNGADDPPK, Func<bool?> CGHGEHGEALP)
		{
		}

		public void UpdateHandles<T>(global::FNLEEFFPAAJ<T> DELCOFCGDFF)
		{
		}
	}
}
