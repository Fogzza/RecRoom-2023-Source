using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.BattleRoyale
{
	public class BattleRoyaleGameplayZone : MonoBehaviourPun
	{
		private enum EAODJAJHKAA
		{
			DISABLED = 0,
			ENABLED = 1
		}

		private enum MNAKFABNGCA
		{
			WAITING = 0,
			SHRINKING_SOON = 1,
			SHRINKING = 2,
			FINISHED = 3
		}

		private static BattleRoyaleGameplayZone EGAIHCNFOEN;

		[SerializeField]
		private int damageAmount;

		[SerializeField]
		private float damagePeriod;

		[SerializeField]
		private float initialWaitBeforeShrinkingDuration;

		[SerializeField]
		private float waitBeforeShrinkingDuration;

		[SerializeField]
		private float shrinkingSoonDuration;

		[SerializeField]
		private float shrinkingDuration;

		[SerializeField]
		private string shrinkingSoonNotification;

		[SerializeField]
		private string shrinkingNotification;

		[SerializeField]
		private float[] ringRadii;

		[SerializeField]
		private Vector3 initialRingCenter;

		[SerializeField]
		private Transform fenceRoot;

		[SerializeField]
		private MeshRenderer fenceRenderer;

		[SerializeField]
		private float worldSpaceFenceHeight;

		[SerializeField]
		private float worldSpaceFenceHexHorizontalSize;

		[SerializeField]
		private float worldSpaceFenceHexVerticalSize;

		[SerializeField]
		private RecRoomAudioClip loopingOutsideRingSFX;

		[SerializeField]
		private RecRoomAudioClip outsideRingDamageAudio;

		[SerializeField]
		private AudioRolloff nearRingAudioRolloff;

		[SerializeField]
		private AnimationCurve ringSpatialAudioCurve;

		private JOJOABLFOBA BGBIFFLGANM;

		private HONEDBECDOK IFCDBBCODHP;

		private global::HNIFCLKLIPF<int, Vector3, float, Vector3, float> CPFOOOCIKGF;

		private float GAHAPPKDLJI;

		private float IKIIKAALJOP;

		private Vector3 KNOBPCFOMAE;

		private float HIDIGGAGBAF;

		private SFXAudioSource GKPGKHOMONA;

		private bool OADGBEFGODF;

		private static readonly int KHNNIIDMFND;

		private const float LKBNKOCJBLH = 1.27777f;

		private const float CJOLGAJPMIB = 0.25f;

		private const int ICCDOHEFFDI = 32;

public static BattleRoyaleGameplayZone Instance
{
get 		{
			return null;
		}

private set {
		}
}

public bool RingsEnabled
{
get 		{
			return false;
		}

}

public Vector3 LocalRingCenter
{
get 		{
			return default;
		}

private set {
		}
}

public float LocalRingRadius
{
get 		{
			return 0f;
		}

private set {
		}
}

public float NextRingRadius
{
get 		{
			return 0f;
		}

}

public Vector3 NextRingCenter
{
get 		{
			return default;
		}

}

public float CurrentRingRadius
{
get 		{
			return 0f;
		}

}

public Vector3 CurrentRingCenter
{
get 		{
			return default;
		}

}

private int ODLDKPNAONM
{
get 		{
			return 0;
		}

}

private bool DNIEDOMLFDA
{
get 		{
			return false;
		}

set {
		}
}

private float CJOOFHAEOJG
{
get 		{
			return 0f;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void MasterStart()
		{
		}

		public void MasterStop()
		{
		}

		private void MOCHCMFANIJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DFKNPNILOFC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DGPLANNNIDC()
		{
		}

		private Vector3 BJCPKMOFOLI(CHILKDJABBF EKOFNPFCLMO, Vector3 LFKKDKCBLFJ, float LGHMEENHFEE, out float DAMOGGANOJL)
		{
			DAMOGGANOJL = default;
			return default;
		}

		private bool DJGMDFMKFNP(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		private void LPLGCIIDEHN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void GHNODAHJCDH()
		{
		}

		private void HAGNALNOHJP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void GBIMHPLCPCN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DHIOILGAKCO()
		{
		}

		private void CKEGKLHNEEK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void DKPEGAMCEDB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EBCHJIMLBNH()
		{
		}

		private void GGNHFHKDCCO(ushort NPOBJBJLKBP, ushort EDNNIIPAKCK)
		{
		}

		private void BILJBPJAOLF()
		{
		}

		private void KJDMPFGPAIO()
		{
		}

		private void NEDNIBCLLFN(Vector3 MPFGGEAFENL, float NGAGNJLGCIK)
		{
		}

		private void GBIGAMIANPB()
		{
		}

		private void ICFDAFLLKJP(int ICEDAHKJFHM, Vector3 FCEBLIDIDMM, float HJNJEFBMNHB, Vector3 KKFGIEGLBLF, float PMBBCBDPKBO)
		{
		}

		private void PGJNLKJFOJP(string PBOPFHHBNPO)
		{
		}

		private bool OEPFFMNJPEB(Vector3 FCEBLIDIDMM, float HJNJEFBMNHB, float PMBBCBDPKBO, out Vector3 KKFGIEGLBLF)
		{
			KKFGIEGLBLF = default;
			return false;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
