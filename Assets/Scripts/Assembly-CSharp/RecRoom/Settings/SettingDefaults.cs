using System;
using System.Collections.Generic;
using RecRoom.Systems.StreamingCamera;
using UnityEngine;

namespace RecRoom.Settings
{
	[Serializable]
	public class SettingDefaults
	{
		[SerializeField]
		public IgnoreBufferSize[] ignoreBufferSizes;

		private Dictionary<ONCCFHECNKK, IgnoreBufferSize> _ignoreBufferSizeMap;

		[SerializeField]
		public TeleportBufferSize[] teleportBufferSizes;

		private Dictionary<PINLDPIKLLE, float> _teleportBufferSizeMap;

		[SerializeField]
		private ONCCFHECNKK juniorIgnoreBuffer;

		[SerializeField]
		private PINLDPIKLLE juniorTeleportBuffer;

		[SerializeField]
		private StreamingCameraController streamingCameraPrefab;

		public ONCCFHECNKK JuniorIgnoreBuffer => ONCCFHECNKK.Disabled;

		public PINLDPIKLLE JuniorTeleportBuffer => PINLDPIKLLE.Small;

		public StreamingCameraController StreamingCameraPrefab => null;

		public IReadOnlyDictionary<ONCCFHECNKK, IgnoreBufferSize> IgnoreBufferSizeMap => null;

		public IReadOnlyDictionary<PINLDPIKLLE, float> TeleportBufferSizeMap => null;
	}
}
