using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class BugReportingController : ModelController<BugReportingModel>
	{
		[Serializable]
		private class DisplaySingleScreenshotImpl : RawImageControllerImpl<BugReportingModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class GameLogPageTitleImpl : TextControllerImpl<BugReportingModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TitleInputFieldImpl : InputFieldControllerImpl<BugReportingModel>
		{
			[SerializeField]
			private TextMeshProUGUI counter;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class DescriptionInputFieldImpl : InputFieldControllerImpl<BugReportingModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class SdlcRadioButtonsImpl : ToggleControllerImpl<BugReportingModel>
		{
			[SerializeField]
			private KJNNABNBICI SdlcPhase;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TakeScreenshotButtonImpl : ButtonControllerImpl<BugReportingModel>
		{
			[SerializeField]
			private TextMeshProUGUI counter;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TakeSingleScreenshotButtonImpl : ButtonControllerImpl<BugReportingModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClearButtonImpl : ButtonControllerImpl<BugReportingModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitButtonImpl : ButtonControllerImpl<BugReportingModel>
		{
			[SerializeField]
			private ScrollRect scrollView;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitGameLogButtonImpl : ButtonControllerImpl<BugReportingModel>
		{
			[SerializeField]
			private ScrollRect scrollView;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BugReportAttachmentListSpawnerImpl : RecyclingListControllerImpl<BugReportingModel, BugReportAttachmentModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class BugReportAttachmentCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<BugReportingModel, BugReportAttachmentModel, BugReportAttachmentModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, BugReportAttachmentModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class HideImageWithNoTextureImpl : HideableControllerImpl<BugReportingModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
