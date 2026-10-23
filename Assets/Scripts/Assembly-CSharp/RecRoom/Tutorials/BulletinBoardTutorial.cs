using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Tutorials
{
	public class BulletinBoardTutorial : TutorialController
	{
		private enum JDMNIHKIMEI
		{
			Inactive = 0,
			BulletinBoardIntro = 1,
			Completed = 2
		}

		private sealed class MBOGDCGPNDI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BulletinBoardTutorial _003C_003E4__this;

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
			public MBOGDCGPNDI(int _003C_003E1__state)
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

		protected override void Awake()
		{
		}

		protected override void Update()
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

		private void PBJPIKLLFCJ(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private IEnumerator GKNDIHIKJBM()
		{
			return null;
		}

		private void NAICJCOMFFK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}
	}
}
