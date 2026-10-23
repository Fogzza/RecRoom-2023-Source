using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Tutorials
{
	public class MirrorTutorial : TutorialController
	{
		private enum CHAEEEIPPBD
		{
			Inactive = 0,
			WaitForPlayerToWalkToMirror = 1,
			MirrorIntro = 2,
			WaitForMirrorInteractionStart = 3,
			WaitForMirrorInteractionFinish = 4,
			MirrorOutro = 5,
			Completed = 6
		}

		private sealed class BAJMGHNNCIJ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MirrorTutorial _003C_003E4__this;

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
			public BAJMGHNNCIJ(int _003C_003E1__state)
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

		private sealed class GKLKGHGPPDE : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MirrorTutorial _003C_003E4__this;

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
			public GKLKGHGPPDE(int _003C_003E1__state)
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
		private SimpleVolume simpleTriggerVolume;

		[SerializeField]
		private float triggerVisionConeHalfAngle;

		private MDEJADHJOEJ BGBIFFLGANM;

protected override TutorialManager.AGHBFNEFPAA EBKKEDNBHBE
{
get 		{
			return TutorialManager.AGHBFNEFPAA.NUX_INTRO;
		}

}

protected override bool KLDEGNDBBLA
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override bool PADNEIPEELM()
		{
			return false;
		}

		protected override void OGBCOBDLGKJ()
		{
		}

		protected override bool BDJKHAEKPNF()
		{
			return false;
		}

		private void DAGLFDODBCJ()
		{
		}

		private void JIMLCFHPFFM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private IEnumerator EFIJFLOHGHO()
		{
			return null;
		}

		private void GEFBADBDJMF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void HLEGDJPNDLF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private IEnumerator JHMOJOEPAIF()
		{
			return null;
		}

		private void BPLNHAOOGEN(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}
	}
}
