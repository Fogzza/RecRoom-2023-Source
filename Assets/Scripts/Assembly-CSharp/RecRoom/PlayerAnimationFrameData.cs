using System;

namespace RecRoom
{
	[Serializable]
	public struct PlayerAnimationFrameData
	{
		public float Time;

		public PlayerAnimationFrameTransform LeftHand;

		public float LeftHandTrigger;

		public float LeftHandPointingFinger;

		public float LeftHandThumbUp;

		public PlayerAnimationFrameTransform RightHand;

		public float RightHandTrigger;

		public float RightHandPointingFinger;

		public float RightHandThumbUp;

		public PlayerAnimationFrameTransform Head;

		public PlayerAnimationFrameTransform Body;

		public PlayerAnimationFrameData(float BBGNJMKOHPL, PlayerAnimationFrameTransform GBHOAABLEKO, float NLIIGGFEJGI, float NDBMHOFCCJP, float BLHNGPKJIEC, PlayerAnimationFrameTransform BCLLPMALPJK, float LGNPJFINNPD, float ADLNEFHGOIJ, float NLIAPOPJEDG, PlayerAnimationFrameTransform HJKMGMBILCI, PlayerAnimationFrameTransform BMIOOJNLJAO)
		{
			Time = 0f;
			LeftHand = default;
			LeftHandTrigger = 0f;
			LeftHandPointingFinger = 0f;
			LeftHandThumbUp = 0f;
			RightHand = default;
			RightHandTrigger = 0f;
			RightHandPointingFinger = 0f;
			RightHandThumbUp = 0f;
			Head = default;
			Body = default;
		}

		public PlayerAnimationFrameData(float BBGNJMKOHPL, PlayerAnimationFrameTransform GBHOAABLEKO, float NLIIGGFEJGI, float NDBMHOFCCJP, float BLHNGPKJIEC, PlayerAnimationFrameTransform BCLLPMALPJK, float LGNPJFINNPD, float ADLNEFHGOIJ, float NLIAPOPJEDG, PlayerAnimationFrameTransform HJKMGMBILCI, PlayerAnimationFrameTransform BMIOOJNLJAO, BodyAnimationMask EDAIAPNLIFC)
		{
			Time = 0f;
			LeftHand = default;
			LeftHandTrigger = 0f;
			LeftHandPointingFinger = 0f;
			LeftHandThumbUp = 0f;
			RightHand = default;
			RightHandTrigger = 0f;
			RightHandPointingFinger = 0f;
			RightHandThumbUp = 0f;
			Head = default;
			Body = default;
		}

		public static PlayerAnimationFrameData MAMNBABIJFL(PlayerAnimationFrameData CDPFBDBELHI)
		{
			return default;
		}
	}
}
