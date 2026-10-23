using System;
using RecRoom.Activities.Vehicles;
using UnityEngine;

public class BoostButton : VehiclePhysicalButton, IINFEBLEDEE, HOLOGEOFMOO
{
	[Serializable]
	public struct MaterialCustomization
	{
		public float ScrollSpeed;
	}

	private const int LOGMEEJPKEM = 2;

	private const string MNOLAOALFFO = "_EmissionScrollX";

	[SerializeField]
	private VehicleBoost boost;

	[SerializeField]
	private bool keepButtonDepressedWhenPhysicallyPressing;

	[SerializeField]
	private bool keepButtonDepressedWhenBoosting;

	[SerializeField]
	private bool keepButtonDepressedWhenBoostNotReady;

	[SerializeField]
	private Renderer materialChangeRenderer;

	[SerializeField]
	private MaterialCustomization boostNotReadyAndInactiveState;

	[SerializeField]
	private MaterialCustomization boostNotReadyAndActiveState;

	[SerializeField]
	private MaterialCustomization boostReadyAndInactiveState;

	[SerializeField]
	private MaterialCustomization boostReadyAndActiveState;

	private MaterialPropertyBlock HOOJEGOGAPE;

	private bool CMFCFIBPOKN;

	private bool KLMMILGCLKK;

	private bool BEGOIGCBPKI;

	private Action OOIOBPPCCDL__BackingField;

	private bool FOOFMMFFFAD;

public bool BoostPressed
{
get 	{
		return false;
	}

set {
	}
}

public bool IsBoosting
{
get 	{
		return false;
	}

set {
	}
}

public bool CanBoost
{
get 	{
		return false;
	}

set {
	}
}

public bool ToggleState
{
get 	{
		return false;
	}

private set {
	}
}

public event Action ToggleStateChanged {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	protected void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void HPKNAJCLKJK()
	{
	}

	private void IBDNKILLPEA()
	{
	}

	private void IJFPCPAODND()
	{
	}

	private void AHJLOKIJIDN()
	{
	}

	public override void CollectVRMotionInput(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public override void DisplayVRMotionInput(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public override void CollectVRButtonInput(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public override void DisplayVRButtonInput(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public override void CollectScreensButtonInput(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public override void DisplayScreensButtonInput(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}
}
