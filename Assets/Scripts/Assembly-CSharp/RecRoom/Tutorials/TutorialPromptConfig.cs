using System;

namespace RecRoom.Tutorials
{
	[Serializable]
	public class TutorialPromptConfig
	{
		[Flags]
		public enum FJDJFNIIDEA
		{
			NONE = 0,
			HANDEDNESS = 1,
			SCREEN_INPUT_DEVICE = 2,
			VR_LOCOMOTION = 4,
			VR_INPUT_MODE = 8,
			SCREENS = HANDEDNESS | SCREEN_INPUT_DEVICE,
			VR = HANDEDNESS | VR_LOCOMOTION | VR_INPUT_MODE
		}

		[NonSerialized]
		public TutorialPromptGeneralConfig GeneralConfig;

		public TutorialPromptContext.AGKBKJJKKHH TutorialPromptType;

		public ScreensTutorialPromptConfig ScreenInputConfig;

		public VRTutorialPromptConfig VRInputConfig;

		private bool JAIPLDJDEHM()
		{
			return false;
		}

		private bool EAMAHDKPCIM()
		{
			return false;
		}

		private bool COHCDCAGDIN()
		{
			return false;
		}

		private bool KCKJCGKJMCG()
		{
			return false;
		}

		public FJDJFNIIDEA HPKAEFNNEDF()
		{
			return FJDJFNIIDEA.NONE;
		}

		public GLKEAIAEBFF DLMLAEKBFIC(TutorialPromptContext KAGPMIHBLMJ)
		{
			return null;
		}
	}
}
