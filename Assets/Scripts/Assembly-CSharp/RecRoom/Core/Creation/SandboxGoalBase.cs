using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.Core.Pools;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.Core.Creation
{
	public abstract class SandboxGoalBase : MonoBehaviourPun
	{
		private sealed class PJPAGLJFIBF : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SandboxGoalBase _003C_003E4__this;

			private MaterialPropertyBlock _003CtempPropertyBlock_003E5__2;

			private int _003CflashCount_003E5__3;

			private float _003Ct_003E5__4;

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
			public PJPAGLJFIBF(int _003C_003E1__state)
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

		[SerializeField]
		protected Tool tool;

		public UnityEvent OnGoalHitEvent;

		[SerializeField]
		private IALAJKBOKBN CollisionLayer;

		[SerializeField]
		private CircuitNodeDisplay circuitNodeDisplay;

		[SerializeField]
		private float minHitInterval;

		[SerializeField]
		private PooledParticle hitParticles;

		[SerializeField]
		private RecRoomAudioClip hitAudio;

		[SerializeField]
		private Renderer[] hitFlashRenderers;

		[SerializeField]
		private Color hitFlashColor;

		[SerializeField]
		private float hitFlashIntensity;

		[SerializeField]
		private int hitFlashCount;

		[SerializeField]
		private float hitFlashDuration;

		[SerializeField]
		private float hitFlashFadeDuration;

		[SerializeField]
		private float hitFlashInterval;

		private float MBBGJMHHNAJ;

		private Coroutine HEJFFLCHMFI;

public Tool Tool
{
get 		{
			return null;
		}

}

protected virtual bool KIGFJAHOJMH
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected abstract void OnTriggerEnter(Collider HNPEBINPOBO);

		protected void ECNBHFMMOGI(Vector3 INLGLHIPOMC)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcOnGoalHit(Vector3 INLGLHIPOMC)
		{
		}

		protected virtual void JHGMCPIGNMP(Vector3 INLGLHIPOMC)
		{
		}

		private IEnumerator PNFCHFIBGNG()
		{
			return null;
		}

		private void DOCAIDFECKG(Renderer LPCBHIEOFOB, MaterialPropertyBlock CCJNODPJDNN, int CHIEJFHOPDP, Color JOPIJOILNEP, float DOEJGDJILAD)
		{
		}
	}
}
