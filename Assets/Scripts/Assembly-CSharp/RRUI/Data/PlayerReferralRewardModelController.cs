using System;
using UnityEngine;

namespace RRUI.Data
{
	public class PlayerReferralRewardModelController : ModelController<PlayerReferralRewardModel>
	{
		[Serializable]
		private class ProgressTextImpl : TextControllerImpl<PlayerReferralRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardSpriteImpl : ImageControllerImpl<PlayerReferralRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClaimRewardButtonImpl : ButtonControllerImpl<PlayerReferralRewardModel>
		{
			private PlayerReferralRewardListModel cachedPlayerReferralRewardListModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfNotStatusImpl : HideableControllerImpl<PlayerReferralRewardModel>
		{
			[SerializeField]
			private MPCEBLLDJEG status;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardProgressBarImpl : ProgressBarControllerImpl<PlayerReferralRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
