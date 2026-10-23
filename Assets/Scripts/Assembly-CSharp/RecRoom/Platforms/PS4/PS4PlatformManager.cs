using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;

namespace RecRoom.Platforms.PS4
{
	public sealed class PS4PlatformManager : PlatformManager
	{
		private class IJHIKNMCLNL
		{
			public ulong KNPINBELAPP;

			public string ILBOEGJIMLF;

			public string HIJIKKBJJBP;
		}

		private class CNJLLOAHIIL
		{
			public ulong JDONLFOPABP;

			public string CAJPALLIGNB;

			public bool KBBEDFOIPAG;
		}

		private sealed class AHADACPFBJN
		{
			public long roomId;

			public string roomName;

			internal string _003CMakeRoomNameAdhereToPlatformRequirements_003Eb__0(IReadOnlyList<long> rroRoomIds)
			{
				return null;
			}
		}

		private sealed class KILLMCFDMOJ
		{
			public global::PHLHFLLLDLK<string> promise;

			internal void _003CGetPlatformDisplayNameFromId_003Eb__0(string displayName)
			{
			}
		}

		private sealed class JBHNCMDFJGM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public global::PHLHFLLLDLK<MJLJBHNFNAP> promise;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public JBHNCMDFJGM(int _003C_003E1__state)
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

		private const string ICCJGCDCAEG = "<b>This game requires a free Rec Room cloud account. If this is your first time playing, a new account will be created and linked to your account on PlayStation™Network.</";

		private const string ILMLALMDGCI = "2021.12.01";

		private const string FCMLAACLENN = "CUSA08481";

		private const string MIEPOHGLIAK = "CUSA09539";

		private const string GGJBGKAGCMD = "CUSA14469";

		private const string EIGNEFIGJOA = "4749538d-d6f4-4df8-bc32-70ca8b4f2bb7";

		private const string PFOLEBNCEOP = "c14a5475-0c6e-4ef7-80a8-bf41e562aade";

		private const string GKFAHDJHFIE = "Packaging/Config.txt";

		private const float INAIABFMIEM = 60f;

		[SerializeField]
		private TextAsset eulaTextAsset;

		[SerializeField]
		private ToolSkinMapper PlusRewardEquipment;

		[SerializeField]
		private EquipmentSkin PlusRewardEquipmentSkin;

		private Coroutine AEIJLMFHAEK;

		private int CBKMIOADCFB;

		private Dictionary<ulong, IJHIKNMCLNL> PPDBJJGMBNF;

		private Dictionary<ulong, CNJLLOAHIIL> FJIIGLLDMDG;

		private readonly global::PHLHFLLLDLK<DateTime?> ELLOHLFMEGM;

		private ulong EOAPJPGALGO;

		private string JGPFBHBHNHJ;

		private string KNMHNBBGBOK;

		private bool? MOOEKCEBAMH;

		private readonly Regex EPHGKINCNII;

		private readonly Regex KDEPFDJGDHM;

public override EAFLPCNDJNK CurrentPlatform
{
get 		{
			return EAFLPCNDJNK.Steam;
		}

}

private ulong FLOINPNLOON
{
get 		{
			return 0uL;
		}

set {
		}
}

public override bool IsPCPlatform
{
get 		{
			return false;
		}

}

public override float TargetFramerate
{
get 		{
			return 0f;
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

public override bool HasServerSideSubscriptionCancellation
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

public override bool ShouldRefreshAccessTokenBeforeCommerceCalls
{
get 		{
			return false;
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

public override bool HasVRFocus
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

private int POFOGEALIIE
{
get 		{
			return 0;
		}

}

public string TitleId
{
get 		{
			return null;
		}

private set {
		}
}

public string RecNetClientId
{
get 		{
			return null;
		}

private set {
		}
}

public bool? IsPlusMember
{
get 		{
			return null;
		}

private set {
		}
}

protected override GADOFHMIGOB GFGOLEPCGKC
{
get 		{
			return GADOFHMIGOB.WindowsDesktop;
		}

}

		protected override void ADOFNHCLKDD()
		{
		}

		public override global::NCOKFFGPIJM<DateTime?> GetPlatformProfileDateOfBirth()
		{
			return null;
		}

		protected override void ENKOHJIEDNC(bool DLEMNBPMGBG)
		{
		}

		protected override CILEIOOHEOB DFMBLLKNLEL()
		{
			return CILEIOOHEOB.Desktop_Valve;
		}

		public override string MakeNameAdhereToPlatformRequirements(string KNOPFGAGMCN, bool IKCLLIPIHHH = true)
		{
			return null;
		}

		public override global::NCOKFFGPIJM<string> MakeRoomNameAdhereToPlatformRequirements(long EPOBIFCHLNM, string LBGBFPDNKOL)
		{
			return null;
		}

		public override global::NCOKFFGPIJM<string> GetPlatformDisplayNameFromId(string OBOBJIEALAL)
		{
			return null;
		}

		public override bool IsEULARequired()
		{
			return false;
		}

		public override string GetEULA()
		{
			return null;
		}

		public override void AcceptEULA()
		{
		}

		private static string KOFEIMHHICF(TextAsset CPNJJIIOCMD)
		{
			return null;
		}

		public override bool IsDisplayModeSelectionRequired()
		{
			return false;
		}

		public override global::NCOKFFGPIJM<MJLJBHNFNAP> RunDisplayModeSelection()
		{
			return null;
		}

		public override LAHBDKNMNHN RunVRDisplayModeConfirmation()
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> GGCMEKICBJD(global::PHLHFLLLDLK<MJLJBHNFNAP> BOJDPAGLBLI)
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

		public override global::NCOKFFGPIJM<string> GetAuthParams()
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

		public IEnumerator GetOnlineID(ulong EJIHLJJMOBD, Action<string> ONAFALABHKI)
		{
			return null;
		}

		public override float GetCurrentProcessTimeSinceBoot()
		{
			return 0f;
		}
	}
}
