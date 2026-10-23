using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.StuntRunner
{
	public class StuntRunnerBoostManager : SingletonMonoBehaviour<StuntRunnerBoostManager>
	{
		private enum HDJNNJJOCJP
		{
			IDLE = 0,
			BOOSTING = 1
		}

		private enum NEFGHOEACNK
		{
			IDLE = 0,
			DECELERATING = 1,
			ACCELERATING = 2,
			CRUISING = 3
		}

		private const string MDNDIAEKFFB = "BOOSTING";

		private const float OEPECPLMGPD = 0.01f;

		[SerializeField]
		private float boostedSprintSpeedMultiplier;

		[SerializeField]
		private float boostedCruisingTime;

		[SerializeField]
		private float boostMultiplierAccelerationRate;

		[SerializeField]
		private float boostMultiplierDecelerationRate;

		[SerializeField]
		private bool applyAirBoostImpulse;

		[SerializeField]
		private float airBoostImpulseSpeed;

		[SerializeField]
		private float airBoostImpulseUpwardsPercentage;

		[SerializeField]
		private RecRoomAudioClip boostFireSfx;

		private MDEJADHJOEJ OBIBHLEAIOO;

		private KBJKDKFNFIA LIJHBIHHBHF;

		private float OMMLFOLNPDP;

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void EHMICKMBCPH()
		{
		}

		private void GOCAGCIPMHI(TriggerCollectible LJJMELANGBO)
		{
		}

		private void MNLMMLPHBNB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void AKBPEOPPDCA(ushort LBBEOLMDNGD, ushort HKDHPIPECPL)
		{
		}

		private void DDHNODFHNOA()
		{
		}

		private void GKIOEGPLFDP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void JMIFMFCPPKH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CCLMLCBFLLJ()
		{
		}

		private void BMJIJHFEJOH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void GGFHFFLHDAB()
		{
		}

		private void GDMCGENPDKB(Player EKOFNPFCLMO)
		{
		}
	}
}
