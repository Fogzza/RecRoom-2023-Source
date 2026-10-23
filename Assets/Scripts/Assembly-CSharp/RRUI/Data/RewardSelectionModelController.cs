using System;
using UnityEngine;

namespace RRUI.Data
{
	public class RewardSelectionModelController : ModelController<RewardSelectionModel>
	{
		[Serializable]
		private class RewardFromUriImpl : FromUriControllerImpl<RewardSelectionModel>
		{
			public override bool RefreshOnShow => false;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class RewardOptionSetterImpl : ControllerImplementation<RewardSelectionModel>
		{
			[SerializeField]
			private RewardSelectionItemModel[] rewardItemModels;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardReasonTextImpl : TextControllerImpl<RewardSelectionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CloseButtonImpl : ButtonControllerImpl<RewardSelectionModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CloseAfterTimeImpl : ControllerImplementation<RewardSelectionModel>
		{
			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
