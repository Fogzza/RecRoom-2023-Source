using System;
using Valve.VR;

namespace RecRoom.Inputs
{
	[Serializable]
	public class SteamVrViveVRInputHandler : SteamVrInputHandler
	{
		private SteamVR_Action_Boolean RotateTouchButtonAction;

		private SteamVR_Action_Boolean RotatePressButtonAction;

		public AxisSwipeButtons RotateAxisSwipeButtons;

		private bool touchDownInDeadZone;

		private AxisSwipeButtons.HPNNNBDBBDB lastSwipeState;

		private AxisSwipeButtons.HPNNNBDBBDB currentSwipeState;

		private int lastHapticFrame;

		private const int HAPTIC_REFRESH_FRAMES = 30;

		public override bool SupportsTouchpadTeleport => false;

		protected override void OPMEDJKHIDF(ref HGLAMAFCPPN DADHJJNJEFA)
		{
		}

		protected override void PGLAHOCNCON(float DOEJGDJILAD, bool HIFDJFBEADN)
		{
		}
	}
}
