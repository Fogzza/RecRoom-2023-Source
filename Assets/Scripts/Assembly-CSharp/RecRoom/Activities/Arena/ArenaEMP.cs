using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Activities.Arena
{
	public class ArenaEMP : MonoBehaviourPun
	{
		public delegate void GNAEKLNPCCA(ArenaEMP JBKMOGLFGKA, CHILKDJABBF EKOFNPFCLMO);

		private enum NDOIIBBGFPH
		{
			NOT_IN_EMP_SITE = 0,
			IN_EMP_SITE = 1,
			ATTACHED_TO_MAINFRAME = 2,
			ARMED = 3,
			DETONATED = 4,
			DEFUSED = 5
		}

		private enum EDCDNJPJMDP
		{
			READY_TO_ARM = 0,
			ARMING = 1
		}

		private enum FCKGMLMHBGL
		{
			ARMED = 0,
			DISARMING = 1
		}

		[SerializeField]
		private float armDuration;

		[SerializeField]
		private SimpleVolume attachmentSearchVolume;

		[SerializeField]
		private BoxCollider attachmentSnapCollider;

		[SerializeField]
		private float detonateDelay;

		[SerializeField]
		private float disarmDuration;

		[SerializeField]
		private float buttonDischargeDuration;

		[SerializeField]
		private RendererMaterialPair glowRenderer;

		[SerializeField]
		private Color dimColor;

		[SerializeField]
		private Color glowColor;

		[SerializeField]
		private RecRoomAudioClip onMainframeAttachAudio;

		[SerializeField]
		private RecRoomAudioClip buttonHoldAudio;

		[SerializeField]
		private float minWarningFrequency;

		[SerializeField]
		private float maxWarningFrequency;

		[SerializeField]
		private AnimationCurve warningFrequencyCurve;

		[SerializeField]
		private RecRoomAudioClip warningBeepAudio;

		[SerializeField]
		private RecRoomAudioClip onArmAudio;

		[SerializeField]
		private RecRoomAudioClip loopingArmedAudio;

		[SerializeField]
		private RecRoomAudioClip detonationAudio;

		[SerializeField]
		private float detonationParticlesDelay;

		[SerializeField]
		private PooledParticle detonationParticlePrefab;

		[SerializeField]
		private RecRoomAudioClip defusedAudio;

		[SerializeField]
		private Tool tool;

		private KBJKDKFNFIA BBJGMGLKDHL;

		private HONEDBECDOK IFCDBBCODHP;

		private JOJOABLFOBA BGBIFFLGANM;

		private ToolPlayerAttractor HGLOCNLDGEL;

		private ChargePhysicalButton HHDMPJJAPJJ;

		private SFXAudioSource EKJMINEJJNA;

		private SFXAudioSource PANOGPMBGAI;

		private int LOAFBJBAKFP;

		public static GNAEKLNPCCA ArmEvent;

		public static GNAEKLNPCCA DefuseEvent;

public bool Armed
{
get 		{
			return false;
		}

}

public bool Detonated
{
get 		{
			return false;
		}

}

public bool Defused
{
get 		{
			return false;
		}

}

		public void Initialize(ArenaManager CFHBAJKJPFJ)
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void MAOPAHLHKNN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void PIPIPOHALHG()
		{
		}

		private void GBIMKKFOPJA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BGLHCCINJEB()
		{
		}

		private void LAACKKIPIHP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CFFIPPCBIGO()
		{
		}

		private void MBIKCNLJJKG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void IOLKACMNBPC()
		{
		}

		private void DLJLNDJCHHJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BDEGBJLMADK()
		{
		}

		private void OJALENEHNKA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void OALEPIIPFPI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void PLJIEKCOIOI()
		{
		}

		private void NPHINKBMDFF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void BOOABAHFGEE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ABDPBLHEKAH()
		{
		}

		private void OIBGBEAJCEF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FCFHDFKDBFA()
		{
		}

		private void DNKLMEIPOPJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void GPJPAEFLABD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void LGKKDKMIJFH()
		{
		}

		private void GJMJKOOEIMO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private bool FHPIBOJIIHA(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private void GJCLGHAONAN(Tool IEGMBEPJMGC)
		{
		}

		private bool BHMCNIBDKAC(out Vector3 HJHIKGCKAEM, out Quaternion EJIMNHBOGHM)
		{
			HJHIKGCKAEM = default;
			EJIMNHBOGHM = default;
			return false;
		}

		private void LCCKAPFKOON(ChargePhysicalButton HHDMPJJAPJJ)
		{
		}

		private bool ALEOFGPCIJJ(ChargePhysicalButton HHDMPJJAPJJ, CHILKDJABBF GFGBFAAOLIH, PlayerHand DPFFFKMKJME)
		{
			return false;
		}

		private void OHNMLICLDFP()
		{
		}

		private void FAFONEDCNBF()
		{
		}

		private void OJGGODOCMOD()
		{
		}

		private void FDDLEPCKMOH(Color HMCAFGCGFJF)
		{
		}

		private void KPCAALNMJAL()
		{
		}

		private void OKDCKJJAKJP()
		{
		}

		private void KPNDEIMJMKF()
		{
		}

		private void CGOOLNBMAAG()
		{
		}

		private void JBEJGNPICMA(float BCPIHGPGDEE)
		{
		}

		private bool DKFABKPMHOH(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}
	}
}
