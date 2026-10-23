using System;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class AnalyticsConfig : GameConfigSourcedConfiguration
	{
		[SerializeField]
		private int managerEventAnalyticsCount;

		[SerializeField]
		private float heartbeatAnalyticsIntervalSeconds;

		private float? _heartbeatAnalyticsIntervalSecondsFromGameConfig;

		public int ManagerEventAnalyticsCount => 0;

		public float HeartbeatAnalyticsIntervalSeconds => 0f;

		public bool HeartbeatAnalyticsEnabled => false;

		protected override void CPJEOKKDJBC()
		{
		}
	}
}
