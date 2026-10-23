using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Core.Creation.CircuitsV1;
using TMPro;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class SandboxColorable : MonoBehaviourPun, DJLCHGFCFAD, GAAKCFPLMHN, CDLJEIPOPKP
	{
		public enum AIEHLICFMOF
		{
			Color = 0,
			ColorAndMaterial = 1
		}

		public enum HOOGOINPCOG
		{
			Albedo = 0,
			Emission = 1,
			Specular = 2
		}

		[Serializable]
		public class CustomColorChannel
		{
			public string PropertyName;

			public HOOGOINPCOG ColorType;
		}

		[Serializable]
		public class ParticleSystemColorSettings
		{
			public ParticleSystem Particles;

			public bool OverrideStartColor;

			public HOOGOINPCOG StartColorMinSource;

			public HOOGOINPCOG StartColorMaxSource;
		}

		public const string PrimaryLabel = "Color";

		[SerializeField]
		private int ConfigurePriority;

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private AIEHLICFMOF RecolorMode;

		[SerializeField]
		private bool UseDefaultColor;

		[SerializeField]
		private JLHLKDMLBPK DefaultColor;

		[SerializeField]
		private bool UseDefaultMaterial;

		[SerializeField]
		private MJGMBIJIKFH DefaultMaterial;

		[SerializeField]
		private CircuitEventNodeDisplay circuitNodeDisplay;

		[SerializeField]
		private bool UseColorCircuitInput;

		[SerializeField]
		private EDBMANFHGGO ColorCircuitInputSlot;

		[SerializeField]
		private bool UseMaterialCircuitInput;

		[SerializeField]
		private EDBMANFHGGO MaterialCircuitInputSlot;

		private global::CDLJMENCODC<int> OJMGNENEOMH;

		private global::CDLJMENCODC<int> BHAIHBJEILN;

		private global::JCAAOOPEEAM<bool, Color> JGCIIKIHEIK;

		public bool _applyAlbedo;

		public bool _applyEmission;

		public bool _applySpecular;

		public bool _useAlbedoAlpha;

		private float EOHMPIPOJDK;

		[SerializeField]
		private CustomColorChannel[] _customChannels;

		[SerializeField]
		private Renderer[] colorableRenderers;

		[SerializeField]
		private Renderer[] colorOnlyRenderers;

		[SerializeField]
		private Light[] colorableLights;

		[SerializeField]
		private TextMeshPro[] colorableTextMeshPros;

		private readonly Dictionary<UnityEngine.Object, Color> KBJBBLGFKEI;

		private readonly Dictionary<UnityEngine.Object, Material> EELLBKPJNBB;

		[SerializeField]
		private ParticleSystemColorSettings[] _particleSystems;

		private ParticleSystem.MinMaxGradient[] AEGENIDPBFD;

		private MaterialPropertyBlock HOOJEGOGAPE;

		private Material MAEMCDOBFAC;

		private HashSet<Func<string>> JKMIPCHGIIE;

		private bool KIOKNGCFMAH;

		private Action HLMBFPBHCMM__BackingField;

		private Action HBEKONGDGII__BackingField;

		private KCOKPCOFDIM NNACNBHCIDD;

public Tool Tool
{
get 		{
			return null;
		}

}

public JLHLKDMLBPK MakerPenColor
{
get 		{
			return JLHLKDMLBPK.RRO_MIN_VALUE;
		}

set {
		}
}

public MJGMBIJIKFH MakerPenMaterial
{
get 		{
			return MJGMBIJIKFH.CARDBOARD;
		}

set {
		}
}

public bool HasMakerPenMaterial
{
get 		{
			return false;
		}

}

public Color? RGBColor
{
get 		{
			return null;
		}

set {
		}
}

public Color? PersistentRGBColor
{
get 		{
			return null;
		}

set {
		}
}

public float AlbedoAlpha
{
get 		{
			return 0f;
		}

set {
		}
}

public Color AlbedoColor
{
get 		{
			return default;
		}

}

public Color EmissionColor
{
get 		{
			return default;
		}

}

public Color SpecularColor
{
get 		{
			return default;
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

public event Action PreSandboxColorChangedEvent {
add {
		}
remove {
		}
}

public event Action SandboxColorChangedEvent {
add {
		}
remove {
		}
}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetMakerPenColor(JEGAPHLGBJA GCBHEJANCJK, JLHLKDMLBPK LNBGDJLPKJM)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetMakerPenMaterial(JEGAPHLGBJA GCBHEJANCJK, MJGMBIJIKFH APGHJHBHCFA)
		{
			return default;
		}

		public void TrySetDefaultRGBColor(Color HMCAFGCGFJF)
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		public void RegisterEditables()
		{
		}

		public KCOKPCOFDIM GetColorPickerDialog(Action<CLKEJFGKNDK, AMFPEDOFIGE> GFNPBKFLPEB)
		{
			return null;
		}

		public void ForceCloseMenu()
		{
		}

		public void ForceDismissDialog()
		{
		}

		private void OnEnable()
		{
		}

		private void JMCADDADDAD(EquipmentSkin BMPCEMBIGBB)
		{
		}

		private void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void BCNECDJCKEE(Dictionary<EDBMANFHGGO, int> CIPFGHFHANF)
		{
		}

		private void EFIAMPNDICI()
		{
		}

		private IFCBCACOLMJ LKKAHDOMAEK(GGHECEJBHPI DELCOFCGDFF, params object[] BHOKKEBBPNA)
		{
			return null;
		}

		private Color AFHMEFHBJDI(HOOGOINPCOG BNAIOANIBMH)
		{
			return default;
		}

		private void FJENPCHLEII()
		{
		}

		private void KJCKBFCPPNC()
		{
		}

		public void UpdateDisplay()
		{
		}

		private void IJFPCPAODND()
		{
		}

		private void CNPAIKIPPJO(Renderer[] DJIABPPMOOD)
		{
		}

		private JLHLKDMLBPK MJFJCLMDCAL()
		{
			return JLHLKDMLBPK.RRO_MIN_VALUE;
		}

		private MJGMBIJIKFH AFKLFOJBPDF()
		{
			return MJGMBIJIKFH.CARDBOARD;
		}

		public void AddRecolorCondition(Func<string> NHJPBHJLFOD)
		{
		}

		public void RemoveRecolorCondition(Func<string> NHJPBHJLFOD)
		{
		}

		public void SetSynchronizing(bool BLOCPPAOJDM)
		{
		}

		private void LMLAPKCIDDI()
		{
		}

		void GAAKCFPLMHN.ResetObject()
		{
			//ILSpy generated this explicit interface implementation from .override directive in LMLAPKCIDDI
			this.LMLAPKCIDDI();
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private Color CCNFPKMFCCI()
		{
			return default;
		}

		[CompilerGenerated]
		private int OHLFADNADBK()
		{
			return 0;
		}

		[CompilerGenerated]
		private void IOEOPGJGDFL(int FEGOOFNBPPL)
		{
		}

		[CompilerGenerated]
		private bool NHLLNCGGEDF()
		{
			return false;
		}

		[CompilerGenerated]
		private bool IBBEJPEGNIG()
		{
			return false;
		}

		[CompilerGenerated]
		private int AMBIMLPHKEB()
		{
			return 0;
		}

		[CompilerGenerated]
		private void BGHOOBOCNJM(int MEHPHGGOMLI)
		{
		}

		[CompilerGenerated]
		private int HJJBHGLPMGN()
		{
			return 0;
		}

		[CompilerGenerated]
		private bool OMNDFBHCIAI()
		{
			return false;
		}

		[CompilerGenerated]
		private int FHGEDAEBCBN()
		{
			return 0;
		}

		[CompilerGenerated]
		private void MPAMHODNHPB(int FEGOOFNBPPL)
		{
		}
	}
}
