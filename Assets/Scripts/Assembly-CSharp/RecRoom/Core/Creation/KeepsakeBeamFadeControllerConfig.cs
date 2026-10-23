using System;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	[Serializable]
	public class KeepsakeBeamFadeControllerConfig
	{
		[SerializeField]
		private float fadeInDuration;

		[SerializeField]
		private float fadeOutDuration;

		[SerializeField]
		private Renderer beamRenderer;

		[SerializeField]
		private Renderer baseRenderer;

		public float FadeInDuration => 0f;

		public float FadeOutDuration => 0f;

		public Renderer BeamRenderer => null;

		public Renderer BaseRenderer => null;
	}
}
