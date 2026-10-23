using System;
using UnityEngine;

[Serializable]
public class InvisibleWallVisualConfig : ScriptableObject
{
	public float ImpactDuration;

	public float MinImpactRadius;

	public float MaxImpactRadius;

	public float ForceToImpactRadius;

	public AnimationCurve ImpactRadiusGrowthCurve;

	public AnimationCurve ImpactAlphaCurve;
}
