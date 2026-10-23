using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class CameraShakeEncounterStep : GameEncounterStep
	{
		public enum AMPHHDKJCDH
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		private enum DOPBAOCBPEK
		{
			TWO_DIMENSIONAL = 0,
			THREE_DIMENSIONAL = 1
		}

		[SerializeField]
		private GHBIAFLJDKB.CameraShakeConfig cameraShake;

		[SerializeField]
		private DOPBAOCBPEK shakeType;

		[SerializeField]
		private Transform threeDimensionalTransform;

		[SerializeField]
		private float threeDimensionalInnerRadius;

		[SerializeField]
		private float threeDimensionalOuterRadius;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnEncounterStart()
		{
		}

		public override void OnEncounterStop()
		{
		}

		public override void OnStartRunning()
		{
		}

		public override void OnUpdateRunning()
		{
		}

		public override void OnStopRunning()
		{
		}

		public override void OnSkipRunning()
		{
		}

		public override bool IsBlockingEncounterEnd()
		{
			return false;
		}

		public override bool IsCompleted()
		{
			return false;
		}
	}
}
