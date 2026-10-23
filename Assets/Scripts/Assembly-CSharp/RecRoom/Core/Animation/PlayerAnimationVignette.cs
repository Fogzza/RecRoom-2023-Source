using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Core.Animation
{
	public class PlayerAnimationVignette : ScriptableObject
	{
		[Serializable]
		private struct KeyAnimation
		{
			public string name;

			public PlayerAnimation animation;

			public AdditiveAnimationWeight cameraWeight;

			public bool loop;

			public float startDelay;

			public float loopDuration;

			public float IHFBADDLCMI()
			{
				return 0f;
			}
		}

		private sealed class HMJNPIBFJML : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerAnimationVignette _003C_003E4__this;

			public GFLJPBGELNJ animationSystem;

			private int _003Cindex_003E5__2;

			private PlayerAnimation _003CfinalAnimation_003E5__3;

			private float _003CanimationStartTime_003E5__4;

			private float _003CloopStartTime_003E5__5;

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
			public HMJNPIBFJML(int _003C_003E1__state)
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
		private KeyAnimation[] keys;

		public IEnumerator LMAEMJKMNEE(GFLJPBGELNJ KHGDDEPEMAB)
		{
			return null;
		}

		public float IHFBADDLCMI()
		{
			return 0f;
		}
	}
}
