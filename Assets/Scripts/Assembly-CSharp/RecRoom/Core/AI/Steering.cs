using System;
using System.Collections.Generic;
using Pathfinding;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.AI
{
	public class Steering : MonoBehaviourPun
	{
		[SerializeField]
		private float maxLinearSpeed;

		[SerializeField]
		private float horizontalAcceleration;

		[SerializeField]
		private float verticalAcceleration;

		[SerializeField]
		private float maxAngularSpeedDegrees;

		[SerializeField]
		private bool faceMovementDirection;

		[SerializeField]
		private float reachedPathNodeDistance;

		[SerializeField]
		private CapsuleCollider terrainNavigationCapsuleCollider;

		[SerializeField]
		private Seeker seeker;

		[SerializeField]
		private float stepHeight;

		[SerializeField]
		private float surfaceTestDistance;

		[SerializeField]
		private bool supportsGravity;

		[SerializeField]
		private float desiredHoverHeight;

		[SerializeField]
		private float minAllowableDistanceToCeiling;

		private float FHIFHHKAAKH;

		private float OIEGLOCLNBC;

		private float OEEIMPOGLNH;

		private float NHLMNOBLOMN;

		private float PADKBNIPPFN;

		private float GGHPBCDLLFD;

		private float CHKFLGIPLML;

		private float KAGHGHDOGFK;

		private bool JFJPOOKAOKC;

		private bool PNBIJDLCJMC;

		private Vector3 IMPJMICNPGN;

		private Vector3 IGBDLIBKPLM;

		private Vector3 HJJGEBDGLDI;

		private bool BDBOHELKANG;

		private float KCDNDFCCKIK;

		private bool JPGJNDGLFNE;

		private bool FALMGPDJGJP;

		private bool CHJMGNPKHHI;

		private List<Collider> HIEFJJCFOAE;

		private global::MOBDJNEDDKC<bool> PIJKEDNLMFL;

		private bool KBOBEPBOJON;

		private bool ENEBOHCEPMC;

		private bool JCDAOHPMLHD;

		private bool MAKPIFOGFLE;

		private bool NFHCNHMLNJG;

		private Vector3 IOLACOMEGOF;

		private Vector3 MONGLGEGFCO;

		private float DCLEIJEKMJN;

		private bool BBDJEKOAIDF;

		private float LIMGEDKLFCL;

		[NonSerialized]
		private readonly global::MKJNCDLHHNA<float> KIPGADMMODN;

		private float KBGMAFDOKIP;

		private float KGCNLGLGBNL;

		private Vector3 FNJGDKLMDOO;

		private bool HMCCLOFGDAJ;

		private Vector3 JGBGCGEJKPP;

		private RigidbodyEx IDCFALFGPFP;

		private bool MPOMMEGGKBJ;

		private float DMPDDPBMPGO;

		private bool NKBKAOBIBDL;

		private float MCLFMNPCPKJ;

		private float HFHGKMJKFPK;

		private float EGFADDPMOMP;

		private Vector3 AAFHAGKIBIH;

		private float BFFGNBANAFC;

		private float BAIMBCNEEMF;

		private bool CHCJBHKHEMP;

		private bool BLIAPOLAGPF;

		private Quaternion ECFAMEOGEAB;

		private float EDNKNPAJDMF;

		private float IMFOFCAENFF;

		private Vector3 IPCMFEDMIAE;

		private float BCJDKDBIEFM;

		private float LBCAEKCIOFH;

		private bool JDPAGOENMEB;

		private bool PEAEKMFOJDA;

		private Path AKCKFKKKFJH;

		private int LGOEBIDLCEO;

		private int MOBNADBJAOB;

		private Vector3 KNIODBKEMCD;

		private NDNDHMIKFJI ODKCGNGAGIM;

		private OEEBBDJIDDP GJFIFJFDEGM;

		private ABMGHAHEMPI LONPIAIHGPI;

		private LAOELDLIJOM KKBAJAIIFIG;

		private const float OGDFLEKKAFB = 0.05f;

		private const float GHNDKLKKKNM = 1E-05f;

		private const float OABJEBHJNIH = 50f;

		private const float BHIGFEHCEIA = 10f;

		private const float FADLBMPDOPC = 0.1f;

		private const float FOACMEELKOB = 0.1f;

		private const float DLEPCIOFGPO = 0.05f;

		private const float BJDIGIIHDJJ = 0.001f;

		private const float HEPJGNKAAME = 5f;

		private const float BCIKBOBMHLP = 0.2f;

		private const float KOOBMBMFLEN = 2.5f;

		private const float CILCOOLAKDI = 45f;

		private const float HNLBCFJHLCM = 0.01f;

		private const float EGHOMKFNIIO = 1f;

public float MaxHorizontalSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public float MaxVerticalSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public float SteppingSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public float MovementSpeedVarietyScalar
{
get 		{
			return 0f;
		}

set {
		}
}

public float HorizontalAcceleration
{
get 		{
			return 0f;
		}

set {
		}
}

public float VerticalAcceleration
{
get 		{
			return 0f;
		}

set {
		}
}

public float AngularSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public Vector3 Velocity
{
get 		{
			return default;
		}

}

public bool GravityEnabled
{
get 		{
			return false;
		}

set {
		}
}

private bool NFPCLOGDCAI
{
get 		{
			return false;
		}

}

private bool EMCFFOBIPFJ
{
get 		{
			return false;
		}

}

public bool IsStuck
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsOnSurface
{
get 		{
			return false;
		}

private set {
		}
}

public Vector3 SurfaceNormal
{
get 		{
			return default;
		}

private set {
		}
}

public Vector3 SurfacePosition
{
get 		{
			return default;
		}

private set {
		}
}

public Vector3 HoverPosition
{
get 		{
			return default;
		}

private set {
		}
}

public bool HoverEnabled
{
get 		{
			return false;
		}

set {
		}
}

public float DesiredHoverHeight
{
get 		{
			return 0f;
		}

}

public float CurrentHoverHeight
{
get 		{
			return 0f;
		}

private set {
		}
}

public bool IsHovering
{
get 		{
			return false;
		}

}

public bool CanNavigateTerrain
{
get 		{
			return false;
		}

}

public ABMGHAHEMPI CollisionConfig
{
get 		{
			return default;
		}

}

public bool ReachedMainSeekTarget
{
get 		{
			return false;
		}

private set {
		}
}

public bool ReachedHeightSeekTarget
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsSeeking
{
get 		{
			return false;
		}

private set {
		}
}

public List<Collider> IgnoredObstacleAvoidanceColliders
{
get 		{
			return null;
		}

set {
		}
}

public float ReachedPathNodeDistance
{
get 		{
			return 0f;
		}

}

public bool UseObstacleAvoidance
{
get 		{
			return false;
		}

set {
		}
}

public bool ReachedLookTarget
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsLooking
{
get 		{
			return false;
		}

private set {
		}
}

public bool CanPath
{
get 		{
			return false;
		}

}

public bool ReachedPathDestination
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsPathing
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsCalculatingPath
{
get 		{
			return false;
		}

}

private bool LJBLHDALOOL
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void StopAll()
		{
		}

		public void Pause()
		{
		}

		public void Resume()
		{
		}

		public void Seek(Vector3 GFCPAMJILIO, float FNANPHJGABF)
		{
		}

		public void Seek(Vector3 GFCPAMJILIO, float FNANPHJGABF, float IJHMMCIMLHM)
		{
		}

		public void Seek(Vector3 GFCPAMJILIO, float FNANPHJGABF, float IJHMMCIMLHM, bool HPAOHBOACMA)
		{
		}

		public void Seek(Vector3 GFCPAMJILIO, float FNANPHJGABF, float IJHMMCIMLHM, bool HPAOHBOACMA, bool DOKNGMLBBEE)
		{
		}

		public void StopSeeking()
		{
		}

		public void Look(Vector3 FDDAFFGMMLB)
		{
		}

		public void Look(Quaternion OOFIIEKBKAE)
		{
		}

		public void Look(Vector3 FDDAFFGMMLB, float GKHEAHKMGEI)
		{
		}

		public void Look(Quaternion OOFIIEKBKAE, float GKHEAHKMGEI)
		{
		}

		public void Look(Vector3 FDDAFFGMMLB, float GKHEAHKMGEI, float IJHMMCIMLHM)
		{
		}

		public void Look(Quaternion OOFIIEKBKAE, float GKHEAHKMGEI, float IJHMMCIMLHM)
		{
		}

		public void StopLooking()
		{
		}

		public void Path(Vector3 FMECHJDDNAF)
		{
		}

		public void Path(Vector3 FMECHJDDNAF, bool KNPEAKJPEDL)
		{
		}

		public void Path(Vector3 FMECHJDDNAF, float FNANPHJGABF)
		{
		}

		public void Path(Vector3 FMECHJDDNAF, float FNANPHJGABF, float IJHMMCIMLHM)
		{
		}

		public void Path(Vector3 FMECHJDDNAF, float FNANPHJGABF, float IJHMMCIMLHM, bool HPAOHBOACMA, bool KNPEAKJPEDL = false)
		{
		}

		private void GOLJDDBFNIL(Path KDENKOIEIEI)
		{
		}

		private bool NHCAIBPHCMD(Vector3 IGIEJKIHEOB, float HNJEACJDBHP = 1f)
		{
			return false;
		}

		public bool PathIsValidOrCalculating(Vector3 IGIEJKIHEOB, float HNJEACJDBHP = 1f)
		{
			return false;
		}

		public bool PathIsValidOrCalculating()
		{
			return false;
		}

		public void StopPathing()
		{
		}

		private void FixedUpdate()
		{
		}

		private void CPFELIFJDGP()
		{
		}

		private void FONGCCJAKAL()
		{
		}

		private void MBCGIKEJHIA()
		{
		}

		private void ADHOBPEFGGO()
		{
		}

		private bool BMIBKOCFEOO(Vector3 HLFIBIDOLEF, out Vector3 JGBGCGEJKPP)
		{
			JGBGCGEJKPP = default;
			return false;
		}

		private bool FCCBKGHCLKL()
		{
			return false;
		}

		public LAOELDLIJOM GetCurrentLocomotionCapsule()
		{
			return default;
		}

		private ABMGHAHEMPI JIJDOHNGAJK()
		{
			return default;
		}

		private void KIIAMKOJLID()
		{
		}

		private void OFEPEAHDIOB()
		{
		}

		private Vector3 KCIHPNGMHKA()
		{
			return default;
		}

		private Vector3 HDBHJCJDAJD()
		{
			return default;
		}

		private Vector3 DNLHONDJLMC(Vector3 ICDPEOKPIEH)
		{
			return default;
		}

		public void SetDesiredHoverHeight(object IALNODEHBNN, float BNJGFFHNOGA)
		{
		}

		public void UnsetDesiredHoverHeight(object IALNODEHBNN)
		{
		}

		private void OBEGBHCMCDG()
		{
		}

		private void CJNHMPAOMGI()
		{
		}

		private float PNNMDJGCAFG(Vector3 LLOLHOKFBIC, Vector3 HFECNDFJCOL)
		{
			return 0f;
		}

		private void DEDAPJLIPHD()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
