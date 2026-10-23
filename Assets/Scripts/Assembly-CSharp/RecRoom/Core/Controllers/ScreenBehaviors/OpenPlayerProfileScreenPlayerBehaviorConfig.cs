using RecRoom.Tutorials;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class OpenPlayerProfileScreenPlayerBehaviorConfig : ScreenPlayerBehaviorConfig<NCGFHMHNKIK, OpenPlayerProfileScreenPlayerBehaviorConfig>
	{
		public float precisePhaseHz;

		public float preciseMaxDistance;

		public float preciseRadius;

		[Space]
		public float broadPhaseHz;

		public float broadMaxDistance;

		public float broadRadius;

		[Space]
		public float maxViewportDistanceFromReticle;

		public float requiredInputHoldTime;

		public float tutorialDelay;

		public float tutorialMaxDistance;

		public float tutorialGazeDotThreshold;

		public TutorialPromptContext viewPlayerProfileTutorialPrompt;
	}
}
