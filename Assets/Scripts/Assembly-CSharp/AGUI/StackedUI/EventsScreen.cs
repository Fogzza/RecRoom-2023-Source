using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RecRoom;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class EventsScreen : WatchUIFlow
	{
		private enum NLHBOBJGAPO
		{
			None = 0,
			ActiveEvents = 1,
			UpcomingEvents = 2,
			PopularEvents = 3,
			MyEvents = 4,
			CreateEvent = 5
		}

		private sealed class OECNDKEKLFM
		{
			public EventsScreen _003C_003E4__this;

			public global::NCOKFFGPIJM<IEnumerable<IMIJPHJKLIM>> searchPromise;

			internal void _003CSearchForEvents_003Eg__OnRequestError_007C0(string error)
			{
			}

			internal void _003CSearchForEvents_003Eg__OnRequestComplete_007C1()
			{
			}

			internal void _003CSearchForEvents_003Eb__2(IEnumerable<IMIJPHJKLIM> eventList)
			{
			}
		}

		private sealed class CFHFHCDGCJO
		{
			public int capturedIndex;

			public EventsScreen _003C_003E4__this;

			internal void _003CInitializePlayerEventTagToggles_003Eb__0(bool isOn)
			{
			}
		}

		[SerializeField]
		private RadioButton3D activeEventsRadioButton;

		[SerializeField]
		private RadioButton3D upcomingEventsRadioButton;

		[SerializeField]
		private RadioButton3D popularEventsRadioButton;

		[SerializeField]
		private RadioButton3D myEventsRadioButton;

		[SerializeField]
		private RadioButton3D createRadioButton;

		[SerializeField]
		private PlayerEventButtonPagedGrid eventsGrid;

		[SerializeField]
		private GameObject searchRow;

		[SerializeField]
		private InputField3D searchField;

		[SerializeField]
		private Button3D searchButton;

		[SerializeField]
		private GameObject playerEventTagTogglesContainer;

		[SerializeField]
		private SubscreenControl subscreenControl;

		[SerializeField]
		private Subscreen eventsSubScreen;

		[SerializeField]
		private CreatePlayerEventUI createPlayerEventUI;

		private bool GDNODLOECCG;

		private static int LAAJCHLOIJG;

		private List<string> IBBMGEIGOJO;

		private const char GEICLMGMHLC = '#';

		private ToggleButton3D[] GHNFFNGGIHO;

		private NLHBOBJGAPO PFFJKPGPNBD;

		private int FLHMLDJDKCK;

		private global::NCOKFFGPIJM<IEnumerable<IMIJPHJKLIM>> DCMBMOFFFDB;

private NLHBOBJGAPO DLBPJCCJJOP
{
get 		{
			return NLHBOBJGAPO.None;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		public void SetTargetEventClub(long? AFPHABFLEBN)
		{
		}

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void ALIHPNGJGDH(IMIJPHJKLIM IGGPIMCKMBP)
		{
		}

		private void DICOLKHOKOD(long JJLIIOCLCNA)
		{
		}

		private void NHEDOPICHKL()
		{
		}

		private void MCFPPOBFJPO()
		{
		}

		private void BDAGMPAOHJB()
		{
		}

		private void EKLHLPNIILO(bool KBHLDNPHEKG)
		{
		}

		private void AABFNMBAOKE()
		{
		}

		private void BADHJBNACCK(IEnumerable<IMIJPHJKLIM> IAOPBOEHEOP)
		{
		}

		private void INKBNLCEELF(string NIOBDAGDJAE)
		{
		}

		private string KNCKIKHEIAG()
		{
			return null;
		}

		private void BBNDIAHGHGL()
		{
		}

		private List<string> EOMCIBEAGAO()
		{
			return null;
		}

		private void IPIGHHNMAJJ()
		{
		}

		public void Button_ActiveEventsDisplayMode()
		{
		}

		public void Button_UpcomingEventsDisplayMode()
		{
		}

		public void Button_PopularEventsDisplayMode()
		{
		}

		public void Button_MyEventsDisplayMode()
		{
		}

		public void Button_CreateEventDisplayMode(Subscreen createSubscreen)
		{
		}

		public void Button_Search()
		{
		}

		protected override bool IMCMBEHDMAF()
		{
			return false;
		}

		[CompilerGenerated]
		private void NGIDBBBFBLI(List<string> CDNLFEOBNKB)
		{
		}
	}
}
