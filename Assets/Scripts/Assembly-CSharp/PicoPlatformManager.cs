using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class PicoPlatformManager : PlatformManager
{
	private sealed class NNLDCJMKILF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DBIPHDIEBCM platformInitPromise;

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
		public NNLDCJMKILF(int _003C_003E1__state)
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

	public Action OnUpdate;

	private string FIHIAKBBMLP;

public override EAFLPCNDJNK CurrentPlatform
{
get 	{
		return EAFLPCNDJNK.Steam;
	}

}

public override string HardwareTypeString
{
get 	{
		return null;
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

public override bool SupportsRestoringPurchases
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

public override bool HasSubscriptionManagementUI
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

public override bool ShouldTryGetSubscriptionWithoutAccessToken
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

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	protected void Update()
	{
	}

	public override global::NCOKFFGPIJM<string> GetAuthParams()
	{
		return null;
	}

	public override LAHBDKNMNHN Initialize()
	{
		return null;
	}

	private LAHBDKNMNHN DCCKEIHKLFN()
	{
		return null;
	}

	private IEnumerator IGIGBNBHEAC(DBIPHDIEBCM OHAPKDFNPFK)
	{
		return null;
	}

	private LAHBDKNMNHN CBGJOGEAKAO()
	{
		return null;
	}

	private LAHBDKNMNHN JIJECPKNNDC()
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

	public override global::NCOKFFGPIJM<CLOICBFMBND> Purchase(POPLPJGHHIA.KAEKKCCLKLH EEFFOCCPECD, int? FIFINGMBONG)
	{
		return null;
	}

	private void PNAKCCKOIHG()
	{
	}

	private static string JDGBDKDDCFA(string JGDAPHKEGIG)
	{
		return null;
	}

	private static int? ECNCLBKMMAK(string ABIBIKMBNMG)
	{
		return null;
	}

	protected override global::NCOKFFGPIJM<bool> MMFJCOHJPPD()
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
