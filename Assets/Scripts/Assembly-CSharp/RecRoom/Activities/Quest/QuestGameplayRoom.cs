using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Activities.SubScenes;
using RecRoom.Core.Encounters;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestGameplayRoom : BaseActivitySubScene
	{
		private enum NMCALBGJCFD
		{
			COMPLETE_REQUIRED_ENCOUNTERS = 0,
			OPEN_DOOR = 1
		}

		public enum NELCIKEGLKI
		{
			INACTIVE = 0,
			RUNNING_ENCOUNTERS = 1,
			FINISHED_ENCOUNTERS = 2,
			FINISHED = 3
		}

		[Serializable]
		public struct BranchingRoomExit
		{
			public QuestManager.PCGJIMCMLHD storyState;

			public int roomIndex;
		}

		private sealed class KGEOCJBMAEA
		{
			public GameEncounter[] encounters;

			public int i;

			public Predicate<RandomlyEnabledGameEncounterDesc> _003C_003E9__0;

			internal bool _003CInitializeEncounters_003Eb__0(RandomlyEnabledGameEncounterDesc rand)
			{
				return false;
			}
		}

		private sealed class LMGKBAEECGG : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public QuestGameplayRoom _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public LMGKBAEECGG(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private string friendlyName;

		[SerializeField]
		private GameEncounter[] requiredEncounters;

		[SerializeField]
		private bool supportsFanfare;

		[SerializeField]
		private RandomlyEnabledGameEncounterDesc[] randomlyEnabledEncounters;

		[SerializeField]
		private GameEncounter[] roomEncounters;

		[SerializeField]
		private NMCALBGJCFD encountersFinishCondition;

		[SerializeField]
		private BranchingRoomExit[] nextRoomOverrides;

		[SerializeField]
		private bool toolCleanupEnabled;

		private GameSpawnPoint[] PNCGNPDDIGN;

		private GiftBoxSpawnPoint[] ALNMOPMEEKF;

		private bool KFKJJLPGMHP;

		private JOJOABLFOBA BGBIFFLGANM;

		private List<GameEncounter> EHEJBEFOLHG;

		private QuestRoomExitDoor[] KOAEIKFFBGH;

		private UIProjector[] PNGLODFHFDO;

		private Coroutine MKPBOCFOBNB;

		private bool JFABPJHCDFA;

		private IDisposable JBIPMOMNHNF;

public GameSpawnPoint[] PlayerSpawnPoints
{
get 		{
			return null;
		}

private set {
		}
}

public GiftBoxSpawnPoint[] GiftSpawnPoints
{
get 		{
			return null;
		}

private set {
		}
}

protected override bool OBIOFEFOLFN
{
get 		{
			return false;
		}

}

private bool EIFPLEELMMM
{
set {
		}
}

private bool EIGBKOJICAK
{
set {
		}
}

private bool HBGKGEGCIHK
{
get 		{
			return false;
		}

set {
		}
}

private bool DJLLAPNGJFG
{
set {
		}
}

public NELCIKEGLKI CurrentState
{
get 		{
			return NELCIKEGLKI.INACTIVE;
		}

}

public BranchingRoomExit[] NextRoomOverrides
{
get 		{
			return null;
		}

}

public QuestRoomExitDoor[] Doors
{
get 		{
			return null;
		}

}

protected virtual bool CLPNMIMEFAL
{
get 		{
			return false;
		}

}

public string RoomName
{
get 		{
			return null;
		}

}

private bool IFIEBODMKAE
{
get 		{
			return false;
		}

}

private bool EFJFLBBACJF
{
get 		{
			return false;
		}

}

private bool GGACENLOEEH
{
get 		{
			return false;
		}

}

private bool DMCNIHOPMNM
{
get 		{
			return false;
		}

}

private bool CNFGJGCALPK
{
get 		{
			return false;
		}

}

		public override void Initialize(int HAFOBFDBCJD)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void Activate()
		{
		}

		private void PCFDLMDLCMP(float OKBAJEAPIHG)
		{
		}

		private void DLCHKGIPPPN()
		{
		}

		public void Deactivate()
		{
		}

		public bool IsFinished()
		{
			return false;
		}

		public override void OnLocalPlayerEnter()
		{
		}

		public void PlayRoomNameNotification()
		{
		}

		private void ECIMPKJIEGL(int OOMCLENBFPI)
		{
		}

		private void IFNFFKPMLOH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void MKKNNFEKOHP()
		{
		}

		private void KBDEFMLJMEH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KMDIIKJAGCJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void Start()
		{
		}

		private void IDEAIBOFHLM()
		{
		}

		private void HDIPNGNNIKN()
		{
		}

		private void BDHGAJIKLEB(bool DJNONEKEEPK)
		{
		}

		private void CHCHDFNLMGO()
		{
		}

		public void InitializeSpawnPoints()
		{
		}

		private void GIAECCFBANO()
		{
		}

		private void EOGOAHACGOA()
		{
		}

		private void NADJEPEFKCA()
		{
		}

		private void PLIEJABMIEB()
		{
		}

		private bool GIHGKNPCNBF(IEnumerable<CHILKDJABBF> BAILIMLNNGP)
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcRequestMasterFinishRoom()
		{
		}

		public void MasterFinishRoom()
		{
		}

		private void KFEBOBBIDDO()
		{
		}

		private void OHDINHHNCNI()
		{
		}

		private void DBKOCMCFMCD(float FHFDDKOBFLG)
		{
		}

		private void MBGOEDLEHKB()
		{
		}

		private IEnumerator OJJBDAPENGL(float FHFDDKOBFLG)
		{
			return null;
		}

		private void IBHMGHNFMGC()
		{
		}
	}
}
