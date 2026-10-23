using System.Runtime.CompilerServices;
using RecRoom.Tutorials;
using UnityEngine;

public class SteeringWheel : AttachedHandle
{
	private const string BEBCACKNBKI = "STEERING_WHEEL";

	[SerializeField]
	private AnimationCurve VRSteeringInputCurve;

	[SerializeField]
	private AnimationCurve VRThrottleInputCurve;

	[SerializeField]
	private DGKPDBBDBJJ.ThrottleConfig throttleConfig;

	[SerializeField]
	private bool buttonControlsUseStickThrottle;

	[SerializeField]
	private DGKPDBBDBJJ.StickSteeringConfig steeringStickThrottleConfig;

	[SerializeField]
	private DGKPDBBDBJJ.StickSteeringConfig steeringButtonThrottleConfig;

	[SerializeField]
	private bool useAimSteering;

	[SerializeField]
	private DGKPDBBDBJJ.AimSteeringConfig aimSteeringConfig;

	[SerializeField]
	private TutorialPromptContext leftHandDriveTutorialPromptButtonControls;

	[SerializeField]
	private TutorialPromptContext rightHandDriveTutorialPromptButtonControls;

	[SerializeField]
	private TutorialPromptContext leftHandDriveTutorialPromptMotionControls;

	[SerializeField]
	private TutorialPromptContext rightHandDriveTutorialPromptMotionControls;

	[SerializeField]
	private Transform leftHandPickupTransform;

	[SerializeField]
	private Transform rightHandPickupTransform;

	private WheelConstraintRigidbodyPickup NGGMECKMJED;

	private DNGACDNJPGH FCNLGEMDBBM;

	private bool CCLGLAAANAJ;

	private float IBCDDNHKPPA;

	private CGOBNNIEKLB JLCHMACOMAI;

protected override string EKJCBGGAFCG
{
get 	{
		return null;
	}

}

	public void GetHandTransform(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, out Vector3 KLCDCMHPFFF, out Quaternion OIJHJMDDEIH)
	{
		KLCDCMHPFFF = default;
		OIJHJMDDEIH = default;
	}

	public void ResetTutorialPromptAvailability()
	{
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

	protected void KNALNPOIOPN(Tool IEGMBEPJMGC)
	{
	}

	private TutorialPromptContext DJECNGEFFOE(PlayerHand PMNLJGLDMJN)
	{
		return null;
	}

	protected void NNALCHFEBDC(Tool IEGMBEPJMGC)
	{
	}

	protected override void EBNEEMIBNLD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	protected override void NKNOBLPFCJD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	protected override void CBPOMCILEML(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void OGLHAOIFBNC(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	private float PNIBJMAPEAA()
	{
		return 0f;
	}

	private float CAJBOLGLOFK()
	{
		return 0f;
	}

	protected override void EGDAKPMBJGG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	protected override void GDMNCBAFCHK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	protected override void AAPJPKCBCCE(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void HJGEJOJNJJJ(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void OHHLLILGIKI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	protected override void JBNGPJANMJF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	protected override void CIIBOPFIPGJ(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void FKIEOJEEBFO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	protected override void KLIPKANLHDC(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	protected override void MPEOOIOHGIP(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	[CompilerGenerated]
	private float BPOFJBHOBJN()
	{
		return 0f;
	}

	[CompilerGenerated]
	private float DMBECDFDIFN()
	{
		return 0f;
	}

	[CompilerGenerated]
	private float FFJMBHGCMNA()
	{
		return 0f;
	}

	[CompilerGenerated]
	private float OIALPGCADGD()
	{
		return 0f;
	}
}
