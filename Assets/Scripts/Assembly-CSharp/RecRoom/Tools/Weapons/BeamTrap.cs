using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class BeamTrap : Trap
	{
		[SerializeField]
		private Transform origin;

		[SerializeField]
		private Transform beam;

		[SerializeField]
		private PooledParticle impactParticlePrefab;

		private PooledParticle BCFIDLEJLMG;

		[SerializeField]
		private PooledParticle emberParticlePrefab;

		private PooledParticle CKGLNJPBEFG;

		[SerializeField]
		private float beamLength;

		[SerializeField]
		private float beamWidth;

		[SerializeField]
		private float beamExtendLerpSpeed;

		public AnimationCurve BeamWidthNoise;

		public RecRoomAudioClip FireLoop;

		public RecRoomAudioClip ImpactSFX;

		private SFXAudioSource HGAOBLNKDAE;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
