using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using RRUI.Theme;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class BrowserModelController : ModelController<BrowserModel>
	{
		[Serializable]
		private class NavigateBackButtonImpl : ButtonControllerImpl<BrowserModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NavigateBackToRouteButtonImpl : ButtonControllerImpl<BrowserModel>
		{
			[SerializeField]
			private Route route;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private bool OCPEODBABOB(RRUI.Navigation.Uri FKFKJOJNCLM)
			{
				return false;
			}
		}

		[Serializable]
		private class NavigateForwardButtonImpl : ButtonControllerImpl<BrowserModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResetAndGoToRouteButtonImpl : ButtonControllerImpl<BrowserModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private Route route;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LinkButtonImpl : ButtonControllerImpl<BrowserModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private Route route;

			[SerializeField]
			private bool isGlobalLink;

			[SerializeField]
			private bool overrideRouter;

			[SerializeField]
			private Router routerOverride;

			[SerializeField]
			protected bool treatAsPageGroup;

			[SerializeField]
			private bool controlToggle;

			public Route Route => null;

			protected virtual bool IsActive => false;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LinkUriButtonImpl : ButtonControllerImpl<BrowserModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private RRUI.Navigation.Uri uri;

			[SerializeField]
			private bool isGlobalLink;

			[SerializeField]
			private bool overrideRouter;

			[SerializeField]
			private Router routerOverride;

			[SerializeField]
			protected bool treatAsPageGroup;

			[SerializeField]
			private bool controlToggle;

			public RRUI.Navigation.Uri Uri => null;

			private Router Router => null;

			protected virtual bool IsActive => false;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HomeScreenRoomPlayMenuSplitTestLinkButtonImpl : ButtonControllerImpl<BrowserModel>
		{
			[SerializeField]
			private Route defaultRoute;

			[SerializeField]
			private Route roomCategorySelectRoute;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class GoToSettingsScreenButtonController : ButtonControllerImpl<BrowserModel>
		{
			[SerializeField]
			protected BrowserModel browserModel;

			[SerializeField]
			private ToggleTheme _toggleTheme;

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
		private class GoToBackpackScreenButtonController : ButtonControllerImpl<BrowserModel>
		{
			[SerializeField]
			protected BrowserModel browserModel;

			[SerializeField]
			private ToggleTheme _toggleTheme;

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
		private class PageGroupToggleThemeImpl : ControllerImplementation<BrowserModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private List<Route> routes;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool CPIGDEKABHN(Route NBCNOLJOIIM)
			{
				return false;
			}
		}

		public enum DJDIKJPFDIN
		{
			IsEmpty = 0,
			IsNotEmpty = 1
		}

		[Serializable]
		private class HideIfBackStackEmptyImpl : HideableControllerImpl<BrowserModel>, global::NOPBJEAADPE<DJDIKJPFDIN>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool JGDBHMOFKOH(Route NBCNOLJOIIM)
			{
				return false;
			}
		}

		[Serializable]
		private class HideIfBackStackNotEmptyImpl : HideableControllerImpl<BrowserModel>, global::NOPBJEAADPE<DJDIKJPFDIN>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool JGDBHMOFKOH(Route NBCNOLJOIIM)
			{
				return false;
			}
		}

		public enum JNAOMDLIIBF
		{
			IsEmpty = 0,
			IsNotEmpty = 1
		}

		[Serializable]
		private class HideIfForwardStackEmptyImpl : HideableControllerImpl<BrowserModel>, global::NOPBJEAADPE<JNAOMDLIIBF>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		public enum MOLECKLBEGB
		{
			IsMatch = 0,
			IsNotMatch = 1
		}

		[Serializable]
		private class HideIfRouteMatchImpl : HideableControllerImpl<BrowserModel>, global::NOPBJEAADPE<MOLECKLBEGB>
		{
			[SerializeField]
			private Route route;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRouteNotMatchImpl : HideableControllerImpl<BrowserModel>, global::NOPBJEAADPE<MOLECKLBEGB>
		{
			[SerializeField]
			private Route route;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideSidebarImpl : HideableControllerImpl<BrowserModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool JGDBHMOFKOH(Route NBCNOLJOIIM)
			{
				return false;
			}
		}

		[Serializable]
		private class ResizeNonSidebarContentImpl : ControllerImplementation<BrowserModel>
		{
			[SerializeField]
			private RectTransform _rectTransform;

			[SerializeField]
			private float _sidebarHiddenOffset;

			[SerializeField]
			private OJCAJBAODPP _bottomBarInsteadOfSidebarPlatforms;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool GLDMBJIMPBM(Route NBCNOLJOIIM)
			{
				return false;
			}
		}

		[Serializable]
		private class ResetScrollRectDuringRoutesImpl : ControllerImplementation<BrowserModel>
		{
			[SerializeField]
			private ScrollRect scrollRect;

			public override bool IsLayoutDependent => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BrowserRouterImpl : ControllerImplementation<BrowserModel>
		{
			private sealed class BDBLNOCNJLO
			{
				public BrowserRouterImpl _003C_003E4__this;

				public RRUI.Navigation.Uri uri;

				internal void _003COnModelChanged_003Eg__OnPreDisplay_007C0()
				{
				}

				internal void _003COnModelChanged_003Eg__OnLoadFailed_007C1()
				{
				}

				internal void _003COnModelChanged_003Eg__OnGoToComplete_007C2(PageWrapper pageSwapInfo)
				{
				}

				internal void _003COnModelChanged_003Eb__3(string error)
				{
				}
			}

			[SerializeField]
			private Router router;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
