using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RRUI.Data
{
	public class FaceTransformationModelController : ModelController<FaceTransformationModel>
	{
		public enum BODCIKKHDEP
		{
			Move = 0,
			Scale = 1
		}

		[Serializable]
		private class FaceTransformationButtonImpl : ButtonControllerImpl<FaceTransformationModel>
		{
			[SerializeField]
			private BODCIKKHDEP transformation;

			[SerializeField]
			private BFEBAPPNHIJ positionDirection;

			[SerializeField]
			private FEIDFGFGJBO scaleDirection;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class UndoButtonImpl : ButtonControllerImpl<FaceTransformationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RedoButtonImpl : ButtonControllerImpl<FaceTransformationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResetToDefaultButtonImpl : ButtonControllerImpl<FaceTransformationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RotationXSliderImpl : SliderControllerImpl<FaceTransformationModel>
		{
			private enum JMLGOFHFEAN
			{
				HORIZONTAL = 0,
				VERTICAL = 1
			}

			[SerializeField]
			private BODCIKKHDEP transformation;

			[SerializeField]
			private JMLGOFHFEAN positionAxis;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void FHPNDLFMODO(float IPMIIEAGJKC)
			{
			}

			protected override void JGFPOMHLIJO(BaseEventData GGMPLAIGLHP)
			{
			}

			private float MAOJPJDFEPB()
			{
				return 0f;
			}

			private void EAFNAKILCGB(float IPMIIEAGJKC)
			{
			}
		}

		private const float OKFGBOFDPOH = 0.01f;
	}
}
