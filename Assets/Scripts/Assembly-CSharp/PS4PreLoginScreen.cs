using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public abstract class PS4PreLoginScreen : MonoBehaviour
{
	public enum LHIGKFFBNKB
	{
		OPTION_1 = 0,
		OPTION_2 = 1
	}

	private sealed class PHJEEKBPCKF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public PS4PreLoginScreen _003C_003E4__this;

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
		public PHJEEKBPCKF(int _003C_003E1__state)
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

	private sealed class NDJJBCAMAIA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public PS4PreLoginScreen _003C_003E4__this;

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
		public NDJJBCAMAIA(int _003C_003E1__state)
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

	private sealed class GOPBGJAGEGJ
	{
		public PS4PreLoginScreen _003C_003E4__this;

		public global::PHLHFLLLDLK<LHIGKFFBNKB> promiseToComplete;

		internal LAHBDKNMNHN _003CFadeInFadeOutCoroutine_003Eb__0(LHIGKFFBNKB response)
		{
			return null;
		}

		internal void _003CFadeInFadeOutCoroutine_003Eb__1(string error)
		{
		}
	}

	private sealed class KMLMJGMPMCA
	{
		public LHIGKFFBNKB response;

		public GOPBGJAGEGJ CS_0024_003C_003E8__locals1;

		internal void _003CFadeInFadeOutCoroutine_003Eb__2()
		{
		}
	}

	private sealed class AIAONHKMPJL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public PS4PreLoginScreen _003C_003E4__this;

		public global::PHLHFLLLDLK<LHIGKFFBNKB> promiseToComplete;

		private GOPBGJAGEGJ _003C_003E8__1;

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
		public AIAONHKMPJL(int _003C_003E1__state)
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

	public Image fadeImage;

	public float fadeSeconds;

	private void Start()
	{
	}

	private IEnumerator<EGGPGCCKPCO> POCJJINGLGH()
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> GPGMNBKDBLA()
	{
		return null;
	}

	public global::NCOKFFGPIJM<LHIGKFFBNKB> Show()
	{
		return null;
	}

	protected virtual IEnumerator<EGGPGCCKPCO> FNOILEMDAHN(global::PHLHFLLLDLK<LHIGKFFBNKB> MDEMBKIODEI)
	{
		return null;
	}

	protected abstract IEnumerator<EGGPGCCKPCO> ICEPODEAHOJ(global::PHLHFLLLDLK<LHIGKFFBNKB> MDEMBKIODEI);
}
