using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

public class DodgeballManager : GameRuleManager
{
	private enum MLDNBNCCGHE
	{
		ROUND_START = 0,
		ROUND_RUNNING = 1,
		ROUND_OVER = 2,
		INVALID = 65535
	}

	private enum ODGCFPLAGBF
	{
		Court = 0,
		Sidelines = 1
	}

	private enum EJALHGKHBEC
	{
		Court = 0,
		Sidelines = 1
	}

	private class AKMJONBGJNC
	{
		private CHILKDJABBF BDJDBNPCCOK;

		private global::MOBDJNEDDKC<bool> NJNHAIKKHOI;

public bool EHAFJJCHKKH
{
get 		{
			return false;
		}

set {
		}
}

		public AKMJONBGJNC(MonoBehaviourPun DELCOFCGDFF, CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void OBEKEHEJLBI()
		{
		}
	}

	private float EAPFGIIPJNB;

	private int GGCOGEBAAEL;

	[SerializeField]
	private RecRoomAudioClip roundStartSFX;

	[SerializeField]
	private RecRoomAudioClip roundOverSFX;

	[SerializeField]
	private RecRoomAudioClip playerScoreSFX;

	[SerializeField]
	private RecRoomAudioClip playerScoreVO;

	[SerializeField]
	private RecRoomAudioClip playerOutSFX;

	[SerializeField]
	private RecRoomAudioClip playerOutVO;

	[SerializeField]
	private RecRoomAudioClip playerImpactSFX;

	[SerializeField]
	private PooledParticle playerImpactVFXPrefab;

	private readonly MDKHKMMJIAB OEMIKHPNGOC;

	private readonly MDKHKMMJIAB ELHGKHCPLNC;

	private JOJOABLFOBA IJCBJEPLABO;

	private HONEDBECDOK EEFBEMEKDEA;

	private List<Dodgeball> JECDNOLFDOL;

	private List<Killzone> KAIFDDNJLLB;

	private bool KCHECNGMLCH;

	private const float DEGOJLNCMMO = 3f;

	private const float OLPFMBNLHGJ = 3f;

	private const float HABOHHDMBOK = 0.35f;

	private Dictionary<int, AKMJONBGJNC> JKDKPKBFNDE;

public new static DodgeballManager Instance
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

public int ScoreToWin
{
get 	{
		return 0;
	}

set {
	}
}

private int CJACBCHIBCL
{
get 	{
		return 0;
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

	private void MJGPHBGDHDJ(Player EKOFNPFCLMO)
	{
	}

	private void EAKLEKEJNHP()
	{
	}

	private void JHECFGDENEP(bool BIJHPJHGOEF, bool AEDEGBAOLDD)
	{
	}

	private void LHOABNCJFAK(bool BIJHPJHGOEF)
	{
	}

	private void OIADAEGLPIH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void PFCNODLLKMD()
	{
	}

	private void PBPEMCBJOCM()
	{
	}

	private void HFLEAKCBPFG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HBJIBIFHKLJ()
	{
	}

	private void PECPACOHGPD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AMABOOCLOBA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void BOHEGOCFNMB()
	{
	}

	private void NODPHHHIJLH()
	{
	}

	private void COFDGOAKGDH(CHILKDJABBF LAKIEOJMCKM, CHILKDJABBF CPLFOBGALMN, Vector3 EPGAOLNDLII)
	{
	}

	private void ADLJODPJPNA(CHILKDJABBF LAKIEOJMCKM, CHILKDJABBF KJCCPIIFNGO, Vector3 EPGAOLNDLII)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestPlayerOut(CHILKDJABBF LAKIEOJMCKM, CHILKDJABBF CPLFOBGALMN, Vector3 JCAMKDOELNO)
	{
	}

	private bool ICOACIHCPNO(CHILKDJABBF LAKIEOJMCKM, CHILKDJABBF CPLFOBGALMN)
	{
		return false;
	}

	[PBOMGCLBFHF]
	private void RpcOnPlayerOut(CHILKDJABBF LAKIEOJMCKM, CHILKDJABBF CPLFOBGALMN, Vector3 JCAMKDOELNO)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnPlayerHit(CHILKDJABBF LAKIEOJMCKM, CHILKDJABBF KJCCPIIFNGO, Vector3 EPGAOLNDLII)
	{
	}

	private void NIKNGAOOFBF(CHILKDJABBF IBBHNAKBIDC, CHILKDJABBF LAKIEOJMCKM, Vector3 OCGLGKDEDMP)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestPlayerCatch(CHILKDJABBF IBBHNAKBIDC, CHILKDJABBF LAKIEOJMCKM, Vector3 OCGLGKDEDMP)
	{
	}

	private bool KGCHENHHEFJ(CHILKDJABBF IBBHNAKBIDC, CHILKDJABBF LAKIEOJMCKM)
	{
		return false;
	}

	[PBOMGCLBFHF]
	private void RpcOnPlayerCatch(CHILKDJABBF IBBHNAKBIDC, CHILKDJABBF LAKIEOJMCKM, Vector3 OCGLGKDEDMP)
	{
	}

	private bool OHOJPJIMCLK(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return false;
	}

	private AKMJONBGJNC ALANECENMJF(CHILKDJABBF EKOFNPFCLMO)
	{
		return null;
	}

	private bool GPOMLHKBNFG(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private void BDLIPAHOGEF(CHILKDJABBF EKOFNPFCLMO, bool GDNHLGMGFLP)
	{
	}

	private void JIMPPMAEBJB(bool GDNHLGMGFLP)
	{
	}

	private void NGGAAPPPGLO()
	{
	}

	private void LPABHGOEHMC()
	{
	}

	private void MBLHNKIJCND(bool OBFHBDLKFPA)
	{
	}

	[CompilerGenerated]
	private void NJEMKHNNAMO()
	{
	}
}
