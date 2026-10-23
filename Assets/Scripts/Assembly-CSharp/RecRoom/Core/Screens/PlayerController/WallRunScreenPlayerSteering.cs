using System;
using UnityEngine;

namespace RecRoom.Core.Screens.PlayerController
{
	[Serializable]
	public class WallRunScreenPlayerSteering : ScreenPlayerSteeringController
	{
		[SerializeField]
		private float rotationSmoothTime;

		[NonSerialized]
		public Vector3 WallNormal;

		public override bool JCFJMDLFMFF(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, out Vector3 ILBLNJAENII, out Vector3 JKPIKDAJMEB)
		{
			ILBLNJAENII = default;
			JKPIKDAJMEB = default;
			return false;
		}

		public override void KGMKIACPAOG(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, AECAHLPIFOC KAEDAICECGN)
		{
		}
	}
}
