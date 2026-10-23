using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecNet;
using RecRoom;
using RecRoom.Avatars;
using RecRoom.Core.Gestures;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerParty : MonoBehaviourPun, PHCICIGDDPA
{
	private sealed class BAEBFFBPKFG
	{
		public PlayerParty _003C_003E4__this;

		public CHILKDJABBF otherPlayer;

		internal void _003CSendHighFive_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private sealed class BCMPFPNJCLH
	{
		public PlayerParty _003C_003E4__this;

		public CHILKDJABBF otherPlayer;

		public Vector3? feedbackPosition;

		public PNBPIGNHJFA source;

		internal void _003CJoinParty_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private sealed class AHHDENLLDGM
	{
		private sealed class _003C_003CAcceptChatPartyInvite_003Eg__WaitForRoomLoadAndAutoPartyCoroutine_007C1_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public AHHDENLLDGM _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public _003C_003CAcceptChatPartyInvite_003Eg__WaitForRoomLoadAndAutoPartyCoroutine_007C1_003Ed(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public long targetRoomInstanceId;

		public int accountId;

		public Func<bool> _003C_003E9__2;

		internal void _003CAcceptChatPartyInvite_003Eb__0(ANAGHNCECEB result)
		{
		}

		internal IEnumerator<EGGPGCCKPCO> _003CAcceptChatPartyInvite_003Eg__WaitForRoomLoadAndAutoPartyCoroutine_007C1()
		{
			return null;
		}

		internal bool _003CAcceptChatPartyInvite_003Eb__2()
		{
			return false;
		}
	}

	private sealed class CEFMHHPAEBI
	{
		public PlayerParty _003C_003E4__this;

		public IBINLLOMNPN toPlayer;

		public PNBPIGNHJFA source;

		internal void _003CSendPartyUpRequest_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private sealed class CABNDFGLLHO
	{
		public PlayerParty _003C_003E4__this;

		public CHILKDJABBF otherPlayer;

		public Vector3 feedbackPosition;

		internal void _003CSendFriendRequest_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private sealed class GEJFELAMIGB
	{
		public CHILKDJABBF otherPlayer;

		public PlayerParty _003C_003E4__this;

		public Vector3 feedbackPosition;

		internal void _003CRpcMakeFriendRequest_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private sealed class HLFMANEKBIF
	{
		public int requestingPlayerId;

		public PNBPIGNHJFA source;

		internal void _003CRpcRequestJoinParty_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private sealed class HLLPFBNFILI
	{
		public CHILKDJABBF otherPlayer;

		public PlayerParty _003C_003E4__this;

		public Vector3? feedbackPosition;

		public PNBPIGNHJFA source;

		internal void _003CRpcJoinParty_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private sealed class COCKENOOHPF
	{
		public CHILKDJABBF otherPlayer;

		public PlayerParty _003C_003E4__this;

		internal void _003CRpcSendHighFive_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private static readonly string AJDCHCADIAP;

	private static readonly string OPOEKHNKKBO;

	private static readonly HashSet<string> ECCNGNHIDOG;

	private static readonly List<ColorVault.DAKHANMKKFJ> KOMNBFKDMPJ;

	private static LKGILLBEJEK FDDKIAFIIEL;

	private const float IOBMMIECGNG = 2f;

	private const string AFAKCJMJFFB = "party";

	public static EEANDDJEMJC LocalPlayerPartyChanged;

	public static EEANDDJEMJC LocalPlayerPartyColorChanged;

	[SerializeField]
	private float partyListUpdateInterval;

	[SerializeField]
	private ParticleSystem fistBumpParticles;

	[SerializeField]
	private float gestureDetectionHandDotMargin;

	[SerializeField]
	private float gestureDetectionHandOpenCloseMargin;

	[SerializeField]
	private float gestureDetectionHandSpeedMargin;

	[SerializeField]
	private SimpleVolume gestureDetectionHandshakeFistbumpVolume;

	[SerializeField]
	private SimpleVolume gestureDetectionHighfiveVolume;

	private float AENFLHIIIEH;

	private bool OCHPBEOKLEA;

	private List<Player> DLFGMFGKPKJ;

	private Player PGKEHBCKJKI;

	private Dictionary<int, float> LEPCGKLFHDN;

	private Dictionary<int, PNBPIGNHJFA> IFHNGFLBGGB;

	private LHMPPJKHCJG KOCMHELAMME;

	private global::MOBDJNEDDKC<int> NOLPHLMFICK;

	private global::ADOKDOGIPIF<string> ONDMGOKJLEA;

	private global::ADOKDOGIPIF<string> MKDFNOIGFDK;

	private Color? OEMNACCKGLM;

public IReadOnlyCollection<Player> PartyMembers
{
get 	{
		return null;
	}

}

public bool IsInParty
{
get 	{
		return false;
	}

}

public int PartySize
{
get 	{
		return 0;
	}

}

public string CurrentPartyId
{
get 	{
		return null;
	}

}

public string CurrentPartyColorId
{
get 	{
		return null;
	}

private set {
	}
}

public Color? PartyColor
{
get 	{
		return null;
	}

}

	public static void Cleanup()
	{
	}

	private void JEDFDGIBILM(string IPMIIEAGJKC, PNBPIGNHJFA HDLFENAPEBE = PNBPIGNHJFA.NONE)
	{
	}

	private float? BNFKOADDCFJ()
	{
		return null;
	}

	private void GLCIFLDAJAE()
	{
	}

	void PHCICIGDDPA.ALCBOOGGMHC()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GLCIFLDAJAE
		this.GLCIFLDAJAE();
	}

	private void LJEPIPPPFJL()
	{
	}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SendHighFive(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	public void JoinParty(CHILKDJABBF PLNGHFIMCDB, Vector3? IGKLIILGJJH, PNBPIGNHJFA GLLFHCCFIGK)
	{
	}

	public void LeaveCurrentParty()
	{
	}

	public bool IsInPartyWith(Player EKOFNPFCLMO)
	{
		return false;
	}

	public bool IsInPartyWith(int? PCKCPNGPNBJ, bool FILPHNKNPEK = false)
	{
		return false;
	}

	public LAHBDKNMNHN InvitePlayerFromOtherRoomToParty(DFDECAEJBIO ACBGBAAHOIM, PNBPIGNHJFA GLEPIJNFADM, bool PGHNOAPKPMC = false)
	{
		return null;
	}

	public void AcceptChatPartyInvite(int EJIHLJJMOBD, JCDPHCELKHI NABGBJNBHDH, ChatMessage BHNMKKBELJE, long PPGDMJDBLII)
	{
	}

	public void SendPartyUpRequest(IBINLLOMNPN FNFMFLJCKEH, PNBPIGNHJFA GLLFHCCFIGK)
	{
	}

	public void InviteAccountsToParty(IReadOnlyList<DFDECAEJBIO> AGIGKKMBEKN, bool PGHNOAPKPMC = false)
	{
	}

	public void SendFriendRequest(CHILKDJABBF PLNGHFIMCDB, Vector3 IGKLIILGJJH)
	{
	}

	public bool CanInvitePlayer(IBINLLOMNPN EKOFNPFCLMO)
	{
		return false;
	}

	public void KickPlayer(Player GFCPAMJILIO)
	{
	}

	public int[] GetPlayerIDs(bool OBLIAGCGGDG = false)
	{
		return null;
	}

	public CHILKDJABBF FindPlayerFromLargestParty()
	{
		return null;
	}

	private void ANOLMHNNNPO(float OKBAJEAPIHG)
	{
	}

	private void BMOPKANFLLC()
	{
	}

	[PBOMGCLBFHF]
	private void RpcMakeFriendRequest(CHILKDJABBF PLNGHFIMCDB, Vector3 IGKLIILGJJH)
	{
	}

	private void HDMAFHAELEI(Player PLNGHFIMCDB, Vector3 IGKLIILGJJH)
	{
	}

	[PBOMGCLBFHF]
	private void RpcRequestJoinParty(int LMOJDCNCLPF, PNBPIGNHJFA GLLFHCCFIGK)
	{
	}

	[PBOMGCLBFHF]
	private void RpcAutoJoinParty(string BLLFELOHJMF)
	{
	}

	[PBOMGCLBFHF]
	private void RpcJoinParty(CHILKDJABBF PLNGHFIMCDB, Vector3? IGKLIILGJJH, PNBPIGNHJFA GLLFHCCFIGK)
	{
	}

	[PBOMGCLBFHF]
	private void RpcSendHighFive(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	private void HHJAKHAMMMM()
	{
	}

	private void BFMGAMGFDDC(Player PLNGHFIMCDB, Vector3? IGKLIILGJJH, PNBPIGNHJFA GLLFHCCFIGK)
	{
	}

	private bool CCNJJNGCONF(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private void DLNBEBEMKDO(Player ANDCAFFMODA, Vector3? IGKLIILGJJH, PNBPIGNHJFA GLLFHCCFIGK)
	{
	}

	private void KBNGLDKJKLN()
	{
	}

	private void JMFGHGIFEII(Player PLNGHFIMCDB, Vector3 IGKLIILGJJH)
	{
	}

	private bool KEFFKDOFPGD(CHILKDJABBF PGKEHBCKJKI, CHILKDJABBF PLNGHFIMCDB)
	{
		return false;
	}

	private void PBJIBBFAFFC(string BLLFELOHJMF)
	{
	}

	private string GLICEDHGLNL()
	{
		return null;
	}

	private bool FNHABPIKEKH(string IGOMIMBBAKG)
	{
		return false;
	}

	[PBOMGCLBFHF]
	private void RpcKickedFromParty(string BLLFELOHJMF)
	{
	}

	private bool MOMJOBHJMNA(Player EKOFNPFCLMO)
	{
		return false;
	}

	public void UpdatePartyLists(bool AIBKGFEBLKP = false)
	{
	}

	private void CEGMKMOIFJM()
	{
	}

	private Player MIJBAGGPMLD()
	{
		return null;
	}

	public GHCICEFBOGM DetectGestureForHand(PlayerHand PMNLJGLDMJN)
	{
		return GHCICEFBOGM.None;
	}

	private void HFCFGLCCACP()
	{
	}

	private void DGDBAJPLAGJ()
	{
	}

	private void JEPGJKBDCFP()
	{
	}

	private void MJGPHBGDHDJ(Player EKOFNPFCLMO)
	{
	}

	public virtual void OnPhotonPlayerDisconnected(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	private void ENLPGLEFMJB(PlayerHand DLCHNMNIOHL, PlayerHand MCGMBMMJMBM, PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, Player MHCOBIPKGNI, Player ANDCAFFMODA)
	{
	}

	private void ACEAPCIJJDL(ParticleSystem BENMDFOMAME, Vector3 INLGLHIPOMC)
	{
	}
}
