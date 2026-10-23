using System.Collections.Generic;
using RecRoom;
using RecRoom.Activities;
using RecRoom.Audio;
using UnityEngine;

public sealed class SoccerManager : GameRuleManager
{
	public enum ONELAMDHFDD
	{
		PRE_ROUND = 0,
		ROUND_RUNNING = 1,
		BALL_SCORED = 2,
		INVALID = 65535
	}

	private const float JMIMLHHIOGC = 3f;

	private const float GEGDEGAEMGG = 3f;

	private float MOFIELACCMO;

	[SerializeField]
	private RecRoomAudioClip blueTeamScoreSFX;

	[SerializeField]
	private RecRoomAudioClip redTeamScoreSFX;

	[SerializeField]
	private RecRoomAudioClip goalSFX;

	[SerializeField]
	private RecRoomAudioClip goalVO;

	[SerializeField]
	private RecRoomAudioClip powerupPickupSFX;

	private JOJOABLFOBA JGFDINEIPEM;

	private HONEDBECDOK KJHJNEDBGMK;

	private SoccerBall PMFMNEJCNDJ;

	private SoccerGarageDoor CPCEKBPENAM;

	private LegacyPowerupSpawner[] HDHOJCIPCKM;

	private readonly List<SoccerPowerup> JMBDEGNHNLA;

	[SerializeField]
	private Transform soccerBallSpawnTransform;

public new static SoccerManager Instance
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

public float GameDuration
{
get 	{
		return 0f;
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

public override bool AutoRunTimer
{
get 	{
		return false;
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

	private void Update()
	{
	}

	private void NFKJFJMFLOI()
	{
	}

	protected override void HDJBEAFJEHD()
	{
	}

	protected override void ENHEJEADGCH()
	{
	}

	private void GOIGDLIPFPM(SoccerBall PMFMNEJCNDJ, SoccerGoal NLGEMJJEFBD, Vector3 DLPJLCNKKJD)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestScore(GIBEGHKMCIE HMNECDJPCKM, Vector3 DLPJLCNKKJD)
	{
	}

	private bool OKLCIKDBMND()
	{
		return false;
	}

	[PBOMGCLBFHF]
	private void RpcOnScore(CHILKDJABBF KOHMLDFIEEL, GIBEGHKMCIE FOKFEPKEDJA, Vector3 DLPJLCNKKJD)
	{
	}

	private void HJNEMNOILBI()
	{
	}

	private void ILMLCBAGEBK(SoccerPowerup EHHMLGPJGDB, Player CLAAKJAFDLA)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestPowerup(SoccerPowerup EHHMLGPJGDB, CHILKDJABBF CLAAKJAFDLA)
	{
	}

	private bool BDOMGGCAJHJ(SoccerPowerup EHHMLGPJGDB, CHILKDJABBF CLAAKJAFDLA)
	{
		return false;
	}

	[PBOMGCLBFHF]
	private void RpcOnPowerupPickup(SoccerPowerup EHHMLGPJGDB, CHILKDJABBF CLAAKJAFDLA)
	{
	}

	private void JCAKPICLLNF()
	{
	}

	private void FOLICLHJFPG()
	{
	}

	private void OFLKGGFBHFI()
	{
	}

	private void HPPILGBKPHJ()
	{
	}

	private void PLMGPIBPOLB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void DKABDCFKPFN(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void NAJOPBNHMMD()
	{
	}

	private void GCGFNIHLEBJ()
	{
	}

	private void HFLEAKCBPFG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HBJIBIFHKLJ()
	{
	}

	private void OJCGFDLDOMM(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void DCAIEJMJIOG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void OHHFKHKFEAO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void PLBLKBAOFEO()
	{
	}
}
