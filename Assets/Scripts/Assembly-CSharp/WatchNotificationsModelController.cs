using System;
using RRUI;
using RRUI.Data;
using TMPro;
using UnityEngine;

public class WatchNotificationsModelController : ModelController<WatchNotificationsModel>
{
	[Serializable]
	private class WatchNotificationSpawnerImpl : MultiPrefabRecyclingListControllerImpl<WatchNotificationsModel, WatchNotificationCardModel>
	{
		[SerializeField]
		private GameObject CategoryHeaderPrefab;

		private bool resetPosition;

		protected override bool ResetPositionWhenSizeChanges => false;

		protected override bool RecomputeLayoutOnModelRefresh => false;

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void AFELIDKEEFL()
		{
		}

		private void NDFHMNAKNLP()
		{
		}

		protected override GameObject CDEDHHMKKNP(int GMEHLIHLGEH)
		{
			return null;
		}

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
		{
		}
	}

	[Serializable]
	private class SubcategoryTooltipSpawnerImpl : PrefabSpawnerControllerImpl<WatchNotificationsModel>
	{
		private EOOFCNPHMKG.KLOEDHJLIFF lastKnownCategory;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
		{
		}
	}

	[Serializable]
	private class MainTabChipToggleImpl : ToggleControllerImpl<WatchNotificationsModel>
	{
		[SerializeField]
		private bool isDefaultTab;

		[SerializeField]
		private EOOFCNPHMKG.KLOEDHJLIFF category;

		[SerializeField]
		private Hideable newMessagesHideable;

		private int lastKnownSubCategory;

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void AFELIDKEEFL()
		{
		}

		protected override void EHOFAGJCHPA()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class SubTabChipToggleImpl : ToggleControllerImpl<WatchNotificationsModel>
	{
		[SerializeField]
		private TextMeshProUGUI chipLabel;

		[SerializeField]
		private Hideable newMessagesHideable;

		private int index;

		public void LFCDFNEAPCF(int GMEHLIHLGEH)
		{
		}

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void AFELIDKEEFL()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class HideIfNoSubtabsImpl : HideableControllerImpl<WatchNotificationsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfEmptyImpl : HideableControllerImpl<WatchNotificationsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNotEmptyImpl : HideableControllerImpl<WatchNotificationsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfSortDataFullyLoadedImpl : HideableControllerImpl<WatchNotificationsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class RefreshButtonImpl : ButtonControllerImpl<WatchNotificationsModel>
	{
		[SerializeField]
		private Hideable hideable;

		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void AFELIDKEEFL()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ShowSortModeImpl : ButtonControllerImpl<WatchNotificationsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ForceTabImpl : ControllerImplementation<WatchNotificationsModel>
	{
		[SerializeField]
		private EOOFCNPHMKG.KLOEDHJLIFF category;

		[SerializeField]
		private int subCategory;

		[SerializeField]
		private bool dontGenerateHeaders;

		private Type subCategoryType => null;

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class RestoreDataFromUriImpl : FromUriControllerImpl<WatchNotificationsModel>
	{
		protected override void AGLPOPGOHMJ()
		{
		}
	}

	[Serializable]
	private class SortLoadingProgressBarImpl : ProgressBarControllerImpl<WatchNotificationsModel>
	{
		protected override void IHEKMEOIBOI()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}
	}
}
