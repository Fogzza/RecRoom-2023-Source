using System;
using RRUI;
using RRUI.Data;
using TMPro;
using UnityEngine;

public class WatchNotificationsHeaderModelController : ModelController<WatchNotificationsHeaderModel>
{
	[Serializable]
	private class HideIfNoneSelectedImpl : HideableControllerImpl<WatchNotificationsHeaderModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNoneSelectableImpl : HideableControllerImpl<WatchNotificationsHeaderModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfAnySelectedImpl : HideableControllerImpl<WatchNotificationsHeaderModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfCanBulkDismissImpl : HideableControllerImpl<WatchNotificationsHeaderModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HeaderLabelImpl : TextControllerImpl<WatchNotificationsHeaderModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class CategorySelectAllToggleImpl : MixedToggleControllerImpl<WatchNotificationsHeaderModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class BatchPrimaryActionButtonImpl : ButtonControllerImpl<WatchNotificationsHeaderModel>
	{
		[SerializeField]
		private TextMeshProUGUI buttonLabelText;

		[SerializeField]
		private Hideable hideable;

		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class BatchSecondaryActionButtonImpl : ButtonControllerImpl<WatchNotificationsHeaderModel>
	{
		[SerializeField]
		private TextMeshProUGUI buttonLabelText;

		[SerializeField]
		private Hideable hideable;

		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class BatchDismissActionButtonImpl : ButtonControllerImpl<WatchNotificationsHeaderModel>
	{
		[SerializeField]
		private Hideable hideable;

		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}
}
