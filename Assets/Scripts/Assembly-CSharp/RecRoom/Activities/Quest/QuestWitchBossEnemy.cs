using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestWitchBossEnemy : Enemy
	{
		private enum MBEOKFINMHF
		{
			RELOCATE = 0,
			POST_RELOCATE_DELAY = 1,
			CHARGE_ATTACK = 2,
			WAITING_FOR_PLAYER_REFLECT = 3,
			PLAYER_REFLECTED = 4,
			REFLECT_PROJECTILE = 5,
			TAKE_DAMAGE = 6,
			INVALID = 65535
		}

		[SerializeField]
		private float postPatrolDelay;

		[SerializeField]
		private float dashSpeed;

		[SerializeField]
		private float maxDashAcceleration;

		[SerializeField]
		private float dashSlowdownDistance;

		[SerializeField]
		private float dashTimeout;

		[SerializeField]
		private float attackChargeDuration;

		[SerializeField]
		private float projectileHeadTargetHeightOffset;

		[SerializeField]
		private float reflectionDuration;

		[SerializeField]
		private int requiredReturnCount;

		[SerializeField]
		private int firstVolleyRequiredReturnCount;

		[SerializeField]
		private float reselectTargetPlayerChance;

		[SerializeField]
		private AnimationCurve projectileSpeedByHealthCurve;

		[SerializeField]
		private float volleySpeedDelta;

		[SerializeField]
		private int takeDamageAmount;

		[SerializeField]
		private float takeDamageDuration;

		[SerializeField]
		private float postDisengageDelay;

		private const float AKNMMGABPGG = 8f;

		private global::MOBDJNEDDKC<Vector3> MDLACAGCOCM;

		private global::MOBDJNEDDKC<bool> KEOEBBAGMIO;

		private global::MOBDJNEDDKC<int> DBOMODCEHJL;

		private global::MOBDJNEDDKC<Vector3> LMHHDBJDGMP;

		private global::MOBDJNEDDKC<float> DKLMALOJAAA;

		private JOJOABLFOBA PBLPENFJJBG;

		private HONEDBECDOK OBGOGHEMNJL;

		private EnemyProjectileToolRangedWeapon KILGKNAIEJE;

		private WitchPatrolPoints CLELAKCJIHE;

		private bool LEHOOFEHJNJ;

private Vector3 IMMECBEDDOF
{
get 		{
			return default;
		}

set {
		}
}

private bool CGKCHPDJOPG
{
get 		{
			return false;
		}

set {
		}
}

private bool FMILAKCNIGH
{
get 		{
			return false;
		}

}

private int GNBMMNHDHBO
{
get 		{
			return 0;
		}

set {
		}
}

private Vector3 JKJJKDJBMLM
{
get 		{
			return default;
		}

set {
		}
}

private float ONKBGLNIHLN
{
get 		{
			return 0f;
		}

set {
		}
}

private int GJEPFMIJAGO
{
get 		{
			return 0;
		}

}

private bool FGCBICPEDKF
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void Update()
		{
		}

		protected override void GJKKJGKFILO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected override void IMPLECFEACH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected override void NEJEMAPNLKG()
		{
		}

		protected override void HMODBJBAIOM()
		{
		}

		private void JJBANHNMPGF(ProjectileTool HKEPPKCNEPN, Enemy KLILJMJEINK, Enemy NJDDIIEPJDM, BHHAHFFCKJO ALOJEPEGILE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void FEAMHGGABOC(EnemyRangedWeaponBase PLOGNHIJBNB, float EJEMJEFJBNM)
		{
		}

		private void AJOCFFKJLCP(ProjectileTool PPKCLLBILPJ, EnemyProjectileToolRangedWeapon.ICCGEAFMOFE LCOBMGBHOJJ, Vector3 PDFEDMAOMNH, Vector3 FJEIPCCFKEB)
		{
		}

		public override bool HasLineOfSight(Vector3 INKGHPCDMCG)
		{
			return false;
		}

		protected override DPMOPDDAJBJ FFFECDFOEAE(bool GCIKGAMKGAE = false)
		{
			return default;
		}

		private void MKOKMJFOCFM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void MGGIGKMIJKD()
		{
		}

		private void OPDOPECMPOD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private Vector3 KFHNHLBDOJH()
		{
			return default;
		}

		private void IPFPPHBKBCN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void KMKFPGEIHMJ()
		{
		}

		private void BBNJBMGIFNA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void NEOGEEMLPON()
		{
		}

		private void BMEDMNOMMCL()
		{
		}

		private void KBELOHLBJOO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void OKBLMCCLGAA()
		{
		}

		private void PADNGNMGAIM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void KNEBPLFJJKK()
		{
		}

		private void CBMBJLKJHAA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void JMBFLCPFJND()
		{
		}

		private void GNODDNCNEFI(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected override void HGFHGLPELGH()
		{
		}

		protected override void EJJDMPGCBGF()
		{
		}

		protected override void CNECFKGNJLJ()
		{
		}
	}
}
