using UnityEngine;

public abstract class VehiclePhysicalButton : PhysicalButtonBase
{
	[SerializeField]
	protected VehiclePhysicalButtonWrapper wrapper;

	[SerializeField]
	protected BoxCollider triggerCollider;

	[SerializeField]
	protected SteeringWheel steeringWheel;

	private bool JNFHNLGPABO;

protected bool ANDDNOCBABI
{
get 	{
		return false;
	}

set {
	}
}

	public VehiclePhysicalButtonWrapper GetVehicleControlWrapper()
	{
		return null;
	}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void Release()
	{
	}

	protected override void OnTriggerEnter(Collider ADMCDJKKCIA)
	{
	}

	private void BGBHNJDGKHC(PhysicalButtonBase HHDMPJJAPJJ, Player EKOFNPFCLMO)
	{
	}

	private void HMOPFKHEMBG(IHANOHBJBBJ ONMKHCBEKPF, Player EKOFNPFCLMO)
	{
	}

	protected virtual void MMFNCLKNDMO()
	{
	}

	public virtual void OnDriverSeatAuthorityChanged(CHILKDJABBF HIGOLKPFBPL)
	{
	}

	public virtual void OnEnterVRMotionInput(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	public virtual void OnExitVRMotion(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	public virtual void CollectVRMotionInput(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public virtual void DisplayVRMotionInput(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public virtual void OnEnterVRButton(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	public virtual void OnExitVRButton(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	public virtual void CollectVRButtonInput(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public virtual void DisplayVRButtonInput(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public virtual void OnEnterScreensButton(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	public virtual void OnExitScreensButton(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	public virtual void CollectScreensButtonInput(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public virtual void DisplayScreensButtonInput(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}
}
