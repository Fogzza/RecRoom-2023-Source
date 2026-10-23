using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.AI
{
	public abstract class EnemyRangedWeaponBase : MonoBehaviourPun
	{
		private enum GOFLFGACDFH
		{
			SINGLE_SHOT = 0,
			BURST = 1
		}

		public delegate void LJKKKEFNFPD(EnemyRangedWeaponBase NEDPKPJNEEC, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void MMPPDKFNNOO(EnemyRangedWeaponBase NEDPKPJNEEC, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void OEOIAFDLMCF(EnemyRangedWeaponBase NEDPKPJNEEC, Enemy NJDDIIEPJDM, BHHAHFFCKJO EKJJODPHDJK, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void NDKMBHJKHJC(EnemyRangedWeaponBase NEDPKPJNEEC, float FHFDDKOBFLG);

		[Serializable]
		private struct ShotSettings
		{
			public float HitChance;
		}

		[Serializable]
		private struct MuzzleFlashParticleSettings
		{
			public PooledParticle Particles;

			public Transform Transform;
		}

		private sealed class CAHHDNIJPJL : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EnemyRangedWeaponBase _003C_003E4__this;

			public float desiredSpeed;

			public Vector3 targetPoint;

			public DPMOPDDAJBJ enemyTarget;

			public Vector3[] targetOffsets;

			public float shotDelay;

			private float _003CactualSpeed_003E5__2;

			private int _003Ci_003E5__3;

			private Vector3 _003Ctarget_003E5__4;

			private float _003CdelayEndTime_003E5__5;

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
			public CAHHDNIJPJL(int _003C_003E1__state)
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
		private float validShotVisionConeDegrees;

		[SerializeField]
		private ShotSettings[] shotSettings;

		[SerializeField]
		private float timeBetweenBurstShots;

		[SerializeField]
		private bool movingTargetExtrapolationEnabled;

		[SerializeField]
		protected Transform projectileOriginTransform;

		[SerializeField]
		private Vector3 targetOffset;

		[SerializeField]
		protected float minimumFireHitDistance;

		[SerializeField]
		protected float maximumFireHitDistance;

		[SerializeField]
		protected float minimumFireMissDistance;

		[SerializeField]
		protected float maximumFireMissDistance;

		[SerializeField]
		protected float minimumFireOffsetRotationAngle;

		[SerializeField]
		protected float maximumFireOffsetRotationAngle;

		[SerializeField]
		private RecRoomAudioClip preFireAudio;

		[SerializeField]
		private PooledParticle muzzleFlashParticlesPrefab;

		[SerializeField]
		private ParticleQualityLevel targetMinimumParticleQuality;

		[SerializeField]
		private MuzzleFlashParticleSettings[] additionalMuzzleFlashParticles;

		[SerializeField]
		private RecRoomAudioClip[] fireAudio;

		[SerializeField]
		protected ImpactDecal projectileImpactDecalPrefab;

		[SerializeField]
		protected PooledParticle projectileImpactParticlesPrefab;

		[SerializeField]
		protected RecRoomAudioClip projectileImpactAudio;

		[SerializeField]
		private WeaponDetailQualityLevel targetMinimumWeaponQuality;

		private JNKNMMDAHCF NLLMOKKOFBI;

		private LJKKKEFNFPD LGODEIKJEJL__BackingField;

		private MMPPDKFNNOO COOMFAKNCHD__BackingField;

		private OEOIAFDLMCF GDKJNOOKNII__BackingField;

		private NDKMBHJKHJC GJINIHDHNHH__BackingField;

		[SerializeField]
		protected Enemy thisEnemy;

		protected EnemyTeamColor JELIDBAOGFK;

		protected readonly List<Collider> GEEGNLOGPDI;

		private Vector3[] JPALJLEJDLG;

		private Coroutine MMABBLDMLGI;

		private IRecRoomQualityConfigProvider DABJFKPDEIL;

public Transform ProjectileOriginTransform
{
get 		{
			return null;
		}

}

public float TotalShotDuration
{
get 		{
			return 0f;
		}

}

protected JNKNMMDAHCF BLCBBOHOOGI
{
get 		{
			return null;
		}

private set {
		}
}

public event LJKKKEFNFPD PlayerHitEvent {
add {
		}
remove {
		}
}

public event MMPPDKFNNOO PlayerToolHitEvent {
add {
		}
remove {
		}
}

public event OEOIAFDLMCF EnemyHitEvent {
add {
		}
remove {
		}
}

public event NDKMBHJKHJC LocalPreFireEvent {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void BCCDNECELAD(GHCCKFEJDOA ICHBECDKHOJ)
		{
		}

		public void AddIgnoredColliders(Collider[] GHKNKHCKPII)
		{
		}

		public void RemoveIgnoredColliders(Collider[] GHKNKHCKPII)
		{
		}

		public void AuthorityFire(Vector3 GFCPAMJILIO, float JEFDIJMDBOF = -1f, float EJEMJEFJBNM = 0f)
		{
		}

		public void AuthorityFire(DPMOPDDAJBJ GFCPAMJILIO, float JEFDIJMDBOF = -1f, float EJEMJEFJBNM = 0f)
		{
		}

		public void StopFiring()
		{
		}

		private void KNNEBLGAHLB(Vector3 ANOPICLGBNG)
		{
		}

		private bool FCOHPNNDLGD(Vector3 GFCPAMJILIO)
		{
			return false;
		}

		protected virtual Vector3 AOOOCNDOLKO(Vector3 ANOPICLGBNG, float HBBMPIGGNPI)
		{
			return default;
		}

		private void EOJAHMBKFHG(DPMOPDDAJBJ NLNEGCMOHGJ, Vector3 OAMILMKJELF, Vector3[] GEDIBPENEHN, float JEFDIJMDBOF, float EJEMJEFJBNM)
		{
		}

		protected abstract float JNGEHFIOODP(float JEFDIJMDBOF);

		protected abstract void HDMBFJDNMEM(Vector3 GFCPAMJILIO, float JEFDIJMDBOF);

		private void PLIBEKLJCKL(DPMOPDDAJBJ NLNEGCMOHGJ, Vector3 OAMILMKJELF, Vector3[] GEDIBPENEHN, float JEFDIJMDBOF, float EJEMJEFJBNM)
		{
		}

		private void EPBEHJIJIMI()
		{
		}

		private IEnumerator FACIPJGNLGI(DPMOPDDAJBJ NLNEGCMOHGJ, Vector3 OAMILMKJELF, Vector3[] GEDIBPENEHN, float JEFDIJMDBOF, float EJEMJEFJBNM)
		{
			return null;
		}

		protected void PFHCKKIBBAD(Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void KBLIPNOHPFN(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void BADNPOJDELK(Enemy NJDDIIEPJDM, BHHAHFFCKJO ALOJEPEGILE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void OGHPKAFGJHG(float EJEMJEFJBNM)
		{
		}

		protected void FIHNOCCPLNJ(Vector3 GFCPAMJILIO)
		{
		}

		protected void DDDBIDAAHJJ(PooledParticle OCOHPFEKKDF, Vector3 PDFEDMAOMNH, Vector3 CHEKLLFMKBP)
		{
		}

		protected void DDDBIDAAHJJ(PooledParticle OCOHPFEKKDF, Vector3 PDFEDMAOMNH, Quaternion HEGBBJCMANH)
		{
		}

		protected void DGDNHFAIDBD(ImpactDecal DJEALLJHFPD, Color HMCAFGCGFJF, Vector3 PDFEDMAOMNH, Vector3 GJOCEGMFHMC, GameObject MHMONCPAJIP)
		{
		}

		protected bool MLAFMLHPMKK()
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcOnFire(DPMOPDDAJBJ NLNEGCMOHGJ, Vector3 OAMILMKJELF, Vector3[] GEDIBPENEHN, float JEFDIJMDBOF, float EJEMJEFJBNM)
		{
		}
	}
}
