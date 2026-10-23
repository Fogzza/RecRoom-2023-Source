using System;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class RewardSelectionItemModelController : ModelController<RewardSelectionItemModel>
	{
		[Serializable]
		private class RewardTextImpl : TextControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardValueImpl : TextControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardStarsImpl : TextControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardRarityImpl : ImageControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardSelectImpl : ButtonControllerImpl<RewardSelectionItemModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardImposterRenderImpl : ImposterRawImageControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfValueEmptyImpl : HideableControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowDoubleRewardsOptionDisabled : HideableControllerImpl<RewardSelectionItemModel>
		{
			[SerializeField]
			private bool ShowWhenRRPlusMember;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideRRPlusIcon : HideableControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideDoubleRewardAvailableBadge : HideableControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideDoubleRewardBadge : HideableControllerImpl<RewardSelectionItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DoubleRewardImageImpl : ImageControllerImpl<RewardSelectionItemModel>
		{
			[SerializeField]
			private Image border;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DoubleRewardInfoButtonImpl : ButtonControllerImpl<RewardSelectionItemModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
