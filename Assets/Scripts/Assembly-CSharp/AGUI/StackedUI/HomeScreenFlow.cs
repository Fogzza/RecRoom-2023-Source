using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class HomeScreenFlow : WatchUIFlow
	{
		public enum PDIOCEBGKMP
		{
			DormRoom = 0,
			RecCenter = 1
		}

		private sealed class EDLPOOAGCCE<T> where T : StackedUIFlowBase
		{
			public HomeScreenFlow _003C_003E4__this;

			public Action<T> flowSetup;

			public Action<T> showFlow;

			internal void _003CSetButtonOnClick_003Eb__0()
			{
			}
		}

		private const string KPCOBIDALBC = "econ_q1_challenges_button_old_watch";

		private const string MJIMIHMLOCP = "show_gift_icon";

		[SerializeField]
		private Button3D profileButton;

		[SerializeField]
		private Button3D settingsButton;

		[SerializeField]
		private Button3D partyButton;

		[SerializeField]
		private Button3D browseRoomsButton;

		[SerializeField]
		private Button3D eventsButton;

		[SerializeField]
		private Button3D createRoomButton;

		[SerializeField]
		private Button3D thisRoomButton;

		[SerializeField]
		private Button3D thisEventButton;

		[SerializeField]
		private Button3D peopleButton;

		[SerializeField]
		private Button3D messagesButton;

		[SerializeField]
		private Button3D checklistButton;

		[SerializeField]
		private Button3D backpackButton;

		[SerializeField]
		private Button3D clubsButton;

		[SerializeField]
		private Button3D storeButton;

		[SerializeField]
		private Button3D evictAllButton;

		[SerializeField]
		private Button3D dormRoomButton;

		[SerializeField]
		private Button3D recCenterButton;

		[SerializeField]
		private Button3D streamingButton;

		[SerializeField]
		private Button3D exitButton;

		[SerializeField]
		private GameObject reportBugButtonSpacer;

		[SerializeField]
		private GameObject debugButtonSpacer;

		[SerializeField]
		private RectTransform devMenuPanel;

		[SerializeField]
		private Button3D devButtonPrefab;

		[SerializeField]
		private PlayerAccountUIControl playerAccountUIControl;

		[SerializeField]
		private Image checklistButtonIcon;

		[SerializeField]
		private Sprite activeKeepsakeEventIcon;

		private Dictionary<Type, Button3DBase> EJCHLKDDIII;

		private bool NCOFJGFCGEF;

		private LMNOCCKEMKH IIOMBMAEKDF;

		private GNKIEJFAGCI MFJAOLJEAGL;

		private LAHBDKNMNHN BPFHAGPBIID;

private bool KOCGJNNCOCO
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
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

		private void PLJLIDOFMBA()
		{
		}

		private void KGJBANOOBEM<T>(Button3D HHDMPJJAPJJ, Action<T> LGCOGELONFN = null, Action<T> FGOBHGMFKML = null) where T : StackedUIFlowBase
		{
		}

		public Button3DBase GetButtonForFlow<T>()
		{
			return null;
		}

		public void LockButton<T>(bool IMNGCLCHDDL)
		{
		}

		public void LockRecCenterButton(bool IMNGCLCHDDL)
		{
		}

		private void HADBHPKHAIL<T>(T ELNPJBMKDAE) where T : StackedUIFlowBase
		{
		}

		public void HighlightButton<T>()
		{
		}

		public void ClearHighlights()
		{
		}

		public void HighlightRoomButton(PDIOCEBGKMP PLPLLEOPODP)
		{
		}

		private void OJGMOCCAOGI()
		{
		}

		private void FABJFHALDJE()
		{
		}

		private Color DHLHJGDBHBM()
		{
			return default;
		}

		private static bool GHOGDKPDPKB()
		{
			return false;
		}

		private void JBHFHKPFGFN(CHILKDJABBF DEODPCHAFKO)
		{
		}

		private void OLDGEDKKOID()
		{
		}

		public void Button_EvictAll()
		{
		}

		public void Button_DormRoom()
		{
		}

		public void Button_RecCenter()
		{
		}

		public void Button_ExitGame()
		{
		}

		protected override bool HELGFGMCPMI()
		{
			return false;
		}

		[CompilerGenerated]
		private void CJOAHFABOJJ()
		{
		}
	}
}
