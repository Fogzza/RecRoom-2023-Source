using RecRoom.Core.Powerups;
using UnityEngine;

namespace RecRoom.Activities.Soccer
{
	public class SoccerSpeedPowerup : Powerup
	{
		[SerializeField]
		private float walkSpeed;

		[SerializeField]
		private float teleportMaxDistanceScalar;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
