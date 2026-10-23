using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class GunHandleScreenToolBehaviorConfig : ScreenToolBehaviorConfig<LAOKKLKBGGG, GunHandleScreenToolBehaviorConfig>
	{
		public ScreenPlayerAimDownSightsSettings aimDownSightsSettings;

		public float minAutoFireTargetAcquisitionTime;

		public float minAutoFireHoldDuration;

		public float aimAssistFrictionRadiusMultiplier;

		public float aimAssistAutoFireRadiusMultiplier;

		public bool aimAssistStickyStrafeSupported;

		public AnimationCurve recoilCurve;

		public AnimationCurve recoilReturnCurve;
	}
}
