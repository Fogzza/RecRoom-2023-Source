using System.Runtime.CompilerServices;
using RecRoom;
using RecRoom.Activities.Vehicles;
using RecRoom.Inputs;
using UnityEngine;

public class WheelConstraintRigidbodyPickup : RigidbodyPickup
{
	public delegate float PJMOKFFNLML();

	public enum LGNAPCILAOP
	{
		Default = 0
	}

	public enum HDBJFACMEDK
	{
		ON_BOUND_HIT = 0,
		STEPPED_PAST_BOUNDS = 1,
		TIMED_PAST_BOUNDS = 2
	}

	public enum BOKKJMAEJKD
	{
		TRACKING_SPACE = 0,
		CAMERA_SPACE = 1
	}

	[SerializeField]
	private Transform constraintRoot;

	[SerializeField]
	private float wheelRadius;

	[SerializeField]
	private float innerRadius;

	[SerializeField]
	private bool invertVisualRotation;

	[SerializeField]
	private float minRotationAngle;

	[SerializeField]
	private float maxRotationAngle;

	[SerializeField]
	private float clampBreakAngleThreshold;

	[SerializeField]
	private AnimationCurve deltaRotationToMaxRotationSpeedCurve;

	[SerializeField]
	private HDBJFACMEDK boundaryFeedbackStyle;

	[SerializeField]
	private float boundsAdditionalFeedbackStepSize;

	[SerializeField]
	private float boundsAdditionalFeedbackPeriod;

	[SerializeField]
	private BOKKJMAEJKD attachedHandSpace;

	[SerializeField]
	private Transform wheelJoint;

	private float DHOPAKKHFFG;

	private global::AFHOAHNAMGF<PJMOKFFNLML> OLNOHDMELJE;

	private float CCINJJHNAAJ;

	private float LIOGJJBBIKK;

	private float HAMMJHHGFHI;

	private CGOBNNIEKLB BJJFOKIKLMC;

	private VRInputHandler NGDALNOIFDA;

	private RigidbodyEx EAKOENJMFEM;

	private float BPLCPCEOOIN;

	[SerializeField]
	private bool visualDebugEnabled;

	[SerializeField]
	private VisualDebuggerManager visualDebuggerManager;

	[SerializeField]
	private GameObject inputVisualizer0;

	private float IHNOGIIHNHI;

	private float LHABDOFOFDI;

public float WheelRadius
{
get 	{
		return 0f;
	}

}

public override Vector3 TargetPosition
{
get 	{
		return default;
	}

}

public override Quaternion TargetRotation
{
get 	{
		return default;
	}

}

public float UnitSteering
{
get 	{
		return 0f;
	}

private set {
	}
}

private Vector2 AIOBMHECJAI
{
get 	{
		return default;
	}

}

protected override CAKFLICMCMA ECEJKNPMEHH
{
get 	{
		return CAKFLICMCMA.WHILE_HELD;
	}

}

private Transform JGACOOODKIA
{
get 	{
		return null;
	}

}

private Vector3 NAIDDMFHMOP
{
get 	{
		return default;
	}

}

public float NormalizedRawInput
{
get 	{
		return 0f;
	}

private set {
	}
}

public float NormalizedDampedInput
{
get 	{
		return 0f;
	}

private set {
	}
}

	protected override void Start()
	{
	}

	protected override void ELLOMOBOGEE()
	{
	}

	public void AddSteeringOverride(PJMOKFFNLML CMOPCHCPMIA, object IALNODEHBNN, LGNAPCILAOP LAGADKBKLAD)
	{
	}

	public void RemoveSteeringOverride(object IALNODEHBNN)
	{
	}

	public override void Pickup(RigidbodyEx PMNLJGLDMJN, Vector3 NPJKCFKEFAG, Quaternion LKIBHMIIOIC)
	{
	}

	public override void Release()
	{
	}

	private void PCECNBFODBG()
	{
	}

	private bool LDOKJFDJLLI(out float INFLGEJBDJM)
	{
		INFLGEJBDJM = default;
		return false;
	}

	private void LCACMMBEBND()
	{
	}

	private float LGIJGJIPAOJ()
	{
		return 0f;
	}

	private static bool GFKHPEHOCDF(Vector3 AHBJONOEKFP, Vector3 BABFPAHPOEP, float HOPMEMOKJHF, out Vector3 BJLBLLJGGAE)
	{
		BJLBLLJGGAE = default;
		return false;
	}

	private static float MPIMDPAKJDF(Vector3 HNJJGHNAHEC)
	{
		return 0f;
	}

	[CompilerGenerated]
	private float KNKMJCFACHA()
	{
		return 0f;
	}

	[CompilerGenerated]
	private float GIGIKMHABNB()
	{
		return 0f;
	}

	[CompilerGenerated]
	private float BIHDGHJDPML()
	{
		return 0f;
	}
}
