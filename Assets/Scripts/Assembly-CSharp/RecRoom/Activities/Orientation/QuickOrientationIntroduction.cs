using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.Core.Animation;
using RecRoom.Core.Utils.Random;
using RecRoom.Tutorials;
using UnityEngine;

namespace RecRoom.Activities.Orientation
{
	public class QuickOrientationIntroduction : OrientationIntroductionBase, FEGADGPOOCL, IDisposable
	{
		private enum CCHEMLOIMON
		{
			WaitForPlayerSpawn = 0,
			Intro = 1,
			Tutorial = 2,
			Watch = 3,
			Completed = 4
		}

		[Serializable]
		private class VoiceOverLine
		{
			public float preAudioDelay;

			public RecRoomAudioClip audio;
		}

		[Serializable]
		private class TutorialPrompt
		{
			public float prePromptDelay;

			public bool logAnalytics;

			public TutorialPromptContext prompt;
		}

		private sealed class NBLIICABGBE : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuickOrientationIntroduction _003C_003E4__this;

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
			public NBLIICABGBE(int _003C_003E1__state)
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

		private sealed class GIAPHKDCJJD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float duration;

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
			public GIAPHKDCJJD(int _003C_003E1__state)
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

		private sealed class MBKIGBBKHPI
		{
			public QuickOrientationIntroduction _003C_003E4__this;

			public TutorialPrompt prompt;

			internal void _003CPlayTutorialPrompt_003Eb__0()
			{
			}

			internal LAHBDKNMNHN _003CPlayTutorialPrompt_003Eb__1()
			{
				return null;
			}

			internal void _003CPlayTutorialPrompt_003Eb__2()
			{
			}
		}

		private sealed class DAAAEOMPJPG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public VoiceOverLine[] voiceOverLines;

			private int _003Ci_003E5__2;

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
			public DAAAEOMPJPG(int _003C_003E1__state)
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

		private sealed class CFKMACDIJAE
		{
			public QuickOrientationIntroduction _003C_003E4__this;

			public Transform head;

			internal bool _003CProcessEncounters_003Eb__1()
			{
				return false;
			}

			internal LAHBDKNMNHN _003CProcessEncounters_003Eb__2()
			{
				return null;
			}

			internal void _003CProcessEncounters_003Eb__3()
			{
			}
		}

		private sealed class GHKOKAIBHEN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public QuickOrientationIntroduction _003C_003E4__this;

			private CFKMACDIJAE _003C_003E8__1;

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
			public GHKOKAIBHEN(int _003C_003E1__state)
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

		private sealed class JIFPOALAIPN
		{
			public QuickOrientationIntroduction _003C_003E4__this;

			public AECAHLPIFOC inputHandler;

			public List<FMNJCGLEDJO> controlTypes;

			internal bool _003CDetectWavingGesture_003Eb__0()
			{
				return false;
			}
		}

		private sealed class PEPJNLCHICG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public QuickOrientationIntroduction _003C_003E4__this;

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
			public PEPJNLCHICG(int _003C_003E1__state)
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

		private sealed class KEAJGIHLIDF
		{
			public bool boxOpen;

			public QuickOrientationIntroduction _003C_003E4__this;

			public bool watchPickedUp;

			public bool watchOpened;

			internal void _003CWatchCoroutine_003Eg__BoxOpened_007C0(BaseOpenableChest box)
			{
			}

			internal void _003CWatchCoroutine_003Eg__WatchPickup_007C1(Tool tool)
			{
			}

			internal bool _003CWatchCoroutine_003Eb__2()
			{
				return false;
			}

			internal bool _003CWatchCoroutine_003Eb__3()
			{
				return false;
			}

			internal void _003CWatchCoroutine_003Eg__WatchOpen_007C4(bool visible)
			{
			}

			internal bool _003CWatchCoroutine_003Eb__5()
			{
				return false;
			}
		}

		private sealed class JMOFIHIAINA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuickOrientationIntroduction _003C_003E4__this;

			private KEAJGIHLIDF _003C_003E8__1;

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
			public JMOFIHIAINA(int _003C_003E1__state)
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

		private sealed class HOECMCKJDGE : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuickOrientationIntroduction _003C_003E4__this;

			public VoiceOverLine[] voiceOverLines;

			private int _003Ci_003E5__2;

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
			public HOECMCKJDGE(int _003C_003E1__state)
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

		private sealed class JKIHBGFEODO : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VoiceOverLine voiceOverLine;

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
			public JKIHBGFEODO(int _003C_003E1__state)
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

		[SerializeField]
		private Transform spawnPoints;

		[SerializeField]
		private Transform spawnPointsTargetPosition;

		[SerializeField]
		private GameObject[] quickOrientationElements;

		[SerializeField]
		private bool blockScreenInputsDuringIntro;

		[SerializeField]
		private RecRoomAudioClip musicalStinger;

		[SerializeField]
		private PlayerAnimationVignette screensVignette;

		[SerializeField]
		private VoiceOverLine[] introVoiceOverLines;

		[Space]
		[SerializeField]
		private bool displayIntroPromptDuringVO;

		[SerializeField]
		private TutorialPromptContext introPrompt;

		[SerializeField]
		[Space]
		private float hudFadeDelay;

		[SerializeField]
		private float hudFadeDuration;

		[SerializeField]
		[Space]
		private float initialCameraFadeDelay;

		[SerializeField]
		private float initialCameraFadeDuration;

		[SerializeField]
		private LookAtTracker lookAtMirrorTracker;

		[SerializeField]
		private TutorialPrompt tutorialLookAtMirror;

		[SerializeField]
		private TutorialPrompt tutorialWave;

		[SerializeField]
		private VoiceOverLine[] tutorialWaveVoiceOverLines;

		[SerializeField]
		private TutorialPrompt tutorialWalk;

		[SerializeField]
		private TutorialPrompt tutorialJump;

		[SerializeField]
		private GameObject giftBox;

		[SerializeField]
		private GameObject giftBoxVFX;

		[SerializeField]
		private GameObject beacon;

		[SerializeField]
		private RecRoomAudioClip boxOpenSFX;

		[SerializeField]
		private GameObject boxOpenVFX;

		[SerializeField]
		private RecRoomAudioClip watchPickUpSFX;

		[SerializeField]
		private TutorialHint openGiftBoxHint;

		[SerializeField]
		private BaseOpenableChest watchGiftBox;

		[SerializeField]
		private Tool watch;

		[SerializeField]
		private GameObject watchPickupVFX;

		[SerializeField]
		private GameObject watchGiftBoxDisappearVFX;

		[SerializeField]
		private PlayerAnimationVignette watchPickUpVignette;

		[Space]
		[SerializeField]
		private VoiceOverLine[] watchInitialVoiceOverLines;

		[SerializeField]
		private VoiceOverLine[] watchBoxOpenVoiceOverLines;

		[SerializeField]
		private VoiceOverLine[] watchPickupVoiceOverLines;

		[SerializeField]
		private VoiceOverLine[] watchExploreVoiceOverLines;

		[SerializeField]
		private TutorialPrompt watchExplorePrompt;

		[SerializeField]
		[Space]
		private VoiceOverLine[] watchContainerOrientationLines;

		[SerializeField]
		private TutorialPrompt openWatchPrompt;

		[SerializeField]
		private TutorialPrompt visitRoomPrompt;

		[SerializeField]
		private VoiceOverLine[] outroVoiceOverLines;

		private MDEJADHJOEJ BGBIFFLGANM;

		private APGPNOKPLLL NKKHAEFBOLO;

		private bool KDBKBFFDGKB;

		private NHNKJMHGBBG GDIBKHKGMGI;

		private bool PGNEFMJIPCK;

		private Action ADILKHJPNGO__BackingField;

		private Coroutine LLKOHPNKKPP;

		private Coroutine HKPCLPFJKBF;

public event Action IntroCompleted {
add {
		}
remove {
		}
}

		public void Init()
		{
		}

		public void ManualUpdate()
		{
		}

		public void Dispose()
		{
		}

		private void FFHDMBBCMLF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void ABNEHFDPHHI()
		{
		}

		private bool NIEJNPAGNMC()
		{
			return false;
		}

		private bool PLKHCPFIHME()
		{
			return false;
		}

		private void OOLGLAPFPJB(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void HMFEPNGGPPF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void DDDJCPNOBJP()
		{
		}

		private IEnumerator EMGPBIIMBLF()
		{
			return null;
		}

		private void NAMCHMCHELM()
		{
		}

		private void KJDJABHILCA()
		{
		}

		private void IOGNJBMJLHH()
		{
		}

		private void FBBHPNNIHAD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private IEnumerator<EGGPGCCKPCO> FNHNBOFMJIH(float FGBPJMKCMAO)
		{
			return null;
		}

		private LAHBDKNMNHN OLHIMAAHFGH(TutorialPrompt HHNMDIGPGKO)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> MMKKGBFJKDL(VoiceOverLine[] KOGJDHEKCNH)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> BPGOMBFBNAN()
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> IINMJKABBEK()
		{
			return null;
		}

		private void DMOEBFDABJK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void ICCNGJNLMNJ(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MPJAEELHJNL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private IEnumerator MBJBBCHPIAH()
		{
			return null;
		}

		private void DPCEBCGGLKG()
		{
		}

		private void NBBLHFOFDJN(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void CHFMPGHBNCL(bool MLDFDBPMBMG)
		{
		}

		private IEnumerator DPJAPFPPBIO(VoiceOverLine[] KOGJDHEKCNH)
		{
			return null;
		}

		private IEnumerator JLKIBOJPJIB(VoiceOverLine NMOAAMHJDEA)
		{
			return null;
		}

		private Coroutine AKKMKDBEFGC(PlayerAnimationVignette JIMMMHPAJDD)
		{
			return null;
		}

		private void MNCCHKCBGNI(string GDGDAIAMBKP, bool LGEIKIBPDOI, bool CIMEHOBDNDL)
		{
		}

		private void PIFBLKIOLKI(TutorialPrompt HHNMDIGPGKO)
		{
		}

		private void JMKLOGEJLMH(TutorialPrompt HHNMDIGPGKO)
		{
		}

		private string HDOOBOKAGJM()
		{
			return null;
		}
	}
}
