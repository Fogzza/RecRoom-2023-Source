using System;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public sealed class ToolMenuPerHandScreenPlayerBehaviorConfig : PerHandScreenPlayerBehaviorConfig<GDKCKIFDNAB, ToolMenuPerHandScreenPlayerBehaviorConfig>
	{
		[Serializable]
		public class MoveableToolMenusConfig
		{
			[SerializeField]
			public float[] RadialXAngleStops;

			[SerializeField]
			public int InitialRadialXAngleStopIndex;

			[SerializeField]
			public float RadialXAngleTransitionTime;

			[SerializeField]
			public float InitialRadialYAngle;

			[SerializeField]
			public bool MirrorInitialRadialYAngleForLeftHand;

			[SerializeField]
			public float RadialYAngleIncrement;

			[SerializeField]
			public float RadialYAngleTransitionTime;

			[SerializeField]
			public float RadialDistance;

			[SerializeField]
			public Vector3 MenuSpacePivotOffset;

			[SerializeField]
			public float MenuPositionFollowDistanceMax;

			[SerializeField]
			public bool MenuPositionFollowLockYAxis;

			[SerializeField]
			public float MenuPositionFollowTime;

			[SerializeField]
			public float MenuPositionFallBehindTime;

			[SerializeField]
			public float PlayerDeadZoneRadius;

			[SerializeField]
			public bool PlayerDeadZoneLockYAxis;
		}

		[SerializeField]
		public MoveableToolMenusConfig MoveableToolMenus;
	}
}
