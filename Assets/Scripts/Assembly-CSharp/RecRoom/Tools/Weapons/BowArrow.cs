using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class BowArrow : Bullet
	{
		private sealed class CLNOCLFNDNP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BowArrow _003C_003E4__this;

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
			public CLNOCLFNDNP(int _003C_003E1__state)
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
		private Transform colliderOriginTransform;

		private Transform FANNNBNGEKK;

		private Quaternion IFLPKMMMHCF;

		private Vector3 ECLKCFJCCPK;

		private bool NPHFIKOFFJL;

		private bool NLCFFELJHNB;

		private Coroutine EIFOANNCLHL;

		private bool EIJAAODKEKP;

protected override Vector3 CCGKMEODAKB
{
get 		{
			return default;
		}

}

protected bool ALDEHOBDAJF
{
get 		{
			return false;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		protected override void FixedUpdate()
		{
		}

		protected void LateUpdate()
		{
		}

		private void DLLHFNNBJAO()
		{
		}

		protected override void JJKLAFOLJBI(FDDLOCDBFDL JJNEFKHCABA)
		{
		}

		public override void Release(Vector3 PIGMAEFKNPK)
		{
		}

		private void BEMLNCMGJDH()
		{
		}

		private IEnumerator CCBDNFOKIGP()
		{
			return null;
		}

		private void NJCIBPGJCGL()
		{
		}

		private void DOMDAMKLHPA(Player EKOFNPFCLMO, bool BMPDAPNDJPA)
		{
		}
	}
}
