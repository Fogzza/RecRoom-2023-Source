using System;
using RecRoom.Core.Creation;
using RecRoom.Tools;
using RecRoom.Tools.MakerPenTools;
using UnityEngine;

namespace RecRoom.Core
{
	[Serializable]
	public abstract class CreationController
	{
		public struct KCJLEJAHMEB
		{
			public float GADEOBMPDPB;

			public Vector3 EOKDDKDJNEC;
		}

		private sealed class IIKCMELJNHM
		{
			public Player player;

			public Vector3 cameraPosition;

			internal bool _003CRespawnPlayerOutOfSelfScale_003Eb__0()
			{
				return false;
			}

			internal void _003CRespawnPlayerOutOfSelfScale_003Eb__1()
			{
			}
		}

		public const float SPHERECAST_PICKING_RADIUS = 0.01f;

		public const float SELF_SCALE_MIN_SIZE = 0.33f;

		public const float SELF_SCALE_MAX_SIZE = 30f;

		private const float SELF_SCALE_MAX_DORM_SIZE = 1.5f;

		public const int CREATOR_PRIORITY = 100000;

		public const string ATTACHED_MENU_OPEN_HAND_LASER_RESTRICTION_TOKEN = "ATTACHED_MENU_OPEN_HAND_LASER_RESTRICTION_TOKEN";

		public const string CREATION_INPUT_HAND_LASER_RESTRICTION_TOKEN = "CREATION_INPUT_HAND_LASER_RESTRICTION_TOKEN";

		private const string MAKER_PEN_HAND_TOKEN = "CREATION_CONTROLLER_MAKER_PEN_HAND_TOKEN";

		private const string SELF_SCALE_TOKEN = "CREATION_CONTROLLER_SELF_SCALE_TOKEN";

		[SerializeField]
		private MakerPenToolConfig makerPenToolConfig;

		[SerializeField]
		private TranslationSnappingVisualization translationSnappingVisualizationPrefab;

		[NonSerialized]
		private FIHGBEHGLGB pendingInventionPermissionsRequestFlag;

		[NonSerialized]
		private TranslationSnappingVisualization _translationSnappingVisualization;

		[NonSerialized]
		private SelfScaleVisualization _selfScaleVisualization;

		public MakerPen MakerPen { get; set; }

		public CreationContext CreationContext { get; set; }

		public HGNHFBBBPNE MakerPenToolsManager { get; private set; }

		public TranslationSnappingVisualization TranslationSnappingVisualization => null;

		public SelfScaleVisualization SelfScaleVisualization => null;

		public float SpherecastPickingRadius => 0f;

		public bool IsInventionPermissionsRequestPending => false;

		public static float SelfScaleMaxSize => 0f;

		protected abstract Transform InternalTransform { get; }

		public abstract DLLIMLHNBON SelectInputButtonState { get; }

		public abstract float AnalogInputValue { get; }

		public bool IsScreenMode => false;

		public Vector3 Position => default;

		public Vector3 Forward => default;

		public Vector3 Up => default;

		public Vector3 Right => default;

		public Quaternion Rotation => default;

		public bool IsSelectInputPressed => false;

		public bool IsSelectInputDown => false;

		public bool IsSelectInputUp => false;

		public bool IsAnalogButtonPressed => false;

		public bool HasInput => false;

		public abstract Ray GFDICPJIEJB();

		public abstract Vector3 ILLMHPKDFLD(float PNJHHGDHBEC);

		public virtual void FLBEPMPANEL(object IALNODEHBNN)
		{
		}

		public virtual void AMFPGMNBIDB(object IALNODEHBNN)
		{
		}

		public virtual bool HCLGHJAMCNC()
		{
			return false;
		}

		public KCJLEJAHMEB PHIADJGIODO(Vector3 ADJINPMOILO)
		{
			return default;
		}

		public Vector3 KPHKMOBEHJM(KCJLEJAHMEB LMDNHLDFGAL)
		{
			return default;
		}

		public Vector3 ELHOLGIFCEA(float GADEOBMPDPB)
		{
			return default;
		}

		public Quaternion NFDFDILDNGN(Quaternion LLJPMBHCKEE)
		{
			return default;
		}

		public Quaternion DPNNGCNMINJ(Quaternion IBHAEICNMJI)
		{
			return default;
		}

		public virtual void IHEKMEOIBOI()
		{
		}

		public virtual void BJDNGFKFKPK(MakerPen BHCCDMJFHEO)
		{
		}

		public virtual void EHMICKMBCPH()
		{
		}

		public virtual void KENBMBNOMKI()
		{
		}

		public void PKKPIFOFPEK(HHNPLBOFAGE IACECANFEKI, FBEHJNCKJPN CIMCLAFMGFE, EHLHPNPGFLN HANBCMDMCAG, bool GLHCHFANPOP = false)
		{
		}

		public void JBBCNLEKDEP(object IALNODEHBNN)
		{
		}

		public void KNABLLLBMDG(object IALNODEHBNN)
		{
		}

		public static void KCIPJGCJDPJ(Player EKOFNPFCLMO, Vector3 DBGNCAACKOB)
		{
		}

		protected virtual void HHLDDEGPLKP(FBEHJNCKJPN CIMCLAFMGFE, HHNPLBOFAGE IACECANFEKI)
		{
		}

		private void NEOHFAHCFDN()
		{
		}

		private void IGKMPAHFCGA()
		{
		}

		private void JOADLLOKOOC()
		{
		}

		public void BPCHKCJHPPN(FBEHJNCKJPN JDCKGDCLODG)
		{
		}

		private void OODJFAIFOCK()
		{
		}

		private void DDLMMFKACKF()
		{
		}

		public void HPPDGAJJHGL()
		{
		}

		private void HGIGPBCBLMN()
		{
		}

		private void GODDMILEBEB(AMEPDCGKFOG DGCFKGEOHOL)
		{
		}

		private void IHJEFJEMAIH(JLHLKDMLBPK IMNKGCAONMB)
		{
		}

		private void BMNBKNINEGP(MJGMBIJIKFH JIFEMEBBEBP)
		{
		}

		private void GHLHIMLJLOA(JECDPJHHBNL HDMIPGPFAPH)
		{
		}

		private void APJEEAPCFDC(JBGFOIKBKED GGGDDKHHCNI)
		{
		}

		private void CJDOJAMJNFM(OEBAEGDPBLA JCIJHAKCGPM)
		{
		}

		private void AGJCDKKIOGC(LFIOJFLIPFC EEKOIHMJIDP)
		{
		}

		private void HKNKFJDKIGL(long KBPFKPGOCFN)
		{
		}
	}
}
