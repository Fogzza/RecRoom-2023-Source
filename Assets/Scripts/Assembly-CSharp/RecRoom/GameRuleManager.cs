using System;
using RecRoom.Systems.PlayerRoles;
using UnityEngine;

namespace RecRoom
{
	public abstract class GameRuleManager : NetworkedSingletonMonoBehaviour<GameRuleManager>
	{
		protected class JELMKEHMFLG
		{
			private GameManager KPCADKBOAFA;

			private GameRuleManager HDEADEMJOIM;

			private HONEDBECDOK LIJGJGIGLOD;

			private global::MOBDJNEDDKC<bool> LMIJPPKHCKB;

			private IDisposable GBCLEDIGKAI;

			private float JBENLOKGBAF;

			private float MEKBCIFFLIN;

			private float DFOGAKDBAGN;

public bool OHBDLIIDOOB
{
get 			{
				return false;
			}

set {
			}
}

public bool FNAJFBBPMFF
{
get 			{
				return false;
			}

}

public float DFOKCIHOOPJ
{
get 			{
				return 0f;
			}

}

public float NNOCKLNAKHJ
{
get 			{
				return 0f;
			}

}

public float KDLBMNHMFDO
{
get 			{
				return 0f;
			}

set {
			}
}

public float JGCLGBIPGHK
{
get 			{
				return 0f;
			}

set {
			}
}

public float MBOFCKMFGAH
{
get 			{
				return 0f;
			}

set {
			}
}

			public JELMKEHMFLG(GameManager KPCADKBOAFA, GameRuleManager HDEADEMJOIM)
			{
			}

			public void MPDBFDACICM()
			{
			}

			public void ENOMAEHIGPA()
			{
			}

			public void GIAECEGFIBO()
			{
			}

			public void NKJIMMNPKDG()
			{
			}

			public void AFELIDKEEFL()
			{
			}

			private void CMPPIAHGFOD(float OKBAJEAPIHG)
			{
			}
		}

		[Serializable]
		public struct PlayerStatName
		{
			public string Name;

			public BFPALKJDPLP Stat;
		}

		public const int GAME_RULE_MANAGER_PRIORITY = 500;

		public static readonly global::HHOBPMOCKMJ<GameRuleManager> RuleManagerInstantiatedEvent;

		[SerializeField]
		private string scoreName;

		[SerializeField]
		private PlayerStatName[] playerStatNames;

		[SerializeField]
		private OverridableGameRole customInGameRole;

		[SerializeField]
		private GameRoleSettings customExtraGameRoleSettings;

		private bool FMOLDEMNLIB;

		protected JELMKEHMFLG EMIKPCIEBBL;

public virtual GameRoleSettings CustomExtraGameRoleSettings
{
get 		{
			return null;
		}

}

public virtual bool AutoRunTimer
{
get 		{
			return false;
		}

}

public virtual bool AutoTagRoom
{
get 		{
			return false;
		}

}

public virtual bool CanContinue
{
get 		{
			return false;
		}

set {
		}
}

public bool Started
{
get 		{
			return false;
		}

private set {
		}
}

public abstract string RuleTypeAutoTag
{
get ;
}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public virtual void RecordMatchAnalytics(bool DNKBEOHALFL)
		{
		}

		public virtual bool LocalPlayerHasGameActivity()
		{
			return false;
		}

		protected override void OnDestroy()
		{
		}

		private void JJJAMBPPCGC()
		{
		}

		protected virtual void HDJBEAFJEHD()
		{
		}

		public int GetMillisecondsFromLocalGameStart(float BBGNJMKOHPL)
		{
			return 0;
		}

		protected virtual void ENHEJEADGCH()
		{
		}

		public virtual bool ValidateRoom()
		{
			return false;
		}
	}
}
