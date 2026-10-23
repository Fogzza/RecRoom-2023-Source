using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RecRoom.Core.UI
{
	public class ScrollRectMovementEnforcer : MonoBehaviour, IScrollHandler, IEventSystemHandler, IBeginDragHandler
	{
		private const float OCCPKMACPEI = 0.001f;

		private const float HIDCFKOCIKI = 1.0000001E-06f;

		[SerializeField]
		private ScrollRect scrollRect;

		private void Awake()
		{
		}

		public void OnScroll(PointerEventData HLMEKEJJPIN)
		{
		}

		public void OnBeginDrag(PointerEventData HLMEKEJJPIN)
		{
		}
	}
}
