using System;
using RecRoom.Audio;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class MeleeWeaponScreenToolBehaviorConfig : ScreenToolBehaviorConfig<OLBEAOKPKGO, MeleeWeaponScreenToolBehaviorConfig>
	{
		[Serializable]
		public class LightAttack
		{
			public PlayerAnimation Animation;

			public AdditiveAnimationWeight CameraWeight;

			public float NormalizedDamage;
		}

		[Serializable]
		public class ChargeAttack
		{
			public PlayerAnimation IntroAnimation;

			public AdditiveAnimationWeight IntroCameraWeight;

			public PlayerAnimation LoopAnimation;

			public AdditiveAnimationWeight LoopCameraWeight;

			public PlayerAnimation ReleaseAnimation;

			public AdditiveAnimationWeight ReleaseCameraWeight;

			public PlayerAnimation OutroAnimation;

			public AdditiveAnimationWeight OutroCameraWeight;

			public float NormalizedDamage;

			public float RequiredChargeDuration;
		}

		public LightAttack[] lightAttackCombo;

		public float maxLightAttackComboWindow;

		public RecRoomAudioClip swingSFX;

		public RecRoomAudioClip heavySwingSFX;

		public RecRoomAudioClip chargeStartSFX;

		public RecRoomAudioClip chargeReleaseSFX;

		public float lightAttackWalkSpeedMultiplier;

		public bool supportsChargeAttack;

		public ChargeAttack chargeAttack;

		public float chargeAttackWalkSpeedMultiplier;

		public float chargeAttackReleaseWalkSpeedMultiplier;

		public bool supportsBlock;

		public PlayerAnimation[] blockComboAnimations;

		public float maxBlockComboWindow;

		public PlayerAnimation weaponBreakAnimation;

		public RecRoomAudioClip weaponBreak2DAudio;

		public GHBIAFLJDKB.CameraShakeConfig attackImpactCameraShake;

		public GHBIAFLJDKB.CameraShakeConfig attackBlockCameraShake;
	}
}
