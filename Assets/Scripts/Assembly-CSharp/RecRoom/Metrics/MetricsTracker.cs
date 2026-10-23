using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace RecRoom.Metrics
{
	public class MetricsTracker : SingletonMonoBehaviour<MetricsTracker>
	{
		private class MetricTracker
		{
			public readonly FACLNBKLHPH Stats;

			private readonly Func<double?> _getter;

			public string Name { get; }

			public MetricTracker(string name, Func<double?> getter)
			{
			}

			public void Update()
			{
			}

			public static MetricTracker Create(string name, ProfilerRecorder recorder, double scale = 1.0)
			{
				return null;
			}

			public static MetricTracker Create(string name, ProfilerCategory category, string statName, double scale = 1.0)
			{
				return null;
			}
		}

		private const double TimeScaleNsToMs = 1E-07;

		private const double BytesToMb = 1.0 / 1048576.0;

		private int _lastSentFrame;

		private OBCPHIJMGBG _lastSentTimestamp;

		private readonly List<MetricTracker> _metrics;

		private void StartRecorders()
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void RegisterEventHandlers()
		{
		}

		private void UnRegisterEventHandlers()
		{
		}

		private void OnWillSendHeartbeat()
		{
		}

		private void Reset()
		{
		}
	}
}
