using System;

namespace RecRoom.Inputs
{
	[Serializable]
	public class InputConfig
	{
		public GamepadInputConfig gamepad;

		public KeyboardMouseInputConfig keyboardMouse;

		public TouchInputConfig touch;
	}
}
