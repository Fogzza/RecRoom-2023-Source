using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestWeaponCorkScaler : MonoBehaviour
	{
		private sealed class PMGDCDCFJIC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestWeaponCorkScaler _003C_003E4__this;

			private float _003CstartTime_003E5__2;

			private float _003CendTime_003E5__3;

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
			public PMGDCDCFJIC(int _003C_003E1__state)
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
		private RangedWeapon weapon;

		[SerializeField]
		private Transform cork;

		[SerializeField]
		private float scaleCorkDuration;

		[SerializeField]
		private Transform hiddenCorkLocalPositionTransform;

		private Vector3 ONOHCLPCCDO;

		private Vector3 KFGKNOKKJOC;

		private Coroutine JKENDKHLKHI;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void DOEHEFOFCJG()
		{
		}

		private void LJJENLPPJOL()
		{
		}

		private void EGIIJHAMJHE()
		{
		}

		private void DBKGPBOLKHA()
		{
		}

		private IEnumerator AJLAPDALPOP()
		{
			return null;
		}
	}
}
