using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class TrailComponent : MonoBehaviourPun, GFLPAFBGELM, NEKJJEGPHFG, DJLCHGFCFAD, PJINIJOHANN, GAAKCFPLMHN
	{
		[Serializable]
		public class TrailMaterial
		{
			public enum AMOFJHGMAHL
			{
				Hard = 0,
				Soft = 1,
				Sword = 2,
				Neon = 3,
				Laser = 4,
				Rainbow = 5,
				RainbowStriped = 6
			}

			public AMOFJHGMAHL TrailMaterialType;

			public Material Material;

			public string FriendlyName => null;
		}

		private sealed class CGLMANKILPL
		{
			public int desiredTrailMaterialType;

			internal bool _003CCurrentMaterial_Set_003Eb__0(TrailMaterial trailMaterial)
			{
				return false;
			}
		}

		private const string ANGEAOLECFD = "Motion Trail";

		private const float HCHEGHCPNKH = 0.25f;

		private const float FOBEFBGEFJH = 0.1f;

		private const float PINFKLBCMLK = 1f;

		private const float BDIGDNDDBNB = 1f;

		private const int PMNCOGHDDJE = 0;

		private const float EKFMANNPJMD = 0.5f;

		[SerializeField]
		private TrailMaterial[] trailMaterials;

		[SerializeField]
		private MeshRenderer[] trailVisuals;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private SandboxColorable sandboxColorable;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private DynamicMeshTrail dynamicMeshTrail;

		[SerializeField]
		protected SyncedComponentV2 syncComponent;

		private float BMLCHMCPOHF;

		private float DHPHKLIFBJH;

		private float ILGGKCBPAOG;

		private readonly Dictionary<string, MIBJNNKFLND> IPMOONFODKJ;

		private global::CDLJMENCODC<bool> HJJDCABOLNC;

		private global::CDLJMENCODC<float> LGLCMKOMCOJ;

		private global::CDLJMENCODC<float> HDPLPKEGKGL;

		private global::MOBDJNEDDKC<int> FHGODPEDFAK;

		private global::MOBDJNEDDKC<float> HHGIOABNHPL;

		private global::MOBDJNEDDKC<float> IJPEKGJNHPN;

public int Color
{
get 		{
			return 0;
		}

}

public bool TrailEnabled
{
get 		{
			return false;
		}

set {
		}
}

public float Lifetime
{
get 		{
			return 0f;
		}

set {
		}
}

public float MaxOpacity
{
get 		{
			return 0f;
		}

set {
		}
}

public int MaterialIndex
{
get 		{
			return 0;
		}

set {
		}
}

public float FadeInDuration
{
get 		{
			return 0f;
		}

set {
		}
}

public float FadeOutDuration
{
get 		{
			return 0f;
		}

set {
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

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void NLOKKKOMABN()
		{
		}

		private void NKILLLEJEFC()
		{
		}

		private void DMEGKHNNAIL()
		{
		}

		private void EAGCBEFAKFN()
		{
		}

		private void MLIHPNGNFMK()
		{
		}

		private void IJFPCPAODND()
		{
		}

		private int LMNLINDNHEM()
		{
			return 0;
		}

		private void GLKIAOJDAAK(int HFIPJMPAFHJ)
		{
		}

		private void AHKCEKGOJCD()
		{
		}

		private void GFOCMFGOFNC(bool BLOCPPAOJDM)
		{
		}

		void PJINIJOHANN.SetSynchronizing(bool BLOCPPAOJDM)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GFOCMFGOFNC
			this.GFOCMFGOFNC(BLOCPPAOJDM);
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

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetEnabled(JEGAPHLGBJA GCBHEJANCJK, bool BFDBCMGIOBG)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetColor(JEGAPHLGBJA GCBHEJANCJK, JLHLKDMLBPK HMCAFGCGFJF)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetLifetime(JEGAPHLGBJA GCBHEJANCJK, float OOBOIODABDP)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetMaxOpacity(JEGAPHLGBJA GCBHEJANCJK, float GLIDGCCGCPM)
		{
			return default;
		}

		public global::FAIKNKAIPLB<OHAJOLBEFND> Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		[CompilerGenerated]
		private Material POFKPKGPHFP(TrailMaterial PBCLPLCEMFH)
		{
			return null;
		}

		[CompilerGenerated]
		private bool FGPLKCCAELK()
		{
			return false;
		}

		[CompilerGenerated]
		private void ACPKIIBNGNL(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool BCEPEGEJGAG()
		{
			return false;
		}

		[CompilerGenerated]
		private float OJJLOLPDFIL()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void EHLABEANBIG(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private float EGLMOBJJJKK()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void KHAFLCGCKLF(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private float OCNECMJHBDN()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void EDIOIOMODJO(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool BKHAKKLLOED()
		{
			return false;
		}

		[CompilerGenerated]
		private float DOIJBOBCCEK()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void NLACPHCHPLD(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool IOGPONINEAB()
		{
			return false;
		}
	}
}
