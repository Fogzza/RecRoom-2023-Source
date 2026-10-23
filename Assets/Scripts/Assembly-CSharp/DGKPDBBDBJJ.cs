using System;
using UnityEngine;

public class DGKPDBBDBJJ
{
	[Serializable]
	public class ThrottleConfig
	{
		public float MinGasAxis;

		public float MaxGasAxis;

		public float MinReverseStickAngle;
	}

	[Serializable]
	public class StickSteeringConfig
	{
		public float MinSteeringAxis;

		public float returnToRestSmoothTime;

		public float inputSmoothTime;

		public AnimationCurve inputCurve;
	}

	[Serializable]
	public class AimSteeringConfig
	{
		public float inputSmoothTime;

		public AnimationCurve inputCurve;
	}

	[Serializable]
	public class DiscreteSteeringConfig
	{
		public float accelerateSmoothTime;

		public float decelerateSmoothTime;

		public float changeDirectionSmoothTime;

		public AnimationCurve inputCurve;
	}

	public static float EDECLBFDEDL(ThrottleConfig FPJKGKBOAOA, Vector2 GOIEOFOMKOH, VehicleControls.GBIMGPLFCJD EJHBBEPLPDN)
	{
		return 0f;
	}

	public static float DAJBODCFBNC(StickSteeringConfig FPJKGKBOAOA, Vector2 GOIEOFOMKOH, ref CGOBNNIEKLB JLCHMACOMAI)
	{
		return 0f;
	}

	public static float DMAICPBAHDJ(StickSteeringConfig FPJKGKBOAOA, Vector2 GOIEOFOMKOH, ref CGOBNNIEKLB JLCHMACOMAI)
	{
		return 0f;
	}

	public static float LJENAABCPBB(AimSteeringConfig FPJKGKBOAOA, float MILGOCGHFJG, ref CGOBNNIEKLB JLCHMACOMAI)
	{
		return 0f;
	}

	private static float GMNJIIKIACI(StickSteeringConfig FPJKGKBOAOA, Vector2 GOIEOFOMKOH)
	{
		return 0f;
	}

	private static float ODNEEBCNKPK(StickSteeringConfig FPJKGKBOAOA, Vector2 GOIEOFOMKOH)
	{
		return 0f;
	}

	public static float KDANJJIKPHP(DiscreteSteeringConfig FPJKGKBOAOA, Vector2 GOIEOFOMKOH, ref CGOBNNIEKLB JLCHMACOMAI)
	{
		return 0f;
	}

	private static float NEMKIMBAHOJ(Vector2 GOIEOFOMKOH)
	{
		return 0f;
	}

	public static VehicleControls.GBIMGPLFCJD LPMBBPGDDJG(float FPJGAJJKGMN)
	{
		return VehicleControls.GBIMGPLFCJD.Drive;
	}
}
