using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.AI
{
	public class EnemyParticles : MonoBehaviour
	{
		[SerializeField]
		private PooledParticle defaultDamageParticles;

		[SerializeField]
		private PooledParticle onDamageParticles;

		[SerializeField]
		private PooledParticle onShieldedDamageParticles;

		[SerializeField]
		private PooledParticle onCriticalHitDamageParticles;

		[SerializeField]
		private float damageParticleZBias;

		[SerializeField]
		private PooledParticle defaultKillParticles;

		[SerializeField]
		private PooledParticle onKillParticles;

		[SerializeField]
		private PooledParticle onCriticalHitKillParticles;

		[SerializeField]
		private float killParticleZBias;

		[SerializeField]
		private PooledParticle onAlertParticles;

		[SerializeField]
		private PooledParticle onChargeParticles;

		[SerializeField]
		private PooledParticle onExplodeParticles;

		private PooledParticle DMBCEKKKJNP;

		private void OnDestroy()
		{
		}

		public void OnTakeDamage(BHHAHFFCKJO GFHNJGJNNCK, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB)
		{
		}

		public void OnKill(BHHAHFFCKJO GFHNJGJNNCK, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB)
		{
		}

		public void StartCharge(Transform FGNGGLFNLIP)
		{
		}

		public void StopCharge()
		{
		}

		public void OnExplode()
		{
		}

		public void OnAggro(Transform FGNGGLFNLIP, Vector3 MOHMCFDNHKH)
		{
		}
	}
}
