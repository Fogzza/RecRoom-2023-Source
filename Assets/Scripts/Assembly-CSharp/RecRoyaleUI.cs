using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RecRoom.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecRoyaleUI : RoomSpecificSubscreenUI
{
	private sealed class EJFLFDKHPGK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public Transform tranformToAnimate;

		public Vector3 start;

		public Vector3 end;

		private float _003Ct_003E5__2;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public EJFLFDKHPGK(int _003C_003E1__state)
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

	private sealed class BHPBNOBJBKA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RecRoyaleUI _003C_003E4__this;

		public FDNLGHJKPBG.MJELDFKOCAF newPlayerStats;

		private int _003ClastAcornBalance_003E5__2;

		private long _003CstartXPValue_003E5__3;

		private int _003CacornsEarned_003E5__4;

		private int _003Ci_003E5__5;

		private float _003CendPct_003E5__6;

		private float _003CanimSpeed_003E5__7;

		private float _003CcurrPct_003E5__8;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public BHPBNOBJBKA(int _003C_003E1__state)
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

	private sealed class JNNKFOLLHHD
	{
		public bool done;

		internal void _003CRunAnimateTierUp_003Eb__0(HGKINAOMNIF response)
		{
		}

		internal bool _003CRunAnimateTierUp_003Eb__1()
		{
			return false;
		}
	}

	private sealed class KJEGGELGBFF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RecRoyaleUI _003C_003E4__this;

		public bool usedAcorns;

		public bool noAvailableItems;

		public int newAcornBalance;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public KJEGGELGBFF(int _003C_003E1__state)
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

	private sealed class GOBAJPOBIBO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int newBalance;

		public int oldBalance;

		public RecRoyaleUI _003C_003E4__this;

		private int _003CacornsEarned_003E5__2;

		private int _003Ci_003E5__3;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public GOBAJPOBIBO(int _003C_003E1__state)
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

	private sealed class NKMPGDNOMJG
	{
		public long cost;

		public RecRoyaleUI _003C_003E4__this;

		internal void _003CUpgradeToEliteTrack_003Eb__0(HGKINAOMNIF response)
		{
		}
	}

	private sealed class DAFMHEOHDAN
	{
		public RecRoyaleUI _003C_003E4__this;

		public KGFLMPJOODP nextTier;

		public long cost;

		internal void _003CPurchaseNextTier_003Eb__0(HGKINAOMNIF response)
		{
		}
	}

	private sealed class ENNIJHHDNLC
	{
		public RecRoyaleUI _003C_003E4__this;

		public bool animateResult;

		public GKPEKOLBBJL currencyType;

		public int tierNumber;

		internal LAHBDKNMNHN _003CUnlockNextTier_003Eb__0(LKKOPNLCJBC.PurchaseBalanceUpdateResponseDTO<EDDPDJCKOBH.GMBCAMAAPMN> updateResponse)
		{
			return null;
		}

		internal void _003CUnlockNextTier_003Eb__1(string error)
		{
		}
	}

	[SerializeField]
	private Image rankBadge;

	[SerializeField]
	private TextMeshProUGUI rankText;

	[SerializeField]
	private Slider xpBar;

	[SerializeField]
	private GameObject maxLevelReachedText;

	[SerializeField]
	private TextMeshProUGUI acornBonusText;

	[SerializeField]
	private Image animatedAcorn;

	[SerializeField]
	private Transform animatedAcornStart;

	[SerializeField]
	private GameObject XPGroup;

	[SerializeField]
	private TextMeshProUGUI xpText;

	[SerializeField]
	private TextMeshProUGUI roundCompleteText;

	[SerializeField]
	private TextMeshProUGUI animatedXPText;

	[SerializeField]
	private Transform animatedXPStart;

	[SerializeField]
	private Transform animatedXPEnd;

	[SerializeField]
	private GameObject seasonTierGroup;

	[SerializeField]
	private TextMeshProUGUI currentSeasonText;

	[SerializeField]
	private TextMeshProUGUI yourTierText;

	[SerializeField]
	private GameObject maxTierReachedText;

	[SerializeField]
	private TextMeshProUGUI seasonEndsText;

	[SerializeField]
	private int daysLeftToShowSeasonEndsText;

	[SerializeField]
	private Button3D upgradeButton;

	[SerializeField]
	private GameObject eliteText;

	[SerializeField]
	private TierRewardPagedGrid tierRewardPagedGrid;

	[SerializeField]
	private Transform acornsParent;

	[SerializeField]
	private Animator acornBonusAnimator;

	[SerializeField]
	private Color gold;

	[SerializeField]
	private RecRoomAudioClip acornPopAudio;

	[SerializeField]
	private RecRoomAudioClip tierUpAudio;

	[SerializeField]
	private RecRoomAudioClip incrementXPClip;

	[SerializeField]
	private RecRoomAudioClip levelUpClip;

	[SerializeField]
	private RecRoomAudioClip statPostedClip;

	[SerializeField]
	private RecRoomAudioClip summaryOpenClip;

	[SerializeField]
	private RecRoomAudioClip roundCompleteClip;

	[SerializeField]
	private RecRoomAudioClip totalXPEarnedClip;

	[SerializeField]
	private RecRoomAudioClip goldAcornAudio;

	[SerializeField]
	private RecRoomAudioClip acornToTierAudio;

	private static readonly int DEOMFFJLGFC;

	private static readonly int AAAJMHNFGFI;

	private static readonly int CJANJPADOHB;

	private static readonly int HKDNLEBIDMF;

	private Animator[] BNEPMGJHMCI;

	private OOLOKEOHJPG MFMGAHKGNGD;

	private FDNLGHJKPBG.JOCOKIINHJK NOGNALIEAGJ;

	private long JGKPMLIFMID;

	private bool LMIBMJGOEOO;

	private SFXAudioSource MGNOIOKOMFF;

	private KGFLMPJOODP KICDGHJCGDF;

	private List<EDDPDJCKOBH.GMBCAMAAPMN> HIPNHNCIIIB;

	private Coroutine FCBOGFMMCCB;

	private bool PNGKNHNJNKI;

	private bool BFDBIMJCLDH;

	private Coroutine IOHHJOJJJCP;

	private Coroutine FANJNGKJAAB;

private bool NHGDDMNPJHA
{
get 	{
		return false;
	}

}

private bool OBAMFJFLIOE
{
get 	{
		return false;
	}

}

	private void Awake()
	{
	}

	public override void Initialize(WatchUIFlow ELNPJBMKDAE)
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void LAEEIDFPELD()
	{
	}

	private void FEJBOLBHJKJ(FDNLGHJKPBG.MJELDFKOCAF CAGPLFLEHBO)
	{
	}

	private IEnumerator NALFAMFEMKJ(Transform NCNKEMFGLFN, Vector3 EBEICGFALNG, Vector3 OGINPOLMPBC, float FGBPJMKCMAO)
	{
		return null;
	}

	private void GFDACKHIMLF(FDNLGHJKPBG.MJELDFKOCAF CAGPLFLEHBO)
	{
	}

	private void KHNIGJHAJHF()
	{
	}

	private IEnumerator EGCGKCNHAGN(FDNLGHJKPBG.MJELDFKOCAF CAGPLFLEHBO)
	{
		return null;
	}

	private void BAAGGADGGCJ(bool NFEHBHLKGJF, int OKFFFOMDEHN, bool PHBNDBODBLJ)
	{
	}

	private IEnumerator KANFOEPFCEG(bool NFEHBHLKGJF, int OKFFFOMDEHN, bool PHBNDBODBLJ)
	{
		return null;
	}

	private bool JPOMBGBOENA(int IBLPMLGLNJN, int JKPJELBKKGN)
	{
		return false;
	}

	private void FIIIGLGHHPP()
	{
	}

	private IEnumerator BALBNAPABND(int IBLPMLGLNJN, int JKPJELBKKGN)
	{
		return null;
	}

	private void EHLCNDNOGCE()
	{
	}

	private void GFDIPIEDOMM()
	{
	}

	private void PPDGLFBANDH()
	{
	}

	private void HPPHMGHIMBI(GKPEKOLBBJL HLFOMOKJKAM, int IEGHJNDINMO, int GMDMKEPHEBP, long KKEJFMCDMBC, bool ELPCGGIBMKM = true)
	{
	}

	private void LFLIGLIPOFO()
	{
	}

	private void ECJGNLOECOA()
	{
	}

	public void Button_Info()
	{
	}

	public void Button_UpgradeToElite()
	{
	}

	public void Button_BuyTier(int tierNumber)
	{
	}

	[CompilerGenerated]
	private void JNIDACCBLIE(FDNLGHJKPBG.JOCOKIINHJK COLMAMKJPJE)
	{
	}

	[CompilerGenerated]
	private void AIPKKNKEBMC(OOLOKEOHJPG JHAGLGAMPLN)
	{
	}

	[CompilerGenerated]
	private void MHKOECIDGCH(LKKOPNLCJBC.PurchaseBalanceUpdateResponseDTO<EDDPDJCKOBH.GMBCAMAAPMN> ODGBIPOHJOM)
	{
	}

	[CompilerGenerated]
	private void AONHDHLPAKB(long IKPHOKLCAHE)
	{
	}
}
