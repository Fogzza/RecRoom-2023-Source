using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Platforms.Xbox
{
	public class XboxPlatformManager : PlatformManager
	{
		private const float INAIABFMIEM = 60f;

		private bool JEBFCMJPBDL;

		[SerializeField]
		private string controllerLostTitle;

		[SerializeField]
		private string controllerLostMessage;

public override EAFLPCNDJNK CurrentPlatform
{
get 		{
			return EAFLPCNDJNK.Steam;
		}

}

public override float TargetFramerate
{
get 		{
			return 0f;
		}

}

public override bool IsPCPlatform
{
get 		{
			return false;
		}

}

protected override int NGKJJJANMME
{
get 		{
			return 0;
		}

}

protected override int IHLGNFBNFFA
{
get 		{
			return 0;
		}

}

public override bool HasClientSidePurchaseFlow
{
get 		{
			return false;
		}

}

public override bool SupportsSubscriptions
{
get 		{
			return false;
		}

}

public override bool HasSubscriptionManagementUI
{
get 		{
			return false;
		}

}

public override bool HasServerSideSubscriptionCancellation
{
get 		{
			return false;
		}

}

public override bool SupportsRestoringPurchases
{
get 		{
			return false;
		}

}

public override bool ShouldTryGetSubscriptionWithoutAccessToken
{
get 		{
			return false;
		}

}

public override bool RequiresPlatformLoginScreen
{
get 		{
			return false;
		}

}

public override bool RequiresLoginBeforeInternet
{
get 		{
			return false;
		}

}

public override bool HasVRFocus
{
get 		{
			return false;
		}

}

protected override GADOFHMIGOB GFGOLEPCGKC
{
get 		{
			return GADOFHMIGOB.WindowsDesktop;
		}

}

public override bool ShowPlatformSpecificDisplayName
{
get 		{
			return false;
		}

}

public override string PlatformNetworkName
{
get 		{
			return null;
		}

}

public override string PlatformIdName
{
get 		{
			return null;
		}

}

public override bool ShouldShowPlatformLogoButton
{
get 		{
			return false;
		}

}

public override bool SupportsPlatformRestrictions
{
get 		{
			return false;
		}

}

public override GHCCKFEJDOA? ForcedQualitySetting
{
get 		{
			return null;
		}

}

public ulong ActiveUserId
{
get 		{
			return 0uL;
		}

}

public override bool SupportsParallelInitialization
{
get 		{
			return false;
		}

}

protected override bool FDIOAONOEGD
{
get 		{
			return false;
		}

}

		protected override CILEIOOHEOB DFMBLLKNLEL()
		{
			return CILEIOOHEOB.Desktop_Valve;
		}

		public override bool IsForcedIsolationByPlatformSettings(out string MEIBABHIOLG)
		{
			MEIBABHIOLG = null;
			return false;
		}

		public override bool IsCrossPlatformWarningRequired()
		{
			return false;
		}

		public override void AcceptCrossPlatformWarning()
		{
		}

		public override void SetRichPresenceStatus(string ALLOPBKEIAJ)
		{
		}

		public override LAHBDKNMNHN AuthorizePurchase(long APMEBBJFJIJ, POPLPJGHHIA.KAEKKCCLKLH EEFFOCCPECD)
		{
			return null;
		}

		public override LAHBDKNMNHN Initialize()
		{
			return null;
		}

		public override global::NCOKFFGPIJM<string> GetCommerceAccessToken()
		{
			return null;
		}

		public override global::NCOKFFGPIJM<List<POPLPJGHHIA.KAEKKCCLKLH>> ApplySkuMetadataOverrides(List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN)
		{
			return null;
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

		public override LAHBDKNMNHN PostLoginInitialize()
		{
			return null;
		}
	}
}
