using System.Collections.Generic;
using ExitGames.Client.Photon;
using RecRoom.Players;
using UnityEngine;

namespace RecRoom.Avatars.Face
{
	[ExecuteAlways]
	public class PlayerFacialAnimator : MonoBehaviour, KFLNCOLKJEM
	{
		public class HNFBOCDEOGD
		{
			private const int CMAOAFBBAPL = 4;

			private PlayerFacialAnimator DELCOFCGDFF;

			public int LGIICDOEGFI;

			public int BEJPCKACHGP;

			public int NALDAFDDLJI;

			public Vector2 BMJDOHFGEGO;

			public Vector2 EFFKMEOJAEB;

			public float LMCKCNHONBP;

			public readonly bool[] BGKIMLFGCCB;

			private static readonly ELFDKCLHAMN DGJEOFHPNDP;

			public static short IIADKJHBOIN(StreamBuffer HLHADAOGCMN, object PJGPNPBFMFD)
			{
				return 0;
			}

			public static object BBCFAILGGHN(StreamBuffer FAMJGEFEDDM, short MNKGPEKFPKK)
			{
				return null;
			}
		}

		private const float AMPEPCMPNGF = 0.5f;

		private const float KEIHAGAPCOK = 0.5f;

		private const float CINFJKDCJGL = 0.3f;

		private const int EEJHIJMALPF = 5;

		public static readonly int IdleID;

		public static readonly int SmileID;

		public static readonly int HugeSmileID;

		public static readonly int ScoreID;

		public static readonly int SadID;

		public static readonly int DisgustID;

		public static readonly int HitID;

		public static readonly int ConcentrateID;

		public static readonly int KissID;

		public static readonly int TalkingID;

		public static readonly int MuteID;

		public static readonly int AFKID;

		public static readonly int HappyID;

		public static readonly int EmoteFlatID;

		public static readonly int EmoteHappyID;

		public static readonly int EmoteSadID;

		public static readonly int EmoteLoveID;

		public static readonly int EmoteAngryID;

		public static readonly int EmoteLaughID;

		public static readonly int EmoteTongueOutID;

		public static readonly int EmoteGrimacingID;

		public static readonly int EmoteWinkID;

		public static readonly int EmoteShockedID;

		public static readonly int EmoteNauseatedID;

		public static readonly int EmoteSmileSweatID;

		public static readonly int EmoteSleepingID;

		public static readonly int EmoteThinkingID;

		public static readonly int EmoteSmirkID;

		public static readonly int EmoteSmileID;

		private static readonly Dictionary<PlayerEmotes.PDHFIKBMGOD, int> DOEAOLDCIFK;

		private static readonly int HHEJMPJOMIL;

		private static readonly int DHFHCCNKEDG;

		private static readonly int ODFMADIADJA;

		private static readonly int KMFAACMPIPE;

		private static readonly int DJBMHIKNOPN;

		private static readonly int EHDCHGNNFMG;

		private static readonly int JKBCHDKJEHE;

		private static readonly int PMFABGJFHEK;

		public static readonly Vector2 EyeBrowsHorizontalPositionRange;

		public static readonly Vector2 EyeBrowsVerticalPositionRange;

		public static readonly Vector2 EyeBrowsScaleRange;

		public static readonly Vector2 EyesHorizontalPositionRange;

		public static readonly Vector2 EyesVerticalPositionRange;

		public static readonly Vector2 EyeScaleRange;

		public static readonly Vector2 MouthHorizontalPositionRange;

		public static readonly Vector2 MouthVerticalPositionRange;

		public static readonly Vector2 MouthScaleRange;

		private const float KEDEHDNJIMC = 0.05f;

		private const float ONKHPGNOBGP = 0.05f;

		private const float KHBGOLPHDAK = 0.05f;

		private const float HMMGCEPLAOA = 0.2f;

		private const float ANMHDDNMNCG = 10f;

		private const float DLAAEODJCAK = 0.1f;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Player player;

		[SerializeField]
		public FaceStyleSet faceStyleSet;

		[SerializeField]
		private Renderer faceRenderer;

		[SerializeField]
		private float jitterFPS;

		[SerializeField]
		public Renderer[] emoteEffectRenderers;

		[SerializeField]
		private Vector2 remapFaceBonesToUVsAnchor;

		[SerializeField]
		private Vector2 remapFaceBonesToUVsScale;

		[SerializeField]
		private float remapFaceBonesJitterMultiplier;

		private const int ALNENEFDLEJ = -1;

		private int HAPKPIGNEFN;

		private int DIGENGJIPIO;

		private int PANCCBNCLGH;

		private int MJHDMGBBGGK;

		private int MBKLLIHIKNI;

		private Vector2 NGNEJFBPNNA;

		private float COJKPPKNCAB;

		private Vector2 OAHKBDPFALB;

		private float DMKHENCKEOP;

		private Vector2 NKNFNFNPFJE;

		private float KPPPDKELNPM;

		private List<FaceFeatureBase> LMLOPCKAKFF;

		private List<FaceFeatureBase> IHNLECMJOJL;

		private List<FaceFeatureBase> EFLGEMIPNAK;

		private List<FaceFeatureBase> PKKFGNBEMEP;

		private Coroutine DPPMJGEEKHO;

		private int? PDIONNJAFFD;

		private int OKANFFJNBGH;

		private int PICIJGNILDB;

		private int OBPFLGLCMII;

		private int PGGOLHIPFII;

		private int FDLLAGNLAOG;

		private int JBEHHDAJPBL;

		private int PODJBBFDKEM;

		private int BJGCNJKICPC;

		private float CJAGDFMKGCL;

		private bool GBIADKIGAFK;

		private EDEHLIJKFKO JOBFFPPEOJC;

		[EFEFIKFHIDK]
		public Sprite eyeBrowSprite;

		[EFEFIKFHIDK]
		public Sprite leftEyeBrowOnlySprite;

		[EFEFIKFHIDK]
		public Sprite rightEyeBrowOnlySprite;

		[EFEFIKFHIDK]
		public Sprite eyeSprite;

		[EFEFIKFHIDK]
		public Sprite leftEyeOnlySprite;

		[EFEFIKFHIDK]
		public Sprite rightEyeOnlySprite;

		[EFEFIKFHIDK]
		public Sprite eyeGleamSprite;

		[EFEFIKFHIDK]
		public Sprite leftEyeGleamOnlySprite;

		[EFEFIKFHIDK]
		public Sprite rightEyeGleamOnlySprite;

		[EFEFIKFHIDK]
		public Sprite mouthSprite;

		[HideInInspector]
		public Vector2 dynamicEyeOffset;

		[HideInInspector]
		public Vector2 dynamicMouthOffset;

		[HideInInspector]
		public float dynamicMouthRollDegrees;

		private bool JOOMIKOPCBN;

		private float DPEMBLJNDDK;

		private HIDAODIFFIL EJNPOPPJPCO;

		private MaterialPropertyBlock HJMGJHJKGAO;

		private Dictionary<Sprite, int> PPBOPNBOGIJ;

private static float CAPEOGGIFIM
{
get 		{
			return 0f;
		}

}

private bool BHKJJHLFKIJ
{
get 		{
			return false;
		}

}

private int HAEBJIOFBHJ
{
get 		{
			return 0;
		}

}

public Renderer FaceRenderer
{
get 		{
			return null;
		}

}

public bool UpdateMaterial
{
get 		{
			return false;
		}

set {
		}
}

public Renderer[] EmoteEffectRenderers
{
get 		{
			return null;
		}

}

public bool Talking
{
get 		{
			return false;
		}

set {
		}
}

private int EJBINICOIAO
{
get 		{
			return 0;
		}

}

private int NBLLOKKKEID
{
get 		{
			return 0;
		}

}

public float AnimationSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public EDEHLIJKFKO FaceDisplaySystem
{
get 		{
			return null;
		}

set {
		}
}

public HIDAODIFFIL ActiveFaceStyle
{
get 		{
			return null;
		}

set {
		}
}

private MaterialPropertyBlock DNAIGHJLBNO
{
get 		{
			return null;
		}

}

		public static Vector2 GetRandomEyePosition()
		{
			return default;
		}

		public static Vector2 GetRandomMouthPosition()
		{
			return default;
		}

		public static float GetRandomMouthScale()
		{
			return 0f;
		}

		public static float GetRandomEyeScale()
		{
			return 0f;
		}

		public void LocalPlayEmote(PlayerEmotes.PDHFIKBMGOD ABDDCLHIIHG, float KKPEJNBKHML = 0f)
		{
		}

		public bool IsEmotePlaying(PlayerEmotes.PDHFIKBMGOD ABDDCLHIIHG)
		{
			return false;
		}

		public void SetIdleHappy(bool DGCFBEPFLJI)
		{
		}

		private void HNFFMMNNGDD(bool CJBCBGBHACB)
		{
		}

		private void ACKDFEIENDH(bool JFBLMICANCL)
		{
		}

		private void GMGIJGHFGFL(Player.NBPIPAJOGLC MKLOBAIKINA)
		{
		}

		private void JCOMICOCHAP()
		{
		}

		private void FECLHJOGDHF(Tool IEGMBEPJMGC)
		{
		}

		private void BOGLMPCCMDC(Tool IEGMBEPJMGC)
		{
		}

		private void HBALFKKDLMH(Player.NBPIPAJOGLC MKLOBAIKINA, Tool IEGMBEPJMGC)
		{
		}

		private void PFHCKKIBBAD(Player.NBPIPAJOGLC MKLOBAIKINA, Player PLNGHFIMCDB, Player.NBPIPAJOGLC GFDCGAJJHML)
		{
		}

		private void NNFJOAKCCOC(int MGLDNCOMNCO)
		{
		}

		public void PlayExpression(int MGLDNCOMNCO)
		{
		}

		private void HJDFKMBOJHA(bool BOAEKEMJECB, bool BBNCKBDJMJP)
		{
		}

		public void CopyFaceSettingsTo(Renderer NBOEGEMEGDI, PlayerFacialAnimator HNPEBINPOBO)
		{
		}

		public List<FaceFeatureBase> GetAvailableFeatures(FaceFeatureType OABKPMOCHBJ)
		{
			return null;
		}

		public void SetFaceSettings(AvatarCustomizationSettings CAOIPCMMNMJ)
		{
		}

		public void SetSelectedFaceFeature(FaceFeatureType OABKPMOCHBJ, int JIBIMLGMIFN)
		{
		}

		public void SetSelectedFaceFeature(FaceFeatureType OABKPMOCHBJ, string JMIFIJDBMNM)
		{
		}

		public void SetFaceFeaturePositionOffset(FaceFeatureType OABKPMOCHBJ, Vector2 INLGLHIPOMC)
		{
		}

		public static float GetFaceFeatureAbsoluteScaleFromNormalizedScale(FaceFeatureType OABKPMOCHBJ, float GAIIMCPFNOG)
		{
			return 0f;
		}

		public static float GetFaceFeatureNormalizedScaleFromAbsoluteScale(FaceFeatureType OABKPMOCHBJ, float MKAOPNMOPJD)
		{
			return 0f;
		}

		public static Vector2 GetFaceFeatureAbsolutePositionFromNormalizedPosition(FaceFeatureType OABKPMOCHBJ, Vector2 JFKENNAIEBE, Vector2 BAMOOBENGAE, Vector2 AADPJMGEEII)
		{
			return default;
		}

		public static Vector2 GetFaceFeatureNormalizedPositionFromAbsolutePosition(FaceFeatureType OABKPMOCHBJ, Vector2 INLGLHIPOMC)
		{
			return default;
		}

		public static Vector2 ClampFaceFeaturePositionOffset(FaceFeatureType OABKPMOCHBJ, Vector2 INLGLHIPOMC, Vector2 BAMOOBENGAE, Vector2 AADPJMGEEII)
		{
			return default;
		}

		private static Vector2 IHNEBGAJADN(FaceFeatureType OABKPMOCHBJ)
		{
			return default;
		}

		private static Vector2 CGLNMPEIEAN(FaceFeatureType OABKPMOCHBJ, Vector2 JFKENNAIEBE)
		{
			return default;
		}

		private static float HFJEDMJPJKK(float IHPJCBCPLCM, float IFPPBNLHCCM, float PLKCNIBDCDC, float LIODLDNGDIO)
		{
			return 0f;
		}

		private static float NOODIHLHNIJ(float IPMIIEAGJKC, float IFPPBNLHCCM, float PLKCNIBDCDC, float LIODLDNGDIO)
		{
			return 0f;
		}

		public void SetFaceFeatureScaleOffset(FaceFeatureType OABKPMOCHBJ, float JDFDFBKKBPO)
		{
		}

		public static float ClampFaceFeatureScaleOffset(FaceFeatureType OABKPMOCHBJ, float JDFDFBKKBPO)
		{
			return 0f;
		}

		private void MDBIEBFEDHE()
		{
		}

		private bool HAOEDCEKOKH(Sprite DLADPCHJMME, out int GMEHLIHLGEH)
		{
			GMEHLIHLGEH = default;
			return false;
		}

		private void OnValidate()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private bool HANIENPBGAN()
		{
			return false;
		}

		private void LLIDOGMAFLA()
		{
		}

		private void LBIEMLPCBCO()
		{
		}

		private void LEGCHICOOAI()
		{
		}

		private void KJDMMKHGNBI(float OKBAJEAPIHG)
		{
		}

		public void OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
		}
	}
}
