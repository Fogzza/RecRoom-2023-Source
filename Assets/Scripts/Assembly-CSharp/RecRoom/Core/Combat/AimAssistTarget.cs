using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Combat
{
	public class AimAssistTarget : MonoBehaviour
	{
		[SerializeField]
		private float radius;

		[NonSerialized]
		public RigidbodyEx RigidbodyEx;

		[NonSerialized]
		public bool IsValidTarget;

		private const float BMNGIBFJBHK = 1f;

		private const float DMAEKLIKJPE = 2f;

		private const float EOFKDJPCEJM = 0.02f;

		private static AimAssistTarget OMBOKGNDAKO;

		private static List<AimAssistTarget> CKCEBENLEKN;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public static bool TryGetClosestTarget(Camera GAPPCJHIBEK, float CAGMKCJCIKC, float NKLMEPDAMLK, out FMMBPBKGLEN DMGDINMADLE, Func<AimAssistTarget, bool> HEHCEFCONHK)
		{
			DMGDINMADLE = null;
			return false;
		}
	}
}
