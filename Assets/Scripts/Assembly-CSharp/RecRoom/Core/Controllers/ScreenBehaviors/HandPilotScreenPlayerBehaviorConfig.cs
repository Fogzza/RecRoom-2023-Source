using RecRoom.Core.Animation;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class HandPilotScreenPlayerBehaviorConfig : PerHandScreenPlayerBehaviorConfig<EBPLFGOHPCE, HandPilotScreenPlayerBehaviorConfig>
	{
		public WeightedPlayerAnimationData animationSettings;

		public HandPilotingAnimationPoseSet openHandPoseSet;

		public HandPilotingAnimationPoseSet pointPoseSet;

		public HandPilotingAnimationPoseSet thumbsUpPoseSet;

		public HandPilotingAnimationPoseSet fistBumpPoseSet;

		[Space]
		public HandPilotingAnimationPoseSet thumbsDownPoseSet;

		public HandPilotingAnimationPoseSet handshakePoseSet;

		[Space]
		public HandPilotingAnimationPoseSet toolOpenHandPoseSet;

		public float reachSmoothTime;

		public float gamepadWaveSmoothTime;

		public float keyboardTouchWaveSmoothTime;

		public float HeadOffsetSmoothTime;

		public float HeadOffsetUpMultiplier;

		public float HeadOffsetDownMultiplier;

		public float HeadOffsetLeftRightMultiplier;

		public float HeadOffsetForwardBackwardMultiplier;

		public float HeadOffsetUpToPitchDegrees;

		public float HeadOffsetRightToYawDegrees;

		public float HeadOffsetForwardToYawDegrees;

		public float HandUpDisplacementToRollDegrees;

		public float HeadMotionToCameraMotionMultiplier;

		public float handCollisionRadius;

		public float wavingTimeoutDelay;

		public float touchWavingTimeoutDelay;

		public float mouseJoystickSpeed;

		public AnimationCurve mouseJoystickCurve;

		public bool debugWave;

		public bool debugReach;

		public float debugReachAxis;
	}
}
