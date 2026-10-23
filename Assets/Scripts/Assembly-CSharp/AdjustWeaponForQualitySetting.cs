using System;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AdjustWeaponForQualitySetting : MonoBehaviour
{
	[Serializable]
	public struct WeaponSettings
	{
		public WeaponDetailQualityLevel WeaponDetailQuality;

		public ImpactDecal ImpactDecalOverride;

		public PooledParticle ImpactParticleOverride;
	}

	[SerializeField]
	private WeaponSettings[] overrideSettings;

	[SerializeField]
	private Weapon weapon;

	private WeaponSettings PKMJGIEDJPO;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void KDELGLNBFAF(GHCCKFEJDOA OINNDPBJCNN)
	{
	}

	private void GMFODDHKMID()
	{
	}
}
