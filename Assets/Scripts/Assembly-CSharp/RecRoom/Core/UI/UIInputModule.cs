using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RecRoom.Core.UI
{
	public class UIInputModule : BaseInputModule, GBBFHAOMGIF
	{
		public struct ELJCKCAHPDA
		{
			[CanBeNull]
			public GameObject GAAFHNIMBEL;

			public bool OKOFOGBNCKL;

			public float NMOGLNDGKPA;

			public bool GBIKOGDOEEF;

			public float DKMIJGDCJLB;

			public bool IAEFGCFFNLC;

			public bool ADOHBEFDDHN;

			public bool ADOJOKHKMHA;
		}

		public struct GJFEIPEOFAK
		{
			public GameObject HPNKOBLPDCM;

			public Vector3? DCOKPMBIOIM;

			public Vector3 JDBBENOCDCK;

			public Vector3? EOCOFNLPMCC;

			public Selectable DELFJHDHKCB;

			public BaseRaycaster ANMEANJMPCO;

			public GameObject AAAAABNMIJI;

			public PhysicalButtonBase KHGIAEMPMPD;

			public RaycastHit? OBEHFLNIACN;

			public GameObject PJAGKLBOPHP;

			public GameObject LEBLOBOOALI;

			public float BNJNAMCMGJE;

public bool FCNJPLIKHNI
{
get 			{
				return false;
			}

}

public bool EBKFBLFPPLB
{
get 			{
				return false;
			}

}

public bool HJCHEBLHBDK
{
get 			{
				return false;
			}

}

public bool EALGFIMKAKP
{
get 			{
				return false;
			}

}

public bool DMPHHIIPHCO
{
get 			{
				return false;
			}

}

public bool PNHJEHDPOMO
{
get 			{
				return false;
			}

}

public bool HEACDGALFOO
{
get 			{
				return false;
			}

}

public bool GGHHOFKKJCK
{
get 			{
				return false;
			}

}

			public void GLBPPAIACJF()
			{
			}

			public string APHABFCDAMP()
			{
				return null;
			}
		}

		public struct NECPNLJBNAH
		{
			public bool NIKCHMKNEMP;

			public bool CINGFLJNHPL;

			public Vector2 BKINIEMFNII;

			public bool HKBJMPGPOLA;

			public bool KJIDICLKHAI;

			public bool LMGCCKOAFFC;

			public bool JOOEJMPBLBN;

			public bool AANHDNFJJKA;

			public float? GFHAENCCHOP;

			public float? EKCIJGJFOKG;
		}

		public struct IAPKENCHHMC
		{
			public bool OEKNECMBJCK;

			public bool CCFAFBPIGMA;

			public bool LELFMKNKDOP;

			public bool LMMBKIHAGJA;

			public bool DDKHPJBNCCL;

			public bool IMNGKBDMICM;

			public PointerEventData FECNINFEHCO;

			public void GLBPPAIACJF()
			{
			}
		}

		private class LBCCADGGNBN
		{
			public GameObject MENMEKKEKAO;

			public GameObject NCKFHOEODJN;

			public GameObject HJMHNBALAMK;

			public GameObject GDGIALGHAHA;

			public PointerEventData HLMEKEJJPIN;

			public Vector3? CDBGPJAEGGE;

			public Vector3? CCNDNEBHNMF;

			public Transform FGNGGLFNLIP;

			public GameObject FAMICEHJMGB;

			public GameObject LJBJNLFLOHN;

			public float IPHIFJJKIAD;

			public float HHDDAMLIBEB;

			public float GCDFOIIOHKA;

			public float KJEMEBMKMGO;

			public bool CKAPIIDJKDI;

			public bool HPJKMLKKDFC;

			public bool DFDNLCFKCHI;

			public bool LCKNCBBGBLL;

			public void ENIHCGAHOGH(RaycastResult CFOEBLBCFBB)
			{
			}

			public Vector3? JNCABEPCFCH()
			{
				return null;
			}
		}

		private sealed class JAIBPAIHAKB
		{
			public ELJCKCAHPDA raycastOptions;

			public UIInputModule _003C_003E4__this;

			public int cursorId;

			internal bool _003CUpdateRaycastsWorldSpace_003Eg__IsPartOfRoot_007C0(GameObject childObject)
			{
				return false;
			}

			internal bool _003CUpdateRaycastsWorldSpace_003Eg__PushButtonCollisionFilter_007C1(Collider collider)
			{
				return false;
			}

			internal bool _003CUpdateRaycastsWorldSpace_003Eg__HitValidImposter_007C3(ref PBEFOHPCCNL P_0)
			{
				return false;
			}

			internal bool _003CUpdateRaycastsWorldSpace_003Eg__ValidateUIHit_007C4(ref PBEFOHPCCNL P_0)
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct PBEFOHPCCNL
		{
			public PointerEventData pointerEventData;

			public float uiDistance;

			public Vector3 playerHeadToPoint;

			public Vector3 playerHeadForward;

			public GameObject hitObject;

			public UIInputMaxRayDistance maxDistanceCheck;

			public UIInputSettings hitObjectSettings;
		}

		public static UIInputModule Instance;

		private readonly EEANDDJEMJC AMHCEKEHIEJ;

		public static float ScrollSensitivity;

		private const float BJFKHJOHBFJ = 1920f;

		private const float OJKHMAPLNJH = 1080f;

		public const float CONTROLLER_CAMERA_FAR_CLIP = 20f;

		private const float ODCCKGIPLIB = 0.2f;

		private const float OMHHHLJNEGG = 0.1f;

		[SerializeField]
		private int maxCursorCount;

		public float MaxUIHeadAngle;

		[SerializeField]
		private float dragAngleThreshold;

		public static float DragDistanceThreshold;

		[SerializeField]
		private float vrTouchDistanceThreshold;

		[SerializeField]
		private bool useCustomReferenceCamera;

		[SerializeField]
		private Camera customReferenceCamera;

		public readonly global::HHOBPMOCKMJ<GameObject> onPointerPressed;

		private LBCCADGGNBN[] EHDILGGIIGC;

		private Camera COMLJLOEGCA;

		private GameObject PBHJNNAOPEA;

		private List<GameObject> EBOJHAHEIJB;

		private List<GameObject> EDHEINGHEBD;

		private Dictionary<GameObject, (bool, Selectable)> HBFMDDMKCCM;

		private Dictionary<GameObject, (bool, GameObject)> HENKEBGDEDN;

		private Dictionary<GameObject, (bool, ScrollRect)> PDDFIOGJABN;

		private Dictionary<GameObject, (bool, BBJMJGEGLDN)> AEBMMGAJFBN;

		private Dictionary<GameObject, (bool, DragScrollDecorator)> PIHEJLLFPFD;

		private Dictionary<GameObject, (bool, GameObject)> HFKBBCCNCLI;

		private Dictionary<GameObject, (bool, Tooltip)> LJDAKLPEGKO;

		private Dictionary<GameObject, (bool, ScrollRectMovementEnforcer)> NJOFMJPLDIP;

public EEANDDJEMJC BeforeRaycastEvent
{
get 		{
			return null;
		}

}

public global::HHOBPMOCKMJ<GameObject> OnPointerPressed
{
get 		{
			return null;
		}

}

public Camera ControllerCamera
{
get 		{
			return null;
		}

private set {
		}
}

private Camera LGHELJBAPPF
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public override void Process()
		{
		}

		public GJFEIPEOFAK UpdateRaycastsWorldSpace(int FMNLEENGNED, Camera GAPPCJHIBEK, Vector2 OADOFEDJPMP, ELJCKCAHPDA DMMDPMFCBHN, bool NFHMOOOIMBK = true)
		{
			return default;
		}

		public GJFEIPEOFAK UpdateRaycastsWorldSpace(int FMNLEENGNED, Vector3 INLGLHIPOMC, Vector3 BPKEANIGKON, ELJCKCAHPDA OBFMJAEJJIG)
		{
			return default;
		}

		public GJFEIPEOFAK UpdateRaycastsScreenSpace(int FMNLEENGNED, Vector2 OADOFEDJPMP)
		{
			return default;
		}

		public void UpdateUIRaycast(int FMNLEENGNED, Camera GAPPCJHIBEK, Vector2 OADOFEDJPMP)
		{
		}

		public IAPKENCHHMC UpdateInput(int FMNLEENGNED, NECPNLJBNAH DMMDPMFCBHN)
		{
			return default;
		}

		public void ClearCursorTarget(int FMNLEENGNED)
		{
		}

		private void EAMFFIEFIHD(int FMNLEENGNED, bool HPJKMLKKDFC, out bool DDAFNFOODCG)
		{
			DDAFNFOODCG = default;
		}

		private void ILFIMIOJOJF(int FMNLEENGNED, out bool DBDJKENIKHF, out bool JIHEPFBEKPI)
		{
			DBDJKENIKHF = default;
			JIHEPFBEKPI = default;
		}

		private void GEEPCCLJFOB(int FMNLEENGNED, out bool JIHEPFBEKPI)
		{
			JIHEPFBEKPI = default;
		}

		private void JAOMPCNAGOB(int FMNLEENGNED, GameObject EABCHFPOCNL)
		{
		}

		private void GCAHHPMJIBC(int FMNLEENGNED)
		{
		}

		private void BCHFBFPMBGE(int FMNLEENGNED, Vector2 LPILGBPKMNM)
		{
		}

		private static float DAFCHELICAN(float CNNCFMJCGJJ, float PGKMADBPFDN, float DPCLJFLKEAO, float LNPDCALEDMK)
		{
			return 0f;
		}

		private void BHKJCKNFBOA(int FMNLEENGNED, bool POPPCNBIHKC, bool DIDCCFBCCLE, bool CKAPIIDJKDI, bool DDAFNFOODCG, bool DBDJKENIKHF, bool JIHEPFBEKPI, bool EDOGGKENOII, bool EFBKIJIDGND, out IAPKENCHHMC FCHPFBFNFAG)
		{
			FCHPFBFNFAG = default;
		}

		private bool GOPKILEEEHK(int FMNLEENGNED)
		{
			return false;
		}

		private bool KMMAIHHKICP(int FMNLEENGNED, Vector2 OADOFEDJPMP)
		{
			return false;
		}

		private bool FAAHPHGBMJJ(RaycastResult CDNLFEOBNKB)
		{
			return false;
		}

		private bool LJJHIOFBFKC(int FMNLEENGNED, Vector2? OADOFEDJPMP)
		{
			return false;
		}

		private void EDHHLILNIIK(LBCCADGGNBN EBIMENIICMG, RaycastResult BKKMNNHAPGN)
		{
		}

		private void PNBFCAHCMGF(int FMNLEENGNED, GameObject MMIDCACDCIA = null)
		{
		}

		private void PIDIMDHKGIC(Vector3 INLGLHIPOMC, Vector3 BPKEANIGKON)
		{
		}

		private bool OHNONIMPEBL<T>(GameObject ONCGIPFNENB, Dictionary<GameObject, (bool, T)> MGGAFPGBPKK, out bool PBMLOOCKCLB, out T KLMCNEIFLMA)
		{
			PBMLOOCKCLB = default;
			KLMCNEIFLMA = default;
			return false;
		}

		private bool HDKJDGNLAJC<T>(GameObject ONCGIPFNENB, Dictionary<GameObject, (bool, T)> MGGAFPGBPKK, out T GLCFIEMIMHN)
		{
			GLCFIEMIMHN = default;
			return false;
		}

		private bool IACENPMFGJK<T>(GameObject ONCGIPFNENB, Dictionary<GameObject, (bool, GameObject)> MGGAFPGBPKK, out GameObject GBHIHDDAOLK) where T : IEventSystemHandler
		{
			GBHIHDDAOLK = null;
			return false;
		}

		private void MMCBMFGFGJE(int FMNLEENGNED, PhysicalButtonBase IOHAEHLHKBL, RaycastHit DPKJHNJJCPD, bool LKMKIEIBFML, out GJFEIPEOFAK CDNLFEOBNKB)
		{
			CDNLFEOBNKB = default;
		}

		private void IKPALAHGAPP(GameObject ONCGIPFNENB, out GameObject FAMICEHJMGB, out float IPHIFJJKIAD, out float GCDFOIIOHKA, out GameObject LJBJNLFLOHN, out float HHDDAMLIBEB, out float KJEMEBMKMGO)
		{
			FAMICEHJMGB = null;
			IPHIFJJKIAD = default;
			GCDFOIIOHKA = default;
			LJBJNLFLOHN = null;
			HHDDAMLIBEB = default;
			KJEMEBMKMGO = default;
		}

		private void IFDFAMLFAAC(ScrollRect IBECFKIMJNF)
		{
		}

		private bool KCDLEKNDDHD()
		{
			return false;
		}

		private static int BMIKLDCNPMG(RaycastResult NNMPJECKECI, RaycastResult EFNJCAIBDLA)
		{
			return 0;
		}

		private static RaycastResult CGGJFDMLNGO(List<RaycastResult> ILJGHKGMILC)
		{
			return default;
		}

		private bool EIDKNKADDIA(PhysicalButtonBase HHDMPJJAPJJ, RaycastHit DFLMIKPEDCJ, Vector3 MEPGPPIOIAD)
		{
			return false;
		}

		private void COAKGPJGDJH(GameObject AEBLODLNJAA)
		{
		}

		private void OFPLIODAOEE(GameObject AEBLODLNJAA, PointerEventData HLMEKEJJPIN, out GameObject LABNCLKAOBH)
		{
			LABNCLKAOBH = null;
		}

		private bool PDNIDOAFLLP(int FMNLEENGNED, NECPNLJBNAH DMMDPMFCBHN, out GameObject EABCHFPOCNL)
		{
			EABCHFPOCNL = null;
			return false;
		}

		private bool FJGKJOBDOMK(GameObject EABCHFPOCNL, LBCCADGGNBN EBIMENIICMG, NECPNLJBNAH DMMDPMFCBHN)
		{
			return false;
		}

		private bool EJOJFEMIKKP(LBCCADGGNBN EBIMENIICMG, NECPNLJBNAH DMMDPMFCBHN)
		{
			return false;
		}

		private bool AENFPENDDOP(LBCCADGGNBN EBIMENIICMG, GameObject JFNKFMPOFND, bool FADKFHFHOHL)
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}

		[CompilerGenerated]
		internal static bool BMIJOIKLFDP(Collider ADMCDJKKCIA)
		{
			return false;
		}

		[CompilerGenerated]
		private bool BCMDGFBNPOP(RaycastResult GOJCEBCMFJK)
		{
			return false;
		}

		[CompilerGenerated]
		private bool AHNMAIEBJDC(RaycastResult GOJCEBCMFJK)
		{
			return false;
		}

		[CompilerGenerated]
		internal static bool PNEBAAPDECA(Vector2 MLIPDLAHDHI, float IHPJCBCPLCM)
		{
			return false;
		}
	}
}
