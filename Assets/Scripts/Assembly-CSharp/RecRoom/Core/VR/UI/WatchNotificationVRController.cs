using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using RecRoom.Inputs;
using RecRoom.Players.Watch;
using UnityEngine;

namespace RecRoom.Core.VR.UI
{
	[Serializable]
	public class WatchNotificationVRController
	{
		private sealed class AAPHNJIPMLP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public WatchAttractor watchAttractor;

			public WatchNotificationVRController _003C_003E4__this;

			public PlayerUI playerUI;

			private float _003CendTime_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public AAPHNJIPMLP(int _003C_003E1__state)
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

		private sealed class JGIBBGLNEAP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PlayerHand watchHand;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public JGIBBGLNEAP(int _003C_003E1__state)
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

		[SerializeField]
		private float watchNotificationDuration;

		[SerializeField]
		private RecRoomAudioClip watchNotificationAudio;

		[SerializeField]
		private float quickAcceptHoldDuration;

		private LKGILLBEJEK attractorEffectCoroutine;

		private LKGILLBEJEK hapticsCoroutine;

		private float quickAcceptInputHoldTime;

		private bool notificationSoundPlaying;

		private int Priority => 0;

		public void EHMICKMBCPH(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE, NotificationManager MBOHNPDIBAA)
		{
		}

		private void JMIKCFIALDB(VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE)
		{
		}

		private void GBLPGNPEMCM(VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE)
		{
		}

		private (bool, float, bool) EGIFKCGKMOL()
		{
			return default;
		}

		private void BPFKGALCLJM(NotificationManager MBOHNPDIBAA, PlayerUI JABLCIGJBJL, PlayerHand HNEHPOMKODE, WatchAttractor OFJNKJJAGAM, NotificationManager.BMLNJJNEOAB PBOPFHHBNPO, Sprite MDECPMJIFKB)
		{
		}

		private void EIJPPDCDCMB(NotificationManager.BMLNJJNEOAB PBOPFHHBNPO, PlayerHand HNEHPOMKODE)
		{
		}

		private void CADCEGMEGEA(NotificationManager MBOHNPDIBAA, NotificationManager.BMLNJJNEOAB PBOPFHHBNPO, Sprite MDECPMJIFKB)
		{
		}

		private void PNKOKJLCPKC(NotificationManager.BMLNJJNEOAB PBOPFHHBNPO, PlayerHand HNEHPOMKODE)
		{
		}

		private void MOAPEEGAKGC(NotificationManager.BMLNJJNEOAB PBOPFHHBNPO, PlayerUI JABLCIGJBJL, WatchAttractor OFJNKJJAGAM)
		{
		}

		private void FGBMHPHIJDD(PlayerUI JABLCIGJBJL, WatchAttractor OFJNKJJAGAM)
		{
		}

		private void OOEILAGGHCA(WatchAttractor OFJNKJJAGAM)
		{
		}

		private IEnumerator<EGGPGCCKPCO> JONGLLIHEJO(PlayerUI JABLCIGJBJL, WatchAttractor OFJNKJJAGAM)
		{
			return null;
		}

		private void IFBPOPMBOHD(PlayerHand HNEHPOMKODE)
		{
		}

		private void DCLGBJKFNAP()
		{
		}

		private IEnumerator<EGGPGCCKPCO> DFDPCMDGHKA(PlayerHand HNEHPOMKODE)
		{
			return null;
		}

		[CompilerGenerated]
		private void KMCFJIIGNHN(SFXAudioSource GLLFHCCFIGK)
		{
		}
	}
}
