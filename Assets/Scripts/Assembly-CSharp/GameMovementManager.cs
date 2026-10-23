using System;

[Serializable]
public class GameMovementManager : KEAFLIHKNBO
{
	private const float RESTRICTED_TELEPORT_BUFFER_DISTANCE = 0f;

	public const int GAME_MOVEMENT_MANAGER_PRIORITY = 100;

	private const string TELEPORT_REGION_TAG_KEY = "TELEPORT_REGION_TAG";

	private FIHGBEHGLGB _teleportBufferDistanceRestrictedFlag;

	private FIHGBEHGLGB _movementModeChangeDuringGameSupportedFlag;

	private global::AFHOAHNAMGF<float> _movementModeChangeGracePeriodMap;

	private GameManager gameManager;

	private GameTeleportRestriction[] teleportRestrictions;

	private LHPHMLDFGDF localPlayerTeleportRegionTag;

	public bool TeleportBufferDistanceRestricted => false;

	public bool MovementModeChangeDuringGameSupported => false;

	public float MovementModeChangeGracePeriod => 0f;

	public void MIEODJOOHID(object IALNODEHBNN)
	{
	}

	public void LPBGAALFHLD(object IALNODEHBNN)
	{
	}

	public void EOKDFPCCHLA(object IALNODEHBNN)
	{
	}

	public void FBIHKEHHPDO(object IALNODEHBNN)
	{
	}

	public void LOEPKHKLNOO(float EOPBCLLHJAJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void GDAMPIFBMBF(object IALNODEHBNN)
	{
	}

	public void InitializeOnAwake(GameManager KPCADKBOAFA)
	{
	}

	public void InitializeOnStart()
	{
	}

	public void CleanupOnDestroy()
	{
	}

	public void OnUpdate()
	{
	}

	public void OnGameStart()
	{
	}

	public void OnGameEnd()
	{
	}

	public void OnPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void DLGBGEHLPLM(LHPHMLDFGDF AHNIMJDLOPB)
	{
	}

	private LHPHMLDFGDF EEIJBKNGECN()
	{
		return LHPHMLDFGDF.TAG_1;
	}

	public void InitializeLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public void ResetLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	private void JFJLDILJMAC()
	{
	}

	public bool AFIIFNNCADH()
	{
		return false;
	}
}
