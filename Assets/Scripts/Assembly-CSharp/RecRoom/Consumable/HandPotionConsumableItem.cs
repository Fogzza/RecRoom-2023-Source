using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Consumable
{
	public class HandPotionConsumableItem : ConsumableItem
	{
		[SerializeField]
		protected PooledParticle particleEffectObject;

		[SerializeField]
		protected AudioClip onGestureAudio;

public PooledParticle ParticleEffectObject
{
get 		{
			return null;
		}

}

public AudioClip OnGestureAudio
{
get 		{
			return null;
		}

}
	}
}
