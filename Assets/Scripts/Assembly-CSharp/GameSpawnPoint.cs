using System.Collections.Generic;
using UnityEngine;

public class GameSpawnPoint : SpawnPoint
{
	public static global::HPIEEIFGNBA<GameSpawnPoint> Comparer;

	[SerializeField]
	protected GJJCKAMAKBF supportedState;

	[SerializeField]
	protected NJOGGCOMCJG[] supportedGameModes;

	private bool GMDLDJFGJIF;

	private GIBEGHKMCIE FAIJDKJFBIK;

	private POEOMLLLCAI JMHMICANCCL;

	private OEKMAGELALF CFHCAEJMOPD;

	private HashSet<GIBEGHKMCIE> MPNDPELPOKB;

public bool IsOnlyForSpectators
{
get 	{
		return false;
	}

set {
	}
}

public GIBEGHKMCIE GameTeam
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

set {
	}
}

public POEOMLLLCAI GameTeamPlayerIndex
{
get 	{
		return POEOMLLLCAI.INDEX_0;
	}

set {
	}
}

public OEKMAGELALF CustomTag
{
get 	{
		return OEKMAGELALF.TAG_1;
	}

set {
	}
}

public GJJCKAMAKBF SupportedGameState
{
get 	{
		return GJJCKAMAKBF.PRE_POST_GAME;
	}

}

protected override Color BAFJOOPEPHO
{
get 	{
		return default;
	}

}

	public bool SupportsGameState(GJJCKAMAKBF DADHJJNJEFA)
	{
		return false;
	}

	public bool SupportsGameMode(NJOGGCOMCJG DNLPIHIBJDP)
	{
		return false;
	}

	public void ClearTeamPlayerVisibility()
	{
	}

	public void UpdateTeamPlayerVisibility(List<GIBEGHKMCIE> KLCMLLICFFO, List<Vector3> IMEJEOKPGKL, float EMLKMJHPICE = 1.8f)
	{
	}

	public bool IsVisibleToTeamPlayers(IEnumerable<GIBEGHKMCIE> ODCIHIKEFOM)
	{
		return false;
	}

	protected override void Awake()
	{
	}
}
