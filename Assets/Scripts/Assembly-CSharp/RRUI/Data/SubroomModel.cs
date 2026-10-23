using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Core.Creation.SceneMoods;
using UnityEngine;

namespace RRUI.Data
{
	public class SubroomModel : RRUIModel
	{
		private sealed class BBGMHDDCKNL
		{
			public PickerDialogModel activeDialog;

			public int selectedIndex;

			public SubroomModel _003C_003E4__this;

			public KPGPFEAGMDE currentLoadRequestPayload;

			public EHEJPNFKNAL selectButton;

			internal void _003CShowSaveVersionDialog_003Eb__4()
			{
			}

			internal void _003CShowSaveVersionDialog_003Eb__5()
			{
			}

			internal bool _003CShowSaveVersionDialog_003Eb__6()
			{
				return false;
			}

			internal void _003CShowSaveVersionDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, RoomSaveCardModel fromModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CShowSaveVersionDialog_003Eb__1()
			{
				return 0;
			}

			internal void _003CShowSaveVersionDialog_003Eb__2(int index)
			{
			}

			internal void _003CShowSaveVersionDialog_003Eb__3(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class FDLIKBECDIP
		{
			public bool redirectToEntrySubroom;

			public SubroomModel _003C_003E4__this;

			internal void _003CTryDeleteSubroom_003Eb__1(LCEKCFEIEGJ roomDetails)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct APONJJOGGCC : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public SubroomModel _003C_003E4__this;

			private TaskAwaiter<LCEKCFEIEGJ> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

			private TaskAwaiter<BCDAPDDMMEO> _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private sealed class PNJGMABPEAC
		{
			public SubroomModel _003C_003E4__this;

			public string operationName;

			internal void _003CTryToggleEntrySubroom_003Eb__0()
			{
			}

			internal void _003CTryToggleEntrySubroom_003Eb__1(string err)
			{
			}
		}

		private sealed class GNHJFGGGMBI
		{
			public PickerDialogModel activeDialog;

			public long selectedRoomId;

			public SubroomModel _003C_003E4__this;

			public List<JCDPHCELKHI> rooms;

			public Predicate<JCDPHCELKHI> _003C_003E9__6;

			internal void _003CShowMoveSubroomPicker_003Eb__4()
			{
			}

			internal void _003CShowMoveSubroomPicker_003Eb__5()
			{
			}

			internal void _003CShowMoveSubroomPicker_003Eb__0(GameObject instance, int index, CardModel cardModel, RoomModel roomModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CShowMoveSubroomPicker_003Eb__1()
			{
				return 0;
			}

			internal bool _003CShowMoveSubroomPicker_003Eb__6(JCDPHCELKHI r)
			{
				return false;
			}

			internal void _003CShowMoveSubroomPicker_003Eb__2(int index)
			{
			}

			internal void _003CShowMoveSubroomPicker_003Eb__3(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class AHABBEOKLJP
		{
			public SubroomModel _003C_003E4__this;

			public long newRoomId;

			public bool movingThisRoom;

			public Func<RRUI.Navigation.Uri, bool> _003C_003E9__5;

			public Action<LCEKCFEIEGJ> _003C_003E9__3;

			public Action<string> _003C_003E9__4;

			internal void _003CTryMoveSubroom_003Eb__2()
			{
			}

			internal void _003CTryMoveSubroom_003Eb__3(LCEKCFEIEGJ newRoomDetails)
			{
			}

			internal bool _003CTryMoveSubroom_003Eb__5(RRUI.Navigation.Uri uri)
			{
				return false;
			}

			internal void _003CTryMoveSubroom_003Eb__4(string err)
			{
			}

			internal void _003CTryMoveSubroom_003Eb__0(LCEKCFEIEGJ newRoomDetails)
			{
			}

			internal void _003CTryMoveSubroom_003Eb__1(string err)
			{
			}
		}

		public const string SUBROOM_ID_KEY = "SUBROOM_ID_KEY";

		private long MCMOLLCNPHO;

		private long LCHGEIAIFFO;

		private OPKEAIOICLJ CIPHEPDBIEL;

		private LCEKCFEIEGJ OCNJNKAJIKN;

		private List<IPKJBIFKDKF> CACPGOBANBC;

		private List<bool> EEJMNKAJEOI;

		private IPKJBIFKDKF EFBNBHFJIBN;

		private HHCLMHEOLDA? DJOHHLPJDHJ;

		private int MAPIGHGMFJP;

		private string LANNFJNIEMC;

		private bool HCKACBMBAFL;

		private bool IAIBOKFCMDO;

		private bool MIKHELCLAII;

		private bool IGGMJCBGAEB;

		private bool CENLLBJOHHG;

		private bool MJINMLFGEEC;

		private Guid DJPHJHBAIME;

		private HLNFDOBEGJO CHABDOLEEMD;

		[SerializeField]
		private GameObject roomPickerPrefab;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public long RoomId
{
get 		{
			return 0L;
		}

private set {
		}
}

public long SubroomId
{
get 		{
			return 0L;
		}

private set {
		}
}

public OPKEAIOICLJ Subroom
{
get 		{
			return null;
		}

private set {
		}
}

public LCEKCFEIEGJ RoomDetails
{
get 		{
			return null;
		}

private set {
		}
}

public List<IPKJBIFKDKF> RoomSaves
{
get 		{
			return null;
		}

private set {
		}
}

public IPKJBIFKDKF SelectedSaveToPublish
{
get 		{
			return null;
		}

private set {
		}
}

public HHCLMHEOLDA? LoadSceneSourceData
{
get 		{
			return null;
		}

private set {
		}
}

public bool SubroomSettingsDirty
{
get 		{
			return false;
		}

}

public bool CanEditSubroom
{
get 		{
			return false;
		}

}

public bool SubroomIsLocal
{
get 		{
			return false;
		}

}

public bool CanToggleSubroomSetting
{
get 		{
			return false;
		}

}

public bool IsEntrySubroom
{
get 		{
			return false;
		}

}

public bool IsRoomPublished
{
get 		{
			return false;
		}

}

public bool CanEnableEntrySubroom
{
get 		{
			return false;
		}

}

public bool IsMakerPenRoomScene
{
get 		{
			return false;
		}

}

public bool CanDeleteSubroom
{
get 		{
			return false;
		}

}

public bool CanSaveSubroom
{
get 		{
			return false;
		}

}

public bool CanGoToSubroom
{
get 		{
			return false;
		}

}

public bool HostOnlyAreasEnabled
{
get 		{
			return false;
		}

}

public bool InvisibleWallsEnabled
{
get 		{
			return false;
		}

}

public bool GadgetsToAllEnabled
{
get 		{
			return false;
		}

}

public bool RemoveGriefableChips
{
get 		{
			return false;
		}

}

public bool UseNewMaterialsEnabled
{
get 		{
			return false;
		}

}

public bool DirectionalVoiceChatEnabled
{
get 		{
			return false;
		}

}

public bool RoomMoodSettingsEnabled
{
get 		{
			return false;
		}

}

public MoodSetting CurrentMood
{
get 		{
			return null;
		}

}

public int MaxPlayersBackingData
{
get 		{
			return 0;
		}

set {
		}
}

public string SubroomNameBackingData
{
get 		{
			return null;
		}

set {
		}
}

		private bool PJNEBPPKGGO(int GMEHLIHLGEH)
		{
			return false;
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected void BPJCBNEEADN(long EPOBIFCHLNM)
		{
		}

		public void ShowSaveVersionDialog()
		{
		}

		public void Set(long EPOBIFCHLNM, long FPPOCBBEOPL, HHCLMHEOLDA APFMLJLPMJD)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void TryGoToSubroom(OPKEAIOICLJ FPDPBAPDONJ)
		{
		}

		public void TryCloneSubroom()
		{
		}

		public void TryDeleteSubroom()
		{
		}

		private Task DMFENBFMCDG()
		{
			return null;
		}

		public void TrySaveSubroom()
		{
		}

		private void NFNDJIKPIJJ()
		{
		}

		public LAHBDKNMNHN TryChangeSubroomName(string KNOPFGAGMCN)
		{
			return null;
		}

		public void TryShowMoveSubroomPicker()
		{
		}

		public LAHBDKNMNHN TryChangeMaxPlayers(int FKPFOMOKACN)
		{
			return null;
		}

		public void TryToggleEntrySubroom()
		{
		}

		public void TryToggleHostOnlyAreasEnabled()
		{
		}

		public void TryToggleInvisibleWallsEnabled()
		{
		}

		public void TryToggleGadgetsToAllEnabled()
		{
		}

		public void TryToggleRemoveGriefableChips()
		{
		}

		public void TryToggleUseNewMaterials()
		{
		}

		public void TryToggleDirectionalVoiceChatEnabled()
		{
		}

		public void TrySetSubroomMood(MoodSetting ADCDGFNDOEJ)
		{
		}

		private void HDDOMKOFCBE(List<JCDPHCELKHI> CECGEDKICOA)
		{
		}

		private void CMIDKFGHEIH(long HCLNCLGLPLD)
		{
		}

		public AEBHFHIINHM GetCardDataForSubroom()
		{
			return null;
		}

		[CompilerGenerated]
		private bool KDFOEMOMBFC(OPKEAIOICLJ IBALDFBGBGL)
		{
			return false;
		}

		[CompilerGenerated]
		private void BIIMKABCPEL(LCEKCFEIEGJ BBHINKGKDBL)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<global::KBKOPBBHCHK<IPKJBIFKDKF>> EPNJMCGNHHD()
		{
			return null;
		}

		[CompilerGenerated]
		private void BDAKIDPGNPF(global::KBKOPBBHCHK<IPKJBIFKDKF> HMOLPGPDBNM)
		{
		}

		[CompilerGenerated]
		private bool EFHODEDBEFH(IPKJBIFKDKF IBALDFBGBGL)
		{
			return false;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<bool>> CLHDKBADDJB()
		{
			return null;
		}

		[CompilerGenerated]
		private void CHMHBKIKCHO(List<bool> OPOLCOKPLLP)
		{
		}

		[CompilerGenerated]
		private void NPDAKKADENP(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void PCCEFGAGAGJ()
		{
		}

		[CompilerGenerated]
		private void AHHKACAHCLD(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void EDBOEIFHHPJ()
		{
		}

		[CompilerGenerated]
		private void HEKGPAONCLO(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void PAPACDBPKAO(IReadOnlyList<JCDPHCELKHI> CECGEDKICOA)
		{
		}

		[CompilerGenerated]
		private bool DANNCGPFLHO(JCDPHCELKHI GOJCEBCMFJK)
		{
			return false;
		}

		[CompilerGenerated]
		private void PHCNHIMPMPO()
		{
		}

		[CompilerGenerated]
		private void LNMDFKCPEOL(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void PICONMELJJJ()
		{
		}

		[CompilerGenerated]
		private void ADLPBLAJCPL()
		{
		}

		[CompilerGenerated]
		private void LJMHLEFIGFA(bool OBFHBDLKFPA)
		{
		}
	}
}
