using Photon.Pun;
using UnityEngine;

namespace RecRoom.Activities.Arena
{
	public class ArenaBase : MonoBehaviourPun
	{
		private enum OPABINDHCJJ
		{
			INACTIVE = 0,
			CONTESTED = 1,
			CAPTURING = 2,
			RUNNING = 3
		}

		private enum NDCBNNHKLKG
		{
			NONE = 0,
			ON_SINGLE_TEAM = 1,
			ON_MULTIPLE_TEAMS = 2
		}

		[SerializeField]
		private string baseName;

		[SerializeField]
		private float onActivateInitialWaveDelay;

		[SerializeField]
		private float waveDuration;

		[SerializeField]
		private EncounterDescriptor blueTeamEncounterPrefab;

		[SerializeField]
		private EncounterDescriptor redTeamEncounterPrefab;

		[SerializeField]
		private bool canChangeTeam;

		[SerializeField]
		private GIBEGHKMCIE defaultTeam;

		[SerializeField]
		private Transform captureCenter;

		[SerializeField]
		private float captureRadius;

		[SerializeField]
		private float captureDuration;

		[SerializeField]
		private float returnToOwningTeamDuration;

		[SerializeField]
		private LockableDoor blueTeamPortal;

		[SerializeField]
		private LockableDoor redTeamPortal;

		[SerializeField]
		private ArenaEncounterSpawner encounterSpawner;

		private GameManager CFHBAJKJPFJ;

		private ArenaBaseVisuals LKIAJIGIEHM;

		private JOJOABLFOBA BGBIFFLGANM;

		private HONEDBECDOK PLPHABIOJNH;

		private global::MOBDJNEDDKC<GIBEGHKMCIE> HDDHADFGJON;

		private global::MOBDJNEDDKC<GIBEGHKMCIE> OMOHALOPKGL;

		private global::MOBDJNEDDKC<float> GLFOMDENKBG;

private GIBEGHKMCIE POKLLJBENFE
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
		}

set {
		}
}

private GIBEGHKMCIE PJPEJGPCGPP
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
		}

set {
		}
}

private float OPOBKHLAAHK
{
get 		{
			return 0f;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		public void Initialize(ArenaManager CFHBAJKJPFJ)
		{
		}

		public void MasterActivate()
		{
		}

		public void MasterDeactivate()
		{
		}

		private void ONCKMBEJGAD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CMPBHPBCMEC()
		{
		}

		private void MPHDIDJBNMH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void KNGDEIFCOKA()
		{
		}

		private void GGKMKKKAHCM(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void MCEHGFOHDIC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void AEJCJGCNDCL()
		{
		}

		private void JOPGJKMAMLF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private float HCCDIHOCDPE()
		{
			return 0f;
		}

		private float PFOAIJEOIDE()
		{
			return 0f;
		}

		private void MHGBPFABJBI()
		{
		}

		private NDCBNNHKLKG KAJIFKICGNB(GIBEGHKMCIE KPKJBJJCLBP, out GIBEGHKMCIE GKEFACJICNN)
		{
			GKEFACJICNN = default;
			return NDCBNNHKLKG.NONE;
		}

		private bool PBLECMCHLIG(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		private Color MMOGJAINOCD(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return default;
		}

		private string APCPAMGHBKD(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
