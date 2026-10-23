using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Tutorials
{
	public class WatchTutorial : TutorialController
	{
		private enum ALFCCMEJPNN
		{
			Inactive = 0,
			WaitForOpenWatchState = 1,
			WatchMenuTutorialState = 2,
			PromptForAge = 3,
			Completed = 4
		}

		private enum DHIKADAHPEN
		{
			HomeMenuIntro = 0
		}

		private sealed class COPEMMAEIMB : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WatchTutorial _003C_003E4__this;

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
			public COPEMMAEIMB(int _003C_003E1__state)
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
		private TutorialPromptContext watchTutorialPrompt;

		[SerializeField]
		private TeleportationPortal dormRoomDoor;

		[SerializeField]
		private GameObject[] objectsDisabledDuringWatchTutorial;

		[SerializeField]
		private RecRoomAudioClip watchMenuIntroVO;

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

		private void KDNJLDDAJHK(EGGMEJDMHKF GPKOELKKOBP)
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

		private void OINNBKFKFKP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void KILFINBDBFL()
		{
		}

		private void GCGHNGBJMMP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void JDBCCPDPNJG(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private IEnumerator NBFOHMHAGLA()
		{
			return null;
		}

		private void AFNPHJFCKGI()
		{
		}

		private void GMGNOEEHOJD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}
	}
}
