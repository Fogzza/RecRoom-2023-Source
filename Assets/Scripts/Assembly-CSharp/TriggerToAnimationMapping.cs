using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToAnimationMapping : MonoBehaviour
{
	[Serializable]
	private struct TriggerClipMapping
	{
		public string TriggerName;

		public AnimationClip Animation;
	}

	[SerializeField]
	private List<TriggerClipMapping> triggerToClipMappings;

	private Dictionary<int, string> EDJDLOEJKOA;

	private void Awake()
	{
	}

	public string GetAnimationForTrigger(int PKOCILPNDOO)
	{
		return null;
	}
}
