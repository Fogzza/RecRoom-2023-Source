using System;

namespace RecRoom.Inputs
{
	[Serializable]
	public class ButtonSettings
	{
		public enum PHCOEFAHLNF
		{
			SIMPLE = 0,
			HAIR_TRIGGER = 1
		}

		public enum LOEANEIHIKN
		{
			TOUCH_PRESSED = 0,
			AXIS_BUTTON = 1
		}

		public PHCOEFAHLNF axisButtonType;

		public float minAxisButtonHoldValue;

		public LOEANEIHIKN touchAxisButtonType;

		public float touchAxisButtonMinValue;
	}
}
