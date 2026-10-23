using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using RRUI.Data;
using RRUI.Navigation;
using RecRoom.AGUI;
using RecRoom.Audio;
using RecRoom.Avatars.Data.Runtime;
using RecRoom.Core.UI;
using RecRoom.Players.Watch;
using RecRoom.Utils.Image;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Core
{
	public class WatchUI : StackedUIBase, PDMHOEKMCMI, JCHEJJCHBKN
	{
		private enum HOEGNJLDIDI
		{
			NOTIF_ROOM_TRANSLATIONS_READY = 0
		}

		private sealed class LFMLNEPFKCB
		{
			public RRUIRootScreen RRUIRoot;

			internal bool _003Cget_IsOnRRUIStandalonePage_003Eb__0(Route route)
			{
				return false;
			}
		}

		private sealed class HAJKGCNHNON : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WatchUI _003C_003E4__this;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public HAJKGCNHNON(int _003C_003E1__state)
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

		private sealed class LBIBDIIAIHG
		{
			public BrowserModel browserModel;

			internal bool _003COnConfirmationDialogDismissed_003Eb__1()
			{
				return false;
			}
		}

		private sealed class EEDAFPCOIOD<DialogType, ResponseType> where DialogType : UIDialog<ResponseType>
		{
			public DialogType newDialog;

			internal void _003CShowTemporaryDialog_003Eb__0()
			{
			}
		}

		private sealed class OPALCLALJNG<R>
		{
			public UIDialog<R> newDialog;

			internal void _003CShowTemporaryDialog_003Eb__0()
			{
			}
		}

		private sealed class CPNANCBLGNH<T1, R>
		{
			public UIDialog<T1, R> newDialog;

			internal void _003CShowTemporaryDialog_003Eb__0()
			{
			}
		}

		private sealed class LJIGLAIGKEG<T1, T2, R>
		{
			public UIDialog<T1, T2, R> newDialog;

			internal void _003CShowTemporaryDialog_003Eb__0()
			{
			}
		}

		private sealed class MPJBJCBHANK<T1>
		{
			public ConfirmUIDialog<T1> newDialog;

			internal void _003CShowTemporaryConfirmationDialog_003Eb__0()
			{
			}
		}

		private sealed class CMACNACLGJN<T1, T2>
		{
			public ConfirmUIDialog<T1, T2> newDialog;

			internal void _003CShowTemporaryConfirmationDialog_003Eb__0()
			{
			}
		}

		private sealed class OACJLOMPKEL
		{
			public Action onComplete;

			internal void _003CShowBirthdayDialog_003Eb__0(DateTime? dob)
			{
			}
		}

		private sealed class EEMJBMOAOIG
		{
			public WatchUI _003C_003E4__this;

			public DMAIEODHOGA message;

			internal void _003CShowMessageDialog_003Eb__0()
			{
			}

			internal void _003CShowMessageDialog_003Eb__1(string error)
			{
			}
		}

		private sealed class NAOPLGLAFJJ
		{
			public DMAIEODHOGA msg;

			public DBIPHDIEBCM promise;

			internal void _003CValidateMessage_003Eb__0(OEBAEGDPBLA invention)
			{
			}
		}

		private sealed class ACAMGGHJBOM
		{
			public StackedUIFlowBase newFlow;

			internal void _003CShowTemporaryFlow_003Eb__0(bool stillOnStack)
			{
			}
		}

		private sealed class ELEHNEPFPDB
		{
			public DFDECAEJBIO targetAccount;

			internal void _003CShowPlayerReportScreen_003Eb__0(ReportWatchUIFlow reportFlow)
			{
			}
		}

		private sealed class KMICLIEGCGN
		{
			public string amplitudeCommandContext;

			internal void _003CShowReportScreen_003Eb__0(ReportWatchUIFlow flow)
			{
			}
		}

		private sealed class HNNPGBGMFID
		{
			public ReportWatchUIFlow reportFlow;

			internal void _003CCreateReport_003Eb__2()
			{
			}
		}

		private sealed class GJLGDKEOCPG
		{
			public int reportedAccountId;

			public IBPKDJLFBHM.OMLBCKDFMHL category;

			public bool playerPresent;

			public string amplitudeCommandContext;

			internal LAHBDKNMNHN _003CCreatePlayerReport_003Eb__1(BJMGAOAAKMM okResponse)
			{
				return null;
			}
		}

		private sealed class POMKNEGHPGL
		{
			public int reportedAccountId;

			public string description;

			internal LAHBDKNMNHN _003CCreateClothingReport_003Eb__1(List<AvatarItemSelection> outfit)
			{
				return null;
			}
		}

		private sealed class MJADPOMNGDP
		{
			public Guid? reportedItemId;

			internal void _003CSubmitClothingItemReport_003Eb__2()
			{
			}
		}

		private sealed class APENOFCKJHN
		{
			public int playerId;

			public WatchUI _003C_003E4__this;

			public Action<BulkAccountSelectionDialog.GGLKDINOLHA> _003C_003E9__3;

			internal void _003CShowIntroduceFriendsDialog_003Eb__0(DFDECAEJBIO account)
			{
			}

			internal void _003CShowIntroduceFriendsDialog_003Eb__3(BulkAccountSelectionDialog.GGLKDINOLHA r)
			{
			}
		}

		private sealed class KCINJGHBEGA
		{
			public DFDECAEJBIO account;

			public APENOFCKJHN CS_0024_003C_003E8__locals1;

			internal void _003CShowIntroduceFriendsDialog_003Eb__1(List<EOKKPHLOBBD> mutualFriends)
			{
			}
		}

		private sealed class PIFCNGAICLI : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public WatchUI _003C_003E4__this;

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
			public PIFCNGAICLI(int _003C_003E1__state)
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

		private sealed class ICEBFHCFIMO
		{
			public bool rejoinOffered;

			public WatchUI _003C_003E4__this;

			internal void _003CInitializeWatch_003Eb__0(bool value)
			{
			}

			internal void _003CInitializeWatch_003Eb__1()
			{
			}
		}

		private sealed class NGEGHKOLFME
		{
			public WatchUI _003C_003E4__this;

			public global::PHLHFLLLDLK<bool> rejoinOfferedPromise;

			public ICEEEAHNICK.RejoinData rejoinData;

			public Func<RRUIRootScreen> _003C_003E9__4;

			internal void _003CHandleRoomRejoinOfferAsync_003Eg__HandleRejoinOffer_007C0(int rejoinDataSequenceNumber, Func<RRUIRootScreen> showUIFunc)
			{
			}

			internal void _003CHandleRoomRejoinOfferAsync_003Eb__1(NCBAEFEDLMK playerEventDetails)
			{
			}

			internal RRUIRootScreen _003CHandleRoomRejoinOfferAsync_003Eb__4()
			{
				return null;
			}

			internal RRUIRootScreen _003CHandleRoomRejoinOfferAsync_003Eb__2()
			{
				return null;
			}
		}

		private sealed class CIDMIBEJHLN
		{
			public NCBAEFEDLMK playerEventDetails;

			public NGEGHKOLFME CS_0024_003C_003E8__locals1;

			internal RRUIRootScreen _003CHandleRoomRejoinOfferAsync_003Eb__3()
			{
				return null;
			}
		}

		private sealed class PBIECCMPAPL
		{
			public WatchUI _003C_003E4__this;

			public FMEDMCFGHFM thread;

			internal void _003CCreateRateLimiterForChatThreadDisplayNotification_003Eb__0()
			{
			}
		}

		private sealed class LOMBDBCFEBM
		{
			public WatchUI _003C_003E4__this;

			public DMAIEODHOGA message;

			public string formatString;

			public NotificationManager.MAOKONFJDIM notificationType;

			public string quickAcceptPrompt;

			internal void _003CSendFromAccountFormattedWatchNotification_003Eb__0(DFDECAEJBIO senderAccount)
			{
			}
		}

		private sealed class IIGLNIPFKLP
		{
			public WatchUI _003C_003E4__this;

			public DMAIEODHOGA message;

			public Action _003C_003E9__1;

			internal void _003CSendWatchNotification_003Eb__0()
			{
			}

			internal void _003CSendWatchNotification_003Eb__1()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct BPNBFBPGLMK
		{
			public Transform watchUITransform;

			public bool active;

			public Transform canvasTransform;
		}

		private sealed class OAIMEENJDDM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public WatchUI _003C_003E4__this;

			private LBIBDIIAIHG _003C_003E8__1;

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
			public OAIMEENJDDM(int _003C_003E1__state)
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

		private static IILDCCEMGBA PBGJGLECDCA;

		public const string SIZE_CONFIG_KEY = "WATCH";

		[SerializeField]
		private UnityEngine.Object oldHomeScreen;

		[SerializeField]
		private UnityEngine.Object newHomeScreen;

		[SerializeField]
		private MeasurePlayerHeightModel measurePlayerHeightModel;

		[SerializeField]
		private RecRoomAudioClip buttonDownAudio;

		[SerializeField]
		private RecRoomAudioClip buttonUpAudio;

		[SerializeField]
		private RecRoomAudioClip watchOpenedAudio;

		[SerializeField]
		private RecRoomAudioClip watchClosedAudio;

		[SerializeField]
		private BoxCollider watchBoxCollider;

		[SerializeField]
		private BasicInteractionRestriction basicInteractionRestriction;

		[SerializeField]
		private Image backgroundImage;

		private Material MMBCJODDBEN;

		private Material JEDPACNMPJO;

		private static readonly int BEFIKCOGKFI;

		private static readonly int NOKANPGMPNI;

		private static readonly int AKMHGGMDIOD;

		public bool EligibleForAutoCloseOnConfirmationResponse;

		private List<WatchUIFlow> FICBDPLJOFK;

		public static EEANDDJEMJC OnWatchInitializedEvent;

		private UIAnchor KLNNMHEKJLN;

		private DMAIEODHOGA EHIENMLMIJI;

		private FMEDMCFGHFM CIBABIGNBEM;

		private const int HEBANGJFNNI = 5;

		private const float LMPDBOAMIBG = 7f;

		private bool OHHKOPANICA;

		private Action<WatchUI, bool> EKFNNHIPJFF__BackingField;

		private FIHGBEHGLGB LABBLOPMFFO;

		private WatchMenuProjector AMNNJNDBCLF;

		private bool? HADJMHFOFCH;

		private const string FDDLJDEJPEK = "rrui_notifications_enabled";

		private bool? JLOABFJAPCD;

		private const string GPDGMDDKFEK = "rrui_people_menu_enabled";

		private bool? PODGICHJJEN;

		private const string ACKJDGOEIGG = "experience_q1_always_open_last_notification";

		private const string PMENMGLGPMP = "open_last_message_on_watch_open";

		private bool? PBBFHKPCJIB;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private FEIKFKAICHC HKNAHLAFLPC;

		private const string HGCEOJEBAPM = "watch_layer";

		private const string HNNBLAPIODE = "new_watch_architecture_enabled";

		public const string UseRRUIHomeScreenKey = "RRUI.UseRRUIHomeScreen";

		private SFXAudioSource LMPCHINDDFG;

		private SFXAudioSource JNKBFPOPAJI;

		private const string AEEJJBKEJID = "No";

		private const string CICMGHGAGNN = "Later";

		private bool DFAJIMLABGB;

		private static LFHHMEALLBA ENDNIAFGGDI;

		private static readonly Dictionary<DGFHKEBHIFF, string> BPLDKAPLFFJ;

		public static global::BPEPJJDICII<DGFHKEBHIFF, string> OnToastUpdatedEvent;

		private bool OEAONLGBBPN;

		private RRUIRootScreen LDLKECEFJCI;

		private int? DEANANFJDGJ;

		private Dictionary<long, MPBBNJKOEPO> IDGGHGANPPH;

		private const float DBINBAMBLEN = 30f;

private static IILDCCEMGBA DAFPCOCAEOE
{
get 		{
			return null;
		}

}

public static WatchUI Local
{
get 		{
			return null;
		}

}

public MeasurePlayerHeightModel MeasurePlayerHeightModel
{
get 		{
			return null;
		}

}

public BoxCollider WatchBoxCollider
{
get 		{
			return null;
		}

}

public BasicInteractionRestriction BasicInteractionRestriction
{
get 		{
			return null;
		}

}

private bool CBEBELMCMCO
{
get 		{
			return false;
		}

}

public UIConfirmationDialog ConfirmationDialog
{
get 		{
			return null;
		}

}

private UIMessageDialog AJCKMDMOJBN
{
get 		{
			return null;
		}

}

private UIVoteDialog GANPFGLCAHA
{
get 		{
			return null;
		}

}

private UIImportFriendsDialog FDLGPFGKFIP
{
get 		{
			return null;
		}

}

private UIBirthdayDialog CABEBCMJPLI
{
get 		{
			return null;
		}

}

private UIAgeDialog HDEAAEMEONG
{
get 		{
			return null;
		}

}

private IntroduceFriendsDialog EOKACNMLHEM
{
get 		{
			return null;
		}

}

private Material IPLDLLIJJNL
{
get 		{
			return null;
		}

}

public bool HasNewMessage
{
get 		{
			return false;
		}

}

public bool HasNewChatMessage
{
get 		{
			return false;
		}

}

public Color BackgroundColor
{
get 		{
			return default;
		}

}

public bool LockedToCurrentScreen
{
get 		{
			return false;
		}

set {
		}
}

public bool AreMessagesPaused
{
get 		{
			return false;
		}

}

public WatchMenuProjector WatchMenuProjector
{
get 		{
			return null;
		}

}

public bool IsInitialized
{
get 		{
			return false;
		}

}

public bool IsOnRRUIStandalonePage
{
get 		{
			return false;
		}

}

protected override string NPNGNBNICFF
{
get 		{
			return null;
		}

}

public bool UseRRUIHomeScreen
{
get 		{
			return false;
		}

}

public bool UseRRUINotificationsScreen
{
get 		{
			return false;
		}

}

public bool UseRRUIEventsScreen
{
get 		{
			return false;
		}

}

public bool UseRRUIPeopleScreen
{
get 		{
			return false;
		}

}

private bool JPNIHCMHDOM
{
get 		{
			return false;
		}

}

public bool UseNewWatchArchitecture
{
get 		{
			return false;
		}

}

public event Action<WatchUI, bool> IsInMinimalSettingsModeChanged {
add {
		}
remove {
		}
}

		public void ClearLastMessage()
		{
		}

		public void ClearLastChatThread()
		{
		}

		public bool GetIsInMinimalSettingsMode()
		{
			return false;
		}

		public void PauseMessages(object IALNODEHBNN)
		{
		}

		public void UnpauseMessages(object IALNODEHBNN)
		{
		}

		private void GIGJIBJKKIH(bool OGJJKOBACOA)
		{
		}

		private static void JCBEJCHIJFI()
		{
		}

		private static void GBEILGJPHID()
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override FlowPrefabResourceReference GCNODPLEIKH()
		{
			return null;
		}

		protected override void GGAKOMGHAGK(StackedUIFlowBase ELNPJBMKDAE)
		{
		}

		protected override void DGPFMFMJNEL(StackedUIFlowBase ELNPJBMKDAE)
		{
		}

		protected override bool NNJNFCGMJKG()
		{
			return false;
		}

		protected override bool GKFDOKDBIBF()
		{
			return false;
		}

		protected override void HCMBCGIBFGA(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool FHAGPHDEEGA)
		{
		}

		private void IBGANNBJPOC<T>(T NJCCDKGIAPI, bool IPMIIEAGJKC) where T : StackedUIFlowBase
		{
		}

		protected override void DNPOGCFJOAC()
		{
		}

		protected override void KHOACLMDKOG()
		{
		}

		protected override void JFAFAIMKJKL()
		{
		}

		private IEnumerator KJBMNLPJHLJ()
		{
			return null;
		}

		public RRUIRootScreen ShowRoomDetails(long KEBHGEHMMGO, BNKIKFBACEL NIFOGEBEDNG, DBECJLAIPEL CFBNOKOADFB, bool HHPJOMNOHPC = true)
		{
			return null;
		}

		public RRUIRootScreen ShowEventDetails(NCBAEFEDLMK INPMFIICIKB)
		{
			return null;
		}

		public RRUIRootScreen ShowEventDetails(NCBAEFEDLMK INPMFIICIKB, bool HHPJOMNOHPC)
		{
			return null;
		}

		public void ShowEventCreateForClub(long AFPHABFLEBN)
		{
		}

		public void ShowEventSetup(NCBAEFEDLMK INPMFIICIKB = null)
		{
		}

		public void ShowEventSettings(NCBAEFEDLMK INPMFIICIKB)
		{
		}

		public void ShowEventInvites(NCBAEFEDLMK INPMFIICIKB)
		{
		}

		public void ShowEventReportDialog(NCBAEFEDLMK INPMFIICIKB)
		{
		}

		public void ShowTokenStore(string PGEIBONDJJP, bool HGLNDEOCGNE = true)
		{
		}

		public void ShowRRPlusSignUp(string PGEIBONDJJP, bool KLEHGPMGPHM = true, EEANDDJEMJC AMFKAIJIABD = null, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD = POPLPJGHHIA.EGCCHLKLIIL.None)
		{
		}

		public void ShowInventionStore()
		{
		}

		public void ShowInventionDetails(long KBPFKPGOCFN, string PGEIBONDJJP, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowItemDetails(int IEGHJNDINMO, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowCustomAvatarItemDetails(Guid JGNABAMMKMP, PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG)
		{
		}

		public void ShowCustomAvatarItemStorePage(Guid JGNABAMMKMP, bool AMBLGCPNOEK, PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG)
		{
		}

		public void ShowCustomAvatarItemDetails(Guid JGNABAMMKMP, ManagedTexture MDNCPEOLOJF, Color HMCAFGCGFJF, PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG)
		{
		}

		public void ShowInventionSearch(List<string> GALCLCJNKMM, string PGEIBONDJJP, string NIOBDAGDJAE, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowStoreItemSearch(string NIOBDAGDJAE, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowCustomAvatarItemSearch(PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG, string NIOBDAGDJAE)
		{
		}

		public void ShowStorefront(string OHBLPAKAJKE, string IHAJMCMKENO, PJGPBJDBNEK.BDOPNLLKBPB OKAPDIKNLCA)
		{
		}

		public void ShowWatchStoreTab(string PGEIBONDJJP)
		{
		}

		public void ShowChat()
		{
		}

		public void ShowWatchStore(string PGEIBONDJJP, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowGoToStoreDialog(string ANJAOEPDJML, string FOKHCBODMCD)
		{
		}

		public LAHBDKNMNHN ShowSkuPurchaseSuccessDialog(string OFMGPNLDCAB, string GKHMKKBKEKC, bool IGDMDHFNMPF)
		{
			return null;
		}

		public void ShowWatchStoreClothing(int MBEMMAGIHIH)
		{
		}

		public void ShowStarterPackDetails(POPLPJGHHIA.OCDCJKGHBON EEFFOCCPECD, string PGEIBONDJJP, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD = POPLPJGHHIA.EGCCHLKLIIL.None)
		{
		}

		public void GoToStarterPackDetails(POPLPJGHHIA.OCDCJKGHBON EEFFOCCPECD, string PGEIBONDJJP, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD = POPLPJGHHIA.EGCCHLKLIIL.None)
		{
		}

		public void TryShowEscapeMenu()
		{
		}

		public void ShowRoomCurrencyStorePage(Guid DJOFODHJEBF, bool JPHFBJCBOIM = true, string NNECEELJHMM = null)
		{
		}

		public void ShowRoomCurrenciesCreatePage(long EPOBIFCHLNM)
		{
		}

		public void ShowKeyStorePage(Guid IBFKGINGICK, EEANDDJEMJC HPBHPGBHAOG = null, bool JPHFBJCBOIM = true, string NNECEELJHMM = null)
		{
		}

		public void ShowInThisRoomBackpackPage()
		{
		}

		public void ShowProgressionEventTutorialCompletedDialog()
		{
		}

		public void ShowRoomConsumableStorePage(Guid JNHIIPBPEOB, bool JPHFBJCBOIM = true, string NNECEELJHMM = null)
		{
		}

		public void ShowRoomConsumablesCreatePage(long EPOBIFCHLNM)
		{
		}

		public void ShowRoomKeysCreatePage(long EPOBIFCHLNM)
		{
		}

		public void ShowSavedOutfitsPage()
		{
		}

		public void ShowRecRoomPlusPage(string PGEIBONDJJP, EEANDDJEMJC AMFKAIJIABD = null, bool OPKEFNEECKK = true)
		{
		}

		public T GoTo<T>(string LDPCFDMCJLH = null) where T : StackedUIFlowBase
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmationDialog(string BOGCJKAMALE, string HGIIJBKEGMK)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmationDialog(string BOGCJKAMALE, string HGIIJBKEGMK, bool EKCLFLADBED)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmationDialog(UIConfirmationDialog.EPIGOMCICOG HNPFAOFHHII, string BOGCJKAMALE, string HGIIJBKEGMK)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmationDialog(UIConfirmationDialog.EPIGOMCICOG HNPFAOFHHII, string BOGCJKAMALE, string HGIIJBKEGMK, string EMBGGBCIFOI, string JLCJLNNHFLO = "No", string ADMBJPIEGBI = "Later", NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT, bool EKCLFLADBED = true, bool PFJNOBINFCN = true)
		{
			return null;
		}

		public static void OpenWatchAndEnableAutoCloseIfAppropriate(WatchUI CPELKAGLFFJ, ref bool CMPOPJAEMOF, bool EKCLFLADBED = true, bool PFJNOBINFCN = true)
		{
		}

		public static bool IsConfirmationFlow(StackedUIFlowBase ELNPJBMKDAE)
		{
			return false;
		}

		private void GCLGPLOELMK()
		{
		}

		private void KBLEHEENBHD()
		{
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowRRUIConfirmationPage(string BOGCJKAMALE, string HGIIJBKEGMK)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowRRUIConfirmationPage(UIConfirmationDialog.EPIGOMCICOG HNPFAOFHHII, string BOGCJKAMALE, string HGIIJBKEGMK, Sprite DLADPCHJMME = null)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowRRUIConfirmationPage(UIConfirmationDialog.EPIGOMCICOG HNPFAOFHHII, string BOGCJKAMALE, string HGIIJBKEGMK, string EMBGGBCIFOI, string JLCJLNNHFLO = "No", string ADMBJPIEGBI = "Later", Sprite DLADPCHJMME = null, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT, bool EKCLFLADBED = true, bool PFJNOBINFCN = true)
		{
			return null;
		}

		public global::NCOKFFGPIJM<ICABNBCOLBH> ShowRRUIMultipleChoicePage(string BOGCJKAMALE, string HGIIJBKEGMK, string[] LLHKNIGMDOL)
		{
			return null;
		}

		public void BrowserModelDialogListDismissDialog()
		{
		}

		public global::NCOKFFGPIJM<ResponseType> ShowTemporaryDialog<DialogType, ResponseType>(DialogType HAAJEFICEGC, Func<DialogType, global::NCOKFFGPIJM<ResponseType>> NBDEDGNGODF, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT) where DialogType : UIDialog<ResponseType>
		{
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<R>(UIDialog<R> HAAJEFICEGC, out UIDialog<R> LCPOJOKEPGJ, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
			LCPOJOKEPGJ = null;
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<R>(UIDialog<R> HAAJEFICEGC, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<T1, R>(UIDialog<T1, R> HAAJEFICEGC, T1 AKPPKIEAJHD, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<T1, R>(UIDialog<T1, R> HAAJEFICEGC, T1 AKPPKIEAJHD, out UIDialog<R> LCPOJOKEPGJ, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
			LCPOJOKEPGJ = null;
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<T1, T2, R>(UIDialog<T1, T2, R> HAAJEFICEGC, T1 FMLCCJGJPCD, T2 MPCLNGKHMLO, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<T1, T2, R>(UIDialog<T1, T2, R> HAAJEFICEGC, T1 FMLCCJGJPCD, T2 MPCLNGKHMLO, out UIDialog<R> LCPOJOKEPGJ, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
			LCPOJOKEPGJ = null;
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowTemporaryConfirmationDialog<T1>(ConfirmUIDialog<T1> HAAJEFICEGC, T1 FMLCCJGJPCD, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT, string LDPCFDMCJLH = null)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowTemporaryConfirmationDialog<T1, T2>(ConfirmUIDialog<T1, T2> HAAJEFICEGC, T1 FMLCCJGJPCD, T2 MPCLNGKHMLO, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT, string LDPCFDMCJLH = null)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmDialog<T1, T2, T3>(ConfirmUIDialog<T1, T2, T3> GDMKJGAKCND, T1 FMLCCJGJPCD, T2 MPCLNGKHMLO, T3 KPIDGAICEOB, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.NONE)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowGoToSubroomDialog(LCEKCFEIEGJ BBHINKGKDBL, HHCLMHEOLDA APFMLJLPMJD, bool OCPLEECEEHL, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowChooseSubroomDialog(LCEKCFEIEGJ BBHINKGKDBL, Action<OPKEAIOICLJ> ONAFALABHKI)
		{
			return null;
		}

		public void ShowVoteDialog()
		{
		}

		public void ShowRoomCalibrationDialog()
		{
		}

		public global::NCOKFFGPIJM<List<JJGPKBPPDHH>> ShowImportFriendsDialog(List<JJGPKBPPDHH> MKACDMNEGNA, OILDLLGEMKP.LKLLEIKDHDD GLLFHCCFIGK)
		{
			return null;
		}

		public global::NCOKFFGPIJM<DateTime?> ShowBirthdayDialog(string GFFOMHMCDGE, string JJNMPMOJLAA, DateTime? PMLJFBLGBMO, int? CDBKKOIFCBB, Action GGKGABPGHMO)
		{
			return null;
		}

		public global::NCOKFFGPIJM<int?> ShowAgeDialog(string GFFOMHMCDGE, string JJNMPMOJLAA, int? HFLCLOJIAOE, Action GGKGABPGHMO)
		{
			return null;
		}

		public bool ShowMessageDialog(DMAIEODHOGA OFCFPGACNJB)
		{
			return false;
		}

		private LAHBDKNMNHN LLLENELGEIC(DMAIEODHOGA MANKFIKGIGJ)
		{
			return null;
		}

		public void ShowLastMessageDialog()
		{
		}

		public void ShowLastChatThreadDialog()
		{
		}

		public void ShowMicSpamWarningDialog(string OFCFPGACNJB)
		{
		}

		public StackedUIFlowBase ShowTemporaryFlow(StackedUIFlowBase GDEKLMNKJBC, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
			return null;
		}

		public void ShowPlayerReportScreen(DFDECAEJBIO FDCLMAGDCFJ, string LDPCFDMCJLH)
		{
		}

		public void ShowReportScreen(string LDPCFDMCJLH, Action<ReportWatchUIFlow> OOHKNBNOLEL, Func<ReportWatchUIFlow, bool> IKGCNDGBKIE, Action LPFMLADCEEL)
		{
		}

		private static void ALBKHIDKMJJ(ReportWatchUIFlow JHCMPHLGEED, string LDPCFDMCJLH)
		{
		}

		private static LAHBDKNMNHN FHAAACGHHGM(int EDHGOGBIALM, IBPKDJLFBHM.OMLBCKDFMHL JNKJFJLJKNJ, string GKHMKKBKEKC, string LDPCFDMCJLH)
		{
			return null;
		}

		public static LAHBDKNMNHN CreateClothingReport(int EDHGOGBIALM, string GKHMKKBKEKC, string LDPCFDMCJLH)
		{
			return null;
		}

		private static LAHBDKNMNHN PPHCNOFPLKK(int EDHGOGBIALM, List<AvatarItemSelection> GPDDJBMKPNG, string GKHMKKBKEKC)
		{
			return null;
		}

		private global::NCOKFFGPIJM<HGKINAOMNIF> OEEOAIADGIH(LCEKCFEIEGJ BBHINKGKDBL, GIMKNIFBLME NPODHMILIGI)
		{
			return null;
		}

		public void ShowIntroduceFriendsDialog(int PCKCPNGPNBJ)
		{
		}

		public static void SetToast(DGFHKEBHIFF ALIOPIPDGDM, int BFFJHKFEFPP)
		{
		}

		public static void SetToast(DGFHKEBHIFF ALIOPIPDGDM, string HLIGBKANEEA)
		{
		}

		public static string GetToast(DGFHKEBHIFF ALIOPIPDGDM)
		{
			return null;
		}

		private void PPKOLGPELII(bool GJGODIHKAHN)
		{
		}

		private void ACPKKFHEMLD()
		{
		}

		private IEnumerator<EGGPGCCKPCO> IKDDMJPGMIJ()
		{
			return null;
		}

		private void FFKPBKLEHDP()
		{
		}

		private global::NCOKFFGPIJM<bool> KGBJHDPMIEF()
		{
			return null;
		}

		private void CAFPOLHNENN(bool IFLEKNIGFGM)
		{
		}

		private void GNBKFMOCOPG()
		{
		}

		public bool TryGetBackgroundColors(out Color PJELODKNJIN, out Color GDNDCPPHFME)
		{
			PJELODKNJIN = default;
			GDNDCPPHFME = default;
			return false;
		}

		public void SetBackgroundColors(Color PJELODKNJIN, Color GDNDCPPHFME)
		{
		}

		public void PlayAttract(NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
		}

		public void PlayAttract(NotificationManager.NCDNGNOMOFN LNLLMBOPHAI, NotificationManager.MAOKONFJDIM OFOMIMPGNJN, string GDOHHMMEKNO, string BDDPCJOHDGM = null)
		{
		}

		public void PlayAttractDelayed(float FHFDDKOBFLG, NotificationManager.NCDNGNOMOFN LNLLMBOPHAI = NotificationManager.NCDNGNOMOFN.ALL_BUT_TEXT)
		{
		}

		public void HandleIncomingChatMessage(FMEDMCFGHFM AAMFKNLLGDC)
		{
		}

		private void CHKJPGMAMCL(FMEDMCFGHFM AAMFKNLLGDC)
		{
		}

		private MPBBNJKOEPO KPFFLPGCALN(FMEDMCFGHFM FEDCNPJJGCF)
		{
			return null;
		}

		public void HandleIncomingRecNetMessage(DMAIEODHOGA OFCFPGACNJB)
		{
		}

		private global::NCOKFFGPIJM<DFDECAEJBIO> GNGFIMNGKCJ(DMAIEODHOGA OFCFPGACNJB, string CPJDECOOKBD, NotificationManager.MAOKONFJDIM OFOMIMPGNJN, string NAAJPACOBKF = null)
		{
			return null;
		}

		private void MGMJCMILHML(DMAIEODHOGA OFCFPGACNJB, string GFFOMHMCDGE, NotificationManager.MAOKONFJDIM OFOMIMPGNJN, string NAAJPACOBKF = null, int BFCFNCMBICC = -1)
		{
		}

		public void ToggleSize()
		{
		}

		public void AddScreenRequiredOnStack(WatchUIFlow OJBBAHEFAAA)
		{
		}

		public void RemoveScreenRequiredOnStack(WatchUIFlow OJBBAHEFAAA)
		{
		}

		private void NILNOPFIADH(bool BMGEHFPFCBJ)
		{
		}

		private void APLHNMMOGDM(Transform FGGHEMDECJO, bool FBHDABEFLKL)
		{
		}

		public void AuthorityOpenMenuDetached(bool COPOILGLIAJ)
		{
		}

		private static WatchUIFlow NPDICIIGMNL(DFDECAEJBIO ACBGBAAHOIM)
		{
			return null;
		}

		public static void ShowAccountUIAndPlayAttract(DFDECAEJBIO ACBGBAAHOIM, NotificationManager.MAOKONFJDIM OFOMIMPGNJN, string GDOHHMMEKNO, string BDDPCJOHDGM = null)
		{
		}

		public static void ShowAccountUI(DFDECAEJBIO ACBGBAAHOIM)
		{
		}

		private static WatchUI DLCIFENCJNB(WatchUIFlow ELNPJBMKDAE)
		{
			return null;
		}

		public static bool OpenWatchFlowAndPlayAttract(WatchUIFlow ELNPJBMKDAE, NotificationManager.MAOKONFJDIM OFOMIMPGNJN, string GDOHHMMEKNO, string BDDPCJOHDGM = null)
		{
			return false;
		}

		public static bool OpenWatchFlow(WatchUIFlow ELNPJBMKDAE)
		{
			return false;
		}

		private void IAIGIMFLGHN(StackedUIFlowBase ELNPJBMKDAE)
		{
		}

		private void FGGOFPIMNBM()
		{
		}

		[CompilerGenerated]
		private void DDEGOIEALEN(HGKINAOMNIF GOJCEBCMFJK)
		{
		}

		[CompilerGenerated]
		private IEnumerator<EGGPGCCKPCO> OOCMOECIFKB()
		{
			return null;
		}

		[CompilerGenerated]
		internal static bool LBLIIGEDPNC(Transform HBJOGBMJJAB, Transform PJIOHJLAHEO)
		{
			return false;
		}

		[CompilerGenerated]
		private static void LKPKGIKEEHO(ref BPNBFBPGLMK P_0)
		{
		}
	}
}
