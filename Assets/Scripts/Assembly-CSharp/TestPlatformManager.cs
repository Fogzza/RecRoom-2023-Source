using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

internal class TestPlatformManager : PlatformManager
{
	private sealed class JBMGOIPMAIK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TestPlatformManager _003C_003E4__this;

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
		public JBMGOIPMAIK(int _003C_003E1__state)
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

	private int HHMLGOAFINP;

	private bool OPOOHPHHHAA;

	private bool AANOCINNLIP;

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

private bool LPCDGDJDEKI
{
get 	{
		return false;
	}

set {
	}
}

protected override GADOFHMIGOB GFGOLEPCGKC
{
get 	{
		return GADOFHMIGOB.WindowsDesktop;
	}

}

	public override LAHBDKNMNHN PreInitialize()
	{
		return null;
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

	private IEnumerator JBKNMGGEIKG()
	{
		return null;
	}

	private void PEDPBDCLEDH()
	{
	}

	private void JKFAECMPDBF()
	{
	}

	private void OnGUI()
	{
	}
}
