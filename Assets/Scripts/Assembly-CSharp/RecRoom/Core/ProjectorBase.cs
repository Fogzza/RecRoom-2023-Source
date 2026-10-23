using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Tools;
using UnityEngine;

namespace RecRoom.Core
{
	public abstract class ProjectorBase : MonoBehaviour
	{
		public enum DAOCECJKNIJ
		{
			Default = 0,
			ForceClosed = 1,
			ForceOpen = 2
		}

		private sealed class ILPFKHCGEHO : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProjectorBase _003C_003E4__this;

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
			public ILPFKHCGEHO(int _003C_003E1__state)
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

		private sealed class LDCKEPHDMBH : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProjectorBase _003C_003E4__this;

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
			public LDCKEPHDMBH(int _003C_003E1__state)
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
		private ToolEntity toolEntity;

		[SerializeField]
		private float innerProximityTriggerRadius;

		[SerializeField]
		private float outerProximityTriggerRadius;

		[SerializeField]
		private float maxOpeningAngle;

		[SerializeField]
		private float maxRotationAngle;

		[SerializeField]
		private float maxUprightOffsetAngle;

		[SerializeField]
		private RecRoomAudioClip openAudioClip;

		[SerializeField]
		private RecRoomAudioClip closeAudioClip;

		[SerializeField]
		private RecRoomAudioClip ambientHumAudioClip;

		private static readonly int PCAJDJMNDAO;

		private static readonly int NBNJCNPDOJJ;

		private static readonly int APLDCEBMKJL;

		private static readonly int BAKGDDKOGDA;

		protected Animator CBCFEAPCGEO;

		private SFXAudioSource HLGJNFJNHPN;

		private Coroutine FBOOLOICCHK;

		private IDisposable OIBLDGMFCDI;

		[NonSerialized]
		public DAOCECJKNIJ Visibility;

		[NonSerialized]
		public Transform TargetTransform;

		private bool IJICNCCEOCE;

		private bool FPNALMLOHHH;

public bool Open
{
get 		{
			return false;
		}

set {
		}
}

public bool FullyOpen
{
get 		{
			return false;
		}

}

public bool FullyClosed
{
get 		{
			return false;
		}

}

private float JHILOBKHLDJ
{
set {
		}
}

public bool MuteAudio
{
get 		{
			return false;
		}

set {
		}
}

		protected virtual void Awake()
		{
		}

		private void Start()
		{
		}

		protected virtual void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void AGDPILCKLLO()
		{
		}

		private void OnDisable()
		{
		}

		private void LIFCJPPNNIC()
		{
		}

		private void KEBECBCBJPG()
		{
		}

		private IEnumerator GHANLAJOLNJ()
		{
			return null;
		}

		private IEnumerator FLENDPCNBPF()
		{
			return null;
		}

		private void FBJJKLGODNB()
		{
		}

		private void JLOJLCNPHJD(out Vector3 JNNFLMMDFDD, out Vector3 INKGHPCDMCG, out Vector3 IKLICOKIGAC, out Vector3 BCINCDNNOGB, out float LLGEEODHEJA)
		{
			JNNFLMMDFDD = default;
			INKGHPCDMCG = default;
			IKLICOKIGAC = default;
			BCINCDNNOGB = default;
			LLGEEODHEJA = default;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
