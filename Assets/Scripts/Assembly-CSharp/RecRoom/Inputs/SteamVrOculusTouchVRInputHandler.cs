using System;

namespace RecRoom.Inputs
{
	[Serializable]
	public class SteamVrOculusTouchVRInputHandler : SteamVrInputHandler
	{
		public override bool SupportsAimWalkAndStickWalkSimultaneously => false;

		public override bool SupportsNaturalGrip => false;
	}
}
