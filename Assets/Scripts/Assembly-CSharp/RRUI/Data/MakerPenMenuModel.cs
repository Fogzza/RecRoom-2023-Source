using System.Collections.Generic;
using RRUI.Navigation;
using RecRoom;
using RecRoom.Audio;
using RecRoom.Tools;
using UnityEngine;

namespace RRUI.Data
{
	public class MakerPenMenuModel : RRUIModel<RRUIModel.AAHMEOHNDKA>
	{
		public enum IEKCDJICBLP
		{
			Tools = 0,
			Palette = 1,
			Config = 2,
			Logging = 3,
			More = 4,
			Performance = 5,
			MainProUX = 6,
			PaletteProUX = 7,
			LoggingProUX = 8,
			SettingsProUX = 9,
			ConfigProUX = 10,
			QAMProUX = 11,
			COUNT = 12
		}

		public enum OOJJGMECOIC
		{
			Shapes = 0,
			Materials = 1,
			Props = 2,
			Inventions = 3,
			Circuits = 4,
			Gizmos = 5,
			Favorites = 6,
			Search = 7,
			COUNT = 8
		}

		public enum KEMAOKMJGHG
		{
			MainMenu = 0,
			TearoffTab = 1
		}

		private sealed class EGJLPFMACLN
		{
			public Uri targetURI;

			internal bool _003CChangeMakerPenTabByUri_003Eb__0(Uri uri)
			{
				return false;
			}
		}

		private const string JOIJGGLCOLF = "MakerPenRoutes/(Makerpen_Palette_Shapes)";

		[SerializeField]
		private Route toolsRoute;

		[SerializeField]
		private Route paletteRoute;

		[SerializeField]
		private Route dataTableRoute;

		[SerializeField]
		private Route configRoute;

		[SerializeField]
		private Route loggingRoute;

		[SerializeField]
		private Route moreRoute;

		[SerializeField]
		private Route perfMonitorRoute;

		[SerializeField]
		private Route paletteProUXRoute;

		[SerializeField]
		private Route loggingProUXRoute;

		[SerializeField]
		private Route settingsProUXRoute;

		[SerializeField]
		private Route configProUXRoute;

		[SerializeField]
		public Route searchProUXRoute;

		[SerializeField]
		public Canvas AttachedMenuCanvas;

		[SerializeField]
		private RecRoomAudioClip menuOpenedAudio;

		[SerializeField]
		private RecRoomAudioClip menuClosedAudio;

		[SerializeField]
		private TetheredUIBase vrDetachedTetheredUI;

		[SerializeField]
		private GameObject vrDetachedTetheredUIMoveBar;

		public NNBAJLCGAOK Settings;

		private IEKCDJICBLP JNFBOKAFIKL;

		private float HDGFHFCPNPD;

		private SFXAudioSource EKHEADENGMK;

		private SFXAudioSource BILHCJJMFJJ;

		private Dictionary<IEKCDJICBLP, KIDPMAMHDFB.MADAPHJHMHC> NDHBHJFJLHG;

		private Dictionary<IEKCDJICBLP, float> ECDOFMGHHDJ;

protected override RRUIModel.AAHMEOHNDKA AOPCDGILOII
{
get 		{
			return default;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public Route DataTableRoute
{
get 		{
			return null;
		}

}

private AGVirtualKeyboard COKINJMBNOK
{
get 		{
			return null;
		}

}

public IEKCDJICBLP CurrentPrimaryTab
{
get 		{
			return IEKCDJICBLP.Tools;
		}

set {
		}
}

		public static IEKCDJICBLP GetTabForProUX(IEKCDJICBLP GOBCPANADIG)
		{
			return IEKCDJICBLP.Tools;
		}

		public void GoToPrimaryTab(bool AKHCCPHNKFB = false)
		{
		}

		public void GoToPaletteRoute(Route HLOIDFMCEIM, bool FADKHFOPAAF = false)
		{
		}

		public void GoToPerfMonitorMenu(bool AKHCCPHNKFB = false)
		{
		}

		private void EONEABBGONL(Uri NCLPONCOOKC, bool AKHCCPHNKFB = false)
		{
		}

		public bool GoBack()
		{
			return false;
		}

		private bool DPNLIABMLAB(IEKCDJICBLP GOBCPANADIG, bool AKHCCPHNKFB)
		{
			return false;
		}

		public Uri GetURIForPrimaryTab(IEKCDJICBLP HDFPGOIABNA)
		{
			return null;
		}

		public bool IsTabTornOff(IEKCDJICBLP HDFPGOIABNA)
		{
			return false;
		}

		public void UpdateBrowserToCurrentData(BrowserModel NAMAMAFFOIB, IEKCDJICBLP KOCNDPLELLL)
		{
		}

		public void SavePrimaryTabData(IEKCDJICBLP KOCNDPLELLL)
		{
		}

		public Route GetPrimaryTabRoute(IEKCDJICBLP GOBCPANADIG)
		{
			return null;
		}

		public Route GetSubTabRoute(OOJJGMECOIC GOBCPANADIG)
		{
			return null;
		}

		private void KFLLJKGKLPB()
		{
		}

		public bool IsVRDetached()
		{
			return false;
		}

		public void AttachVRDetachedMenu()
		{
		}

		public void VRDetachedMenuResetLocalScale()
		{
		}

		public void OnResetButtonClicked(IEKCDJICBLP FPEIJPKHKCA, bool NFACAKIAIKP = true, bool OCPAMJGPBDA = true)
		{
		}

		private void OEOAHBIEKPA(IEKCDJICBLP KOCNDPLELLL)
		{
		}

		public void ShowThisRoomScreen()
		{
		}

		public void StartToolMenuTimer()
		{
		}

		public void StopToolMenuTimer()
		{
		}

		public void ToolButtonClicked()
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void BJPPPBGBLAO()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(RRUIModel.AAHMEOHNDKA KMDKPCPJKJH)
		{
			return null;
		}

		private void NKAPMCCPIKN(TetheredUIBase JBEDDFCPPMG, bool BMGEHFPFCBJ)
		{
		}

		private void LHCOHOOMAGO()
		{
		}

		private void IJBIFMPCGEG()
		{
		}

		public void SaveCurrentPageData(IEKCDJICBLP GOBCPANADIG)
		{
		}
	}
}
