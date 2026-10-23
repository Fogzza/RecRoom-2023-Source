using System;
using UnityEngine;

namespace RRUI.Data
{
	public class SkuListModelController : ModelController<SkuListModel>
	{
		[Serializable]
		private class HideErrorMessageSectionImpl : HideableControllerImpl<SkuListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideSkuCarouselImpl : HideableControllerImpl<SkuListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformPurchasesDisabledImpl : HideableControllerImpl<SkuListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformPurchasesEnabledImpl : HideableControllerImpl<SkuListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MultiPrefabSkuListCardSpawnerImpl : MultiPrefabRecyclingListCardSpawnerControllerImpl<SkuListModel, SkuModel, SkuModelController, SkuListModel, SkuModel>
		{
			[SerializeField]
			private GameObject singleSkuPrefab;

			[SerializeField]
			private GameObject skuBundlePrefab;

			private GameObject instantiatedSingleSkuPrefab;

			private GameObject instantiatedSkuBundlePrefab;

			protected override bool RecomputeLayoutOnModelRefresh => false;

			protected override bool ResetPositionWhenSizeChanges => false;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, SkuModel DLIMOKDNNOB, JLOCLGGLOPP IPPNFJDPPNP)
			{
			}

			protected override GameObject CDEDHHMKKNP(int GMEHLIHLGEH)
			{
				return null;
			}
		}
	}
}
