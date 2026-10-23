using System;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class DynamicFooterElementsDialogModelController : InterfaceModelController<CIAOBLFFGAB>
	{
		[Serializable]
		private class FooterElementsToDynamicUIImpl : ControllerImplementation<CIAOBLFFGAB>
		{
			[SerializeField]
			private DynamicUIModel dynamicUIModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoFooterImpl : HideableControllerImpl<CIAOBLFFGAB>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FooterLayoutImpl : ControllerImplementation<CIAOBLFFGAB>
		{
			[SerializeField]
			private HorizontalOrVerticalLayoutGroup layoutGroup;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
