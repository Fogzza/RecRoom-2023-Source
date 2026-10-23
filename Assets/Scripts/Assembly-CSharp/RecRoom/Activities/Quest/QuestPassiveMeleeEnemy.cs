using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestPassiveMeleeEnemy : Enemy
	{
		private enum DPJHBNKAIBD
		{
			FIND_TARGET = 0,
			FOLLOW_TARGET = 1,
			PASSIVELY_ATTACK = 2,
			INVALID = 65535
		}

		[SerializeField]
		private float desiredTargetDistance;

		[SerializeField]
		private float minRandomTargetOffsetAngle;

		[SerializeField]
		private float maxRandomTargetOffsetAngle;

		[SerializeField]
		private Transform armsTransform;

		[SerializeField]
		private float meleeAttackDuration;

		[SerializeField]
		private SimpleVolume meleeColliderActivationHitBox;

		[SerializeField]
		private float shieldStunRecoilSpeed;

		private JOJOABLFOBA PBLPENFJJBG;

		private HONEDBECDOK NCFAAOFJHCF;

		private Collider[] NJLMBIIMFKD;

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

		protected override void MGKPHCBKLEN(Enemy DPENEFKKNDN, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void EKCPKDDGHED(Enemy DPENEFKKNDN, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private bool LLKDKFPLKEM(Player EKOFNPFCLMO, out MeleeWeapon OHDFIGLMMFC)
		{
			OHDFIGLMMFC = null;
			return false;
		}

		private bool LBINGFEPINI(Tool IEGMBEPJMGC, out MeleeWeapon OHDFIGLMMFC)
		{
			OHDFIGLMMFC = null;
			return false;
		}

		private void ADKFPFKKDEL(Weapon OHDFIGLMMFC, Vector3 MIFJCKFLKDI, Vector3 CJMFBCALHFK)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcOnPlayerBlocked(int EBPAGLCOLCM, Vector3 PDFEDMAOMNH)
		{
		}

		private void GNAKKEOEFLN()
		{
		}

		private void GJDHFPLLBKK()
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

		private void GIBOKJPMNPD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BOFBIANBPDF()
		{
		}

		private void OFEKNCACLAJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void IDEDGGLGLAD()
		{
		}

		public override void AuthorityOnDamageChangeVelocity(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK)
		{
		}

		protected override void GGKGCGAEDOI()
		{
		}

		protected override void HDGAJEPCDAJ()
		{
		}
	}
}
