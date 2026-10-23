using System;

namespace RecRoom.Inputs
{
	[Serializable]
	public class ControlConfig
	{
		public InputConfig inputConfig;

		public ButtonSettings buttonSettings;

		public Axis2DSettings axisSettings;
	}
}
