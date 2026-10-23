using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace RecRoom.Core.Creation.SceneMoods
{
	public class MoodConfig : ScriptableObject
	{
		[Serializable]
		public class BackgroundObjectConfig
		{
			public string name;

			public BackgroundObject prefab;

			public Color defaultColor;

			public float defaultAlpha;

			public int id;

			public bool[] visibleInSlot;
		}

		[Serializable]
		public struct ReflectionProbeSettings
		{
			[ICGBEFCGILO]
			public int QualityLevel;

			public bool SkyboxOnly;

			public float UpdateFrequencySeconds;

			public ReflectionProbeTimeSlicingMode TimesliceMode;

			public int CubemapResolution;

			public static ReflectionProbeSettings Default => default;
		}

		private sealed class JJGLCAHHNLM
		{
			public int id;

			internal bool _003CGetBackgroundConfigFromId_003Eb__0(BackgroundObjectConfig a)
			{
				return false;
			}
		}

		private sealed class CMMJINNFOLM
		{
			public BackgroundObject prefab;

			internal bool _003CGetIdFromBackgroundObjectPrefab_003Eb__0(BackgroundObjectConfig ob)
			{
				return false;
			}
		}

		public Material SkyBoxMaterial;

		public List<BackgroundObjectConfig> BackgroundObjectConfigs;

		public string[] BackgroundObjectSlotTitles;

		[SerializeField]
		private ReflectionProbeSettings[] reflectionProbeSettings;

		public ReflectionProbeSettings CurrentReflectionProbeSettings => default;

		public Dictionary<string, MIBJNNKFLND> JJKHCHJHIEN(int APFNAOPENNF)
		{
			return null;
		}

		public BackgroundObjectConfig GJJBKDEICME(int IKHNIJKGJFD)
		{
			return null;
		}

		public int CFAMNNECGPO(BackgroundObject GDEKLMNKJBC)
		{
			return 0;
		}
	}
}
