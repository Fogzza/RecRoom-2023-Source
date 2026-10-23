using System;
using System.Collections.Generic;
using UnityEngine;

namespace RRUI.Data
{
	public class StaffCuratedRoomPlaylistsModelController : ModelController<StaffCuratedRoomPlaylistsModel>
	{
		[Serializable]
		private class StaffCuratedPlaylistsCarouselSpawnerImpl : PrefabSpawnerControllerImpl<StaffCuratedRoomPlaylistsModel>
		{
			private List<KeyValuePair<Transform, string>> carouselToSortId;

			[SerializeField]
			private GameObject defaultPrefab;

			[SerializeField]
			private GameObject noScrollPrefab;

			[SerializeField]
			private GameObject noMetadataPrefab;

			private PlayMenuCarouselModel _PlayMenuCarouselModel;

			private PlayMenuCarouselModel playMenuCarouselModel => null;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}
	}
}
