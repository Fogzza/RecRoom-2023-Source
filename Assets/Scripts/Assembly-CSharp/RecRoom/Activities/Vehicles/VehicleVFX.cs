using System;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleVFX : MonoBehaviour
	{
		[Serializable]
		private class CollisionVFXSpeedVersionConfig
		{
			public float triggerSpeedThreshold;

			public float particleOpacity;

			public float particleSize;
		}

		[Serializable]
		private class CollisionVFXConfig
		{
			public PooledParticle collisionParticlePrefab;

			public CollisionVFXSpeedVersionConfig slowVersionConfig;

			public CollisionVFXSpeedVersionConfig fastVersionConfig;
		}

		[SerializeField]
		private GroundVehicle vehicle;

		[SerializeField]
		private CollisionVFXConfig collisionDustConfig;

		[SerializeField]
		private CollisionVFXConfig collisionSparkConfig;

		[SerializeField]
		private float minCollisionVFXTriggerInterval;

		[SerializeField]
		private ParticleSystem vehicleExhaustSmokePrefab;

		[SerializeField]
		private float exhaustVFXTriggerRPMThreshold;

		[SerializeField]
		private PooledParticle vehicleBoostLinesPrefab;

		[SerializeField]
		private bool canBoostBeSeenOutsideOfVehicle;

		[SerializeField]
		private PooledParticle vehicleExteriorBoostPrefab;

		[SerializeField]
		private Transform vehicleBoostLinesTargetTransform;

		[SerializeField]
		private Transform vehicleExteriorBoostTargetTransform;

		private float EHMBHLDELDF;

		private PooledParticle KBBNHGKCAHD;

		private PooledParticle EGMEHHKKNED;

private bool PJMLFJLKMDG
{
get 		{
			return false;
		}

}

public int Priority
{
get 		{
			return 0;
		}

}

		private bool OJHMIDAAPCH(PooledParticle JDGDPMCGAHN)
		{
			return false;
		}

		public void PlayCollisionVFX(float MJPKOMEINCJ, Vector3 ELGLOEDDKAJ, bool GCLOMKGLGMA)
		{
		}

		public void PlayExhaustVFX(float LMHJBCNNOKB)
		{
		}

		public void OnLocalPlayerEnterCar()
		{
		}

		public void OnLocalPlayerLeaveCar()
		{
		}

		private bool KENHGEKOODF()
		{
			return false;
		}

		public void EnableBoostVfxIfNecessary(bool EKFJOBLMPFI)
		{
		}

		private void DEMJCHHOLFK()
		{
		}

		private void GNCJAHFNPDE()
		{
		}

		public void UpdateBoostVfxTransform()
		{
		}

		private void PGJIIHCCEEE()
		{
		}

		private void CFIHNFMELKE()
		{
		}

		public void DisableBoostVfxIfNecessary()
		{
		}

		private void HHEPBIBPDHG()
		{
		}

		private void CLINBLLENHC()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}
	}
}
