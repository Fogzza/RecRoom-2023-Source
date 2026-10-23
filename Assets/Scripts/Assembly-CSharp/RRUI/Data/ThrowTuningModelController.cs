using System;
using UnityEngine;

namespace RRUI.Data
{
	public class ThrowTuningModelController : ModelController<ThrowTuningModel>
	{
		private enum CBLGEGODPHJ
		{
			Linear = 0,
			Angular = 1
		}

		public enum JHMKNOGDDNC
		{
			Direction = 0,
			Magnitude = 1
		}

		[Serializable]
		private class VelocityMultiplierSliderImpl : SliderControllerImpl<ThrowTuningModel>
		{
			[SerializeField]
			private CBLGEGODPHJ VelocityType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void FHPNDLFMODO(float IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class RollbackDirectionRangeSliderImpl : RangeSliderControllerImpl<ThrowTuningModel>
		{
			[SerializeField]
			private JHMKNOGDDNC RollbackType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void ADGEIDHGCDA(float DJNOOBMNBFK, float LHFPANIHENE)
			{
			}
		}

		[Serializable]
		private class VelocityAverageMethodRadioButtonsImpl : ToggleControllerImpl<ThrowTuningModel>
		{
			[SerializeField]
			private CBLGEGODPHJ VelocityType;

			[SerializeField]
			private ControllerVelocitySettings.IONOMPNPLLB VelocityAverageMethod;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RollbackInfoButtonImpl : ButtonControllerImpl<ThrowTuningModel>
		{
			[SerializeField]
			private JHMKNOGDDNC RollbackType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}
	}
}
