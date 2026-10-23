using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

internal class FJCOIIPMCLL : IDisposable
{
	[Serializable]
	internal struct BacktraceStats
	{
		public bool enabled;

		public int sentCount;

		public int errorCount;

		public int warningCount;

		public int logCount;

		public int exceptionCount;

		public int assertCount;
	}

	private sealed class OJCKCNBKNKE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public FJCOIIPMCLL _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public OJCKCNBKNKE(int _003C_003E1__state)
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
		private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private const string HGIHHBMPFJP = "BACKTRACE_STATS_KEY";

	private const float JCKBLMMGOEE = 0.2f;

	private BHNJIBDJFAL NJPJBDDAEFH;

	private BacktraceStats IHJPCNNDPGN;

	private LKGILLBEJEK FENLMFHIKMN;

	private bool JMBBLLIFCGC;

internal BacktraceStats DLPBKMMIPIN
{
get 	{
		return default;
	}

}

	private IEnumerator<EGGPGCCKPCO> IHEKMEOIBOI()
	{
		return null;
	}

	public void Dispose()
	{
	}

	public void GGJNANJMPKH()
	{
	}

	public void EEIMMDHKKIH(bool EPDJDCDHLMP)
	{
	}

	private void ENBDIMJAIGH(string OFCFPGACNJB, string LMAKMIFAAGI, LogType NIFOGEBEDNG)
	{
	}

	private void PCOACDLIALN(float OKBAJEAPIHG)
	{
	}

	private void ACJLBNHOCIP()
	{
	}

	private void EDJKGKEAOHO()
	{
	}

	private void FOJAMFPCNHC(BacktraceStats IHJPCNNDPGN, bool CJMHOPGDPKI)
	{
	}

	[CompilerGenerated]
	private bool KPBIHOBJGKH()
	{
		return false;
	}
}
