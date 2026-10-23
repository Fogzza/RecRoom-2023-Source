using System;
using RecRoom.Core.UI;
using RecRoom.Tools;
using UnityEngine;

namespace RRUI.Data
{
	public class MakerPenMenuModelController : ModelController<MakerPenMenuModel>
	{
		[Serializable]
		private class ResetTetheredTabToggleButtonImpl : ButtonControllerImpl<MakerPenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AttachVRDetachedMenuButtonImpl : ButtonControllerImpl<MakerPenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResetVRDetachedSizeButtonImpl : ButtonControllerImpl<MakerPenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		private abstract class BaseTabToggleButtonImpl<TEnum> : ToggleControllerImpl<MakerPenMenuModel> where TEnum : Enum
		{
			[SerializeField]
			private TEnum tabType;

			protected abstract bool MCNLBMBLHLA(TEnum KOCNDPLELLL);

			protected abstract void HOOPNCFHAPL(TEnum KOCNDPLELLL);

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PrimaryTabToggleButtonImpl : BaseTabToggleButtonImpl<MakerPenMenuModel.IEKCDJICBLP>
		{
			protected override bool MCNLBMBLHLA(MakerPenMenuModel.IEKCDJICBLP KOCNDPLELLL)
			{
				return false;
			}

			protected override void HOOPNCFHAPL(MakerPenMenuModel.IEKCDJICBLP KOCNDPLELLL)
			{
			}
		}

		[Serializable]
		private class HideablePerfTabImpl : HideableControllerImpl<MakerPenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ThisRoom_Button : ButtonControllerImpl<MakerPenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowInTetheredTearoffModeHideableImpl : HideableControllerImpl<MakerPenMenuModel>
		{
			[SerializeField]
			private bool hideInTearoffMode;

			[SerializeField]
			private Canvas canvas;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowWhenPrimaryTabIsActiveHideableImpl : HideableControllerImpl<MakerPenMenuModel>
		{
			[SerializeField]
			private MakerPenMenuModel.IEKCDJICBLP tabType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_EnabledForTargetMode : ButtonControllerImpl<MakerPenMenuModel>
		{
			[SerializeField]
			private HHNPLBOFAGE enabledForMode;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TetheredTearoffTabHandleImpl : UIHandleDecoratorControllerImpl<MakerPenMenuModel>
		{
			[SerializeField]
			private MakerPenMenuModel.IEKCDJICBLP tabType;

			private TetheredUIBase TetheredContainer => null;

			private bool CanTearOff => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OFKPEIELNKN(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
			{
			}

			protected override void EOIFKCOAEHE(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
			{
			}

			protected override void ALDOPCAJBEJ(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
			{
			}
		}

		[Serializable]
		private class TetheredTearoffButtonHandleImpl : ButtonControllerImpl<MakerPenMenuModel>
		{
			[SerializeField]
			private MakerPenMenuModel.IEKCDJICBLP tabType;

			private TetheredUIBase TetheredContainer => null;

			private bool PersistentDataExists => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

private static MakerPen FMMANPOHFCE
{
get 		{
			return null;
		}

}
	}
}
