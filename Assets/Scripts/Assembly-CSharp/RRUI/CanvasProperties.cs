using UnityEngine;

namespace RRUI
{
	public class CanvasProperties : MonoBehaviour, OFGOLFLCBPH
	{
		[SerializeField]
		private RectTransform _mainContentRectTransform;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public Vector2 GetCanvasResolution()
		{
			return default;
		}
	}
}
