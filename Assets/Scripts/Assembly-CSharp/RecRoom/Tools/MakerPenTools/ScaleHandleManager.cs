using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class ScaleHandleManager : HandleManagerBase
	{
		private sealed class AFMFMPHHLLE : IEnumerable<MakerPenHandle>, IEnumerable, IEnumerator<MakerPenHandle>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private MakerPenHandle _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ScaleHandleManager _003C_003E4__this;

			private ScaleAxisHandleBase[] _003C_003E7__wrap1;

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
			public AFMFMPHHLLE(int _003C_003E1__state)
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

		protected ScaleAxisHandleBase HPPABNMHNII;

		protected ScaleAxisHandleBase[] BKEFMOFKHLO;

		private GameObject HPJIFOEIJPB;

		private static Vector3[] GMCHBNKPPOJ;

		private static Vector3[] EDAFKAGHPLP;

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

		public static ScaleHandleManager Create()
		{
			return null;
		}

		protected virtual void OPAAGENNPLF()
		{
		}

		public void OnStart()
		{
		}

		public void UpdateHandles<T>(global::FNLEEFFPAAJ<T> DELCOFCGDFF)
		{
		}

		protected virtual bool CGDCMLLNLMG<T>(global::FNLEEFFPAAJ<T> DELCOFCGDFF)
		{
			return false;
		}
	}
}
