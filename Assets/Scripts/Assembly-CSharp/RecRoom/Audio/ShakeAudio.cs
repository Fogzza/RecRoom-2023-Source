using System;
using UnityEngine;

namespace RecRoom.Audio
{
	public class ShakeAudio : MonoBehaviour
	{
		[Serializable]
		public class ShakeDefinition
		{
			public float MinimumLinearAcceleration;

			public float MaximumLinearAcceleration;

			public float MinimumAngularAcceleration;

			public float MaximumAngularAcceleration;

			public float MinimumInterval;

			public RecRoomAudioClip[] AudioClips;

			private float lastPlayTime;

			public bool CGFBDBCFIKJ(float FMHBCBCAMLB, float IAMNIPPCMAL)
			{
				return false;
			}

			public void NOIOGEDNFDJ(Transform EHFFICIAODF)
			{
			}
		}

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private bool onlyPlayAudioWhileHeldByPlayer;

		[SerializeField]
		private float lookBackStartTime;

		[SerializeField]
		private float lookBackEndTime;

		[SerializeField]
		private ShakeDefinition[] shakeDefinitions;

		private Vector3 MOLNPJFNABG;

		private Vector3 PGJLBEOIPOI;

		private float FIIGLHKBMPE;

		private float MHOEJODKFMH;

		private float MEOPBBIEGMF;

		private void FixedUpdate()
		{
		}

		private float ANGHBJOHPJO(float NBCPNJJPMCM)
		{
			return 0f;
		}

		private void OJNIANGNONL()
		{
		}
	}
}
