using System;
using UnityEngine;

namespace RecRoom.Core.ImageEffects
{
	public class PostProcessVolumeSettings : MonoBehaviour
	{
		[Serializable]
		public class PlatformSettings
		{
			public enum PKALMPFEDPB
			{
				Any = 0,
				VR = 1,
				Screens = 2
			}

			public PKALMPFEDPB PlayerContext;

			public RuntimePlatform[] Platforms;

			public bool bloomEnabled;
		}

		private sealed class POOILICKAPD
		{
			public PlatformSettings.PKALMPFEDPB context;

			internal bool _003CApplySettings_003Eb__0(PlatformSettings s)
			{
				return false;
			}
		}

		private static readonly PlatformSettings[] JILJNKKHLHF;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void FFEJFIHJFJF()
		{
		}
	}
}
