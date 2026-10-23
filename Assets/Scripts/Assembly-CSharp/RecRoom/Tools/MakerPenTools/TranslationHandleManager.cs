using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class TranslationHandleManager : HandleManagerBase
	{
		private sealed class CJMOALPMDJA : IEnumerable<MakerPenHandle>, IEnumerable, IEnumerator<MakerPenHandle>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private MakerPenHandle _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public TranslationHandleManager _003C_003E4__this;

			private TranslationSideHandle[] _003C_003E7__wrap1;

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
			public CJMOALPMDJA(int _003C_003E1__state)
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

		private TranslationArrowCenterHandle DIDKLCLGAFM;

		private TranslationArrowCenterHandle EGDBGELNBNA;

		private TranslationArrowCenterHandle DCFDBGKACFP;

		private TranslationPlaneHandle PELBIJPIKAK;

		private TranslationPlaneHandle PEDAKJHEMPA;

		private TranslationPlaneHandle EFPKAGNBECN;

		private TranslationSideHandle[] BKEFMOFKHLO;

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

		public static TranslationHandleManager Create()
		{
			return null;
		}

		private void LLLPMINBGLL()
		{
		}

		public void OnStart()
		{
		}

		public void UpdateHandles<T>(global::DDLEHONFEBP<T> LBDKKGGNBPP, NNBAJLCGAOK CAOIPCMMNMJ)
		{
		}
	}
}
