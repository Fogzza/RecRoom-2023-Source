using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace AGUI.StackedUI
{
	public class PeopleWatchUIFlow : WatchUIFlow
	{
		[Serializable]
		private class StringData
		{
			public LocalizedString noOneHereString;

			public LocalizedString noSearchResultsString;

			public LocalizedString importFriendsString;

			public LocalizedString loadingString;
		}

		private sealed class CDJKGFJBPFJ
		{
			public IEnumerable<DFDECAEJBIO> partyMemberAccounts;

			internal void _003CGetPartyMemberAccounts_003Eb__0(List<DFDECAEJBIO> accounts)
			{
			}

			internal void _003CGetPartyMemberAccounts_003Eb__1(string error)
			{
			}
		}

		private sealed class JLPHGMJAMKG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PeopleWatchUIFlow _003C_003E4__this;

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
			public JLPHGMJAMKG(int _003C_003E1__state)
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

		private sealed class NJPOAEGFHCP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PeopleWatchUIFlow _003C_003E4__this;

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
			public NJPOAEGFHCP(int _003C_003E1__state)
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

		private sealed class HNOPOGPKHKA
		{
			public BulkAccountSelectionDialog.AMDIPFKFHCC inviteToPartyDialogSettings;

			public PeopleWatchUIFlow _003C_003E4__this;

			internal global::NCOKFFGPIJM<BulkAccountSelectionDialog.GGLKDINOLHA> _003CButton_InviteToParty_003Eb__0(BulkAccountSelectionDialog dialog)
			{
				return null;
			}

			internal void _003CButton_InviteToParty_003Eb__1(BulkAccountSelectionDialog.GGLKDINOLHA r)
			{
			}
		}

		private const string NKCBNDDNJGF = "Friends.PostGamePromptUnderFriendCount";

		private const int DNIMFLMKNKJ = 5;

		private const float LPKOEINADFM = 30f;

		private const float PIFGIILOINJ = 600f;

		[SerializeField]
		private PeopleScreenPagedGrid pagedGrid;

		[SerializeField]
		private TextMeshProUGUI noResultsText;

		[SerializeField]
		private AccountSpecificUIBehaviour.PlayerDisplayMode defaultDisplayMode;

		[SerializeField]
		private RadioButton3D friendsRadioButton;

		[SerializeField]
		private RadioButton3D partyRadioButton;

		[SerializeField]
		private RadioButton3D recentPlayersRadioButton;

		[SerializeField]
		private RadioButton3D FindRadioButton;

		[SerializeField]
		private RadioButton3D suggestedFriendsRadioButton;

		[SerializeField]
		private GameObject partyButtonsRow;

		[SerializeField]
		private Button3D leavePartyButton;

		[SerializeField]
		private GameObject notInPartyDisplay;

		[SerializeField]
		private GameObject partyIsEmptyDisplay;

		[SerializeField]
		private BulkAccountSelectionDialog inviteToPartyDialogPrefab;

		[SerializeField]
		private GameObject filterRow;

		[SerializeField]
		private ToggleButton3D recentPlayersToggleButton;

		[SerializeField]
		private ToggleButton3D nearbyPlayersToggleButton;

		private bool AJFHBKOHEIN;

		private bool MCAMCDMLHBG;

		[SerializeField]
		private GameObject importFriendsGroup;

		[SerializeField]
		private TextMeshProUGUI importFriendsText;

		[SerializeField]
		private GameObject searchRow;

		[SerializeField]
		private ValidatedButtonInputField searchField;

		[SerializeField]
		private float minSearchTime;

		public Action FindFriendsAction;

		[SerializeField]
		private int defaultGridSize;

		[SerializeField]
		private int searchGridSize;

		[SerializeField]
		private int largeGridSize;

		[SerializeField]
		private int largeSearchGridSize;

		private IILDCCEMGBA LCPOIILBNLD;

		public LCEKCFEIEGJ TargetRoom;

		private IEnumerable<DFDECAEJBIO> NDGINFFPPHK;

		private string JDPGCELOKNO;

		private float PFPGCOJNDPC;

		private bool KNPGJLJBGLH;

		private bool MAAFHEJFEDA;

		private LKGILLBEJEK NHNMKKKIEAJ;

		private LKGILLBEJEK DIPCCBBCKMK;

		private int? HEJCAPMHKIL;

		private AccountSpecificUIBehaviour.PlayerDisplayMode GJMHPEFEHAC;

		[SerializeField]
		private StringData Strings;

protected override string CIKPANGLFGP
{
get 		{
			return null;
		}

}

private int GEKNFDNKABD
{
get 		{
			return 0;
		}

}

public AccountSpecificUIBehaviour.PlayerDisplayMode PeopleDisplayMode
{
get 		{
			return AccountSpecificUIBehaviour.PlayerDisplayMode.None;
		}

set {
		}
}

private bool KOCGJNNCOCO
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		private void OnEnable()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		protected override void KMCIKAHLOHC(OMNLIPPAPDI CAPKFCHDLFA, bool IHLDMKBBMHJ)
		{
		}

		private void BDAGMPAOHJB(bool OPKEFNEECKK = false, bool EPJFLLDJBJN = false)
		{
		}

		private void MFHEEHJHGNK(OMNLIPPAPDI CAPKFCHDLFA, bool JGGOPMDFPOE)
		{
		}

		private void JHMCPBKGAFC()
		{
		}

		private void KCDPAONFOBA(AccountSpecificUIBehaviour.PlayerDisplayMode AIDOCIKAKCJ)
		{
		}

		private IEnumerable<DFDECAEJBIO> HPPKIDAGKOK()
		{
			return null;
		}

		private IEnumerable<DFDECAEJBIO> AIMJBLEKAHM()
		{
			return null;
		}

		private IEnumerable<int> GOKCJCHGJIH()
		{
			return null;
		}

		private IEnumerable<DFDECAEJBIO> MGMCCAFNINH()
		{
			return null;
		}

		private IEnumerable<DFDECAEJBIO> PCHDKIMOMEO(bool AJFHBKOHEIN, bool MCAMCDMLHBG)
		{
			return null;
		}

		private List<DFDECAEJBIO> MGHMEHGBDLK(IEnumerable<DFDECAEJBIO> AGIGKKMBEKN)
		{
			return null;
		}

		private static int BFLFOPMNCHM(DFDECAEJBIO ACBGBAAHOIM)
		{
			return 0;
		}

		private void KKKMGDLECEH()
		{
		}

		private void AOBOPJDHIMC()
		{
		}

		private IEnumerator<EGGPGCCKPCO> BMGLALKMAKJ()
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> BDABELLJCCC()
		{
			return null;
		}

		private void JGKLHFJNABM(string JDPGCELOKNO)
		{
		}

		public void Button_ImportFriends()
		{
		}

		public void Button_GenerateFriendCode()
		{
		}

		public void Button_ShowDetails(DFDECAEJBIO account)
		{
		}

		public void Button_SetRecentDisplayMode()
		{
		}

		public void Button_ShowSubscriptions()
		{
		}

		public void Button_SetFriendsDisplayMode()
		{
		}

		public void Button_SetPartyDisplayMode()
		{
		}

		public void Button_SetFindDisplayMode()
		{
		}

		public void Button_SetClubDisplayMode()
		{
		}

		public void Button_SetPendingFriendsDisplayMode()
		{
		}

		public void Button_FindPlatformFriends()
		{
		}

		public void Button_ToggleRecentPlayers()
		{
		}

		public void Button_ToggleNearbyPlayers()
		{
		}

		public void Button_Search()
		{
		}

		public void Button_InviteToParty()
		{
		}

		private void NKGFHIHABOA(IReadOnlyList<DFDECAEJBIO> AGIGKKMBEKN)
		{
		}

		public void Button_LeaveParty()
		{
		}

		public override void Button_ExitFlow()
		{
		}

		protected override bool HELGFGMCPMI()
		{
			return false;
		}

		private void OKPLCFDCMAK()
		{
		}

		private void OCOINNPPELC(int? PCKCPNGPNBJ)
		{
		}

		private void DKFIOOOOMME(Player PILIBFHFNHM)
		{
		}

		private void NDOCBKKMPFB()
		{
		}

		private void HBNBBEMDJDI(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		[CompilerGenerated]
		private bool PLIHBPPBODI(string ADGIOFAMOGF)
		{
			return false;
		}

		[CompilerGenerated]
		private void KJHGPFGMDJL()
		{
		}

		[CompilerGenerated]
		private void CFILMNBHAIE()
		{
		}

		[CompilerGenerated]
		private void MODBLDLCFNM(List<JJGPKBPPDHH> MKACDMNEGNA)
		{
		}

		[CompilerGenerated]
		private void DBAAEDJBBIM(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void ONLGCDMMEJL(List<DFDECAEJBIO> AGIGKKMBEKN)
		{
		}

		[CompilerGenerated]
		private void GPFOOCJJIJG()
		{
		}
	}
}
