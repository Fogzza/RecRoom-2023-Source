using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class DrawingSurfaceScreenPlayerBehaviorConfig : ScreenPlayerBehaviorConfig<BOHAPFEPOPH, DrawingSurfaceScreenPlayerBehaviorConfig>
	{
		public float desiredSurfaceNormalDistance;

		public ScreenPlayerCameraSettings drawingCameraSettings;

		public float nearClipPlaneMaxDistFromSurface;

		public float cameraTransitionDuration;

		public ScreenPlayerCursorSettings penPlacementCursorSettings;

		public Vector3 penPlacementRotationOffsetEuler;

		public float minDistanceFromSurface;

		public float maxDistanceFromSurface;

		public float minSquareAspectRatio;

		public float maxSquareAspectRatio;

		public float screenFitBufferFraction;

		[Space]
		public float canvasMaxLinearMovement;

		public float canvasMaxAngularMovement;

		public float mouseZoomDeltaScroll;

		public float gamepadZoomSpeed;

		public float gamepadPanSpeed;

		public float keyboardRollSpeed;

		public float gamepadRollSpeed;

		public AnimationCurve touchPressureCurve;

		public PlayerAnimation idleAnimationLoop;
	}
}
