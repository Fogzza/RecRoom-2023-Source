using System;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class LongbowScreenToolBehaviorConfig : ScreenToolBehaviorConfig<HKFOHCAGONK, LongbowScreenToolBehaviorConfig>
	{
		[Serializable]
		public struct RecoilSettings
		{
			public Vector2 recoilAngle;

			public float recoilDuration;

			public float recoilReturnDuration;

			public static RecoilSettings LCPAMALNCPJ(RecoilSettings BLFKABPCHLN, RecoilSettings NPFMAENOPCH, float IHPJCBCPLCM)
			{
				return default;
			}
		}

		public SerializableBlendedPlayerAnimation chargeAnimationBlend;

		public AdditiveAnimationWeight chargeCameraAnimationWeight;

		public SerializableBlendedPlayerAnimation aimDownSightsChargeAnimationBlend;

		public AdditiveAnimationWeight aimDownSightsChargeCameraAnimationWeight;

		public PlayerAnimation recoilAnimation;

		public ScreenPlayerAimDownSightsSettings aimDownSightsSettings;

		public float maxChargeDuration;

		public AnimationCurve chargeCurve;

		public float maximumRateOfFire;

		public ScreenPlayerRangedWeaponCrosshairSettings unchargedCrosshairSettings;

		public ScreenPlayerRangedWeaponCrosshairSettings chargedCrosshairSettings;

		public bool applyRecoil;

		public AnimationCurve chargeRecoilCurve;

		public RecoilSettings unchargedRecoilSettings;

		public RecoilSettings chargedHipFireRecoilSettings;

		public RecoilSettings chargedADSRecoilSettings;

		public AnimationCurve recoilCurve;

		public AnimationCurve recoilReturnCurve;

		public GHBIAFLJDKB.CameraShakeConfig onFireUnchargedCameraShake;

		public GHBIAFLJDKB.CameraShakeConfig onFireChargedHipFireCameraShake;

		public GHBIAFLJDKB.CameraShakeConfig onFireChargesADSCameraShake;
	}
}
