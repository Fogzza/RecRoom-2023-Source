using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestKnightEnemy : Enemy
	{
		private enum BNIADBFNKPI
		{
			SPIN = 0,
			CHARGE = 1
		}

		private enum CMNLOMBBLJI
		{
			FIND_TARGET = 0,
			FOLLOW_TARGET = 1,
			LOOK_AT_TARGET = 2,
			SLASH_ATTACK = 3,
			SPIN_ATTACK_PREPARE = 4,
			SPIN_ATTACK = 5,
			SPIN_ATTACK_STOP = 6,
			CHARGE_TARGET = 7,
			POST_ATTACK = 8,
			INVALID = 65535
		}

		[SerializeField]
		private BNIADBFNKPI attackType;

		[SerializeField]
		private float desiredTargetDistance;

		[SerializeField]
		private float minRandomTargetOffsetAngle;

		[SerializeField]
		private float maxRandomTargetOffsetAngle;

		[SerializeField]
		private float lookAtTargetDuration;

		[SerializeField]
		private float lookAtTargetAngularSpeedDegrees;

		[SerializeField]
		private float attackRange;

		[SerializeField]
		private float slashAttackDuration;

		[SerializeField]
		private float spinPrepareAngularSpeed;

		[SerializeField]
		private float spinPrepareAngle;

		[SerializeField]
		private float spinPrepareSlowdownAngle;

		[SerializeField]
		private float spinAngularSpeed;

		[SerializeField]
		private float spinAngle;

		[SerializeField]
		private float spinStopAngle;

		[SerializeField]
		private float spinStopSlowdownAngle;

		[SerializeField]
		private float postAttackDuration;

		[SerializeField]
		private float chargeDistance;

		[SerializeField]
		private float chargeSpeed;

		[SerializeField]
		private float chargeAcceleration;

		[SerializeField]
		private ParticleSystem chargeParticles;

		public const string CHARGE_SPEED_OVERRIDE = "CSO";

		public const string CHARGE_DIST_OVERRIDE = "CDO";

		private JOJOABLFOBA BEMANLOEDDE;

		private HONEDBECDOK ACMNKPDJAJE;

		private global::MOBDJNEDDKC<Vector3> GNIHDACGJEI;

		private AnimationAttackTrigger JKCAPFODGNL;

private Vector3 EMAJHKHIJEM
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

		public override void AuthorityOnDamageApplyForce(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 COPOILGLIAJ, Vector3 PDFEDMAOMNH)
		{
		}

		public override void AuthorityOnDamageChangeVelocity(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK)
		{
		}

		private void GJDHFPLLBKK()
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

		private void FPNGEKCEANP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void MMAABMFIMNF()
		{
		}

		private void BBBDAGOAGJO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KDCLMGNBHIP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void OPJEBBAIKMA()
		{
		}

		private void APNOOOLPFNO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void IGBJOJCEHPJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BBEAGNHJMGM()
		{
		}

		private void CJEAFLPACDH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void NKLCAGOIOHK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ODJFEPFPANN()
		{
		}

		private void KAGFEGMFAEJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
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

		private void GOIELBJMOBA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void HHHFLCGKLCO()
		{
		}

		private void KCEBEMDAAPF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private Vector3 APMAGFLLNIC()
		{
			return default;
		}

		private void ECMFAFLFBPE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void KHHNPBBCFNC()
		{
		}

		private void DDLEIPKPMMA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected override void GGKGCGAEDOI()
		{
		}

		protected override void HDGAJEPCDAJ()
		{
		}

		private void CFDGMGOFIFG(bool FBHDABEFLKL)
		{
		}
	}
}
