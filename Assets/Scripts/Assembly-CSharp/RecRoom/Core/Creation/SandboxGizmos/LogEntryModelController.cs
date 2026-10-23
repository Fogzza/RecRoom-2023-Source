using System;
using RRUI.Data;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class LogEntryModelController : ModelController<LogEntryModel>
	{
		[Serializable]
		private class LogEntryTextImpl : TextControllerImpl<LogEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LogEntryButtonImpl : ButtonControllerImpl<LogEntryModel>
		{
			[SerializeField]
			private Color selectedColor;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
