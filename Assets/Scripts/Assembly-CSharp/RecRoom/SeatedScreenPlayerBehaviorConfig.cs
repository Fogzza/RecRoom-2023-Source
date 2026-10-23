using System;
using RecRoom.Core;
using RecRoom.Core.Controllers.ScreenBehaviors;
using UnityEngine;

namespace RecRoom
{
	public class SeatedScreenPlayerBehaviorConfig : ScreenPlayerBehaviorConfig<IFEBAGHFDLN, SeatedScreenPlayerBehaviorConfig>
	{
		[Serializable]
		public class RecenterConfig
		{
			public float maxSpeed;

			public float smoothTime;

			public float delay;

			public float maxAngle;
		}

		public float cameraRollSmoothTime;

		public AnimationCurve cameraRollRemapCurve;

		public float cameraPitchSmoothTime;

		public AnimationCurve cameraPitchRemapCurve;

		public RecenterConfig recenterConfig;

		public ScreenPlayerCameraSettings RapidlyAcceleratingCameraSettings;

		public bool UseSeparateRapidlyAcceleratingCameraSettingsWhenFacingBackwards;

		public ScreenPlayerCameraSettings RapidlyAcceleratingCameraSettingsBackwards;

		public float RapidlyAcceleratingCameraSettingsFadeInDuration;

		public float RapidlyAcceleratingCameraSettingsFadeOutDuration;

		public float SeatedCameraMaxRotationFromForward;

		public ScreenPlayerCameraSettings SeatedCameraSettings;

		public AnimationCurve LeanRadiusByLeanAngle;

		public float MaxLeanRadius;

		public AnimationCurve LeanHeadRollAngleByLeanAngle;

		public float MaxHeadRollAngle;

		public float LeanSmoothTime;

		public float LeanReturnSmoothTime;

		public bool forceToThirdPerson;

		public Vector3 thirdPersonTargetToPivotOffset;
	}
}
