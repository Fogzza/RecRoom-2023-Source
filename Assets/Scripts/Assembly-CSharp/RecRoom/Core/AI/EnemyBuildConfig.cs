using System;
using UnityEngine;

namespace RecRoom.Core.AI
{
	[Serializable]
	public class EnemyBuildConfig : ScriptableObject
	{
		[Serializable]
		public class Config
		{
			public string FriendlyName;

			public Enemy Prefab;

			public LPOIMGOKCOC BehaviorType;

			public string EnemyDamageFriendlyNameString;

			public EnemyRuntimeConfig.Config MPPCHNIIAEN()
			{
				return null;
			}
		}

		public float FlyingEnemySpawnHeight;

		public Config[] Enemies;
	}
}
