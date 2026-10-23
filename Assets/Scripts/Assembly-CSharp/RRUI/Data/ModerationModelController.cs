using System;
using UnityEngine;

namespace RRUI.Data
{
	public class ModerationModelController : ModelController<ModerationModel>
	{
		[Serializable]
		private class ShowReportAccountDialogImpl : ButtonControllerImpl<ModerationModel>
		{
			[SerializeField]
			private GameObject accountCardPrefab;

			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BanScreenTitleImpl : TextControllerImpl<ModerationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BanScreenDetailsImpl : TextControllerImpl<ModerationModel>
		{
			private IDisposable countdownDisposable;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void ALHNNKKLGHC(float GADDGJANIGG = 0f)
			{
			}
		}

		[Serializable]
		private class WarnScreenDetailsImpl : TextControllerImpl<ModerationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AcknowledgeWarningImpl : ButtonControllerImpl<ModerationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}
	}
}
