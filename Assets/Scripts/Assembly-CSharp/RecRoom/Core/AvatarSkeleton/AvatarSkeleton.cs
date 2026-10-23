using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Photon.Pun;
using RootMotion.FinalIK;
using Unity.Profiling;
using UnityEngine;

namespace RecRoom.Core.AvatarSkeleton
{
	public class AvatarSkeleton : MonoBehaviourPun, KFLNCOLKJEM
	{
		[Serializable]
		private struct SkeletonLODUpdateRate
		{
			public AMBBOEBJPNH lod;

			public float updateRate;
		}

		private class JAGBCHNMAAO : MBGEHDFNLFE
		{
			private Transform MFMCCGHIILB;

			private Vector3 CPANGHKGFHC;

			private float? KPPJIAGIPHN;

public Transform DHGHIDOLKGM
{
get 			{
				return null;
			}

set {
			}
}

public Vector3 PGMKCFAPIHE
{
get 			{
				return default;
			}

set {
			}
}

public float? JLKCMFHDIFJ
{
get 			{
				return null;
			}

set {
			}
}
		}

		public interface MBGEHDFNLFE
		{

 Transform DHGHIDOLKGM
{
get ;
}

 Vector3 PGMKCFAPIHE
{
get ;
}
		}

		private struct EGHDGIKEIHM
		{
			public float OOMDNMMLOMP;

			public RigidbodyEx NHFGDOEKCJH;

			public RigidbodyEx LAFAOOJHJAC;

			public RigidbodyEx PFMKGJMHJHL;

			public RigidbodyEx GOLIGPJEEAJ;

			public Vector3 MHLFKOCKJBM;

			public Vector3 EEHBCAIBLNK;

			public bool EBFBPAHKCPB;
		}

		private enum CGPFELMIMCD
		{
			Idle = 0,
			FollowingTarget = 1,
			LockedToTarget = 2
		}

		private enum GIMOKMIDCDM
		{
			Smooth = 0,
			BalancedBasedOnDeadzones = 1,
			ForceSnapIntoPlace = 2
		}

		private const int NOLIALCIJLC = 0;

		private const float BMEKLMAJCFM = 10f;

		private static readonly int POLNMDEKDMD;

		private static readonly int NLCIICAIMCH;

		private static readonly int HLADGMOGPLL;

		private static readonly int OPPEMGCBBFD;

		private static readonly int KGMJGLJDBMO;

		private static readonly int FAPNBNFJLKF;

		private static readonly int MMEFGEKDNHO;

		private static readonly int NMGHAMOKLAM;

		private static readonly int MCPKANHEHHI;

		private static readonly int IJMKFDKCANO;

		private static readonly int JGAJEBCAOLJ;

		private static readonly int FLKDHIKEPDB;

		private static readonly int JEGJECLDGLO;

		private static readonly int IFCLBKIFCDP;

		private static readonly int OCENNINPKDB;

		private static readonly int PPMMPJGOONM;

		private static readonly int JALGHFFPMDH;

		private static readonly int NEEPGNGMHOP;

		private static readonly int EBOHEIBMJNN;

		private static readonly int KFAKKFDDMFA;

		private static readonly int KFBCNKFDJEN;

		private static readonly int PGPNDKMOHDC;

		private static readonly int PIHAKALKOCC;

		[SerializeField]
		protected AvatarSkeletonContent content;

		[SerializeField]
		protected Player player;

		[SerializeField]
		protected Animator skeletonAnimator;

		[SerializeField]
		protected VRIK skeletonInverseKinematics;

		[SerializeField]
		private SkeletonLODUpdateRate[] lodUpdateRates;

		private readonly JAGBCHNMAAO LFIDMKOIALD;

		private readonly JAGBCHNMAAO DNKIELMIBKH;

		private readonly JAGBCHNMAAO LBPPMFIENAI;

		private readonly JAGBCHNMAAO GMCBIPNJHIO;

		private readonly JAGBCHNMAAO KDBIGFFBEDA;

		private readonly JAGBCHNMAAO EACHDIGAAMG;

		private readonly JAGBCHNMAAO EEKDEKNPMCL;

		private readonly JAGBCHNMAAO DFBDAHEBKHP;

		private readonly JAGBCHNMAAO GIMKDKDJJAI;

		private readonly JAGBCHNMAAO AOIFAGOFAJJ;

		private readonly JAGBCHNMAAO JAMLBIKEGBG;

		private readonly JAGBCHNMAAO KGKKEFHBCMD;

		private readonly JAGBCHNMAAO LNBBPMGLFOF;

		private readonly JAGBCHNMAAO EGGKBMNANOE;

		private readonly JAGBCHNMAAO DCBKEPGODFG;

		private readonly JAGBCHNMAAO PAEGPDBCFBF;

		private readonly JAGBCHNMAAO IIEJEGGFLEO;

		private ReadOnlyCollection<JAGBCHNMAAO> IHOPPJOBGEE;

		[SerializeField]
		protected Transform headAdditiveBaseBoneTransform;

		[SerializeField]
		protected GameObject bendyTorsoVisual;

		private Renderer[] HGNODDKHHCO;

		private MaterialPropertyBlock OEKIDPNMIMK;

		[SerializeField]
		protected GameObject skeletonExceptForTorsoDebugVisual;

		private (JAGBCHNMAAO, JAGBCHNMAAO)[] MDGADHKKJDI;

		private bool OEAONLGBBPN;

		private bool HFPPCABOFGJ;

		private static AvatarSkeletonContent LCDAMMAKHIF;

		private static readonly ProfilerMarker NOJDFKPDAMN;

		private static readonly ProfilerMarker HEJAGLFCGOI;

		private static readonly ProfilerMarker CJNNBFIBNEF;

		private ProfilerMarker IIFKDIBNLHC;

		private bool ADAAGKLNEOL;

		private bool FEMGBDGCFMO;

		private bool DFJGIFGCNIG;

		private bool IBLDIIJIGGP;

		private float KDDCHPOFDOG;

		private Action EAAKOHFELHB__BackingField;

		private bool BBIPFOFMHLG;

		private CGPFELMIMCD HCJDJEOALGB;

		private float DEKENIKFNOK;

		private readonly CNHEOBEGMKA EGEJEBIHGFB;

		private readonly CGOBNNIEKLB DHINMEOEKLI;

		private Vector3 DCHDNKGHEFE;

		private CGPFELMIMCD OIPCDILOEBP;

		private float LEDPCJHOOKD;

		private float MEBJBANMPLK;

		private readonly GONNOHBHNKF NHICAMNOOFO;

		private readonly CGOBNNIEKLB MGJHNLJOKLC;

		private readonly GONNOHBHNKF DBCLGGAKADL;

		private bool MPNEHBLPMHF;

		private readonly List<AnimatorClipInfo> LLNNFKMAFBF;

		private readonly StringBuilder KHHNFONOGDI;

		private static GameObject JGOLBJPEHHJ;

		private static Camera CHAIPBMDNOO;

		private static readonly Vector3 NBNEFBJLBFP;

		private static readonly Vector3 IBDDCJJCIJF;

		private static readonly Vector3 HEKBPFNKEAK;

		private static readonly Vector3 IKBKAHBICPE;

public MBGEHDFNLFE HeadBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE NeckBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE ShouldersBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE StomachBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE HipsBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE RightUpperArmBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE RightLowerArmBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE RightHandBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE LeftUpperArmBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE LeftLowerArmBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE LeftHandBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE RightUpperLegBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE RightLowerLegBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE RightFootBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE LeftUpperLegBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE LeftLowerLegBone
{
get 		{
			return null;
		}

}

public MBGEHDFNLFE LeftFootBone
{
get 		{
			return null;
		}

}

public IReadOnlyList<MBGEHDFNLFE> AllBones
{
get 		{
			return null;
		}

}

public bool IsInRigidTorsoMode
{
get 		{
			return false;
		}

set {
		}
}

private Renderer[] MPPONGFGPAE
{
get 		{
			return null;
		}

}

private MaterialPropertyBlock BMEPFHLEJJG
{
get 		{
			return null;
		}

}

public event Action UpdateCompleted {
add {
		}
remove {
		}
}

		public void HideAllBoneDebugVisuals()
		{
		}

		public void ShowAllBoneDebugVisuals()
		{
		}

		public void Initialize(bool HFPPCABOFGJ = false)
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		public void UpdateSkeleton()
		{
		}

		private bool BPGANGPGBPO()
		{
			return false;
		}

		private void DJCEDHBEACI()
		{
		}

		public static Vector3 GetHeadPivoPosition(Vector3 MIKOHGEJNML, Quaternion ICJGLEEEGKK)
		{
			return default;
		}

		private EGHDGIKEIHM OBBGPOBPHNK()
		{
			return default;
		}

		private void CEPHGMOEOJC(ref EGHDGIKEIHM DADHJJNJEFA)
		{
		}

		private void OLIEFAIEAKD()
		{
		}

		private void HKMCPADLNKF(Transform GLLFHCCFIGK, JAGBCHNMAAO GFCPAMJILIO)
		{
		}

		private void CGCLNMJINHB()
		{
		}

		private void BFNKDHHOJII(bool IPMIIEAGJKC)
		{
		}

		private void IEHKKOCNILD(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		void KFLNCOLKJEM.OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IEHKKOCNILD
			this.IEHKKOCNILD(EDIGAFOKGOJ, AKOKILEPANJ);
		}

		private void LMLBOBKEMJB(in EGHDGIKEIHM DADHJJNJEFA, GIMOKMIDCDM IDAFILFGKCL)
		{
		}

		private void EMKDANOKOGE(RigidbodyEx OOGJOGANIKJ, bool LDEEGDEKBLJ)
		{
		}

		private void JCJGALABNFJ(RigidbodyEx OOGJOGANIKJ)
		{
		}

		private void FKBOMLKGIKA(in EGHDGIKEIHM DADHJJNJEFA, GIMOKMIDCDM IDAFILFGKCL)
		{
		}

		private Vector3 BAAKOECLLDE(in EGHDGIKEIHM DADHJJNJEFA)
		{
			return default;
		}

		private void NHCIJHPFNKF(in EGHDGIKEIHM DADHJJNJEFA, GIMOKMIDCDM IDAFILFGKCL)
		{
		}

		private float DCOCDPKHJAI(in EGHDGIKEIHM DADHJJNJEFA)
		{
			return 0f;
		}

		private void FIKKFIBEDJN(EGHDGIKEIHM DADHJJNJEFA, GIMOKMIDCDM IDAFILFGKCL, Vector3 EKLGIEAOPDG)
		{
		}

		private void LBHEBIJPDPD(in EGHDGIKEIHM DADHJJNJEFA)
		{
		}

		private void OLPPHGGCGAP(Vector3 MDCGEFLCEBB, ref bool NEBKDDNCBPG, out float DMIPMFMPLAP, out float DHNIFGKEEJD)
		{
			DMIPMFMPLAP = default;
			DHNIFGKEEJD = default;
		}

		private float EGFGFOGLMEL(in EGHDGIKEIHM DADHJJNJEFA)
		{
			return 0f;
		}

		private float PINGHDPLLHO(Vector3 BIDFALNKAIH, Vector3 NCGGBABHKOG)
		{
			return 0f;
		}

		private void NNCJEODMKHM(in EGHDGIKEIHM DADHJJNJEFA)
		{
		}

		private void HNPEIFBCAFB(in EGHDGIKEIHM DADHJJNJEFA)
		{
		}

		private void BCMIGMEMOEO(in EGHDGIKEIHM DADHJJNJEFA)
		{
		}

		private void OGGPHACMLME(in EGHDGIKEIHM DADHJJNJEFA)
		{
		}

		private float IKNODNMPEDN(in (JAGBCHNMAAO, JAGBCHNMAAO) EIEOJIFKIBD)
		{
			return 0f;
		}

		private Vector3 FKJKLCHGNPK(in (JAGBCHNMAAO, JAGBCHNMAAO) EIEOJIFKIBD)
		{
			return default;
		}

		private void HJMMFFLHKLD(in EGHDGIKEIHM DADHJJNJEFA)
		{
		}

		private void OFGADILKKPO(JAGBCHNMAAO FMMAIBDCKDA, JAGBCHNMAAO IJEIOMOPNML, IKSolverVR.Arm GEMKEBABPIB, RigidbodyEx BCPGKJDMEFP, bool GBMKOCPKFPI)
		{
		}

		private float CKOOHPODJCN(bool GBMKOCPKFPI)
		{
			return 0f;
		}

		private float LNAJPFKBPMN(JAGBCHNMAAO FMMAIBDCKDA, JAGBCHNMAAO IJEIOMOPNML, IKSolverVR.Arm GEMKEBABPIB, RigidbodyEx BCPGKJDMEFP)
		{
			return 0f;
		}

		private void GJPCOILMNOE(in EGHDGIKEIHM DADHJJNJEFA)
		{
		}

		private void IHMAFDANIDJ(RigidbodyEx BCPGKJDMEFP, Transform AKBMILGOPCG, Transform OMCFDJDGHHO)
		{
		}

		public void SetBendyTorsoShirtColor(Color HMCAFGCGFJF)
		{
		}

		public void UpdateBendyTorsoColor()
		{
		}
	}
}
