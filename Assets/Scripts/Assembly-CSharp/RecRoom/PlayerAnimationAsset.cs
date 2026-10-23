using System.Collections.Generic;
using UnityEngine;

namespace RecRoom
{
	public class PlayerAnimationAsset : ScriptableObject, HDMAJJEAGJB
	{
		public const float CANONICAL_HEAD_HEIGHT = 1.6f;

		public const float CANONICAL_SHOULDER_OFFSET = 0.3f;

		public const float CANONICAL_ARM_LENGTH = 0.8f;

		[SerializeField]
		private List<PlayerAnimationFrameData> frames;

		[SerializeField]
		private bool applyOffset;

		[SerializeField]
		private Vector3 fullBodyPositionOffset;

		[SerializeField]
		private Vector3 fullBodyRotationOffset;

		[SerializeField]
		private Vector3 headPositionOffset;

		[SerializeField]
		private Vector3 headRotationOffset;

		[SerializeField]
		private Vector3 leftHandPositionOffset;

		[SerializeField]
		private Vector3 leftHandRotationOffset;

		[SerializeField]
		private Vector3 rightHandPositionOffset;

		[SerializeField]
		private Vector3 rightHandRotationOffset;

		[SerializeField]
		private Vector3 cameraPositionOffset;

		[SerializeField]
		private Vector3 cameraRotationOffset;

		[SerializeField]
		private List<PlayerAnimationEvent> events;

		[SerializeField]
		private bool useRootMotion;

		[SerializeField]
		private AnimationCurve rootMotionDisplacementCurve;

		[SerializeField]
		private bool playTwoHandedIfPossible;

		[SerializeField]
		private AdditiveAnimationWeight additiveWeight;

		public List<PlayerAnimationEvent> Events => null;

		public float Duration => 0f;

		public bool UseRootMotion => false;

		public bool PlayTwoHandedIfPossible => false;

		public float StartTime => 0f;

		public float EndTime => 0f;

		public bool GIOAIBLKODB(HDMAJJEAGJB CKPMAHHPKPD)
		{
			return false;
		}

		public bool ICEELIJEKMO(HDMAJJEAGJB CKPMAHHPKPD)
		{
			return false;
		}

		public ILKAJHIJEJK LAIEGNPOKFP(float GGEPGCNHMDB, bool AOIDMDIPBFG, AdditiveAnimationWeight FOIIMLCNJGI, bool NPAFLNKLKNE)
		{
			return default;
		}

		public ILKAJHIJEJK LAIEGNPOKFP(float GGEPGCNHMDB, bool AOIDMDIPBFG, AdditiveAnimationWeight FOIIMLCNJGI, bool NPAFLNKLKNE, bool CPMHACPCEGF, bool IBKOGCPFMCG)
		{
			return default;
		}

		public float OHPKKKNEFAN(float GGEPGCNHMDB)
		{
			return 0f;
		}

		public void DNHNFLEJEFG(PlayerAnimationFrameData CDPFBDBELHI)
		{
		}

		private int JNNMCLAGCJD(float BBGNJMKOHPL)
		{
			return 0;
		}
	}
}
