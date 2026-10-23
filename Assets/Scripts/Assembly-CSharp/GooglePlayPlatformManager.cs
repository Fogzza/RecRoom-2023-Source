using System.Collections.Generic;

public class GooglePlayPlatformManager : PlatformManager
{
	private const float NJMDFOLODAN = 60f;

	private const float KHKNEIGCGEM = 30f;

	private const string FKJNECKPMJA = "MicrophonePermDontAskAgain";

	private const string AKOCMMPKDJM = "ContactPermDontAskAgain";

	private EFGIDDLNECL ALCHBCLKCII;

	private string HECBNAFMCMN;

	private float LKHAPIENNPA;

	private DBIPHDIEBCM GIAJBMMABNN;

	private const int DPBPNKMKLLO = 2500;

	private const float KEDKKFCMJGB = 7f;

	private const string NGABOGLBGGE = "android.permission.READ_CONTACTS";

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

public override bool IsLowMemoryDevice
{
get 	{
		return false;
	}

}

public override bool IsPCPlatform
{
get 	{
		return false;
	}

}

public override bool IsFileSystemUserAccessible
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

public override float TargetFramerate
{
get 	{
		return 0f;
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

public override bool SupportsPortraitMode
{
get 	{
		return false;
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

public override bool HasPlatformImages
{
get 	{
		return false;
	}

}

public override bool RequestReviewSupported
{
get 	{
		return false;
	}

}

public override bool SupportsContactsPermission
{
get 	{
		return false;
	}

}

public override bool SupportsInvitingPlatformFriendsOrContacts
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

	protected override void Start()
	{
	}

	public override LAHBDKNMNHN Initialize()
	{
		return null;
	}

	private LAHBDKNMNHN CFFKIOCBGME()
	{
		return null;
	}

	public override LAHBDKNMNHN PostLoginInitialize()
	{
		return null;
	}

	protected override void OnApplicationPause(bool NFHCNHMLNJG)
	{
	}

	public override void SetRichPresenceStatus(string ALLOPBKEIAJ)
	{
	}

	public override global::NCOKFFGPIJM<string> GetAuthParams()
	{
		return null;
	}

	public override bool SupportsLinkToDownloadUpdate()
	{
		return false;
	}

	public override void LinkToDownloadUpdate()
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

	public override void DisplaySystemReviewUI()
	{
	}

	public override global::NCOKFFGPIJM<List<POPLPJGHHIA.KAEKKCCLKLH>> ApplySkuMetadataOverrides(List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN)
	{
		return null;
	}

	public override global::NCOKFFGPIJM<string> GetCommerceAccessToken()
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

	private void PNAKCCKOIHG()
	{
	}

	public override global::NCOKFFGPIJM<List<string>> GetContactListEmails()
	{
		return null;
	}

	public override global::NCOKFFGPIJM<List<string>> GetContactListPhones()
	{
		return null;
	}

	public override bool CanAskForContactsPermission()
	{
		return false;
	}

	public override bool HasContactsPermission()
	{
		return false;
	}

	public override LAHBDKNMNHN SendTextMessageFriendCodeInvite(string MMLMMHEMGFP, string FBHLPHOGLIL)
	{
		return null;
	}

	protected override CILEIOOHEOB DFMBLLKNLEL()
	{
		return CILEIOOHEOB.Desktop_Valve;
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

	private static string JDGBDKDDCFA(string JGDAPHKEGIG)
	{
		return null;
	}

	private static int? ECNCLBKMMAK(string ABIBIKMBNMG)
	{
		return null;
	}
}
