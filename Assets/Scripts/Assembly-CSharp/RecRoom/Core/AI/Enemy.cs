using System;
using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Core.Combat;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Core.AI
{
	public abstract class Enemy : MonoBehaviourPun, EHHJPOOBNFN, JGPDIPBCBHK
	{
		public enum MDGCCBDJGBJ
		{
			DEFAULT = 0,
			ALWAYS_DISPLAY = 1,
			NEVER_DISPLAY = 2
		}

		private enum EICFINHKKCA
		{
			INSTANTIATOR_ID = 0,
			INSTANTIATION_PARAMS = 1,
			ENEMY_TYPE = 2,
			SPAWN_TARGET_POSITION = 3,
			SPAWN_ON_PATROL = 4,
			PATROL_PHOTON_VIEW_ID = 5,
			TEAM_ID = 6,
			SPAWN_DISENGAGED = 7,
			UNIQUE_RANDOM_VALUE = 8,
			VALUE_COUNT = 9
		}

		private enum AIHPHFJFLML
		{
			NONE = 0,
			ANIMATION = 1,
			PHYSICS = 2,
			PHYSICS_ON_COLLISION = 3
		}

		public enum JGNNBCGFCLN
		{
			INVALID = 0,
			SPAWNING = 1,
			PATROL = 2,
			COMBAT = 3,
			INTERRUPTED = 4,
			DISENGAGED = 5,
			DEAD = 6,
			CUSTOM_LOGIC = 7
		}

		private enum CCNKDDBCLFN
		{
			COMBAT_ACTIVE = 0,
			COMBAT_STUN = 1
		}

		private enum EJHBCKODIHP
		{
			INTERRUPTED_STUN = 0,
			INTERRUPTED_RECOVERY = 1
		}

		private enum BEPLPCGCDEM
		{
			RANDOM = 0,
			CLOSEST = 1,
			LEAST_TARGETED = 2
		}

		public enum MHOMBEOIIIG
		{
			INVALID = -1,
			OMNIDIRECTIONAL = 0,
			VISION_CONE = 1
		}

		public delegate void CFEAILHKDEA(Enemy DPENEFKKNDN);

		public delegate void LAHBDMEFDJH(Enemy DPENEFKKNDN, Collision KDGCDLJEAMD);

		[Serializable]
		protected class CombatSettings
		{
			public DJBEHNDMJDL DamageType;

			public bool InterruptsBehavior;

			public float StunDuration;

			public float DamageMultiplier;

			public float RecoilMultiplier;

			public float KillingBlowRecoilMultiplier;

			public bool CriticalHitInterruptsBehavior;

			public float CriticalHitStunDuration;

			public float CriticalHitDamageMultiplier;

			public float CriticalHitRecoilMultiplier;

			public float KillingBlowCriticalHitRecoilMultiplier;

			public bool ShieldHitInterruptsBehavior;

			public float ShieldHitStunDuration;

			public float ShieldHitDamageMultiplier;

			public float ShieldHitRecoilMultiplier;

			public static CombatSettings Default => null;
		}

		[Serializable]
		protected struct RigidbodyConstraintSettings
		{
			[SerializeField]
			private bool freezePositionX;

			[SerializeField]
			private bool freezePositionY;

			[SerializeField]
			private bool freezePositionZ;

			[SerializeField]
			private bool freezeRotationX;

			[SerializeField]
			private bool freezeRotationY;

			[SerializeField]
			private bool freezeRotationZ;

			public RigidbodyConstraints Constraints => RigidbodyConstraints.None;

			public RigidbodyConstraintSettings(bool DFIOIDKKNAG, bool PBKGCJJKIIA, bool AICLHJBLDNL, bool NICACMNHNMB, bool APEIBOHNGNA, bool IMECOMNBIEK)
			{
				freezePositionX = false;
				freezePositionY = false;
				freezePositionZ = false;
				freezeRotationX = false;
				freezeRotationY = false;
				freezeRotationZ = false;
			}
		}

		[Serializable]
		private struct PlayerDamageSetting
		{
			public Player.NBPIPAJOGLC BodyPart;

			public int Damage;
		}

		[SerializeField]
		private float patrolSearchRadius;

		[SerializeField]
		private float patrolSpeed;

		[SerializeField]
		private float patrolMaxAcceleration;

		[SerializeField]
		private float patrolAngularSpeed;

		[SerializeField]
		private PlayerDamageSetting[] playerDamageSettings;

		[SerializeField]
		private int enemyDamage;

		[SerializeField]
		private CombatSettings[] combatSettings;

		[SerializeField]
		private bool stunnedUntilRigidbodyComesToRest;

		[SerializeField]
		private RigidbodyConstraintSettings interruptedStunConstraints;

		[SerializeField]
		private RigidbodyConstraintSettings stunConstraints;

		[SerializeField]
		private int maxHealth;

		[SerializeField]
		private bool takesDamageOnKillzones;

		[SerializeField]
		private Transform healthBarRoot;

		[SerializeField]
		private Vector3 healthBarOffset;

		[SerializeField]
		private float healthBarScale;

		[SerializeField]
		private MDGCCBDJGBJ healthBarSetting;

		[SerializeField]
		private Transform lineOfSightOrigin;

		[SerializeField]
		private float spawnDuration;

		[SerializeField]
		private float spawnSlowdownDistance;

		[SerializeField]
		private float movementSpeed;

		[SerializeField]
		private bool fudgeMovementSpeed;

		[SerializeField]
		protected float movementMaxAcceleration;

		[SerializeField]
		protected float movementAngularSpeed;

		[SerializeField]
		protected float movementSlowdownDistance;

		[SerializeField]
		protected bool neverPitchWhileLooking;

		[SerializeField]
		private float animationShatterDeathDuration;

		[SerializeField]
		private AIHPHFJFLML shatterType;

		[SerializeField]
		private bool animationShatterLookAtAttack;

		[SerializeField]
		private float ragdollShatterSpeed;

		[SerializeField]
		private float recoveryDuration;

		[SerializeField]
		private bool transferOwnershipOnTargetChange;

		[SerializeField]
		protected bool trackTargetCount;

		[SerializeField]
		protected float preferredTargetSearchRadius;

		[SerializeField]
		private float maxTargetSearchRadius;

		[SerializeField]
		private bool prioritizeAttackers;

		[SerializeField]
		private int timesToPrioritizeCurrentTargets;

		[SerializeField]
		private bool requireLineOfSightToTargets;

		[SerializeField]
		private BEPLPCGCDEM patrolTargetSelectionMode;

		[SerializeField]
		private BEPLPCGCDEM combatTargetSelectionMode;

		[SerializeField]
		private MHOMBEOIIIG targetFindingDirection;

		[SerializeField]
		private float visionConeAngle;

		[SerializeField]
		private float visionConeHeight;

		[SerializeField]
		private float stuckDistanceFromNavMesh;

		[SerializeField]
		private float stuckSecondsUntilAutoKill;

		[SerializeField]
		private bool spawnToolOnDeath;

		[SerializeField]
		private SerializedGuid spawnToolTypeId;

		[SerializeField]
		private EnemyAnimator enemyAnimator;

		[SerializeField]
		private EnemyAudio enemyAudio;

		[SerializeField]
		private EnemyParticles enemyParticles;

		[SerializeField]
		private EnemyRangedWeaponBase rangedWeapon;

		[SerializeField]
		private PointsDropper pointsDropper;

		[SerializeField]
		private NetworkTransform networkTransform;

		[SerializeField]
		private RigidbodyEx rigidbodyEx;

		[SerializeField]
		private Steering steering;

		[SerializeField]
		private VisibleInCamera visibleInCamera;

		private static Transform JKEHDDNLLOB;

		private static readonly float IFCFIJCNGGM;

		private Collider[] NJLMABKOLAK;

		private MeleeWeaponCollider[] GHACMINFMCJ;

		private Renderer[] KJJMMGMBOFO;

		private RagdollPiece[] MOLDOBOFBBP;

		private QuestEnemyArticulatingAccessory[] DLJMLKCDALI;

		protected bool BHBMMJAPDJJ;

		protected Vector3 NLPNLHGADKH;

		protected Vector3 KCMFJMDIABN;

		private float IFGHGIMKJPG;

		private float BBJODLPGPOM;

		private float ABDAFPGMCAF;

		private DPMOPDDAJBJ BNFDOAGKGPL;

		private int MBJJKJFKIKJ;

		private bool DCECLAKALBD;

		private bool IFCDBMHFABD;

		private bool AMFJKDDFKJM;

		private global::MOBDJNEDDKC<int> CMOCBCIONGB;

		private global::MOBDJNEDDKC<bool> OJBLGDIBIBH;

		private global::JPEBBAFCBEP<int, Vector3> MEPJMCOAPGG;

		private global::MOBDJNEDDKC<bool> GLGFOAGHLAM;

		private global::MOBDJNEDDKC<int> BMHLBLNGLKJ;

		private global::MOBDJNEDDKC<int> IFJCADMHNDH;

		private global::MOBDJNEDDKC<int> ALEEHFNPNAE;

		private global::MOBDJNEDDKC<bool> LPOAOLEINJD;

		private global::JPEBBAFCBEP<ushort, ushort> PBOOEJDNOKP;

		private global::MOBDJNEDDKC<int> GLAGHFANHOP;

		private global::KPBNLENPEPO<int, float, float, float> CLNHBLNONIH;

		private global::MOBDJNEDDKC<bool> JOHEEDDILNB;

		private global::MOBDJNEDDKC<float> HEMFMPCJLOO;

		private FIHGBEHGLGB BIPPIKPBMIE;

		private global::MOBDJNEDDKC<bool> DEOKIEGBBAF;

		private JOJOABLFOBA BGBIFFLGANM;

		private HONEDBECDOK IFCDBBCODHP;

		protected bool HOCFFNMCCJJ;

		protected bool MBHHCJEHBDB;

		private bool EJEOJHDFICP;

		protected List<CHILKDJABBF> MNGLDCONAMN;

		protected bool LEFEEMBFHCB;

		protected bool GOGEDKOLIBK;

		protected bool JMLLCJEMLPN;

		protected List<DPMOPDDAJBJ> LANECALFJIP;

		private const float DHKOBFAJCAG = 4.25f;

		private const int KIGNIGDDNIB = 100;

		private const int LHIPJOAPOEP = 100;

		private const float LONBAEHHKBB = 5f;

		private const float JEEEDKMOGIL = 4f;

		private const float ALENDKHJKHC = 0.25f;

		private const float GKEJEMEIDOK = 10f;

		private const float LKICAEBFLOO = 0.1f;

		private const float BPNBFEDFHCC = 6f;

		private const float FEBLJMBHFHG = 6f;

		private const float OALECKDGJEI = 0.4f;

		private const float GHJIKKKIHBI = 1f;

		private const int LNNANHNJCFE = 0;

		private const float NMHOOLDFIBI = 0.05f;

		private const float NAECOILFJFM = 0.0025000002f;

		private const float JGICKFONCJI = 1f;

		private const float LKEPIIIIION = 1f;

		private const float IFDEDODLAAF = 4f;

		private const float JLNFDEFJCPF = 2f;

		private const float GPMBLFGADHP = 1f;

		private const float JMLNGGEHPDE = 720f;

		private const float AJJOHJENCLM = 1f;

		protected const RigidbodyConstraints KJGINDNNMOH = RigidbodyConstraints.FreezeRotation;

		protected const RigidbodyConstraints JILFEFFLPBH = RigidbodyConstraints.None;

		private const float CJGIJDHCMIF = 2f;

		public const string SPAWN_STATE_OVERRIDE = "SSO";

		public const string PREVENT_AUTO_AGGRO_OVERRIDE = "AAO";

		public const string MAX_HEALTH_OVERRIDE = "MHO";

		public const string MOVE_SPEED_OVERRIDE = "MSO";

		public const string HEALTH_BAR_OVERRIDE = "HBO";

		public const string DASH_SPEED_OVERRIDE = "DSO";

		public const string DASH_MIN_DIST_OVERRIDE = "DMiDO";

		public const string DASH_MAX_DIST_OVERRIDE = "DMaDO";

		private float NPDHHIEKPAL;

		private const float NKLGGGDBAEL = 45f;

		private const float KBOFKHNDFCG = 2f;

		private EnemyRangedWeaponBase EAFLPIADMGI;

		private EnemyCollider[] DEHLPBDCGBO;

		private int HGPNIBBIJPE;

		private Dictionary<string, object> DMDCPHJIGKG;

		private KDBKBBGOBIP GHIAIFIJADH;

		private Vector3 LGHADAEGANK;

		private Vector3 OEEINIAJEGG;

		private bool PHEAEMOAACF;

		private GIBEGHKMCIE IAIOPJHCCEJ;

		private float MHNENFBBMPM;

		private bool OLFFFNIDBKA;

		private global::MOBDJNEDDKC<int> KDBAGDPBKHN;

		private global::MOBDJNEDDKC<int> ODNBHACJGGB;

		private global::DAHHPCNLCBH<EnemyPatrol> BLFNOAIHLIK;

		private bool EGCOLEMAAKE;

		private DPMOPDDAJBJ FCLAKEDJHGB;

		private int KIJHHBJDKFC;

		private Weapon CILAHJALAFL;

		private int FOEDLFFFPGL;

		private bool NJFADEMEDMO;

		private bool HDPACFKHEBO;

		private DPMOPDDAJBJ JAFPFEALLLE;

		private int KPNABLMBNCG;

		private Vector3 CIHKDJIBOCG;

		private float INCANBOGKGN;

		private bool KMMDFHKHFJF;

		public static global::HHOBPMOCKMJ<Enemy> EnemyInstantiatedEvent;

		public static global::HHOBPMOCKMJ<Enemy> EnemySpawnEvent;

		public static global::BPEPJJDICII<Enemy, DPMOPDDAJBJ> EnemyDeathEvent;

		public static global::BPEPJJDICII<Enemy, DPMOPDDAJBJ> EnemyTargetChangeEvent;

		public static global::KAJFMPHPBGO<Enemy, DPMOPDDAJBJ, Tool, Vector3> EnemyDetectedImpact;

		public static global::CBEFDECGNBJ<DPMOPDDAJBJ, Enemy, Vector3> TookDamageEvent;

		public static global::KAJFMPHPBGO<Enemy, int, int, CHILKDJABBF> EnemyHealthChangeEvent;

		private LAHBDMEFDJH GOMJJNFHOIA__BackingField;

		private CFEAILHKDEA BDDKEOEEIMM__BackingField;

		private CFEAILHKDEA DKNHPNKHCLB__BackingField;

		private CFEAILHKDEA KMLNBCONAPB__BackingField;

		private CFEAILHKDEA FHEEDBPMHEN__BackingField;

		private CFEAILHKDEA NIANOHANMAK__BackingField;

		private CFEAILHKDEA LMHHEFHPBNN__BackingField;

		private CFEAILHKDEA COPAGALAENI__BackingField;

		private CFEAILHKDEA IPIKJNEJEOO__BackingField;

		private CFEAILHKDEA AOPJFCCAHBE__BackingField;

private JBGFOIKBKED MPKLANEMOCA
{
get 		{
			return JBGFOIKBKED.AC_UNIT;
		}

}

private static Transform BMDNACLBJJJ
{
get 		{
			return null;
		}

}

public Steering Steering
{
get 		{
			return null;
		}

}

public RigidbodyEx RigidbodyEx
{
get 		{
			return null;
		}

}

public int PhotonViewId
{
get 		{
			return 0;
		}

}

private PointsDropper BCKOEOOOCGE
{
get 		{
			return null;
		}

}

public EnemyAudio EnemyAudio
{
get 		{
			return null;
		}

}

protected EnemyAnimator LJCLDKDBJIB
{
get 		{
			return null;
		}

}

protected EnemyParticles JMNHMPGGKBE
{
get 		{
			return null;
		}

}

protected EnemyRangedWeaponBase IEPNCKPPHOB
{
get 		{
			return null;
		}

private set {
		}
}

public MDGCCBDJGBJ HealthBarSetting
{
get 		{
			return MDGCCBDJGBJ.DEFAULT;
		}

}

public Transform HealthBarRoot
{
get 		{
			return null;
		}

}

public Vector3 HealthBarOffset
{
get 		{
			return default;
		}

}

public float HealthBarScale
{
get 		{
			return 0f;
		}

}

public EnemyCollider[] Colliders
{
get 		{
			return null;
		}

private set {
		}
}

protected bool GHFFKMLCAHE
{
get 		{
			return false;
		}

set {
		}
}

public int InstantiatorPhotonViewId
{
get 		{
			return 0;
		}

private set {
		}
}

public Dictionary<string, object> InstantiationParameters
{
get 		{
			return null;
		}

private set {
		}
}

public KDBKBBGOBIP EnemyType
{
get 		{
			return KDBKBBGOBIP.QUEST_GOBLIN_BASIC_GROUND_MELEE;
		}

private set {
		}
}

public Vector3 SpawnTargetPosition
{
get 		{
			return default;
		}

private set {
		}
}

public Vector3 InstantiationPosition
{
get 		{
			return default;
		}

private set {
		}
}

public bool SpawnOnPatrol
{
get 		{
			return false;
		}

private set {
		}
}

public GIBEGHKMCIE Team
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
		}

private set {
		}
}

private float ENNPFAKGMIP
{
get 		{
			return 0f;
		}

set {
		}
}

private bool NIAOFNLNFEC
{
get 		{
			return false;
		}

set {
		}
}

public bool IsAlive
{
get 		{
			return false;
		}

private set {
		}
}

public int Health
{
get 		{
			return 0;
		}

set {
		}
}

public int MaxHealth
{
get 		{
			return 0;
		}

set {
		}
}

public JGNNBCGFCLN CurrentState
{
get 		{
			return JGNNBCGFCLN.INVALID;
		}

}

public ushort CurrentSubState
{
get 		{
			return 0;
		}

}

protected ushort IHAAMKKLKKI
{
get 		{
			return 0;
		}

set {
		}
}

protected ushort PKCPCKLKLIP
{
get 		{
			return 0;
		}

set {
		}
}

protected bool JMMDGJPMEIH
{
get 		{
			return false;
		}

}

public bool IsDoneSpawning
{
get 		{
			return false;
		}

}

private static int IHBDKGBKIAL
{
get 		{
			return 0;
		}

}

private int GACDAHHGOKO
{
get 		{
			return 0;
		}

set {
		}
}

protected bool ICADFNKLGIG
{
get 		{
			return false;
		}

}

protected bool KDMFOKHBMDK
{
get 		{
			return false;
		}

}

protected EnemyPatrol NANDGIBIPLK
{
get 		{
			return null;
		}

set {
		}
}

private int MGDBNCAHCDA
{
get 		{
			return 0;
		}

}

private Vector3 EPDCONLDGCG
{
get 		{
			return default;
		}

}

private bool BGBAJCPKEGE
{
get 		{
			return false;
		}

set {
		}
}

private bool KHPHKJHMIBH
{
get 		{
			return false;
		}

set {
		}
}

private bool MKLEBAJKDIG
{
get 		{
			return false;
		}

set {
		}
}

private bool PFBJMKDDIBP
{
get 		{
			return false;
		}

set {
		}
}

protected bool BKCHNJFOODM
{
get 		{
			return false;
		}

}

public bool IsStunned
{
get 		{
			return false;
		}

}

public bool IsAggrod
{
get 		{
			return false;
		}

}

public virtual bool CanAggroEnemies
{
get 		{
			return false;
		}

}

public virtual int CustomEncounterValue
{
get 		{
			return 0;
		}

}

public bool CanStartCombat
{
get 		{
			return false;
		}

}

public DPMOPDDAJBJ LastAttacker
{
get 		{
			return default;
		}

set {
		}
}

public Weapon LastAttackerWeapon
{
get 		{
			return null;
		}

set {
		}
}

private bool HEIPONBENCF
{
get 		{
			return false;
		}

set {
		}
}

protected bool MNKBFJHGHBC
{
get 		{
			return false;
		}

set {
		}
}

public DPMOPDDAJBJ Target
{
get 		{
			return default;
		}

set {
		}
}

private int OHFDBJBOHCJ
{
get 		{
			return 0;
		}

set {
		}
}

public MHOMBEOIIIG LineOfSightDirection
{
get 		{
			return MHOMBEOIIIG.OMNIDIRECTIONAL;
		}

set {
		}
}

public float LineOfSightDistance
{
get 		{
			return 0f;
		}

set {
		}
}

public float PatrolLineOfSightDistance
{
get 		{
			return 0f;
		}

}

public float LineOfSightVisionConeAngle
{
get 		{
			return 0f;
		}

set {
		}
}

public float LineOfSightImpactAlertRange
{
get 		{
			return 0f;
		}

set {
		}
}

public bool UsesVisionConeForTargeting
{
get 		{
			return false;
		}

}

public bool DefaultUsesVisionConeForTargeting
{
get 		{
			return false;
		}

}

protected bool FJOGFFDFOCD
{
get 		{
			return false;
		}

set {
		}
}

private Vector3 LDAOGFPOFDF
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 CenterPosition
{
get 		{
			return default;
		}

}

public float CenterRadius
{
get 		{
			return 0f;
		}

private set {
		}
}

protected Transform AGHPEFCLOHN
{
get 		{
			return null;
		}

}

public Vector3 HeadPosition
{
get 		{
			return default;
		}

}

public float PathingSpeedOverride
{
get 		{
			return 0f;
		}

set {
		}
}

public float MovementSpeed
{
get 		{
			return 0f;
		}

}

protected float IHOFEGBMIGI
{
get 		{
			return 0f;
		}

}

protected bool GMKCFGDLJFG
{
get 		{
			return false;
		}

set {
		}
}

public Transform ObjectSpawnOrigin
{
get 		{
			return null;
		}

}

public bool IsVisible
{
get 		{
			return false;
		}

}

protected bool NNGNALANPIO
{
get 		{
			return false;
		}

set {
		}
}

public bool IsHighLOD
{
get 		{
			return false;
		}

set {
		}
}

 int global::EHHJPOOBNFN.KDBKBBGOBIP
{
get 		{
			return 0;
		}

}

public event LAHBDMEFDJH CollisionEnterEvent {
add {
		}
remove {
		}
}

public event CFEAILHKDEA SpawnStartEvent {
add {
		}
remove {
		}
}

public event CFEAILHKDEA SpawnEndEvent {
add {
		}
remove {
		}
}

public event CFEAILHKDEA EnemyTransitionedFromSpawnState {
add {
		}
remove {
		}
}

public event CFEAILHKDEA DeathEvent {
add {
		}
remove {
		}
}

public event CFEAILHKDEA StunEndEvent {
add {
		}
remove {
		}
}

public event CFEAILHKDEA LODChangedEvent {
add {
		}
remove {
		}
}

public event CFEAILHKDEA PatrolCompletedEvent {
add {
		}
remove {
		}
}

public event CFEAILHKDEA PatrolCanceledEvent {
add {
		}
remove {
		}
}

public event CFEAILHKDEA PatrolToTargetCompletedEvent {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		private void KPIKNAOECLH()
		{
		}

		private void DILIGALEGLA()
		{
		}

		private void GKHMABDODNO()
		{
		}

		private void CBLKPLHPHIJ()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void DFKFFKNPGKK()
		{
		}

		protected virtual void Update()
		{
		}

		public virtual void LowLODUpdate()
		{
		}

		public void AuthoritySetPatrol(UGCAIPathPoint NDLANGNMPBF)
		{
		}

		public void AuthorityPatrolToPosition(Vector3 INLGLHIPOMC)
		{
		}

		protected void HAAHPGDHDLJ(float FNANPHJGABF)
		{
		}

		public static bool TrySampleNavMesh(Vector3 ONCLMGDKJDF, out Vector3 LJPJNJKIAHP, float FCIDHLIAHIO = -1f)
		{
			LJPJNJKIAHP = default;
			return false;
		}

		protected virtual void OJLPPOJMJJP()
		{
		}

		private void JIOKBMIDPPJ()
		{
		}

		public bool AuthorityTryApplyAttack(CHILKDJABBF FDOGMDABIGJ, Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		protected bool NDAHGPMEFHJ(Enemy KLILJMJEINK, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		protected virtual bool DGLIDHCLFDE(DPMOPDDAJBJ NJDHAACHDKF, Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		protected void FMMMINEGFFI(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK)
		{
		}

		public virtual void AuthorityOnDamageApplyForce(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 COPOILGLIAJ, Vector3 PDFEDMAOMNH)
		{
		}

		public virtual void AuthorityClearVelocity()
		{
		}

		public virtual void AuthorityOnDamageChangeVelocity(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK)
		{
		}

		public int GetPlayerAttackDamage(Player.NBPIPAJOGLC GMDBDJAOOGJ)
		{
			return 0;
		}

		protected void LLEFMBEGBAL(bool MAIKPLAINIB, float ANLEGLNKCHJ = 0f)
		{
		}

		protected void FALGPIEABJE(bool MAIKPLAINIB, float ANLEGLNKCHJ = 0f)
		{
		}

		protected void FPGDOHHFMFO(Vector3 INKGHPCDMCG, float ANLEGLNKCHJ = 0f)
		{
		}

		private void ENOMJLDOLGJ()
		{
		}

		protected virtual void CLPGJLCKBBC(DPMOPDDAJBJ NJDHAACHDKF, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, bool HGCNLFKJLHP, Vector3 EPGAOLNDLII, Vector3 OMGOEKPFJCM)
		{
		}

		protected virtual void EKCPKDDGHED(Enemy DPENEFKKNDN, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void MGKPHCBKLEN(Enemy DPENEFKKNDN, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void BCHPHNNIPMK(Enemy DPENEFKKNDN, Enemy NJDDIIEPJDM, BHHAHFFCKJO ALOJEPEGILE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void EAAFPNJINAP(MeleeWeaponCollider ADMCDJKKCIA, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void OMPDFOGEGPH(MeleeWeaponCollider ADMCDJKKCIA, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void EJJEBBEFLJG(EnemyRangedWeaponBase PLOGNHIJBNB, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void OABBJIOBHMH(EnemyRangedWeaponBase PLOGNHIJBNB, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void EECIEOMDMFL(EnemyRangedWeaponBase PLOGNHIJBNB, Enemy NJDDIIEPJDM, BHHAHFFCKJO ALOJEPEGILE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void FEAMHGGABOC(EnemyRangedWeaponBase PLOGNHIJBNB, float EJEMJEFJBNM)
		{
		}

		protected void ELEELIOLIPF(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, out bool DMDOLDIPIMF, out float OINDBKFOAPD)
		{
			DMDOLDIPIMF = default;
			OINDBKFOAPD = default;
		}

		public int GetDamageCombatSettings(int FDDPFMJOHLO, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK)
		{
			return 0;
		}

		protected float CCEFCPNEGDN(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK)
		{
			return 0f;
		}

		private CombatSettings MPOBDMAKIOP(DJBEHNDMJDL IKEDGLGPGEA)
		{
			return null;
		}

		protected void GBLGKJAHADG(EnemyRangedWeaponBase KBPKGKEMHED)
		{
		}

		private void OnTriggerEnter(Collider ADMCDJKKCIA)
		{
		}

		private void EIPCOAAHNIK(Killzone BIDNDOKMKKK)
		{
		}

		public virtual bool HasLineOfSight(Vector3 INKGHPCDMCG)
		{
			return false;
		}

		public bool HasStraightPathToTarget(DPMOPDDAJBJ GFCPAMJILIO, Vector3 JOLJPMNAOIK, Vector3 JAGAICCIBGF, float OHBOCNDPHFA, bool NDAPHBGKIGE = true)
		{
			return false;
		}

		private void OnCollisionEnter(Collision KDGCDLJEAMD)
		{
		}

		public static bool TryGetRaycastHitPoint(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, out float DAMOGGANOJL, out Vector3 EPGAOLNDLII, out Vector3 OMGOEKPFJCM)
		{
			DAMOGGANOJL = default;
			EPGAOLNDLII = default;
			OMGOEKPFJCM = default;
			return false;
		}

		public static bool TryGetRaycastHitPoint(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, out float DAMOGGANOJL, out Vector3 EPGAOLNDLII, out Vector3 OMGOEKPFJCM)
		{
			DAMOGGANOJL = default;
			EPGAOLNDLII = default;
			OMGOEKPFJCM = default;
			return false;
		}

		private Bounds GDHAFADBCOL()
		{
			return default;
		}

		private void HALDEIAGFAB(bool NHOCMNIMFLL)
		{
		}

		protected virtual void OAGMCCEBKPJ()
		{
		}

		private void PEJLPPOOGIO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BIJPOFCCMPF()
		{
		}

		private void MFIMIABEOBG(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual DPMOPDDAJBJ FFFECDFOEAE(bool GCIKGAMKGAE = false)
		{
			return default;
		}

		public void AddPreventAutoAggro(object IALNODEHBNN)
		{
		}

		public void RemovePreventAutoAggro(object IALNODEHBNN)
		{
		}

		protected bool LDJLFGLHHFH()
		{
			return false;
		}

		protected bool DLHKOGALPKE()
		{
			return false;
		}

		protected bool ILKGFJOPOMN(DPMOPDDAJBJ GFCPAMJILIO)
		{
			return false;
		}

		private void CIAGKHCOBLP(Weapon PLOGNHIJBNB, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
		{
		}

		private void HIMBHEKNECN(Tool IEGMBEPJMGC, Collision KDGCDLJEAMD)
		{
		}

		private void PHCPMAECFCN(Tool IEGMBEPJMGC, Vector3 OGEABPMOJJB)
		{
		}

		private void KILPMJBCJLI(DPMOPDDAJBJ NIHJGPHOHAJ, Tool FJEGOJJKOLD)
		{
		}

		private DPMOPDDAJBJ AGEFLBNGIJJ()
		{
			return default;
		}

		private bool JECPMPKAMMD(JGNNBCGFCLN DADHJJNJEFA)
		{
			return false;
		}

		protected virtual void EJMDHILBIGC(bool BDHANIHALBA)
		{
		}

		protected virtual void PNHOKAPCDOJ(bool BDHANIHALBA)
		{
		}

		private bool KEDGNBOFHAG()
		{
			return false;
		}

		private bool MLMBBLLOCIL()
		{
			return false;
		}

		private bool KEKGCBOBBDO()
		{
			return false;
		}

		public virtual void AuthorityStartPatrol()
		{
		}

		protected virtual void GJKKJGKFILO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected virtual void LKEKOJOGKDF()
		{
		}

		protected virtual void IMPLECFEACH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected void LPBDDGAJBMM()
		{
		}

		private void IPKMDEEMNBC()
		{
		}

		public void AuthorityStartCombat()
		{
		}

		protected virtual void NEJEMAPNLKG()
		{
		}

		protected virtual void OFHFJBCEGKG()
		{
		}

		private void OODADIBNFKP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ANLBMMBBIID()
		{
		}

		private void FKAAGOLOOKB(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual void DIJGDEJKMFB()
		{
		}

		protected virtual void CKEEPLIFHHJ()
		{
		}

		protected virtual void HMODBJBAIOM()
		{
		}

		private void IBJAFKOLFOK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void GKKJBLOKMEK()
		{
		}

		private void OFGBDCMGAPG(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void NDNAPPBBKLL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void MDNFMNMIEAF(float MGKNLEAPMJG)
		{
		}

		private void DALFPMLKLLG()
		{
		}

		private void FJPMDLCCEFN(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		public void MasterOnCustomEncounterEvent()
		{
		}

		protected virtual void PAMOPOINNCC()
		{
		}

		private void DBBCGCFLCOC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void LKAAEBGFADK()
		{
		}

		private void AKNKDPJJFFH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual void GGKGCGAEDOI()
		{
		}

		protected virtual void HDGAJEPCDAJ()
		{
		}

		private void MLHNGIIBCNM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void AGDBDJFFMBL()
		{
		}

		private void ANPOKPEOGCG(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		public void MasterDisengage()
		{
		}

		public void MasterReengage()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcAuthorityDisengage()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcAuthorityReengage()
		{
		}

		protected virtual void HGFHGLPELGH()
		{
		}

		protected virtual void EJJDMPGCBGF()
		{
		}

		protected virtual void CNECFKGNJLJ()
		{
		}

		private void HHLIMLPCECP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected void ALMHPOEBBJL()
		{
		}

		private void JOBBEPCGGON(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual void BHECKIKLDOK()
		{
		}

		private void DLFBNJFBLEH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CCNHONLCDKH()
		{
		}

		private void FBEADPDMAEJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected void DMHHEBEOHKN(Vector3 OIEPDFJCEHE, BHHAHFFCKJO GFHNJGJNNCK)
		{
		}

		private void JFPECGEBGHF(Vector3 KGIOBJMPLKI, BHHAHFFCKJO GFHNJGJNNCK)
		{
		}

		protected virtual void DLAIAOKPJOI()
		{
		}

		protected DPMOPDDAJBJ CILDLMDLLHK(bool GCIKGAMKGAE, bool IHHGIOAJILJ)
		{
			return default;
		}

		protected DPMOPDDAJBJ KNDHJIFKDOK(bool GCIKGAMKGAE, bool IHHGIOAJILJ)
		{
			return default;
		}

		protected Vector3 CCNPKNEPOMM()
		{
			return default;
		}

		protected void HDDDDKCHBMG(bool GCIKGAMKGAE, bool IHHGIOAJILJ, List<DPMOPDDAJBJ> BDMBNCLLPDA)
		{
		}

		protected void ACCMEFCFMCE(bool GCIKGAMKGAE, Vector3 CKPDACEBMHF, Vector3 CEGJMNNHCPL, Vector3 FDGAFEFHAFB, float GDIENBGMGIB, float GKJHODLJDHD, float HNBKFPCHOOC, bool NCHEFPKLNNN, bool IHHGIOAJILJ, List<DPMOPDDAJBJ> BDMBNCLLPDA)
		{
		}

		protected Vector3 DBKEDENKHLJ(bool NCHEFPKLNNN)
		{
			return default;
		}

		protected Vector3 MPFPEFPCOPL(Vector3 INLGLHIPOMC, bool NCHEFPKLNNN)
		{
			return default;
		}

		public void AuthoritySetLineOfSightParameters(MHOMBEOIIIG HBKAOEDJHLM, float DMOILOHGMLJ, float PLEEKPIMLLF, float JEHCNJNPPJE, bool BHNFNGGIPCA)
		{
		}

		protected Vector3 OGDIHCMNKHF(Vector3 INKGHPCDMCG, float FDKKKJKMKHH, float HDONKMNNGBM, float JKOCMGHEOKK)
		{
			return default;
		}

		private void HDICLAEBDEL(bool OMIEECFMGON)
		{
		}

		public static Enemy MasterSpawn(KDBKBBGOBIP KKBDEPBJBHJ, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OAIMPHPNBDO, bool HCLFHEHOHLL, EnemyPatrol JAMCBDMIOEI, GIBEGHKMCIE NEBNOBLPNEP, bool EMIEDCJNPDE, int PAECKOPBNFH, Dictionary<string, object> ENFEHHMJMLG)
		{
			return null;
		}

		public static void MasterKill(Enemy DPENEFKKNDN)
		{
		}

		public static void MasterDispose(Enemy DPENEFKKNDN)
		{
		}

		public static bool IsShield(BHHAHFFCKJO MBKGKPOBHBB)
		{
			return false;
		}

		public static bool IsCriticalHit(BHHAHFFCKJO MBKGKPOBHBB)
		{
			return false;
		}

		private void AJPCMKOKOAG()
		{
		}

		protected virtual bool IAJNLDKIODN()
		{
			return false;
		}

		private void PPEMJMANANE()
		{
		}

		private void ELFAAPPPDNI()
		{
		}

		public void RenderOutline(LMKFOACECEG IEMMIFODLAI)
		{
		}

		public virtual void TransferOwnership(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcOnTookDamage(DPMOPDDAJBJ NJDHAACHDKF, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, bool HGCNLFKJLHP, Vector3 EPGAOLNDLII, Vector3 OMGOEKPFJCM)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcShatter(Vector3 KGIOBJMPLKI, BHHAHFFCKJO OMNHIFFMOON)
		{
		}

		private void OnMasterClientSwitched(CHILKDJABBF GKNDJIKLPKK)
		{
		}
	}
}
