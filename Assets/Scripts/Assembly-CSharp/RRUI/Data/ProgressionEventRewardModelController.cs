using System;
using UnityEngine;

namespace RRUI.Data
{
	public class ProgressionEventRewardModelController : ModelController<ProgressionEventRewardModel>
	{
		[Serializable]
		private class RewardImageImpl : RecNetRawImageControllerImpl<ProgressionEventRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ProgressTextImpl : TextControllerImpl<ProgressionEventRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClaimRewardButtonImpl : ButtonControllerImpl<ProgressionEventRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfNotMainRewardImpl : HideableControllerImpl<ProgressionEventRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotStatusImpl : HideableControllerImpl<ProgressionEventRewardModel>
		{
			[SerializeField]
			private ProgressionEventRewardModel.BANPBFCEMCA status;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardProgressBarImpl : ProgressBarControllerImpl<ProgressionEventRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
