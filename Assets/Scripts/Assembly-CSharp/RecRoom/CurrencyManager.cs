using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom
{
	public class CurrencyManager : SingletonMonoBehaviour<CurrencyManager>
	{
		[Serializable]
		public struct NotificationTimings
		{
			public float preCollectableDelay;

			public float collectableSpawnDuration;

			public float postCollectableDelay;

			public float awardCountDuration;

			public float awardCountTickFrequency;

			public RecRoomAudioClip celebrationStartAudio;
		}

		[Serializable]
		public class CurrencyTypeSettings
		{
			public GKPEKOLBBJL currencyType;

			public bool isPlatformSpecific;

			public EAFLPCNDJNK[] platformTypes;

			public string currencyName;

			public bool currencyNameSingularOnly;

			public SpawnableCollectible currencyPrefab;

			public PooledParticle currencyBoxAwardFx;

			public AnimationCurve particleSpawnAmounts;

			public AnimationCurve particleSpawnDurations;

			public bool skipAwardNotifications;

			public RecRoomAudioClip celebrationFinishAudio;

			public RecRoomAudioClip dispensingCurrencyAudioClip;

			public RecRoomAudioClip dispensingCurrencyShortAudioClip;

			public RecRoomAudioClip countingCurrencyAudioClip;

			public int smallAmountThreshold;
		}

		[Serializable]
		public struct CurrencyAward
		{
			public int baseAward;

			public int bonusAward;

			public int currentCount;

			public int rateLimit;

			public EPJJLKAOOLD balanceAddType;

			public GKPEKOLBBJL currencyType;

			public EAFLPCNDJNK? platformType;
		}

		private sealed class KFBOLAGINKB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public CurrencyManager _003C_003E4__this;

			public CurrencyAward currencyAward;

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
			public KFBOLAGINKB(int _003C_003E1__state)
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

		private sealed class IMMONHKDLNF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public Transform spawnTransform;

			public CurrencyManager _003C_003E4__this;

			public Player targetPlayer;

			public CurrencyAward award;

			public bool fromGiftBox;

			private Vector3 _003CspawnPosition_003E5__2;

			private Quaternion _003CspawnRotation_003E5__3;

			private WorldSpaceNotification _003Cnotification_003E5__4;

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
			public IMMONHKDLNF(int _003C_003E1__state)
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

		private sealed class CEOHLGLEAKH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public int awardAmount;

			public CurrencyManager _003C_003E4__this;

			public GKPEKOLBBJL currencyType;

			public EAFLPCNDJNK? platformType;

			public NotificationTimings timing;

			public Transform spawnTransform;

			public bool fromGiftBox;

			public Player targetPlayer;

			private float _003CawardAmountF_003E5__2;

			private float _003CawardDuration_003E5__3;

			private CurrencyTypeSettings _003Csettings_003E5__4;

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
			public CEOHLGLEAKH(int _003C_003E1__state)
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

		private sealed class DNKIGLMFNPE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public CurrencyManager _003C_003E4__this;

			public Vector3 spawnPosition;

			public Quaternion rotation;

			public NotificationTimings timing;

			public int awardAmount;

			public GKPEKOLBBJL currencyType;

			public EAFLPCNDJNK? platformType;

			public int previousAward;

			public WorldSpaceNotification notification;

			public string subtitle;

			private float _003CcountdownTimer_003E5__2;

			private float _003CtickTimer_003E5__3;

			private int _003CtotalTicks_003E5__4;

			private int _003CcountedTicks_003E5__5;

			private int _003CcountedAward_003E5__6;

			private int _003CawardStepSize_003E5__7;

			private CurrencyTypeSettings _003Csettings_003E5__8;

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
			public DNKIGLMFNPE(int _003C_003E1__state)
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
		private NotificationTimings baseAwardNotificationTimings;

		[SerializeField]
		private NotificationTimings bonusAwardNotificationTimings;

		[SerializeField]
		private float postSpawnDelay;

		[SerializeField]
		private float postBaseAwardDelay;

		[SerializeField]
		public float preFinishAudioDelay;

		[SerializeField]
		private CurrencyTypeSettings[] currencyTypeSettings;

		[SerializeField]
		private string bonusSubtitleTemplate;

		[SerializeField]
		private string awardNoDailySubtitle;

		[SerializeField]
		private string titleTemplate;

		[SerializeField]
		private PooledParticle celebrateParticlePrefab;

		[SerializeField]
		private float celebrateParticleSpacing;

		private int MENFAOKCCLM;

		private LKGILLBEJEK AIIMKHICJNL;

		private LKGILLBEJEK BPDFDINCBPJ;

		private GameObject PGODBENJEHO;

public bool IsWaitingToAwardCurrency
{
get 		{
			return false;
		}

}

public bool IsCurrencyRewardRunning
{
get 		{
			return false;
		}

}

private bool EAMFMJFGKBF
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void CPEEAIHIMMG(LKKOPNLCJBC.BalanceUpdateResponseDTO<LKKOPNLCJBC.RewardBalanceModificationDTO> MLDANHIGANI)
		{
		}

		private IEnumerator<EGGPGCCKPCO> ODIFBEMDJJG(CurrencyAward GFNCBNPFGKL)
		{
			return null;
		}

		public void ReceiveCurrencyAwardFromGiftBox(Player GCILADHGICM, int BECMELKBGCA, GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB, Transform FNAMEGNIGFA)
		{
		}

		public void StartReceiveCurrencyAwardsCoroutine(Player CBDPEOAABOH, CurrencyAward EJGBIFAPJHP, Transform FNAMEGNIGFA, bool HMMNPPJLBPP)
		{
		}

		public void StopReceiveCurrencyAwardsCoroutine()
		{
		}

		private IEnumerator<EGGPGCCKPCO> OKEFCKJELPM(Player CBDPEOAABOH, CurrencyAward EJGBIFAPJHP, Transform FNAMEGNIGFA, bool HMMNPPJLBPP)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> AFBBJBBDNDG(Player CBDPEOAABOH, int MLDLAEBBODJ, Transform FNAMEGNIGFA, NotificationTimings HLAGNPALJIL, GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB, bool HMMNPPJLBPP)
		{
			return null;
		}

		private void JIGDNLNFFGL(float MLDLAEBBODJ, float IFBKPBCLLAL, Transform FNAMEGNIGFA, CurrencyTypeSettings CAOIPCMMNMJ)
		{
		}

		private void NFIFIEJDANP(Player CBDPEOAABOH, int MLDLAEBBODJ, Vector3 FCNGMPHKHAE, NotificationTimings HLAGNPALJIL, GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB)
		{
		}

		private IEnumerator<EGGPGCCKPCO> AJGIJAMJINC(WorldSpaceNotification PBOPFHHBNPO, string OEEBIOPLOMG, int MLDLAEBBODJ, int CPJPLABJHMJ, Vector3 FCNGMPHKHAE, Quaternion HEGBBJCMANH, NotificationTimings HLAGNPALJIL, GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB)
		{
			return null;
		}

		private CurrencyTypeSettings BJGONBKDJAP(GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB)
		{
			return null;
		}

		private bool CLNPLMLHCIH(CurrencyTypeSettings CAOIPCMMNMJ, GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB)
		{
			return false;
		}

		public string ToCurrencyString(long BAOJPELMDEI, GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB)
		{
			return null;
		}

		public string GetPluralCurrencyName(GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB)
		{
			return null;
		}

		public SpawnableCollectible GetCurrencyPrefab(GKPEKOLBBJL HLFOMOKJKAM, EAFLPCNDJNK? GEAFKINFDLB)
		{
			return null;
		}
	}
}
