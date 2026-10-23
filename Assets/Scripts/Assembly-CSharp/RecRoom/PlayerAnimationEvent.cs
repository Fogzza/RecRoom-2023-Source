using System;

namespace RecRoom
{
	[Serializable]
	public struct PlayerAnimationEvent
	{
		public enum BKEAPIGNCKG
		{
			ANY = -1,
			NONE = 0,
			DROP_TOOL = 1,
			THROW_TOOL = 2,
			CUSTOM_ACTION_1 = 3,
			CUSTOM_ACTION_2 = 4,
			CUSTOM_ACTION_3 = 5,
			LOCOMOTION_ACTION_1 = 1000,
			LOCOMOTION_ACTION_2 = 1001
		}

		public float Time;

		public BKEAPIGNCKG EventType;
	}
}
