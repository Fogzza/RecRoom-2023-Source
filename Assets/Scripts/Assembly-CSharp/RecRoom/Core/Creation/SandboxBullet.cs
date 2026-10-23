using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class SandboxBullet : Bullet
	{
		[SerializeField]
		private WeaponAudio weaponAudio;

		[SerializeField]
		protected ImpactDecal impactDecalPrefab;

		[SerializeField]
		protected Vector2 minMaxImpactDecalScale;

		[SerializeField]
		protected float randomImpactSplatOffset;

		[SerializeField]
		protected PooledParticle impactParticlePrefab;

		[SerializeField]
		private string friendlyName;

public WeaponAudio WeaponAudio
{
get 		{
			return null;
		}

}

public ImpactDecal ImpactDecalPrefab
{
get 		{
			return null;
		}

}

public Vector2 MinMaxImpactDecalScale
{
get 		{
			return default;
		}

}

public float RandomImpactSplatOffset
{
get 		{
			return 0f;
		}

}

public PooledParticle ImpactParticlePrefab
{
get 		{
			return null;
		}

}

public string FriendlyName
{
get 		{
			return null;
		}

}
	}
}
