using System;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class WhipScreenToolBehaviorConfig : ScreenToolBehaviorConfig<NGJLFLIIJPA, WhipScreenToolBehaviorConfig>
	{
		[Serializable]
		public class LightAttack
		{
			public PlayerAnimation UncoilAnimation;

			public PlayerAnimation UncoiledLoopAnimation;

			public PlayerAnimation CrackAnimation;

			public float NormalizedDamage;
		}

		[Serializable]
		public struct GazeOffsetFudge
		{
			public float gazeDistance;

			public Vector3 offset;
		}

		public LightAttack[] lightAttackCombo;

		public float maxLightAttackComboWindow;

		public float lightAttackUncoilSpeed;

		public bool lightAttackWhipPopperUsesGravity;

		public PlayerAnimation chargeAttackLoopAnimation;

		public PlayerAnimation chargeAttackUncoilIntroAnimation;

		public PlayerAnimation chargeAttackUncoilLoopAnimation;

		public PlayerAnimation chargeAttackCrackAnimation;

		public float chargeAttackUncoilSpeed;

		public bool chargeAttackWhipPopperUsesGravity;

		public GazeOffsetFudge[] offsetFudges;

		public GHBIAFLJDKB.CameraShakeConfig attackImpactCameraShake;

		public float minUncoilingDistance;

		public float maxUncoilingDistance;

		public float minCrackSpeed;

		public float maxCrackSpeed;
	}
}
