using System;
using UnityEngine;

namespace RRUI.Data
{
	public class DynamicUIDialogModelController : ModelController<DynamicUIDialogModel>
	{
		[Serializable]
		private class ToDynamicUIImpl : ControllerImplementation<DynamicUIDialogModel>
		{
			[SerializeField]
			private DynamicUIModel dynamicUIModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HeaderToDynamicUIImpl : ControllerImplementation<DynamicUIDialogModel>
		{
			[SerializeField]
			private DynamicUIModel dynamicUIModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FooterToDynamicUIImpl : ControllerImplementation<DynamicUIDialogModel>
		{
			[SerializeField]
			private DynamicUIModel dynamicUIModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoHeaderImpl : HideableControllerImpl<DynamicUIDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoFooterImpl : HideableControllerImpl<DynamicUIDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
