using System;
using UnityEngine;

[Serializable]
public class GameTeamConfig : ScriptableObject
{
	[Serializable]
	public struct TeamConfig
	{
		public GIBEGHKMCIE Team;

		public Color Color;

		public string Name;
	}

	public TeamConfig[] TeamConfigs;

	public TeamConfig AnyTeamConfig;

	public Color HighContrastLocalPlayerTeamColor;

	public Color HighContrastEvenOpponentTeamColor;

	public Color HighContrastOddOpponentTeamColor;
}
