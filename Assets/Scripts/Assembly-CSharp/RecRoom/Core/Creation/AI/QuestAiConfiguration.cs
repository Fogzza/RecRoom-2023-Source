using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Creation.AI
{
	public abstract class QuestAiConfiguration : MonoBehaviour
	{
		public abstract void SetupSynchronizedFields(JPEAKDKPCGM NEHBOBJIBEC);

		public abstract void AddInstantiationParams(Dictionary<string, object> HMJOKPKOPCN);

		public abstract int AddConfigurableSettings(CreationObject ICHBECDKHOJ, AKCHPHOMHLH POAGNGMDMGB, int LAGADKBKLAD);

		public abstract void DeserializeFrom(ACBOEIAGKJL GBJAJCMANGI, FBLAHKFEHNM LJFNCCMLIDM);

		public abstract void SerializeTo(ACBOEIAGKJL GBJAJCMANGI);
	}
}
