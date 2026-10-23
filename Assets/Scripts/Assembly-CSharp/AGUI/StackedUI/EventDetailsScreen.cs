using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI.Dialog;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class EventDetailsScreen : WatchUIFlow
	{
		private sealed class MJGCIOCPECO
		{
			public EventDetailsScreen _003C_003E4__this;

			public long eventId;

			internal void _003CUpdateRsvpStatus_003Eb__0(HHAPNEKGMEP response)
			{
			}
		}

		[SerializeField]
		private PlayerEventSpecificUIBehaviour eventImageRoomWatcher;

		[SerializeField]
		private TextMeshProUGUI eventName;

		[SerializeField]
		private Button3D editEventNameButton;

		[SerializeField]
		private TextMeshProUGUI eventDescription;

		[SerializeField]
		private Button3D editEventDescriptionButton;

		[SerializeField]
		private TextMeshProUGUI eventTags;

		[SerializeField]
		private Button3D editEventTagsButton;

		[SerializeField]
		private TextMeshProUGUI locationText;

		[SerializeField]
		private TextMeshProUGUI clubText;

		[SerializeField]
		private TextMeshProUGUI timeText;

		[SerializeField]
		private TextMeshProUGUI dateText;

		[SerializeField]
		private ToggleButton3D yesToggle;

		[SerializeField]
		private TextMeshProUGUI yesCountText;

		[SerializeField]
		private ToggleButton3D interestedToggle;

		[SerializeField]
		private ToggleButton3D noToggle;

		[SerializeField]
		private PlayerInfoUIControl organizerInfo;

		[SerializeField]
		private Button3D organizerInfoButton;

		[SerializeField]
		private Button3D reportButton;

		[SerializeField]
		private Button3D inviteFriendsButton;

		[SerializeField]
		private GoToPlayerEventConditionalButton goToEventButton;

		[SerializeField]
		private PlayerEventGuestsPagedGrid guestsPagedGrid;

		[SerializeField]
		private Slider3D eventAccessibilitySlider;

		[SerializeField]
		private Button3D saveChangesButton;

		[SerializeField]
		private GameObject viewInstancesButton;

		[SerializeField]
		private TextMeshProUGUI editLocationText;

		[SerializeField]
		private TextMeshProUGUI editTimeText;

		[SerializeField]
		private TextMeshProUGUI editDateText;

		[SerializeField]
		private UIDateSelectionDialog datePickerPrefab;

		[SerializeField]
		private TimeRangeSelectionDialog timeRangePickerPrefab;

		[SerializeField]
		private ChooseEventLocationDialog locationPickerPrefab;

		[SerializeField]
		private EditPlayerEventTagsDialog editTagsDialog;

		[SerializeField]
		private RadioButton3D detailsButton;

		[SerializeField]
		private RadioButton3D setupButton;

		[SerializeField]
		private InviteFriendsDialog inviteFriendsDialogPrefab;

		[SerializeField]
		private UpdatePlayerEventNameDialog updateNameDialog;

		[SerializeField]
		private UpdatePlayerEventDescriptionDialog updateDescriptionDialog;

		[SerializeField]
		private UIReportEventDialog reportDialog;

		[SerializeField]
		private TextMeshProUGUI infoText;

		[SerializeField]
		private SubscreenControl subscreenControl;

		[SerializeField]
		private Subscreen detailsSubscreen;

		[SerializeField]
		private Subscreen guestsSubscreen;

		[SerializeField]
		private Subscreen setupSubscreen;

		private DFDECAEJBIO DLAMJIPNNCL;

		private NCBAEFEDLMK BAFHPMNNPBF;

		private AccountSpecificUIBehaviour[] HHNCPFNPCBN;

		private ChooseEventLocationDialog.KIMGKCKCMFO KPDIAFCCIFH;

		private TimeRangeSelectionDialog.GLEGFFOOPGA FPFOBLHNHND;

		private DateTime? NFDDOCAOBDC;

		private AAOMIMIAKGO? FJPNAPONCJI;

		private string LPJKCBCOICA;

		private string BJJKDACGPKC;

		private string NPFGECCGIIP;

		private RoomOrPlaylistSpecificUIBehaviour[] NKACBNPEEHG;

protected override string CIKPANGLFGP
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
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

		protected override bool AOOGCBCALDP()
		{
			return false;
		}

		protected override bool MIGHBFJHBPN()
		{
			return false;
		}

		private void PBDHJJJOHBL(Subscreen HKBLOCHFDOH, Subscreen BFLJJAMBILE)
		{
		}

		public void ShowScreen(NCBAEFEDLMK JDBHABEFGKF, bool ACFHMPDKHJG = true)
		{
		}

		private void CBNMJFECNFL()
		{
		}

		private void KBMBOOJGKCL(string AKOKILEPANJ)
		{
		}

		private void NLBAENAKFLO()
		{
		}

		private void NLBAENAKFLO(HHAPNEKGMEP MLDANHIGANI)
		{
		}

		private void NNMMHDPBPAG(string ALLOPBKEIAJ, bool CEKBHBBHDCG)
		{
		}

		private void KNHADOJPGLN()
		{
		}

		private void GEDAFKMBKFB()
		{
		}

		private void MOIABENJCJI()
		{
		}

		private void JIJGENCCBCB()
		{
		}

		private bool PKFHBHKEGJN()
		{
			return false;
		}

		private void GPAJGPHMIIO(int? EJIHLJJMOBD)
		{
		}

		private void NCJHBEHKHJK(HHAPNEKGMEP MLDANHIGANI, bool NCPDDNBABLF)
		{
		}

		private void OFECJDPCKNF(IMIJPHJKLIM IGGPIMCKMBP, IEEOJIDNBLP MLDANHIGANI)
		{
		}

		private void PDILPMIKDMB(IMIJPHJKLIM IGGPIMCKMBP, IEEOJIDNBLP MLDANHIGANI)
		{
		}

		private void FIBMMOOPJKG(NCBAEFEDLMK INPMFIICIKB)
		{
		}

		private void ABHOCGIGIGB(CJDHONMNJNA CDNLFEOBNKB)
		{
		}

		public void Button_EditName()
		{
		}

		public void Button_EditDescription()
		{
		}

		public void Button_EditImage()
		{
		}

		public void Button_EditTags()
		{
		}

		public void Toggle_RsvpYes(bool isOn)
		{
		}

		public void Toggle_RsvpInterested(bool isOn)
		{
		}

		public void Toggle_RsvpNo(bool isOn)
		{
		}

		public void Button_OrganizerInfo()
		{
		}

		public void Button_Report()
		{
		}

		public void ShowReportDialog()
		{
		}

		public void Button_DeleteEvent()
		{
		}

		public void Button_SaveChanges()
		{
		}

		public void Button_EditLocation()
		{
		}

		public void Button_EditDate()
		{
		}

		public void Button_EditTimeRange()
		{
		}

		public void Button_AccessibilityChanged()
		{
		}

		public void Button_ViewEventInstances()
		{
		}

		public void ShowSetupSubscreen()
		{
		}

		public void Button_InviteFriends()
		{
		}

		public void ShowInviteDialog(bool ACBJLNPFHGM = true)
		{
		}

		public void Button_ShowGuestAccount(DFDECAEJBIO account)
		{
		}

		public static AAOMIMIAKGO GetAccessibilityFromSlider(float BINCPCKFDFH)
		{
			return AAOMIMIAKGO.Private;
		}

		public static float GetSliderValueFromAccessibility(AAOMIMIAKGO HDECMIPFJEN)
		{
			return 0f;
		}

		[CompilerGenerated]
		private void GJFKHGLAMGJ(string FEEKDEIKPHM)
		{
		}

		[CompilerGenerated]
		private void JBGBLCAKABN(EPILDIJELPG APMHMCKALGG)
		{
		}

		[CompilerGenerated]
		private void MJNNFLGFEOK(DFDECAEJBIO ACBGBAAHOIM)
		{
		}

		[CompilerGenerated]
		private List<IEEOJIDNBLP> POLMAIBIGOC(List<IEEOJIDNBLP> GPGBEJBAIPB)
		{
			return null;
		}

		[CompilerGenerated]
		private bool FJLACGDMIPM(IEEOJIDNBLP GOJCEBCMFJK)
		{
			return false;
		}

		[CompilerGenerated]
		private void MNNGMJNCGCE(List<IEEOJIDNBLP> GPGBEJBAIPB)
		{
		}

		[CompilerGenerated]
		private void IAAFFABFPJP(CJDHONMNJNA CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void MCNJINCJALP(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void EBBJBDILOMF(CJDHONMNJNA CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void EELDJHKKFDI(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<GDCLLKJIJPJ> KFGAOAMFMJF(string NPOEAPJKNFN)
		{
			return null;
		}

		[CompilerGenerated]
		private void LJMPBIMBAPF(string PEHCJFEPFJN)
		{
		}

		[CompilerGenerated]
		private void CKMBBNFLDCO(HGKINAOMNIF MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void AJJEILBPMFB(HGKINAOMNIF MGJFACHBKHJ)
		{
		}

		[CompilerGenerated]
		private void CMAHILNJMOI(GDCLLKJIJPJ CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void PNBFFKAOGMJ(string HPOGIBBIGIG)
		{
		}

		[CompilerGenerated]
		private void ELLNICABMKE(ChooseEventLocationDialog.KIMGKCKCMFO KPFNANKNKLE)
		{
		}

		[CompilerGenerated]
		private void OKMGBFKCANO(DateTime? BEEAEBLMLIH)
		{
		}

		[CompilerGenerated]
		private void GPLABBPKNKH(TimeRangeSelectionDialog.GLEGFFOOPGA BMHHMBOMICL)
		{
		}
	}
}
