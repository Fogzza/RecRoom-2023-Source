using System;
using AGUI.StackedUI.Dialog;
using RecNet;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom
{
	public class FeedbackSettings : ScriptableObject
	{
		[Serializable]
		public struct StyleSettings
		{
			public RoomComment.LDMAFFPGJCL Style;

			public Color TextColor;

			public Color BackgroundColor;

			public Color ProxyIconReadColor;

			public Color ProxyIconUnreadColor;

			public Sprite ProxyIconSprite;

			public float DateTextWeightModifier;

			public float MessageTextWeightModifier;
		}

		private sealed class LAJJAKHJBLK
		{
			public RoomComment.LDMAFFPGJCL style;

			internal bool _003CGetStyleSettings_003Eb__0(StyleSettings x)
			{
				return false;
			}
		}

		[SerializeField]
		private RoomCommentView roomCommentViewPrefab;

		[SerializeField]
		private RoomCommentInputUIDialog roomCommentTextInputUI;

		[SerializeField]
		private int roomCommentMaxLength;

		[SerializeField]
		private float roomCommentPlacementDistanceVR;

		[SerializeField]
		private float roomCommentPlacementDistanceScreensTouch;

		[SerializeField]
		private int roomCommentsRateLimitingMaxEventsPerWindow;

		[SerializeField]
		private float roomCommentsRateLimitingWindowDuration;

		[SerializeField]
		private float roomCommentOpenDuration;

		[SerializeField]
		private float roomCommentCloseDuration;

		[SerializeField]
		private float roomCommentTeleportOffsetDistance;

		[SerializeField]
		private StyleSettings[] styleSettings;

		[SerializeField]
		private RecRoomAudioClip openCommentAudioClip;

		[SerializeField]
		private RecRoomAudioClip closeCommentAudioClip;

		[SerializeField]
		private RecRoomAudioClip createCommentAudioClip;

		[SerializeField]
		private RecRoomAudioClip deleteCommentAudioClip;

		public RoomCommentView RoomCommentViewPrefab => null;

		public RoomCommentInputUIDialog RoomCommentTextInputUI => null;

		public int RoomCommentMaxLength => 0;

		public float RoomCommentPlacementDistanceVR => 0f;

		public float RoomCommentPlacementDistanceScreensTouch => 0f;

		public int RoomCommentsRateLimitingMaxEventsPerWindow => 0;

		public float RoomCommentsRateLimitingWindowDuration => 0f;

		public float RoomCommentOpenDuration => 0f;

		public float RoomCommentCloseDuration => 0f;

		public float RoomCommentTeleportOffsetDistance => 0f;

		public RecRoomAudioClip OpenCommentAudioClip => null;

		public RecRoomAudioClip CloseCommentAudioClip => null;

		public RecRoomAudioClip CreateCommentAudioClip => null;

		public RecRoomAudioClip DeleteCommentAudioClip => null;

		public StyleSettings CKBBMMHBBEA(RoomComment.LDMAFFPGJCL IECPKMLJDCJ)
		{
			return default;
		}
	}
}
