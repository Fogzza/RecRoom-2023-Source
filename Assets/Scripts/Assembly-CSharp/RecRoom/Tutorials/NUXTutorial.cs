using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RRUI.Navigation;
using RecRoom.Activities.Orientation;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.Core.Animation;
using UnityEngine;

namespace RecRoom.Tutorials
{
	public class NUXTutorial : TutorialController
	{
		private enum JJJFDNNJCOK
		{
			Inactive = 0,
			DormRoomIntro = 1,
			Completed = 2
		}

		private sealed class ICLPKHHKBKA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NUXTutorial _003C_003E4__this;

			object IEnumerator<object>.Current
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
			public ICLPKHHKBKA(int _003C_003E1__state)
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

		private sealed class HCCANCLNKKM : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NUXTutorial _003C_003E4__this;

			object IEnumerator<object>.Current
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
			public HCCANCLNKKM(int _003C_003E1__state)
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

		private sealed class KKFKBCPFDIH
		{
			private sealed class _003C_003CRRUIWatchFlowTeardown_003Eg__WaitUntilWatchNotVisible_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public KKFKBCPFDIH _003C_003E4__this;

				public float timeout;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CRRUIWatchFlowTeardown_003Eg__WaitUntilWatchNotVisible_007C0_003Ed(int _003C_003E1__state)
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

			public WatchUI watchUI;

			internal IEnumerator<EGGPGCCKPCO> _003CRRUIWatchFlowTeardown_003Eg__WaitUntilWatchNotVisible_007C0(float timeout)
			{
				return null;
			}

			internal void _003CRRUIWatchFlowTeardown_003Eg__PostCloseCleanup_007C1()
			{
			}
		}

		private sealed class HBJPJOEIHOK
		{
			public float start;

			public float timeout;

			public KKFKBCPFDIH CS_0024_003C_003E8__locals1;

			internal bool _003CRRUIWatchFlowTeardown_003Eb__2()
			{
				return false;
			}
		}

		[SerializeField]
		private float initialVoiceOverDelay;

		[SerializeField]
		private RecRoomAudioClip nuxMusic;

		[SerializeField]
		private float nuxMusicFadeInTime;

		[SerializeField]
		private SceneSpawnPoint nuxSpawnPoint;

		[SerializeField]
		private TeleportationPortal recCenterDoor;

		[SerializeField]
		private RecRoomAudioClip yourDormVoiceOver;

		[SerializeField]
		private RecRoomAudioClip beforeYouGoVoiceOver;

		[SerializeField]
		private RecRoomAudioClip yourVeryOwnVoiceOver;

		[SerializeField]
		private RecRoomAudioClip thisIsYourDormVoiceOver;

		[SerializeField]
		private GameObject giftBoxTable;

		[SerializeField]
		private OrientationTearStripBox giftBox;

		[SerializeField]
		private GiftBoxItemContainer rewardContainer;

		[SerializeField]
		private RecRoomAudioClip closedGiftBoxAppearingSfx;

		[SerializeField]
		private GameObject closedGiftBoxBeacon;

		[SerializeField]
		private float boxDespawnDelay;

		[SerializeField]
		private Tool reward;

		[SerializeField]
		private GameObject watchPickedUpVfx;

		[SerializeField]
		private RecRoomAudioClip watchPickedUpSfx;

		[SerializeField]
		private string watchPickedUpNotificationText;

		[SerializeField]
		private float watchPickedUpNotificationDuration;

		[SerializeField]
		private PCBHIGOMCDE watchPickedUpNotificationType;

		[SerializeField]
		private PlayerAnimationVignette screensVignette;

		[SerializeField]
		private Radio radio;

		private MDEJADHJOEJ BGBIFFLGANM;

		private Coroutine HEGLMMJABEN;

protected override TutorialManager.AGHBFNEFPAA EBKKEDNBHBE
{
get 		{
			return TutorialManager.AGHBFNEFPAA.NUX_INTRO;
		}

}

protected override bool KLDEGNDBBLA
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void CLMFJKBJPDK()
		{
		}

		protected override bool PADNEIPEELM()
		{
			return false;
		}

		protected override void HFLDIIHPOHM()
		{
		}

		protected override void OGBCOBDLGKJ()
		{
		}

		protected override bool BDJKHAEKPNF()
		{
			return false;
		}

		protected override void BDACPGCBACI()
		{
		}

		private void AJFMFMJIDCN(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private IEnumerator NMIEBFKFALP()
		{
			return null;
		}

		private void MBJDNLMMFDO(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool PLKHCPFIHME()
		{
			return false;
		}

		private void NECABLFNFAM()
		{
		}

		private void NDENAIFEGGC()
		{
		}

		private void MLOEPDOPGJD()
		{
		}

		private IEnumerator CGLNBLOCMBH()
		{
			return null;
		}

		public static bool RRUIWatchFlowSetup(Route NBCNOLJOIIM = null)
		{
			return false;
		}

		public static bool RRUIWatchFlowTeardown(bool ACCBMKJPCII = false)
		{
			return false;
		}

		private bool EHBJHIIBHAB(JJJFDNNJCOK DBMCLBLGGJG)
		{
			return false;
		}
	}
}
