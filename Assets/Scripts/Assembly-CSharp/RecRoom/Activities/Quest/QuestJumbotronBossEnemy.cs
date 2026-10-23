using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestJumbotronBossEnemy : Enemy
	{
		private enum DHJFABACIAB
		{
			WAKING_UP = 0,
			FIND_TARGET = 1,
			FOLLOW_TARGET = 2,
			CHARGE_ATTACK = 3,
			ATTACK = 4,
			FACE_BROKE = 5,
			INVALID = 65535
		}

		[SerializeField]
		private float wakeUpDuration;

		[SerializeField]
		private float screenBrokeWaitDuration;

		[SerializeField]
		private RecRoomAudioClip wakeUpVO;

		[SerializeField]
		private RecRoomAudioClip[] screenBreakAudio;

		[SerializeField]
		private RecRoomAudioClip[] randomScreenBreakVO;

		[SerializeField]
		private RecRoomAudioClip deathVO;

		[SerializeField]
		private float slowdownAngle;

		[SerializeField]
		private float lookForTargetPitchAngle;

		[SerializeField]
		private float lookForTargetsRotationSpeed;

		[SerializeField]
		private float lookAtTargetRotationSpeed;

		[SerializeField]
		private float lookAtTargetDuration;

		[SerializeField]
		private float chargeAttackDuration;

		[SerializeField]
		private float attackDuration;

		private global::MOBDJNEDDKC<float> AJENIADDELN;

		private global::MOBDJNEDDKC<int> IHFGALLHKMG;

		private JOJOABLFOBA BEMANLOEDDE;

		private HONEDBECDOK ACMNKPDJAJE;

		private QuestJumbotronBossWeapon PLOGNHIJBNB;

		private QuestJumbotronBossFace[] BHBOOIGABNI;

		private static CFEAILHKDEA JOOFKJAKMFF__BackingField;

public override int CustomEncounterValue
{
get 		{
			return 0;
		}

}

public override bool CanAggroEnemies
{
get 		{
			return false;
		}

}

private float KDMHCEHBMJO
{
get 		{
			return 0f;
		}

set {
		}
}

private int HBJKIOFAIHL
{
get 		{
			return 0;
		}

set {
		}
}

private int BIFECDFCEKL
{
get 		{
			return 0;
		}

}

public static event CFEAILHKDEA TookDamageEvent {
add {
		}
remove {
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

		protected override void NEJEMAPNLKG()
		{
		}

		protected override void OFHFJBCEGKG()
		{
		}

		protected override void Update()
		{
		}

		protected override void CKEEPLIFHHJ()
		{
		}

		protected override void HGFHGLPELGH()
		{
		}

		protected override void CNECFKGNJLJ()
		{
		}

		private void HILGCFFPCIP()
		{
		}

		private void EMMDJJNLKHB()
		{
		}

		private void LAGJBLBBDIM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void PADLIGLCIIH()
		{
		}

		private void BEJICGGDLFJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void GJDHFPLLBKK()
		{
		}

		private void ILABFONGDBP()
		{
		}

		private void DKDPHKDOEGP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ALENMAAPGIB()
		{
		}

		private void BBNJBMGIFNA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void NEOGEEMLPON()
		{
		}

		private void GBIPPEBPHHA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BMAEGNLOJFN()
		{
		}

		private void IPJAFMKJPEA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void IJLFNBGCDDK()
		{
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

		protected override void OJLPPOJMJJP()
		{
		}

		protected override bool DGLIDHCLFDE(DPMOPDDAJBJ NJDHAACHDKF, Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		protected override void CLPGJLCKBBC(DPMOPDDAJBJ NJDHAACHDKF, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, bool HGCNLFKJLHP, Vector3 EPGAOLNDLII, Vector3 OMGOEKPFJCM)
		{
		}

		private void CLIOLBMFMEN(QuestJumbotronBossFace KAJJOBOBAIK, int LCLKHEDICPD, int EMDIPCIPFBF, CHILKDJABBF FDOGMDABIGJ)
		{
		}

		private void BJLEPEEIPNA(QuestJumbotronBossFace KAJJOBOBAIK, CHILKDJABBF FDOGMDABIGJ)
		{
		}

		private QuestJumbotronBossFace PNCJLGLDOJD(BHHAHFFCKJO GFHNJGJNNCK)
		{
			return null;
		}

		public override void AuthorityOnDamageApplyForce(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 COPOILGLIAJ, Vector3 PDFEDMAOMNH)
		{
		}

		public override void AuthorityOnDamageChangeVelocity(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK)
		{
		}

		public override void AuthorityClearVelocity()
		{
		}

		private void OEGDFMPMLPI()
		{
		}
	}
}
