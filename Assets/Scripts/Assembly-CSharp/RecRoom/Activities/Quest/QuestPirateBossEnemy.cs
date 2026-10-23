using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestPirateBossEnemy : Enemy
	{
		private enum FENOJJEDEPK
		{
			IDLE = 0,
			RELOCATE = 1,
			EVADE = 2,
			FIND_TARGET = 3,
			CHARGE_ATTACK = 4,
			ATTACK = 5,
			INVALID = 65535
		}

		private enum CIMPBDBKAKI
		{
			EVADE = 0,
			POST_EVADE_IDLE = 1
		}

		[SerializeField]
		private float maxEvadeDistance;

		[SerializeField]
		private float evadeMovementSpeed;

		[SerializeField]
		private float evadeSlowdownDistance;

		[SerializeField]
		private float evadeCompleteIdleDuration;

		[SerializeField]
		private float evadeAngularSpeed;

		[SerializeField]
		private float maxEvadeFaceVelocityDistance;

		[SerializeField]
		private float evadeFaceVelocityYawAngle;

		[SerializeField]
		private float firstPhaseRangedAttackChance;

		[SerializeField]
		private float secondPhaseRangedAttackChance;

		[SerializeField]
		private float thirdPhaseRangedAttackChance;

		[SerializeField]
		private float attackChargeDuration;

		[SerializeField]
		private float attackDuration;

		private JOJOABLFOBA PBLPENFJJBG;

		private HONEDBECDOK OBGOGHEMNJL;

		private global::MOBDJNEDDKC<int> JGCCGHEDOGJ;

		private global::MOBDJNEDDKC<Vector3> JMAFJEAFBMI;

		private global::MOBDJNEDDKC<bool> CPAGEAKBGOP;

		private QuestPirateBossPatrolPoints OKBNLPEODMB;

private bool NEFKADHHCGD
{
get 		{
			return false;
		}

set {
		}
}

public override int CustomEncounterValue
{
get 		{
			return 0;
		}

}

private int ELNPOIKKOAK
{
get 		{
			return 0;
		}

set {
		}
}

private Vector3 PFNECLAPAKJ
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

		protected override void Update()
		{
		}

		protected override void NEJEMAPNLKG()
		{
		}

		protected override void OFHFJBCEGKG()
		{
		}

		protected override bool DGLIDHCLFDE(DPMOPDDAJBJ NJDHAACHDKF, Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		protected override void EJMDHILBIGC(bool BDHANIHALBA)
		{
		}

		protected override void PNHOKAPCDOJ(bool BDHANIHALBA)
		{
		}

		protected override void PAMOPOINNCC()
		{
		}

		private Transform GALIAKFIHGP(bool DALBGHLBKEN = false)
		{
			return null;
		}

		private void GJNLEDMGNHO()
		{
		}

		private void PCJPIECAHOB()
		{
		}

		private void MKOKMJFOCFM(ushort IAMJCGFGNAO, ushort HKDHPIPECPL)
		{
		}

		private void MGGIGKMIJKD()
		{
		}

		private void OPDOPECMPOD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void HIAMMPHIHMF(ushort EHLPLCEJPDD, ushort ODCFAHJGDJN)
		{
		}

		private void DFNNHBINCIK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void IJFJGFOHKIC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void NCMHIOFKIOF()
		{
		}

		private void HGPNMIFLKPF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void DHAAOHPJGGN(Transform LGNBPPLGJBI)
		{
		}

		private Vector3 DPIBAJJBNDP(Vector3 INKGHPCDMCG, Transform GLEAOGHMBPH)
		{
			return default;
		}

		private Vector3 MACCNHAMELK(Transform GLEAOGHMBPH)
		{
			return default;
		}

		private void LJBEPDAKOMD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BFBPEBIALNL()
		{
		}

		private Vector3 CFFGJFJFPIL(Transform LGNBPPLGJBI, Vector3 NHFFGAAPMLI)
		{
			return default;
		}

		private bool LEJPFPCOCPK()
		{
			return false;
		}

		private float FDDFCHJFMLD()
		{
			return 0f;
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

		private void GBIPPEBPHHA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BMAEGNLOJFN()
		{
		}

		private void IFNAHGAPMEP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
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
