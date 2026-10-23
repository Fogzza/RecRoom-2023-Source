using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using UnityEngine;

public class NotificationManager : SingletonMonoBehaviour<NotificationManager>, KCHEHPJJMCP
{
	[Flags]
	public enum NCDNGNOMOFN
	{
		NONE = 0,
		ALL = -1,
		ALL_BUT_TEXT = -9,
		Sound = 1,
		Particle = 2,
		Haptic = 4,
		Text = 8
	}

	public enum MAOKONFJDIM
	{
		Default = 0,
		Chat = 1,
		Cheer = 2,
		Friend = 3,
		FriendRequest = 4,
		Invite = 5,
		Gift = 6,
		Club = 7,
		Room = 8,
		Party = 9,
		Alert = 10,
		Subscribed = 11,
		Event = 12
	}

	public delegate bool BJLOFJDNOIK();

	public struct BMLNJJNEOAB
	{
		public readonly bool BCGLNNFGJLD;

		public readonly MAOKONFJDIM OFOMIMPGNJN;

		public readonly NCDNGNOMOFN CNEGMCINPEK;

		public readonly string BOGCJKAMALE;

		public readonly string PCFACAKIICE;

		public readonly int BFCFNCMBICC;

		public Action IKCHEKPJENN;

		public string EJDIHAJANCO;

		public bool LLJBDFLBMGM;

		public Func<(bool, float, bool)> IEGGCALIHIJ;

		public BMLNJJNEOAB(bool BCGLNNFGJLD, MAOKONFJDIM OFOMIMPGNJN, NCDNGNOMOFN CNEGMCINPEK, string JGMGGFFEKBC, string BDPBDHACNMO, int BFCFNCMBICC = -1, Action IKCHEKPJENN = null, string EJDIHAJANCO = null, bool LLJBDFLBMGM = true)
		{
			this.BCGLNNFGJLD = false;
			this.OFOMIMPGNJN = MAOKONFJDIM.Default;
			this.CNEGMCINPEK = NCDNGNOMOFN.NONE;
			BOGCJKAMALE = null;
			PCFACAKIICE = null;
			this.BFCFNCMBICC = 0;
			this.IKCHEKPJENN = null;
			this.EJDIHAJANCO = null;
			this.LLJBDFLBMGM = false;
			IEGGCALIHIJ = null;
		}
	}

	public class IAMJAHDKBDF
	{
		public PCBHIGOMCDE MMMENNAAGAA;

		public string LJJGMJNNJKN;

		public Color? FNGFGDIHCFN;

		public string EHFAPDPNCFN;

		public Color? JAPMCJJENGJ;

		public float KDLBMNHMFDO;

		public Action PNBEFDMJOHC;

		public HDFLABKGILA GGFHBGJAJFB;

		public object JEOBJPNNFMP;

		public DLIIJAEEFFH GNECDPFEOCE;

		public float HBOEBEHGECO;
	}

	private struct NDCIOOCADKK
	{
		public string LJJGMJNNJKN;

		public string EHFAPDPNCFN;
	}

	public class HDFLABKGILA : IDisposable
	{
		public bool NOAPCNNCLGH;

		public void Dispose()
		{
		}
	}

	private sealed class FADCEBNNHJN
	{
		public MAOKONFJDIM notificationType;

		public Func<MAOKONFJDIM, bool> _003C_003E9__1;

		internal bool _003CShouldShowWatchNotification_003Eb__0(MAOKONFJDIM[] x)
		{
			return false;
		}

		internal bool _003CShouldShowWatchNotification_003Eb__1(MAOKONFJDIM y)
		{
			return false;
		}
	}

	private sealed class MKKPECLJOED : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public PlayerUI playerUI;

		public WatchNotificationDialog dialog;

		public BMLNJJNEOAB notification;

		public Sprite inputButtonIcon;

		public Action onFadeOut;

		private bool _003CwatchOpen_003E5__2;

		private float _003CtimeUntilFadeOutStarts_003E5__3;

		private float _003CtimeUntilFadeOutCompletes_003E5__4;

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
		public MKKPECLJOED(int _003C_003E1__state)
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

	private sealed class MABBJJABGGF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public NotificationManager _003C_003E4__this;

		public MAOKONFJDIM notificationType;

		public NCDNGNOMOFN effectsToPlay;

		public string titleText;

		public string subtitleText;

		public int fromAccountId;

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
		public MABBJJABGGF(int _003C_003E1__state)
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

	private sealed class EEOEJCILGOB : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public NotificationManager _003C_003E4__this;

		public PCBHIGOMCDE style;

		public string titleText;

		public string subtitleText;

		public float duration;

		public Action callback;

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
		public EEOEJCILGOB(int _003C_003E1__state)
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

	private sealed class OFPDKJCIBAN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool animateIn;

		public IBPJIOJOPLF notification;

		public BJLOFJDNOIK higherPriorityNotificationPending;

		public NotificationManager _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private float _003Ctime_003E5__3;

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
		public OFPDKJCIBAN(int _003C_003E1__state)
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

	private sealed class OMFHHNKDMLN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NotificationManager _003C_003E4__this;

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
		public OMFHHNKDMLN(int _003C_003E1__state)
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

	private sealed class DLJOBKLEBPD : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NotificationManager _003C_003E4__this;

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
		public DLJOBKLEBPD(int _003C_003E1__state)
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

	private sealed class AFDLFKKPODA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NotificationManager _003C_003E4__this;

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
		public AFDLFKKPODA(int _003C_003E1__state)
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

	private sealed class NFNEBONKKOD : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NotificationManager _003C_003E4__this;

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
		public NFNEBONKKOD(int _003C_003E1__state)
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

	public const NCDNGNOMOFN WatchNotificationEffectFlags_None = NCDNGNOMOFN.NONE;

	public const NCDNGNOMOFN WatchNotificationEffectFlags_All = NCDNGNOMOFN.ALL;

	public const NCDNGNOMOFN WatchNotificationEffectFlags_AllButText = NCDNGNOMOFN.ALL_BUT_TEXT;

	public static WatchNotificationTypeConfig WatchNotificationTypeConfig;

	private CDAGHEDCBHH HHHFNGPHHMC;

	private List<IAMJAHDKBDF> KPBLFCPEBHE;

	private IAMJAHDKBDF JFPGLJJGKPP;

	private IAMJAHDKBDF KHHIKDCNJAH;

	private IBPJIOJOPLF GGIBBLLMFHD;

	private readonly global::MKJNCDLHHNA<NDCIOOCADKK> IALIFCJKEBJ;

	private readonly HashSet<object> PKBOGCHJFIM;

	private bool OGGBAEHMABJ;

	private IBPJIOJOPLF PIHMEEJMGOM;

	private HLNFDOBEGJO CHABDOLEEMD;

	private readonly global::AFHOAHNAMGF<RecRoomAudioClip> FMILCEOGAHE;

	private BMLNJJNEOAB? FEGOFJCAIDA;

	private LKGILLBEJEK BMIKNMNKJAI;

	private bool FPKLCFHCALL;

	private readonly Dictionary<int, MAOKONFJDIM[]> PKKIPIBMAJB;

	private readonly FIHGBEHGLGB AEDEOKFOONA;

	private readonly global::AFHOAHNAMGF<PCBHIGOMCDE> BOCEDLOFHCI;

	private float MMOOBOKMLNL;

	private float GHJIPFINCCJ;

public CDAGHEDCBHH ScreenSpaceNotificationConfig
{
get 	{
		return null;
	}

set {
	}
}

public bool ShouldShowWatchNotifications
{
get 	{
		return false;
	}

}

public bool WatchNotificationDisplayed
{
get 	{
		return false;
	}

}

public PCBHIGOMCDE NotificationImportanceThreshold
{
get 	{
		return PCBHIGOMCDE.Minor;
	}

}

public bool Paused
{
get 	{
		return false;
	}

}

public bool IsPlaying
{
get 	{
		return false;
	}

}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void SuppressWatchNotificationTypes(int HNHCDMKMKPN, params MAOKONFJDIM[] PPCFAEOFIAD)
	{
	}

	public void ClearSuppressedWatchNotificationTypes(int HNHCDMKMKPN)
	{
	}

	public void DisplayWatchNotificationDialog(BMLNJJNEOAB PBOPFHHBNPO, WatchNotificationDialog GDMKJGAKCND, Sprite CKGFAEHILNB)
	{
	}

	private bool FIAMILFGIPF(PlayerUI JABLCIGJBJL, MAOKONFJDIM OFOMIMPGNJN)
	{
		return false;
	}

	private void CJGLGHFBNMC(PlayerUI JABLCIGJBJL, BMLNJJNEOAB PBOPFHHBNPO, WatchNotificationDialog GDMKJGAKCND, Sprite CKGFAEHILNB)
	{
	}

	private void CMJGEABCEPN()
	{
	}

	private void ALPBJPODEJO(WatchNotificationDialog GDMKJGAKCND)
	{
	}

	private static IEnumerator<EGGPGCCKPCO> PBBKBAPDNAC(PlayerUI JABLCIGJBJL, BMLNJJNEOAB PBOPFHHBNPO, WatchNotificationDialog GDMKJGAKCND, Sprite CKGFAEHILNB, Action KPNMELIEDAC)
	{
		return null;
	}

	public bool TryConsumeWatchNotification(out BMLNJJNEOAB PBOPFHHBNPO)
	{
		PBOPFHHBNPO = default;
		return false;
	}

	public void PlayWatchNotification(bool BCGLNNFGJLD, MAOKONFJDIM OFOMIMPGNJN, NCDNGNOMOFN NLGFPNJNOLJ = NCDNGNOMOFN.ALL, string GFFOMHMCDGE = null, string KOKLOFKIPJE = null, int BFCFNCMBICC = -1, Action IKCHEKPJENN = null, string BBPCIBGIHMD = null, bool LLJBDFLBMGM = true)
	{
	}

	public void PlayWatchNotificationDelayed(float FHFDDKOBFLG, MAOKONFJDIM OFOMIMPGNJN, NCDNGNOMOFN NLGFPNJNOLJ, string BOGCJKAMALE = null, string PCFACAKIICE = null, int BFCFNCMBICC = -1)
	{
	}

	private IEnumerator EPMJGILCJEO(float FHFDDKOBFLG, MAOKONFJDIM OFOMIMPGNJN, NCDNGNOMOFN NLGFPNJNOLJ, string BOGCJKAMALE, string PCFACAKIICE, int BFCFNCMBICC)
	{
		return null;
	}

	public void AddWatchNotificationRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveWatchNotificationRestriction(object IALNODEHBNN)
	{
	}

	public void ForceStopNotification(WatchNotificationDialog GDMKJGAKCND)
	{
	}

	public void AddNotificationDialogImportanceThreshold(object IALNODEHBNN, PCBHIGOMCDE MMPIJKJMPLD)
	{
	}

	public void RemoveNotificationDialogImportanceThreshold(object IALNODEHBNN)
	{
	}

	private void LLPOLBHGEJO()
	{
	}

	public void AddScreenSpaceNotificationAudio(RecRoomAudioClip MKJLHAMMENF, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveScreenSpaceNotificationAudio(object IALNODEHBNN)
	{
	}

	public IDisposable Play(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, float FGBPJMKCMAO, Action ONAFALABHKI = null, object FBKGABBEDDH = null)
	{
		return null;
	}

	public IDisposable Play(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, Color CMFLEKHFOPD, float FGBPJMKCMAO, Action ONAFALABHKI = null)
	{
		return null;
	}

	public IDisposable Play(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, string PCFACAKIICE, float FGBPJMKCMAO, Action ONAFALABHKI = null, object FBKGABBEDDH = null)
	{
		return null;
	}

	public IDisposable Play(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, Color CMFLEKHFOPD, string PCFACAKIICE, float FGBPJMKCMAO, Action ONAFALABHKI = null)
	{
		return null;
	}

	public IDisposable Play(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, string PCFACAKIICE, Color AHMECDBHPKK, float FGBPJMKCMAO, Action ONAFALABHKI = null)
	{
		return null;
	}

	public IDisposable Play(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, float FGBPJMKCMAO, float LAGADKBKLAD)
	{
		return null;
	}

	public IDisposable Play(PCBHIGOMCDE IECPKMLJDCJ, float OJFELHKMIKO, DLIIJAEEFFH LBDIMKLCAFH, string BOGCJKAMALE, Color? CMFLEKHFOPD, string PCFACAKIICE, Color? AHMECDBHPKK, float FGBPJMKCMAO, Action ONAFALABHKI = null, object FBKGABBEDDH = null)
	{
		return null;
	}

	public void PlayDelayed(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, float FGBPJMKCMAO, float FHFDDKOBFLG, Action ONAFALABHKI = null)
	{
	}

	public void PlayDelayed(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, string PCFACAKIICE, float FGBPJMKCMAO, float FHFDDKOBFLG, Action ONAFALABHKI = null)
	{
	}

	public void PlayRoomChatPreferred(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, float FGBPJMKCMAO = 3f, Action ONAFALABHKI = null, object FBKGABBEDDH = null, Player EKOFNPFCLMO = null)
	{
	}

	public void PlayVirtualWatchNotification(DMAIEODHOGA OFCFPGACNJB)
	{
	}

	public void ClearNonPersistentNotifications()
	{
	}

	public void AddPersistentNotification(string BOGCJKAMALE, object IALNODEHBNN)
	{
	}

	public void AddPersistentNotification(string BOGCJKAMALE, string PCFACAKIICE, object IALNODEHBNN, bool IGAJELLEPCP = false)
	{
	}

	public void RemovePersistentNotification(object IALNODEHBNN)
	{
	}

	public void ClearPersistentNotifications(Player MHCOBIPKGNI)
	{
	}

	public void UpdatePersistentNotificationTitle(string OFMGPNLDCAB, object IALNODEHBNN)
	{
	}

	public void UpdatePersistentNotificationSubtitle(string OEEBIOPLOMG, object IALNODEHBNN)
	{
	}

	private IEnumerator HOGMDBCJKGK(PCBHIGOMCDE IECPKMLJDCJ, string BOGCJKAMALE, string PCFACAKIICE, float FGBPJMKCMAO, float FHFDDKOBFLG, Action ONAFALABHKI)
	{
		return null;
	}

	private bool DGIMHGOHMFI(float LAGADKBKLAD)
	{
		return false;
	}

	private IEnumerator KPGGEBEPOPB(IBPJIOJOPLF PBOPFHHBNPO, BJLOFJDNOIK NGHPHBONKIK, bool JLDKFHLAAFB)
	{
		return null;
	}

	private IBPJIOJOPLF LDJNLAOPBAM(PCBHIGOMCDE NIFOGEBEDNG)
	{
		return null;
	}

	public static float GetDefaultPriorityForType(PCBHIGOMCDE NIFOGEBEDNG)
	{
		return 0f;
	}

	public static float SuggestDisplayTimeForMessageInSeconds(string OFCFPGACNJB)
	{
		return 0f;
	}

	private DLIIJAEEFFH OPAEFAAFPGJ(PCBHIGOMCDE NIFOGEBEDNG)
	{
		return DLIIJAEEFFH.Opportunistic;
	}

	private IEnumerator CELDFEJIBFF()
	{
		return null;
	}

	private bool NOOEMCCABBL()
	{
		return false;
	}

	private bool PIEDBEFJAEO()
	{
		return false;
	}

	private bool NKIEEBKCFPC()
	{
		return false;
	}

	private IAMJAHDKBDF CPIMGNHLJNN()
	{
		return null;
	}

	private void NFGKKOFMKHM()
	{
	}

	private IEnumerator OLAFLPKMDDL()
	{
		return null;
	}

	private IEnumerator HHKGLFIANID()
	{
		return null;
	}

	private bool DFPFJJLPEBB()
	{
		return false;
	}

	private IAMJAHDKBDF OKPIGAMDEKP()
	{
		return null;
	}

	private IEnumerator KHJBLILFOAJ()
	{
		return null;
	}

	private bool IDLPLEGPMNG()
	{
		return false;
	}

	[CompilerGenerated]
	private bool LFPKCBADPOB()
	{
		return false;
	}

	[CompilerGenerated]
	private bool MMIIICHLNOD()
	{
		return false;
	}
}
