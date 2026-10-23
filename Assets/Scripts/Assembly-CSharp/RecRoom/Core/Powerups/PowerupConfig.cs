using System;
using UnityEngine;

namespace RecRoom.Core.Powerups
{
	[Serializable]
	public class PowerupConfig : ScriptableObject
	{
		[Serializable]
		public class Config
		{
			public string FriendlyName;

			public Powerup Prefab;
		}

		[SerializeField]
		public Config[] Powerups;
	}
}
