using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Steamworks;

public sealed class SteamPlatformManager : PlatformManager
{
	private class JIKNIHDEBGD
	{
		public byte[] JBMKKNPCCPL;

		public int ODCOGNPDKPM;

		public string LEFPGJEKFGF;
	}

	private sealed class PFCAALBEINF
	{
		public LKGILLBEJEK timeout;

		public byte[] ticket;

		public uint ticketSize;

		internal void _003CGetAuthSessionTicket_003Eb__1()
		{
		}

		internal global::NCOKFFGPIJM<JIKNIHDEBGD> _003CGetAuthSessionTicket_003Eb__2(GetAuthSessionTicketResponse_t response)
		{
			return null;
		}
	}

	private sealed class NHFMJPPFGFE
	{
		public SteamPlatformManager _003C_003E4__this;

		public long transactionId;

		internal void _003CAuthorizePurchase_003Eb__0()
		{
		}
	}

	private sealed class HJBPFJBIAON
	{
		public SteamPlatformManager _003C_003E4__this;

		public DBIPHDIEBCM promise;

		public int counter;

		public IDisposable token;

		internal void _003CGetOrCreatePurchasePromise_003Eb__0(float deltaTime)
		{
		}

		internal void _003CGetOrCreatePurchasePromise_003Eb__1()
		{
		}
	}

	private const float NILNINGLACF = 90f;

	private const float HOANFJKIPDF = 60f;

	public const uint RECROOM_APP_ID = 471710u;

	private bool HOCFFNMCCJJ;

	private bool GMOAILKCEKK;

	private global::PHLHFLLLDLK<GetAuthSessionTicketResponse_t> NDBIFMCEBEC;

	private Callback<GetAuthSessionTicketResponse_t> IPGKKNFCDNC;

	private Callback<GameRichPresenceJoinRequested_t> OELNJCBCPCF;

	private Callback<MicroTxnAuthorizationResponse_t> HIEMHMJGGEI;

	private Callback<GameOverlayActivated_t> DIBHHLKNNHE;

	private Dictionary<long, DBIPHDIEBCM> IGDNBCELOHE;

public override EAFLPCNDJNK CurrentPlatform
{
get 	{
		return EAFLPCNDJNK.Steam;
	}

}

public override float TargetFramerate
{
get 	{
		return 0f;
	}

}

public override bool SupportsNewRenderer
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

public override bool IsPCPlatform
{
get 	{
		return false;
	}

}

protected override int IHLGNFBNFFA
{
get 	{
		return 0;
	}

}

protected override bool FANJKCPFGLN
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

public override bool HasVRFocus
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

public override bool IsFileSystemUserAccessible
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

public override bool SupportsInvitingPlatformFriendsOrContacts
{
get 	{
		return false;
	}

}

	protected override void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private bool CJCDBIJJBBN()
	{
		return false;
	}

	public override LAHBDKNMNHN Initialize()
	{
		return null;
	}

	public override LAHBDKNMNHN PostLoginInitialize()
	{
		return null;
	}

	public GDHOAGNFOBD.KEIAPDLHGPG LoadAvatarForPlayer(CSteamID BLIEGOEMBFI, string LBAJNKDCIPL)
	{
		return null;
	}

	public override void SetRichPresenceStatus(string ALLOPBKEIAJ)
	{
	}

	private void LJNKNCKOCMN(GameRichPresenceJoinRequested_t AKPPKIEAJHD)
	{
	}

	private void CMLPPKDDLCJ(GameOverlayActivated_t AKPPKIEAJHD)
	{
	}

	private void OLFGAIFDEML(bool LJNKJMLFBJF)
	{
	}

	private void HFCANKCHEIC()
	{
	}

	public override global::NCOKFFGPIJM<string> GetAuthParams()
	{
		return null;
	}

	private global::NCOKFFGPIJM<JIKNIHDEBGD> IODJMOABKEN()
	{
		return null;
	}

	private void FPIOJDEGMNN(GetAuthSessionTicketResponse_t MLDANHIGANI)
	{
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

	public override global::NCOKFFGPIJM<string> GetCommerceAccessToken()
	{
		return null;
	}

	public override LAHBDKNMNHN AuthorizePurchase(long APMEBBJFJIJ, POPLPJGHHIA.KAEKKCCLKLH EEFFOCCPECD)
	{
		return null;
	}

	private DBIPHDIEBCM DKAGGGJIGEE(long APMEBBJFJIJ)
	{
		return null;
	}

	private void PLLNFBEOKBK(long APMEBBJFJIJ)
	{
	}

	private void NNFKJDIGLAO(MicroTxnAuthorizationResponse_t AKPPKIEAJHD)
	{
	}

	protected override CILEIOOHEOB DFMBLLKNLEL()
	{
		return CILEIOOHEOB.Desktop_Valve;
	}

	public static bool IsUsingIndexController(VRTrackedController.EGONEFPMCNI BNNHCJJILFB)
	{
		return false;
	}

	public static bool TryGetSteamVRDeviceIndex(VRTrackedController.EGONEFPMCNI BNNHCJJILFB, out uint GMEHLIHLGEH)
	{
		GMEHLIHLGEH = default;
		return false;
	}

	public override global::NCOKFFGPIJM<bool> SendPlatformGameInvite(string PCOPJCDDHIO)
	{
		return null;
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

	public override List<BHKFKPHPOEE> PlatformFriendsOrContactsDetailsTransformFunc(List<BHKFKPHPOEE> JDBHABEFGKF)
	{
		return null;
	}

	public override FNIIKBEFEDO GetFriendOnlineStatus(string OBCFBKKCBFH)
	{
		return FNIIKBEFEDO.Online;
	}

	[CompilerGenerated]
	private void DBGPMLMBFKF()
	{
	}
}
