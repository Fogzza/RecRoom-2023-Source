using System;
using RecRoom.Activities.BattleRoyale;
using RecRoom.Core.Screens.PlayerController;
using UnityEngine;

namespace RecRoom.Core.Vehicles
{
	public class GliderScreenVehicleController : ScreenVehicleController
	{
		[SerializeField]
		private WeightedPlayerAnimationData weightedAnimationData;

		[SerializeField]
		private PlayerAnimation3DBlendedPoseSet weightedAnimationPoseSet;

		[SerializeField]
		private ScreenPlayerCameraSettings cameraSettings;

		[SerializeField]
		private float maxCameraAngleFromForward;

		[SerializeField]
		private float cameraSettingsFadeDuration;

		[SerializeField]
		private float initialControlDelay;

		[SerializeField]
		private float throttleInputAccelerateTime;

		[SerializeField]
		private float throttleInputDecelerateTime;

		[SerializeField]
		private float steeringInputAccelerateTime;

		[SerializeField]
		private float steeringInputDecelerateTime;

		[NonSerialized]
		private CBJIHCIDPGO steeringController;

		[NonSerialized]
		private LGPLMNGEAGA cameraController;

		[NonSerialized]
		private float throttleVelocity;

		[NonSerialized]
		private float steeringVelocity;

		[NonSerialized]
		private float throttle;

		[NonSerialized]
		private float steering;

		[NonSerialized]
		private float lastStartTime;

		[NonSerialized]
		private float lastInputTime;

		[NonSerialized]
		private PlayerHand.ICBKGDOJNDN lastHandOnHandle;

		private WeightedPlayerAnimationData weightedAnimationBlend;

		public int Priority => 0;

		public override void CAMGEHFMCEK(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, BaseVehicle GFNJONFMHFK, AECAHLPIFOC KAEDAICECGN)
		{
		}

		public override void PJKEEILFPHG(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, BaseVehicle GFNJONFMHFK, ScreenHUD JOGBBEAGAAN, AECAHLPIFOC KAEDAICECGN)
		{
		}

		public override void EHMICKMBCPH(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, BaseVehicle GFNJONFMHFK, AECAHLPIFOC KAEDAICECGN)
		{
		}

		public override void INMCOCBHIJB(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, BaseVehicle GFNJONFMHFK, AECAHLPIFOC KAEDAICECGN)
		{
		}

		private bool ILNACALAILE(AECAHLPIFOC JLFMCCADIKH)
		{
			return false;
		}

		private void OMGODLOGAND(PlayerHand PMNLJGLDMJN, BattleRoyaleGlider IOGAIMNIGHM)
		{
		}
	}
}
