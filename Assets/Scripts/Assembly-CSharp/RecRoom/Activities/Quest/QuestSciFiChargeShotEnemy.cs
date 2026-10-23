using RecRoom.Audio;
using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestSciFiChargeShotEnemy : Enemy
	{
		private enum KEDHABGJMAP
		{
			POST_SPAWN = 0,
			FIND_TARGET = 1,
			FOLLOW_TARGET = 2,
			ATTACK_DELAY = 3,
			ATTACK = 4,
			INVALID = 65535
		}

		private enum MMALDIDIIKH
		{
			PREPARE_CHARGE = 0,
			CHARGE_ATTACK = 1,
			INVALID = 65535
		}

		[SerializeField]
		private float postSpawnDelay;

		[SerializeField]
		private float scanForTargetHeadSlowdownAngle;

		[SerializeField]
		private float maxScanForTargetHeadYaw;

		[SerializeField]
		private float scanForTargetHeadPitch;

		[SerializeField]
		private float snapToTargetAngularSpeedDegrees;

		[SerializeField]
		private float followTargetMovementSpeed;

		[SerializeField]
		private float followTargetMovementAcceleration;

		[SerializeField]
		private float followTargetMovementSlowdownDistance;

		[SerializeField]
		private float followTargetAngularSpeedDegrees;

		[SerializeField]
		private float targetAcquiredHeadLaserOffset;

		[SerializeField]
		private float desiredTargetOffset;

		[SerializeField]
		private float minRandomOffsetAngle;

		[SerializeField]
		private float maxRandomOffsetAngle;

		[SerializeField]
		private QuestEnemyArticulatingAccessory head;

		[SerializeField]
		private Transform laser;

		[SerializeField]
		private float chargePrepareDuration;

		[SerializeField]
		private float chargeAttackDuration;

		[SerializeField]
		private float attackDelayDuration;

		[SerializeField]
		private float attackDuration;

		[SerializeField]
		private RecRoomAudioClip[] alertVO;

		[SerializeField]
		private RecRoomAudioClip alertSFX;

		private global::MOBDJNEDDKC<float> COACGAECBIP;

		private global::MOBDJNEDDKC<int> JHFOKDGIOFG;

		private JOJOABLFOBA BEMANLOEDDE;

		private HONEDBECDOK ACMNKPDJAJE;

		private EnemyFacialAnimator PPJPDHFBGBF;

		private BlinkingRenderer DOKMDKCBJML;

		private Vector3 DKLNCIGANED;

private float ECKOOCOPNON
{
get 		{
			return 0f;
		}

set {
		}
}

private DPMOPDDAJBJ HFFAHIKBGMO
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

		protected override void Update()
		{
		}

		public override void AuthorityOnDamageApplyForce(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 COPOILGLIAJ, Vector3 PDFEDMAOMNH)
		{
		}

		public override void AuthorityOnDamageChangeVelocity(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK)
		{
		}

		private void JFNFHJCPPJL(ushort EHLPLCEJPDD, ushort ANAKIMJNHMH)
		{
		}

		private void IAPLMCJJKMN()
		{
		}

		protected override DPMOPDDAJBJ FFFECDFOEAE(bool GCIKGAMKGAE = false)
		{
			return default;
		}

		private bool GGICCMOMGNJ()
		{
			return false;
		}

		public override void AuthorityStartPatrol()
		{
		}

		protected override void GJKKJGKFILO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected override void LKEKOJOGKDF()
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

		private void ALENMAAPGIB()
		{
		}

		private void PAHAOJDJFJL(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected override void DLAIAOKPJOI()
		{
		}

		private void GBEONBDLFLF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void NEFJLLMBLOO()
		{
		}

		private void LPMCMKEDAIF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CJCOFDFHGGB()
		{
		}

		private void HFEALJAIMOG(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void EIMIMMMCPAE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EMJDGHEKJDD()
		{
		}

		private void GBIPPEBPHHA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BMAEGNLOJFN()
		{
		}

		protected override void GGKGCGAEDOI()
		{
		}

		protected override void HDGAJEPCDAJ()
		{
		}

		protected override void CLPGJLCKBBC(DPMOPDDAJBJ NJDHAACHDKF, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, bool HGCNLFKJLHP, Vector3 EPGAOLNDLII, Vector3 OMGOEKPFJCM)
		{
		}

		protected override void EJMDHILBIGC(bool BDHANIHALBA)
		{
		}

		protected override void BHECKIKLDOK()
		{
		}

		private void MGKIHJHMPPK(out Vector3 EPGAOLNDLII, out Vector3 OMGOEKPFJCM)
		{
			EPGAOLNDLII = default;
			OMGOEKPFJCM = default;
		}

		private void IJELIFJAHBK()
		{
		}

		public override void TransferOwnership(CHILKDJABBF EKOFNPFCLMO)
		{
		}
	}
}
