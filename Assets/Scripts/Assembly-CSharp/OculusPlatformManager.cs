using System;
using System.Collections.Generic;

public class OculusPlatformManager : PlatformManager
{
	[Serializable]
	private class GraphApiMeResponse
	{
		public ulong id;
	}

	private const float KKELGNNFFFG = 72f;

	private const float PIMOIBBMFFA = 90f;

	private const float OKFHONJPDKD = 60f;

	private static Dictionary<CILEIOOHEOB, List<string>> EMBCJILEPOB;

	private string AFDBNPPBPGF;

	private string ONJHEDOLCKD;

	private string HCMAACDPMGP;

	private IILDCCEMGBA PFGCMJCEEMA;

public string AppID
{
get 	{
		return null;
	}

set {
	}
}

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

public override bool IsFileSystemUserAccessible
{
get 	{
		return false;
	}

}

public override float TargetFramerate
{
get 	{
		return 0f;
	}

}

public override bool IsMetaHardwareForJuniorRestrictions
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

public override bool IsPCPlatform
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

public override bool HasHardwareKeyboard
{
get 	{
		return false;
	}

}

public override bool SupportsLogout
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

protected override GADOFHMIGOB GFGOLEPCGKC
{
get 	{
		return GADOFHMIGOB.WindowsDesktop;
	}

}

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	protected override void OnDestroy()
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

	public override void SetRichPresenceStatus(string ALLOPBKEIAJ)
	{
	}

	public override global::NCOKFFGPIJM<List<string>> GetPlatformFriendIds()
	{
		return null;
	}

	protected override global::NCOKFFGPIJM<bool> MMFJCOHJPPD()
	{
		return null;
	}

	public override global::NCOKFFGPIJM<string> GetAuthParams()
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
}
