using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using UnityEngine;

namespace RRUI.Data
{
	public class MeasurePlayerHeightModelController : ModelController<MeasurePlayerHeightModel>
	{
		[Serializable]
		private class MeasurePlayerHeightButtonImpl : ButtonControllerImpl<MeasurePlayerHeightModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ConfirmPlayerHeightButtonImpl : ButtonControllerImpl<MeasurePlayerHeightModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		private abstract class ShowWhileMeasuringStageHideableImpl : HideableControllerImpl<MeasurePlayerHeightModel>
		{
			private sealed class JAMEEAANLKJ
			{
				public bool visible;

				public ShowWhileMeasuringStageHideableImpl _003C_003E4__this;

				internal void _003COnModelChanged_003Eb__0(MeasurePlayerHeightModel.ECNAABABKBP stage)
				{
				}
			}

protected abstract MeasurePlayerHeightModel.ECNAABABKBP[] ShowStages
{
get ;
}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowWhilePreMeasuringHideableImpl : ShowWhileMeasuringStageHideableImpl
		{
			protected override MeasurePlayerHeightModel.ECNAABABKBP[] ShowStages => null;
		}

		[Serializable]
		private class ShowWhileMeasuringHideableImpl : ShowWhileMeasuringStageHideableImpl
		{
			protected override MeasurePlayerHeightModel.ECNAABABKBP[] ShowStages => null;
		}

		[Serializable]
		private class ShowWhilePostMeasuringHideableImpl : ShowWhileMeasuringStageHideableImpl
		{
			protected override MeasurePlayerHeightModel.ECNAABABKBP[] ShowStages => null;
		}

		[Serializable]
		private class ShowWhileCustomStagesHideableImpl : ShowWhileMeasuringStageHideableImpl
		{
			[SerializeField]
			private MeasurePlayerHeightModel.ECNAABABKBP[] showStages;

			protected override MeasurePlayerHeightModel.ECNAABABKBP[] ShowStages => null;
		}

		[Serializable]
		private class MeasuringProgressBarControllerImpl : ProgressBarControllerImpl<MeasurePlayerHeightModel>
		{
			[SerializeField]
			private AudioSource audioSource;

			private bool progressBarStarted;

			protected override void NGFFCLPHKJN()
			{
			}

			private void LNCEINNKCEL(RecRoomAudioClip OAAADBMOMNE)
			{
			}
		}

		[Serializable]
		private class ProgressBarTextImpl : TextControllerImpl<MeasurePlayerHeightModel>
		{
			private sealed class EIAHAMGJIGJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public ProgressBarTextImpl _003C_003E4__this;

				private int _003CprogressStringIndex_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public EIAHAMGJIGJ(int _003C_003E1__state)
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
			private float TimeBetweenStringChanges;

			[SerializeField]
			private string[] progressStrings;

			private LKGILLBEJEK progressStringCyclePromise;

			private IEnumerator<EGGPGCCKPCO> EIDBNADNNCL()
			{
				return null;
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ResultTextImpl : TextControllerImpl<MeasurePlayerHeightModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
