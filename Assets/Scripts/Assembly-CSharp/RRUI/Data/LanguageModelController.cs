using System;
using System.Collections.Generic;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class LanguageModelController : ModelController<LanguageModel>
	{
		[Serializable]
		private class ShowLanguageSelectionButtonImpl : ButtonControllerImpl<LanguageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LanguageDisplayTextImpl : TextControllerImpl<LanguageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideLanguageSelectorImpl : HideableControllerImpl<LanguageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLanguageImpl : HideableControllerImpl<LanguageModel>
		{
			public List<LocaleIdentifier> locales;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfEnglishLanguageImpl : HideableControllerImpl<LanguageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotEnglishLanguageImpl : HideableControllerImpl<LanguageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
