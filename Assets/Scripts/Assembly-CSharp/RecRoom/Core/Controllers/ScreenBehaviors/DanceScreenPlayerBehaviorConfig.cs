using RecRoom.Core.Screens.PlayerController;
using RecRoom.MathUtils.Springs;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class DanceScreenPlayerBehaviorConfig : ScreenPlayerBehaviorConfig<IJLDLBJBOHD, DanceScreenPlayerBehaviorConfig>
	{
		public SimpleSpring6DConfig DefaultInputSpring;

		public PlayerAnimation3DBlendedPoseSet[] BlendedPoses;

		public WeightedPlayerAnimationData AnimationSettings;

		public ScreenPlayerCameraSettings HighEnergyCameraSettings;

		public ScreenPlayerCameraSettings LowEnergyCameraSettings;

		public float CameraBlendTime;

		public float mouseSensitivity;
	}
}
