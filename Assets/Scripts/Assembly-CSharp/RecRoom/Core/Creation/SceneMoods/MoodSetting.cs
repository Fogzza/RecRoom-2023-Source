using System;
using RecRoom.Core.Creation.SceneMoods.MoodBlendData;
using RecRoom.DataStructures;
using UnityEngine;
using UnityEngine.Rendering;

namespace RecRoom.Core.Creation.SceneMoods
{
	[Serializable]
	public class MoodSetting : ScriptableObject
	{
		public string FriendlyName;

		public VolumeProfile VolumeProfile;

		public Cubemap BakedReflection;

		[SerializeField]
		public SkyBoxMoodSettings SkyBoxSettings;

		[SerializeField]
		public SunMoodSettings SunSettings;

		[SerializeField]
		public FogMoodSettings FogSettings;

		[SerializeField]
		public BloomMoodSettings BloomSettings;

		[SerializeField]
		public ColorGradingMoodSettings ColorGradingSettings;

		[SerializeField]
		public BackgroundObjectsMoodSettings BackgroundObjectsSettings;

		[SerializeField]
		private SerializedGuid guid;

		public Guid Guid => default;
	}
}
