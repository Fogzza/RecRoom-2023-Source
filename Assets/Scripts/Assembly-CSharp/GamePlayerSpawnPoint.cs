using UnityEngine;

public class GamePlayerSpawnPoint : GameSpawnPoint
{
	[SerializeField]
	private GIBEGHKMCIE supportedTeam;

	[SerializeField]
	private POEOMLLLCAI supportedTeamPlayerIndex;

	[SerializeField]
	private OEKMAGELALF customTag;

	[SerializeField]
	private bool allowDynamicAddRemove;

public GIBEGHKMCIE SupportedTeam
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

}

public POEOMLLLCAI SupportedTeamPlayerIndex
{
get 	{
		return POEOMLLLCAI.INDEX_0;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}
}
