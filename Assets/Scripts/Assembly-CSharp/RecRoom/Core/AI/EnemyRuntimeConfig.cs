using System;
using UnityEngine;

namespace RecRoom.Core.AI
{
	[Serializable]
	public class EnemyRuntimeConfig : ScriptableObject
	{
		[Serializable]
		public class Config
		{
			[Serializable]
			public struct EnemyScoreInfo
			{
				public bool IsValid;

				public int MaxScore;

				public int MinScore;
			}

			public string FriendlyName;

			public string PrefabName;

			public LPOIMGOKCOC BehaviorType;

			public string EnemyDamageFriendlyNameString;

			public EnemyScoreInfo ScoreInfo;
		}

		public float FlyingEnemySpawnHeight;

		public Config[] Enemies;
	}
}
