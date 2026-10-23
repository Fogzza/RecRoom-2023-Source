using UnityEngine;

namespace RecRoom.Core
{
	public sealed class ScreenAimAssistSettings : ScriptableObject
	{
		public float maxTargetDistance;

		public float frictionRadius;

		public float frictionScaleGamepad;

		public float frictionScaleTouch;

		public float stickyStrafeRadius;

		public float stickyStrafeMinDistance;

		public float stickyStrafeMaxDistance;

		public float stickyStrafeMinMultiplier;

		public float stickyStrafeMaxMultiplier;

		public AnimationCurve stickyStrafeMultiplierOverDistanceCurve;

		public float bulletMagnetismRadius;

		public float autoFireRadius;
	}
}
