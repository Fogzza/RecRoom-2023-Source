using System;
using System.Runtime.CompilerServices;
using RecRoom.Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RRUI.Data
{
	public class TetheredUIModelController : ModelController<TetheredUIModel>
	{
		[Serializable]
		private class CloseButton : ButtonControllerImpl<TetheredUIModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToggleRotationLock : ToggleControllerImpl<TetheredUIModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TogglePinnedInWorld : ToggleControllerImpl<TetheredUIModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		private abstract class TetheredUIHandleController : UIHandleDecoratorControllerImpl<TetheredUIModel>
		{
			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NCNEOCKIJML()
			{
			}
		}

		[Serializable]
		private class MoveUIHandleImpl : TetheredUIHandleController
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EOIFKCOAEHE(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
			{
			}
		}

		[Serializable]
		private class ResizeUIHandleImpl : TetheredUIHandleController
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EOIFKCOAEHE(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
			{
			}
		}

		[Serializable]
		private class DistanceUIHandleImpl : TetheredUIHandleController
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EOIFKCOAEHE(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
			{
			}
		}

		[Serializable]
		private class PrimaryTearoffTabTextImpl : TextControllerImpl<TetheredUIModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MakerPen_TearoffTab_Timer : HoverableControllerImpl<TetheredUIModel>
		{
			[SerializeField]
			public MakerPenMenuModel.IEKCDJICBLP primaryTab;

			private LKGILLBEJEK menuHoveredPromise;

			private LKGILLBEJEK menuUnHoveredPromise;

			private float hoverDelay;

			private const string MAKER_PEN_ANALYTICS_HOVER_DELAY = "UGC.MakerPen_HoverDelay";

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private void BHODPBAMMID(PointerEventData PCPEJHIMHJJ)
			{
			}

			private void KAFHJAJDCMP(PointerEventData PCPEJHIMHJJ)
			{
			}

			private void NDLIFOMKEPN()
			{
			}

			private void MCAADALAPKH()
			{
			}

			[CompilerGenerated]
			private void FKLJDBDNIBN()
			{
			}

			[CompilerGenerated]
			private void MDNDOBPIDCD()
			{
			}
		}

		[Serializable]
		private class PrimaryTab_Analytics : ControllerImplementation<TetheredUIModel>
		{
			[SerializeField]
			public MakerPenMenuModel.IEKCDJICBLP primaryTab;

			private KIDPMAMHDFB.MADAPHJHMHC menuOpenEvent;

			private float menuOpenStartTime;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
