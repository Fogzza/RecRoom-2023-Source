using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class BeamGun : AutomaticGun
	{
		private sealed class GOGMEJNCBDB : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BeamGun _003C_003E4__this;

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
			public GOGMEJNCBDB(int _003C_003E1__state)
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

		private static int IDPJKPDIJKA;

		[SerializeField]
		private Transform beam;

		private Material AEEKLHIKNMK;

		private Renderer BPKGAPJPINE;

		[SerializeField]
		private PooledParticle chargeParticlePrefab;

		private PooledParticle MPNJJDDFIJE;

		private ParticleSystem.EmissionModule FAEEGDDOPMB;

		[SerializeField]
		private PooledParticle muzzleFlashParticlePrefab;

		private PooledParticle BPEAGKAAIKM;

		[SerializeField]
		private PooledParticle emberParticlePrefab;

		private PooledParticle CKGLNJPBEFG;

		[SerializeField]
		private float chargeActivationTime;

		[SerializeField]
		private int emberFinishedBurst;

		[SerializeField]
		protected float beamLength;

		[SerializeField]
		private float beamWidth;

		[SerializeField]
		private float beamExtendLerpSpeed;

		public AnimationCurve BeamWidthByCharge;

		public AnimationCurve BeamLengthByCharge;

		public AnimationCurve BeamOpacityByCharge;

		public AnimationCurve BeamWidthNoise;

		public RecRoomAudioClip SpinUp;

		public RecRoomAudioClip SpinUpCancel;

		public RecRoomAudioClip FireInitialize;

		public RecRoomAudioClip FireLoop;

		public RecRoomAudioClip FireFinished;

		[SerializeField]
		private MeshRenderer AmmoEmmissiveRampRenderer;

		private Material EPMEAIBELNF;

		[SerializeField]
		private TeamColorRenderer teamColorRenderer;

		private SFXAudioSource HGAOBLNKDAE;

		private SFXAudioSource HKCHBPOKALJ;

		private global::MOBDJNEDDKC<float> DKEJCILEAJI;

		private Coroutine BKIMNCBIAED;

		protected bool FPJEAJNNJCI;

		protected bool PJDCIKFFNIC;

public float ChargePercentage
{
get 		{
			return 0f;
		}

}

protected float PABFKBMLEOD
{
get 		{
			return 0f;
		}

set {
		}
}

public bool isBeamActive
{
get 		{
			return false;
		}

}

protected bool AOAGJKAIKLL
{
get 		{
			return false;
		}

}

protected bool JPONHMLJFGO
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected void JPLDBNKDMKM(Color HMCAFGCGFJF)
		{
		}

		protected virtual void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void KBLAHEIFMAE(float NNMPJECKECI)
		{
		}

		protected override void NHDINKLIIOC()
		{
		}

		protected override void BENOONGCBKO()
		{
		}

		private IEnumerator CAKIBFEFMCE()
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private void NBECFFIAJMM()
		{
		}
	}
}
