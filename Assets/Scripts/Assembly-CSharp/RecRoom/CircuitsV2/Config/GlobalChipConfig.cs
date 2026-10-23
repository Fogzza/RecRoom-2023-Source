using System;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class GlobalChipConfig
	{
		[SerializeField]
		private Color chipTextColor;

		[SerializeField]
		private Color deprecatedChipTextColor;

		[SerializeField]
		private float resetAnimationDurationSeconds;

		[SerializeField]
		private AnimationCurve resetAnimationCurve;

		[SerializeField]
		private Color resetAnimationTargetColor;

		public Color ChipTextColor => default;

		public Color DeprecatedChipTextColor => default;

		public float ResetAnimationDurationSeconds => 0f;

		public AnimationCurve ResetAnimationCurve => null;

		public Color ResetAnimationTargetColor => default;
	}
}
