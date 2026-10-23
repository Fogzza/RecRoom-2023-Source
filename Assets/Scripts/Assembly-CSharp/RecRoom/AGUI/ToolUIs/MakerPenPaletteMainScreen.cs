using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI;
using AGUI.StackedUI;
using RecRoom.AGUI.ToolUIs.PaletteSearch;
using TMPro;
using UnityEngine;

namespace RecRoom.AGUI.ToolUIs
{
	public class MakerPenPaletteMainScreen : MakerPenPaletteUIFlowBase
	{
		public enum CEPGPOCJAMC
		{
			None = 0,
			Search = 1,
			ShapesAndColors = 2,
			Gadgets = 3,
			Props = 4,
			Settings = 5,
			Inventions = 6,
			CircuitV2 = 7,
			Clipboard = 8
		}

		public enum CAIAFLDKAIB
		{
			Materials = 0,
			Colors = 1,
			Eyedropper = 2
		}

		private sealed class PPHHEFCKCCM
		{
			public int temp;

			public MakerPenPaletteMainScreen _003C_003E4__this;

			internal void _003CInitialize_003Eb__0(RadioButton3D isOn)
			{
			}
		}

		private sealed class GGCPAIIEAHJ
		{
			public int temp;

			public MakerPenPaletteMainScreen _003C_003E4__this;

			internal void _003CInitialize_003Eb__1(RadioButton3D isOn)
			{
			}
		}

		private sealed class DIKEOFHPKEB
		{
			public RadioButton3D button;

			internal bool _003CTrySelectButton_003Eb__0(RadioButton3D b)
			{
				return false;
			}
		}

		private sealed class LOKLFDOJOLN
		{
			public ANOEOICCMDH category;

			internal bool _003CAddAuthorizedRestrictedToolTypesForCategory_003Eb__1(JBGFOIKBKED toolType)
			{
				return false;
			}
		}

		private sealed class JCBCJLGPADK
		{
			public MakerPenPaletteMainScreen _003C_003E4__this;

			public int currentInventionFilterIndex;

			public int previousPage;

			internal void _003CUpdateInventions_003Eb__0(List<OEBAEGDPBLA> myInventions)
			{
			}

			internal void _003CUpdateInventions_003Eb__1(string error)
			{
			}
		}

		private sealed class JDNFOKACGED
		{
			public MakerPenPaletteMainScreen _003C_003E4__this;

			public int buttonIndex;

			internal bool _003CUpdateSpawnableToolFilterButtons_003Eb__0(RadioButton3D b)
			{
				return false;
			}
		}

		[SerializeField]
		private SubscreenControl subscreenControl;

		[SerializeField]
		private MakerPenPaletteSearchScreen searchSubscreen;

		[SerializeField]
		private CircuitV2Subscreen circuitsV2Subscreen;

		[SerializeField]
		private Subscreen spawnableToolSubscreen;

		[SerializeField]
		private Subscreen settingsSubscreen;

		[SerializeField]
		private Subscreen inventionsSubscreen;

		[SerializeField]
		private Subscreen clipboardSubscreen;

		[SerializeField]
		private Subscreen circuitsSubscreen;

		[SerializeField]
		private RadioButton3D circuitsV2RadioButton;

		[SerializeField]
		private RadioButton3D gadgetsRadioButton;

		[SerializeField]
		private RadioButton3D propsRadioButton;

		[SerializeField]
		private InkBarControl inkBarControl;

		[SerializeField]
		private TextMeshProUGUI selectedItemText;

		[SerializeField]
		private MakerPenPaletteSearchPagedGrid paletteSearchPagedGrid;

		private Material FCHDIJDLCLG;

		[SerializeField]
		private Renderer[] shapePreviews;

		[SerializeField]
		private AMEPDCGKFOG[] shapeButtonsGridOrderToShapeType;

		[SerializeField]
		private SpawnableToolPagedGrid spawnableToolPagedGrid;

		[SerializeField]
		private RadioGroup3D spawnableToolsFilterGroup;

		[SerializeField]
		private InventionPagedGrid inventionPagedGrid;

		[SerializeField]
		private RadioGroup3D inventionsFilterGroup;

		[SerializeField]
		private string[] inventionFilterNames;

		[SerializeField]
		private ClipboardPagedGrid clipboardPagedGrid;

		[SerializeField]
		private PagedGrid settingsPagedGrid;

		[SerializeField]
		private ToggleButton3D desatWorldToggle;

		[SerializeField]
		private ToggleButton3D adaptiveGridToggle;

		[SerializeField]
		private ToggleButton3D adaptiveCreationSizeToggle;

		[SerializeField]
		private ToggleButton3D playStopGizmosToggle;

		[SerializeField]
		private Button3D deleteAllButton;

		[SerializeField]
		private Slider3D grabbableByDefaultSlider;

		[SerializeField]
		private ToggleButton3D viewGadgetsWithoutMakerPenToggle;

		[SerializeField]
		private ToggleButton3D showOptimizedCollidersToggle;

		[SerializeField]
		private ToggleButton3D showCV2ExecHighlightsToggle;

		[SerializeField]
		private ToggleButton3D showCV2DataHighlightsToggle;

		[SerializeField]
		private ToggleButton3D showCV2HoverHighlightsToggle;

		[SerializeField]
		private ToggleButton3D showCV2OutOfScopeToggle;

		private RadioButton3D[] FFDAIEGHJKE;

		private RadioButton3D[] IFDFFKLNMEJ;

		private RadioButton3D[] LDOELEPJDKC;

		private RadioButton3D[] BPPPKAMAFBF;

		private bool NGJGBJEHIPJ;

		private JBGFOIKBKED MBANBJCNLLC;

		private static readonly Dictionary<string, int> MGIFOADIFAK;

		private static int PDKOCIGMNBI;

		private OEBAEGDPBLA HOMPDICCBHG;

		private LFIOJFLIPFC OEIGNBGPBMN;

		private static bool LEEFOENBAPM;

		private List<JBGFOIKBKED> ANFCNMKLOHF;

		public readonly global::HHOBPMOCKMJ<AMEPDCGKFOG> ShapeTypeSelectionButtonPressed;

		public readonly global::HHOBPMOCKMJ<JLHLKDMLBPK> ShapeColorSelectionButtonPressed;

		public readonly global::HHOBPMOCKMJ<MJGMBIJIKFH> ShapeMaterialSelectionButtonPressed;

		public readonly global::HHOBPMOCKMJ<JECDPJHHBNL> ColorableSnapshotSelectionButtonPressed;

		public readonly global::HHOBPMOCKMJ<JBGFOIKBKED> SpawnableToolSelectionButtonPressed;

		public readonly global::HHOBPMOCKMJ<OEBAEGDPBLA> InventionSelectionButtonPressed;

		public readonly global::HHOBPMOCKMJ<LFIOJFLIPFC> SnapshotSelectionButtonPressed;

		private int PFBIOBPPGII;

		private int CMEDEJDKOKK;

		private int CBBKGBDEFCG;

		private CEPGPOCJAMC CIECFEBDHMM;

		private CEPGPOCJAMC FDDGOMLNNJO;

		private bool? FKHOBAIBBOJ;

public Material UIShapeMaterialInstance
{
get 		{
			return null;
		}

private set {
		}
}

public static CAIAFLDKAIB currentMaterialTab
{
get 		{
			return CAIAFLDKAIB.Materials;
		}

set {
		}
}

public IEnumerable<AMEPDCGKFOG> DisplayedShapes
{
get 		{
			return null;
		}

}

private int KJCIEABJFBE
{
get 		{
			return 0;
		}

set {
		}
}

private int LEAEFOKFKFI
{
get 		{
			return 0;
		}

set {
		}
}

private int GPFLMLJAKCA
{
get 		{
			return 0;
		}

set {
		}
}

private CEPGPOCJAMC HJFFDKOMMCN
{
get 		{
			return CEPGPOCJAMC.None;
		}

set {
		}
}

public CEPGPOCJAMC LastCreationDisplayMode
{
get 		{
			return CEPGPOCJAMC.None;
		}

private set {
		}
}

private bool KEJIIKGICJA
{
get 		{
			return false;
		}

}

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		private void NJMCOMBNPLN()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void NJBCGGGDEHI()
		{
		}

		public RadioButton3D GetButtonForShape(AMEPDCGKFOG LJGNKMONIGD)
		{
			return null;
		}

		public void SelectPropButton(JBGFOIKBKED KDHBALDHKBN)
		{
		}

		public void DeselectAllPropButtons()
		{
		}

		public void SelectInventionButton(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		public void SelectSnapshotButton(LFIOJFLIPFC EEKOIHMJIDP)
		{
		}

		public void DeselectAllInventionButtons()
		{
		}

		public void DeselectAllSnapshotButtons()
		{
		}

		private bool MNHLGMNPJGK(AMEPDCGKFOG LJGNKMONIGD, RadioGroup3D EILJAEDFKEC)
		{
			return false;
		}

		private void FELDAFBABBI(RadioGroup3D EILJAEDFKEC)
		{
		}

		public static void OnUsedPaletteItem(JDNHCJEAMBI KDAFDKBCGIO, long IKHNIJKGJFD)
		{
		}

		private void JMHBEDPFEOA()
		{
		}

		private void KACHBPEDOBB()
		{
		}

		private void LKNDGPKMGEO()
		{
		}

		private void MBCPIGMLMNG()
		{
		}

		private void EOGCOKMBNLL(SpawnableToolCategoryConfig.NPLMNGEDABB CIFHMNKCLNG, int LFMLPBEFCCP)
		{
		}

		private void IIMCGKAJMHL(SpawnableToolPagedGrid JOPGEMPGKLD, ANOEOICCMDH JNKJFJLJKNJ)
		{
		}

		public static List<JBGFOIKBKED> GetAuthorizedRestrictedToolTypes()
		{
			return null;
		}

		private void DEDDPGGJAIK(int JPBKEBGCBDI = 0)
		{
		}

		private void AFJBPLHICJK()
		{
		}

		private void EBFGNDGCLFG()
		{
		}

		private void AFLBEOAOBCA(SpawnableToolCategoryConfig.NPLMNGEDABB CIFHMNKCLNG)
		{
		}

		private void PONCEJGGKKF()
		{
		}

		private void GFGICPMOBMD(string CEEBKJJBEMB)
		{
		}

		public void ShowTab(CEPGPOCJAMC AIDOCIKAKCJ)
		{
		}

		private void HHLDDEGPLKP(FBEHJNCKJPN CIMCLAFMGFE, HHNPLBOFAGE IACECANFEKI)
		{
		}

		private void GCJDOKBJCJD()
		{
		}

		private void EKEKIDEMOGJ()
		{
		}

		private void NFDOIHDPAGM(long IKHNIJKGJFD)
		{
		}

		public void Button_Close()
		{
		}

		public void Button_Search()
		{
		}

		public void Button_ShapesAndColors()
		{
		}

		public void Button_Gadgets()
		{
		}

		public void Button_Props()
		{
		}

		public void Button_Inventions()
		{
		}

		public void Button_Clipboard()
		{
		}

		public void Button_CircuitsV2()
		{
		}

		public void Button_Settings()
		{
		}

		public void Button_SearchCircuitsV2()
		{
		}

		public void Button_FilterSpawnableTools(int GMEHLIHLGEH)
		{
		}

		public void Button_SpawnableToolSelected(JBGFOIKBKED spawnableTool)
		{
		}

		public void Button_FilterInventions(int GMEHLIHLGEH)
		{
		}

		public void Button_InventionSelected(OEBAEGDPBLA invention)
		{
		}

		public void Button_SnapshotSelected(LFIOJFLIPFC snapshot)
		{
		}

		public void Button_InventionInfo(OEBAEGDPBLA invention)
		{
		}

		public void Button_SelectColor(JLHLKDMLBPK shapeColor)
		{
		}

		public void Button_SelectMaterial(MJGMBIJIKFH shapeMaterial)
		{
		}

		public void Button_SelectColorableSnapshot(JECDPJHHBNL colorableSnapshot)
		{
		}

		public void Button_SelectShape(int shapeType)
		{
		}

		private void FPIABBEAHMK(NNBAJLCGAOK JGEGKOOCOEH)
		{
		}

		private void DNBJBDCIBNC()
		{
		}

		public void Toggle_DesatWorldInShapeMode(bool isOn)
		{
		}

		public void ToggleShowPivot(bool isOn)
		{
		}

		public void Toggle_SnapToCenter(bool isOn)
		{
		}

		public void Toggle_RotatearoundPivot(bool isOn)
		{
		}

		public void Toggle_FreezeRotationOnMove(bool isOn)
		{
		}

		public void Toggle_UniformShapes(bool isOn)
		{
		}

		public void Initialize_SnappingMode(JNODIIINKKJ.PBDGIEELIHN value)
		{
		}

		public void Initialize_GridSnap(float value)
		{
		}

		public void Toggle_AlignToEdges(bool isOn)
		{
		}

		public void Toggle_ShowGrid(bool isOn)
		{
		}

		public void Toggle_AdaptiveGrid(bool isOn)
		{
		}

		public void Toggle_AdaptiveCreationSize(bool isOn)
		{
		}

		public void Toggle_ShowSelectionBounds(bool isOn)
		{
		}

		public void Toggle_RoundedTubes(bool isOn)
		{
		}

		public void Toggle_EnableSelfScaling(bool isOn)
		{
		}

		public void Toggle_ConnectTubes(bool isOn)
		{
		}

		public void SliderReleased_TubeAnalogMode(float value)
		{
		}

		public void Initialize_AngleSnap(float value)
		{
		}

		public void SliderReleased_TubeHeightScale(float value)
		{
		}

		public void SliderReleased_TubeRingPoints(float value)
		{
		}

		public void SliderReleased_DragSelectSize(float value)
		{
		}

		public void Toggle_PlayStopGizmos(bool isPlaying)
		{
		}

		public void Toggle_ShowOptimizedColliderOnSelection(bool isOn)
		{
		}

		public void Toggle_ShowCV2ExecHighlights(bool isOn)
		{
		}

		public void Toggle_ShowCV2DataHighlights(bool isOn)
		{
		}

		public void Toggle_ShowCV2HoverHighlights(bool isOn)
		{
		}

		public void Toggle_ShowCV2OutOfScope(bool isOn)
		{
		}

		public void Button_DeleteEverything()
		{
		}

		public void Button_ResetEverything()
		{
		}

		public void SliderReleased_GrabbableByDefault(float value)
		{
		}

		public void Toggle_ShowGadgetsWithoutMakerPen(bool isOn)
		{
		}

		[CompilerGenerated]
		private void LKKFLJBANKP()
		{
		}

		[CompilerGenerated]
		private bool JMAHJBDDHKA(RadioButton3D EFNJCAIBDLA)
		{
			return false;
		}
	}
}
