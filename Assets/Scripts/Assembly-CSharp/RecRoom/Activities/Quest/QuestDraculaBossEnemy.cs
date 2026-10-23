using System;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Encounters;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestDraculaBossEnemy : Enemy
	{
		public enum ACHAKLHKBML
		{
			FIND_TARGET = 0,
			TELEPORT_OUT = 1,
			SNEAK = 2,
			TELEPORT_IN = 3,
			CHARGE_ATTACK = 4,
			ATTACK_TARGET = 5,
			POST_ATTACK = 6,
			DASH = 7,
			INVALID = 65535
		}

		private enum MLHDOMJKPJM
		{
			PLAYER_HEAD = 0,
			PLAYER_FEET = 1
		}

		public enum LECLKPALAPF
		{
			VAMPIRE_FORM_1 = 0,
			BAT_FORM_1 = 1,
			VAMPIRE_FORM_2 = 2,
			BAT_FORM_2 = 3,
			VAMPIRE_FORM_3 = 4,
			DEAD = 5
		}

		[Serializable]
		public struct AttackConfiguration
		{
			public LECLKPALAPF encounterPhase;

			public EnemyRangedWeaponBase attackWeapon;

			public int numberOfAttacks;

			public static AttackConfiguration Default => default;
		}

		[Serializable]
		public struct DashConfiguration
		{
			public LECLKPALAPF encounterPhase;

			public float noDashProbability;

			public float dashSpeed;

			public float minDashDistance;

			public float maxDashDistance;

			public float dashTimeout;

			public static DashConfiguration Default => default;
		}

		[SerializeField]
		private bool updateTargetPositionWhileAttacking;

		[SerializeField]
		private float teleportOutDuration;

		[SerializeField]
		private float sneakDuration;

		[SerializeField]
		private float teleportParticleTimeBeforeTeleportIn;

		[SerializeField]
		private float teleportInDuration;

		[SerializeField]
		private float assassinationTeleportInDistanceFromTarget;

		[SerializeField]
		private float normalTeleportInDistanceFromTarget;

		[SerializeField]
		private float normalTeleportAngleInFrontOfPlayer;

		[SerializeField]
		private float assassinationProbability;

		[SerializeField]
		private SkinnedMeshRenderer visibleMeshRenderer;

		[SerializeField]
		private ParticleSystem teleportParticle;

		[SerializeField]
		private ParticleSystem teleportingInParticle;

		[SerializeField]
		private RecRoomAudioClip teleportOutAudioClip;

		[SerializeField]
		private RecRoomAudioClip teleportingInAudioClip;

		[SerializeField]
		private RecRoomAudioClip teleportInAudioClip;

		[SerializeField]
		private float playSneakingVOProbability;

		[SerializeField]
		private RecRoomAudioClip[] sneakingVOClips;

		[SerializeField]
		private float attackChargeDuration;

		[SerializeField]
		private float attackDuration;

		[SerializeField]
		private float targetDistanceForMeleeAttack;

		[SerializeField]
		private MeleeWeaponCollider[] meleeAttackColliders;

		[SerializeField]
		private MLHDOMJKPJM attackTarget;

		[SerializeField]
		private bool canTargetLastVisiblePlayerPosition;

		[SerializeField]
		private float animationShotDelay;

		[SerializeField]
		private AttackConfiguration[] phaseAttackConfigurations;

		[SerializeField]
		private bool supportsPostAttack;

		[SerializeField]
		private float postAttackDuration;

		[SerializeField]
		private DashConfiguration[] phaseDashConfigurations;

		[SerializeField]
		private float maxDashAcceleration;

		[SerializeField]
		private float dashSlowdownDistance;

		[SerializeField]
		private KDBKBBGOBIP batFormEnemyType;

		[SerializeField]
		private KDBKBBGOBIP batFormDecoyEnemyType;

		private const int AJIJDGEDBKP = 3;

		private const int GOPNICAJHDB = 3;

		[SerializeField]
		private GameEncounter animalFormGameEncounter;

		private global::MOBDJNEDDKC<Vector3> DFPKNENHMLE;

		private global::MOBDJNEDDKC<Vector3> LMHHDBJDGMP;

		private global::MOBDJNEDDKC<int> AGDEDAHEPFD;

		public JOJOABLFOBA behaviorStateMachine;

		private HONEDBECDOK ACMNKPDJAJE;

		private HONEDBECDOK OEBBHNLHAKC;

		private AnimationAttackTrigger JKCAPFODGNL;

		private AttackConfiguration BPEODBPKGOD;

		private Vector3 AMMNJIKABKN;

		private int KKBPKPGJMCB;

		private bool KBIDECBJMOG;

		private SFXAudioSource BMAFPCAJDGK;

private Vector3 MNCNJFCMDCG
{
get 		{
			return default;
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

private LECLKPALAPF GPBIDIEKMKK
{
get 		{
			return LECLKPALAPF.VAMPIRE_FORM_1;
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

private bool GMKKNMNFCKN
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

		private void BPHCMHMIBOM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FOMGLMHEOEB()
		{
		}

		private void MCPHEHCANMG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ICHKFIMDHKP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void NFOLKBKPOHG()
		{
		}

		private void FOMMKHHLONN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void APHPJGMBHHH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void IGKJACNCHOA()
		{
		}

		private void KCNEKEHPHLL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private Vector3 BBAFCFDJKFC(out float POEHENDONCI, int JMIKLPCCCGL = 0)
		{
			POEHENDONCI = default;
			return default;
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

		private void MKFNGNMFFMC(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
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

		private void NBCLHBFFIEN(bool MMMANCDALEK)
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

		private bool LEFPDFHGKEO(float KOGBLHPDFAD, float CJLEIIDADFK, out Vector3 IBPJHMBJLEL)
		{
			IBPJHMBJLEL = default;
			return false;
		}

		protected override void HGFHGLPELGH()
		{
		}

		protected override void CNECFKGNJLJ()
		{
		}

		private void CFICHOFHFLH(bool BMGEHFPFCBJ)
		{
		}

		private void CFDGMGOFIFG(bool FBHDABEFLKL)
		{
		}

		private void EJPNGJIPKFK(Enemy NAJIPPPKGLO)
		{
		}

		private void CLPGJLCKBBC(DPMOPDDAJBJ NJDHAACHDKF, Enemy INIEKKNFPDP, Vector3 OGEABPMOJJB)
		{
		}

		private void IPKENALFCAE(Enemy BEKMEKPCLJH)
		{
		}

		private void DCPMDACOJCB(Enemy BEKMEKPCLJH)
		{
		}

		private void HKIABFOJHME()
		{
		}

		private AttackConfiguration AJIHLIOCPIF(LECLKPALAPF MGADLDPDPGK)
		{
			return default;
		}

		private DashConfiguration OCIHPBKGMFF(LECLKPALAPF MGADLDPDPGK)
		{
			return default;
		}

		protected override void BHECKIKLDOK()
		{
		}

		private void DAFKBHGEFHJ(CHILKDJABBF HIGOLKPFBPL)
		{
		}
	}
}
