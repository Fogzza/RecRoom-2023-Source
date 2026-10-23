using System;

namespace RecRoom.Inputs
{
	[Serializable]
	public class SteamVrIndexVRInputHandler : SteamVrInputHandler
	{
		public override bool SupportsAimWalkAndStickWalkSimultaneously => false;

		public override bool SupportsNaturalGrip => false;

		public override bool SupportsTwoStageGrip => false;
	}
}
