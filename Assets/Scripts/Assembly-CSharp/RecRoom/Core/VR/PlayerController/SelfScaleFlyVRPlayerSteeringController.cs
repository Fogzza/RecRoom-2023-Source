using System;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Core.VR.PlayerController
{
	[Serializable]
	public class SelfScaleFlyVRPlayerSteeringController : FlyVRPlayerSteeringController
	{
		[NonSerialized]
		private float originalCameraNearPlane;

		[NonSerialized]
		private Vector3 leftHandLocalPos;

		[NonSerialized]
		private Vector3 rightHandLocalPos;

		[NonSerialized]
		private bool leftHandHasInput;

		[NonSerialized]
		private bool rightHandHasInput;

		public bool SkipRespawnOnNextDisable { get; set; }

		public override void BEEAGBGBBPF()
		{
		}

		public override void BNJKHBPANNO()
		{
		}

		public override void KGMKIACPAOG(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, VRInputHandler APCLONJLBKH, VRInputHandler LLFLHHOFILH)
		{
		}

		public static void CABJJIOPODF(Player EKOFNPFCLMO, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE, out bool HFDFFJGNKLF, out bool PEKEKAPIHOE)
		{
			HFDFFJGNKLF = default;
			PEKEKAPIHOE = default;
		}

		private void DEGDKFDLHGJ(VRPlayerController BIEDNOLFJBE, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE)
		{
		}
	}
}
