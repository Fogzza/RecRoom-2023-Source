using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using RecRoom.Core.AI;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.AI
{
	public class QuestAIController : UGCAIController, DJLCHGFCFAD
	{
		private enum KEBNFICCMJJ
		{
			INVALID = -1,
			PATHING = 0,
			COMPLETE = 1,
			CANCELED = 2
		}

		private sealed class CONEHMLGMNE
		{
			public QuestAIController _003C_003E4__this;

			public Vector3 position;

			internal void _003CPathTo_003Eb__0()
			{
			}
		}

		private sealed class DOJPIHKLJMD
		{
			public QuestAIController _003C_003E4__this;

			public UGCAIPathPoint patrolPoint;

			internal void _003CPathTo_003Eb__0()
			{
			}
		}

		private sealed class IDPNIHGLDBO
		{
			public QuestAIController _003C_003E4__this;

			public UGCAIPathPoint startPoint;

			internal void _003CSetPatrol_003Eb__0()
			{
			}
		}

		private sealed class EOOAOAOMIIG
		{
			public bool forceNonPlanar;

			public QuestAIController _003C_003E4__this;

			public Vector3 direction;

			internal void _003CLookAtDirection_003Eb__0()
			{
			}
		}

		private sealed class PADPAJPPLKJ
		{
			public QuestAIController _003C_003E4__this;

			public DBIPHDIEBCM doneSpawningPromise;

			internal void _003CWaitUntilDoneSpawning_003Eb__0()
			{
			}
		}

		private sealed class LMENNIOMBMO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public QuestAIController _003C_003E4__this;

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
			public LMENNIOMBMO(int _003C_003E1__state)
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

		private const float BDELKPPHMPN = 20f;

		private static readonly string JENADLAAOHG;

		private static readonly float JKHMMEBLHJF;

		[SerializeField]
		private KDBKBBGOBIP type;

		[SerializeField]
		private Vector3 spawnOffset;

		[SerializeField]
		private GameObject meshRoot;

		[SerializeField]
		private GameObject interactionRoot;

		private static float BMKBHACGNPF;

		private QuestAiConfiguration[] DEHHCKDGLJD;

		private global::MOBDJNEDDKC<int> HFGDEOIIGGO;

		private global::MOBDJNEDDKC<GIBEGHKMCIE> NJBADKMEAIM;

		private global::MOBDJNEDDKC<KEBNFICCMJJ> LKLMKMADKPG;

		private Enemy JIBBMICOBPM;

public override bool IsInstantiated
{
get 		{
			return false;
		}

}

public override int AIPhotonViewId
{
get 		{
			return 0;
		}

}

public override Vector3 GroundPosition
{
get 		{
			return default;
		}

}

public override Vector3 Position
{
get 		{
			return default;
		}

}

public override Vector3 HeadPosition
{
get 		{
			return default;
		}

}

public override Quaternion Rotation
{
get 		{
			return default;
		}

}

public override Vector3 Velocity
{
get 		{
			return default;
		}

}

public override float MaxPathingSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public override int Health
{
get 		{
			return 0;
		}

set {
		}
}

public override int MaxHealth
{
get 		{
			return 0;
		}

set {
		}
}

public override bool IsAlive
{
get 		{
			return false;
		}

}

public override DPMOPDDAJBJ Target
{
get 		{
			return default;
		}

set {
		}
}

public override Enemy.MHOMBEOIIIG LineOfSightDirection
{
get 		{
			return Enemy.MHOMBEOIIIG.OMNIDIRECTIONAL;
		}

}

public override float LineOfSightDistance
{
get 		{
			return 0f;
		}

}

public override float LineOfSightVisionConeAngle
{
get 		{
			return 0f;
		}

}

private Enemy JOHIJDMCEIA
{
get 		{
			return null;
		}

set {
		}
}

public Enemy SpawnedEnemy
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

set {
		}
}

private KEBNFICCMJJ DLACIICAHNJ
{
get 		{
			return KEBNFICCMJJ.PATHING;
		}

set {
		}
}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Spawn()
		{
		}

		private void ILJKOJOAMAC(Vector3 NEJGLOLFEMA, Quaternion BBAIBGOOPJA)
		{
		}

		public override void Despawn()
		{
		}

		public override void Kill()
		{
		}

		public override void TeleportTo(Vector3 BAGMHHCMNNF, Quaternion DNEFKBEHEEC)
		{
		}

		public override void PathTo(Vector3 INLGLHIPOMC)
		{
		}

		public override void PathTo(UGCAIPathPoint KICKMPFFGDE)
		{
		}

		public override void SetPatrol(UGCAIPathPoint IGMJIDHLCBG)
		{
		}

		public override void LookAt(Vector3 INLGLHIPOMC)
		{
		}

		public override void LookAtDirection(Vector3 HLFIBIDOLEF, bool DMBJOIJMOIH = false)
		{
		}

		public override void StopLooking()
		{
		}

		public override void UseObstacleAvoidance(bool CFEOANOPDKA)
		{
		}

		private DBIPHDIEBCM JDIBFOJMIKO()
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> LPELJJONFJC()
		{
			return null;
		}

		public override void StartCombatBehavior()
		{
		}

		public override void StopCombatBehavior()
		{
		}

		public override void TakeDamage(int FDDPFMJOHLO, bool GJDPKDEDBBI, DPMOPDDAJBJ AGMGLGGBLBH)
		{
		}

		public override bool HasLineOfSight(Vector3 INLGLHIPOMC)
		{
			return false;
		}

		protected override void LBLEKNIEBOC(CreationObject ICHBECDKHOJ, int LAGADKBKLAD)
		{
		}

		public override void SetLineOfSightParameters(Enemy.MHOMBEOIIIG HBKAOEDJHLM, float DMOILOHGMLJ, float PLEEKPIMLLF, float JEHCNJNPPJE, bool BHNFNGGIPCA)
		{
		}

		private string BNAPBGOIHHB()
		{
			return null;
		}

		private void JILMHHGBGPO()
		{
		}

		private void PBPAFHKCNNI(Enemy DPENEFKKNDN)
		{
		}

		private void JEFFNCMDGCM(Enemy DPENEFKKNDN)
		{
		}

		private void PLIFEAPAPOC()
		{
		}

		private void DAFKBHGEFHJ(CHILKDJABBF HIGOLKPFBPL)
		{
		}

		private void LLKFGDEHLMM(Enemy DPENEFKKNDN)
		{
		}

		private void MDODKBLBPHJ(Enemy DPENEFKKNDN, DPMOPDDAJBJ NJDHAACHDKF)
		{
		}

		private void OPAFAKOAKKF(Enemy DPENEFKKNDN, DPMOPDDAJBJ GCPDONMPCIG)
		{
		}

		private void BCHCMMBJPDN(Enemy DPENEFKKNDN, DPMOPDDAJBJ ELMIEBMCNIN, Tool DAIGPMJPLNN, Vector3 NIICPJIHEGG)
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private bool OPHCOABOGAD()
		{
			return false;
		}

		[CompilerGenerated]
		private int PGAGKNNMKKI()
		{
			return 0;
		}

		[CompilerGenerated]
		private void MONILDENAFM(int IPMIIEAGJKC)
		{
		}
	}
}
