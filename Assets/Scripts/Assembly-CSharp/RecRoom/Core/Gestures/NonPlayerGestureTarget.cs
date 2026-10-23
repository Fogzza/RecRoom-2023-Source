using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Core.Gestures
{
	public class NonPlayerGestureTarget : MonoBehaviour
	{
		private sealed class JJDCHMDGEAE : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NonPlayerGestureTarget _003C_003E4__this;

			private Vector3 _003ChandStartPos_003E5__2;

			private Quaternion _003ChandStartRot_003E5__3;

			private Vector3 _003CarmStartPos_003E5__4;

			private Quaternion _003CarmStartRot_003E5__5;

			private float _003Cstep_003E5__6;

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
			public JJDCHMDGEAE(int _003C_003E1__state)
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

		private Action<PlayerHandGestures.NAHIAFFDEIO> LFLFEAECCCD__BackingField;

		private HandshakeGesture.FINJNKMKNBA GNKFBOHCCLN;

		[SerializeField]
		private Transform connectedArm;

		[SerializeField]
		private PlayerHandGestures.NAHIAFFDEIO _supportedGesture;

		[SerializeField]
		private PlayerHand.ICBKGDOJNDN _handType;

		[SerializeField]
		private RigidbodyPickup _rigidbodyPickup;

		[SerializeField]
		private Interpolator interpolator;

		private Vector3 NNPDEOBKMNH;

		private Quaternion DAKCGGJDHEE;

		private Vector3 NEKMCANAONG;

		private Quaternion EIEJKKLDALJ;

		private Coroutine NNLMAFADJJE;

public HandshakeGesture.FINJNKMKNBA CurrentHandshakeState
{
get 		{
			return HandshakeGesture.FINJNKMKNBA.Inactive;
		}

private set {
		}
}

public PlayerHandGestures.NAHIAFFDEIO SupportedGesture
{
get 		{
			return PlayerHandGestures.NAHIAFFDEIO.Highfive;
		}

}

public PlayerHand.ICBKGDOJNDN HandType
{
get 		{
			return PlayerHand.ICBKGDOJNDN.Left;
		}

}

public Vector3 PalmDirection
{
get 		{
			return default;
		}

}

public Vector3 FingerDirection
{
get 		{
			return default;
		}

}

public RigidbodyPickup RigidbodyPickup
{
get 		{
			return null;
		}

}

public event Action<PlayerHandGestures.NAHIAFFDEIO> OnGestureCompletedAction {
add {
		}
remove {
		}
}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void UpdateOriginalPosition(Vector3 INLGLHIPOMC)
		{
		}

		public void UpdateHandshakeState(HandshakeGesture.FINJNKMKNBA PPGHNKPDPOB)
		{
		}

		public void FinishGesture(PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH)
		{
		}

		private IEnumerator POPPBEAAIFN()
		{
			return null;
		}
	}
}
