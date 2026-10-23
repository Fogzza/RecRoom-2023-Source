using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Broadcasting;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class EventModel : RRUIModel
	{
		private sealed class KOGFHFONOBA
		{
			public string currentConfirmText;

			public MessageWithInputFieldDialogModel deleteDialog;

			public EHEJPNFKNAL deleteApplyButton;

			public EventModel _003C_003E4__this;

			internal bool _003CShowDeleteEventConfirmationDialog_003Eb__2()
			{
				return false;
			}

			internal void _003CShowDeleteEventConfirmationDialog_003Eb__3()
			{
			}

			internal string _003CShowDeleteEventConfirmationDialog_003Eb__4()
			{
				return null;
			}

			internal void _003CShowDeleteEventConfirmationDialog_003Eb__5(string s)
			{
			}

			internal void _003CShowDeleteEventConfirmationDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}

			internal void _003CShowDeleteEventConfirmationDialog_003Eg__ConfirmDelete_007C1()
			{
			}
		}

		private sealed class EMNPAKNLAHA
		{
			public List<EventsConfig.BroadcastPermissionsModeFriendlyNameMapping> options;

			public EventModel _003C_003E4__this;

			public PickerDialogModel activeDialog;

			public Predicate<EventsConfig.BroadcastPermissionsModeFriendlyNameMapping> _003C_003E9__4;

			internal void _003CShowChangeDefaultBroadcastPermissionsDialog_003Eb__0(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
			{
			}

			internal int _003CShowChangeDefaultBroadcastPermissionsDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CShowChangeDefaultBroadcastPermissionsDialog_003Eb__4(EventsConfig.BroadcastPermissionsModeFriendlyNameMapping item)
			{
				return false;
			}

			internal void _003CShowChangeDefaultBroadcastPermissionsDialog_003Eb__2(int index)
			{
			}

			internal void _003CShowChangeDefaultBroadcastPermissionsDialog_003Eb__3(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class EOLGLKCMNAA
		{
			public EventModel _003C_003E4__this;

			public PickerDialogModel activeDialog;

			public Predicate<EventsConfig.BroadcastPermissionsModeFriendlyNameMapping> _003C_003E9__5;

			internal bool _003CShowChangeCanRequestBroadcastPermissionDialog_003Eb__0(EventsConfig.BroadcastPermissionsModeFriendlyNameMapping x)
			{
				return false;
			}

			internal void _003CShowChangeCanRequestBroadcastPermissionDialog_003Eb__1(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
			{
			}

			internal int _003CShowChangeCanRequestBroadcastPermissionDialog_003Eb__2()
			{
				return 0;
			}

			internal bool _003CShowChangeCanRequestBroadcastPermissionDialog_003Eb__5(EventsConfig.BroadcastPermissionsModeFriendlyNameMapping item)
			{
				return false;
			}

			internal void _003CShowChangeCanRequestBroadcastPermissionDialog_003Eb__3(int index)
			{
			}

			internal void _003CShowChangeCanRequestBroadcastPermissionDialog_003Eb__4(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class GEBFDHKLDEK
		{
			public string trimmedTag;

			internal bool _003CIsPopularTag_003Eb__0(string popularTag)
			{
				return false;
			}
		}

		private sealed class OKHLOJFEAIJ
		{
			public RoomPickerDialogModel roomPickerDialogModel;

			public EventModel _003C_003E4__this;

			public GameObject subRoomCardPrefab;

			public EHEJPNFKNAL nextButton;

			internal void _003CShowEventLocationSelectionDialog_003Eb__1()
			{
			}

			internal bool _003CShowEventLocationSelectionDialog_003Eb__2()
			{
				return false;
			}

			internal void _003CShowEventLocationSelectionDialog_003Eb__3(JCDPHCELKHI room)
			{
			}

			internal void _003CShowEventLocationSelectionDialog_003Eb__0(BaseDialogModel<DAPFKAIPKPO> dialog)
			{
			}
		}

		private sealed class MDDLCLNILBI
		{
			public EventModel _003C_003E4__this;

			public GameObject subRoomCardPrefab;

			public Func<int> _003C_003E9__4;

			public Action<int> _003C_003E9__5;

			internal void _003CShowEventLocationSubroomDialog_003Eb__0(LCEKCFEIEGJ details)
			{
			}

			internal int _003CShowEventLocationSubroomDialog_003Eb__4()
			{
				return 0;
			}

			internal void _003CShowEventLocationSubroomDialog_003Eb__5(int index)
			{
			}
		}

		private sealed class FOLNJHEDNCI
		{
			public LCEKCFEIEGJ details;

			public PickerDialogModel subroomPickerDialog;

			public List<OPKEAIOICLJ> availableSubrooms;

			public MDDLCLNILBI CS_0024_003C_003E8__locals1;

			internal bool _003CShowEventLocationSubroomDialog_003Eb__1(OPKEAIOICLJ x)
			{
				return false;
			}

			internal void _003CShowEventLocationSubroomDialog_003Eb__7()
			{
			}

			internal void _003CShowEventLocationSubroomDialog_003Eb__3(GameObject instance, int index, CardModel cardModel, SubroomModel subRoomModel, JLOCLGGLOPP subroomToCardController)
			{
			}

			internal void _003CShowEventLocationSubroomDialog_003Eb__6(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class EHHOPNIFGCO
		{
			public EventModel _003C_003E4__this;

			public bool refreshOnError;

			public string fieldName;

			internal void _003CTryUpdateEventField_003Eb__0(GDCLLKJIJPJ response)
			{
			}

			internal void _003CTryUpdateEventField_003Eb__1(string error)
			{
			}
		}

		private sealed class CDHGIPIGFKG
		{
			public EventModel _003C_003E4__this;

			public GDCLLKJIJPJ response;

			internal void _003CHandleCreateResponse_003Eb__0(NCBAEFEDLMK details)
			{
			}
		}

		private sealed class GECHFGABGBP
		{
			public IMIJPHJKLIM playerEvent;

			internal bool _003CRefreshInternal_003Eb__7(BJCIKFCDBFN m)
			{
				return false;
			}
		}

		private sealed class PDMHABAEDEL
		{
			public List<Player> broadcasters;

			internal void _003CShowAllBroadcasters_003Eb__2(GameObject instance, int index, CardModel cardModel, AccountModel accountModel, JLOCLGGLOPP toCardController)
			{
			}
		}

		private sealed class OADOMJJOMED
		{
			public CardModel cardModel;

			public Player broadcaster;

			internal void _003CShowAllBroadcasters_003Eb__3(DFDECAEJBIO account)
			{
			}

			internal void _003CShowAllBroadcasters_003Eb__4()
			{
			}
		}

		private sealed class FKELHBMFGJL
		{
			public EventModel _003C_003E4__this;

			public BroadcastingManager broadcastingManager;

			public CMCJNOMAEEK dialogModel;

			internal void _003CManageBroadcasters_003Eb__2(GameObject instance, int index, CardModel cardModel, AccountModel accountModel, JLOCLGGLOPP toCardController)
			{
			}

			internal bool _003CManageBroadcasters_003Eb__3(string query, int idx)
			{
				return false;
			}

			internal bool _003CManageBroadcasters_003Eb__11(int idx)
			{
				return false;
			}

			internal bool _003CManageBroadcasters_003Eb__12(int idx)
			{
				return false;
			}

			internal void _003CManageBroadcasters_003Eb__4(BaseDialogModel<KCOKPCOFDIM> model)
			{
			}
		}

		private sealed class NINFOMILBCC
		{
			public CardModel cardModel;

			public Player player;

			public int accountId;

			public FKELHBMFGJL CS_0024_003C_003E8__locals1;

			internal void _003CManageBroadcasters_003Eb__6(DFDECAEJBIO account)
			{
			}

			internal void _003CManageBroadcasters_003Eb__7()
			{
			}

			internal bool _003CManageBroadcasters_003Eb__8()
			{
				return false;
			}

			internal string _003CManageBroadcasters_003Eb__9()
			{
				return null;
			}

			internal void _003CManageBroadcasters_003Eb__10()
			{
			}
		}

		private sealed class CCFMMLOMOCB
		{
			public EventModel _003C_003E4__this;

			public HHAPNEKGMEP targetResponse;

			internal void _003CChangeRSVP_003Eb__0()
			{
			}
		}

		private sealed class PLDCFDIDDMP
		{
			public DateTime updateTime;

			internal bool _003CBroadcastAt_003Eb__0()
			{
				return false;
			}
		}

		private sealed class ONEPLCPGMBB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public DateTime updateTime;

			public EventModel _003C_003E4__this;

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
			public ONEPLCPGMBB(int _003C_003E1__state)
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

		private static readonly IReadOnlyList<string> JLABHAGEFNC;

		private const string EANEOHABJIN = "X";

		private static readonly string POHNHEDDNJL;

		public const int BUFFER_MINUTES = 20;

		private const int IFMJMBIEHBI = 5;

		private const int PJIHPANMKAF = 1440;

		private const int DFCLECFMNMJ = 30;

		private const int LICACAMAGCH = 30;

		private const int JDFHDIPGNAJ = -1;

		private bool LBJMILOMHGN;

		private JCDPHCELKHI IHKKLOOELFM;

		private int CHBBBDMODLN;

		private string POJEHPMCKLE;

		private string DDCPACDDJGC;

		private string NCLJMPKAIIK;

		private readonly List<EventsConfig.BroadcastPermissionsModeFriendlyNameMapping> ELMKAFEOFJA;

		private string OPPLKIDFPLL;

		private long BMEMDEOMHJD;

		private long? EHDNCHEOAOF;

		private long? BLKDDEAKFIA;

		private bool NBMPOBDLEBK;

		private bool FHFBOEABOPM;

		private HNIAHAIDJAC KMPHLHLJELJ;

		private HNIAHAIDJAC OCOEAAHKHLD;

		private DateTime HLFJDLDJJFC;

		private DateTime MHMDFAIMHIG;

		private int ANFOLGCGLMN;

		private AAOMIMIAKGO EPAKDBHEAPA;

		private IReadOnlyList<string> AOAAJOIANKC;

		private IReadOnlyList<string> BLFANOCIMMC;

		private string NIGPHLOFNJE;

		private bool ODDKDHIFAJM;

		private string AHPNCLEIKNA;

		[IgnoreDataMember]
		private IReadOnlyList<string> OAINOAJPMBA;

		[IgnoreDataMember]
		private IReadOnlyList<string> BBBCAFBLBII;

		private DDIMGLNCLMH FDDAAJBPIBI;

		private IMIJPHJKLIM LMCGJAMDGPJ;

		private JCDPHCELKHI JEAJEKEACFP;

		private DFDECAEJBIO EOHCDFKAIPP;

		private EPILDIJELPG MHEKPMAPNPG;

		private List<ALGBCBHPICC> EAHDAGAJEAA;

		private static HHAPNEKGMEP DCPOPKAMNIH;

		private long NJJFDENHGKK;

		private bool EFCHGPAGNLL;

		private BJCIKFCDBFN HHGEJDMGJFK;

		private KCOKPCOFDIM HKFLDGEIKML;

		private global::NCOKFFGPIJM<BaseDialogModel<KCOKPCOFDIM>> LNNPJHMJPDH;

		private readonly List<Player> FGJMFEIFIAL;

		private LKGILLBEJEK HMCIKOONJGN;

		private EventListModel DLGBNEDAKKD;

		private int? CBIHELFICFH;

public IReadOnlyList<string> AgTags
{
get 		{
			return null;
		}

}

public IReadOnlyList<string> PlayerAddedTags
{
get 		{
			return null;
		}

}

public string MainTag
{
get 		{
			return null;
		}

}

public string LocationTextBackingField
{
get 		{
			return null;
		}

private set {
		}
}

public long LocationRoomIdBackingField
{
get 		{
			return 0L;
		}

private set {
		}
}

public long? LocationSubRoomIdBackingField
{
get 		{
			return null;
		}

private set {
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

public long? ClubIdBackingField
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsMultiInstanceBackingField
{
get 		{
			return false;
		}

private set {
		}
}

public bool SupportMultiInstanceRoomChatBackingField
{
get 		{
			return false;
		}

private set {
		}
}

public HNIAHAIDJAC DefaultBroadcastPermissionsBackingField
{
get 		{
			return HNIAHAIDJAC.None;
		}

private set {
		}
}

public HNIAHAIDJAC CanRequestBroadcastPermissionBackingField
{
get 		{
			return HNIAHAIDJAC.None;
		}

private set {
		}
}

public DateTime StartTimeBackingField
{
get 		{
			return default;
		}

private set {
		}
}

public DateTime CalculatedEndTime
{
get 		{
			return default;
		}

private set {
		}
}

public int EventDurationMinutesBackingField
{
get 		{
			return 0;
		}

private set {
		}
}

public AAOMIMIAKGO AccessibilityBackingField
{
get 		{
			return AAOMIMIAKGO.Private;
		}

private set {
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

public IReadOnlyList<string> TagsBackingField
{
get 		{
			return null;
		}

private set {
		}
}

public string ImageNameBackingField
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsExistingEvent
{
get 		{
			return false;
		}

}

public bool CanEditEventSettings
{
get 		{
			return false;
		}

}

public bool CanDeleteEvent
{
get 		{
			return false;
		}

}

public bool CanEditEventTags
{
get 		{
			return false;
		}

}

public bool CanCreateMultiInstanceEvent
{
get 		{
			return false;
		}

}

public bool CanSaveName
{
get 		{
			return false;
		}

}

public bool CanSaveDescription
{
get 		{
			return false;
		}

}

public bool CanSaveDateRange
{
get 		{
			return false;
		}

}

public bool CanCreateEvent
{
get 		{
			return false;
		}

}

public bool IsNameValid
{
get 		{
			return false;
		}

}

public bool IsDescriptionValid
{
get 		{
			return false;
		}

}

private DDIMGLNCLMH NGHDNBBKJLD
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

public IMIJPHJKLIM PlayerEvent
{
get 		{
			return null;
		}

set {
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

public List<ALGBCBHPICC> Tags
{
get 		{
			return null;
		}

private set {
		}
}

public bool LocalPlayerInBroadcastInstance
{
get 		{
			return false;
		}

}

public bool CanRequestBroadcastingAuthorization
{
get 		{
			return false;
		}

}

public bool HasBroadcastingAuthorization
{
get 		{
			return false;
		}

}

public bool CanStartBroadcasting
{
get 		{
			return false;
		}

}

public bool CanStopBroadcasting
{
get 		{
			return false;
		}

}

public bool CanViewBroadcasters
{
get 		{
			return false;
		}

}

public bool CanManageBroadcasters
{
get 		{
			return false;
		}

}

public bool CanRSVP
{
get 		{
			return false;
		}

}

public bool CanJoinEvent
{
get 		{
			return false;
		}

}

public bool CanCreatePrivateEventInstance
{
get 		{
			return false;
		}

}

public bool CanInviteFriends
{
get 		{
			return false;
		}

}

public bool HasPendingInvite
{
get 		{
			return false;
		}

}

public int? InvitingPlayerAccountId
{
get 		{
			return null;
		}

}

public bool EventOrganizerIsLocalPlayer
{
get 		{
			return false;
		}

}

public bool IsEventOrganizerInRoom
{
get 		{
			return false;
		}

}

public HHAPNEKGMEP PlayerEventResponseType
{
get 		{
			return HHAPNEKGMEP.Yes;
		}

}

public EventListModel EventList
{
get 		{
			return null;
		}

private set {
		}
}

public int? EventListIndex
{
get 		{
			return null;
		}

private set {
		}
}

public long PlayerEventId
{
get 		{
			return 0L;
		}

set {
		}
}

public bool IncludeDetails
{
get 		{
			return false;
		}

set {
		}
}

		private void PIMNFBGCOFC()
		{
		}

		public void SetStartTimeBackingField(DateTime HDGFHFCPNPD)
		{
		}

		public void SetEventDuration(int FGBPJMKCMAO)
		{
		}

		public void SetEventDurationFromEndTime(DateTime FJKIDPPLMMJ)
		{
		}

		public void ShowDeleteEventConfirmationDialog()
		{
		}

		public void ShowChangeDefaultBroadcastPermissionsDialog(GameObject MPNJFGHHINN)
		{
		}

		public void ShowChangeCanRequestBroadcastPermissionDialog(GameObject MPNJFGHHINN)
		{
		}

		public void TryCreateEvent()
		{
		}

		public void TrySaveName()
		{
		}

		public void TrySaveDescription()
		{
		}

		public void TryChangeMultiInstance(bool CGNIAKOKMAK)
		{
		}

		public void TryChangeSupportMultiInstanceRoomChat(bool AFOAEIMJADC)
		{
		}

		public void TryChangeDefaultBroadcastPermissions(HNIAHAIDJAC FHDKNFBMGCJ)
		{
		}

		public void TryChangeCanRequestBroadcastPermission(HNIAHAIDJAC FHDKNFBMGCJ)
		{
		}

		private void MOAIKIBDMDP()
		{
		}

		public void TryChangeLocation(GameObject JDMCONIPCEJ)
		{
		}

		public void TryChangeImage()
		{
		}

		public void ChangeAccessibility(AAOMIMIAKGO NCJPNJKEEHD)
		{
		}

		public void TrySaveDateRange()
		{
		}

		public bool IsPopularTag(string AHNIMJDLOPB)
		{
			return false;
		}

		public void TrySetMainTag(string AHNIMJDLOPB)
		{
		}

		public void TryChangeEventTags(IReadOnlyList<string> AOGGECFBBGI)
		{
		}

		public global::NCOKFFGPIJM<int> UpdateAndGetPopularTagCount()
		{
			return null;
		}

		private void JKMENKGELHM()
		{
		}

		private void EFNAFELOFEO()
		{
		}

		private void JFHIBCKHPFO(IMIJPHJKLIM IGGPIMCKMBP)
		{
		}

		private void EKLBJOGKBOI()
		{
		}

		private string ODIEILDOBEB()
		{
			return null;
		}

		private bool KHONLJKJIPK(IReadOnlyList<string> CMBMOBEBGIN)
		{
			return false;
		}

		private void PPNEGNIGDFE(GameObject JDMCONIPCEJ)
		{
		}

		private void DLKGBJILPIH(GameObject JDMCONIPCEJ)
		{
		}

		private global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> DNKDJFFBMIB()
		{
			return null;
		}

		private static global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> NJMPCOCOPEI(global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> DDLIBIHPMNF)
		{
			return null;
		}

		private void HNPOMLMKLEJ(LCEKCFEIEGJ JDBHABEFGKF, OPKEAIOICLJ FPDPBAPDONJ)
		{
		}

		private void PNKNBFBOMKI(bool GGBPLIOLJJE, string LILJJIELHBD, global::NCOKFFGPIJM<GDCLLKJIJPJ> BOJDPAGLBLI, bool BNLAOIDDPNH = false)
		{
		}

		private string AFOHLBPDEIG(GDCLLKJIJPJ MLDANHIGANI)
		{
			return null;
		}

		private void PBKHJPPPNEE(GDCLLKJIJPJ MLDANHIGANI)
		{
		}

		private void LEBECHKBJLH(GDCLLKJIJPJ MLDANHIGANI)
		{
		}

		public static char OnRoomNameInputValidate(string HLIGBKANEEA, int MLPMIFMIOKK, char EAAIEEDJAHD)
		{
			return '\0';
		}

		public void Set(long NJJFDENHGKK, long AFPHABFLEBN = 0L, bool EFCHGPAGNLL = false, int? PPEFGCDIOAL = null, EventListModel CBDBDEIIOKG = null)
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public global::NCOKFFGPIJM<int> GetInterestedResponseCount()
		{
			return null;
		}

		public int GetCurrentlyBroadcastingCount()
		{
			return 0;
		}

		public void TryStartBroadcasting()
		{
		}

		public void TryStopBroadcasting()
		{
		}

		public void TryRequestBroadcastingAuthorization()
		{
		}

		public void ShowAllBroadcasters()
		{
		}

		public void ManageBroadcasters()
		{
		}

		private static void HBCBJGDLEKH(Player EKOFNPFCLMO)
		{
		}

		private static string IJLIJGFCKJF(Player EKOFNPFCLMO, BroadcastingManager.DNGGEIPPHLG? EONGELGDICL)
		{
			return null;
		}

		private void JJJMMHCBPCE()
		{
		}

		private IEnumerable<Player> IMFCMANFGKM()
		{
			return null;
		}

		private static void AMNDINBJIHN(Player EKOFNPFCLMO, BroadcastingManager.CGOKGJPDIAF LMCAEKEFKCH)
		{
		}

		private static void HLLKBJAGCHG(Player EKOFNPFCLMO)
		{
		}

		public void ShareEventCode()
		{
		}

		public void JoinEvent()
		{
		}

		public void CreatePrivateEventInstance()
		{
		}

		public void ChangeRSVP(HHAPNEKGMEP MBKKJGCIFMK)
		{
		}

		private void OJGPLMMLJML(IMIJPHJKLIM IGGPIMCKMBP)
		{
		}

		private void MKONMEHGFNN(IMIJPHJKLIM IGGPIMCKMBP, IEEOJIDNBLP MMHAGFMGBPC)
		{
		}

		private void LBEJHKDIPNM(IMIJPHJKLIM IGGPIMCKMBP, IEEOJIDNBLP MMHAGFMGBPC)
		{
		}

		private void AMOBMOCPGDM(int EJIHLJJMOBD)
		{
		}

		private void MJGPHBGDHDJ(Player EKOFNPFCLMO)
		{
		}

		private void JPOMDJGGMOM(Player EKOFNPFCLMO)
		{
		}

		private void NEKLLILPING()
		{
		}

		private void EFAFIEDDEBF((long, int) PCPEJHIMHJJ)
		{
		}

		private void DILBKEOEBPK()
		{
		}

		public string GetEventImageName()
		{
			return null;
		}

		private void MPHINBNLJHH()
		{
		}

		private IEnumerator<EGGPGCCKPCO> ACCIKPIBOIC(DateTime BKPKOGBFMFG)
		{
			return null;
		}

		[CompilerGenerated]
		private bool MKGFEJNMCFA(string FCCGDNMAHPA)
		{
			return false;
		}

		[CompilerGenerated]
		private void IKLEEOLPEDK(string LOKKJFCDNHB)
		{
		}

		[CompilerGenerated]
		private void DOIOJPJIMIN(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private void MEBODPHJKBH(string PEHCJFEPFJN)
		{
		}

		[CompilerGenerated]
		private bool OHKAPLEKKGK(string FCCGDNMAHPA)
		{
			return false;
		}

		[CompilerGenerated]
		private void GIBMNHBIDDN(List<string> CMBMOBEBGIN)
		{
		}

		[CompilerGenerated]
		private void LGFOBHAIKMJ()
		{
		}

		[CompilerGenerated]
		private bool OJGJIJFMKJH(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
			return false;
		}

		[CompilerGenerated]
		private bool BPKDDPKBBLO(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
			return false;
		}

		[CompilerGenerated]
		private void EGIPJNNFJBI(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void GOMFDHLFFHL(LCEKCFEIEGJ JDBHABEFGKF)
		{
		}

		[CompilerGenerated]
		private bool DBBAAFCEBDH(Player COLMAMKJPJE)
		{
			return false;
		}

		[CompilerGenerated]
		private void FGMIGNCCHJP(NCBAEFEDLMK INPMFIICIKB)
		{
		}

		[CompilerGenerated]
		private void JGMDNENDOFP(IMIJPHJKLIM IGGPIMCKMBP)
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN BAALKCMAIHL(IMIJPHJKLIM IGGPIMCKMBP)
		{
			return null;
		}

		[CompilerGenerated]
		private void HGHPAFDFDJA(DFDECAEJBIO ACBGBAAHOIM)
		{
		}

		[CompilerGenerated]
		private void IFAFLIEDMOP(JCDPHCELKHI KPFNANKNKLE)
		{
		}

		[CompilerGenerated]
		private void IAOINEBIGDO(EPILDIJELPG DHNNLHJMKIH)
		{
		}
	}
}
