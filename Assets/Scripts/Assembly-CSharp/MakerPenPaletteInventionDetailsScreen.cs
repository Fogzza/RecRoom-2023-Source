using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using RecRoom.AGUI.ToolUIs;
using RecRoom.Core;
using RecRoom.Core.Creation;
using RecRoom.Utils.Image;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakerPenPaletteInventionDetailsScreen : MakerPenPaletteUIFlowBase
{
	private sealed class EBNKLNCNDKM
	{
		public MakerPenPaletteInventionDetailsScreen _003C_003E4__this;

		public bool cheer;

		internal void _003CButton_Cheer_003Eb__0(JLLIAMENNLJ result)
		{
		}

		internal void _003CButton_Cheer_003Eb__1(string error)
		{
		}
	}

	[SerializeField]
	private EnterInventionNameDialog enterInventionNameDialog;

	[SerializeField]
	private EnterInventionDescriptionDialog enterInventionDescriptionDialog;

	[SerializeField]
	private EditInventionTagsDialog editInventionTagsDialog;

	[SerializeField]
	private ReportInventionDialog reportInventionDialog;

	[SerializeField]
	private TextMeshProUGUI inventionName;

	[SerializeField]
	private Button3D editNameButton;

	[SerializeField]
	private TextMeshProUGUI inventionDescription;

	[SerializeField]
	private Button3D editDescriptionButton;

	[SerializeField]
	private TextMeshProUGUI inventionTagsText;

	[SerializeField]
	private Button3D editTagsButton;

	[SerializeField]
	private Tooltip tagsTooltip;

	[SerializeField]
	private RawImage inventionImage;

	[SerializeField]
	private Button3D editImageButton;

	[SerializeField]
	private PlayerInfoUIControl creatorInfo;

	[SerializeField]
	private Button3D creatorInfoButton;

	[SerializeField]
	private GameObject statsContainer;

	[SerializeField]
	private TextMeshProUGUI ownersCountText;

	[SerializeField]
	private TextMeshProUGUI roomsCountText;

	[SerializeField]
	private TextMeshProUGUI priceText;

	[SerializeField]
	private TextMeshProUGUI inkCostText;

	[SerializeField]
	private TextMeshProUGUI infoText;

	[SerializeField]
	private float inkCostLowThreshold;

	[SerializeField]
	private float inkCostMediumThreshold;

	[SerializeField]
	private ToggleButton3D cheerToggle;

	[SerializeField]
	private TextMeshProUGUI cheersCountText;

	[SerializeField]
	private Button3D reportButton;

	[SerializeField]
	private TextMeshProUGUI permissionsText;

	[SerializeField]
	private string useOnlyPermissionLabel;

	[SerializeField]
	private string editAndSavePermissionLabel;

	[SerializeField]
	private string publishingPermissionLabel;

	private CGOPOAFDIDN FIJHCMLFKJH;

	private ALONAFPFMKD CJIHMOOKNIB;

	private DFDECAEJBIO CMHKLCBLLCC;

	private Coroutine BFOKNOAIGFP;

	private ManagedTexture HLFEDKNBNOB;

	private string LEJMENICLLJ;

	private string FLHPCHFDAML;

	private List<string> DOLNIDINOBB;

	private AccountSpecificUIBehaviour[] JFEOBFOGLFD;

	private ReputationSpecificUIBehaviour[] KMCMEIBCHBD;

	private GDHOAGNFOBD.KEIAPDLHGPG CCHMKKIAPPM;

	private WatchUI IICLICGCHGJ;

	private OEBAEGDPBLA FMMPBEFPFFM;

private WatchUI JHFPEDCIDPG
{
get 	{
		return null;
	}

set {
	}
}

public OEBAEGDPBLA TargetInvention
{
get 	{
		return null;
	}

private set {
	}
}

	protected override void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void SetTargetInvention(OEBAEGDPBLA EGDOIKMDMJM)
	{
	}

	private void NADNEOKPDBN(string ALLOPBKEIAJ, bool CEKBHBBHDCG)
	{
	}

	private void IMNLKCGHNPP()
	{
	}

	private void DNLJGNNKHPJ()
	{
	}

	private string AFNBLDFLANA(string KNOPFGAGMCN)
	{
		return null;
	}

	private void IDJOBIBIJCD()
	{
	}

	private void AIHJNKFFKIN()
	{
	}

	private void HKNKFJDKIGL(long KBPFKPGOCFN)
	{
	}

	private void AFJCAMKMKEN(JDCIJIEOFOL FBCDJHOIDJJ)
	{
	}

	private void BGBLMPMABJO(CreationManager.HGDLKGAFGLC.PODFOMGJNCI MLDANHIGANI)
	{
	}

	public void Button_EditName()
	{
	}

	public void Button_EditDescription()
	{
	}

	public void Button_EditTags()
	{
	}

	public void Button_UpdateImage()
	{
	}

	private void KPCICOBDIPG(JLLIAMENNLJ MLDANHIGANI)
	{
	}

	public void Button_CreatorInfo()
	{
	}

	public void Button_Publish()
	{
	}

	public void Button_Unpublish()
	{
	}

	public void Button_Setup()
	{
	}

	public void Button_Report()
	{
	}

	public void Button_Cheer(bool cheer)
	{
	}

	public void Button_ViewInStore()
	{
	}

	private void GPAJGPHMIIO(int? EJIHLJJMOBD)
	{
	}

	private void JJONABDDNKA()
	{
	}

	private void EDKNIACIFLJ()
	{
	}

	private void IDOAGMGDMCO()
	{
	}

	private void LCJOAIMDENO()
	{
	}

	private void PJDACPCPNBI()
	{
	}

	private void LDMJKIFNMPK()
	{
	}

	[CompilerGenerated]
	private void KDGFDNHKACF(ALONAFPFMKD CDNLFEOBNKB)
	{
	}

	[CompilerGenerated]
	private void KPGMCELIDDE(string NLJOHEKGNDH)
	{
	}

	[CompilerGenerated]
	private void NOPCPEPJCKN()
	{
	}

	[CompilerGenerated]
	private void HHCPDEHPEDC(Texture2D CIONKGJFLOB)
	{
	}

	[CompilerGenerated]
	private void GMNPFFGCLBA(DFDECAEJBIO ACBGBAAHOIM)
	{
	}

	[CompilerGenerated]
	private void HNONOFCOKJD(JLLIAMENNLJ CDNLFEOBNKB)
	{
	}

	[CompilerGenerated]
	private void NEPIMPPBPFI(string NLJOHEKGNDH)
	{
	}

	[CompilerGenerated]
	private void HPJLJJHFBPP(OEBAEGDPBLA EGDOIKMDMJM)
	{
	}

	[CompilerGenerated]
	private void GKGKDLOCCAH(HENPPMLGJNP FEGCJGMIGKM)
	{
	}

	[CompilerGenerated]
	private void JGBFILPCOCG(HENPPMLGJNP LDFINKDFLBK)
	{
	}

	[CompilerGenerated]
	private void HFFPJOMLGCM(RenderTexture NHDEMBFBKJK)
	{
	}

	[CompilerGenerated]
	private void MJJDBGNLNII(string PEHCJFEPFJN)
	{
	}

	[CompilerGenerated]
	private void ABAHHFKEDIJ(string NPOEAPJKNFN)
	{
	}

	[CompilerGenerated]
	private void LGNAJNDCIKL(string HPOGIBBIGIG)
	{
	}

	[CompilerGenerated]
	private void CDHHCPPIMLC(HGKINAOMNIF MLDANHIGANI)
	{
	}

	[CompilerGenerated]
	private void JAMAOJMKFML(PJGPNHMNHPH JGPDCPDKBGJ)
	{
	}

	[CompilerGenerated]
	private void DOPNJMCLDHD(JLGDECHJNNO ANAJIMNLFLD)
	{
	}
}
