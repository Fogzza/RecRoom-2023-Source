using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleBoost : MonoBehaviour
	{
		public enum IBDGACBMDGL
		{
			NOT_YET_STARTED = 0,
			INTRO = 1,
			BOOSTING = 2,
			OUTRO = 3,
			DONE = 4
		}

		private bool ANIIOMCDDFN;

		private bool EIMCHIHMOMM;

		private const string GOAAPKAKINN = "Boost";

		private const int LIDAHIMFLLD = 100;

		[SerializeField]
		protected int boostCapacity;

		[SerializeField]
		protected int boostCost;

		[SerializeField]
		protected float boostApplyThrottle;

		[SerializeField]
		protected AnimationCurve boostIntroCurve;

		[SerializeField]
		protected int boostIntroDurationMilliseconds;

		[SerializeField]
		protected AnimationCurve boostActiveCurve;

		[SerializeField]
		protected int boostActiveDurationMilliseconds;

		[SerializeField]
		protected AnimationCurve boostOutroCurve;

		[SerializeField]
		protected int boostOutroDurationMilliseconds;

		[SerializeField]
		protected float maxTorqueBoostPercentage;

		[SerializeField]
		protected float maxTorqueBoostAdditive;

		[SerializeField]
		protected bool canStack;

		[SerializeField]
		protected float stackModifierExponential;

		[SerializeField]
		protected VehicleBoostAudio boostAudio;

		[SerializeField]
		private VehicleVFX vehicleVfx;

		[SerializeField]
		protected GaugeNeedle boostNeedle;

		[SerializeField]
		private bool onlyDoCameraChangesForDriver;

		[SerializeField]
		protected GameObject boostNotReadyIndicator;

		[SerializeField]
		protected GameObject boostReadyIndicator;

		[SerializeField]
		protected GameObject boostNotInUseIndicator;

		[SerializeField]
		protected GameObject boostInUseIndicator;

		[SerializeField]
		protected bool disableReadyIndicatorsWhenInUse;

		[SerializeField]
		protected TextMesh debugText;

		[SerializeField]
		private GroundVehicle vehicle;

		private global::BDOFFIKKMIO<int> AMJJHNPOLOD;

		private List<int> MIPPEHMOHLP;

		private int BKGMPPFANLK;

		private bool KHKJNEDAJEN;

		private Action NONBHJPLFIH__BackingField;

		private Action DJPEAPEEDHA__BackingField;

		private global::MOBDJNEDDKC<int> OACKGONMEFO;

		private global::MOBDJNEDDKC<int> LAEGDCMMJND;

public int CurrentBoost
{
get 		{
			return 0;
		}

private set {
		}
}

public int BoostCapacity
{
get 		{
			return 0;
		}

set {
		}
}

public bool CanAffordBoost
{
get 		{
			return false;
		}

}

public event Action OnBoostUpdated {
add {
		}
remove {
		}
}

public event Action OnCanBoostUpdated {
add {
		}
remove {
		}
}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void ResetActiveBoosts()
		{
		}

		public void ResetBoostMeter()
		{
		}

		private void MILHANOAIEO(TriggerCollectible LJJMELANGBO)
		{
		}

		public bool CanPickupBoost()
		{
			return false;
		}

		public void AuthorityAddBoost(int AFGEOMAIDJN)
		{
		}

		public bool UseBoost()
		{
			return false;
		}

		public bool IsBoosting()
		{
			return false;
		}

		private void HPNOBMCJCFK()
		{
		}

		private void BIKDMALACPJ(bool GLKBGPHMMNC = false)
		{
		}

		private void DNKAMHKIPGM()
		{
		}

		private float JPHBOLDPFLD()
		{
			return 0f;
		}

		private float JFLNFHDNEJA(float FPJGAJJKGMN)
		{
			return 0f;
		}

		private float FAHAILKFKJF(float HMKLOLJGHPK, float JFGDAEILDGE)
		{
			return 0f;
		}

		private void BFEEPAJNBAI()
		{
		}

		private IBDGACBMDGL MDOCKCFFINJ(int HDGFHFCPNPD, int CJCLLNNMCFL)
		{
			return IBDGACBMDGL.NOT_YET_STARTED;
		}

		private void DKNIHELGKLH()
		{
		}

		private float MGMOMCOBOGE()
		{
			return 0f;
		}

		private float KIKDGLGDGAB(int HDGFHFCPNPD, int CJCLLNNMCFL)
		{
			return 0f;
		}

		[CompilerGenerated]
		private void ABFNACEEELH()
		{
		}
	}
}
