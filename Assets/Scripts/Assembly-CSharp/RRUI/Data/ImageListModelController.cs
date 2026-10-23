using System;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class ImageListModelController : ModelController<ImageListModel>
	{
		[Serializable]
		private class ShowSearchSortDialogButtonImpl : ButtonControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FilterByTaggedSelfToggleImpl : ToggleControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SortByCheersToggleImpl : ToggleControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SortByNewestToggleImpl : ToggleControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<ImageListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfNoPublicPhotosImpl : HideableControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasPublicPhotosImpl : HideableControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoPhotosOfSelfImpl : HideableControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasPhotosOfSelfImpl : HideableControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfServerDisabledImpl : HideableControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowingLocalAccountCreatedImagesImpl : HideableControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowingRemoteAccountCreatedImagesImpl : HideableControllerImpl<ImageListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SelectableImageListSpawnerImpl : SelectableRecyclingListCardSpawnerControllerImpl<ImageListModel, ImageModel, ImageModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ImageModel GIIBNBFDOED, JLOCLGGLOPP NIOCLBOMGJG)
			{
			}

			protected override void IGNBBEJIBJO(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ImageModel GIIBNBFDOED)
			{
			}

			private void GELMAMOLGOD(int GMEHLIHLGEH, ImageModel GIIBNBFDOED)
			{
			}
		}

		[Serializable]
		private class ImageListSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ImageListModel, ImageModel, ImageModelController>
		{
			private sealed class EDNCMPLFMMG
			{
				public ImageListSpawnerImpl _003C_003E4__this;

				public long imageId;

				internal void _003COnPopulateInstance_003Eb__0()
				{
				}
			}

			[SerializeField]
			private bool overrideCardClick;

			[SerializeField]
			private Route cardClickRouteOverride;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ImageModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}
	}
}
