using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Core.Animation;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class PlayScreenAnimationVignetteEncounterStep : GameEncounterStep
	{
		public enum GFMJCDCAHKP
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1,
			AFTER_VIGNETTE_DURATION = 2
		}

		private sealed class NDHHFIJLBFA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerAnimationVignette vignette;

			public PlayScreenAnimationVignetteEncounterStep _003C_003E4__this;

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
			public NDHHFIJLBFA(int _003C_003E1__state)
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
		protected PlayerAnimationVignette vignette;

		private float GDJAFIFIDCG;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnEncounterStart()
		{
		}

		public override void OnEncounterStop()
		{
		}

		private IEnumerator MIGAHMEHPAB(PlayerAnimationVignette JIMMMHPAJDD)
		{
			return null;
		}

		public override void OnStartRunning()
		{
		}

		public override void OnUpdateRunning()
		{
		}

		public override void OnStopRunning()
		{
		}

		public override void OnSkipRunning()
		{
		}

		public override bool IsBlockingEncounterEnd()
		{
			return false;
		}

		public override bool IsCompleted()
		{
			return false;
		}
	}
}
