using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Core.VR.PlayerController
{
	[Serializable]
	public class FlyVRPlayerSteeringController : VRPlayerSteeringController
	{
		[StructLayout((LayoutKind)3)]
		private struct EEGPGJBIMHP
		{
			public Vector3 desiredDirection;

			public float desiredNormalizedSpeed;
		}

		private static readonly Vector3 HEAD_TO_CHEST_OFFSET;

		private static readonly float MAX_ARM_DISTANCE;

		private static readonly float SpeedCurveExponent;

		private float relativeDistance;

		private Vector3? chestPositionTrackingSpace;

		public PlayerHand AimFlyingHand { get; set; }

		public VRInputHandler AimFlyingHandInput { get; set; }

		public bool LegacyFlying { get; set; }

		public override void BEEAGBGBBPF()
		{
		}

		public override void KGMKIACPAOG(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, VRInputHandler APCLONJLBKH, VRInputHandler LLFLHHOFILH)
		{
		}

		private bool GCECBAPFFDC(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK)
		{
			return false;
		}

		private bool ILKJHADLKGA(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO)
		{
			return false;
		}

		private void KIHGJPCLECG()
		{
		}

		private float OAMFIKGMCOA(Player EKOFNPFCLMO, PlayerHand PMNLJGLDMJN)
		{
			return 0f;
		}

		[CompilerGenerated]
		private static void BHIEIGKMDMP(Vector3 OIEPDFJCEHE, ref EEGPGJBIMHP P_1)
		{
		}
	}
}
