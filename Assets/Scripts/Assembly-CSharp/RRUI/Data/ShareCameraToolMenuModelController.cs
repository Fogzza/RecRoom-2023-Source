using System;
using RecRoom;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class ShareCameraToolMenuModelController : ModelController<ShareCameraToolMenuModel>
	{
		[Serializable]
		private class TimerCountdownTextImpl : TextControllerImpl<ShareCameraToolMenuModel>
		{
			[SerializeField]
			private Image fillImage;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PreviewImageImpl : RawImageControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TakePictureButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void IHEKMEOIBOI()
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
		private class ChangeModeButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideCameraButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SettingsButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TripodButtonImpl : ToggleControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SavePhotoButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NativeShareButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PrintPhotoButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SetProfileButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ConfirmButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CancelButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DiscardPhotoButtonImpl : ButtonControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveOptionToggleImpl : ToggleControllerImpl<ShareCameraToolMenuModel>
		{
			[SerializeField]
			private bool privateSaveOption;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfInShareCamStateImpl : HideableControllerImpl<ShareCameraToolMenuModel>
		{
			[SerializeField]
			private ShareCamera.EGBCDMMOCEH hideForThisState;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInShareCamStateImpl : HideableControllerImpl<ShareCameraToolMenuModel>
		{
			[SerializeField]
			private ShareCamera.EGBCDMMOCEH showForThisState;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowIfActivePhotoGuideImpl : HideableControllerImpl<ShareCameraToolMenuModel>
		{
			[SerializeField]
			private ShareCamera.FAJCEKGPCFF showForGuide;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowIfPreviewCaptureProhibitedImpl : HideableControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInPhotoRollExperiment : HideableControllerImpl<ShareCameraToolMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShareCamPreviewAnimatorImpl : ControllerImplementation<ShareCameraToolMenuModel>
		{
			[SerializeField]
			private Animator animator;

			private readonly int onCaptureParameter;

			private readonly int isMirroredParameter;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void FIKKJFGHJKA()
			{
			}
		}

		[Serializable]
		private class CanvasGroupOpacityImpl : ControllerImplementation<ShareCameraToolMenuModel>
		{
			[SerializeField]
			private CanvasGroup canvasGroup;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
