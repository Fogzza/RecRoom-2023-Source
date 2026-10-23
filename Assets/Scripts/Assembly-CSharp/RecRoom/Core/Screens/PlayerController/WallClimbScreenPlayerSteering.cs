using System;
using UnityEngine;

namespace RecRoom.Core.Screens.PlayerController
{
	[Serializable]
	public class WallClimbScreenPlayerSteering : ScreenPlayerSteeringController
	{
		public enum LHGOGGBAIPH
		{
			NONE = 0,
			LEFT_HAND = 1,
			RIGHT_HAND = 2
		}

		[SerializeField]
		private float maxRotationSmoothTime;

		[SerializeField]
		private float smoothTimeCurveDuration;

		[SerializeField]
		private AnimationCurve gazeSmoothTimeCurve;

		[NonSerialized]
		public Vector3 WallNormal;

		[NonSerialized]
		private LHGOGGBAIPH _lookAwayFromWall;

		[NonSerialized]
		private float lastStateChangeTime;

		public LHGOGGBAIPH LookAwayFromWall
		{
			get
			{
				return LHGOGGBAIPH.NONE;
			}
			set
			{
			}
		}

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
