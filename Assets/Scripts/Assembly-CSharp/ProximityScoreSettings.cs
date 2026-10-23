using System;
using UnityEngine;

[Serializable]
public struct ProximityScoreSettings
{
	public float MinThreshold;

	public float MaxThreshold;

	public float MinScore;

	public float MaxScore;

	public bool UseCurve;

	public AnimationCurve DistanceScoreCurve;
}
