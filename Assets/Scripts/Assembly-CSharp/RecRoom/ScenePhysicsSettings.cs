using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom
{
	[Serializable]
	public sealed class ScenePhysicsSettings : NMIKADGOIOE
	{
		[Serializable]
		public sealed class PhysicsLODSettings
		{
			[SerializeField]
			private float UnderTwoPointFiveMeterUpdateRate;

			[SerializeField]
			private float UnderFiveMeterUpdateRate;

			[SerializeField]
			private float UnderTenMeterUpdateRate;

			[SerializeField]
			private float UnderTwentyMeterUpdateRate;

			[SerializeField]
			private float UnderFiftyMeterUpdateRate;

			[SerializeField]
			private float UnderHundredMeterUpdateRate;

			[SerializeField]
			private float UnderFiveHundredMeterUpdateRate;

			[SerializeField]
			private float GreaterThanFiveHundredMeterUpdateRate;

			private Dictionary<AMBBOEBJPNH, float> updateRates;

			public static readonly PhysicsLODSettings DefaultPhysicsSettings;

			public float EMBPPCLLKIN(AMBBOEBJPNH JIEAFINGALJ)
			{
				return 0f;
			}

			private void KFBFFMJDBJN()
			{
			}
		}

		[SerializeField]
		private Vector3 gravity;

		[SerializeField]
		private float bounceThreshold;

		[SerializeField]
		private PhysicsLODSettings lodSettings;

		public PhysicsLODSettings LODSettings => null;

		public void JGHENDHCBHF(RecRoomSceneManager MACMCOFLIIO)
		{
		}

		public void BJDNGFKFKPK()
		{
		}

		public void LJODMHLJPAD()
		{
		}

		public void CDJHKCNAIKI()
		{
		}

		public void KPFOBOPDHJM()
		{
		}
	}
}
