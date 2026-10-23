using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Activities.Quest;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.StuntRunner
{
	public class StuntRunnerManager : QuestManager
	{
		public enum DEJHLMNCIBF
		{
			INVALID = 65535,
			WAIT_FOR_PLAYERS = 0,
			COURSE_PREP = 1,
			COUNTDOWN = 2,
			COURSE_RUNNING = 3,
			COURSE_FINISHED = 4,
			COURSE_TRANSITION = 6
		}

		private enum DOFFILEEEGE
		{
			TIMED_OUT = 0,
			COMPLETED = 1
		}

		private enum AJGCDNADDKJ
		{
			CURRENT_COURSE_FINISHED = 1,
			COURSE_TIME = 2,
			TOTAL_TIME = 9,
			COMPLETED_COURSE_TIME1 = 10,
			COMPLETED_COURSE_TIME2 = 11,
			COMPLETED_COURSE_TIME3 = 12,
			COMPLETED_COURSE_TIME4 = 13,
			COMPLETED_COURSE_TIME5 = 14,
			COMPLETED_COURSE_TIME6 = 15
		}

		private enum OLIICIKJPEG
		{
			DURING_RACE = 0,
			POST_RACE = 1
		}

		public enum BIJKBMLMHKI
		{
			COUNTDOWN = 0,
			RACE_START = 1,
			PLAYER_FINISHED = 2,
			GAME_START = 3
		}

		[Serializable]
		private struct StuntRunnerFeedbackStep
		{
			public RecRoomAudioClip[] possibleAudioClips;

			public bool stopMusic;

			public RecRoomAudioClip musicChange;

			public string notificationTitle;

			public string notificationSubTitle;

			public float notificationDuration;

			public float delayAfterAudioClipBeforeNextFeedbackStep;

			public float delayWhenNoAudioClipBeforeNextFeedbackStep;

			private SFXAudioSource clipAudioSource;

			public EGGPGCCKPCO NOIOGEDNFDJ(bool DNILCPBLNFE, bool KCPHJNEBNPF = true, string OIDGJDNKPNO = null)
			{
				return null;
			}

			private EGGPGCCKPCO MBBLFEEDMCN()
			{
				return null;
			}
		}

		[Serializable]
		private struct StuntRunnerFeedbackStepBucket
		{
			public float percentile;

			public StuntRunnerFeedbackStep feedback;
		}

		[Serializable]
		private struct StuntRunnerBucketedFeedbackStep
		{
			public StuntRunnerFeedbackStepBucket[] feedbackBuckets;

			public EGGPGCCKPCO NOIOGEDNFDJ(float HEOMCBGGPAP, bool DNILCPBLNFE, bool KCPHJNEBNPF = true, string OIDGJDNKPNO = null)
			{
				return null;
			}
		}

		[Serializable]
		private struct StuntRunnerConditionalFeedbackStep
		{
			public StuntRunnerFeedbackStep completedFeedback;

			public StuntRunnerFeedbackStep timedOutFeedback;

			public EGGPGCCKPCO NOIOGEDNFDJ(bool AANGHIPHJFD, bool DNILCPBLNFE, bool DGCFMNEOAPL = true, bool IEPKDACLJHK = true, string OIDGJDNKPNO = null)
			{
				return null;
			}
		}

		[Serializable]
		private struct TimeRemainingWarning
		{
			public int timeRemaining;

			public RecRoomAudioClip warningVO;
		}

		public delegate void DOLOBEFEFMG(BIJKBMLMHKI MBJJKJNAOPF);

		private sealed class IGPEBHIAAOD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

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
			public IGPEBHIAAOD(int _003C_003E1__state)
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

		private sealed class BJJHGDIAAIN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public CHILKDJABBF finishingPlayer;

			public bool firstToFinish;

			public bool timedOut;

			public StuntRunnerManager _003C_003E4__this;

			public int finishTimeMilliseconds;

			private float _003CfinishTimePercentile_003E5__2;

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
			public BJJHGDIAAIN(int _003C_003E1__state)
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

		private sealed class CLJGBICBBHO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public StuntRunnerManager _003C_003E4__this;

			private GameScoreManager.ELDAKJLJBKB _003Crank_003E5__2;

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
			public CLJGBICBBHO(int _003C_003E1__state)
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

		private sealed class HLNBFGGPBOP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public StuntRunnerManager _003C_003E4__this;

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
			public HLNBFGGPBOP(int _003C_003E1__state)
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

		private sealed class DPHPGLBGMKK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public StuntRunnerManager _003C_003E4__this;

			public bool timedOut;

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
			public DPHPGLBGMKK(int _003C_003E1__state)
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

		private sealed class BNFJLNKOBHP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public bool downedPlayerIsLocal;

			public StuntRunnerManager _003C_003E4__this;

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
			public BNFJLNKOBHP(int _003C_003E1__state)
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

		private static readonly string EPPAJFIGHGA;

		private static readonly string OGPONBBNAJE;

		[SerializeField]
		private int courseMaxBaseScore;

		[SerializeField]
		private RecRoomAudioClip preRaceStartStinger;

		[SerializeField]
		private RecRoomAudioClip[] countdownTickAudioClips;

		[SerializeField]
		private RecRoomAudioClip raceStartAudioClip;

		[SerializeField]
		private float timeBetweenRaceStartAndGameplayMusic;

		[SerializeField]
		private TimeRemainingWarning[] timeRemainingWarnings;

		[SerializeField]
		private StuntRunnerConditionalFeedbackStep playerFinishedCourse;

		[SerializeField]
		private StuntRunnerConditionalFeedbackStep localPlayerFinishedCourse;

		[SerializeField]
		private StuntRunnerBucketedFeedbackStep localPlayerPlacementNotification;

		[SerializeField]
		private StuntRunnerConditionalFeedbackStep localPlayerFinishedCourseNotification;

		[SerializeField]
		private StuntRunnerBucketedFeedbackStep localPlayerFinishedCourseVO;

		[SerializeField]
		private StuntRunnerBucketedFeedbackStep localPlayerCrowdVO;

		[SerializeField]
		private StuntRunnerFeedbackStep localPlayerNewBestNotification;

		[SerializeField]
		private StuntRunnerFeedbackStep localPlayerPostFinishedCourseMusic;

		[SerializeField]
		private StuntRunnerConditionalFeedbackStep courseEnd;

		[SerializeField]
		private StuntRunnerConditionalFeedbackStep courseEndUGC;

		[SerializeField]
		private float winFeedbackStartDelay;

		[SerializeField]
		private StuntRunnerFeedbackStep startWinNotification;

		[SerializeField]
		private StuntRunnerFeedbackStep winNotificationSS;

		[SerializeField]
		private StuntRunnerFeedbackStep winNotificationS;

		[SerializeField]
		private StuntRunnerFeedbackStep winNotificationA;

		[SerializeField]
		private StuntRunnerFeedbackStep winNotificationB;

		[SerializeField]
		private StuntRunnerFeedbackStep winNotificationC;

		[SerializeField]
		private StuntRunnerFeedbackStep endWinNotification;

		[SerializeField]
		private StuntRunnerFeedbackStep localPlayerOutBuzzer;

		[SerializeField]
		private StuntRunnerFeedbackStep announcerTauntVO;

		[SerializeField]
		private RecRoomAudioClip[] audienceReactionSFX;

		[SerializeField]
		private PlayerFollowingSpotlight playerSpotlightPrefab;

		[SerializeField]
		private StuntRunnerGameplayRoom gameplayRoomPrefab;

		[SerializeField]
		private RecRoomAudioClip loadingGameMusic;

		[SerializeField]
		private RecRoomAudioClip gameplayMusic;

		private JOJOABLFOBA HAJEJKPNGBJ;

		private HONEDBECDOK IFCDBBCODHP;

		private float KMBOBOHIJAB;

		private global::MOBDJNEDDKC<bool> HDNJLEGJPEL;

		private List<PlayerFollowingSpotlight> FEBEFBKLBIC;

		private LKGILLBEJEK AIJOBGGEMKK;

		private LKGILLBEJEK HOIFGOABLEB;

		private LKGILLBEJEK FOFCNGEPDFP;

		public static global::HHOBPMOCKMJ<BIJKBMLMHKI> FeedbackEvent;

		private float BLMMHPKMHJI;

		private bool PJPMEOGNPHA;

		private bool FJNCFJBPFPK;

		private bool FCCMIBDCBIB;

		private bool FNJLLIIFGJP;

		private int FOEIAFMHLJO;

public new static StuntRunnerManager Instance
{
get 		{
			return null;
		}

}

public new static bool IsInitialized
{
get 		{
			return false;
		}

}

public int TotalTimeStatChannelForLeaderboard
{
get 		{
			return 0;
		}

}

public override string RuleTypeAutoTag
{
get 		{
			return null;
		}

}

private DEJHLMNCIBF MBHNCCMHIPK
{
get 		{
			return DEJHLMNCIBF.WAIT_FOR_PLAYERS;
		}

set {
		}
}

private DOFFILEEEGE FHAMMMJMEAM
{
get 		{
			return DOFFILEEEGE.TIMED_OUT;
		}

}

private bool IPPLPJDIDDA
{
get 		{
			return false;
		}

}

private bool FMADDMDMPHK
{
get 		{
			return false;
		}

set {
		}
}

public float CourseMaxFinishTimeSeconds
{
get 		{
			return 0f;
		}

set {
		}
}

public bool AnnouncerEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool AmbienceEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool SpotlightsEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool MusicEnabled
{
get 		{
			return false;
		}

set {
		}
}

private StuntRunnerGameplayRoom HGLLNIEJIDN
{
get 		{
			return null;
		}

}

public override bool IsQuestRunning
{
get 		{
			return false;
		}

}

protected override bool KHMNCIMPGMG
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void NJMEMOBBHKF()
		{
		}

		protected override void FNMLANJLBOE(int OOMCLENBFPI)
		{
		}

		protected override void GOGMHGACAFI()
		{
		}

		protected override void HDJBEAFJEHD()
		{
		}

		protected override void ENHEJEADGCH()
		{
		}

		private void OJFNKCIMOAH()
		{
		}

		private void FOJEEPENMEA(Player EKOFNPFCLMO)
		{
		}

		private IEnumerator<EGGPGCCKPCO> FCHOLGAPJBF()
		{
			return null;
		}

		private void FLCNPMMALKP(PhysicalButtonBase HHDMPJJAPJJ, Player EKOFNPFCLMO)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestCourseFinishTime(CHILKDJABBF EKOFNPFCLMO, int OODFHBINEIL)
		{
		}

		private void JMBLOANGNEN(CHILKDJABBF EKOFNPFCLMO, int OODFHBINEIL)
		{
		}

		[PBOMGCLBFHF]
		private void RpcNotifyPlayerFinishedCourse(CHILKDJABBF EKOFNPFCLMO, int OODFHBINEIL, bool AANGHIPHJFD, bool CDANJANNGAD, int KGLADFIJHJK)
		{
		}

		private IEnumerator<EGGPGCCKPCO> OPBJMEADJNH(int OODFHBINEIL, CHILKDJABBF KKBCOPFIIBB, bool AANGHIPHJFD, bool CDANJANNGAD)
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestFinishedPlayingRaceEndFeedback(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void ILNKHEOACFP()
		{
		}

		protected override void JCGBIJMNELF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected override void NJMNFBIODOP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private IEnumerator<EGGPGCCKPCO> KBKOMGAGNHE()
		{
			return null;
		}

		protected override void OCCPGAKFHFH()
		{
		}

		protected override bool CDOBBMCNJKP()
		{
			return false;
		}

		private void KICCEPJGKPG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FGHBFGCDCBE()
		{
		}

		private void JJNIEHMAEOI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CBABLEOIAPP()
		{
		}

		private void HOOLBBBDCHO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EHLPLFHEMCP()
		{
		}

		private void OOCDGEJAGEO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private IEnumerator<EGGPGCCKPCO> EAFLKLPHOKE()
		{
			return null;
		}

		private void BLHODCJOHOM(float HCNHLFPCLIO)
		{
		}

		private void GCONKJCNNCJ(ushort EHLPLCEJPDD, ushort EDNNIIPAKCK)
		{
		}

		private void EGLOPIKBKPL()
		{
		}

		private bool ADCHJDCIMJN()
		{
			return false;
		}

		private bool COAGPFIGNGH(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		private void CEECKOODFOJ(float IOFAEAHGBGJ)
		{
		}

		private void GHBIHIEKMCO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ONLOLFIFPCO()
		{
		}

		private IEnumerator<EGGPGCCKPCO> IPKDPDJCCLB(bool AANGHIPHJFD)
		{
			return null;
		}

		private void OLMBGBLKMBA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		public override bool ValidateRoom()
		{
			return false;
		}

		private void PLLNBNAEGLO(Killzone FOOPALEAEGM)
		{
		}

		protected override void KOKBPINKLEI(CHILKDJABBF ADIIGAEKMMD, JANNFCHDBAB GBMLHJHCLFD, KDBKBBGOBIP OGPDFOMPNND)
		{
		}

		private IEnumerator<EGGPGCCKPCO> FCHFNPPDAKD(bool PDLDMNDBPLI)
		{
			return null;
		}

		private void OnPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private string GJGOJAEEAAN()
		{
			return null;
		}

		public int CurrentCourseTime()
		{
			return 0;
		}

		private int IKCMDLCFMIK(int FINHGCLJBPA, int JFBHLKBFDJI, int FDIGLHIBNMB)
		{
			return 0;
		}

		private int MKJEFIILJGP(CHILKDJABBF EKOFNPFCLMO)
		{
			return 0;
		}

		private void BBGNKNGCACD(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void NEKLNKCGDLI()
		{
		}

		private void FGAIIDNNKLB()
		{
		}

		private void GOMAMPKCCDL()
		{
		}

		private void NAOAHFANMLO()
		{
		}

		[CompilerGenerated]
		private void FIOCOPFBOPG(POCFIEIKIDJ.JGIKBELENCF CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void ONEDOABCDMO()
		{
		}
	}
}
