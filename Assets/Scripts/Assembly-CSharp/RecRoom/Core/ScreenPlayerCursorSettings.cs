using UnityEngine;

namespace RecRoom.Core
{
	public class ScreenPlayerCursorSettings : ScriptableObject
	{
		public Sprite CursorSpriteMouse;

		public float CursorSpriteViewportSizeMouse;

		public Vector2 CursorSpritePivotMouse;

		public Sprite CursorSpriteTouch;

		public float CursorSpriteViewportSizeTouch;

		public Vector2 CursorSpritePivotTouch;

		public Sprite CursorSpriteGamepad;

		public float CursorSpriteViewportSizeGamepad;

		public Vector2 CursorSpritePivotGamepad;

		public float MaxSpeedViewportSpaceGamepad;

		public float AccelerationTimeGamepad;

		public float DecelerationTimeGamepad;

		public float OverTargetFrictionScaler;

		public float OverTargetSpeedReturnDelay;
	}
}
