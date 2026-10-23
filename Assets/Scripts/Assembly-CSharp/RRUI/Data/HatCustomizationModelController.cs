using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RRUI.Data
{
	public class HatCustomizationModelController : ModelController<HatCustomizationModel>
	{
		[Serializable]
		private class HatCustomizationCategoriesHideableImpl : HideableControllerImpl<HatCustomizationModel>
		{
			[SerializeField]
			private HatCustomizationModel.HatAdjustmentType categoryType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HatCustomizationCategoryToggleButtonImpl : ToggleControllerImpl<HatCustomizationModel>
		{
			[SerializeField]
			private HatCustomizationModel.HatAdjustmentType categoryType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class UndoButtonImpl : ButtonControllerImpl<HatCustomizationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RedoButtonImpl : ButtonControllerImpl<HatCustomizationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResetButtonImpl : ButtonControllerImpl<HatCustomizationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LegacyButtonImpl : ButtonControllerImpl<HatCustomizationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HelmetHairToggleImpl : ToggleControllerImpl<HatCustomizationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HatAdjustmentSliderImpl : SliderControllerImpl<HatCustomizationModel>
		{
			private const float MIN_SLIDER_CHANGED_DIFFERENCE = 0.01f;

			[SerializeField]
			private HatCustomizationModel.HatAdjustmentType adjustment;

			[SerializeField]
			private HatCustomizationModel.UVPositionAxis uvAxis;

			[SerializeField]
			private HatCustomizationModel.PositionOffsetAxis positionOffsetAxis;

			[SerializeField]
			private HatCustomizationModel.RotationOffsetAxis rotationOffsetAxis;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void FHPNDLFMODO(float IPMIIEAGJKC)
			{
			}

			protected override void JGFPOMHLIJO(BaseEventData GGMPLAIGLHP)
			{
			}

			private bool CECINGKOCHM()
			{
				return false;
			}

			private float MAOJPJDFEPB()
			{
				return 0f;
			}

			private void EAFNAKILCGB(float IPMIIEAGJKC)
			{
			}
		}
	}
}
