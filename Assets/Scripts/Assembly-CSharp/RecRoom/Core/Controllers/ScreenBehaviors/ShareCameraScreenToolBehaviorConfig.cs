using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class ShareCameraScreenToolBehaviorConfig : ScreenToolBehaviorConfig<DNDHLBENHFB, ShareCameraScreenToolBehaviorConfig>
	{
		public ScreenPlayerCameraSettings framingForwardCameraSettings;

		public float cameraTransitionDuration;

		public float selfieCameraFadeDuration;

		public AnimationCurve shareCamOffsetFromMainCameraByAspectRatio;

		public float collisionSphereRadius;

		public float collisionAdjustedMinDistanceFromCamera;

		public MIPKGIMPMPO.SelfieModeSettings selfieModeSettings;

		public PlayerAnimation loopingAnimation;

		public Vector3 offhandPosition;

		public Vector3 offhandRotation;
	}
}
