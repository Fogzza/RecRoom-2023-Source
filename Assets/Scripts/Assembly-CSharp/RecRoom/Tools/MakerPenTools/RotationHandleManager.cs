using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class RotationHandleManager : HandleManagerBase
	{
		private sealed class CMIBNGCIGIH : IEnumerable<MakerPenHandle>, IEnumerable, IEnumerator<MakerPenHandle>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private MakerPenHandle _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public RotationHandleManager _003C_003E4__this;

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
			public CMIBNGCIGIH(int _003C_003E1__state)
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

		private RotationCircleCenterHandle DIDKLCLGAFM;

		private RotationCircleCenterHandle EGDBGELNBNA;

		private RotationCircleCenterHandle DCFDBGKACFP;

		private RotationCircleCenterHandle DICKAGPKCLA;

		private GameObject HPJIFOEIJPB;

protected override bool APMAJMPEOEG
{
get 		{
			return false;
		}

}

public override IEnumerable<MakerPenHandle> AllHandles
{
get 		{
			return null;
		}

}

		public static RotationHandleManager Create()
		{
			return null;
		}

		private void LLLPMINBGLL()
		{
		}

		private void LBPGPMKIPBP(MakerPenHandleManagerConfig FPJKGKBOAOA)
		{
		}

		public void OnStart()
		{
		}

		public void UpdateHandles<T>(global::DDLEHONFEBP<T> MPLIANHHNHG, AINHEFJAEPG PIDPNOCEFPD)
		{
		}
	}
}
