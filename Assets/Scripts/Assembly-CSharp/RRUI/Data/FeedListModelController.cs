using System;
using System.Collections.Generic;
using UnityEngine;

namespace RRUI.Data
{
	public class FeedListModelController : ModelController<FeedListModel>
	{
		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<FeedListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfNotLoadingImpl : HideableControllerImpl<FeedListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotFailedImpl : HideableControllerImpl<FeedListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RefreshFeedButtonImpl : ButtonControllerImpl<FeedListModel>
		{
			[SerializeField]
			protected RecyclingListScrollRect recyclingListScrollRect;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FeedListSpawnerImpl : InfiniteScrollListControllerImpl<FeedListModel, ImageFeedItemModel, LMPPEEMILFC>
		{
			private readonly Dictionary<GameObject, ImageFeedItemModel> _instanceToModelMapping;

			protected override IReadOnlyList<LMPPEEMILFC> ModelItems => null;

			protected override void JIDEGEPPHIE()
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB)
			{
			}

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			private void OIGAMBGCDPB(ImageFeedItemModel MDOPFJMFGGK)
			{
			}

			private void NPGFEKNKPHD(ImageFeedItemModel MDOPFJMFGGK)
			{
			}

			private void PGBKAMGODPL()
			{
			}

			private ImageFeedItemModel BHOEHFCOMCI(GameObject CMDPMJBEBAB)
			{
				return null;
			}
		}
	}
}
