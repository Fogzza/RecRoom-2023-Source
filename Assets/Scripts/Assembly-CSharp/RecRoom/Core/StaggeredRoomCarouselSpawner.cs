using RRUI;
using UnityEngine;

namespace RecRoom.Core
{
	public class StaggeredRoomCarouselSpawner : StaggeredPrefabSpawner
	{
		[SerializeField]
		private RectTransform defaultPrefab;

		[SerializeField]
		private RectTransform noScrollPrefab;

		[SerializeField]
		private RectTransform noMetadataPrefab;

		private new void OnEnable()
		{
		}
	}
}
