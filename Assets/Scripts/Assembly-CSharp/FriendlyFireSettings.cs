using System;

[Serializable]
public struct FriendlyFireSettings
{
	public bool PlayerOnPlayerFriendlyFireSupported;

	public bool PlayerOnEnemyFriendlyFireSupported;

	public bool EnemyOnPlayerFriendlyFireSupported;

	public bool EnemyOnEnemyFriendlyFireSupported;

	public bool GrenadesCanDamageTeammates;
}
