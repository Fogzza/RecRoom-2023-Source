using System;
using System.Runtime.CompilerServices;
using Photon.Pun;

[Serializable]
public class GameBoundsManager : MonoBehaviourPun, KEAFLIHKNBO
{
	private enum JFKMNDPGAFC
	{
		IN_BOUNDS = 0,
		OUT_OF_BOUNDS_GRACE_PERIOD = 1,
		OUT_OF_BOUNDS_COUNTING_DOWN = 2,
		OUT_OF_BOUNDS_TIMER_EXPIRED = 3
	}

	private GameManager gameManager;

	private MDEJADHJOEJ localPlayerOutOfBoundsStateMachine;

	private KBJKDKFNFIA stateTimer;

	private FIHGBEHGLGB _outOfBoundsPausedFlag;

	private FIHGBEHGLGB _outOfBoundsSupportedFlag;

	private FIHGBEHGLGB _outOfBoundsSpectatorsSupportedFlag;

	private FIHGBEHGLGB _shouldKillOutOfBoundsPlayersFlag;

	private global::AFHOAHNAMGF<float> _gracePeriodMap;

	private global::AFHOAHNAMGF<float> _maxDurationMap;

	private bool LocalPlayerInBounds => false;

	public bool OutOfBoundsPaused => false;

	public bool OutOfBoundsSupported => false;

	public bool OutOfBoundsSpectatorsSupported => false;

	public bool ShouldKillOutOfBoundsPlayers => false;

	private float OutOfBoundsGracePeriod => 0f;

	public float OutOfBoundsMaxDuration => 0f;

	public void PauseOutOfBoundsCheck(object IALNODEHBNN)
	{
	}

	public void ResumeOutOfBoundsCheck(object IALNODEHBNN)
	{
	}

	protected override void Awake()
	{
	}

	public void InitializeOnAwake(GameManager KPCADKBOAFA)
	{
	}

	public void InitializeOnStart()
	{
	}

	public void OnUpdate()
	{
	}

	public void CleanupOnDestroy()
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

	public void InitializeLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public void ResetLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	private void PNNLIHOKFCJ()
	{
	}

	private void IHBPDENALIJ()
	{
	}

	public void AddOutOfBoundsSupport(object IALNODEHBNN)
	{
	}

	public void RemoveOutOfBoundsSupport(object IALNODEHBNN)
	{
	}

	public void AddOutOfBoundsSpectatorsSupport(object IALNODEHBNN)
	{
	}

	public void RemoveOutOfBoundsSpectatorsSupport(object IALNODEHBNN)
	{
	}

	public void AddKillOutOfBoundsPlayersSupport(object IALNODEHBNN)
	{
	}

	public void RemoveKillOutOfBoundsPlayersSupport(object IALNODEHBNN)
	{
	}

	public void AddOutOfBoundsGracePeriod(float EOPBCLLHJAJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveOutOfBoundsGracePeriod(object IALNODEHBNN)
	{
	}

	public void AddOutOfBoundsMaxDuration(float MHAAOONBMNJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveOutOfBoundsMaxDuration(object IALNODEHBNN)
	{
	}

	private void OLKHHGJGGPD()
	{
	}

	private void LGLILCEBMLJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void OPCGLLKNMLE()
	{
	}

	private void MDKKPKJNCGF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void CAEINGAKAJO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void APGKJLBKMIC()
	{
	}

	private void BPCFDHGDPBL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private bool KKOMHLMHPFI(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	[PBOMGCLBFHF]
	public void RpcRequestMasterKillLocalPlayer(GGGMJMEFFOC BOCBPOADLNM)
	{
	}

	[PBOMGCLBFHF]
	public void RpcAcknowledgeLocalPlayerKilled()
	{
	}

	[CompilerGenerated]
	private void MLOIMJJFOPD()
	{
	}
}
