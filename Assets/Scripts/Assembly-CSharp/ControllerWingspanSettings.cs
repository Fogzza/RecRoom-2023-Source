using System;

[Serializable]
public struct ControllerWingspanSettings
{
	public float WristDistanceToControllerCenter;

	public float PalmDistanceToControllerCenter;

	public float ControllerCenterDistanceToFingertip;

	public float ScaleCompensation;

	public static ControllerWingspanSettings Default => default;
}
