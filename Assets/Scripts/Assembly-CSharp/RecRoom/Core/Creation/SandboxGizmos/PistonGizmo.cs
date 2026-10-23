using System.Runtime.CompilerServices;
using System.Text;
using RecRoom.CircuitsV2.GraphNodes;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class PistonGizmo : AcceleratedMovementGizmo, GFLPAFBGELM, NEKJJEGPHFG
	{
		private enum EHAELKJHAEB
		{
			LessThanPiston = 0,
			GreaterThanPiston = 1
		}

		private static readonly HDHIMOFHFJL AHADDDAMGKE;

		[SerializeField]
		private float maxMovementSpeed;

		[SerializeField]
		private float minTargetDistance;

		[SerializeField]
		private float maxTargetDistance;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		private const float JPKKELCOBEM = 1E-05f;

		private const float GAPGMCEAIEN = 0.01f;

		public const IALAJKBOKBN DEFAULT_COLLISION_LAYER = IALAJKBOKBN.DynamicPhysicsIgnoreDynamicPhysics;

		[SerializeField]
		private LineRenderer pathLineRenderer;

		private float AJBGNJJPMIF;

		private Vector3 BDENALNIAKH;

		private float JNJHPFJPBAC;

		private Vector3 BNMAGILNLGJ;

		private float EBLOBPJOBGM;

		private float CJOPJDHMJGC;

		private bool IJHMMCIMLHM;

		private global::CDLJMENCODC<float> BDKFNLJMENO;

		private float KCHNBPBJCKL;

		private global::CDLJMENCODC<float> OLBNFPLJLLC;

		private global::JCAAOOPEEAM<float, int> BEMFHGJNNHA;

		private global::JCAAOOPEEAM<float, int> DJHKCCPIKBC;

		private global::JCAAOOPEEAM<float, int> OLKANBLOBLI;

		private EHAELKJHAEB AEHALCLGFOH;

		private Vector3 NFIGBEGFOGB;

protected override string BLDIMIHMMGD
{
get 		{
			return null;
		}

}

public float MaxTravelDistance
{
get 		{
			return 0f;
		}

set {
		}
}

public float TargetDistance
{
get 		{
			return 0f;
		}

set {
		}
}

public override bool IsCircuitsV2
{
get 		{
			return false;
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

		private float EHOHBAOLFBL(float IPMIIEAGJKC)
		{
			return 0f;
		}

		private float JOEPBOIHEPL(float IPMIIEAGJKC)
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void Update()
		{
		}

		protected override AKCHPHOMHLH MNECEOLGCKC()
		{
			return null;
		}

		protected override void DPHIKDNCLDK()
		{
		}

		protected override void LDHMIPDLMND()
		{
		}

		protected override void OPBHAMDIMBE(Vector3 CPLLMPKBHAM, Quaternion IKEPGNGNPGC)
		{
		}

		private void DCHHBOBBCGA(in Vector3 MGNBGIDOJLH)
		{
		}

		protected override void IHLNPHDKJOO()
		{
		}

		private void KCCMIIDMNLB()
		{
		}

		private void OIJEJIIJINK()
		{
		}

		private void PDPENJAAAOA()
		{
		}

		private void JCDMPCEPKJH(float DMIPMFMPLAP)
		{
		}

		protected override void EADGFKAGGBD()
		{
		}

		private void GGGKNMCCACD()
		{
		}

		private float CCBLMGBEGBO()
		{
			return 0f;
		}

		private void HHMACKMAIIA(float DLEMNBPMGBG)
		{
		}

		public override void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public override void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		private void JGLLMCALGON()
		{
		}

		private Vector3 JJHIGDPOOLA(float DAMOGGANOJL)
		{
			return default;
		}

		public float GetDistance()
		{
			return 0f;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetDistance(JEGAPHLGBJA GCBHEJANCJK, float DAMOGGANOJL)
		{
			return default;
		}

		private void KNBLDCHELAK(float DAMOGGANOJL)
		{
		}

		private void BHNJGGPKEAN()
		{
		}

		public float GetSpeed()
		{
			return 0f;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetSpeed(JEGAPHLGBJA GCBHEJANCJK, float DMIPMFMPLAP)
		{
			return default;
		}

		private void HAGBGOMPBIE(float DMIPMFMPLAP)
		{
		}

		private void HAGEMKDKINA()
		{
		}

		public float GetAcceleration()
		{
			return 0f;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetAcceleration(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		private void DFFNLDCOFCH()
		{
		}

		private void FCEJHLPHPCA(float IPMIIEAGJKC)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetMaxDistance(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetTargetDistance(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		private void FMBJBIJPLLO()
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
		private void MDDPANBGBLJ()
		{
		}

		[CompilerGenerated]
		private float EECMHMJFPJL()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void LGGDKOFHOKK(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool LEHHCFJMHEJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void OFMDENLDFAM(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool HGILBDJBNPA()
		{
			return false;
		}

		[CompilerGenerated]
		private bool CBKMJHFFPFH()
		{
			return false;
		}

		[CompilerGenerated]
		private void HDLFHPCADFK(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool BOJKANAECGG()
		{
			return false;
		}

		[CompilerGenerated]
		private bool BEJFDIFHCGJ()
		{
			return false;
		}
	}
}
