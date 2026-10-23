using RecRoom.Activities.StuntRunner;
using UnityEngine;

namespace RecRoom
{
	public class BoostCollectible : TriggerCollectible
	{
		[SerializeField]
		private StuntRunnerBoostManager boostManagerPrefab;

		protected override void Awake()
		{
		}
	}
}
