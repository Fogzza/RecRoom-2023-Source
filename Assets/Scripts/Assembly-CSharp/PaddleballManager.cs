using System.Collections.Generic;
using RecRoom;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

public class PaddleballManager : GameRuleManager
{
	public enum MFILJCPDMFH
	{
		ROUND_RUNNING = 0,
		BALL_SCORED = 1,
		INVALID = 65535
	}

	[SerializeField]
	private float ballScoredStateDuration;

	[SerializeField]
	private RecRoomAudioClip goalSFX;

	[SerializeField]
	private RecRoomAudioClip goalVO;

	[SerializeField]
	private PooledParticle goalVFXPrefab;

	private JOJOABLFOBA NADPCJELAIB;

	private HONEDBECDOK IEBJEJNIFDC;

	private TeleportationPortal[] PAFNLBBMCFB;

	private List<PaddleballBall> OBNCCPGMJIE;

	private PaddleballBall OIBPBNCPHLD;

	private List<PaddleballBallSpawnPoint> DDEBBPAEPLL;

	private List<PaddleballGoal> PNKCGNOKBOJ;

	private global::MOBDJNEDDKC<GIBEGHKMCIE> DOGDIMFADDE;

	private int GGCOGEBAAEL;

public new static PaddleballManager Instance
{
get 	{
		return null;
	}

}

public new static bool IsInitialized
{
get 	{
		return false;
	}

}

public override bool AutoRunTimer
{
get 	{
		return false;
	}

}

public int ScoreToWin
{
get 	{
		return 0;
	}

set {
	}
}

public override string RuleTypeAutoTag
{
get 	{
		return null;
	}

}

private GIBEGHKMCIE OILCHBILJEL
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

set {
	}
}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected override void Start()
	{
	}

	protected void Update()
	{
	}

	protected void NFKJFJMFLOI()
	{
	}

	protected override void HDJBEAFJEHD()
	{
	}

	protected override void ENHEJEADGCH()
	{
	}

	private void EGCHKJHDLFK(PaddleballGoal PDIBMCIEHIJ, Vector3 DLPJLCNKKJD)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestScore(PaddleballGoal PDIBMCIEHIJ, Vector3 DLPJLCNKKJD)
	{
	}

	private bool OKLCIKDBMND()
	{
		return false;
	}

	[PBOMGCLBFHF]
	private void RpcOnScore(PaddleballGoal PDIBMCIEHIJ, Vector3 DLPJLCNKKJD)
	{
	}

	private void LODJDJACBDJ()
	{
	}

	private void HJNEMNOILBI(GIBEGHKMCIE JCFAJMFPIAM)
	{
	}

	private void KAOPNNNELKO(GIBEGHKMCIE JCFAJMFPIAM)
	{
	}

	private Transform POJBLKPLLLL(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private void HFLEAKCBPFG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HBJIBIFHKLJ()
	{
	}

	private void DCAIEJMJIOG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void PLBLKBAOFEO()
	{
	}

	private bool NLGJOLDMOOP(Tool IEGMBEPJMGC, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
	{
		return false;
	}
}
