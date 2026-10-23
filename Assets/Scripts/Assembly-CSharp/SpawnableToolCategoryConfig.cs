using System;
using UnityEngine;

[Serializable]
public class SpawnableToolCategoryConfig : ScriptableObject
{
	public enum NPLMNGEDABB
	{
		INVALID = -1,
		GAGDETS = 0,
		PROPS = 1,
		LAST = PROPS,
		FIRST = GAGDETS,
		COUNT = 2
	}

	[Serializable]
	public class CategoryConfig
	{
		public ANOEOICCMDH Category;

		public string FriendlyName;

		public NPLMNGEDABB Group;
	}

	[SerializeField]
	public CategoryConfig[] CategoryConfigs;
}
