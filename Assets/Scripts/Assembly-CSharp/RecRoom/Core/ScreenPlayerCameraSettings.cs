using UnityEngine;

namespace RecRoom.Core
{
	[CreateAssetMenu]
	public class ScreenPlayerCameraSettings : ScriptableObject
	{
		public ScreenCameraTargetingData TargetingData;

		public bool HideFirstPersonRenderers;

		public bool CanModifyFOV;
	}
}
