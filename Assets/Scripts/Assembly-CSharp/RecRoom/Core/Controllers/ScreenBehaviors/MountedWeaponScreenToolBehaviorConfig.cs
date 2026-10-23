using RecRoom.Inputs;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public abstract class MountedWeaponScreenToolBehaviorConfig<Runtime, Config> : ScreenToolBehaviorConfig<Runtime, Config> where Runtime : global::DHLJKDHGPCC<Runtime, Config>, new() where Config : MountedWeaponScreenToolBehaviorConfig<Runtime, Config>
	{
		public SerializableBlendedPlayerAnimation aimingAnimation;

		public SerializableBlendedPlayerAnimation fireAnimation;

		public SerializableBlendedPlayerAnimation recoilAnimation;

		public bool loopFireAnimation;

		public ScreenPlayerCameraSettings cameraSettings;

		public float cameraFadeTime;

		public float maxCameraRotationSpeed;

		public float maxPlayerTranslateSpeed;

		public float maxPlayerRotateSpeed;

		public float aimSpeed;

		public float aimSmoothTime;

		public ScreensCameraInputGamepadSettings aimInputSettings;

		public float walkAwayDistance;
	}
}
