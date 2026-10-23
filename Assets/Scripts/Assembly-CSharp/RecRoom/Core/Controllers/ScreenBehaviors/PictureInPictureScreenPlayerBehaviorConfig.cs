using RecRoom.Core.Imposters;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class PictureInPictureScreenPlayerBehaviorConfig : ScreenPlayerBehaviorConfig<FOMEKOMHGCN, PictureInPictureScreenPlayerBehaviorConfig>
	{
		public float CameraFieldOfView;

		public float CameraMinDistanceFromHead;

		public float CameraHeightOffsetFromHead;

		public float CameraMaxBoundsRadius;

		public float CameraNearPlane;

		public float CameraFarPlane;

		public LayerMask PictureInPictureCullingMask;

		public bool UseRenderPass;

		public bool ApplyCustomLighting;

		public ImposterRenderConfig ImposterRenderConfig;

		public float PlayerBoundsMargin;

		public float PlayerBoundsSmoothSpeed;

		public float PlayerYawSmoothSpeed;

		public float HeightOffsetMultiplier;

		public float ScaleDistanceInfluence;

		public int RenderResolutionSize;

		public AnimationCurve VerticalFadeMaxByBoundsOffsetMinY;

		public float VerticalMaskFadeRange;

		public float VerticalFadeInSmoothSpeed;

		[Space]
		public AnimationCurve PiPFramerateByGameFramerate;

		public int PiPMaxFramerate;

		public int PiPMinFramerate;
	}
}
