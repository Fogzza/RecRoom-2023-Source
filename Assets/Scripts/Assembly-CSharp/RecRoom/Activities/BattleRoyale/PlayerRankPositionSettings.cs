using System;
using UnityEngine;

namespace RecRoom.Activities.BattleRoyale
{
	[Serializable]
	public struct PlayerRankPositionSettings
	{
		public float spaceBetweenRanks;

		public float spaceBetweenSecondAndThirdRank;

		public float spaceBetweenFirstAndSecondRank;

		public Vector3 defaultPlayerNameLocalPosition;
	}
}
