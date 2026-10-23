using UnityEngine;

namespace RecRoom
{
	public abstract class PlayerController
	{
		protected static readonly string RESPAWN_TOKEN;

		public const int RESPAWN_PRIORITY = 1000000;

		private static CGOBNNIEKLB playerHeightSpring;

		private float _trackingSpaceRotationVelocity;

		public const float HEAD_RADIUS = 0.1f;

public float LGOKNKLNIGP
{
get 		{
			return this._trackingSpaceRotationVelocity;
		}

}

public abstract bool HasInputThisFrame
{
get ;
}

public virtual float DesiredPlayerScale
{
get 		{
			return 0f;
		}

}

		public abstract void IHEKMEOIBOI(LocalPlayerController HOIIBHDNAJI);

		public abstract void FCCAJFNJBLH();

		public abstract void LIDHELJBOFC();

		public abstract void HAFMJAPFCGD();

		public abstract void GIHKGIMINNE();

		public abstract void AKFBGKGEGGF();

		public virtual void ALBLCLBPGMJ()
		{
		}

		public abstract void HADBNNANGFK();

		public abstract void NMJKIJBBDKO(Player MHCOBIPKGNI);

		public abstract void JMHMIEACMHH(LoginScreenSpawnPoint FPDAFHFAEIC);

		public abstract Player JPAGHPDCEFL(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH);

		public void KBONBBABNGO(float BEONMACFCNH, object IALNODEHBNN)
		{
		}

		public void IHLLNIBIAEO(object IALNODEHBNN)
		{
		}

		public Vector3 PDGMEBDCGFG(Player EKOFNPFCLMO)
		{
			return default;
		}

		public Vector3 IMAOLFMMGIJ(Player EKOFNPFCLMO)
		{
			return default;
		}

		public Vector3 BNAAHOMBGFM(Player EKOFNPFCLMO)
		{
			return default;
		}

		public Vector3 HNGGOBKHMAP(Player EKOFNPFCLMO)
		{
			return default;
		}

		public Transform PBPNAODBFFJ(Player EKOFNPFCLMO)
		{
			return null;
		}

		public void CLOMHOKFIPM(Player EKOFNPFCLMO, Vector3 HKNBIJNOJII, float LPBAONEEHOD, Vector3 OMMJFMECNJJ, bool JDJNIBJJNJC = false)
		{
		}

		public void EPDDHDEDPEO(Player EKOFNPFCLMO, Vector3 LNMOOCBAAIM, float BJOFABFHINJ = 0f)
		{
		}

		public void LECEELLGGNA(Player EKOFNPFCLMO, Vector3 LNMOOCBAAIM, float AOOONHBIJMA, Vector3 KIHNNKGPHHD, Vector3 FLAMDDLFAMD, float OKBAJEAPIHG, float BJOFABFHINJ = 0f)
		{
		}

		private Quaternion IBLOGJHFBLC(Player EKOFNPFCLMO, Vector3 LNMOOCBAAIM, float BJOFABFHINJ)
		{
			return default;
		}

		public virtual void KBHEHEFFOKF(GNEENOANCIM.ABLDJLKKHJP NHJPBHJLFOD)
		{
		}

		public virtual void KPFCKHNHGPC(GNEENOANCIM.ABLDJLKKHJP NHJPBHJLFOD)
		{
		}

		protected bool JECEJNHKMNH(Player EKOFNPFCLMO)
		{
			return false;
		}

		protected bool FELOKDAKOKA(Player EKOFNPFCLMO)
		{
			return false;
		}

		private void GALJPKPIPBG(Tool IEGMBEPJMGC, BKMDFCCNPGE CKEPLIBLBFJ, bool EPDJDCDHLMP, bool OENLCMEDCNI)
		{
		}

		protected float IHIELKCMLKH(out float OGFNHDIAGIO)
		{
			OGFNHDIAGIO = default;
			return 0f;
		}

		protected void AHCJPBDBJKK(float BJOFABFHINJ)
		{
		}

		protected void NGJDKOKKEDE()
		{
		}

		public bool LNKHENNFCLK(out float FHAJJMKOOJJ)
		{
			FHAJJMKOOJJ = default;
			return false;
		}

		public virtual void PPGOLHLBGGH()
		{
		}
	}
}
