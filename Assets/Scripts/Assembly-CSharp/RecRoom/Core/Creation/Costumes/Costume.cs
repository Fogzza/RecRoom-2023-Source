using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using AGUI.StackedUI;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.Costumes
{
	public abstract class Costume : MonoBehaviourPun, DJLCHGFCFAD, GAAKCFPLMHN, NKHKPBPHIEG, FLAHOAAMCJB, EFOEBOFJOMK, GFLPAFBGELM, NEKJJEGPHFG
	{
		public delegate void BCCCPIBHLAA(Costume PKLMFPHMDIA);

		private sealed class GINGJLPGMFD
		{
			public Costume _003C_003E4__this;

			public CreationObject creationObject;

			internal HashSet<Guid> _003CStart_003Eb__0()
			{
				return null;
			}

			internal void _003CStart_003Eb__1(IEnumerable<Guid> value)
			{
			}

			internal bool _003CStart_003Eb__2()
			{
				return false;
			}

			internal bool _003CStart_003Eb__3()
			{
				return false;
			}

			internal bool _003CStart_003Eb__4()
			{
				return false;
			}

			internal bool _003CStart_003Eb__5()
			{
				return false;
			}

			internal Guid _003CStart_003Eb__8()
			{
				return default;
			}

			internal void _003CStart_003Eb__9(Guid value)
			{
			}

			internal void _003CStart_003Eb__11(float _)
			{
			}
		}

		private sealed class BKBKGHHLHOP
		{
			public Costume _003C_003E4__this;

			public CHILKDJABBF photonPlayer;

			internal void _003CMasterEquipToPhotonPlayer_003Eb__0(bool playerOwns)
			{
			}
		}

		private sealed class MNBMGJDFHEI : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public Costume _003C_003E4__this;

			public bool suppressSFX;

			private int _003CphotonPlayerId_003E5__2;

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
			public MNBMGJDFHEI(int _003C_003E1__state)
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

		private const EDBMANFHGGO JCFHKMKLIJC = EDBMANFHGGO.R;

		private const BHEOAPLBNIE MOJDGFMPNGB = BHEOAPLBNIE.R;

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private CostumeStackedUI uiPrefab;

		[SerializeField]
		private Transform uiRoot;

		[SerializeField]
		private BaseUIPivot uiPivot;

		[SerializeField]
		private AudioClip equipSound;

		[SerializeField]
		private AudioClip unequipSound;

		[SerializeField]
		private float sfxVolume;

		private CostumePiece JNDLKIHGMHF;

		private CostumePiece DOEBDJLKBBH;

		[SerializeField]
		private float uiHideDistance;

		[SerializeField]
		private float dummyUprightThreshold;

		private HLNFDOBEGJO CHABDOLEEMD;

		protected readonly List<CostumePiece> LCDHNJODLJO;

		private CostumeStackedUI MELDFJGPOOO;

		private float LDCFOAMEMBB;

		private float JMFGCNOOGMN;

		protected static readonly Dictionary<int, Costume> DBLJIEAJKEA;

		private static readonly List<int> HPLFMKGJJJE;

		private static readonly Dictionary<string, MIBJNNKFLND> OGGKBPGNAJO;

		private global::CDLJMENCODC<int> FECNLNNOFBE;

		private CHILKDJABBF PFCJGNIDNAM;

		protected Player OJFOIJAGGGM;

		private EEANDDJEMJC HPBHPGBHAOG;

		private RoleGuidSetEditableUIControl AOGKJDNDFPB;

		private global::EDPNALIEGFA<Guid> HLBDABFALLL;

		private global::MOBDJNEDDKC<bool> EJDKCAAGFBL;

		private global::MOBDJNEDDKC<bool> CEDIMHIEAFG;

		private global::MOBDJNEDDKC<bool> GKFFFMHGPCD;

		private CreationObjectSettingFriendlyFlagsControl APIFMIPIGCP;

		private global::MOBDJNEDDKC<int> JLIHKKCOIOI;

		private KeyGuidEditableUIControl POHINAEHMDM;

		private global::MOBDJNEDDKC<Guid> KLKFNBENDHB;

		private bool MKPOFJHIMDE;

		private bool LHPLJJHFNOD;

		private BCCCPIBHLAA CGEMLIBHFFL__BackingField;

		private BCCCPIBHLAA PHIJCKBFADO__BackingField;

		private BCCCPIBHLAA IKLLCLBPEGH__BackingField;

		private BCCCPIBHLAA AOEKJCNGJOH__BackingField;

		private BCCCPIBHLAA ACCKFFDKJNA__BackingField;

		private LKGILLBEJEK GINAMEBLPMG;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

public Tool Tool
{
get 		{
			return null;
		}

}

protected virtual CircuitNodeDisplay BKNHLHMPPPI
{
get 		{
			return null;
		}

}

public CostumePiece SelectedCostumePiece
{
get 		{
			return null;
		}

private set {
		}
}

public CHILKDJABBF EquippedPhotonPlayer
{
get 		{
			return null;
		}

}

private ISet<Guid> IGHNNLBKEIB
{
get 		{
			return null;
		}

}

private bool MBIFPBCILNJ
{
get 		{
			return false;
		}

set {
		}
}

public bool ShowEquipUi
{
get 		{
			return false;
		}

set {
		}
}

public bool PlayEquipSoundEffect
{
get 		{
			return false;
		}

set {
		}
}

public Player.JLLGKBEJLOF OutfitFilter
{
get 		{
			return Player.JLLGKBEJLOF.None;
		}

set {
		}
}

public Guid EquipLockedByKeyId
{
get 		{
			return default;
		}

set {
		}
}

protected virtual int CGACJNDMIBH
{
get 		{
			return 0;
		}

set {
		}
}

protected virtual int DGAIKEPONLM
{
get 		{
			return 0;
		}

}

protected virtual bool NKKCBOJFJOE
{
get 		{
			return false;
		}

}

public bool IsEquipLockedByKey
{
get 		{
			return false;
		}

}

public bool IsEquipped
{
get 		{
			return false;
		}

}

public bool IsReadyToEquip
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsUIVisible
{
get 		{
			return false;
		}

private set {
		}
}

public BaseUIPivot UIPivot
{
get 		{
			return null;
		}

}

private bool CCPEFLMAEIM
{
get 		{
			return false;
		}

}

public bool IsEmpty
{
get 		{
			return false;
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

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
		}

}

public virtual bool UseSkinning
{
get 		{
			return false;
		}

}

public event BCCCPIBHLAA EquipEvent {
add {
		}
remove {
		}
}

public event BCCCPIBHLAA UnequipEvent {
add {
		}
remove {
		}
}

public event BCCCPIBHLAA IsReadyToEquipChangedEvent {
add {
		}
remove {
		}
}

public event BCCCPIBHLAA IsEquipLockedByKeyChangedEvent {
add {
		}
remove {
		}
}

public event BCCCPIBHLAA EquipKeyUpdatedEvent {
add {
		}
remove {
		}
}

		public void SetHighlightedCostumePiece(CostumePiece COLMAMKJPJE)
		{
		}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void NLHFKBFPHAB(AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void LIDAMFHGFIP()
		{
		}

		public void ResetObject()
		{
		}

		protected virtual bool ACFKPEFKIOD()
		{
			return false;
		}

		protected void HAMINDPJLBH()
		{
		}

		private void EPIPHCINLLE()
		{
		}

		private void CACPEKLAMFC()
		{
		}

		private CostumeUIFlow MHENACMEMHG<V>() where V : CostumeUIFlow
		{
			return null;
		}

		private void KGFMKAAFGJO()
		{
		}

		private void LEMMPKPKJKO(EOHADGOEBOD NKEGLGHKOJC)
		{
		}

		private void OFIHOMNKHGH(Dictionary<EDBMANFHGGO, int> KLPFODAMNED)
		{
		}

		private void HPPGKOEBMNI(Tool PMEFICGEDFK)
		{
		}

		private void AAGKCNIGEAG(Tool PMEFICGEDFK)
		{
		}

		private void OMPFMHJDHOC(RigidbodyEx ICHBECDKHOJ)
		{
		}

		private void BADODPLCJNK(Tool PMEFICGEDFK)
		{
		}

		private void CEIMFCAJHNO(DHJLEHBOGBG GADDGJANIGG)
		{
		}

		private BJIJHMNPDCH MLANBKJGGOC(Collider ADMCDJKKCIA)
		{
			return null;
		}

		private void OnPhotonPlayerDisconnected(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void EKCDJIKBJJG(LMKFOACECEG? IEMMIFODLAI)
		{
		}

		public void RequestEquipToPlayer(Player EKOFNPFCLMO)
		{
		}

		public void RequestUnequip()
		{
		}

		public void RefreshIsReadyToEquip()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestEquipToPlayer(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestUnequip()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcPromptLocalPlayerToBuyEquipKey()
		{
		}

		private void LFDDOLHBACI(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void ODCHGGFMJMH(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void BHAKKKPCFAN()
		{
		}

		private static KLNOBKBCIEK OEMIALCEAPO(IEnumerable<Guid> EJOCLPIJNHL)
		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

		private void CPKDLLBJHIH(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void MBDEAOJPDKN(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private static void LMOONPGMBGN(Player EKOFNPFCLMO, Player.JLLGKBEJLOF EICNLGCAONF)
		{
		}

		private void CJLGNIPOLNN()
		{
		}

		protected abstract void LHLALHKGGBO();

		private IEnumerator<EGGPGCCKPCO> CMGNLMABIDP(bool BKAKDCIDNLG)
		{
			return null;
		}

		public virtual Transform GetTransformFromBoneIndex(int GMEHLIHLGEH)
		{
			return null;
		}

		private void PFKCFHCNMBE(bool BKAKDCIDNLG)
		{
		}

		private void DPIPECDGAKP()
		{
		}

		protected virtual void PNCNHIGGGPH()
		{
		}

		protected virtual void HJAMGJGIHNA()
		{
		}

		private void JKGAKHMGKHM(int CNNMDJPOLOB, bool BKAKDCIDNLG)
		{
		}

		private void MMJFBHMDHAB()
		{
		}

		private void ILCALOBDADK()
		{
		}

		private void GFEDDPIBAHO(bool MIAMLDCMJJH)
		{
		}

		protected virtual void KIHNKLKHIAA(bool GMJGLPNAENI)
		{
		}

		private void IDKAEGJCGDH()
		{
		}

		private void BFLOGKHNOBH()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public void OnSelected()
		{
		}

		public void OnDeselected()
		{
		}

		public void OnMakerPenHoverStart(FBEHJNCKJPN CIMCLAFMGFE, Collider LPGAJGPGKFM)
		{
		}

		public void OnMakerPenHovering(FBEHJNCKJPN CIMCLAFMGFE, Collider LPGAJGPGKFM)
		{
		}

		public global::FAIKNKAIPLB<OHAJOLBEFND> Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		private void KCKAPEICBBP(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void FBIMEJGNDAF(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private bool MCMNPIPEFIO()
		{
			return false;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Equip(JEGAPHLGBJA GCBHEJANCJK, CHILKDJABBF EKOFNPFCLMO)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Unequip(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		private bool IFEJLJHHBMJ()
		{
			return false;
		}

		public virtual void RemoveSkinning()
		{
		}

		private void NBPEOPANJMK(GBAJDOHJDHJ HFEKGOLNKOL)
		{
		}

		public abstract void AssertCostumePlacedCorrectly();

		[CompilerGenerated]
		private void DMIHCECGBFO()
		{
		}

		[CompilerGenerated]
		private void DMNIDPIHLHO()
		{
		}
	}
}
