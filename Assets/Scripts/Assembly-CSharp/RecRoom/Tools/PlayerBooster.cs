using RecRoom.Audio;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Tools
{
	public class PlayerBooster : Weapon
	{
		private enum DNPNGFFPKJC
		{
			IDLE = 0,
			BOOSTING = 1
		}

		private enum MDFGPHKLEGH
		{
			IDLE = 0,
			DECELERATING = 1,
			ACCELERATING = 2,
			CRUISING = 3
		}

		private const string JBADGJPOIOE = "PLAYER_BOOSTER";

		private const float CMIPBOEKCNO = 1000f;

		[SerializeField]
		private float boostedSprintSpeedMultiplier;

		[SerializeField]
		private float fuelConsumedPerSecond;

		[SerializeField]
		private float boostMultiplierAccelerationRate;

		[SerializeField]
		private float boostMultiplierDecelerationRate;

		[SerializeField]
		private RecRoomAudioClip speedBoostPickupSfx;

		[SerializeField]
		private RecRoomAudioClip uselessSpeedBoostPickupSfx;

		[SerializeField]
		private float boostPickupSfxPitchShiftAtMaxBoost;

		[SerializeField]
		private RecRoomAudioClip boostMeterFullSfx;

		[SerializeField]
		private RecRoomAudioClip boostMeterEmptySfx;

		private MDEJADHJOEJ GDAMJKPKJAP;

		private float OMMLFOLNPDP;

protected override Color EGOOKBNKAEM
{
get 		{
			return default;
		}

}

protected override int NIGBCNOPLKD
{
get 		{
			return 0;
		}

}

private DNPNGFFPKJC MBHNCCMHIPK
{
get 		{
			return DNPNGFFPKJC.IDLE;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void TryStartBoosting()
		{
		}

		public void StopBoosting()
		{
		}

		private void JMNJJLBJLEK(Tool IEGMBEPJMGC)
		{
		}

		private void GHJGJJNABIK(Tool IEGMBEPJMGC)
		{
		}

		private void MEMBPBALAKE(Tool IEGMBEPJMGC)
		{
		}

		private void EHMICKMBCPH()
		{
		}

		private void MILHANOAIEO(TriggerCollectible LJJMELANGBO)
		{
		}

		public void SetDefaultFuelLevel()
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

		private void AHPNGINIIIA()
		{
		}

		private void CCLMLCBFLLJ()
		{
		}

		private void GDMCGENPDKB(Player EKOFNPFCLMO)
		{
		}
	}
}
