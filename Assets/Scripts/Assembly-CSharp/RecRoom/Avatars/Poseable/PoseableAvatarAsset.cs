using RecRoom.Core.Imposters;
using RecRoom.Players;
using UnityEngine;

namespace RecRoom.Avatars.Poseable
{
	public class PoseableAvatarAsset : ScriptableObject
	{
		[SerializeField]
		public PlayerAnimationFrameData PoseData;

		[SerializeField]
		public PlayerEmotes.PDHFIKBMGOD Emote;

		[SerializeField]
		public float EmoteNormalizedTime;

		[SerializeField]
		public ImposterRenderConfig RenderConfiguration;

		public ILKAJHIJEJK Pose => default;
	}
}
