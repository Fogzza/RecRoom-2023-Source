using System;
using UnityEngine;

namespace RecRoom.Players.Watch
{
	public class WatchGazeTracker : MonoBehaviour
	{
		[Serializable]
		public struct GazeParameters
		{
			[SerializeField]
			private float maxFovAngle;

			[SerializeField]
			private float maxPitchAngle;

			[SerializeField]
			private float maxRollAngle;

			public float MaxFovDot { get; private set; }

			public float MaxPitchDot { get; private set; }

			public float MaxRollDot { get; private set; }

			public void INEAGMCIGHK()
			{
			}
		}

		[SerializeField]
		private GazeParameters watchOpenParameters;

		[SerializeField]
		private GazeParameters watchCloseParameters;

		[SerializeField]
		private float watchOpenDwellDuration;

		[SerializeField]
		private WatchMenuProjector watchMenuProjector;

		[SerializeField]
		private PlayerHand.PJAINFJHBKP[] preventsGazeOpenMenuHandStates;

		private PlayerHand CHEFLEAEBEP;

		private float KGJKEGNMEPK;

		private bool JKBEHOGDEMP;

		private void Awake()
		{
		}

		private bool MPILMIJFMDF(PlayerHand PMNLJGLDMJN)
		{
			return false;
		}

		public void UpdateWatchDwelling()
		{
		}

		public bool IsGazingAtWatch()
		{
			return false;
		}

		public bool IsGazingAtWatch(out bool LKJNCLPDMPL)
		{
			LKJNCLPDMPL = default;
			return false;
		}

		private bool BLMGFAKGKNG(PlayerHand PMNLJGLDMJN, GazeParameters HMJOKPKOPCN, out bool LKJNCLPDMPL)
		{
			LKJNCLPDMPL = default;
			return false;
		}

		private PlayerHand CBMGJEJJCGB(GazeParameters CGEOABHPDDG)
		{
			return null;
		}
	}
}
