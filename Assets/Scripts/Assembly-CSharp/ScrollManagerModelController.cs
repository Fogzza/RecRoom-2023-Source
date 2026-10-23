using System;
using RRUI;
using RRUI.Data;
using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.MonoBehaviours;

public class ScrollManagerModelController : ModelController<ScrollManagerModel>
{
	[Serializable]
	private class RegisterScrollbarImpl : ControllerImplementation<ScrollManagerModel>
	{
		[SerializeField]
		private Scrollbar scrollbar;

		[SerializeField]
		private ScrollbarFixer8 scrollbarFixer;

		[SerializeField]
		private Hideable hideable;

		private ScrollManagerModel.FMKGKAPHKDF registerData;

		private bool isInitialized;

		private bool showOnInitialize;

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void EHOFAGJCHPA()
		{
		}

		private void ICBEKKAJBAP()
		{
		}

		private void JCHBIJBACIM()
		{
		}

		private void PHADFEKJCCA()
		{
		}

		private void OMMKOIJNCFK(float KDBDLAMBCIH)
		{
		}

		protected override void PLLBMDOLLBP()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class VRThumbstickHideableImpl : HideableControllerImpl<ScrollManagerModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SideWatch_ScrollbarHideableImpl : HideableControllerImpl<ScrollManagerModel>
	{
		[SerializeField]
		private bool isLeftSideOfWatch;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SideWatch_ScrollbarSwapSidesImpl : HideableControllerImpl<ScrollManagerModel>
	{
		[SerializeField]
		private bool isLeftSideOfWatch;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SideWatch_PageButtonImpl : ButtonControllerImpl<ScrollManagerModel>
	{
		[SerializeField]
		private bool isPageUp;

		[SerializeField]
		private bool isLeftSideOfWatch;

		protected override void BNFEJGHHHLO()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SideWatch_SwapPreferredSideImpl : ButtonControllerImpl<ScrollManagerModel>
	{
		protected override void BNFEJGHHHLO()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SideWatch_AdaptHeightImpl : ControllerImplementation<ScrollManagerModel>
	{
		[SerializeField]
		private RectTransform rectTransform;

		[SerializeField]
		private bool isLeftSideOfWatch;

		[SerializeField]
		private RectTransform swapButton;

		[SerializeField]
		private VerticalLayoutGroup layoutGroup;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SideWatch_ScrollbarImpl : ControllerImplementation<ScrollManagerModel>
	{
		[SerializeField]
		private bool isLeftSideOfWatch;

		[SerializeField]
		private Scrollbar scrollbar;

		[SerializeField]
		private ScrollbarFixer8 scrollbarFixer;

		protected override void NGFFCLPHKJN()
		{
		}
	}
}
