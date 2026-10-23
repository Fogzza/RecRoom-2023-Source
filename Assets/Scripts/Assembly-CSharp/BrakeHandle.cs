using RecRoom;
using UnityEngine;

public class BrakeHandle : AttachedHandle
{
	[SerializeField]
	private RigidbodyEx parentRigidbodyEx;

	[SerializeField]
	private RetargettableAttachedRigidbodyPickup retargettablePickup;

	[SerializeField]
	private Transform defaultTransform;

	[SerializeField]
	private Transform engagedTransform;

	[SerializeField]
	private Vector3 pickupPointLocalPosition;

	[SerializeField]
	private BrakeHandleAudio brakeHandleAudio;

	private bool IBAHOOBDABF;

public bool BrakeEngaged
{
get 	{
		return false;
	}

set {
	}
}

public Vector3 HandlePickupPosition
{
get 	{
		return default;
	}

}

	protected override void Awake()
	{
	}

	public bool CanPickupBrake(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
	{
		return false;
	}

	protected override void CBPOMCILEML(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void OGLHAOIFBNC(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void AAPJPKCBCCE(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void HJGEJOJNJJJ(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void CIIBOPFIPGJ(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void MPEOOIOHGIP(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	private void MCEMHJEIJKC()
	{
	}
}
