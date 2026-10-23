using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using Photon.Voice.Unity;
using TMPro;
using UnityEngine;

namespace RecRoom.Tools.Productivity
{
	public class DesktopAudioSharingSpeaker : MonoBehaviourPun, KFLNCOLKJEM
	{
		private enum OHBPBIJAMFK
		{
			NOT_SUPPORTED = 0,
			SPEAKER_IN_USE = 1,
			INVALID_PLAYER = 2,
			BROADCASTING_REQUESTED = 3
		}

		private const string HHOOBNDALEJ = "[DesktopAudioSharing_PhotonVoiceRecorder]";

		private const string KNOPLAPFHNK = "Broadcasting audio!";

		private const string NHOLLOEHEJM = "Output device changed";

		private const string LOFPJMNDEBG = "Audio Sharing is not supported.";

		private const string AEFMFAEBLDK = "Speaker already in use.";

		private const string CCCIBECJMAO = "Speaker inactive or in use by someone else.";

		private const string EFKDEBBENDN = "Error";

		private const float PGCBBLDFBDC = 3f;

		private const string LHBNKMJDOBL = "Stopped broadcasting audio";

		private const float GAFDPDDDMJJ = 3f;

		private const int IKHJKALAKCA = -1;

		[SerializeField]
		private TextMeshProUGUI broadcasterLabel;

		private IReadOnlyList<AKIDNFAPJGC> IHIOGAGFNPL;

		private bool POLLIMFJHII;

		private global::MOBDJNEDDKC<int> IEEFPNCLBCP;

		private Recorder KGPNIIPJAIK;

		private int PCADNMLPNEH;

private int FCMAODIOPJD
{
get 		{
			return 0;
		}

}

private bool OLCGPNMEECP
{
get 		{
			return false;
		}

}

public bool IsDefaultOutputDeviceUsed
{
get 		{
			return false;
		}

private set {
		}
}

public int BroadcastingPlayerId
{
get 		{
			return 0;
		}

private set {
		}
}

public Recorder VoiceRecorder
{
get 		{
			return null;
		}

private set {
		}
}

public int VoiceRecorderSourceIndex
{
get 		{
			return 0;
		}

private set {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void EACPEPNPACM()
		{
		}

		private void PAKHCBBCPFC()
		{
		}

		private IReadOnlyList<AKIDNFAPJGC> KANFJJKKHGA(bool JFDHBCBJEEK)
		{
			return null;
		}

		private void IAOJHJPJDEJ()
		{
		}

		protected void Update()
		{
		}

		public void OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		private void PGNADHBFKJP()
		{
		}

		private void HBFGNGKIJBO()
		{
		}

		private int KDEMLEJDLPC()
		{
			return 0;
		}

		private bool FHBNAMBANOI()
		{
			return false;
		}

		private bool HMMCKFEOKGI()
		{
			return false;
		}

		private bool EBODJIPNDEI()
		{
			return false;
		}

		private OHBPBIJAMFK KHHAGAFKNCH()
		{
			return OHBPBIJAMFK.NOT_SUPPORTED;
		}

		[PBOMGCLBFHF]
		public void RpcAuthorityRequestStartBroadcast(int FHHMFPGMCBJ)
		{
		}

		[PBOMGCLBFHF]
		public void RpcAuthorityRequestStopBroadcast(int FHHMFPGMCBJ)
		{
		}

		private global::EOFPHLEIINJ<float> OIIJIOHDOIN()
		{
			return null;
		}

		private void ICHGNMPKOEG()
		{
		}

		private void EBJAJGHKKHM()
		{
		}

		private void LJMBFMNAJBC(string PKDFKOMHNGK)
		{
		}

		private void OIEECKBCMGB()
		{
		}

		private void FFBMLDJBKIN(OHBPBIJAMFK CDNLFEOBNKB)
		{
		}

		private void HMJGJIGJMME(string DJNMDBANOAF)
		{
		}

		private void ICLECAJNEBJ(string DJNMDBANOAF)
		{
		}

		private void GJHNFFGKBLG()
		{
		}

		public void Button_ToggleBroadcastingClaim()
		{
		}

		public void Button_CycleInput()
		{
		}

		[CompilerGenerated]
		private void GIMBBHMEACD(DFDECAEJBIO ACBGBAAHOIM)
		{
		}

		[CompilerGenerated]
		private void JALKABEIKAF(string NLJOHEKGNDH)
		{
		}
	}
}
