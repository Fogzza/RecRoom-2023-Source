using System;

namespace RRUI.Data
{
	public class NewPlayerChallengeHowToDialogController : ModelController<NewPlayerChallengeHowToDialogModel>
	{
		[Serializable]
		private class HelpTextImpl : TextControllerImpl<NewPlayerChallengeHowToDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HelpTipImageImpl : RecNetRawImageControllerImpl<NewPlayerChallengeHowToDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoHelpTipImageImpl : HideableControllerImpl<NewPlayerChallengeHowToDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
