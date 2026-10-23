using System;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class GlobalHighlightConfig
	{
		[SerializeField]
		private int maxWireUpdatesPerFrame;

		[SerializeField]
		private int maxPortUpdatesPerFrame;

		[SerializeField]
		private float flashFullDuration;

		[SerializeField]
		private float flashFadeDuration;

		public int MaxWireUpdatesPerFrame => 0;

		public int MaxPortUpdatesPerFrame => 0;

		public float FlashFullDuration => 0f;

		public float FlashFadeDuration => 0f;

		public GlobalHighlightConfig(int DFKPCDMJPIP, int JJJJPNIFDBG, int HKEPAOEOPFJ, int GFDBOONHLPP)
		{
		}
	}
}
