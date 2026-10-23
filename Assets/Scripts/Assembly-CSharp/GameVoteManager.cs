using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;

public class GameVoteManager : MonoBehaviourPun, KEAFLIHKNBO
{
	public enum DOIBEJFNDGA
	{
		NONE = 0,
		SUBROOM = 1
	}

	public delegate void NNNAOFNMEDF();

	private class MEBMKMNNHLH
	{
		private NNNAOFNMEDF CACJCBGIAEJ__BackingField;

		private global::MOBDJNEDDKC<string> IJFODHIEJLH;

public string HHDNLFHJIOP
{
get 		{
			return null;
		}

set {
		}
}

public event NNNAOFNMEDF CACJCBGIAEJ {
add {
		}
remove {
		}
}

		public MEBMKMNNHLH(MonoBehaviourPun DELCOFCGDFF, CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void CKOIAJJEHPD()
		{
		}
	}

	private sealed class ACCKBBCCMDG
	{
		public string mapName;

		internal bool _003CVoteIsValid_003Eb__0(string s)
		{
			return false;
		}
	}

	private Action FJPHFMBDBLG__BackingField;

	private Action DHFGGDDEBPF__BackingField;

	private Dictionary<string, int> BNIMBPEEGKM;

	private readonly Dictionary<int, MEBMKMNNHLH> JKDKPKBFNDE;

	private global::MOBDJNEDDKC<string> CMPBBHNPBEK;

public string NextLevel
{
get 	{
		return null;
	}

private set {
	}
}

public bool LocalPlayerSupportsVoting
{
get 	{
		return false;
	}

}

public bool LocalPlayerCanVoteNextLevel
{
get 	{
		return false;
	}

}

public DOIBEJFNDGA LocalPlayerVotingMode
{
get 	{
		return DOIBEJFNDGA.NONE;
	}

}

public event Action VoteReceivedEvent {
add {
	}
remove {
	}
}

public event Action NextLevelChangeEvent {
add {
	}
remove {
	}
}

	public void LocalPlayerTryOpenVoteNextLevelMenu()
	{
	}

	public void LocalPlayerSubmitLevelVote(string PAKKJAPOGPN)
	{
	}

	public IEnumerable<string> LocalMapsToVoteOn()
	{
		return null;
	}

	public void OnVotesChange()
	{
	}

	public int GetLevelVotes(string PAKKJAPOGPN)
	{
		return 0;
	}

	public void RoomAuthorityMoveGroupToNextMap()
	{
	}

	private bool GAODOMAEBHM(string MGHHPEIHDIO)
	{
		return false;
	}

	private MEBMKMNNHLH ALANECENMJF(CHILKDJABBF EKOFNPFCLMO)
	{
		return null;
	}

	private string KMOMGJPKIEG()
	{
		return null;
	}

	private void OnPhotonPlayerConnected(CHILKDJABBF DEODPCHAFKO)
	{
	}

	private void EMOOEGLABAI()
	{
	}

	public void CleanupOnDestroy()
	{
	}

	public void InitializeLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public void InitializeOnAwake(GameManager KPCADKBOAFA)
	{
	}

	public void InitializeOnStart()
	{
	}

	public void OnGameEnd()
	{
	}

	public void OnGameStart()
	{
	}

	public void OnPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void OnUpdate()
	{
	}

	public void ResetLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	[CompilerGenerated]
	internal static void IHNPNBHKELF(string NLJOHEKGNDH)
	{
	}
}
