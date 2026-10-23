using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CodeStage.AntiCheat.ObscuredTypes;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecNet;
using RecRoom.Core.Creation.AI;
using RecRoom.Sharing;
using RecRoom.Systems.PlayerRoles;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomModel : RRUIModel
	{
		public enum FABGCCNABGM
		{
			SmallestSubroom = 0,
			EntrySubroom = 1
		}

		public struct LKMOIICAIBO
		{
			public string EDMNOAEBDNC;

			public string LJJGMJNNJKN;

			public string EHFAPDPNCFN;
		}

		private enum JJKMBNBOCLL
		{
			None = 0,
			Save = 1,
			Restore = 2
		}

		public class INNLBDEFBDE : Exception
		{
			public readonly string NKHKELCMHGJ;

			public INNLBDEFBDE(string FGFCBOHADKH)
			{
			}

			public INNLBDEFBDE(string FGFCBOHADKH, Exception OAFPGAMPFDL)
			{
			}
		}

		private struct KKAMLCGCICI
		{
			private readonly Guid NHFALNCCPHI;

			private readonly bool DFCNEKLOPOH;

			public KKAMLCGCICI(Guid NHFALNCCPHI, bool DFCNEKLOPOH)
			{
				this.NHFALNCCPHI = default;
				this.DFCNEKLOPOH = false;
			}

			public void KLCMDGBGEGE(string DADHJJNJEFA, JCDPHCELKHI HKAIILLHJGF, JCDPHCELKHI KAGNPDPCDPC, bool? FABGIJFPAEP = null, string NLJOHEKGNDH = null)
			{
			}
		}

		private sealed class OKHAOFGIPPJ
		{
			public PickerDialogModel activeDialog;

			public int newCreatorAccountId;

			public RoomModel _003C_003E4__this;

			public Action _003C_003E9__7;

			public Action<string> _003C_003E9__8;

			public Predicate<ObscuredInt> _003C_003E9__10;

			internal void _003CShowChangeRoomCreatorDialog_003Eb__4()
			{
			}

			internal void _003CShowChangeRoomCreatorDialog_003Eb__5()
			{
			}

			internal void _003CShowChangeRoomCreatorDialog_003Eb__7()
			{
			}

			internal void _003CShowChangeRoomCreatorDialog_003Eb__8(string error)
			{
			}

			internal bool _003CShowChangeRoomCreatorDialog_003Eb__6()
			{
				return false;
			}

			internal void _003CShowChangeRoomCreatorDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, AccountModel accountModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CShowChangeRoomCreatorDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CShowChangeRoomCreatorDialog_003Eb__10(ObscuredInt i)
			{
				return false;
			}

			internal void _003CShowChangeRoomCreatorDialog_003Eb__2(int index)
			{
			}

			internal void _003CShowChangeRoomCreatorDialog_003Eb__3(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class LKBMDPLBCLM
		{
			public CardModel cardModel;

			internal void _003CShowChangeRoomCreatorDialog_003Eb__9(DFDECAEJBIO account)
			{
			}
		}

		private sealed class JMKENFIBDBL
		{
			public string currentConfirmText;

			public MessageWithInputFieldDialogModel activeDialog;

			public EHEJPNFKNAL applyButton;

			public RoomModel _003C_003E4__this;

			internal bool _003CShowDeleteRoomConfirmationDialog_003Eb__2()
			{
				return false;
			}

			internal void _003CShowDeleteRoomConfirmationDialog_003Eb__3()
			{
			}

			internal string _003CShowDeleteRoomConfirmationDialog_003Eb__4()
			{
				return null;
			}

			internal void _003CShowDeleteRoomConfirmationDialog_003Eb__5(string s)
			{
			}

			internal void _003CShowDeleteRoomConfirmationDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}

			internal void _003CShowDeleteRoomConfirmationDialog_003Eg__ConfirmDelete_007C1()
			{
			}
		}

		private sealed class JCIHBOOIEFB
		{
			public string trimmedTag;

			internal bool _003CIsPopularTag_003Eb__0(string popularTag)
			{
				return false;
			}
		}

		private sealed class KELFOKAIHNA
		{
			public bool shouldRequestRoomSave;

			public long roomId;

			public RoomModel _003C_003E4__this;

			internal void _003CTryToggleCreativeToolsBeta_003Eb__1()
			{
			}
		}

		private sealed class FAMPCJMBPFG
		{
			public long roomId;

			public RoomModel _003C_003E4__this;

			internal void _003CTryToggleCreativeRoles_003Eb__1()
			{
			}
		}

		private sealed class BINKHLIACLN
		{
			public string subroomName;

			public MessageWithInputFieldDialogModel activeDialog;

			public RoomModel _003C_003E4__this;

			internal string _003CShowAddNewSubroomDialog_003Eb__2()
			{
				return null;
			}

			internal void _003CShowAddNewSubroomDialog_003Eb__3(string s)
			{
			}

			internal void _003CShowAddNewSubroomDialog_003Eb__4()
			{
			}

			internal void _003CShowAddNewSubroomDialog_003Eb__5()
			{
			}

			internal void _003CShowAddNewSubroomDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}

			internal void _003CShowAddNewSubroomDialog_003Eg__Create_007C1(string name)
			{
			}

			internal void _003CShowAddNewSubroomDialog_003Eb__6()
			{
			}

			internal void _003CShowAddNewSubroomDialog_003Eb__7(string error)
			{
			}
		}

		private sealed class HMJFFDHEPBJ
		{
			public HMKGEIMLLNJ value;

			public RoomModel _003C_003E4__this;

			internal void _003CTryChangeRoomAccessibility_003Eb__0()
			{
			}

			internal void _003CTryChangeRoomAccessibility_003Eb__1(string error)
			{
			}
		}

		private sealed class JMKJBNADOBB
		{
			public RoomModel _003C_003E4__this;

			public bool privateInstance;

			internal void _003CTryGoToRoom_003Eb__0(OPKEAIOICLJ subRoom)
			{
			}
		}

		private sealed class EGPIFILFKJF
		{
			public OPKEAIOICLJ subRoom;

			public RoomModel _003C_003E4__this;

			public bool privateInstance;

			public Func<IPKJBIFKDKF, bool> _003C_003E9__4;

			public Action _003C_003E9__5;

			internal bool _003CLoadOrShowVersionDialog_003Eb__4(IPKJBIFKDKF s)
			{
				return false;
			}

			internal void _003CLoadOrShowVersionDialog_003Eb__5()
			{
			}
		}

		private sealed class FNALCFHFILD
		{
			public List<IPKJBIFKDKF> roomSaves;

			public EGPIFILFKJF CS_0024_003C_003E8__locals1;

			internal void _003CLoadOrShowVersionDialog_003Eb__1(global::KBKOPBBHCHK<IPKJBIFKDKF> roomSaveResults)
			{
			}

			internal global::NCOKFFGPIJM<IPKJBIFKDKF> _003CLoadOrShowVersionDialog_003Eb__2()
			{
				return null;
			}

			internal void _003CLoadOrShowVersionDialog_003Eb__3(IPKJBIFKDKF latestValidSave)
			{
			}
		}

		private sealed class AOJOANOKFMK
		{
			public IPKJBIFKDKF latestValidSave;

			public FNALCFHFILD CS_0024_003C_003E8__locals2;

			internal void _003CLoadOrShowVersionDialog_003Eb__6()
			{
			}
		}

		private sealed class CDCLEOPDEPM
		{
			public bool isEnabled;

			public RoomModel _003C_003E4__this;

			internal void _003CToxModExperimentIsEnabled_003Eb__0()
			{
			}
		}

		private sealed class NPIPPOFFIIK
		{
			public RoomModel _003C_003E4__this;

			public bool randomSubroom;

			internal void _003CJoinPublicRoomInstance_003Eb__0()
			{
			}
		}

		private sealed class HPCBJBGEPJI
		{
			public bool isFavorited;

			public string amplitudeCommandContext;

			public RoomModel _003C_003E4__this;

			internal void _003CToggleIsFavorited_003Eb__0()
			{
			}

			internal void _003CToggleIsFavorited_003Eb__1(string error)
			{
			}

			internal void _003CToggleIsFavorited_003Eb__2()
			{
			}
		}

		private sealed class PNGPIBOBPGL
		{
			public bool isCheered;

			public string amplitudeCommandContext;

			public RoomModel _003C_003E4__this;

			internal void _003CToggleIsCheered_003Eb__0()
			{
			}

			internal void _003CToggleIsCheered_003Eb__1(string error)
			{
			}

			internal void _003CToggleIsCheered_003Eb__2()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct EHEICCPMNIA : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public RoomModel _003C_003E4__this;

			public string descriptionText;

			public bool publish;

			private TaskAwaiter<BCDAPDDMMEO> _003C_003Eu__1;

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

		private sealed class AGIAJGEGLFI
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CShowCreateClonedRoomDialog_003Eb__1_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public AGIAJGEGLFI _003C_003E4__this;

				public CancellationToken cancellationToken;

				private TaskAwaiter<LCEKCFEIEGJ> _003C_003Eu__1;

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

			public bool generatedName;

			public string currentNameText;

			public string newAutoGeneratedRoomName;

			public RoomModel _003C_003E4__this;

			public KKAMLCGCICI analyticsSample;

			public MessageWithInputFieldDialogModel activeDialog;

			public LAJCFKEJKIN createButton;

			internal Task _003CShowCreateClonedRoomDialog_003Eb__1(CancellationToken cancellationToken)
			{
				return null;
			}

			internal bool _003CShowCreateClonedRoomDialog_003Eb__2()
			{
				return false;
			}

			internal void _003CShowCreateClonedRoomDialog_003Eb__3()
			{
			}

			internal string _003CShowCreateClonedRoomDialog_003Eb__4()
			{
				return null;
			}

			internal void _003CShowCreateClonedRoomDialog_003Eb__5(string s)
			{
			}

			internal void _003CShowCreateClonedRoomDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}
		}

		private sealed class PKIACBHEBKB
		{
			public RoomModel _003C_003E4__this;

			public EGGMEJDMHKF previousRoomInstance;

			public LCEKCFEIEGJ newRoomCloneDetails;

			internal void _003CCloneRoom_003Eb__0(ANAGHNCECEB result)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct PFCGOJACHEC : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LCEKCFEIEGJ> _003C_003Et__builder;

			public RoomModel _003C_003E4__this;

			public KKAMLCGCICI analyticsSample;

			public bool isAutogeneratedName;

			public string roomName;

			private PKIACBHEBKB _003C_003E8__1;

			private TaskAwaiter<LCEKCFEIEGJ> _003C_003Eu__1;

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

		private sealed class DPDIOIDAJCI
		{
			private sealed class _003C_003COnRoomCloned_003Eg__TryEquipMakerPen_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public DPDIOIDAJCI _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003COnRoomCloned_003Eg__TryEquipMakerPen_007C0_003Ed(int _003C_003E1__state)
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

			public EGGMEJDMHKF previousRoomInstance;

			public JCDPHCELKHI targetRoom;

			internal IEnumerator<EGGPGCCKPCO> _003COnRoomCloned_003Eg__TryEquipMakerPen_007C0()
			{
				return null;
			}

			internal bool _003COnRoomCloned_003Eb__1()
			{
				return false;
			}
		}

		private bool PNOADKEDJJI;

		private string GPPKMEFFCDN;

		private string PMHFBLIAIFB;

		private string HFECDJCAHOP;

		public LKMOIICAIBO LoadingScreenBackingField;

		private readonly ManagedTexture PHDELAPLILN;

		private IReadOnlyList<string> AOAAJOIANKC;

		private bool PCLIFFNIGLK;

		private const string KJLGEIBOEHH = "X";

		private string CHLIFEFPFJF;

		[TextArea]
		[SerializeField]
		private string betaFeaturesConfirmationBodyText;

		private const string JCMFKPPFEIK = "Exposes the Maker Pen Role setting called \"Creation Restrictions Apply.\" Objects will store their creator’s Roles, which may impact load times. A user’s current Roles will be compared to an object’s stored Roles to determine if they can affect that object with the Maker Pen. Owners and co-owners are not subject to these selection restrictions but will still impact the Roles stored on objects.\n\nAre you sure you wish to turn this on? This will also save the";

		private const string OOLNEPOEBCE = "All stored roles will be removed from objects, and objects will no longer store their creator’s roles. This is not an undoable operation.\n\nAre you sure you wish to continue? This will save the roo";

		[SerializeField]
		[TextArea]
		private string objectModelConfirmationBodyText;

		[SerializeField]
		private string cocReminderYesButtonText;

		[SerializeField]
		private string cocReminderNoButtonText;

		[SerializeField]
		private string cocReminderDialogTextViewCoCButtonText;

		[SerializeField]
		private string openCoCWebpageTitleText;

		[SerializeField]
		private string openCoCWebpageMessageText;

		private DFHAFLJGDNL JIALHGHCOON;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private const string DFJAIMOFABE = "CHECK_COMFORT_MODE_PREF";

		public const string DEFAULT_WARNING_REJECT_BUTTON_TEXT = "Cancel";

		private bool OMBHJBLIILA;

		private global::PHLHFLLLDLK<HGKINAOMNIF> MHIMIIJDCPA;

		private string JNEPIJIAMOO;

		[SerializeField]
		private float minSaveRestoreInterval;

		[SerializeField]
		private bool showSaveLoadFeedback;

		public const string TOXMOD_EXPERIMENT_NAME = "ugc_toxmod_rollout";

		public const string TOXMOD_EXPERIMENT_PARAMETER = "show_warning";

		private ActionCode OFCIIBEPLKF;

		private JJKMBNBOCLL JMCGBDDCDGD;

		private float FDHODAAFOJF;

		private float ACAOEKEHINF;

		private DBIPHDIEBCM EFMFIMJJMCI;

		private HLNFDOBEGJO CHABDOLEEMD;

		private ALOOJKKMCGM FPAJJENFDJC;

		private LKFJJHJMFIB ADGPGMPOPNJ;

		private EAOCHKEGDFJ BBHMAAACAIO;

		private IILDCCEMGBA LCPOIILBNLD;

		private MMCFCPOLMGM ANPMAHKHJMF;

		private PNPHOOBLIIO KKGOHIDNJOL;

		private NNBAJLCGAOK JGEGKOOCOEH;

		private CGOPOAFDIDN FIJHCMLFKJH;

		private FEIKFKAICHC HKNAHLAFLPC;

		private IPBHBFJGDME FANDMLPFELA;

		private HHCLMHEOLDA? DJOHHLPJDHJ;

		private bool EFCHGPAGNLL;

		private bool LPAKDAMKLBM;

		private bool PGEIIONMFOF;

		private RoomListModel.FFPAGDBKIPG IKGBDPLLFPM;

		private global::CPEJHPJNIKM<long> OHJCMACAONC;

		private static Dictionary<long, bool> JNBNOMJMGID;

		private readonly Dictionary<BLIIKHLKHJA, int> PPLJNIAFENC;

		private bool FHEGNGJPBHO;

		private JCDPHCELKHI JEAJEKEACFP;

		private DFDECAEJBIO EOHCDFKAIPP;

		private EPILDIJELPG MHEKPMAPNPG;

		private LCEKCFEIEGJ BBHINKGKDBL;

		private JHHNJPLOIPG DEENIDELFLG;

		private LFGKKGANEIP OJGLMFBEIOG;

		private string KPKHPAJGALM;

		private bool AEJMCINJHHI;

		private readonly List<string> KHKLEFFMPGP;

		private List<int> EGGJGAECJDF;

		private long ODPJMCODPHB;

		private long AFPHABFLEBN;

		private int? OKOHEPOJGOI;

		private bool EOAPHBMEHNJ;

		private bool HFNLIMEKHJM;

		private bool HPMFJICOHPN;

		private static Regex DIJEKONGHKC;

		private const string BEJJPIKCHHK = "\u200b$";

		private string COGOOCKIHNL;

		private string NMAIJDNOLEC;

		private const string PLGHBOBKGMF = "UGC.ObjectModel.Allowed";

		private float CPEFCHAGMIH;

public bool CanBrowseRoomInstances
{
get 		{
			return false;
		}

}

public bool CanPublishRoom
{
get 		{
			return false;
		}

}

public bool CanUnpublishRoom
{
get 		{
			return false;
		}

}

public bool CanDeleteRoom
{
get 		{
			return false;
		}

}

public bool CanChangeRoomCreator
{
get 		{
			return false;
		}

}

public bool CanCreateCurrencies
{
get 		{
			return false;
		}

}

public bool ShowLoadingScreenPreview
{
get 		{
			return false;
		}

set {
		}
}

public string NameBackingField
{
get 		{
			return null;
		}

set {
		}
}

public string DescriptionBackingField
{
get 		{
			return null;
		}

set {
		}
}

public string CustomWarningBackingField
{
get 		{
			return null;
		}

set {
		}
}

public bool CanChangeRoomSetting
{
get 		{
			return false;
		}

}

public bool CanChangeRoomTags
{
get 		{
			return false;
		}

}

public bool CanChangeCreativeContentBeta
{
get 		{
			return false;
		}

}

public bool IsCreativeRolesActive
{
get 		{
			return false;
		}

}

public bool HasMakerPenPermissionOverride
{
get 		{
			return false;
		}

}

public bool CanChangeCreativeRoles
{
get 		{
			return false;
		}

}

public bool CanChangeCustomWarning
{
get 		{
			return false;
		}

}

public bool CanChangeAiSettings
{
get 		{
			return false;
		}

}

public bool CanChangeLoadingScreen
{
get 		{
			return false;
		}

}

public bool CanCreateNewSubroom
{
get 		{
			return false;
		}

}

public IReadOnlyList<string> PopularTags
{
get 		{
			return null;
		}

private set {
		}
}

public bool CanChangeRoomPermissions
{
get 		{
			return false;
		}

}

public bool CanChangeGameRoles
{
get 		{
			return false;
		}

}

public bool AiIgnorePlayers
{
get 		{
			return false;
		}

}

public bool NavMeshVisible
{
get 		{
			return false;
		}

}

public string RoomWarningRejectButtonText
{
get 		{
			return null;
		}

private set {
		}
}

public bool ComfortModeTogglePref
{
get 		{
			return false;
		}

private set {
		}
}

public global::PHLHFLLLDLK<HGKINAOMNIF> RoomWarningResponsePromise
{
get 		{
			return null;
		}

private set {
		}
}

public bool ComfortModeToggle
{
get 		{
			return false;
		}

set {
		}
}

public bool JoiningRequiresSwitchToWalk
{
get 		{
			return false;
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

public RoomListModel.FFPAGDBKIPG RoomListSource
{
get 		{
			return RoomListModel.FFPAGDBKIPG.ServerSearch;
		}

private set {
		}
}

public ProgressionEventDTO ActiveProgressionEvent
{
get 		{
			return null;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public JCDPHCELKHI Room
{
get 		{
			return null;
		}

set {
		}
}

public DFDECAEJBIO CreatorAccount
{
get 		{
			return null;
		}

set {
		}
}

public EPILDIJELPG Club
{
get 		{
			return null;
		}

set {
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

public JHHNJPLOIPG UserInteractionDetails
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsRoomLinkedToRecRoomStudio
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

public LFGKKGANEIP CanLocalPlayerJoinRoom
{
get 		{
			return null;
		}

private set {
		}
}

public string CanLocalPlayerJoinRoomText
{
get 		{
			return null;
		}

private set {
		}
}

public bool RoomIsVoiceModerated
{
get 		{
			return false;
		}

}

public bool ToxModExperimentIsShowWarning
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsRoomNameVisibleToLocalPlayer
{
get 		{
			return false;
		}

}

public bool HasSufficientVersion
{
get 		{
			return false;
		}

}

public bool CanJoinPublicRoomInstance
{
get 		{
			return false;
		}

}

public bool CanCreatePrivateRoomInstance
{
get 		{
			return false;
		}

}

public bool InPrivateInstanceOfRoom
{
get 		{
			return false;
		}

}

public string CustomWarningText
{
get 		{
			return null;
		}

}

public IReadOnlyList<string> RoomImageNames
{
get 		{
			return null;
		}

}

public List<int> FriendsInRoomAccountIds
{
get 		{
			return null;
		}

private set {
		}
}

public int FriendCountInRoom
{
get 		{
			return 0;
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

public long ClubId
{
get 		{
			return 0L;
		}

private set {
		}
}

public bool HasJustSaved
{
get 		{
			return false;
		}

}

public bool HasJustRestored
{
get 		{
			return false;
		}

}

public bool CanCopyRoom
{
get 		{
			return false;
		}

}

public bool RoomIsLocal
{
get 		{
			return false;
		}

}

public bool RoomInstanceIsPrivate
{
get 		{
			return false;
		}

}

public bool HasActiveRoomJoinRequest
{
get 		{
			return false;
		}

private set {
		}
}

public bool CanChooseSubroom
{
get 		{
			return false;
		}

private set {
		}
}

public bool CanEditRoom
{
get 		{
			return false;
		}

}

public bool CanSaveRoom
{
get 		{
			return false;
		}

}

public bool SwitchTeamsSupported
{
get 		{
			return false;
		}

}

public bool CanSwitchTeams
{
get 		{
			return false;
		}

}

private PJCMOOCCFCF MPPKNGNLMNN
{
get 		{
			return null;
		}

}

public bool HasSelfRevivePermissions
{
get 		{
			return false;
		}

}

public bool CanCurrentlyReviveSelf
{
get 		{
			return false;
		}

}

public bool CanStartGame
{
get 		{
			return false;
		}

}

public bool CanEndGame
{
get 		{
			return false;
		}

}

public bool CanUseCloudData
{
get 		{
			return false;
		}

}

public bool CanViewRoomComments
{
get 		{
			return false;
		}

}

public bool CanShowSimilarRooms
{
get 		{
			return false;
		}

}

public bool HasRRPlusRoomRestriction
{
get 		{
			return false;
		}

private set {
		}
}

public bool ObjectModelEnabled
{
get 		{
			return false;
		}

}

public bool IsObjectModelAllowed
{
get 		{
			return false;
		}

}

		public static char OnRoomNameInputValidate(string HLIGBKANEEA, int MLPMIFMIOKK, char EAAIEEDJAHD)
		{
			return '\0';
		}

		protected override void DHHOMFCCFKP()
		{
		}

		public void TryChangeRoomName()
		{
		}

		public void TryChangeRoomDescription()
		{
		}

		public void TryChangeRoomImage()
		{
		}

		public void ShowChangeRoomCreatorDialog()
		{
		}

		public void TryPublishRoom()
		{
		}

		public void TryUnpublishRoom()
		{
		}

		public void ShowDeleteRoomConfirmationDialog()
		{
		}

		public int GetRoomDisplayCapacity()
		{
			return 0;
		}

		public bool GetMaxPlayerCountTypeActive(AJKBDDEPMMF NIFOGEBEDNG)
		{
			return false;
		}

		public void TryChangeRoomCountForMaxPlayers(AJKBDDEPMMF NIFOGEBEDNG)
		{
		}

		public global::NCOKFFGPIJM<int> UpdateAndGetPopularTagCount()
		{
			return null;
		}

		public bool IsPopularTag(string AHNIMJDLOPB)
		{
			return false;
		}

		public void TrySetMainTag(string AHNIMJDLOPB)
		{
		}

		public void TryChangeRoomTags(IReadOnlyList<string> AOGGECFBBGI)
		{
		}

		public void TryToggleRoomWarning(BBMLADAOMKF GACOIMKHNIN)
		{
		}

		public void TryChangeCustomRoomWarning()
		{
		}

		public void TryToggleSupportsScreens()
		{
		}

		public void TryToggleSupportsWalkVR()
		{
		}

		public void TryToggleSupportTeleportVR()
		{
		}

		public void TryToggleSupportsJuniors()
		{
		}

		public void TryToggleCloningAllowed()
		{
		}

		public void TryToggleDisableMicAutoMute()
		{
		}

		public void TryToggleDisableRoomComments()
		{
		}

		public void TryToggleAllowNewUsers()
		{
		}

		public void TryToggleEncryptVoiceChat()
		{
		}

		public void TryToggleCreativeToolsBeta()
		{
		}

		public void TryToggleCreativeRoles()
		{
		}

		public void TryToggleMakerPenPermissionOverride()
		{
		}

		public void TryToggleObjectModelEnabled()
		{
		}

		public void TryChangeLoadingScreenImage()
		{
		}

		public void TryChangeLoadingScreen()
		{
		}

		public int GetActiveAICount()
		{
			return 0;
		}

		public int GetAIBudgetPercentage()
		{
			return 0;
		}

		public void TryToggleAiIgnorePlayers()
		{
		}

		public void TryToggleNavMeshVisible()
		{
		}

		public void TryDestroyAllAi()
		{
		}

		public void TryRebakeNavMesh()
		{
		}

		public void ShowAddNewSubroomDialog()
		{
		}

		private void MMGPNPCHCPP(JDCIJIEOFOL EKOFNPFCLMO)
		{
		}

		private void NPEEOEMNBCI(CHILKDJABBF EKOFNPFCLMO, GameRole GADDGJANIGG)
		{
		}

		private void LOGCDMFMOCI(JDCIJIEOFOL EKOFNPFCLMO)
		{
		}

		private void JMJFABFCIOE()
		{
		}

		private global::NCOKFFGPIJM<string> DLLPNBIEHKH()
		{
			return null;
		}

		private bool EEJIOBLDOPF(out string NLJOHEKGNDH)
		{
			NLJOHEKGNDH = null;
			return false;
		}

		private void HGNOJLNIHDH()
		{
		}

		private void AJDOBJJLBGM()
		{
		}

		private global::NCOKFFGPIJM<LCEKCFEIEGJ> AKAKCMKFDEP(HMKGEIMLLNJ IPMIIEAGJKC)
		{
			return null;
		}

		private void OCABNGCMJIA(global::NCOKFFGPIJM<LCEKCFEIEGJ> GNKCHIELMJP)
		{
		}

		private void NNFILDMMGFP(string NPOEAPJKNFN)
		{
		}

		private bool KHONLJKJIPK(IReadOnlyList<string> CMBMOBEBGIN)
		{
			return false;
		}

		private void AHGMFELDCHJ()
		{
		}

		public void UpdateComfortModeEnabled()
		{
		}

		public void SetRoomWarningData(LHDONKEPGMA PCPEJHIMHJJ)
		{
		}

		private bool EECOFIAPEIG()
		{
			return false;
		}

		public void Set(long EPOBIFCHLNM, HHCLMHEOLDA APFMLJLPMJD, bool EFCHGPAGNLL = false, long AFPHABFLEBN = -1L, int? OKOHEPOJGOI = null, RoomListModel NGFEBJIIMBM = null, RoomListModel.FFPAGDBKIPG JINDLJHFBGF = RoomListModel.FFPAGDBKIPG.None, global::CPEJHPJNIKM<long> OHJCMACAONC = null)
		{
		}

		protected override void IILPBDLFFKG()
		{
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

		protected void AMOBMOCPGDM(int EJIHLJJMOBD)
		{
		}

		private void KJDCLOJMMEG()
		{
		}

		private void OCCLLPEDNPJ(UGCAIController HBEKDJPJIAD)
		{
		}

		private void KCIIKMKCCGB()
		{
		}

		private void JJAMMOHCJKA(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		private void HGIDGAMECOP(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void NavigateToRoomPageAndRecordImpression()
		{
		}

		private void DEMINBHNPLE(bool NMDKEMCBOHF, bool FDEJJLEDLEN)
		{
		}

		private void GGIEAOOCJAJ(ANAGHNCECEB CDNLFEOBNKB)
		{
		}

		private void MEAGLIJCBDG(bool NMDKEMCBOHF, OPKEAIOICLJ FPDPBAPDONJ = null)
		{
		}

		private void BDIAOHOHNMH(bool NMDKEMCBOHF, OPKEAIOICLJ FPDPBAPDONJ, IPKJBIFKDKF PDHPDFDENKF)
		{
		}

		private void IAOEBABNEFN()
		{
		}

		private void FEMLNCMEJIC(JJKMBNBOCLL MCDNLHIFOLF)
		{
		}

		private void EEFFGCFHIME()
		{
		}

		private bool EOIMFLJHABP()
		{
			return false;
		}

		public bool CanCreateMeetupCodeForRoom()
		{
			return false;
		}

		public bool CanShareRoom()
		{
			return false;
		}

		public void CreateMeetupCode()
		{
		}

		public void ShareRoomCode()
		{
		}

		public global::NCOKFFGPIJM<ActionCode.NMLEIPDLABI> GetRoomCode()
		{
			return null;
		}

		public void JoinPublicRoomInstance(bool FDEJJLEDLEN)
		{
		}

		public void CreatePrivateRoomInstance()
		{
		}

		public bool CanTriggerDiscGolfHazard()
		{
			return false;
		}

		public void TriggerDiscGolfHazard()
		{
		}

		public void ToggleBowlingBumpers()
		{
		}

		public void SwitchTeam()
		{
		}

		public void StartGame()
		{
		}

		public void EndGame()
		{
		}

		public void ReviveSelf()
		{
		}

		public bool CanFavorite()
		{
			return false;
		}

		public void ToggleIsFavorited(string LDPCFDMCJLH)
		{
		}

		public bool CanCheer()
		{
			return false;
		}

		public void ToggleIsCheered(string LDPCFDMCJLH)
		{
		}

		public bool CalculateShouldHideSaveRestoreButtons()
		{
			return false;
		}

		public void TryRestoreRoom()
		{
		}

		public void TrySaveRoom()
		{
		}

		private Task DMFENBFMCDG(string LAHJFBJNIAC, bool IANGIIINDJM)
		{
			return null;
		}

		private static string HPIDIEJKPAL(Exception AHHCFDOHCNE)
		{
			return null;
		}

		public void ShowSaveConfirmationDialog()
		{
		}

		private void KHONFGPKIIO(string LAHJFBJNIAC, bool IANGIIINDJM)
		{
		}

		public void ShowCreateClonedRoomDialog()
		{
		}

		private Task<LCEKCFEIEGJ> BBNDKFJEDFE(string LBGBFPDNKOL, KKAMLCGCICI CBAJANIIENG, CancellationToken NDKAKDJMDIF, bool FABGIJFPAEP)
		{
			return null;
		}

		private void MIEAGNPAIAE(EGGMEJDMHKF JDFKPDLMMCM, JCDPHCELKHI NABGBJNBHDH, Matchmaking.DABKEMNEPLM COKEHKMDIDL)
		{
		}

		public string GetRoomNameWithLineMarkers()
		{
			return null;
		}

		public bool IsKeepsakeRoom()
		{
			return false;
		}

		public void ApplyKeepsakeOverrides(AEBHFHIINHM CGFMEGOHAHA)
		{
		}

		public bool GetCachedAreAllKeepsakesCollected(bool JFDHBCBJEEK = false)
		{
			return false;
		}

		public global::NCOKFFGPIJM<Dictionary<BLIIKHLKHJA, int>> GetTotalKeepsakeCountPerCategoryForRoom()
		{
			return null;
		}

		public global::NCOKFFGPIJM<Dictionary<BLIIKHLKHJA, int>> GetUncollectedKeepsakeCountPerCategoryForRoom()
		{
			return null;
		}

		public string GetKeepsakeCategoryOutlineImageName(BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public string GetKeepsakeCategoryFilledImageName(BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public IComparer<BLIIKHLKHJA> GetKeepsakeCategoryComparer()
		{
			return null;
		}

		[CompilerGenerated]
		private void LBAPELCCGGG()
		{
		}

		[CompilerGenerated]
		private void NCHKGHMDFOP(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void FMJCELCFODC()
		{
		}

		[CompilerGenerated]
		private void DDHAMFFNCAL(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void MBPPKPBAODB(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private void JLJCNKCBNFN()
		{
		}

		[CompilerGenerated]
		private void CLNLCGKBDKO()
		{
		}

		[CompilerGenerated]
		private void CAKOFLIMHJM()
		{
		}

		[CompilerGenerated]
		private void NKBMHMALFJA()
		{
		}

		[CompilerGenerated]
		private void FAEPHLBOBKI(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void DMJFAKBGCIP(IReadOnlyList<string> CMBMOBEBGIN)
		{
		}

		[CompilerGenerated]
		private bool NDFEDKOCOMD(PGCPAFNLAFN IHPJCBCPLCM)
		{
			return false;
		}

		[CompilerGenerated]
		private void PAELEAIKNCD()
		{
		}

		[CompilerGenerated]
		private void DELOOJAGKCF(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void MKAMPKHJKCM(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void JBOBAAGJCNB(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void CEMHBADGPHG()
		{
		}

		[CompilerGenerated]
		private void FEINCKEDHAN(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void MCOHNCNKJJL()
		{
		}

		[CompilerGenerated]
		private void NPIAPHLIMNC(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		internal static void NPHGFALEDHL()
		{
		}

		[CompilerGenerated]
		private void NOGIADKODGD(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private void KJHBEGJACFA()
		{
		}

		[CompilerGenerated]
		private void KPMEMBJNDGE(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<string> CBDEKHKNJGG(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		[CompilerGenerated]
		private bool LDKJMANFNBF()
		{
			return false;
		}

		[CompilerGenerated]
		private void GGBHDHICIPG()
		{
		}

		[CompilerGenerated]
		private bool BJHLBDEENAM(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
			return false;
		}

		[CompilerGenerated]
		private void JOLNICKFFJJ(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void JPMECIFBDGA(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void GOIECCLBECI()
		{
		}

		[CompilerGenerated]
		private void PKEHCKIBGJH()
		{
		}

		[CompilerGenerated]
		private void MIJIEAGNKBM(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private bool ABOFGCDDKJE(string IHPJCBCPLCM)
		{
			return false;
		}

		[CompilerGenerated]
		private void GHEEIBEONBJ(JCDPHCELKHI KPFNANKNKLE)
		{
		}

		[CompilerGenerated]
		private void GEEODDANIGE(DFDECAEJBIO ACBGBAAHOIM)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<EPILDIJELPG> JEEIMGKOCLE()
		{
			return null;
		}

		[CompilerGenerated]
		private void BCNIKEHHDGC(EPILDIJELPG APMHMCKALGG)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<Matchmaking.MFANGFIMOIC>> PKCBIBOODAC()
		{
			return null;
		}

		[CompilerGenerated]
		private void HEJPEEKEDMA(List<Matchmaking.MFANGFIMOIC> MPOPNGJFAJO)
		{
		}

		[CompilerGenerated]
		private void DGPOBBFOGLH(JHHNJPLOIPG BMBJHOFJKDP)
		{
		}

		[CompilerGenerated]
		private void AOGJKPCFADI()
		{
		}

		[CompilerGenerated]
		private void GGBPMFCFCLA()
		{
		}

		[CompilerGenerated]
		private void MFICKGODBHB(HGKINAOMNIF MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void NDMEHFCDCHI()
		{
		}

		[CompilerGenerated]
		private void DKOPJJKGJLB(bool EGJEBAFNALL)
		{
		}

		[CompilerGenerated]
		private void EBPPOHKIGOA((string, bool) PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private void KFNGDGFBIAO(int KEAGBJBHEEL)
		{
		}
	}
}
