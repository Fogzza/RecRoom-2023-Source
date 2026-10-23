using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class FlipOpenWeaponSights : MonoBehaviour
	{
		private sealed class HJOHENCHOKF : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FlipOpenWeaponSights _003C_003E4__this;

			public Quaternion leftTargetLocalRotation;

			public Quaternion rightTargetLocalRotation;

			private Quaternion _003CinitialLocalLeftOrientation_003E5__2;

			private Quaternion _003CinitialLocalRightOrientation_003E5__3;

			private float _003CstartTime_003E5__4;

			private float _003CendTime_003E5__5;

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
			public HJOHENCHOKF(int _003C_003E1__state)
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
		private Tool tool;

		[SerializeField]
		private Transform leftHandFrontSight;

		[SerializeField]
		private Transform leftHandBackSight;

		[SerializeField]
		private Vector3 closedLeftHandRotation;

		[SerializeField]
		private Vector3 openLeftHandRotation;

		[SerializeField]
		private Transform rightHandFrontSight;

		[SerializeField]
		private Transform rightHandBackSight;

		[SerializeField]
		private Vector3 closedRightHandRotation;

		[SerializeField]
		private Vector3 openRightHandRotation;

		[SerializeField]
		private float timeToUpdate;

		private Coroutine GNBMHPLPBOA;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void BOGLMPCCMDC(Tool IEGMBEPJMGC)
		{
		}

		private void FECLHJOGDHF(Tool IEGMBEPJMGC)
		{
		}

		private void ECGCCKDMGHA(Tool IEGMBEPJMGC, bool NPCJEDPMAEN = false)
		{
		}

		private IEnumerator PIJKGNLBIEG(Quaternion OEALHFOHHBI, Quaternion AGCLMJDLMEC)
		{
			return null;
		}

		private void LFLBCGKNMCE(Quaternion BJJOEOEAODC, Quaternion LJNNMIAEMEL)
		{
		}

		private void ANGHFCIAIFB()
		{
		}

		private void FPJGDGDMFIC(Quaternion HEGBBJCMANH)
		{
		}

		private void JCICDJPKKML(Quaternion HEGBBJCMANH)
		{
		}
	}
}
