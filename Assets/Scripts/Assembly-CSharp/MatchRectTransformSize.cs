using UnityEngine;

public class MatchRectTransformSize : MonoBehaviour
{
	[SerializeField]
	private RectTransform _rectTransform;

	[SerializeField]
	private RectTransform rectToMatch;

	private void Update()
	{
	}

	private void OnValidate()
	{
	}
}
