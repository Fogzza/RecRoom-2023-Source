using System;
using System.Collections.Generic;
using RRUI.Data;
using RRUI.Theme;
using UnityEngine;
using UnityEngine.Localization;

namespace RRUI.Models.Statsig
{
	public class StatsigModelController : ModelController<StatsigModel>
	{
		[Serializable]
		private class DisplayOrderPriorityImpl : ControllerImplementation<StatsigModel>
		{
			[SerializeField]
			private StatsigModel.StatsigSortableTransform[] sortableTransforms;

			[SerializeField]
			private bool useLayer;

			[SerializeField]
			private string experimentName;

			[SerializeField]
			private string layerName;

			[SerializeField]
			private string experimentOverrideConfigName;

			[SerializeField]
			private string transformOrderParameter;

			private Dictionary<string, StatsigModel.StatsigSortableTransform> transformDict;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		private abstract class DualValuedStatsigTextImpl : TextControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string parameterTrueText;

			[SerializeField]
			private string parameterFalseText;

			[SerializeField]
			private LocalizedString parameterTrueLocText;

			[SerializeField]
			private LocalizedString paramaterFalseLocText;

protected abstract bool UseTrueText
{
get ;
}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SetTextBasedOnExperimentBoolImpl : DualValuedStatsigTextImpl
		{
			[SerializeField]
			private string experimentName;

			[SerializeField]
			private string boolParameterName;

			protected override bool UseTrueText => false;
		}

		[Serializable]
		private class SetTextBasedOnFeatureGateImpl : DualValuedStatsigTextImpl
		{
			[SerializeField]
			private string featureGate;

			protected override bool UseTrueText => false;
		}

		[Serializable]
		private class SetTextBasedOnLayerParameterImpl : TextControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string layerName;

			[SerializeField]
			private string parameterName;

			[SerializeField]
			private float defaultValue;

			[SerializeField]
			private string formatString;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SetButtonTypeBasedOnExperimentBoolImpl : ButtonControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string experimentName;

			[SerializeField]
			private string boolParameterName;

			[SerializeField]
			private EEMHKKCPPNI buttonType;

			private ButtonTheme _buttonTheme;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfSortableTransformNotInludedInTestGroupImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string statsigTransformName;

			[SerializeField]
			private bool useLayer;

			[SerializeField]
			private string experimentName;

			[SerializeField]
			private string layerName;

			[SerializeField]
			private string parameterName;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfFeatureGateActiveImpl : FeatureGateActiveHideableImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfFeatureGateNotActiveImpl : FeatureGateActiveHideableImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private abstract class FeatureGateActiveHideableImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string featureGate;

			protected bool OOMGKNPLHBP()
			{
				return false;
			}
		}

		[Serializable]
		private class HideIfExperimentParamTrueImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string experimentName;

			[SerializeField]
			private string parameterName;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfExperimentParamFalseImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string experimentName;

			[SerializeField]
			private string parameterName;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLayerParamTrueImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string layerName;

			[SerializeField]
			private string parameterName;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLayerParamFalseImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string layerName;

			[SerializeField]
			private string parameterName;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLayerParamsFalseImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string layerName;

			[SerializeField]
			private string[] parameterNames;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLayerParamEqualStringImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string layerName;

			[SerializeField]
			private string parameterName;

			[SerializeField]
			private string value;

			[SerializeField]
			private string defaultValue;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLayerParamNotEqualStringImpl : HideableControllerImpl<StatsigModel>
		{
			[SerializeField]
			private string layerName;

			[SerializeField]
			private string parameterName;

			[SerializeField]
			private string value;

			[SerializeField]
			private string defaultValue;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
