using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Creation
{
	public abstract class BaseDynamicLight : MonoBehaviourPun, GAAKCFPLMHN
	{
		private const EDBMANFHGGO JFHNBHCKOBG = EDBMANFHGGO.R;

		private const EDBMANFHGGO PMNIIFGIDHJ = EDBMANFHGGO.G;

		private const EDBMANFHGGO ADPMJEPLLNP = EDBMANFHGGO.B;

		private const EDBMANFHGGO HJPGEOCHNLH = EDBMANFHGGO.C;

		private const EDBMANFHGGO MFANEIOLEDA = EDBMANFHGGO.M;

		private const EDBMANFHGGO BNKFHMCFPHH = EDBMANFHGGO.Y;

		private const EDBMANFHGGO PLALMIAKGCP = EDBMANFHGGO.K;

		private const float LDEGGBKNOJM = 1f;

		[SerializeField]
		protected SandboxColorable sandboxColorable;

		[SerializeField]
		private CircuitEventNodeDisplay circuitDisplayNode;

		[SerializeField]
		protected CreationObject creationObject;

		[SerializeField]
		private Light lightObject;

		[SerializeField]
		private URPLight urpLightObject;

		[SerializeField]
		private MeshRenderer[] lightVisuals;

		[SerializeField]
		private float rangeScalingFactor;

		[SerializeField]
		protected float minRange;

		[SerializeField]
		protected float maxRange;

		[SerializeField]
		protected float defaultRange;

		[SerializeField]
		private float intensityScalingFactor;

		[SerializeField]
		protected float minIntensity;

		[SerializeField]
		protected float maxIntensity;

		[SerializeField]
		private float defaultIntensity;

		[SerializeField]
		protected int minAngle;

		[SerializeField]
		protected int maxAngle;

		[SerializeField]
		private float defaultAngle;

		[SerializeField]
		private bool useURPAngle;

		[SerializeField]
		protected float minSoftness;

		[SerializeField]
		protected float maxSoftness;

		[SerializeField]
		private float defaultSoftness;

		[SerializeField]
		protected float minSpecular;

		[SerializeField]
		protected float maxSpecular;

		[SerializeField]
		private float defaultSpecular;

		private bool KIOKNGCFMAH;

		protected global::CDLJMENCODC<bool> EOEGBDADDCG;

		protected global::CDLJMENCODC<float> JIEGOFDHFKK;

		protected global::CDLJMENCODC<float> BAPBAJCDNAN;

		protected global::CDLJMENCODC<float> CGMOIPEOCDL;

		protected global::CDLJMENCODC<float> GAEGGODPNOE;

		protected global::CDLJMENCODC<float> KFBNEIENLKK;

public bool Emit
{
get 		{
			return false;
		}

set {
		}
}

public float Intensity
{
get 		{
			return 0f;
		}

set {
		}
}

public float Range
{
get 		{
			return 0f;
		}

set {
		}
}

public float Angle
{
get 		{
			return 0f;
		}

set {
		}
}

public float Softness
{
get 		{
			return 0f;
		}

set {
		}
}

public float Specular
{
get 		{
			return 0f;
		}

set {
		}
}

public int Color
{
get 		{
			return 0;
		}

}

protected bool HKGAOMLIDGJ
{
get 		{
			return false;
		}

set {
		}
}

protected float AHAJNOALBEM
{
get 		{
			return 0f;
		}

set {
		}
}

protected float LJJJMPEPPAG
{
get 		{
			return 0f;
		}

set {
		}
}

protected float GEFDEJDHFAL
{
get 		{
			return 0f;
		}

set {
		}
}

protected float HCCOINOBFNE
{
get 		{
			return 0f;
		}

set {
		}
}

protected float IILMLCANDAA
{
get 		{
			return 0f;
		}

set {
		}
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

		protected abstract void ALGOHCLKDAD();

		protected override void OnDestroy()
		{
		}

		public void OnInputsUpdated(Dictionary<EDBMANFHGGO, int> updates)
		{
		}

		private void DECAIKNELAG()
		{
		}

		private void KDBFHAJDPJG()
		{
		}

		private void LPFGFAOMJND()
		{
		}

		private void INNNNCDPBDE()
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetEmit(JEGAPHLGBJA GCBHEJANCJK, bool IPMIIEAGJKC)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetIntensity(JEGAPHLGBJA GCBHEJANCJK, float OHOALJOJBGA)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetRange(JEGAPHLGBJA GCBHEJANCJK, float MEPEJGGNHNE)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetAngle(JEGAPHLGBJA GCBHEJANCJK, float OFIJCNNPEHM)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetSoftness(JEGAPHLGBJA GCBHEJANCJK, float CJHIPJMIGBJ)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetSpecular(JEGAPHLGBJA GCBHEJANCJK, float IPKCANKECAH)
		{
			return default;
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

		protected void IOELCENAHBP(bool MENKCIKHJHG)
		{
		}

		private void IOELCENAHBP()
		{
		}

		protected void JNFDLLEAKOL(float OHOALJOJBGA)
		{
		}

		protected void KNFLKLCOKEG(float MEPEJGGNHNE)
		{
		}

		protected void JAPJJGPGBFG(float OFIJCNNPEHM)
		{
		}

		protected void FJINPCHNOLE(float CJHIPJMIGBJ)
		{
		}

		protected void EMEMGDKPEGN(float IPKCANKECAH)
		{
		}

		private void GNMHFMDLCLJ(int HFKAEACJODH)
		{
		}

		protected void BAOEIMDLADL(JLHLKDMLBPK FMHCCJDJFBA)
		{
		}

		private void BAOEIMDLADL(Color FMHCCJDJFBA)
		{
		}
	}
}
