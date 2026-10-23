using System;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomPickerDialogModelController : ModelController<RoomPickerDialogModel>
	{
		[Serializable]
		private class NoResultsTextImpl : TextControllerImpl<RoomPickerDialogModel>
		{
			[SerializeField]
			private string defaultNoItemsText;

			[SerializeField]
			private string defaultNoResultsText;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NoResultsImageImpl : ImageControllerImpl<RoomPickerDialogModel>
		{
			[SerializeField]
			private Sprite defaultNoItemsImage;

			[SerializeField]
			private Sprite defaultNoResultsImage;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SearchQueryButtonImpl : ButtonControllerImpl<RoomPickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RoomListSourceToggleImpl : ToggleControllerImpl<RoomPickerDialogModel>
		{
			[SerializeField]
			private RoomListModel.FFPAGDBKIPG toggleSource;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SearchQueryInputFieldImpl : InputFieldControllerImpl<RoomPickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class HideIfNoFooterElementsImpl : HideableControllerImpl<RoomPickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotShowingFiltersImpl : HideableControllerImpl<RoomPickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotEmptyImpl : HideableControllerImpl<RoomPickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PickerItemSpawnerImpl : RecyclingListControllerImpl<RoomPickerDialogModel, CardModel>
		{
			private uint _modelBackingDataVersion;

			protected override GameObject DefaultPrefabToSpawn => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}
	}
}
