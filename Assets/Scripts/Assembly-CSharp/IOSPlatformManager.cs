using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using SA.Foundation.Templates;
using SA.iOS.Social;
using SA.iOS.StoreKit;
using UnityEngine;

public class IOSPlatformManager : PlatformManager
{
	private enum NGIAAFLJBDB
	{
		Microphone = 0,
		Notifications = 1,
		Webcam = 2,
		Contacts = 3
	}

	public class OKJEFNHCGOK : ISN_iSKPaymentTransactionObserver
	{
		private sealed class HFBNDFKFKJP
		{
			public ISN_iSKPaymentTransaction transaction;

			public Action _003C_003E9__4;

			public Action<string> _003C_003E9__5;

			public Action<string> _003C_003E9__3;

			internal LAHBDKNMNHN _003CFinishPurchasedTransaction_003Eb__0(ISN_SKAppStoreReceipt appStoreReceipt)
			{
				return null;
			}

			internal void _003CFinishPurchasedTransaction_003Eb__4()
			{
			}

			internal void _003CFinishPurchasedTransaction_003Eb__5(string error)
			{
			}

			internal void _003CFinishPurchasedTransaction_003Eb__3(string error)
			{
			}

			internal void _003CFinishPurchasedTransaction_003Eb__1(string error)
			{
			}
		}

		private sealed class LKFLBIGIPHJ
		{
			public ISN_SKAppStoreReceipt appStoreReceipt;

			public HFBNDFKFKJP CS_0024_003C_003E8__locals1;

			internal LAHBDKNMNHN _003CFinishPurchasedTransaction_003Eb__2(string token)
			{
				return null;
			}
		}

		private sealed class AJBGPMJHDOL
		{
			public OKJEFNHCGOK _003C_003E4__this;

			public ISN_iSKPaymentTransaction transaction;

			internal LAHBDKNMNHN _003COnTransactionUpdated_003Eg__HandleTransactionUpdated_007C0()
			{
				return null;
			}

			internal void _003COnTransactionUpdated_003Eb__1()
			{
			}

			internal void _003COnTransactionUpdated_003Eb__2(string recNetCommerceError)
			{
			}
		}

		private Action<ISN_iSKPaymentTransaction, string> PHNBMMELPJE__BackingField;

		private Action<SA_Result> HHBLONGLMED__BackingField;

public event Action<ISN_iSKPaymentTransaction, string> PHNBMMELPJE {
add {
		}
remove {
		}
}

public event Action<SA_Result> HHBLONGLMED {
add {
		}
remove {
		}
}

		private LAHBDKNMNHN JCMMFHAJIDG(ISN_iSKPaymentTransaction HIOJOLIPFKD)
		{
			return null;
		}

		public void OnTransactionUpdated(ISN_iSKPaymentTransaction HIOJOLIPFKD)
		{
		}

		public void OnTransactionRemoved(ISN_iSKPaymentTransaction CDNLFEOBNKB)
		{
		}

		public bool OnShouldAddStorePayment(ISN_SKProduct CDNLFEOBNKB)
		{
			return false;
		}

		public void OnRestoreTransactionsComplete(SA_Result CDNLFEOBNKB)
		{
		}

		private void EDFDOOHJGHM(string OFCFPGACNJB)
		{
		}

		public void DidChangeStorefront()
		{
		}
	}

	private sealed class KOGOKFIFEAE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
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
		public KOGOKFIFEAE(int _003C_003E1__state)
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

	private sealed class DHCCIMJFFEN
	{
		public string legacyPlatformId;

		public string newPlatformId;

		internal void _003CPostLoginInitialize_003Eb__1(string error)
		{
		}

		internal void _003CPostLoginInitialize_003Eb__2()
		{
		}
	}

	private sealed class JFDNCGLFFIE
	{
		public POPLPJGHHIA.KAEKKCCLKLH sku;

		internal bool _003CApplySkuMetadataOverridesInternal_003Eb__3(ISN_SKProduct p)
		{
			return false;
		}
	}

	private sealed class BKDPOAECPKN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public global::PHLHFLLLDLK<List<POPLPJGHHIA.KAEKKCCLKLH>> completePromise;

		public List<POPLPJGHHIA.KAEKKCCLKLH> skus;

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
		public BKDPOAECPKN(int _003C_003E1__state)
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

	private sealed class MKCHBOMJDIC
	{
		public bool refresh;

		internal global::NCOKFFGPIJM<ISN_SKAppStoreReceipt> _003CGetCurrentAppStoreReceipt_003Eb__0()
		{
			return null;
		}
	}

	private sealed class NADNCHIPIOD
	{
		public global::PHLHFLLLDLK<ISN_SKAppStoreReceipt> promise;

		internal void _003CGetCurrentAppStoreReceipt_003Eb__1(SA_Result result)
		{
		}
	}

	private sealed class ABNEJIBBJIM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
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
		public ABNEJIBBJIM(int _003C_003E1__state)
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

	private sealed class GEOGJJPJGAA
	{
		public POPLPJGHHIA.KAEKKCCLKLH sku;

		public global::PHLHFLLLDLK<CLOICBFMBND> promise;

		public IOSPlatformManager _003C_003E4__this;

		internal void _003CPurchase_003Eg__HandleTransactionComplete_007C0(ISN_iSKPaymentTransaction transaction, string recNetCommerceError)
		{
		}
	}

	private sealed class NDMLGKJGFNI
	{
		public DBIPHDIEBCM promise;

		public IOSPlatformManager _003C_003E4__this;

		internal void _003CRestorePurchases_003Eg__HandleTransactionUpdated_007C0(ISN_iSKPaymentTransaction transaction, string recNetCommerceError)
		{
		}

		internal void _003CRestorePurchases_003Eg__HandleRestoreTransactionsComplete_007C1(SA_Result result)
		{
		}
	}

	private sealed class JMFIANICLEG
	{
		public AsyncOperation async;

		internal bool _003CMicrophonePermissionsRequestCoroutine_003Eb__0()
		{
			return false;
		}
	}

	private sealed class NAAJHEIGALM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public global::PHLHFLLLDLK<bool> promise;

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
		public NAAJHEIGALM(int _003C_003E1__state)
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

	private sealed class EJHMPEDLAAG
	{
		public AsyncOperation async;

		internal bool _003CWebcamPermissionsRequestCoroutine_003Eb__0()
		{
			return false;
		}
	}

	private sealed class GDFIHJECIFC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public DBIPHDIEBCM promise;

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
		public GDFIHJECIFC(int _003C_003E1__state)
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

	private sealed class GMHAKCNNDDK
	{
		public Texture2D image;

		public bool diposeImage;

		public Enum linkType;

		public string url;

		public string key;

		internal void _003COpenNativeSharingPrompt_003Eb__0(ISN_UIActivityViewControllerResult result)
		{
		}
	}

	public const string APPLE_APPID = "1450306065";

	private const float NJMDFOLODAN = 60f;

	private const float KHKNEIGCGEM = 30f;

	[Obsolete]
	private const string PNNMIBFIMBL = "IOSISH";

	private const string PLEOKIOFFBE = "IOSPPID";

	private const string AMFIIIHMHPF = "IOSPPID_MGRTD";

	private const string IGKJFCMMIEL = "IOS_CPR";

	private const float KEDKKFCMJGB = 7f;

	private const int NKJFIKHCLAD = 1024;

	private const int GHEPLIJABHP = 1900;

	private const int DPOFNPANCJP = 2500;

	private OKJEFNHCGOK JCODOMKBPHG;

	private EFGIDDLNECL ALCHBCLKCII;

	private NDGFGGOEPCG BOBLLCJCCBD;

	private JKHCJAJHGAO MNDFDFPLEDB;

	private const string EEGDINJKJAK = "PermissionReminderDay";

	private const string GHJGHFIMALD = "IsPermissionRequested";

	private const string DLHDKCGJFFE = "OptOutOfPermissionReminder";

	private const float HIMMOIKNAMK = 0.07f;

	private float GIBPHJLAOEC;

	private float MANANGJGCBL;

	private static IOSPlatformManager CJGLPIFHGPF;

	private static readonly Action<double> BAOBBDOBKML;

public override EAFLPCNDJNK CurrentPlatform
{
get 	{
		return EAFLPCNDJNK.Steam;
	}

}

public override HBEFBLGGFMC RecNetDeviceClass
{
get 	{
		return HBEFBLGGFMC.Unknown;
	}

}

public override float TargetFramerate
{
get 	{
		return 0f;
	}

}

public override bool IsPCPlatform
{
get 	{
		return false;
	}

}

protected override int NGKJJJANMME
{
get 	{
		return 0;
	}

}

protected override int IHLGNFBNFFA
{
get 	{
		return 0;
	}

}

public override bool SupportsPlatformProfileImage
{
get 	{
		return false;
	}

}

public override bool HasClientSidePurchaseFlow
{
get 	{
		return false;
	}

}

public override bool SupportsSubscriptions
{
get 	{
		return false;
	}

}

public override bool HasServerSideSubscriptionCancellation
{
get 	{
		return false;
	}

}

public override bool HasSubscriptionManagementUI
{
get 	{
		return false;
	}

}

public override bool SupportsRestoringPurchases
{
get 	{
		return false;
	}

}

public override bool ShouldTryGetSubscriptionWithoutAccessToken
{
get 	{
		return false;
	}

}

public override bool IsLowMemoryDevice
{
get 	{
		return false;
	}

}

public override GHCCKFEJDOA? ForcedQualitySetting
{
get 	{
		return null;
	}

}

public override bool HasVRFocus
{
get 	{
		return false;
	}

}

public override bool HasSmallPhysicalScreen
{
get 	{
		return false;
	}

}

public override bool SupportsARFeatures
{
get 	{
		return false;
	}

}

public override bool HasHardwareKeyboard
{
get 	{
		return false;
	}

}

public override bool SupportsPortraitMode
{
get 	{
		return false;
	}

}

public override bool HasPlatformImages
{
get 	{
		return false;
	}

}

protected override GADOFHMIGOB GFGOLEPCGKC
{
get 	{
		return GADOFHMIGOB.WindowsDesktop;
	}

}

private static bool NCOOMFIOLDK
{
get 	{
		return false;
	}

}

private static bool HCDMFCJNBGI
{
get 	{
		return false;
	}

set {
	}
}

public override bool RequestReviewSupported
{
get 	{
		return false;
	}

}

protected override bool IOBGBLCMANG
{
get 	{
		return false;
	}

}

protected override bool CJKFKKMFDOO
{
get 	{
		return false;
	}

}

protected override bool IAMHADIGNEF
{
get 	{
		return false;
	}

}

protected override bool ANMHDGMAKDL
{
get 	{
		return false;
	}

}

public static bool HasWebcamPermission
{
get 	{
		return false;
	}

}

public override bool SupportsNativeSharing
{
get 	{
		return false;
	}

}

	private static bool JHGCOKNBMMD()
	{
		return false;
	}

	public override bool SupportsLinkToDownloadUpdate()
	{
		return false;
	}

	public override void LinkToDownloadUpdate()
	{
	}

	protected override void Start()
	{
	}

	protected override void OnApplicationFocus(bool DPOALIELOMI)
	{
	}

	protected override RegionInfo CFEMEEEPKCO()
	{
		return null;
	}

	private static IEnumerator<EGGPGCCKPCO> KGDMAGLPDIK()
	{
		return null;
	}

	private static void KNPNAGOFOEJ(string NLJOHEKGNDH)
	{
	}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void HADBNNANGFK()
	{
	}

	private void NMJKIJBBDKO(Player EKOFNPFCLMO)
	{
	}

	private void PHLIKDFBFCI(bool DODFDBIOPIM)
	{
	}

	public override LAHBDKNMNHN Initialize()
	{
		return null;
	}

	public override LAHBDKNMNHN PostLoginInitialize()
	{
		return null;
	}

	private void LNMGJFHJKOC(ISN_SKProductsResponse CDNLFEOBNKB)
	{
	}

	private void GIFJDFMFFNM(GHCCKFEJDOA PKJIEOPNCHK)
	{
	}

	public override void SetRichPresenceStatus(string ALLOPBKEIAJ)
	{
	}

	public override int GetTouchScreenKeyboardHeight()
	{
		return 0;
	}

	public override global::NCOKFFGPIJM<List<string>> GetPlatformFriendIds()
	{
		return null;
	}

	public override global::NCOKFFGPIJM<string> GetPlatformFriendName(string OBCFBKKCBFH)
	{
		return null;
	}

	public override GDHOAGNFOBD.KEIAPDLHGPG GetPlatformFriendPicture(string OBCFBKKCBFH)
	{
		return null;
	}

	public override global::NCOKFFGPIJM<List<POPLPJGHHIA.KAEKKCCLKLH>> ApplySkuMetadataOverrides(List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> KALGADMPKPL(global::PHLHFLLLDLK<List<POPLPJGHHIA.KAEKKCCLKLH>> JFIHJEIMDHP, List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN)
	{
		return null;
	}

	public override global::NCOKFFGPIJM<string> GetCommerceAccessToken()
	{
		return null;
	}

	public override global::NCOKFFGPIJM<string> GetCommerceSubscriptionAccessToken()
	{
		return null;
	}

	private Dictionary<string, object> DACAFBIBMLA()
	{
		return null;
	}

	public global::NCOKFFGPIJM<ISN_SKAppStoreReceipt> GetCurrentAppStoreReceipt(bool JFDHBCBJEEK)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> CJECENNADBE()
	{
		return null;
	}

	public override LAHBDKNMNHN AuthorizePurchase(long APMEBBJFJIJ, POPLPJGHHIA.KAEKKCCLKLH EEFFOCCPECD)
	{
		return null;
	}

	public override global::NCOKFFGPIJM<CLOICBFMBND> Purchase(POPLPJGHHIA.KAEKKCCLKLH EEFFOCCPECD, int? FIFINGMBONG)
	{
		return null;
	}

	public override LAHBDKNMNHN RestorePurchases()
	{
		return null;
	}

	public override LAHBDKNMNHN ShowManageSubscriptionPlatformUI()
	{
		return null;
	}

	protected override CILEIOOHEOB DFMBLLKNLEL()
	{
		return CILEIOOHEOB.Desktop_Valve;
	}

	[Obsolete]
	private static string MDDDJPOOKIC()
	{
		return null;
	}

	private static string HKJEDOEEHEI()
	{
		return null;
	}

	private static string ADMCHPOOANB()
	{
		return null;
	}

	public override void DisplaySystemReviewUI()
	{
	}

	private static bool GBJCIDLNBAO(NGIAAFLJBDB OAHMEFCIJFN)
	{
		return false;
	}

	private static void BHDEKEJAEKI(NGIAAFLJBDB OAHMEFCIJFN)
	{
	}

	private static bool IEJNNBGNJPP(NGIAAFLJBDB OAHMEFCIJFN)
	{
		return false;
	}

	private static void DGOIODPDMHF(NGIAAFLJBDB OAHMEFCIJFN)
	{
	}

	private static void JIEBEOJHNCC(NGIAAFLJBDB OAHMEFCIJFN)
	{
	}

	private static void BPCAJMIIEAC()
	{
	}

	protected override global::NCOKFFGPIJM<bool> MMFJCOHJPPD()
	{
		return null;
	}

	private static IEnumerator<EGGPGCCKPCO> JKLPDJNCFOJ(global::PHLHFLLLDLK<bool> BOJDPAGLBLI)
	{
		return null;
	}

	protected override LAHBDKNMNHN DGGLLELEIII()
	{
		return null;
	}

	public static LAHBDKNMNHN RequestWebcamPermission()
	{
		return null;
	}

	private static IEnumerator<EGGPGCCKPCO> AKIOBJDGKJO(DBIPHDIEBCM BOJDPAGLBLI)
	{
		return null;
	}

	private static void EENOKPDMBIJ()
	{
	}

	public static void OpenAppSettings()
	{
	}

	private static void FOLHFBEDBNO(double LNCNJNEEDGG)
	{
	}

	private void EDHFKBNJIPL(float OKBAJEAPIHG)
	{
	}

	public override int SystemMemorySizeMB()
	{
		return 0;
	}

	public override bool TryGetMemoryStats(out JGGOBFIOPEP IHJPCNNDPGN)
	{
		IHJPCNNDPGN = default;
		return false;
	}

	public override float GetCurrentProcessTimeSinceBoot()
	{
		return 0f;
	}

	public override void OpenNativeSharingPrompt(Enum AKKAOAJPGOL, string FDAIMOMOHIG, string PEDLJMJDBPA, string HLIGBKANEEA, Texture2D IECDHEIBMJN, bool GHEDOPCIOHD)
	{
	}

	private static void MMPCNNJKGDJ(int? FIFINGMBONG, string JGDAPHKEGIG)
	{
	}

	private static int? EOMCDAOCGMF(string JGDAPHKEGIG)
	{
		return null;
	}

	private static void CPMHJHFHOIL(string JGDAPHKEGIG)
	{
	}

	[CompilerGenerated]
	private void CPPGDBJMIGA(ISN_SKProductsResponse CDNLFEOBNKB)
	{
	}

	[CompilerGenerated]
	private string DLHDCAFLACL(ISN_SKAppStoreReceipt OOAJOGNGMEB)
	{
		return null;
	}
}
