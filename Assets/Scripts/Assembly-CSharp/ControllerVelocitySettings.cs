using System;

[Serializable]
public class ControllerVelocitySettings
{
	public enum IONOMPNPLLB
	{
		AVERAGE_DIRECTION_AVERAGE_MAGNITUDE = 0,
		AVERAGE_DIRECTION_MAX_MAGNITUDE = 1
	}

	public float LinearVelocityMultiplier;

	public float AngularVelocityMultiplier;

	public IONOMPNPLLB LinearVelocityAverageMethod;

	public IONOMPNPLLB AngularVelocityAverageMethod;

	public bool VelocityWaitForNextUpdate;

	public bool VelocityRollbackUsesFixedTimestep;

	public int DirectionRollbackStartFrame;

	public int DirectionRollbackEndFrame;

	public int MagnitudeRollbackStartFrame;

	public int MagnitudeRollbackEndFrame;
}
