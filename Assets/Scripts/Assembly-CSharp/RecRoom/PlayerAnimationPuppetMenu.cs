using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using RecRoom.Core;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class PlayerAnimationPuppetMenu : MonoBehaviour
	{
		private sealed class CJDCPOPDDBJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PlayerAnimationPuppetMenu _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public CJDCPOPDDBJ(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private PlayerAnimationAsset defaultAnimation;

		[SerializeField]
		private Button3D decrementButton;

		[SerializeField]
		private Button3D incrementButton;

		[SerializeField]
		private Text label;

		private PlayerAnimationPreviewPuppet IKMJJIEINIM;

		private int KLLGIENAIKF;

private int HJNEJEJKOKE
{
get 		{
			return 0;
		}

set {
		}
}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void NMLBHAADMIN()
		{
		}

		private void HADBNNANGFK()
		{
		}

		private IEnumerator<EGGPGCCKPCO> PFKBOJKJEFI()
		{
			return null;
		}

		public void Button_AnimationIndexIncrement()
		{
		}

		public void Button_AnimationIndexDecrement()
		{
		}
	}
}
