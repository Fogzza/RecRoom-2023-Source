using System;

[Serializable]
public struct PlayerCombatUISettings
{
	public bool LocalPlayerUISupported;

	public bool OpponentUISupported;

	public bool TeammateUISupported;

	public bool TeammateUIAlwaysVisible;

	public bool OpponentUIAlwaysVisible;
}
