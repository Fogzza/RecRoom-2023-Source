using System;
using RRUI.Data;
using UnityEngine;

namespace Assets.RRUI.Models.Rewards
{
	internal class RRPlusDoubleRewardDialogModelController : ModelController<RRPlusDoubleRewardDialogModel>
	{
		[Serializable]
		private class DontShowAgainCheckboxImpl : ToggleControllerImpl<RRPlusDoubleRewardDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NormalRewardAmountTextImpl : TextControllerImpl<RRPlusDoubleRewardDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DoubleRewardAmountTextImpl : TextControllerImpl<RRPlusDoubleRewardDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SelectOriginalImpl : ButtonControllerImpl<RRPlusDoubleRewardDialogModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OpenRRPlusPageImpl : ButtonControllerImpl<RRPlusDoubleRewardDialogModel>
		{
			[SerializeField]
			private string entrypointName;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
