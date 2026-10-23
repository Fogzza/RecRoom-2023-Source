using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

public class Dartboard : MonoBehaviour
{
	public float bullseyeRadius;

	public float innerRadius;

	public float outerRadius;

	public PooledParticle HitParticleOuter;

	public PooledParticle HitParticleInner;

	public PooledParticle HitParticleBullseye;

	public RecRoomAudioClip HitAudio;

	private void OnTriggerEnter(Collider ADMCDJKKCIA)
	{
	}
}
