using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using UnityEngine;

public class CameraFade : SingletonMonoBehaviour<CameraFade>
{
	public enum BAIBOJEOOGB
	{
		None = 0,
		Misc = 1,
		LoadNewRoom = 2,
		ReloadRoom = 3,
		AppExit = 4,
		BootSequence = 5,
		BootSequence_LoadNewRoom = 6,
		TitleScreenFlow = 7,
		Logout = 8,
		ShowWebPage = 9,
		IntroRoutine = 10,
		WelcomeRoutine = 11,
		Encounter = 12,
		GameManager_PS = 13
	}

	private sealed class APMDAGFINHP
	{
		public BAIBOJEOOGB reason;

		public DDNDPJHCIHN _003C_003E9__5;

		public DDNDPJHCIHN _003C_003E9__7;

		internal object _003CFade_003Eb__0()
		{
			return null;
		}

		internal void _003CFade_003Eb__2()
		{
		}

		internal object _003CFade_003Eb__5()
		{
			return null;
		}

		internal void _003CFade_003Eb__3(string err)
		{
		}

		internal void _003CFade_003Eb__4()
		{
		}

		internal object _003CFade_003Eb__7()
		{
			return null;
		}
	}

	private sealed class DDDHDKAOKPF
	{
		public string err;

		public APMDAGFINHP CS_0024_003C_003E8__locals1;

		internal object _003CFade_003Eb__6()
		{
			return null;
		}
	}

	private sealed class NKEAPFNOHEN
	{
		public bool fadeDone;

		internal void _003CFadeCoroutine_003Eb__2()
		{
		}

		internal bool _003CFadeCoroutine_003Eb__3()
		{
			return false;
		}
	}

	private sealed class OEABPGDOOJE
	{
		public bool fadeDone;

		internal void _003CFadeCoroutine_003Eb__5()
		{
		}

		internal bool _003CFadeCoroutine_003Eb__6()
		{
			return false;
		}
	}

	private sealed class INOADMJNOMG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public bool suppressEffect;

		public bool fadeIn;

		public CameraFade _003C_003E4__this;

		public float additionalDelay;

		public float overrideDuration;

		public BAIBOJEOOGB reason;

		private IDisposable _003Csample_003E5__2;

		private PNAABCMOHGM.PINBHDOHJGH _003CfadeScope_003E5__3;

		private IDisposable _003C_003E7__wrap3;

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
		public INOADMJNOMG(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		private void _003C_003Em__Finally2()
		{
		}

		private void _003C_003Em__Finally3()
		{
		}

		private void _003C_003Em__Finally4()
		{
		}

		private void _003C_003Em__Finally5()
		{
		}

		private void _003C_003Em__Finally6()
		{
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

	[SerializeField]
	private float fadeOutDelay;

	[SerializeField]
	private float fadeInDelay;

	[SerializeField]
	private float fadeOutDuration;

	[SerializeField]
	private float fadeInDuration;

	[SerializeField]
	private RecRoomAudioClip RezOutAudio;

	[SerializeField]
	private RecRoomAudioClip RezInAudio;

	private LKGILLBEJEK IPGFEAJFGPJ;

	[NonSerialized]
	public bool SuppressAnimateInOutEffects;

	private BAIBOJEOOGB NBNAJBKGNMJ;

public float TotalFadeInDuration
{
get 	{
		return 0f;
	}

}

public float TotalFadeOutDuration
{
get 	{
		return 0f;
	}

}

public bool IsFading
{
get 	{
		return false;
	}

}

public bool IsFadedOut
{
get 	{
		return false;
	}

}

public bool IsFadedIn
{
get 	{
		return false;
	}

}

public float CurrentFade
{
get 	{
		return 0f;
	}

}

public BAIBOJEOOGB FadeReason
{
get 	{
		return BAIBOJEOOGB.None;
	}

private set {
	}
}

	public LKGILLBEJEK FadeIn(bool OGMCEHHFCPB = false, float IEIJJJFGHPD = 0f, float FHFDDKOBFLG = 0f)
	{
		return null;
	}

	public LKGILLBEJEK FadeOut(BAIBOJEOOGB CKHHGBNHHCK, bool OGMCEHHFCPB = false, float IEIJJJFGHPD = 0f, float FHFDDKOBFLG = 0f)
	{
		return null;
	}

	private LKGILLBEJEK LDGHAGNGCBC(bool PLNMEANENBA, BAIBOJEOOGB CKHHGBNHHCK, bool OGMCEHHFCPB = false, float IEIJJJFGHPD = 0f, float FHFDDKOBFLG = 0f)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> BEKOHPHLLGJ(bool PLNMEANENBA, BAIBOJEOOGB CKHHGBNHHCK, bool OGMCEHHFCPB, float IEIJJJFGHPD, float GBBDEADGJLN)
	{
		return null;
	}

	[CompilerGenerated]
	internal static bool FMKMMIDDKJG()
	{
		return false;
	}
}
