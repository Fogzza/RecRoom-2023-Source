using System;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Core.VR.PlayerController
{
	[Serializable]
	public class WalkVRPlayerSteeringController : VRPlayerSteeringController
	{
		[SerializeField]
		private float minSpeedHandAngle;

		[SerializeField]
		private float maxSpeedHandAngle;

		public override void KGMKIACPAOG(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, VRInputHandler APCLONJLBKH, VRInputHandler LLFLHHOFILH)
		{
		}

		protected void FPIJHLAIGMI(Player EKOFNPFCLMO, PlayerHand EAKBIFPIFEH, VRInputHandler LPHNBECFCJO, Camera GAPPCJHIBEK, out Vector3 EDCANBIPEGG, out float OJMFBKHIOFM, out Vector3 EEPAMGLMMJE)
		{
			EDCANBIPEGG = default;
			OJMFBKHIOFM = default;
			EEPAMGLMMJE = default;
		}

		private void FICNHGIAOMJ(PlayerHand EAKBIFPIFEH, VRInputHandler LPHNBECFCJO, Player EKOFNPFCLMO, out Vector3 EDCANBIPEGG, out float OJMFBKHIOFM, out Vector3 EEPAMGLMMJE)
		{
			EDCANBIPEGG = default;
			OJMFBKHIOFM = default;
			EEPAMGLMMJE = default;
		}
	}
}
