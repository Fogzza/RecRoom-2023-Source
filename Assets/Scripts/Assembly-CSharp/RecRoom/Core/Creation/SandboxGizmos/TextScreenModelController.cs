using System;
using RRUI.Data;
using RRUI.Theme;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class TextScreenModelController : ModelController<TextScreenModel>
	{
		[Serializable]
		private class LogSpawnerImpl : RecyclingListControllerImpl<TextScreenModel, TextEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class Button_ToggleTimestamps : ButtonControllerImpl<TextScreenModel>
		{
			[SerializeField]
			protected ToggleTheme toggleTheme;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_ToggleChannel : ButtonControllerImpl<TextScreenModel>
		{
			[SerializeField]
			protected ToggleTheme toggleTheme;

			[SerializeField]
			private AIMNMBLLDFJ logScreenChannel;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_ClearLogs : ButtonControllerImpl<TextScreenModel>
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
