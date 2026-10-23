using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class DelayedRangedWeaponTrigger : MonoBehaviourPun
	{
		public delegate void BLEALPFGGAD(DelayedRangedWeaponTrigger OBNBBDPHGAD);

		private sealed class LJKBAPJDGAG : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DelayedRangedWeaponTrigger _003C_003E4__this;

			private float _003Ct_003E5__2;

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
			public LJKBAPJDGAG(int _003C_003E1__state)
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

		private BLEALPFGGAD ADNOPNMIKHD__BackingField;

		private BLEALPFGGAD HMIGOOOOFLN__BackingField;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private RangedWeapon weapon;

		[SerializeField]
		private WeaponAudio weaponAudio;

		[SerializeField]
		private float delay;

		[SerializeField]
		private float inputResponseDelay;

		[SerializeField]
		private Transform fuseStartTransform;

		[SerializeField]
		private Transform fuseEndTransform;

		[SerializeField]
		private PooledParticle triggerPullParticlesPrefab;

		[SerializeField]
		private Transform triggerPullParticleTransform;

		[SerializeField]
		private PooledParticle countdownParticlesPrefab;

		[SerializeField]
		private float vibrationIntensity;

		[SerializeField]
		private RecRoomAudioClip prepareFiringAudio;

		[SerializeField]
		private RecRoomAudioClip fireDelayLoopingAudio;

		private Transform EEMGLAMCMIA;

		private PooledParticle BDPBJBNGFGD;

		private Coroutine GDFKMFHDFPI;

		private SFXAudioSource IBEGKMGDIFD;

public float Delay
{
get 		{
			return 0f;
		}

}

public bool IsCountingDown
{
get 		{
			return false;
		}

}

public event BLEALPFGGAD CountdownStartedEvent {
add {
		}
remove {
		}
}

public event BLEALPFGGAD TriggeredEvent {
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

		public void AuthorityTryFire()
		{
		}

		private void MBIOLEBFOOM(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private void JMNJJLBJLEK(Tool PMEFICGEDFK)
		{
		}

		private void HNJEDNNDGBH()
		{
		}

		private void GHFFGHBKJIN()
		{
		}

		private void LACDLIFONKH()
		{
		}

		private void HCNIEODINDL()
		{
		}

		private IEnumerator NPACHLOJDMM()
		{
			return null;
		}

		private void JCNKHHJBJCG()
		{
		}

		private void LNDFIHPKJGC()
		{
		}

		private void LKCOHKNLINP()
		{
		}

		private void NEAEDBMIJNH()
		{
		}

		[PBOMGCLBFHF]
		private void RpcPrepareDelayedFiring()
		{
		}
	}
}
