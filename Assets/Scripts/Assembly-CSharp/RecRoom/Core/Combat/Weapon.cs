using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.AI;
using RecRoom.Core.Creation;
using RecRoom.Core.Pools;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Combat
{
	public abstract class Weapon : MonoBehaviourPun, HECDIPMDFHB, NEKJJEGPHFG
	{
		public delegate void EOBKKOEBIFA(Weapon PLOGNHIJBNB, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD);

		public delegate void OLINGELMBHE(Weapon PLOGNHIJBNB, Enemy INIEKKNFPDP, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD);

		public delegate void NNPOEMADDFJ(Weapon PLOGNHIJBNB, Player INIEKKNFPDP, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD);

		public delegate void PHDMBGAOGJM(Weapon PLOGNHIJBNB, Tool INIEKKNFPDP, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD);

		public delegate void HMEGAEGHJCL(Player KJCCPIIFNGO);

		public delegate void ALIDDHNGMOK(int IKHNIJKGJFD, float IPMIIEAGJKC);

		public delegate void EKMELGCNEOM(int IKHNIJKGJFD);

		public delegate void BDFDGDABAFN(int IKHNIJKGJFD, bool IPMIIEAGJKC);

		public delegate int GMFBBAHGNAG(Weapon NEDPKPJNEEC);

		public delegate void JCFEHEBAPCB(Weapon NEDPKPJNEEC, int CPGMKGHBPLO);

		[Serializable]
		protected struct PlayerDamageSetting
		{
			public Player.NBPIPAJOGLC BodyPart;

			public int Damage;
		}

		[Serializable]
		protected struct EnemyDamageSettings
		{
			[SerializeField]
			private int MinDamage;

			[SerializeField]
			private int MaxDamage;

			public int IOAOPBENJLK(float FKDIODIJMDJ)
			{
				return 0;
			}
		}

		private sealed class CNGEHPMAHOO : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Weapon _003C_003E4__this;

			private float _003CdisarmTime_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public CNGEHPMAHOO(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class OFCNKFLLPPD : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Weapon _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public OFCNKFLLPPD(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private Trap trap;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private TeamColorRenderer _teamColor;

		[SerializeField]
		private WeaponAudio _weaponAudio;

		[SerializeField]
		private ControlPanelCircuitObject _controlPanelCircuitObject;

		[SerializeField]
		protected CreationObject creationObject;

		[SerializeField]
		private DJBEHNDMJDL damageType;

		[SerializeField]
		private DJBEHNDMJDL secondaryDamageType;

		[SerializeField]
		protected PlayerDamageSetting[] playerDamageSettings;

		[SerializeField]
		private bool canDamagePlayersViaHeldTool;

		[SerializeField]
		private bool canBlockWeaponAttacks;

		[SerializeField]
		private EnemyDamageSettings enemyDamageSettings;

		[SerializeField]
		private EnemyDamageSettings secondaryEnemyDamageSettings;

		[SerializeField]
		protected bool canApplyCriticalHits;

		[SerializeField]
		protected bool canTriggerExplosives;

		[SerializeField]
		protected bool _canSuicide;

		[SerializeField]
		protected int maxSelfDamage;

		[SerializeField]
		protected bool supportsAmmunition;

		[SerializeField]
		protected bool supportsAmmunitionAnimation;

		[SerializeField]
		protected int ammunitionMagazineSize;

		[SerializeField]
		protected int defaultMagazineAmmunition;

		[SerializeField]
		protected bool automaticallyReloadMagazine;

		[SerializeField]
		protected bool disableAmmunitionWhenInfiniteAmmoActive;

		[SerializeField]
		protected bool hasInfiniteReserveAmmunition;

		[SerializeField]
		protected int maximumTotalAmmunition;

		[SerializeField]
		protected bool disarmOnTotalAmmunitionExhaustion;

		[SerializeField]
		protected bool disablePostTotalAmmunitionExhaustion;

		[SerializeField]
		protected ImpactDecal impactDecalPrefab;

		[SerializeField]
		protected Vector2 minMaxImpactDecalScale;

		[SerializeField]
		protected float randomImpactSplatOffset;

		[SerializeField]
		private WeaponDetailQualityLevel targetMinimumDetailQuality;

		[SerializeField]
		protected bool overrideParticleStartColor;

		[SerializeField]
		protected PooledParticle impactParticlePrefab;

		[SerializeField]
		private string customPlayerKilledNotification;

		[SerializeField]
		private string customKilledByPlayerNotification;

		[SerializeField]
		protected PooledParticle secondaryDamageParticlePrefab;

		private const int LFNPPHPACGE = 3;

		public const float OUT_OF_AMMO_DISARM_DELAY = 0.25f;

		private const float DEPCFHOOJAG = 4f;

		private const float CJMPLBGFAIE = 0.2f;

		private const float NCHNLFCJMCC = 0.2f;

		private const float AHNKIOIHBAO = 1.5f;

		private const float AAHOOOPEDEC = 3f;

		private static readonly string LHGIJGFCNJI;

		protected const float LPNBIPKIKGI = 1f;

		private Action CFAOPBOHBKA__BackingField;

		public static global::CBEFDECGNBJ<Weapon, NGLCDIDOEMK, bool> PostImpactEventStatic;

		public static global::KAJFMPHPBGO<Weapon, Enemy, NGLCDIDOEMK, bool> EnemyImpactEventStatic;

		private Action CNKKKMEGANN__BackingField;

		private NNPOEMADDFJ NNGIDPFDOOJ__BackingField;

		private PHDMBGAOGJM EMPOCDCIGAL__BackingField;

		private OLINGELMBHE PGHPEMJPIPD__BackingField;

		private EOBKKOEBIFA KEFHKOAMBJD__BackingField;

		private EOBKKOEBIFA HHIBLHPJIMG__BackingField;

		private HMEGAEGHJCL JGACDLIIJGJ__BackingField;

		private ALIDDHNGMOK HAOGNLMJCFH__BackingField;

		private EKMELGCNEOM EIEKMEGICBL__BackingField;

		private BDFDGDABAFN PBDBAAGOFAA__BackingField;

		private Action GOFNMJJIBGN__BackingField;

		private Action<Vector3> HGJLBDOPMGG__BackingField;

		public GMFBBAHGNAG CustomGetReserveAmmoBehavior;

		public JCFEHEBAPCB CustomSetReserveAmmoBehavior;

		private static FIHGBEHGLGB KDHCJOOJEEB;

		protected static readonly int HACKDJLKMNB;

		protected static readonly int JJGCICLDHFM;

		private bool PLDKCCGJLFP;

		private bool BOFEGEHBJEF;

		private bool ELLEGBOIPKB;

		protected readonly List<Collider> FBDHMGAAHNP;

		private float[] CMCMKMIJDGD;

		private GameManager KPCADKBOAFA;

		private global::MOBDJNEDDKC<int> AHPDHEACDIK;

		private global::MDAHOKBAGPC<int, int, float> JEBLGMNAHFJ;

		private bool LEJLMLAHBDD;

		private int EEGNAADDPHE;

		private Coroutine BLCEMOEGNNF;

		private Coroutine BKMBDLHPEGJ;

		private JNKNMMDAHCF DHCLACKALOF;

		private IRecRoomQualityConfigProvider DABJFKPDEIL;

		private DPMOPDDAJBJ NFKDNMABAAP;

		private bool FANFJBJMFDJ;

		private int CGGDMAEOADN;

public Tool Tool
{
get 		{
			return null;
		}

}

protected Trap BCPNBEECJIE
{
get 		{
			return null;
		}

}

protected Animator CIOPHAMGMHB
{
get 		{
			return null;
		}

}

public TeamColorRenderer TeamColor
{
get 		{
			return null;
		}

}

protected virtual WeaponAudio LICEBFGMMBB
{
get 		{
			return null;
		}

}

protected ControlPanelCircuitObject GJNNFDHGJMP
{
get 		{
			return null;
		}

}

protected static bool GPEMDCEOPHA
{
get 		{
			return false;
		}

}

private bool PEBILHMOKIG
{
get 		{
			return false;
		}

set {
		}
}

public bool IsReloading
{
get 		{
			return false;
		}

set {
		}
}

public bool CanSuicide
{
get 		{
			return false;
		}

}

public bool CanDamagePlayersViaHeldTool
{
get 		{
			return false;
		}

}

public bool CanBlockWeaponAttacks
{
get 		{
			return false;
		}

}

public bool DefenderHasDamageAuthority
{
get 		{
			return false;
		}

set {
		}
}

protected abstract Color EGOOKBNKAEM
{
get ;
}

protected virtual int NIGBCNOPLKD
{
get 		{
			return 0;
		}

}

public DPMOPDDAJBJ Wielder
{
get 		{
			return default;
		}

set {
		}
}

public virtual DJBEHNDMJDL DamageType
{
get 		{
			return DJBEHNDMJDL.DEFAULT;
		}

}

public DJBEHNDMJDL SecondaryDamageType
{
get 		{
			return DJBEHNDMJDL.DEFAULT;
		}

}

public int MagazineAmmunition
{
get 		{
			return 0;
		}

}

public int AmmunitionMagazineSize
{
get 		{
			return 0;
		}

}

public int ReserveAmmunition
{
get 		{
			return 0;
		}

}

public float LastAmmunitionChangeTime
{
get 		{
			return 0f;
		}

}

public int TotalAmmunition
{
get 		{
			return 0;
		}

}

public float TotalAmmunitionNormalized
{
get 		{
			return 0f;
		}

}

public float MagazineAmmunitionNormalized
{
get 		{
			return 0f;
		}

}

public bool SupportsManualReload
{
get 		{
			return false;
		}

}

public bool HasEnoughMagazineAmmunition
{
get 		{
			return false;
		}

}

public bool IsAmmoTotallyExhausted
{
get 		{
			return false;
		}

}

public bool AmmunitionSupported
{
get 		{
			return false;
		}

}

public bool HasInfiniteReserveAmmunition
{
get 		{
			return false;
		}

}

public ImpactDecal ImpactDecal
{
get 		{
			return null;
		}

set {
		}
}

public PooledParticle ImpactParticles
{
get 		{
			return null;
		}

set {
		}
}

public bool IsShield
{
get 		{
			return false;
		}

}

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
		}

}

 CHILKDJABBF global::HECDIPMDFHB.owner
{
get 		{
			return null;
		}

}

 bool global::HECDIPMDFHB.hasAuthority
{
get 		{
			return false;
		}

}

public event Action ToolPostAwakeEvent {
add {
		}
remove {
		}
}

public event Action AmmunitionChangeEvent {
add {
		}
remove {
		}
}

public event NNPOEMADDFJ PlayerImpactEvent {
add {
		}
remove {
		}
}

public event PHDMBGAOGJM PlayerToolImpactEvent {
add {
		}
remove {
		}
}

public event OLINGELMBHE EnemyImpactEvent {
add {
		}
remove {
		}
}

public event EOBKKOEBIFA OtherImpactEvent {
add {
		}
remove {
		}
}

public event EOBKKOEBIFA PostImpactEvent {
add {
		}
remove {
		}
}

public event HMEGAEGHJCL DealtPlayerOnPlayerDamageEvent {
add {
		}
remove {
		}
}

public event ALIDDHNGMOK FloatAnimatorEvent {
add {
		}
remove {
		}
}

public event EKMELGCNEOM TriggerAnimatorEvent {
add {
		}
remove {
		}
}

public event BDFDGDABAFN BoolAnimatorEvent {
add {
		}
remove {
		}
}

public event Action OnReloadNotificationPlayed {
add {
		}
remove {
		}
}

public event Action<Vector3> BlockAttackEvent {
add {
		}
remove {
		}
}

		public static void AddGlobalInfiniteAmmoSupport(object IALNODEHBNN)
		{
		}

		public static void RemoveGlobalInfiniteAmmoSupport(object IALNODEHBNN)
		{
		}

		protected override void Awake()
		{
		}

		private void KDELGLNBFAF(GHCCKFEJDOA ICHBECDKHOJ)
		{
		}

		private void BHKNIMDIJPO(Tool IEGMBEPJMGC)
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void KMBKIAODIFA(Tool IEGMBEPJMGC)
		{
		}

		private void GOLBHAGLOEP(Tool IEGMBEPJMGC)
		{
		}

		protected virtual void NHJOPMPGEFM(RigidbodyEx FDPNBMFPHHJ)
		{
		}

		public virtual void AddImpactIgnoredColliders(IEnumerable<Collider> ADMCDJKKCIA)
		{
		}

		public virtual void RemoveImpactIgnoredColliders(IEnumerable<Collider> ADMCDJKKCIA)
		{
		}

		public virtual void AddImpactIgnoredCollider(Collider ADMCDJKKCIA)
		{
		}

		public virtual void RemoveImpactIgnoredCollider(Collider ADMCDJKKCIA)
		{
		}

		public void OnBlockAttack(Vector3 INLGLHIPOMC)
		{
		}

		public void RaisePostImpactEvent(NGLCDIDOEMK BNFNJFKJEOA, bool OKANEJFAGIJ)
		{
		}

		public virtual int GetPlayerImpactDamage(Player.NBPIPAJOGLC AAEAKJPHADF, float ONDJPLPDHEC, bool DLFEBMLOBAM)
		{
			return 0;
		}

		protected virtual void MGKPHCBKLEN(Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		public virtual void NotifyWeaponDealtPlayerOnPlayerDamage(Player KJCCPIIFNGO)
		{
		}

		public virtual int GetEnemyDamage(float BHEFDILBFOI = 0f)
		{
			return 0;
		}

		protected virtual bool BCHPHNNIPMK(Enemy DPENEFKKNDN, BHHAHFFCKJO MBKGKPOBHBB, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		public void RaiseEnemyImpactEvent(Enemy NJDDIIEPJDM, BHHAHFFCKJO EKJJODPHDJK, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
		{
		}

		protected virtual void LPPBNHDIHAE(Enemy DPENEFKKNDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void HIMBHEKNECN(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void FJDHLLOOIKA(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected bool LNKNAJGMLPN(Tool LMEKFBDFCDN)
		{
			return false;
		}

		protected virtual void AJEBBOBCEED(Trap MBLENDJGFCI, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void EIHGAODGHHI(Weapon OMLENACDLFH, Weapon PANFKBPMCFI)
		{
		}

		protected virtual void BMFONHPBFAN(Player ACNLJOAAJMA, Weapon PANFKBPMCFI)
		{
		}

		protected virtual void AMCJOFBMFOG(NGLCDIDOEMK BNFNJFKJEOA, bool OKANEJFAGIJ = true)
		{
		}

		private void OGLMNNOFPLM()
		{
		}

		protected virtual void AOMPLKNJDAI()
		{
		}

		private void FGHKGAMLNIM(Player EKOFNPFCLMO)
		{
		}

		public Player GetPlayerOwner()
		{
			return null;
		}

		protected virtual void PLLGKABPABI(Tool PMEFICGEDFK, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		public void ReloadAmmunition()
		{
		}

		protected void EGJAMCNOKOI()
		{
		}

		protected void DKMIAENAPNH()
		{
		}

		public void ForceAmmunitionValuesOnSpawn(int FPLAOMCPGGE, int NJBMNPKEEDM)
		{
		}

		protected void ADMJNCPMCHE(int FPLAOMCPGGE, int NJBMNPKEEDM)
		{
		}

		protected virtual void MEBNNOCJCOF()
		{
		}

		protected void PKLJBOAHOAF()
		{
		}

		protected void PKLJBOAHOAF(bool AKMEJEGCLCC)
		{
		}

		private void LHKJDOIANBP()
		{
		}

		private bool HNBDBIFBMEC(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private bool LENHOOIGDPD(Tool PMEFICGEDFK, Player DHPGNFBDHKH, CHNLCOIEBMH JMEEAMAPEDC)
		{
			return false;
		}

		public virtual void TryPlayOutOfAmmoFeedback()
		{
		}

		protected void NDPLKHJBLOH()
		{
		}

		private void FOIOMLLMJLC()
		{
		}

		private void KLDKIBIGKAF()
		{
		}

		private IEnumerator MKAHEJPNABD()
		{
			return null;
		}

		private void HMCGAJFPFNL()
		{
		}

		private void JBOHILOEDIO()
		{
		}

		protected virtual bool HPCBPBCFNPM()
		{
			return false;
		}

		private IEnumerator GODOMMEJONI()
		{
			return null;
		}

		protected virtual void MHNKPOFIPLK(NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void MHNKPOFIPLK(NGLCDIDOEMK BNFNJFKJEOA, Vector2 BDKNNBIHGCJ)
		{
		}

		protected void MHNKPOFIPLK(ImpactDecal KADDHGOKNJL, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void MHNKPOFIPLK(ImpactDecal KADDHGOKNJL, NGLCDIDOEMK BNFNJFKJEOA, Vector2 BDKNNBIHGCJ)
		{
		}

		protected void MHNKPOFIPLK(ImpactDecal KADDHGOKNJL, Vector3 INLGLHIPOMC, Vector3 CHEKLLFMKBP, GameObject INIKJPPBMBP)
		{
		}

		protected virtual bool JEBDCFKGFIK(GameObject DMGMDFOGEDM, ImpactDecal GDEKLMNKJBC)
		{
			return false;
		}

		protected PooledParticle DDDBIDAAHJJ(PooledParticle GLEIJHOELIP, Vector3 INLGLHIPOMC, bool AIJDMBNCMLG = false, float FKLJAEGFEDK = 1f)
		{
			return null;
		}

		protected void LEEJPHLMNLN(NGLCDIDOEMK BNFNJFKJEOA, PooledParticle GDEKLMNKJBC = null)
		{
		}

		public void SetAnimationBool(int IKHNIJKGJFD, bool IPMIIEAGJKC)
		{
		}

		public void SetAnimationFloat(int IKHNIJKGJFD, float IPMIIEAGJKC)
		{
		}

		public void SetAnimationTrigger(int IKHNIJKGJFD)
		{
		}

		public string GetCustomPlayerKillNotification(CHILKDJABBF NLGCGEFCFNA)
		{
			return null;
		}

		public string GetCustomKilledByPlayerNotification(CHILKDJABBF CFKFMJPPCAJ)
		{
			return null;
		}

		public virtual bool ImpactAlreadyRegistered(byte GIHGJIFCHMK, CHILKDJABBF INIEKKNFPDP)
		{
			return false;
		}
	}
}
