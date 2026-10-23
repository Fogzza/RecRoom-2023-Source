using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Inputs;
using UnityEngine;

namespace RRUI.Data
{
	public class MeasurePlayerHeightModel : RRUIModel
	{
		public enum ECNAABABKBP
		{
			PRE_MEASURING = 0,
			MEASURING = 1,
			POST_MEASURING = 2
		}

		public enum LGPMJKBFNCI
		{
			MEASUREMENT_START = 0,
			PROGRESS_BAR_START = 1,
			PROGRESS_BAR_FINISH = 2,
			AUDIO_START = 3,
			AUDIO_FINISH = 4
		}

		private sealed class FBIOFOALGDL
		{
			public LKGILLBEJEK measurePlayerHeightCoroutine;

			public MeasurePlayerHeightModel _003C_003E4__this;

			internal void _003CMeasurePlayerHeight_003Eb__0()
			{
			}
		}

		private sealed class EFINPIDHOCM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MeasurePlayerHeightModel _003C_003E4__this;

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
			public EFINPIDHOCM(int _003C_003E1__state)
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

		private sealed class MPCOHILPLBA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MeasurePlayerHeightModel _003C_003E4__this;

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
			public MPCOHILPLBA(int _003C_003E1__state)
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

		private sealed class NINKPPOANAG
		{
			public MeasurePlayerHeightModel _003C_003E4__this;

			public JKHCJAJHGAO audioPromise;

			public JKHCJAJHGAO progressBarPromise;

			internal void _003CMeasurePlayerHeightCoroutine_003Eb__0()
			{
			}

			internal void _003CMeasurePlayerHeightCoroutine_003Eb__1()
			{
			}

			internal void _003CMeasurePlayerHeightCoroutine_003Eb__2()
			{
			}

			internal void _003CMeasurePlayerHeightCoroutine_003Eb__3()
			{
			}
		}

		private sealed class COFDPNFJECG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MeasurePlayerHeightModel _003C_003E4__this;

			public LIKFFCKGMNN controlPromise;

			private VRInputHandler _003CfirstHand_003E5__2;

			private VRInputHandler _003CsecondHand_003E5__3;

			private float _003CendMeasurementTime_003E5__4;

			private ControllerWingspanSettings _003CwingspanConfig_003E5__5;

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
			public COFDPNFJECG(int _003C_003E1__state)
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
		protected PlayerHeightConfig heightConfig;

		[SerializeField]
		protected float measurementDurationTime;

		[SerializeField]
		protected float progressBarStartTime;

		[SerializeField]
		protected float progressBarEndTime;

		[SerializeField]
		protected float audioStartTime;

		[SerializeField]
		protected float measuredWingspanSmoothTime;

		[SerializeField]
		protected RecRoomAudioClip measuringAudioClip;

		private JNKNMMDAHCF NLLMOKKOFBI;

		private bool EFFLEFFFDLN;

		private float? NAIILPFEGDA;

		private bool ENGDKGCHJJL;

		private float ILFPNHFKPMO;

		private ECNAABABKBP NODHMIMJPJD;

		private LGPMJKBFNCI NBCMJMMJGOO;

		private Action PIDLAFGCECM__BackingField;

		private LIKFFCKGMNN MFDIAMCAKMO;

		private readonly CGOBNNIEKLB FHIEBKOCKIF;

public JNKNMMDAHCF SettingsManager
{
get 		{
			return null;
		}

private set {
		}
}

public bool CanMeasurePlayerHeight
{
get 		{
			return false;
		}

private set {
		}
}

public float? MeasurementTimeRemaining
{
get 		{
			return null;
		}

private set {
		}
}

public bool HasMeasuredPlayerHeight
{
get 		{
			return false;
		}

private set {
		}
}

public float MeasurementDurationTime
{
get 		{
			return 0f;
		}

}

public RecRoomAudioClip MeasuringAudioClip
{
get 		{
			return null;
		}

}

public float ProgressBarDuration
{
get 		{
			return 0f;
		}

}

public float MeasuredPlayerWingspan
{
get 		{
			return 0f;
		}

private set {
		}
}

public float MeasuredPlayerHeight
{
get 		{
			return 0f;
		}

}

public bool MeasuredPlayerHeightIsTooTall
{
get 		{
			return false;
		}

}

public bool MeasuredPlayerHeightIsTooShort
{
get 		{
			return false;
		}

}

public ECNAABABKBP CurrentMeasuringStage
{
get 		{
			return ECNAABABKBP.PRE_MEASURING;
		}

private set {
		}
}

public LGPMJKBFNCI CurrentMeasuringSubStage
{
get 		{
			return LGPMJKBFNCI.MEASUREMENT_START;
		}

private set {
		}
}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public PlayerHeightConfig HeightConfig
{
get 		{
			return null;
		}

}

public bool IsPlayerHeightMeasurementNeeded
{
get 		{
			return false;
		}

}

public event Action MeasurementFlowCompleted {
add {
		}
remove {
		}
}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		private void PPKOLGPELII(bool GJGODIHKAHN)
		{
		}

		public void MeasurePlayerHeight()
		{
		}

		public void SaveMeasuredPlayerHeight()
		{
		}

		public void MarkCompleted()
		{
		}

		private IEnumerator<EGGPGCCKPCO> CGJDPBLFIAA()
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> GNMCEHPLEEJ()
		{
			return null;
		}

		private void PMKMEHLAKGD()
		{
		}

		private IEnumerator<EGGPGCCKPCO> ICDPHNCCHNO(LIKFFCKGMNN FBJGHBMPOPK)
		{
			return null;
		}
	}
}
