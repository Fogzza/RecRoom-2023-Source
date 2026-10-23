using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class MessagesWatchUIFlow : WatchUIFlow
	{
		private enum HJLMNNNNEHM
		{
			DELETE_ALL_NOTIFICATIONS_BODY_SINGULAR = 0,
			DELETE_ALL_NOTIFICATIONS_BODY_PLURAL = 1,
			DELETE_ALL_NOTIFICATIONS_TITLE = 2
		}

		[SerializeField]
		private MessagesScreenItem itemTemplate;

		[SerializeField]
		private AnnouncementsScreenItem announcementTemplate;

		[SerializeField]
		private RectTransform contentPanel;

		[SerializeField]
		private Transform pageNumberPanel;

		[SerializeField]
		private TextMeshProUGUI noNotificationsTextObject;

		[SerializeField]
		private string noNotificationsMessage;

		[SerializeField]
		private LocalizedString localizedNoNotificationsMessage;

		[SerializeField]
		private string noAnnouncementsMessage;

		[SerializeField]
		private Selectable previousPageButton;

		[SerializeField]
		private Selectable nextPageButton;

		[SerializeField]
		private TextMeshProUGUI currentPageText;

		[SerializeField]
		private TextMeshProUGUI totalPagesText;

		[SerializeField]
		private int itemsPerPage;

		[SerializeField]
		private int largeItemsPerPage;

		private global::BGFDKFCGFDO<DMAIEODHOGA> GINJGPAHLMK;

		private global::BGFDKFCGFDO<HEDHPBBBLKG> FAFMGLNMKFC;

		[SerializeField]
		private RadioButton3D notificationsButton;

		[SerializeField]
		private RadioButton3D announcementsButton;

		[SerializeField]
		private RadioButton3D chatButton;

		[SerializeField]
		private Transform clearAllNotificationsButtonRoot;

		[SerializeField]
		private Transform showNotificationsConfigButtonRoot;

		[SerializeField]
		private SubscreenControl subscreenControl;

		[SerializeField]
		private Subscreen notificationsAndAnnouncementsSubscreen;

		private readonly List<DMAIEODHOGA> KCAFECEHLLK;

		private int OFJODMDPOOI;

		private bool KBPDNKFFPPA;

		private bool IAEBAGDJIKI;

private global::BGFDKFCGFDO<DMAIEODHOGA> ODPJHLBGEDG
{
get 		{
			return null;
		}

}

private global::BGFDKFCGFDO<HEDHPBBBLKG> DAPDMFGAGJL
{
get 		{
			return null;
		}

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

		private void PBDHJJJOHBL(Subscreen HKBLOCHFDOH, Subscreen BFLJJAMBILE)
		{
		}

		private bool KECMKBBIJBI()
		{
			return false;
		}

		private void OEAMKLADGBM()
		{
		}

		private void DMHNIGEAKOP()
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		private void GMDNAAFFKPK()
		{
		}

		protected override void KMCIKAHLOHC(OMNLIPPAPDI CAPKFCHDLFA, bool IHLDMKBBMHJ)
		{
		}

		private void MFLLIOEEMKG()
		{
		}

		private void BLKGPLLEJFE(PIMDBGKAIBE.MMANGNBCADN EIKNIKMJMOP, DMAIEODHOGA OFCFPGACNJB)
		{
		}

		private void BLKGPLLEJFE(PIMDBGKAIBE.MMANGNBCADN EIKNIKMJMOP, IReadOnlyList<DMAIEODHOGA> OBDPGGPGHBB)
		{
		}

		private void PJEOLKGLODL()
		{
		}

		private void GLBPPAIACJF()
		{
		}

		private void BAHEFJOEFJJ(int AAGJANDDPGM, int BGBHPKMGOND, int KIOCCMKBCMG)
		{
		}

		public void Button_ShowAnnouncementsList()
		{
		}

		public void Button_ShowNotificationsList()
		{
		}

		public void Button_PreviousPage()
		{
		}

		public void Button_NextPage()
		{
		}

		public void Button_ClearAllNotifications()
		{
		}

		public void Button_ShowNotificationConfig()
		{
		}

		public void Button_GoToChat()
		{
		}

		[CompilerGenerated]
		private void BHBLACEIJBK(HGKINAOMNIF GOJCEBCMFJK)
		{
		}

		[CompilerGenerated]
		private void POHMBKGJECK()
		{
		}
	}
}
