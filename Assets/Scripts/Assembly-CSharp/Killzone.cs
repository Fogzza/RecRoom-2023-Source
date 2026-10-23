using UnityEngine;

public class Killzone : MonoBehaviour
{
	public enum HENPLHEAIGE
	{
		RESET_LAST_SPAWN_POINT = 0,
		RESET_LAST_PICKUP_POINT = 1,
		DISABLE = 2
	}

	[SerializeField]
	private bool respawnsPlayers;

	[SerializeField]
	private bool killsPlayerOnRespawn;

	[SerializeField]
	private Transform playerRespawnPositionOverride;

	[SerializeField]
	private string playerRespawnNotificationOverride;

	[SerializeField]
	private bool killsEnemies;

	[SerializeField]
	private bool resetsTools;

	[SerializeField]
	private bool resetsToolsOnEnter;

	[SerializeField]
	private HENPLHEAIGE resetToolMode;

	[SerializeField]
	private bool activeInCustomRooms;

	[SerializeField]
	private bool editorDrawSolidKillzoneWhenSelected;

public bool RespawnsPlayers
{
get 	{
		return false;
	}

}

public bool KillsPlayersOnRespawn
{
get 	{
		return false;
	}

}

public string PlayerRespawnNotificationOverride
{
get 	{
		return null;
	}

}

public bool KillsEnemies
{
get 	{
		return false;
	}

}

public bool ResetsTools
{
get 	{
		return false;
	}

}

public bool ResetsToolsOnEnter
{
get 	{
		return false;
	}

}

	public HENPLHEAIGE GetToolCollisionEffect(Tool IEGMBEPJMGC)
	{
		return HENPLHEAIGE.RESET_LAST_SPAWN_POINT;
	}

	public bool GetPlayerRespawnPositionAndRotation(out Vector3 LMFDFNAOFBL, out Quaternion NIIMICBCADB)
	{
		LMFDFNAOFBL = default;
		NIIMICBCADB = default;
		return false;
	}

	private void Awake()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}

	private void Reset()
	{
	}
}
