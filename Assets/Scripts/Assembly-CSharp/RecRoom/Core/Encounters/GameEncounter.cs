using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class GameEncounter : MonoBehaviourPun
	{
		private enum ANBKIHBDPFK
		{
			INACTIVE = 0,
			WAITING_FOR_TRIGGER = 1,
			RUNNING_STEPS = 2,
			FINISHED = 3
		}

		private enum OPFNDBAICBC
		{
			WAITING_FOR_STEP_COMPLETION = 0,
			INITIAL_STEP = 1
		}

		private enum OAIAPNBJHOH
		{
			INSTANTIATOR_ID = 0,
			INSTANTIATION_PARAMS = 1,
			AUTOMATICALLY_ACTIVATE = 2,
			TEAM_ID = 3,
			OVERRIDE_PATROL_ID = 4,
			VALUE_COUNT = 5
		}

		public delegate void JHDBGJIFNNL(GameEncounter CGBFJFNKJFN);

		[SerializeField]
		private GameEncounterStartTrigger[] startTriggers;

		[SerializeField]
		private GameEncounterStep[] steps;

		private HONEDBECDOK CIMGEOHGFJK;

		private HONEDBECDOK KLIJMCAEKKB;

		private JOJOABLFOBA BGBIFFLGANM;

		private bool DCECLAKALBD;

		private bool CGHKOCBCKFB;

		private bool OEAONLGBBPN;

		public static global::HHOBPMOCKMJ<GameEncounter> GameEncounterInstantiatedEvent;

		public static global::HHOBPMOCKMJ<GameEncounter> GameEncounterDestroyedEvent;

		private int HGPNIBBIJPE;

		private Dictionary<string, object> DMDCPHJIGKG;

		private GIBEGHKMCIE IAIOPJHCCEJ;

		private EnemyPatrol CNHIKOMDMGE;

		private bool LNOHIOKFPBD;

		private GameManager BFPJLNAKJPP;

public GameEncounterStep[] Steps
{
get 		{
			return null;
		}

}

public int InstantiatorPhotonViewId
{
get 		{
			return 0;
		}

private set {
		}
}

public Dictionary<string, object> InstantiationParameters
{
get 		{
			return null;
		}

private set {
		}
}

public GIBEGHKMCIE Team
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
		}

private set {
		}
}

public EnemyPatrol OverridePatrol
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsActive
{
get 		{
			return false;
		}

}

public bool IsRunning
{
get 		{
			return false;
		}

}

public bool IsFinished
{
get 		{
			return false;
		}

}

public bool IsWaitingForTrigger
{
get 		{
			return false;
		}

}

public bool IsBeingTornDown
{
get 		{
			return false;
		}

private set {
		}
}

public GameManager Game
{
get 		{
			return null;
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

		protected override void OnDestroy()
		{
		}

		public void Initialize()
		{
		}

		public T GetStep<T>() where T : GameEncounterStep
		{
			return null;
		}

		public T GetStepBeforeIndex<T>(int MCMIIFGJDJG) where T : GameEncounterStep
		{
			return null;
		}

		public T[] GetSteps<T>() where T : GameEncounterStep
		{
			return null;
		}

		public T[] GetStepsBeforeIndex<T>(int MCMIIFGJDJG) where T : GameEncounterStep
		{
			return null;
		}

		public int GetStepCount<T>() where T : GameEncounterStep
		{
			return 0;
		}

		public int GetStepCountBeforeIndex<T>(int MCMIIFGJDJG) where T : GameEncounterStep
		{
			return 0;
		}

		private ushort MDDFOHFHBLI(int DKNDDGCEKDH)
		{
			return 0;
		}

		private int HFGNKBFFDOP()
		{
			return 0;
		}

		private GameEncounterStep FOAHFNBOAGO()
		{
			return null;
		}

		public void MasterActivate()
		{
		}

		public void MasterDeactivate(bool NNLKFJOBALI = false)
		{
		}

		private void Update()
		{
		}

		private void JNLNGJHMMFJ()
		{
		}

		private void CANDLFMBAAF()
		{
		}

		private void ONCKMBEJGAD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void LMMHKJJDDBL()
		{
		}

		private void IHFFKLFMFOI(ushort BNDEPNFOAFE, ushort HKDHPIPECPL)
		{
		}

		private void GPDOGGFOOEO()
		{
		}

		private void CAGKFFKIDFM(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private bool GMOAFIBIOFO()
		{
			return false;
		}

		private void IJDLDLOFNNF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ECNAJCDEPEA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KCNFJJOPHFE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ADNMGKJCMOK()
		{
		}

		private void NDJINDHAHJC(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void NJGJPMCCHFA()
		{
		}

		private void HBMMOCHNGJD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ONNNFMFCHIH()
		{
		}

		public static GameEncounter MasterInstantiate(string BNMICPAMOFB, bool CGHKOCBCKFB, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, GIBEGHKMCIE NEBNOBLPNEP, EnemyPatrol MKMEEOCJIBJ, PhotonView FEJBBOECEOC, Dictionary<string, object> ENFEHHMJMLG)
		{
			return null;
		}

		public static void MasterDestroy(GameEncounter CGBFJFNKJFN)
		{
		}
	}
}
