using RecRoom.Core.Imposters;
using UnityEngine;

namespace RecRoom.Avatars.Poseable
{
	public class PoseableAvatarConfig : ScriptableObject
	{
		[SerializeField]
		public PoseableAvatarPuppet PuppetPrefab;

		[SerializeField]
		public ImposterRenderConfig GeneralRenderConfig;

		[SerializeField]
		public PoseableAvatarAsset[] Poses;

		[SerializeField]
		public PoseableAvatarAsset OutfitPose;

		[SerializeField]
		public int ImageResolution;

		[SerializeField]
		public int DropShadowDownsampleIterations;

		[SerializeField]
		public Material DropShadowMaterial;
	}
}
