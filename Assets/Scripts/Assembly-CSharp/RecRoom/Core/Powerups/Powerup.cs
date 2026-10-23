using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Powerups
{
	public abstract class Powerup : MonoBehaviourPun
	{
		private enum IDMIMAACHNF
		{
			INSTANTIATOR_ID = 0,
			INSTANTIATION_PARAMS = 1,
			TARGET_PLAYER_ID = 2,
			POWERUP_TYPE = 3,
			VALUE_COUNT = 4
		}

		public delegate void OHPFBCDNKFK(FGBJLABIGCM OLGHMMBEFGK, CHILKDJABBF EKOFNPFCLMO);

		public delegate void MANBEIHABLI(Powerup EHHMLGPJGDB);

		public static global::BPEPJJDICII<FGBJLABIGCM, CHILKDJABBF> PowerupActivationRequestedEvent;

		public static global::HHOBPMOCKMJ<Powerup> PowerupInstantiatedEvent;

		public static global::HHOBPMOCKMJ<Powerup> PowerupDestroyedEvent;

		public static global::HHOBPMOCKMJ<Powerup> PowerupEffectsStartedEvent;

		[SerializeField]
		private string notificationText;

		[SerializeField]
		private float _lifeTime;

		[SerializeField]
		private bool _grantsInvicibility;

		[SerializeField]
		private float invincibilityBufferSeconds;

		[SerializeField]
		private RecRoomAudioClip musicClip;

		[SerializeField]
		private RecRoomAudioClip spawnSfx;

		[SerializeField]
		private PooledParticle spawnParticlePrefab;

		[SerializeField]
		private RecRoomAudioClip activeLoopSfx;

		[SerializeField]
		private PooledParticle activeParticlesPrefab;

		[SerializeField]
		private Texture _tonemappingLut;

		[SerializeField]
		private float _tonemappingFadeTime;

		[SerializeField]
		private RecRoomAudioClip destroyedSfx;

		[SerializeField]
		private PooledParticle destroyedParticlePrefab;

		[SerializeField]
		private RecRoomAudioClip impactSfx;

		[SerializeField]
		private ImpactDecal impactDecalPrefab;

		[SerializeField]
		private PooledParticle impactParticle;

		protected HONEDBECDOK FBPAJPEEHNP;

		protected SFXAudioSource MOILBKHBHKH;

		protected PooledParticle DGPNEBABJBP;

		private CHILKDJABBF FCCECPMKCON;

		private FGBJLABIGCM KEPJAEKMFIJ;

public float Lifetime
{
get 		{
			return 0f;
		}

}

public bool GrantsInvincibility
{
get 		{
			return false;
		}

}

public RecRoomAudioClip MusicClip
{
get 		{
			return null;
		}

}

public Texture TonemappingLut
{
get 		{
			return null;
		}

}

public float TonemappingFadeTime
{
get 		{
			return 0f;
		}

}

public CHILKDJABBF TargetPlayer
{
get 		{
			return null;
		}

private set {
		}
}

public FGBJLABIGCM Type
{
get 		{
			return FGBJLABIGCM.QUEST_DAMAGE;
		}

private set {
		}
}

public float InvincibilityDuration
{
get 		{
			return 0f;
		}

}

		public static void RequestPowerupActivation(FGBJLABIGCM OLGHMMBEFGK, CHILKDJABBF EKOFNPFCLMO)
		{
		}

		public static Powerup MasterSpawnPowerup(FGBJLABIGCM OLGHMMBEFGK, CHILKDJABBF EKOFNPFCLMO, int PAECKOPBNFH, Dictionary<string, object> ENFEHHMJMLG)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void MasterRestartTimer()
		{
		}

		private void NMAKPDCPBON()
		{
		}

		protected virtual void FDGKKLPILPD(Player BEMAFDJKONA)
		{
		}

		protected virtual void PEMAOIDKHLC(Player BEMAFDJKONA)
		{
		}

		protected virtual void NJEBCODLLNL()
		{
		}

		protected virtual void LBBAOIBBOED()
		{
		}

		protected PooledParticle DDDBIDAAHJJ(PooledParticle GDEKLMNKJBC, bool KNMILELNMFH)
		{
			return null;
		}

		private void IJBMKMAIIMD(Weapon PLOGNHIJBNB, Enemy INIEKKNFPDP, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
		{
		}

		private void HDAEEODMPCO(Weapon PLOGNHIJBNB, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
		{
		}

		protected virtual void JFILPFPPCAF(Weapon PLOGNHIJBNB, Enemy INIEKKNFPDP, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
		{
		}

		private void DFMKJBGFFKF()
		{
		}

		protected void OnMasterClientSwitched(CHILKDJABBF GKNDJIKLPKK)
		{
		}
	}
}
