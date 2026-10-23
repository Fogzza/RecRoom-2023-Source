using System;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Inputs
{
	public class ScreenPlayerActionDefinitions : ScriptableObject
	{
		[Serializable]
		public class ScreenPlayerActionDefinition
		{
			public string actionName;

			public SerializedGuid actionId;

			[Space]
			public string playerFacingName;

			public string playerFacingDescription;

			public bool showInControlsDiagram;

			public void LDOEHMAGIIJ()
			{
			}
		}

		public ScreenPlayerActionDefinition[] screenPlayerActions;
	}
}
