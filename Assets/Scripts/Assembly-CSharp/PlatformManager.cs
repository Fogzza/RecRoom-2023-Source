using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;

public abstract class PlatformManager : SingletonMonoBehaviour<PlatformManager>, MCCKDPKLCIN, NOJDOPMIBGK, PAJFMLEBPDP, MFENCGHNPBJ, BAKFGPOAGJH
{
	public enum EGHPOOCGFOA
	{
		ALLOWED = 0,
		BLOCKED = 1
	}

	public enum AAPIIKNIDIC
	{
		Newcomer = 1,
		Explorer = 2,
		RecRoomerI = 3,
		RecRoomerII = 4,
		PartyAnimal = 5,
		Cheerleader = 6,
		Friendo = 7,
		Fashionista = 8,
		CreatorI = 9,
		CreatorII = 10
	}

	public enum BMNBAINOBHA
	{
		None = 0,
		Muted = 1,
		Blocked = 2
	}

	public struct GBJOGCFCGPL
	{
		public EGHPOOCGFOA AOHKGCAEOEB;

		public EGHPOOCGFOA HGJCAMNKOLB;

		public EGHPOOCGFOA JIGGCPBAFAH;
	}

	public class CLOICBFMBND
	{
		public bool HELMJMKMDOD;

		public string NDICDDPCEJN;

		public string MHFDMDDMKNF;
	}

	private class HLPLHDPLFMJ : MFENCGHNPBJ
	{
		[Preserve]
		public HLPLHDPLFMJ()
		{
		}

		public bool TryGetMemoryStats(out JGGOBFIOPEP IHJPCNNDPGN)
		{
			IHJPCNNDPGN = default;
			return false;
		}
	}

	private sealed class JIIPDOIFHGL
	{
		public ulong currentCacheSize;

		internal object _003CRunPeriodicHTTPCacheMaintenance_003Eb__0()
		{
			return null;
		}
	}

	private sealed class MACBGEGJPMF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlatformManager _003C_003E4__this;

		public DBIPHDIEBCM promise;

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
		public MACBGEGJPMF(int _003C_003E1__state)
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

	private sealed class LEKGENPNLIB
	{
		public bool waitForWatchClosed;

		internal bool _003CWaitUntilWatchReadyCoroutine_003Eb__0()
		{
			return false;
		}
	}

	private sealed class ILOCGGEOEHG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public bool waitForWatchClosed;

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
		public ILOCGGEOEHG(int _003C_003E1__state)
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

	private sealed class PEHOLBFJNBD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

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
		public PEHOLBFJNBD(int _003C_003E1__state)
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

	private sealed class MGIIJBAMDAH
	{
		public List<string> platformFriendIds;

		public PlatformManager _003C_003E4__this;

		internal List<string> _003CGetPlatformFriendIdsOfNonRecRoomPlayers_003Eb__1(List<JJGPKBPPDHH> rrPlayers)
		{
			return null;
		}
	}

	private sealed class AKODIGBPLNL
	{
		public IEnumerable<string> rrPlayerPlatformIds;

		public MGIIJBAMDAH CS_0024_003C_003E8__locals1;

		internal bool _003CGetPlatformFriendIdsOfNonRecRoomPlayers_003Eb__3(string id)
		{
			return false;
		}
	}

	private sealed class DLLLFGJNKAL
	{
		public string platformIdOrPhone;

		public PlatformManager _003C_003E4__this;

		internal BHKFKPHPOEE _003CGetPlatformFriendOrContactDetails_003Eb__0(string name)
		{
			return null;
		}
	}

	private static Action<PlatformManager, BHNJIBDJFAL> APPMOJJIFGL__BackingField;

	private static Action<PlatformManager> PHEHKBGIOME__BackingField;

	protected PDKMOBAFOAA? FHKJJCCOOLE;

	private Action JIMCKEBJNAB__BackingField;

	private string KGONPFFEKHD;

	private string ODHIFIHNBHM;

	private byte[] GAIMLKPLFHD;

	private string KKGEGPHEDCA;

	private CILEIOOHEOB BAHELMOBOFO;

	private RegionInfo ICPOFICKPLP;

	private KDHPMLNMNNO? IOCEDCBBAPF;

	private bool GHNDGLLBJJE;

	private bool FEMLCPCPOFA;

	private Action<bool> AJABMEODJCN__BackingField;

	private Action<bool> ACCKDIBKNAM__BackingField;

	private bool PAEPAOPGFLM;

	private GBJOGCFCGPL EDMBBAJGKAK;

	private const ulong AIDOPCHMBLA = 524288000uL;

	private HJDBOADFHMC HAPHJLEINOM;

	private const int IAIKKCBPHPL = 5000000;

	private const int EHMICHADPBP = 2500000;

	private const int KDPOACKECMO = 1250000;

	private JNKNMMDAHCF DHCLACKALOF;

	private BHNJIBDJFAL FFPLKJLJJGB;

	private IILDCCEMGBA OBDKAJOFODI;

	private LKFJJHJMFIB ADGPGMPOPNJ;

	private FCAFJHGMACK EMBGONOIIBO;

	private JIEEEFENLJF FOJDCMKMBIM;

	private BAKFGPOAGJH BKLIALOKJIL;

	private IDisposable HDOELCCGLJC;

	private Coroutine MJAFBIFFANF;

	private const string AJDIJIOHDLB = "+launcher:";

	private const string BDENHCNFEFO = "mobilehome";

	public const int LOWEST_SUPPORTED_PHYSICS_UPDATE_RATE = 30;

	public const int MAX_SUPPORTED_FIXED_UPDATE_CALLS = 2;

	private const float CDAOOPJDBBP = 60f;

	private JFMOJNIDLNH EEPNAGBEJEE;

	protected static readonly global::PKDAONKKDNF<string> ILHCMADELKI;

	private List<string> IKDNKMBAKAI;

public abstract float TargetFramerate
{
get ;
}

public virtual bool SupportsNewRenderer
{
get 	{
		return false;
	}

}

protected abstract int NGKJJJANMME
{
get ;
}

protected abstract int IHLGNFBNFFA
{
get ;
}

public string PlatformProfileId
{
get 	{
		return null;
	}

set {
	}
}

public string PlatformProfileName
{
get 	{
		return null;
	}

set {
	}
}

public byte[] PlatformProfileImage
{
get 	{
		return null;
	}

set {
	}
}

public string PlatformName
{
get 	{
		return null;
	}

}

public CILEIOOHEOB CurrentHardwareType
{
get 	{
		return CILEIOOHEOB.Desktop_Valve;
	}

set {
	}
}

public RegionInfo CurrentRegionInfo
{
get 	{
		return null;
	}

set {
	}
}

public KDHPMLNMNNO CurrentUnityLauncher
{
get 	{
		return KDHPMLNMNNO.Default;
	}

}

public bool IsVRMode
{
get 	{
		return false;
	}

}

public virtual bool HasSmallPhysicalScreen
{
get 	{
		return false;
	}

}

public virtual bool HasHardwareKeyboard
{
get 	{
		return false;
	}

}

public virtual bool IsFileSystemUserAccessible
{
get 	{
		return false;
	}

}

public virtual bool SupportsPortraitMode
{
get 	{
		return false;
	}

}

public HGMGOPODGJN DefaultLayout
{
get 	{
		return HGMGOPODGJN.Landscape;
	}

}

public bool SupportsHardwareBackButton
{
get 	{
		return false;
	}

}

public virtual bool SupportsToxMod
{
get 	{
		return false;
	}

}

public virtual bool IsMetaHardwareForJuniorRestrictions
{
get 	{
		return false;
	}

}

public bool IsFocusedInteractionTarget
{
get 	{
		return false;
	}

set {
	}
}

public bool IsSystemUIOverlaid
{
get 	{
		return false;
	}

set {
	}
}

public bool IsPlatformManagerInitialized
{
get 	{
		return false;
	}

}

public virtual bool SupportsARFeatures
{
get 	{
		return false;
	}

}

public bool UseReducedPhysicsRate
{
get 	{
		return false;
	}

private set {
	}
}

public GBJOGCFCGPL CurrentPlatformRestrictions
{
get 	{
		return default;
	}

set {
	}
}

public virtual bool SupportsPlatformRestrictions
{
get 	{
		return false;
	}

}

public bool ChatAllowed
{
get 	{
		return false;
	}

}

public string ExecutablePath
{
get 	{
		return null;
	}

}

public virtual bool SupportsPlatformProfileImage
{
get 	{
		return false;
	}

}

public virtual bool SupportsLogout
{
get 	{
		return false;
	}

}

public virtual bool SupportsParallelInitialization
{
get 	{
		return false;
	}

}

public bool SupportsRecRoomStudioLocalDevelopment
{
get 	{
		return false;
	}

}

protected virtual bool FANJKCPFGLN
{
get 	{
		return false;
	}

}

protected virtual bool FDIOAONOEGD
{
get 	{
		return false;
	}

}

protected JNKNMMDAHCF BLCBBOHOOGI
{
get 	{
		return null;
	}

}

protected BHNJIBDJFAL PGHHCPJJBHA
{
get 	{
		return null;
	}

private set {
	}
}

protected IILDCCEMGBA JAGJNNFIEIH
{
get 	{
		return null;
	}

private set {
	}
}

public abstract EAFLPCNDJNK CurrentPlatform
{
get ;
}

public virtual string HardwareTypeString
{
get 	{
		return null;
	}

}

public virtual HBEFBLGGFMC RecNetDeviceClass
{
get 	{
		return HBEFBLGGFMC.Unknown;
	}

}

public abstract bool IsPCPlatform
{
get ;
}

public virtual bool IsLowMemoryDevice
{
get 	{
		return false;
	}

}

public abstract bool HasClientSidePurchaseFlow
{
get ;
}

public abstract bool SupportsSubscriptions
{
get ;
}

public abstract bool HasServerSideSubscriptionCancellation
{
get ;
}

public abstract bool HasSubscriptionManagementUI
{
get ;
}

public abstract bool SupportsRestoringPurchases
{
get ;
}

public abstract bool ShouldTryGetSubscriptionWithoutAccessToken
{
get ;
}

public virtual bool SupportsPurchasing
{
get 	{
		return false;
	}

}

public virtual bool ShouldRefreshAccessTokenBeforeCommerceCalls
{
get 	{
		return false;
	}

}

public virtual bool RequiresPlatformLoginScreen
{
get 	{
		return false;
	}

}

public virtual bool RequiresLoginBeforeInternet
{
get 	{
		return false;
	}

}

public virtual bool ShowPlatformSpecificDisplayName
{
get 	{
		return false;
	}

}

public virtual GHCCKFEJDOA? ForcedQualitySetting
{
get 	{
		return null;
	}

}

public bool CurrentPlatformIsOculusType
{
get 	{
		return false;
	}

}

public string CurrentPlatformAsAnalyticsString
{
get 	{
		return null;
	}

}

public abstract bool HasVRFocus
{
get ;
}

protected JFMOJNIDLNH AGBPOGNJAKP
{
get 	{
		return null;
	}

}

public bool CanDenyMicrophonePermissions
{
get 	{
		return false;
	}

}

protected virtual bool IOBGBLCMANG
{
get 	{
		return false;
	}

}

public bool HasMicrophonePermissions
{
get 	{
		return false;
	}

}

protected virtual bool CJKFKKMFDOO
{
get 	{
		return false;
	}

}

public bool CanRequestMicrophonePermissions
{
get 	{
		return false;
	}

}

protected virtual bool IAMHADIGNEF
{
get 	{
		return false;
	}

}

public bool CanOpenMicrophonePermissionsSettings
{
get 	{
		return false;
	}

}

protected virtual bool ANMHDGMAKDL
{
get 	{
		return false;
	}

}

public virtual bool HasPlatformImages
{
get 	{
		return false;
	}

}

protected abstract GADOFHMIGOB GFGOLEPCGKC
{
get ;
}

public virtual string PlatformNetworkName
{
get 	{
		return null;
	}

}

public virtual string PlatformIdName
{
get 	{
		return null;
	}

}

public virtual bool ShouldShowPlatformLogoButton
{
get 	{
		return false;
	}

}

public virtual bool SupportsContactsPermission
{
get 	{
		return false;
	}

}

public virtual bool ShouldSendPlatformGameInvites
{
get 	{
		return false;
	}

}

public virtual bool RequestReviewSupported
{
get 	{
		return false;
	}

}

public virtual bool SupportsInvitingPlatformFriendsOrContacts
{
get 	{
		return false;
	}

}

 HBEFBLGGFMC global::PAJFMLEBPDP.LJFAPIGEOOJ
{
get 	{
		return HBEFBLGGFMC.Unknown;
	}

}

 EAFLPCNDJNK global::PAJFMLEBPDP.KAAIIIEPCIA
{
get 	{
		return EAFLPCNDJNK.Steam;
	}

}

 string global::PAJFMLEBPDP.KNPINBELAPP
{
get 	{
		return null;
	}

}

 byte global::PAJFMLEBPDP.OHIFNEKCMHC
{
get 	{
		return 0;
	}

}

 int global::PAJFMLEBPDP.OLINKLPFIAF
{
get 	{
		return 0;
	}

}

 bool global::PAJFMLEBPDP.NGBNIAENMNJ
{
get 	{
		return false;
	}

}

 bool global::PAJFMLEBPDP.FCMOKPGLLGD
{
get 	{
		return false;
	}

}

 bool global::PAJFMLEBPDP.CHEOGJCNNIA
{
get 	{
		return false;
	}

}

 bool global::PAJFMLEBPDP.ShouldTryGetSubscriptionWithoutAccessToken
{
get 	{
		return false;
	}

}

public virtual bool SupportsNativeSharing
{
get 	{
		return false;
	}

}

public static event Action<PlatformManager, BHNJIBDJFAL> OnPlatformManagerCreated {
add {
	}
remove {
	}
}

public static event Action<PlatformManager> OnPlatformManagerDestroyed {
add {
	}
remove {
	}
}

public event Action CurrentHardwareTypeChanged {
add {
	}
remove {
	}
}

public event Action<bool> IsFocusedInteractionTargetChanged {
add {
	}
remove {
	}
}

public event Action<bool> IsSystemUIOverlaidChanged {
add {
	}
remove {
	}
}

	public virtual global::NCOKFFGPIJM<DateTime?> GetPlatformProfileDateOfBirth()
	{
		return null;
	}

	public void SetInnerFocusProvider(BAKFGPOAGJH EMADDEGJKAF)
	{
	}

	protected virtual void GAEAJMMJNDD(bool DLEMNBPMGBG)
	{
	}

	protected virtual void ENKOHJIEDNC(bool DLEMNBPMGBG)
	{
	}

	public virtual bool IsForcedIsolationByPlatformSettings(out string MEIBABHIOLG)
	{
		MEIBABHIOLG = null;
		return false;
	}

	public virtual bool IsValidAdvertisingId(string IKHNIJKGJFD)
	{
		return false;
	}

	protected virtual bool JKLKPNJMCJN(bool CDNDNECCHGF)
	{
		return false;
	}

	protected override void Awake()
	{
	}

	private void CIKBMHBHGNK()
	{
	}

	private void KKFEDCCKKOC()
	{
	}

	private void IPINEEDCEOM()
	{
	}

	protected virtual void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void UpdateCurrentHardwareType()
	{
	}

	private LAHBDKNMNHN BFGABDJMJKO()
	{
		return null;
	}

	private IEnumerator HEDLMGGCPEG(DBIPHDIEBCM BOJDPAGLBLI)
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<BMNBAINOBHA> IsPlayerCommunicationRestricted(int EJIHLJJMOBD)
	{
		return null;
	}

	protected virtual RegionInfo CFEMEEEPKCO()
	{
		return null;
	}

	protected virtual KDHPMLNMNNO LJBGCKGAEOO()
	{
		return KDHPMLNMNNO.Default;
	}

	protected PDKMOBAFOAA DDHCEIJDFCI()
	{
		return default;
	}

	public static IEnumerator<EGGPGCCKPCO> WaitUntilWatchReadyCoroutine(bool NCHEOADEEJP = true)
	{
		return null;
	}

	protected static HBEFBLGGFMC HMKEHNKMANO()
	{
		return HBEFBLGGFMC.Unknown;
	}

	public virtual void ShowSystemEmptyStoreDialog()
	{
	}

	public static string GamePlatformAsAnalyticsString(EAFLPCNDJNK GEAFKINFDLB, CILEIOOHEOB? DGOOEGDMPLP)
	{
		return null;
	}

	public abstract LAHBDKNMNHN Initialize();

	public abstract LAHBDKNMNHN PostLoginInitialize();

	public virtual LAHBDKNMNHN PreInitialize()
	{
		return null;
	}

	protected void FGAIEOJLOEG()
	{
	}

	public bool IsSiloedMatchmakingEnabled()
	{
		return false;
	}

	public bool RequestSiloedMatchmaking()
	{
		return false;
	}

	public bool RequestCrossPlatformMatchmaking()
	{
		return false;
	}

	public virtual bool IsEULARequired()
	{
		return false;
	}

	public virtual string GetEULA()
	{
		return null;
	}

	public virtual void AcceptEULA()
	{
	}

	public virtual void AcceptCrossPlatformWarning()
	{
	}

	public virtual bool IsDisplayModeSelectionRequired()
	{
		return false;
	}

	public virtual global::NCOKFFGPIJM<MJLJBHNFNAP> RunDisplayModeSelection()
	{
		return null;
	}

	public virtual LAHBDKNMNHN RunVRDisplayModeConfirmation()
	{
		return null;
	}

	public virtual bool IsCrossPlatformWarningRequired()
	{
		return false;
	}

	private void KGMFCODNAHF()
	{
	}

	protected virtual void OnApplicationFocus(bool DPOALIELOMI)
	{
	}

	protected virtual void OnApplicationPause(bool NFHCNHMLNJG)
	{
	}

	protected virtual void ADOFNHCLKDD()
	{
	}

	public LAHBDKNMNHN RequestMicrophonePermissions()
	{
		return null;
	}

	protected virtual global::NCOKFFGPIJM<bool> MMFJCOHJPPD()
	{
		return null;
	}

	public LAHBDKNMNHN OpenMicrophonePermissionsSettings()
	{
		return null;
	}

	protected virtual LAHBDKNMNHN DGGLLELEIII()
	{
		return null;
	}

	public virtual LAHBDKNMNHN PlatformLogin()
	{
		return null;
	}

	public virtual bool SupportsLinkToDownloadUpdate()
	{
		return false;
	}

	public virtual void LinkToDownloadUpdate()
	{
	}

	public abstract void SetRichPresenceStatus(string ALLOPBKEIAJ);

	public virtual global::NCOKFFGPIJM<string> GetAuthParams()
	{
		return null;
	}

	public virtual int GetTouchScreenKeyboardHeight()
	{
		return 0;
	}

	public abstract global::NCOKFFGPIJM<List<string>> GetPlatformFriendIds();

	public abstract global::NCOKFFGPIJM<string> GetPlatformFriendName(string OBCFBKKCBFH);

	public abstract GDHOAGNFOBD.KEIAPDLHGPG GetPlatformFriendPicture(string OBCFBKKCBFH);

	public virtual global::NCOKFFGPIJM<List<POPLPJGHHIA.KAEKKCCLKLH>> GetAllSkusWithOverrides()
	{
		return null;
	}

	public abstract global::NCOKFFGPIJM<List<POPLPJGHHIA.KAEKKCCLKLH>> ApplySkuMetadataOverrides(List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN);

	public abstract global::NCOKFFGPIJM<string> GetCommerceAccessToken();

	public virtual global::NCOKFFGPIJM<string> GetCommerceSubscriptionAccessToken()
	{
		return null;
	}

	public abstract LAHBDKNMNHN AuthorizePurchase(long APMEBBJFJIJ, POPLPJGHHIA.KAEKKCCLKLH EEFFOCCPECD);

	public virtual global::NCOKFFGPIJM<CLOICBFMBND> Purchase(POPLPJGHHIA.KAEKKCCLKLH EEFFOCCPECD, int? FIFINGMBONG)
	{
		return null;
	}

	public virtual LAHBDKNMNHN RestorePurchases()
	{
		return null;
	}

	public virtual LAHBDKNMNHN ShowManageSubscriptionPlatformUI()
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<string> TransformErrorMessage(string FJHECPJPHOJ)
	{
		return null;
	}

	public virtual IEnumerator<EGGPGCCKPCO> ShowPlatformRestrictionMessagesCoroutine()
	{
		return null;
	}

	protected abstract CILEIOOHEOB DFMBLLKNLEL();

	public string SanitizeName(string KNOPFGAGMCN)
	{
		return null;
	}

	public virtual string MakeNameAdhereToPlatformRequirements(string KNOPFGAGMCN, bool IKCLLIPIHHH = true)
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<string> MakeRoomNameAdhereToPlatformRequirements(long EPOBIFCHLNM, string LBGBFPDNKOL)
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<string> GetPlatformDisplayNameFromId(string OBOBJIEALAL)
	{
		return null;
	}

	public virtual LAHBDKNMNHN ShowPlatformAccountUIForPlatformId(string OBOBJIEALAL)
	{
		return null;
	}

	public virtual bool CanAskForContactsPermission()
	{
		return false;
	}

	public virtual bool HasContactsPermission()
	{
		return false;
	}

	public virtual void OpenAppSettingsPage()
	{
	}

	public virtual LAHBDKNMNHN RequestContactsPermission()
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<List<string>> GetContactListEmails()
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<List<string>> GetContactListPhones()
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<string> GetNameFromEmail(string JJDOGJNEIHG)
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<string> GetNameFromPhone(string MMLMMHEMGFP)
	{
		return null;
	}

	public virtual void TrySendPlatformGameInvite(int DDMKPBDHODM)
	{
	}

	public virtual global::NCOKFFGPIJM<bool> SendPlatformGameInvite(string PCOPJCDDHIO)
	{
		return null;
	}

	public virtual int SystemMemorySizeMB()
	{
		return 0;
	}

	public virtual bool TryGetMemoryStats(out JGGOBFIOPEP IHJPCNNDPGN)
	{
		IHJPCNNDPGN = default;
		return false;
	}

	public virtual float GetCurrentProcessTimeSinceBoot()
	{
		return 0f;
	}

	public virtual void CompleteAchievement(AAPIIKNIDIC GNCDKMJDOLI)
	{
	}

	public virtual void DisplaySystemReviewUI()
	{
	}

	public virtual LAHBDKNMNHN SendTextMessageFriendCodeInvite(string MMLMMHEMGFP, string FBHLPHOGLIL)
	{
		return null;
	}

	public global::NCOKFFGPIJM<List<string>> GetPlatformFriendIdsOfNonRecRoomPlayers()
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<List<string>> GetCommaSeparatedPhonesOfNonRecRoomPlayers()
	{
		return null;
	}

	public virtual List<BHKFKPHPOEE> PlatformFriendsOrContactsDetailsTransformFunc(List<BHKFKPHPOEE> JDBHABEFGKF)
	{
		return null;
	}

	public global::NCOKFFGPIJM<List<BHKFKPHPOEE>> GetPlatformFriendsOrContactsDetails(List<string> KGIJDGDOPCD)
	{
		return null;
	}

	public virtual global::NCOKFFGPIJM<BHKFKPHPOEE> GetPlatformFriendOrContactDetails(string CLMKHKHBGBB)
	{
		return null;
	}

	public virtual FNIIKBEFEDO GetFriendOnlineStatus(string OBCFBKKCBFH)
	{
		return FNIIKBEFEDO.Online;
	}

	[IOFOCEAPGPD(NPBJMIOJGOK.None)]
	private static void DGCAPHHIHLM(MNALHHOLFGL FMPHDMAKDKP)
	{
	    FMPHDMAKDKP.IFIGMJHIABP<MFENCGHNPBJ>().CLBIACAHFKJ<HLPLHDPLFMJ>();
	}

	private global::NCOKFFGPIJM<string> JEGBHHGBDLJ()
	{
		return null;
	}

	global::NCOKFFGPIJM<string> PAJFMLEBPDP.GNLNKGIDGCG()
	{
		//ILSpy generated this explicit interface implementation from .override directive in JEGBHHGBDLJ
		return this.JEGBHHGBDLJ();
	}

	private global::NCOKFFGPIJM<bool> KDCCELLBENK(int AFBGIPGHBMO)
	{
		return null;
	}

	global::NCOKFFGPIJM<bool> PAJFMLEBPDP.IsPlayerCommunicationRestricted(int AFBGIPGHBMO)
	{
		//ILSpy generated this explicit interface implementation from .override directive in KDCCELLBENK
		return this.KDCCELLBENK(AFBGIPGHBMO);
	}

	private string BIBMGCBGFML(string KNOPFGAGMCN, bool IKCLLIPIHHH)
	{
		return null;
	}

	string PAJFMLEBPDP.NAFCNPEDAFM(string KNOPFGAGMCN, bool IKCLLIPIHHH)
	{
		//ILSpy generated this explicit interface implementation from .override directive in BIBMGCBGFML
		return this.BIBMGCBGFML(KNOPFGAGMCN, IKCLLIPIHHH);
	}

	private global::NCOKFFGPIJM<string> HFPEIMBEIAB(long EPOBIFCHLNM, string KNOPFGAGMCN)
	{
		return null;
	}

	global::NCOKFFGPIJM<string> PAJFMLEBPDP.MakeRoomNameAdhereToPlatformRequirements(long EPOBIFCHLNM, string KNOPFGAGMCN)
	{
		//ILSpy generated this explicit interface implementation from .override directive in HFPEIMBEIAB
		return this.HFPEIMBEIAB(EPOBIFCHLNM, KNOPFGAGMCN);
	}

	private global::NCOKFFGPIJM<string> ODHDAJCIHGB()
	{
		return null;
	}

	global::NCOKFFGPIJM<string> PAJFMLEBPDP.GetCommerceSubscriptionAccessToken()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ODHDAJCIHGB
		return this.ODHDAJCIHGB();
	}

	public virtual void OpenNativeSharingPrompt(Enum AKKAOAJPGOL, string FDAIMOMOHIG, string PEDLJMJDBPA, string HLIGBKANEEA, Texture2D IECDHEIBMJN, bool GHEDOPCIOHD)
	{
	}

	protected void BNCPNCKDPFL()
	{
	}

	[CompilerGenerated]
	private LAHBDKNMNHN ECEPKLOPGAJ(bool GBMLDABCLOD)
	{
		return null;
	}

	[CompilerGenerated]
	private global::NCOKFFGPIJM<List<POPLPJGHHIA.KAEKKCCLKLH>> KDPBCDIHEMD(List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN)
	{
		return null;
	}

	[CompilerGenerated]
	private global::NCOKFFGPIJM<List<string>> LJGAAGJMENO(List<string> JECFPGLILKM)
	{
		return null;
	}
}
