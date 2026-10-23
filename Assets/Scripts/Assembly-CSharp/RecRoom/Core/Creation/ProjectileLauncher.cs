using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ProjectileLauncher : RangedWeapon, GFLPAFBGELM, NEKJJEGPHFG, DJLCHGFCFAD
	{
		public const string PrimaryLabel = "Projectile";

		private const int OANIMNGIDEG = 2;

		private const int JCBNHNKLOKD = 13;

		private const int FMBBOJKAPJD = 1;

		private const int HFDADLGEDHK = 1;

		private const int NNAABKANIOK = 16;

		private const float KAKOFCCNOHI = 1f;

		private const float HMKKDIOFBCM = 75f;

		private const float HMIDHJFCEPF = 1000f;

		private const float GICOPEHBDIM = 0.1f;

		private const float PINFKLBCMLK = 4f;

		private const float ALFDJDJANFG = 5f;

		private const float DPOMMMPAHIF = 0f;

		private const float ABGHBEHMKEN = 0f;

		private const float MLLJGOANADA = 90f;

		private const float KHDOBFNIBCP = 0f;

		private const float IICJONPPJHC = 1.5f;

		private const float MAOFHONBNLO = 100f;

		private const bool PBGHEIKMADP = false;

		private const int LFMNNBIJNJM = 10;

		private AAFBBJFIGFP POOJIPDLGMD;

		[SerializeField]
		private SandboxBullet[] projectiles;

		private Dictionary<string, MIBJNNKFLND> PEMHNLNFMDE;

		private global::CDLJMENCODC<CHILKDJABBF> GHGCNKAGHGN;

		private global::CDLJMENCODC<int> LJKJPFDHNGC;

		private global::CDLJMENCODC<int> PBECCHCNKKI;

		private global::CDLJMENCODC<int> FEOMLHCCPEE;

		private global::CDLJMENCODC<float> FPAHBGDKGNC;

		private global::CDLJMENCODC<float> DGNEIMNHEPO;

		private global::CDLJMENCODC<float> AHHMFGIFNDF;

		private global::CDLJMENCODC<bool> FEEILMILPAD;

		private global::MOMJAPFGODO<int, int, int> LOLBDDFOJJN;

		private global::CDLJMENCODC<float> DBDMFANJMGB;

		private global::CDLJMENCODC<bool> GAEENMGMBIN;

public CHILKDJABBF FiringPlayer
{
get 		{
			return null;
		}

set {
		}
}

public int CurrentProjectileIndex
{
get 		{
			return 0;
		}

set {
		}
}

public int CurrentProjectileColor
{
get 		{
			return 0;
		}

set {
		}
}

protected override Color EGOOKBNKAEM
{
get 		{
			return default;
		}

}

public int CurrentProjectileCount
{
get 		{
			return 0;
		}

set {
		}
}

public float CurrentProjectileSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public float CurrentProjectileLifetime
{
get 		{
			return 0f;
		}

set {
		}
}

public float CurrentProjectileAngleDegrees
{
get 		{
			return 0f;
		}

set {
		}
}

public float CurrentProjectileAngleRadians
{
get 		{
			return 0f;
		}

}

public bool CurrentProjectileGravityEnabled
{
get 		{
			return false;
		}

set {
		}
}

public (int, int, int) CurrentProjectileDamage
{
get 		{
			return default;
		}

set {
		}
}

public int CurrentProjectileHeadDamage
{
get 		{
			return 0;
		}

}

public int CurrentProjectileTorsoDamage
{
get 		{
			return 0;
		}

}

public int CurrentProjectileHandDamage
{
get 		{
			return 0;
		}

}

public float CurrentProjectileForce
{
get 		{
			return 0f;
		}

set {
		}
}

public bool SFXToggle
{
get 		{
			return false;
		}

set {
		}
}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
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

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void Start()
		{
		}

		protected void FGDGBBOKDPG(Vector3 INLGLHIPOMC, Vector3 HLFIBIDOLEF, int NNIAPMPEPJI)
		{
		}

		private void DHCOOEAEKOL()
		{
		}

		private void DLOLECIENGD()
		{
		}

		private void MCCLGIABAEK()
		{
		}

		protected override void MGKPHCBKLEN(Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void FJDHLLOOIKA(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void AMCJOFBMFOG(NGLCDIDOEMK BNFNJFKJEOA, bool OKANEJFAGIJ = true)
		{
		}

		protected override void MHNKPOFIPLK(NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		public global::FAIKNKAIPLB<OHAJOLBEFND> Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2TryFire(JEGAPHLGBJA GCBHEJANCJK, Vector3 HLFIBIDOLEF)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetFiringPlayer(JEGAPHLGBJA GCBHEJANCJK, Player EKOFNPFCLMO)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetProjectileSpeed(JEGAPHLGBJA GCBHEJANCJK, float DMIPMFMPLAP)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetProjectileLifetime(JEGAPHLGBJA GCBHEJANCJK, float OOBOIODABDP)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetProjectileSpread(JEGAPHLGBJA GCBHEJANCJK, float NMHGNOIAPGF)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetHeadDamage(JEGAPHLGBJA GCBHEJANCJK, int FHOPIFJDLJM)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetTorsoDamage(JEGAPHLGBJA GCBHEJANCJK, int JKKLNJIAHLB)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetHandDamage(JEGAPHLGBJA GCBHEJANCJK, int PAGJACJDAHN)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetProjectileColor(JEGAPHLGBJA GCBHEJANCJK, int HMCAFGCGFJF)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetProjectileCount(JEGAPHLGBJA GCBHEJANCJK, int BFFJHKFEFPP)
		{
			return default;
		}

		[PBOMGCLBFHF]
		protected void RpcAuthorityCV2TryFireShot(Vector3 INLGLHIPOMC, Vector3 HLFIBIDOLEF, byte NNIAPMPEPJI)
		{
		}

		private void OnPhotonPlayerConnected(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		public virtual void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public virtual void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private int FFPOGGGCOEK()
		{
			return 0;
		}

		[CompilerGenerated]
		private void EMGPHLNDONA(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int LJKNAHKHBLI()
		{
			return 0;
		}

		[CompilerGenerated]
		private void CIJBFKMELAK(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool IJPMKENFNKF()
		{
			return false;
		}

		[CompilerGenerated]
		private int OEIPJMFCFCC()
		{
			return 0;
		}

		[CompilerGenerated]
		private void EPBOJKFMFAB(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool BONNJPFNFBD()
		{
			return false;
		}

		[CompilerGenerated]
		private float KNCMNDFEBNP()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void OGMCIBBOEHE(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool HHNGFEDBDKF()
		{
			return false;
		}

		[CompilerGenerated]
		private float NFNMIGHEKEP()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void BAHDAGPJFEJ(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool JJLNJGMEAPA()
		{
			return false;
		}

		[CompilerGenerated]
		private float BCAKJHDICPB()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void HPGGJDFGHGC(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool PBPKDFDDHFD()
		{
			return false;
		}

		[CompilerGenerated]
		private bool DOBOINHPHEJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void PGFBLGBENOO(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool GCAAHHHILAK()
		{
			return false;
		}

		[CompilerGenerated]
		private int IHMLBCGFCID()
		{
			return 0;
		}

		[CompilerGenerated]
		private void NDEOLIMNALK(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int CHKMLAINHPC()
		{
			return 0;
		}

		[CompilerGenerated]
		private void NBDOELEKCMA(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int ODHFCDBHGMH()
		{
			return 0;
		}

		[CompilerGenerated]
		private void DJBMADIPKFO(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float KAIJDKHLBLI()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void NBDPDOEKKFD(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool HLGNOOCOIOK()
		{
			return false;
		}

		[CompilerGenerated]
		private bool CKKPCEJJLFJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void MNCMLLEENEK(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool AIPFBKGJPFL()
		{
			return false;
		}
	}
}
