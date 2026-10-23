using System;
using RRUI.Data;
using RRUI.Theme;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class LogScreenModelController : ModelController<LogScreenModel>
	{
		[Serializable]
		private class LogSpawnerImpl : RecyclingListControllerImpl<LogScreenModel, LogEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class Button_ToggleTimestamps : ButtonControllerImpl<LogScreenModel>
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
		private class Button_ToggleChannel : ButtonControllerImpl<LogScreenModel>
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
		private class Button_ClearLogs : ButtonControllerImpl<LogScreenModel>
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
