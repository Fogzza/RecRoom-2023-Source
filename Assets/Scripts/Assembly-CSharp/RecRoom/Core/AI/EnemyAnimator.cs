using UnityEngine;

namespace RecRoom.Core.AI
{
	public class EnemyAnimator : MonoBehaviour
	{
		public enum LCLCDMFPHFO
		{
			CullCompletely = 0,
			CullUpdateTransforms = 10,
			AnimateIfAuthority = 20,
			AlwaysAnimate = 30
		}

		public enum MMEKGNLFGMP
		{
			NONE = 0,
			CHARGE = 1,
			ATTACK = 2,
			POST_ATTACK = 3,
			ATTACK_INTERRUPTED = 4
		}

		public enum DIDEDPPMNJC
		{
			NONE = 0,
			CHARGE = 1,
			ATTACK = 2,
			POST_ATTACK = 3
		}

		public enum AMDCKJOLFIJ
		{
			NONE = 0,
			PREPARE = 1,
			JUMP = 2
		}

		[SerializeField]
		private bool patrolHasTransition;

		[SerializeField]
		private bool isAlwaysMoving;

		[SerializeField]
		private int meleeAttackVariantCount;

		[SerializeField]
		private int blockVariantCount;

		[SerializeField]
		private LCLCDMFPHFO cullingMode;

		private static readonly int OJAKICNFGGG;

		private static readonly int DBDNGFIMEOI;

		private static readonly int OLOHKKNALAP;

		private static readonly int HDBHPMBNJLE;

		private static readonly int IAIAMJIJPLC;

		private static readonly int AMLBAILLALB;

		private static readonly int OLHPPNEEIHB;

		private static readonly int MCLPGBDEDHE;

		private static readonly int IIHCFDACAGE;

		private static readonly int NLIEHJEMDKI;

		private static readonly int PIMJIEPEMKM;

		private static readonly int CKIMPGJILPL;

		private static readonly int JKCAOPFBBEC;

		private static readonly int FCONEPGCCAD;

		private static readonly int LKJKNIGDCFN;

		private static readonly int MDGHJKANMOA;

		private static readonly int JHOBKAEBGCD;

		private static readonly int EPNOJGMINMF;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Enemy enemy;

		private bool EMHPJOBEJBC;

		private float GOIDFGFOOBM;

		private int IHDKGAPBJKI;

		private int LEGEOMHIEPK;

public bool IsInPatrol
{
set {
		}
}

public bool InCombat
{
set {
		}
}

public bool IsMoving
{
set {
		}
}

public bool IsDisengaged
{
set {
		}
}

public MMEKGNLFGMP MeleeCombat
{
set {
		}
}

public DIDEDPPMNJC RangedCombat
{
set {
		}
}

public AMDCKJOLFIJ Jump
{
set {
		}
}

public bool IsBlocking
{
set {
		}
}

public bool IsSprinting
{
set {
		}
}

		public void StartStun(bool LAEHAIMILII)
		{
		}

		public void StopStun()
		{
		}

		public void PlayRangedAttack()
		{
		}

		public void PlayMeleeAttack()
		{
		}

		public void PlayDeath()
		{
		}

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private int GFAMANBAIIL()
		{
			return 0;
		}

		private int DPDDJAOBACB()
		{
			return 0;
		}

		public int GetRandomMeleeAttackVariantIndex()
		{
			return 0;
		}

		public void SetMeleeAttackVariantIndex(int GMEHLIHLGEH)
		{
		}

		private void ENNAFLMMIKF()
		{
		}

		private void EKLBLDHILPE()
		{
		}

		private void HNDDLIBKJOI(CHILKDJABBF HIGOLKPFBPL)
		{
		}
	}
}
