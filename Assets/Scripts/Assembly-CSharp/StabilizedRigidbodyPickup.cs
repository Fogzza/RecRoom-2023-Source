using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom;
using UnityEngine;

public class StabilizedRigidbodyPickup : RigidbodyPickup
{
	private sealed class HKEKBFAPCKP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StabilizedRigidbodyPickup _003C_003E4__this;

		public Quaternion currentRotation;

		private float _003Cduration_003E5__2;

		private float _003Ctimer_003E5__3;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public HKEKBFAPCKP(int _003C_003E1__state)
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
	private float separationAngle;

	[SerializeField]
	private float returnToDestabilizedSpeed;

	private RigidbodyEx OMIJHCMLOAG;

	[NonSerialized]
	public Vector3 StabilizerOffsetPosition;

	[NonSerialized]
	public Quaternion StabilizerOffsetRotation;

	[NonSerialized]
	public Vector3 StabilizedRigidbodyOffsetFromPickup;

	private Action CJKLMPHLOBJ__BackingField;

	private Coroutine PCHEDANMHMC;

	private Quaternion EKKHDLMMNFK;

public RigidbodyEx Stabilizer
{
get 	{
		return null;
	}

set {
	}
}

public override Quaternion TargetRotation
{
get 	{
		return default;
	}

}

public Vector3 StabilizedForward
{
get 	{
		return default;
	}

}

public Vector3 StabilizerPosition
{
get 	{
		return default;
	}

}

public event Action StabilizerSeparationEvent {
add {
	}
remove {
	}
}

	private void EAAODKLDEOH(Quaternion GDHHCIKHKAJ)
	{
	}

	private void KEPFLPMOELD()
	{
	}

	private IEnumerator MHKIJLPGKAN(Quaternion GDHHCIKHKAJ)
	{
		return null;
	}

	[DebuggerHidden]
	[CompilerGenerated]
	private Quaternion NBECFFIAJMM()
	{
		return default;
	}
}
