using System;
using UnityEngine;

public class CachedViewSceneSettings : MonoBehaviour
{
	[Serializable]
	public struct Settings
	{
		public string GroupName;

		public bool SupportsAutoDisable;
	}

	[SerializeField]
	private Settings[] cachedViewSettingOverrides;

	private void Awake()
	{
	}
}
