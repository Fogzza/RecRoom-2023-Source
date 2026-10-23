using System;
using UnityEngine;

namespace RecRoom
{
	[Serializable]
	public class SerializableBlendedPlayerAnimationAssets : BaseBlendedPlayerAnimationAssets
	{
		[Serializable]
		private struct BlendedAnimationData
		{
			public PlayerAnimationAsset Animation;

			public float FullBlendParameter;
		}

		[SerializeField]
		private BlendedAnimationData[] animations;

		protected override int KBADJLINDHB()
		{
			return 0;
		}

		protected override HDMAJJEAGJB BDMFHHCHHHM(int GMEHLIHLGEH)
		{
			return null;
		}

		protected override float KKACPOIEJNF(int GMEHLIHLGEH)
		{
			return 0f;
		}
	}
}
