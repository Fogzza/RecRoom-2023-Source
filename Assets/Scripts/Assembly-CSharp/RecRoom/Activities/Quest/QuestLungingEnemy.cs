using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestLungingEnemy : Enemy
	{
		private enum KLMHNIPBODJ
		{
			FIND_TARGET = 0,
			FOLLOW_TARGET = 1,
			LUNGE_ATTACK_CHARGE = 2,
			LUNGE_ATTACK = 3,
			POST_ATTACK = 4,
			DASH = 5,
			INVALID = 65535
		}

		[SerializeField]
		private bool pathTowardsPlayerCentroidToFindTarget;

		[SerializeField]
		private float desiredTargetDistance;

		[SerializeField]
		private float attackChargeDuration;

		[SerializeField]
		private float maxLungeDistance;

		[SerializeField]
		private float lungeAcceleration;

		[SerializeField]
		private float lungeTime;

		[SerializeField]
		private AnimationCurve lungeCurve;

		[SerializeField]
		private float postAttackDuration;

		[SerializeField]
		private float dashSpeed;

		[SerializeField]
		private float maxDashAcceleration;

		[SerializeField]
		private float dashSlowdownDistance;

		[SerializeField]
		private float minDashDistance;

		[SerializeField]
		private float maxDashDistance;

		[SerializeField]
		private float dashTimeout;

		[SerializeField]
		private ParticleSystem lungeParticle;

		[SerializeField]
		private TrailRenderer lungeTrail;

		private const string ELALOBEFMCA = "LungingEnemy";

		private JOJOABLFOBA BEMANLOEDDE;

		private HONEDBECDOK ACMNKPDJAJE;

		private bool CFKPFHIBDBJ;

		private AnimationAttackTrigger JKCAPFODGNL;

		private float BNMGANHBCPG;

		private global::MOBDJNEDDKC<Vector3> DFPKNENHMLE;

		private float JNFBGFLKCEM;

		private float KHPIEGPFDEK;

		private float AFJJPBPFFFK;

private Vector3 MNCNJFCMDCG
{
get 		{
			return default;
		}

set {
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

		protected override void OnDestroy()
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

		private void DKDPHKDOEGP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected virtual void ALENMAAPGIB()
		{
		}

		private void PAHAOJDJFJL(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
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

		private void IFEBJPBGABG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void MDEGLGMCLJI()
		{
		}

		private void LIJLLMJPMPL(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private Vector3 CKBPNFHJNGP()
		{
			return default;
		}

		private void ILNPOMIPENH(DPMOPDDAJBJ GFCPAMJILIO, out float PKFCJPAKBLP, out float HMKBMBOECPO)
		{
			PKFCJPAKBLP = default;
			HMKBMBOECPO = default;
		}

		private void IGIBCGINMAE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void HJIHDHNANNI()
		{
		}

		private void NMJLEDHDDNL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
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

		private void CFDGMGOFIFG(bool FBHDABEFLKL)
		{
		}

		protected override void EKCPKDDGHED(Enemy DPENEFKKNDN, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void ENFODDCBCJP(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void EJMDHILBIGC(bool BDHANIHALBA)
		{
		}

		protected override void PNHOKAPCDOJ(bool BDHANIHALBA)
		{
		}
	}
}
