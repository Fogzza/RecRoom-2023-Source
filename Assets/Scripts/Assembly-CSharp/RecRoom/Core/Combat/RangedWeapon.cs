using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Core.AI;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Combat
{
	public abstract class RangedWeapon : Weapon
	{
		protected enum DADIOEMCKMA
		{
			SCREENS_ONLY = 0,
			ALWAYS = 1
		}

		public delegate void LFOCNJLPBHC(RangedWeapon NEDPKPJNEEC);

		[Serializable]
		protected struct ImpactForces
		{
			[SerializeField]
			private float minChargeImpactForce;

			[SerializeField]
			private float maxChargeImpactForce;

			public ImpactForces(float IFPPBNLHCCM, float LIODLDNGDIO)
			{
				minChargeImpactForce = 0f;
				maxChargeImpactForce = 0f;
			}

			public float CLOBMBABBDJ(float GFJAJFDJLDM)
			{
				return 0f;
			}
		}

		private sealed class BNGKMMIILNH : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RangedWeapon _003C_003E4__this;

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
			public BNGKMMIILNH(int _003C_003E1__state)
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

		protected byte LDDHHJKLPJP;

		[SerializeField]
		protected Bullet bulletPrefab;

		[SerializeField]
		protected float bulletFireSpeed;

		[SerializeField]
		protected ImpactForces bulletImpactForce;

		[SerializeField]
		protected float maximumFiringRate;

		[SerializeField]
		protected float maximumAutomaticFiringRate;

		[SerializeField]
		protected Color defaultProjectileColor;

		[SerializeField]
		protected bool overrideMuzzleFlashParticleStartColor;

		[SerializeField]
		protected PooledParticle muzzleFlashPrefab;

		[SerializeField]
		protected Transform muzzleFlashOrigin;

		[SerializeField]
		protected bool hasRecoilAnimation;

		[SerializeField]
		protected PulsingBeam pulsingBeam;

		[SerializeField]
		protected bool playHapticsOnFire;

		[SerializeField]
		protected Transform barrelTransform;

		[SerializeField]
		protected Transform rearSightTransform;

		[SerializeField]
		protected Transform frontSightTransform;

		[SerializeField]
		protected float sightAccuracyDistance;

		[SerializeField]
		protected BoxCollider worldOverlapCollider;

		[SerializeField]
		protected bool hasReloadEffect;

		[SerializeField]
		protected float reloadDelay;

		[SerializeField]
		protected bool hasOutOfAmmoFireAnimation;

		[SerializeField]
		private bool hasAmmunitionStateVisuals;

		[SerializeField]
		private GameObject hasAmmunitionRemainingVisualRoot;

		[SerializeField]
		private GameObject outOfAmmoVisualRoot;

		[SerializeField]
		private DADIOEMCKMA ignoreWielderCollisions;

		[NonSerialized]
		public bool HasOverriddenTargetPoint;

		[NonSerialized]
		public Vector3 OverrideTargetPoint;

		[NonSerialized]
		public bool CombatantHitBulletExpansionEnabled;

		[NonSerialized]
		public float CombatantHitBulletExpansionRadiusScale;

		protected static readonly int ADJNJAMOILF;

		protected static readonly int ELNDFEFCHNK;

		protected static readonly int KIOCLAPNFIK;

		protected static readonly int FHKJLPCIEPM;

		protected float KPLOLOBPAMO;

		private Coroutine CEEIIFCCCOE;

		private List<RigidbodyEx> DLPEEGJNHMN;

		private const float PPPJCPCKDJH = 0.66f;

		private const float MFBPFAFPFPO = 0.2f;

		private bool GFEJPEJGADG;

		public static global::HHOBPMOCKMJ<RangedWeapon> LocalPlayerFireStaticEvent;

		private LFOCNJLPBHC LEJOHJCDKFC__BackingField;

		public static global::HHOBPMOCKMJ<Bullet> LocalPlayerAcquiredBulletEvent;

		public static global::HHOBPMOCKMJ<PooledParticle> LocalPlayerAcquiredPooledParticleEvent;

		private static Collider[] IHPMCBEPPPC;

		private static bool DEABNHHIHAF;

public float MaximumFiringRate
{
get 		{
			return 0f;
		}

}

public float MaximumAutomaticFiringRate
{
get 		{
			return 0f;
		}

}

public bool IsOnCooldown
{
get 		{
			return false;
		}

}

public bool IsMisfire
{
get 		{
			return false;
		}

}

public Vector3 AimOrigin
{
get 		{
			return default;
		}

}

public Vector3 AimDirection
{
get 		{
			return default;
		}

}

public float TimeSinceLastFire
{
get 		{
			return 0f;
		}

}

protected override Color EGOOKBNKAEM
{
get 		{
			return default;
		}

}

public bool BlockFireAnimation
{
get 		{
			return false;
		}

set {
		}
}

public bool HasBulletDrop
{
get 		{
			return false;
		}

}

public event LFOCNJLPBHC LocalPlayerFireEvent {
add {
		}
remove {
		}
}

		public virtual bool IsAutomaticFireRunning()
		{
			return false;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void SetConfigurationData(BOJMNDBGLEA KEKEIBKNLKD)
		{
		}

		public virtual void Fire(float BHEFDILBFOI = 1f)
		{
		}

		public virtual void Fire(Vector3 OIEPDFJCEHE, float BHEFDILBFOI = 1f)
		{
		}

		protected virtual void MPNCIDCFDNM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, bool GHCPLAPAGHB, byte CMBCNFBLLNI)
		{
		}

		protected void AKDLPPEJBKD(Bullet HCLJODLNCNE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, byte CMBCNFBLLNI, float PDGCNICBLGN = -1f, bool FGFPPJJKHMN = false, Player EKMGJPMBLCP = null)
		{
		}

		protected virtual Bullet AKDLPPEJBKD(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, byte CMBCNFBLLNI, float PDGCNICBLGN = -1f, bool FGFPPJJKHMN = false, Player EKMGJPMBLCP = null, Bullet GDEKLMNKJBC = null)
		{
			return null;
		}

		protected void NMAPIHMAPEH()
		{
		}

		private bool FNPBIECFLDN(Collider GJKLNFFOHPF, Vector3 EPGAOLNDLII)
		{
			return false;
		}

		protected virtual Bullet LIPKDHINPGF(Bullet GDEKLMNKJBC = null)
		{
			return null;
		}

		private void COCACFLPOMO(Bullet HCLJODLNCNE)
		{
		}

		protected virtual void FCIODKAEJGF(Bullet HCLJODLNCNE, Vector3 INLGLHIPOMC)
		{
		}

		protected virtual void JCHOIPAFDFK(Bullet HCLJODLNCNE, Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void BHCDKFBLBMG(Bullet HCLJODLNCNE, Enemy DPENEFKKNDN, BHHAHFFCKJO MBKGKPOBHBB, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void LABCLALOAEL(Bullet HCLJODLNCNE, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void EOJKDNNLMMB(Bullet HCLJODLNCNE, Trap MBLENDJGFCI, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void LMCLMIPHONB(Bullet HCLJODLNCNE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void CJBDELDEJNN(Bullet HCLJODLNCNE, Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void MJCBEGKCCFK()
		{
		}

		private void ADCCHJFLEPJ()
		{
		}

		private IEnumerator LCJABOLOIDB()
		{
			return null;
		}

		public virtual void PlayPreFireAnimation()
		{
		}

		protected override void MEBNNOCJCOF()
		{
		}

		public override void TryPlayOutOfAmmoFeedback()
		{
		}

		public bool IsOverlappingObstruction()
		{
			return false;
		}

		public void AddMisfireIgnoredRigidbodyEx(RigidbodyEx EHHPLBPDKBE)
		{
		}

		public void RemoveMisfireIgnoredRigidbodyEx(RigidbodyEx EHHPLBPDKBE)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcFireShot(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, bool KNPOOEMHFKL, byte CMBCNFBLLNI)
		{
		}

		private void PDLDBGOKHNP(CHILKDJABBF EKMGJPMBLCP, CHILKDJABBF KJCCPIIFNGO, int AAEAKJPHADF, int FDDPFMJOHLO, in Vector3 OGENEKOENLC, in Vector3 OMGOEKPFJCM)
		{
		}
	}
}
