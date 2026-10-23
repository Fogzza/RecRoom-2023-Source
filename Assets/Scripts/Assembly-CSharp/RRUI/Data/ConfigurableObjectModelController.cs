using System;
using UnityEngine;

namespace RRUI.Data
{
	public class ConfigurableObjectModelController : ModelController<ConfigurableObjectModel>
	{
		[Serializable]
		private class FriendlyNameTextImpl : TextControllerImpl<ConfigurableObjectModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SubtitleTextImpl : TextControllerImpl<ConfigurableObjectModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ValuesDontMatchImpl : HideableControllerImpl<ConfigurableObjectModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ConfigureDynamicUIImpl : ControllerImplementation<ConfigurableObjectModel>
		{
			[SerializeField]
			private DynamicUIModel dynamicUIModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CollapseAll : ButtonControllerImpl<ConfigurableObjectModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ExpandAll : ButtonControllerImpl<ConfigurableObjectModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_HideIfCurrentConfigurableNull : HideableControllerImpl<ConfigurableObjectModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_ShowIfCurrentConfigurableIsNotNull : HideableControllerImpl<ConfigurableObjectModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ResetObjectProperties : ButtonControllerImpl<ConfigurableObjectModel>
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
