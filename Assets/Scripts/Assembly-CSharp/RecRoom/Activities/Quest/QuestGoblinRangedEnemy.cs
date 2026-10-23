using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestGoblinRangedEnemy : Enemy
	{
		private enum KJPHNGKIPGN
		{
			FIND_TARGET = 0,
			CHARGE_ATTACK = 1,
			ATTACK_TARGET = 2,
			POST_ATTACK = 3,
			DASH = 4,
			INVALID = 65535
		}

		private enum BGLNKHAFOIL
		{
			PLAYER_HEAD = 0,
			PLAYER_FEET = 1
		}

		[SerializeField]
		private bool pathTowardsPlayerCentroidToFindTarget;

		[SerializeField]
		private bool updateTargetPositionWhileAttacking;

		[SerializeField]
		private float attackChargeDuration;

		[SerializeField]
		private float attackDuration;

		[SerializeField]
		private BGLNKHAFOIL attackTarget;

		[SerializeField]
		private bool canTargetLastVisiblePlayerPosition;

		[SerializeField]
		private float animationShotDelay;

		[SerializeField]
		private bool supportsPostAttack;

		[SerializeField]
		private float postAttackDuration;

		[SerializeField]
		private float dashSpeed;

		[SerializeField]
		private float maxHorizontalDashAcceleration;

		[SerializeField]
		private float maxVerticalDashAcceleration;

		[SerializeField]
		private float dashSlowdownDistance;

		[SerializeField]
		private float minDashDistance;

		[SerializeField]
		private float maxDashDistance;

		[SerializeField]
		private float dashTimeout;

		private global::MOBDJNEDDKC<Vector3> DFPKNENHMLE;

		private JOJOABLFOBA BEMANLOEDDE;

		private HONEDBECDOK ACMNKPDJAJE;

		private Vector3 AMMNJIKABKN;

private Vector3 MNCNJFCMDCG
{
get 		{
			return default;
		}

set {
		}
}

private bool ACBEEOHCOEC
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

		protected override void NEJEMAPNLKG()
		{
		}

		protected override void OFHFJBCEGKG()
		{
		}

		protected override void Update()
		{
		}

		private void BEJICGGDLFJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void GJDHFPLLBKK()
		{
		}

		private void OEOKBBOBEDP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void BBNJBMGIFNA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void NEOGEEMLPON()
		{
		}

		private void LIGGBJBKGFC(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void BNJAPGBDOLM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void HABGKFLKMDK()
		{
		}

		private Vector3 DFOCJAIEDEN()
		{
			return default;
		}

		private bool KCKAGIMANAH(out Vector3 INKGHPCDMCG)
		{
			INKGHPCDMCG = default;
			return false;
		}

		private void NBCLHBFFIEN()
		{
		}

		private void IGIBCGINMAE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void HJIHDHNANNI()
		{
		}

		private void NMJLEDHDDNL(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void APBHDHFBHIO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void INCHPNPOKPF()
		{
		}

		private void BJHMOLGOFFK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private Vector3 CCJJDGFIKGO()
		{
			return default;
		}

		protected override void EJMDHILBIGC(bool BDHANIHALBA)
		{
		}

		protected override void PNHOKAPCDOJ(bool BDHANIHALBA)
		{
		}

		protected override void BHECKIKLDOK()
		{
		}
	}
}
