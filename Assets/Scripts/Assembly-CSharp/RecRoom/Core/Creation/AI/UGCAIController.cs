using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.AI;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.AI
{
	public abstract class UGCAIController : MonoBehaviourPun, GFLPAFBGELM, NEKJJEGPHFG
	{
		[SerializeField]
		protected Tool Tool;

		[SerializeField]
		private ControlPanelCircuitObject ControlPanelCircuitObject;

		[SerializeField]
		private CreationObject CreationObject;

		private static readonly global::HHOBPMOCKMJ<UGCAIController> FFGOBLHMAHJ;

		private static readonly global::BPEPJJDICII<UGCAIController, DPMOPDDAJBJ> LMJDDHMOPDL;

		private static readonly global::BPEPJJDICII<UGCAIController, DPMOPDDAJBJ> LFCAEEPIMAE;

		private static readonly global::KAJFMPHPBGO<UGCAIController, DPMOPDDAJBJ, CreationObject, Vector3> KLJOGHCFJFH;

		private static readonly global::HHOBPMOCKMJ<UGCAIController> IKJGNAEBHHI;

		private static readonly global::HHOBPMOCKMJ<UGCAIController> CHLHFIMCCIB;

public abstract bool IsInstantiated
{
get ;
}

public abstract int AIPhotonViewId
{
get ;
}

public abstract Vector3 GroundPosition
{
get ;
}

public abstract Vector3 Position
{
get ;
}

public abstract Vector3 HeadPosition
{
get ;
}

public abstract Quaternion Rotation
{
get ;
}

public abstract Vector3 Velocity
{
get ;
}

public abstract float MaxPathingSpeed
{
get ;
set ;
}

public abstract int Health
{
get ;
set ;
}

public abstract int MaxHealth
{
get ;
set ;
}

public abstract bool IsAlive
{
get ;
}

public abstract DPMOPDDAJBJ Target
{
get ;
set ;
}

public abstract Enemy.MHOMBEOIIIG LineOfSightDirection
{
get ;
}

public abstract float LineOfSightDistance
{
get ;
}

public abstract float LineOfSightVisionConeAngle
{
get ;
}

protected bool GLMEGNOMBGG
{
get 		{
			return false;
		}

}

public static global::GEBDAEJFJCK<UGCAIController> AISpawned
{
get 		{
			return null;
		}

}

public static global::BEHMNCHGIOA<UGCAIController, DPMOPDDAJBJ> AIDied
{
get 		{
			return null;
		}

}

public static global::BEHMNCHGIOA<UGCAIController, DPMOPDDAJBJ> AITargetChanged
{
get 		{
			return null;
		}

}

public static global::NIPBACIHKDG<UGCAIController, DPMOPDDAJBJ, CreationObject, Vector3> AIHeardSound
{
get 		{
			return null;
		}

}

public static global::GEBDAEJFJCK<UGCAIController> AIPatrolCompleted
{
get 		{
			return null;
		}

}

public static global::GEBDAEJFJCK<UGCAIController> AIPatrolCanceled
{
get 		{
			return null;
		}

}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
		}

}

		protected void ONFMOHDBPIK(UGCAIController IHPJCBCPLCM)
		{
		}

		protected void AAPFOLMJCDJ(UGCAIController IHPJCBCPLCM, DPMOPDDAJBJ DJGCMHNEBOC)
		{
		}

		protected void PAOGGMOPFGA(UGCAIController IHPJCBCPLCM, DPMOPDDAJBJ DJGCMHNEBOC)
		{
		}

		protected void OIPCDJGFCPB(UGCAIController IHPJCBCPLCM, DPMOPDDAJBJ DJGCMHNEBOC, CreationObject MLIPDLAHDHI, in Vector3 NHEDGPECFAM)
		{
		}

		protected void JFLFEKHBKBE(UGCAIController IHPJCBCPLCM)
		{
		}

		protected void IFMOKJFPPEP(UGCAIController IHPJCBCPLCM)
		{
		}

		protected virtual void Start()
		{
		}

		private static OBIIECHNFJK KMNDAGHAGDM()
		{
			return OBIIECHNFJK.NotSupported;
		}

		protected override void OnDestroy()
		{
		}

		public abstract void Spawn();

		public abstract void Despawn();

		public abstract void Kill();

		public abstract void TeleportTo(Vector3 BAGMHHCMNNF, Quaternion DNEFKBEHEEC);

		public abstract void PathTo(Vector3 INLGLHIPOMC);

		public abstract void PathTo(UGCAIPathPoint KICKMPFFGDE);

		public abstract void SetPatrol(UGCAIPathPoint IGMJIDHLCBG);

		public abstract void LookAt(Vector3 INLGLHIPOMC);

		public abstract void LookAtDirection(Vector3 HLFIBIDOLEF, bool DMBJOIJMOIH = false);

		public abstract void StopLooking();

		public abstract void UseObstacleAvoidance(bool CFEOANOPDKA);

		public abstract void StartCombatBehavior();

		public abstract void StopCombatBehavior();

		public abstract void TakeDamage(int FDDPFMJOHLO, bool GJDPKDEDBBI, DPMOPDDAJBJ AGMGLGGBLBH);

		public abstract bool HasLineOfSight(Vector3 INLGLHIPOMC);

		protected virtual void MNECEOLGCKC()
		{
		}

		protected abstract void LBLEKNIEBOC(CreationObject ICHBECDKHOJ, int LAGADKBKLAD);

		public abstract void SetLineOfSightParameters(Enemy.MHOMBEOIIIG HBKAOEDJHLM, float DMOILOHGMLJ, float PLEEKPIMLLF, float JEHCNJNPPJE, bool IGLAJPKHIKJ);

		private global::FAIKNKAIPLB<OHAJOLBEFND> DCBNIOPDHIN(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		global::FAIKNKAIPLB<OHAJOLBEFND> GFLPAFBGELM.Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DCBNIOPDHIN
			return this.DCBNIOPDHIN(GCBHEJANCJK);
		}

		private void DDBOHLKEFBM(UGCAIController HBEKDJPJIAD)
		{
		}

		private void BEANLOCOEDA(UGCAIController HBEKDJPJIAD, DPMOPDDAJBJ NJDHAACHDKF)
		{
		}

		private void KBCLJHGNPBI(DPMOPDDAJBJ GCPDONMPCIG)
		{
		}

		private void CPOOPCKNFLB(DPMOPDDAJBJ MMJCBNNHBGI, CreationObject GIBNNMGAAHO, in Vector3 NIICPJIHEGG)
		{
		}

		private void AMGPLEIACIJ()
		{
		}

		private void FFLLCFODFKK()
		{
		}
	}
}
