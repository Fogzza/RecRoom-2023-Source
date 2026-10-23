using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AGUI.StackedUI;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.Systems.PlayerRoles;
using UnityEngine;

namespace RecRoom.Core.Creation.Shapes
{
	public class TriggerVolume : MonoBehaviourPun, GFLPAFBGELM, NEKJJEGPHFG, DJLCHGFCFAD, LEJOPAFDMEE, GAAKCFPLMHN, GBIGGECGKHF
	{
		private enum CODHPNJBAHM
		{
			Player = 0,
			Tool = 1
		}

		private sealed class HLBAGHLJOID
		{
			public TriggerVolume _003C_003E4__this;

			public string tagName;

			internal void _003CFilterTags_Set_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}
		}

		private sealed class MFMGFEHNLPH
		{
			public TriggerVolume _003C_003E4__this;

			public string role;

			internal void _003CFilterRole_Set_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}
		}

		public const BHEOAPLBNIE ENTERED_SLOT = BHEOAPLBNIE.R;

		public const BHEOAPLBNIE CURRENT_TOTAL_SLOT = BHEOAPLBNIE.G;

		public const BHEOAPLBNIE EXITED_SLOT = BHEOAPLBNIE.B;

		[SerializeField]
		private BoxCollider mainCollider;

		[SerializeField]
		private Color playerModeColor;

		[SerializeField]
		private Color playerModeAccentColor;

		[SerializeField]
		private Color toolModeColor;

		[SerializeField]
		private Color toolModeAccentColor;

		[SerializeField]
		private MeshRenderer[] renderersToRecolorOnModeChange;

		[SerializeField]
		private Transform circuitOutputs;

		[SerializeField]
		private float playerCapsuleRadius;

		[SerializeField]
		private float playerCapsuleHeight;

		[SerializeField]
		private Collider[] ignoredColliders;

		[SerializeField]
		private Tooltip tooltip;

		[SerializeField]
		private string defaultFilterTooltip;

		[SerializeField]
		private string playerTrackingModeTooltip;

		[SerializeField]
		private string objectTrackingModeTooltip;

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private CreationObjectSettingStringUIControl tagEditPrefab;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		[SerializeField]
		private CreationObject creationObject;

		private bool HALCELKCFDI;

		private int CCDFOALMNPB;

		private TriggerVolumeInputNodeDisplay GEDNDLCBMDK;

		private NLOGDCDGECD KIAFFPNPDBK;

		private NBIHDIPMEHG HDMOPEHNGCG;

		private List<CHILKDJABBF> OOICEIPCLDM;

		private JHMBDIKGCIK POEAEJAAPLN;

		private List<Tool> EBCPNDHNFGN;

		private HashSet<CHILKDJABBF> PHHKNODMIJH;

		private Dictionary<CHILKDJABBF, int> DDKLJGBEAJJ;

		private Dictionary<CHILKDJABBF, int> AKDLJMGFEPE;

		private HashSet<Tool> IDFIKHHFFPC;

		private Dictionary<Tool, int> FIGIECMFPHK;

		private Dictionary<Tool, int> HAEOKFPAJEI;

		private HashSet<object> ODNGLHDKDBB;

		private bool PFGCFMLPLKK;

		private global::MOBDJNEDDKC<bool> OMLHBKPEMLK;

		private global::MOBDJNEDDKC<int> MEEHOONLBBI;

		private global::MOBDJNEDDKC<string[]> MPANKADELOK;

		private global::MOBDJNEDDKC<string> HDGEODABNJI;

		private global::MOBDJNEDDKC<bool> JIKCBAEGNGO;

		private global::MOBDJNEDDKC<bool> GGKJKKFNLOO;

		private global::MOBDJNEDDKC<bool> CMFEJPJBFOM;

		private bool HDGFAHIGDDH;

		private Action<CHILKDJABBF> BLMBFLNFNPG;

		private Action<CHILKDJABBF> NAJPDHPCJME;

		private Action<Tool> KPNMNCKICIA;

		private Action<Tool> DLDHALIENCK;

		private Action<TriggerVolume> MILGNCFFJIE__BackingField;

public bool IsCircuitsV2
{
get 		{
			return false;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

private bool DCEEMKEOKHL
{
get 		{
			return false;
		}

set {
		}
}

private CODHPNJBAHM OAEBIMKIDEG
{
get 		{
			return CODHPNJBAHM.Player;
		}

set {
		}
}

public string[] FilterTags
{
get 		{
			return null;
		}

private set {
		}
}

public string FilterRole
{
get 		{
			return null;
		}

set {
		}
}

private bool KDCPFGFKEIH
{
get 		{
			return false;
		}

}

private bool NMPMOCHFNML
{
get 		{
			return false;
		}

}

private bool NLGLGNOBOPI
{
get 		{
			return false;
		}

set {
		}
}

public bool JuniorEnabled
{
get 		{
			return false;
		}

set {
		}
}

private bool EEBMGOHNGBA
{
get 		{
			return false;
		}

set {
		}
}

private bool NAKJJGDBMEK
{
get 		{
			return false;
		}

}

public bool DeserializedFromLegacyData
{
get 		{
			return false;
		}

private set {
		}
}

public IEnumerable<Tool> FilteredTools
{
get 		{
			return null;
		}

}

public int FilteredToolCount
{
get 		{
			return 0;
		}

}

public IEnumerable<CHILKDJABBF> FilteredPlayers
{
get 		{
			return null;
		}

}

public int FilteredPlayerCount
{
get 		{
			return 0;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

 GMHHJCFIMML global::NEKJJEGPHFG.CV2CreationObject
{
get 		{
			return null;
		}

}

public event Action<TriggerVolume> PivotPointChangedOnDeserialize {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Start()
		{
		}

		public void CurrentMode_Set(int DLEMNBPMGBG)
		{
		}

		public int CurrentMode_Get()
		{
			return 0;
		}

		public void FilterTags_Set(string OMMKMMMFFCK)
		{
		}

		public void FilterTags_Set(string[] OMMKMMMFFCK)
		{
		}

		public string FilterTags_Get()
		{
			return null;
		}

		public void FilterRole_Set(string KLBONOOHBND)
		{
		}

		public string FilterRole_Get()
		{
			return null;
		}

		public void JuniorEnabled_Set(bool DLEMNBPMGBG)
		{
		}

		public bool JuniorEnabled_Get()
		{
			return false;
		}

		private void JOEBAOIGBOO()
		{
		}

		private void KEKGPKFPBIH()
		{
		}

		private void FNDDFOFOJBL()
		{
		}

		private void ILCMMDNEBBH()
		{
		}

		private void JLCBHPIOGJE()
		{
		}

		private void DJCMCPGPPBI(Tool IEGMBEPJMGC)
		{
		}

		private void OEGAMALDPOP(Tool IEGMBEPJMGC)
		{
		}

		private void IKLFEOOKNFF(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void IJJKPONIJGD(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void AOHCMIJIBCP()
		{
		}

		private void FNOOANDNENN(Tool IEGMBEPJMGC)
		{
		}

		private void IMEKHAABCME<T>(TriggerVolumeInputNodeDisplay KNBPIEINLIG, HashSet<T> BPPPNDCBLIE, Dictionary<T, int> NGCAFHCMLFK, Dictionary<T, int> DJNPJEEDLMP, Action<T> DPBMMDKCNNJ, Action<T> GIJCEIKNJKA)
		{
		}

		private void JEGIODHHPCM(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void CDPPNCNJBOE(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void MOADDIMIABG(Tool IEOJNAOLJBG)
		{
		}

		private void ALEJCKAEAIP(Tool NDDOECJGGCG)
		{
		}

		private void BCNKCBBHNIC()
		{
		}

		private void BOECBICDDAL(Player EKOFNPFCLMO, Vector3 OJJNPNOEJDC, Vector3 NHOAENGJMLK)
		{
		}

		[PBOMGCLBFHF]
		private void FireEnterExitEvents(GGGMJMEFFOC BDGGGHEOPBI)
		{
		}

		private void OnTriggerEnter(Collider PAKCCEOOEJB)
		{
		}

		private void OnTriggerExit(Collider PAKCCEOOEJB)
		{
		}

		private static Player ANNBIMBMHCF(Tool KLPABBBBADG)
		{
			return null;
		}

		public bool IsTrackedWithFilters(Tool KLPABBBBADG)
		{
			return false;
		}

		public bool IsTrackedWithFilters(CHILKDJABBF KLPABBBBADG)
		{
			return false;
		}

		private void IFCGAELCKNH(GameRole KLBONOOHBND)
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		private void HKLGAIHJIMD()
		{
		}

		public void OnCreatedBySpawning()
		{
		}

		private void MFDIHOFLAAM(Vector3 MPOLJDGFKLE, Vector3 EBLENKNBANC)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private void DDMECHOMHFN(GNFJMCHKBIK ALCJDCGEBLM)
		{
		}

		void LEJOPAFDMEE.PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DDMECHOMHFN
			this.DDMECHOMHFN(ALCJDCGEBLM);
		}

		public void ResetObject()
		{
		}

		private void AFNPCLIDKMD(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void PIENFAIGDMJ(CreationObject BPEGJLIMPPJ)
		{
		}

		private void DEBOPBJIHCE(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void GPBMDNNAGKG(CreationObject BPEGJLIMPPJ)
		{
		}

		private global::FAIKNKAIPLB<OHAJOLBEFND> DCBNIOPDHIN(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		global::FAIKNKAIPLB<OHAJOLBEFND> GFLPAFBGELM.Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DCBNIOPDHIN
			return this.DCBNIOPDHIN(GCBHEJANCJK);
		}

		[CompilerGenerated]
		private bool KFHKCAPBHHK()
		{
			return false;
		}

		[CompilerGenerated]
		private bool NLIEEGKFONI()
		{
			return false;
		}

		[CompilerGenerated]
		private void FHCJIJDMNJE(bool DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private bool EFCOJDCDEKI()
		{
			return false;
		}

		[CompilerGenerated]
		private bool ANFIGMLBKAC()
		{
			return false;
		}

		[CompilerGenerated]
		private bool IOAACAEKOAD()
		{
			return false;
		}
	}
}
