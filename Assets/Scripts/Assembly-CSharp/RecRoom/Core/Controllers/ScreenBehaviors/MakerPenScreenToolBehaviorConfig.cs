using RecRoom.Audio;
using RecRoom.Core.Animation;
using RecRoom.Core.Creation.Screens;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class MakerPenScreenToolBehaviorConfig : ScreenToolBehaviorConfig<MAKLDLJIMFP, MakerPenScreenToolBehaviorConfig>
	{
		public ScreenPlayerCameraSettings cameraSettings;

		public WeightedPlayerAnimationData animationSettings;

		public HandPilotingAnimationPoseSet animationPoseSet;

		public float animationSpringTime;

		public PlayerAnimation menuAnimationLoop;

		public AnimationCurve selfScaleFOVbyScale;

		public float proUXPivotDistance;

		public float proUXPanRatio;

		public float proUXZoomRatio;

		public float proUXOrbitRatio;

		public float proUXZoomScrollStep;

		public float minFocusScreenFill;

		public float maxFocusScreenFill;

		public float startMoveUp;

		public float proUXCreationDistance;

		public float proUXMinZoomDistance;

		public bool hideMakerPen;

		public bool allowInfiniteZoom;

		public bool resetPivotOnWASD;

		public bool hideMouseOnMove;

		public ScreenPlayerCursorSettings proUXStationaryCursor;

		public ScreenPlayerCursorSettings proUXMoveCursor;

		public RecRoomAudioClip toolChangeAudio;

		public ScreenCreationController creationController;
	}
}
