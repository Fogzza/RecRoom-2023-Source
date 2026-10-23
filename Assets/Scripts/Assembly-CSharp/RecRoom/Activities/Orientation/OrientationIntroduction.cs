using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using RecRoom.Core.Animation;
using RecRoom.Tutorials;
using UnityEngine;

namespace RecRoom.Activities.Orientation
{
	public class OrientationIntroduction : OrientationIntroductionBase, FEGADGPOOCL, IDisposable
	{
		private enum JAPBCKLLCBJ
		{
			Inactive = 0,
			WaitForPlayerSpawn = 1,
			Welcome = 2,
			VRLocomotionSelection = 3,
			HeadInside = 4,
			Completed = 5
		}

		[Serializable]
		private class VoiceOverLine
		{
			public float preAudioDelay;

			public RecRoomAudioClip audio;
		}

		[Serializable]
		private class TutorialPrompt
		{
			public float prePromptDelay;

			public TutorialPromptContext prompt;
		}

		private sealed class EJCBMEOCOEO : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OrientationIntroduction _003C_003E4__this;

			private Coroutine _003CvignetteCoroutine_003E5__2;

			private int _003Ci_003E5__3;

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
			public EJCBMEOCOEO(int _003C_003E1__state)
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

		private sealed class JCLPDNOGEPL
		{
			public string analyticsEventStepName;

			public TutorialPrompt prompt;

			internal void _003COnEnterHeadInsideState_003Eb__6()
			{
			}

			internal LAHBDKNMNHN _003COnEnterHeadInsideState_003Eb__7()
			{
				return null;
			}

			internal void _003COnEnterHeadInsideState_003Eb__8()
			{
			}
		}

		private sealed class JMBHODIKMBB : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VoiceOverLine voiceOverLine;

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
			public JMBHODIKMBB(int _003C_003E1__state)
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

		private sealed class GEEGCMPCJKH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public VoiceOverLine[] voiceOverLines;

			private int _003Ci_003E5__2;

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
			public GEEGCMPCJKH(int _003C_003E1__state)
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

		private sealed class EFDAICFJFOE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float duration;

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
			public EFDAICFJFOE(int _003C_003E1__state)
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
		private RecRoomAudioClip musicalStinger;

		[SerializeField]
		private PlayerAnimationVignette screensVignette;

		[SerializeField]
		private VoiceOverLine[] welcomeVoiceOverLines;

		[SerializeField]
		private VoiceOverLine[] headInsideVoiceOverLines;

		[SerializeField]
		private TutorialPrompt walkPrompt;

		[SerializeField]
		private TutorialPrompt lookPrompt;

		[SerializeField]
		private float hudFadeDelay;

		[SerializeField]
		private float hudFadeDuration;

		[SerializeField]
		private float initialCameraFadeDelay;

		[SerializeField]
		private float initialCameraFadeDuration;

		[SerializeField]
		private bool reset;

		private MDEJADHJOEJ BGBIFFLGANM;

		private Action ADILKHJPNGO__BackingField;

		private Coroutine IOPPNHNDDPI;

		private LKGILLBEJEK AFOBDMLMJCG;

public event Action IntroCompleted {
add {
		}
remove {
		}
}

		public void Init()
		{
		}

		public void ManualUpdate()
		{
		}

		public void Dispose()
		{
		}

		private void KMAMLAHODAD(JAPBCKLLCBJ DADHJJNJEFA)
		{
		}

		private void DBFPBJLOPFF(JAPBCKLLCBJ DADHJJNJEFA)
		{
		}

		private void HAMDHPDNFHC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void FFHDMBBCMLF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void ABNEHFDPHHI()
		{
		}

		private bool NIEJNPAGNMC()
		{
			return false;
		}

		private bool PLKHCPFIHME()
		{
			return false;
		}

		private void OLMJDJALIDD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void PMDNOGCIECB(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private IEnumerator AFAOFPLGJDA()
		{
			return null;
		}

		private void NAMCHMCHELM()
		{
		}

		private void KJDJABHILCA()
		{
		}

		private void IOGNJBMJLHH()
		{
		}

		private void INKJICPNFAI(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void KADBAFKDAMD()
		{
		}

		private void MIMICOCKHJA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void EMDNDPOPMLL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MGFPNLINNOK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void NBBLHFOFDJN(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void EOMMJNILDAL()
		{
		}

		private IEnumerator DPJAPFPPBIO(VoiceOverLine NMOAAMHJDEA)
		{
			return null;
		}

		private Coroutine AKKMKDBEFGC(PlayerAnimationVignette JIMMMHPAJDD)
		{
			return null;
		}

		[CompilerGenerated]
		private static IEnumerator<EGGPGCCKPCO> JGMPBFOFIOB(VoiceOverLine[] KOGJDHEKCNH)
		{
			return null;
		}

		[CompilerGenerated]
		internal static IEnumerator<EGGPGCCKPCO> MPNGMOJLJMK(float FGBPJMKCMAO)
		{
			return null;
		}

		[CompilerGenerated]
		private static LAHBDKNMNHN NGPLNOECEGH(TutorialPrompt HHNMDIGPGKO, string IOAOEDOIBDO)
		{
			return null;
		}

		[CompilerGenerated]
		private LAHBDKNMNHN HFKIKIPMBMP()
		{
			return null;
		}

		[CompilerGenerated]
		private LAHBDKNMNHN BDNEOCAJLKJ()
		{
			return null;
		}

		[CompilerGenerated]
		private void NNJDHBPEGKH()
		{
		}
	}
}
