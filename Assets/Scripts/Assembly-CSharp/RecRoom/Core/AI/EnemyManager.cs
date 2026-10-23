using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.AI
{
	public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
	{
		private class FLABBGHDMLL
		{
			public List<DPMOPDDAJBJ> DKJEDFMFMGG;

			public Vector3 JNACECJILEC;
		}

		private const int BBMGLBAKCKI = 15;

		private const int CNAAMBPINNL = 5;

		private const int POPCHGKPFBI = 5;

		private const float BNHNFGIKGNM = 100f;

		private const int IMFAAEBDBLP = 100;

		[SerializeField]
		private List<KDBKBBGOBIP> preLoadedEnemyTypes;

		private static int LHKAFMMBLMN;

		private static readonly List<float> DHJKFGLGMIO;

		private static readonly Dictionary<GIBEGHKMCIE, FLABBGHDMLL> DNNHCIHMLCK;

		private static readonly List<Enemy> LICCBKAAKBJ;

		public static bool SupportsEnemyOnEnemyFriendlyFire;

		public static bool SupportsPlayerOnEnemyFriendlyFire;

public static List<Enemy> AllEnemies
{
get 		{
			return null;
		}

}

public static int EnemyCount
{
get 		{
			return 0;
		}

}

public static int AggrodEnemyCount
{
get 		{
			return 0;
		}

}

public bool IgnorePlayers
{
get 		{
			return false;
		}

}

private GIBEGHKMCIE PLINCHMNMKL
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
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

		public void RegisterEnemy(Enemy DPENEFKKNDN)
		{
		}

		public void UnregisterEnemy(Enemy DPENEFKKNDN)
		{
		}

		private void KBHCHOOMKDO()
		{
		}

		public bool TargetIsAlive(DPMOPDDAJBJ GFCPAMJILIO)
		{
			return false;
		}

		public bool IsAlly(GIBEGHKMCIE NEBNOBLPNEP, DPMOPDDAJBJ GFCPAMJILIO)
		{
			return false;
		}

		public bool IsAlly(GIBEGHKMCIE NEBNOBLPNEP, Enemy DPENEFKKNDN)
		{
			return false;
		}

		public bool IsAlly(GIBEGHKMCIE NEBNOBLPNEP, CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		public bool IsValidAttack(Enemy NJDDIIEPJDM, DPMOPDDAJBJ NJDHAACHDKF)
		{
			return false;
		}

		public DPMOPDDAJBJ GetAggrodAllyInRadius(Enemy JMBOIKNLKPH, float NNLEGJGIGHA)
		{
			return default;
		}

		public DPMOPDDAJBJ GetClosestOpponent(Enemy JMBOIKNLKPH, float GKJHODLJDHD, bool NDJGMHEDNIH, out float EILLKKHBBIB)
		{
			EILLKKHBBIB = default;
			return default;
		}

		public void GetOpponentsInRadius(Enemy JMBOIKNLKPH, float EKGNBFKIEIB, bool IHHGIOAJILJ, List<DPMOPDDAJBJ> JIJJKAIMKAK)
		{
		}

		public void GetOpponentsInRadius(Enemy JMBOIKNLKPH, float HDLKDCGLGAI, float EKGNBFKIEIB, bool IHHGIOAJILJ, List<DPMOPDDAJBJ> JIJJKAIMKAK)
		{
		}

		public void GetOpponentsInVisionCone(Enemy JMBOIKNLKPH, Vector3 CKPDACEBMHF, Vector3 PPHCAGJCENA, Vector3 FDGAFEFHAFB, float GDIENBGMGIB, float GKJHODLJDHD, float HNBKFPCHOOC, bool NCHEFPKLNNN, bool IHHGIOAJILJ, List<DPMOPDDAJBJ> JIJJKAIMKAK)
		{
		}

		public bool TryGetOpponentCentroid(Enemy JMBOIKNLKPH, out Vector3 KCHAIAINPHG)
		{
			KCHAIAINPHG = default;
			return false;
		}

		public int GetOtherEnemyTargetCount(DPMOPDDAJBJ GFCPAMJILIO)
		{
			return 0;
		}

		public void AuthorityAddEnemyTargetCount(Enemy JMBOIKNLKPH, DPMOPDDAJBJ GFCPAMJILIO, int FKHDPLPGMAK)
		{
		}

		private float NEMBJLANNMJ(Enemy DPENEFKKNDN)
		{
			return 0f;
		}

		private void LOJGHPBOHJB()
		{
		}

		private void HKLGMEGDJFD(GHCCKFEJDOA OINNDPBJCNN)
		{
		}

		private void BBJHDJHPNMC()
		{
		}

		private void LOMEHIFAAGI(CHILKDJABBF EKOFNPFCLMO, GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void LOMEHIFAAGI(Enemy DPENEFKKNDN, GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void BDIBJIMAAJJ(DPMOPDDAJBJ GFCPAMJILIO, GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void MPJIIPAIDNO(Enemy JMBOIKNLKPH, float NNLEGJGIGHA, bool IHHGIOAJILJ, List<DPMOPDDAJBJ> JIJJKAIMKAK)
		{
		}
	}
}
