using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class RangedWeaponScreenToolBehaviorConfig : ScreenToolBehaviorConfig<IBFNDDLNDHM, RangedWeaponScreenToolBehaviorConfig>
	{
		public PlayerAnimation preFireAnimation;

		public PlayerAnimation recoilAnimation;

		public bool blockFireAnimation;

		public bool supportsAimDownSights;

		public ScreenPlayerAimDownSightsSettings aimDownSightsSettings;

		public bool runsUntilInputUp;

		public bool disarmOnTotalAmmoExhaustion;

		public float maximumRateOfFire;

		public bool continuousFireWhileTouchHeld;

		public bool continuousFireWithGamepad;

		public bool hasCustomContinuousFireRate;

		public float continuousFireRate;

		public bool supportsAutoFire;

		public float minAutoFireTargetAcquisitionTime;

		public float minAutoFireHoldDuration;

		public float aimAssistFrictionRadiusMultiplier;

		public float aimAssistAutoFireRadiusMultiplier;

		public bool aimAssistBulletMagnetismSupported;

		public bool aimAssistStickyStrafeSupported;

		public bool useAimAssistBulletExpansion;

		public float aimAssistBulletExpansionScale;

		public float minAimTargetDistanceInVehicle;

		public float defaultAimTargetDistanceInVehicle;

		public PlayerAnimation reloadAnimation;

		public ScreenPlayerRangedWeaponCrosshairSettings crosshairSettings;

		public bool hideReticle;

		public ScreenPlayerRangedWeaponAccuracySettings accuracySettings;

		public bool shootTowardsGazeTarget;

		public PlayerAnimation weaponBreakAnimation;

		public RecRoomAudioClip weaponBreak2DAudio;

		public bool applyRecoil;

		public Vector2 recoilAngle;

		public AnimationCurve recoilCurve;

		public float recoilDuration;

		public AnimationCurve recoilReturnCurve;

		public float recoilReturnDuration;

		public GHBIAFLJDKB.CameraShakeConfig onFireCameraShake;
	}
}
