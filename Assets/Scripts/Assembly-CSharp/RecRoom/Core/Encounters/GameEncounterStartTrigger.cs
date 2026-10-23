using System;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public abstract class GameEncounterStartTrigger : MonoBehaviour
	{
		protected GameEncounter CGBFJFNKJFN;

		protected int IJNHGKCENED;

public abstract string Description
{
get ;
}

		public virtual void OnAwake(GameEncounter CGBFJFNKJFN, int IJNHGKCENED)
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

		public abstract void StartListening();

		public abstract bool IsTriggered();

		public abstract void StopListening();

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
