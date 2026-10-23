using System;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public abstract class GameEncounterStep : MonoBehaviour
	{
		[SerializeField]
		protected string stepName;

		[SerializeField]
		protected int finishCondition;

		[SerializeField]
		protected int finishValue;

		protected GameEncounter CGBFJFNKJFN;

		protected int GNNALAJAMKB;

		protected KBJKDKFNFIA KLIJMCAEKKB;

		protected KBJKDKFNFIA CIMGEOHGFJK;

public string StepName
{
get 		{
			return null;
		}

}

public abstract string Description
{
get ;
}

		public virtual void OnAwake(GameEncounter CGBFJFNKJFN, int GNNALAJAMKB, KBJKDKFNFIA KLIJMCAEKKB, KBJKDKFNFIA CIMGEOHGFJK)
		{
		}

		public virtual void OnCleanup()
		{
		}

		public virtual void OnEncounterActivate()
		{
		}

		public virtual void OnEncounterDeactivate()
		{
		}

		public abstract void OnEncounterStart();

		public abstract void OnEncounterStop();

		public abstract void OnStartRunning();

		public abstract void OnUpdateRunning();

		public abstract void OnStopRunning();

		public abstract void OnSkipRunning();

		public abstract bool IsBlockingEncounterEnd();

		public abstract bool IsCompleted();

		protected void PCKILAFDHFI(string AHADDDAMGKE)
		{
		}

		protected void MEBPALIGFAK(string AHADDDAMGKE)
		{
		}

		protected void DEPHNJDEMPM(string AHADDDAMGKE)
		{
		}

		private string HHCHGFLJFLK(string AHADDDAMGKE)
		{
			return null;
		}

		protected string KMONHNGJNKK(string FDAIMOMOHIG)
		{
			return null;
		}

		public static string ParseFriendlyTypeName(Type NIFOGEBEDNG)
		{
			return null;
		}
	}
}
