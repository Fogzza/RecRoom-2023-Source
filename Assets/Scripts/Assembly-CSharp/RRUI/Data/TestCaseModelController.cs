using System;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using UnityEngine;

namespace RRUI.Data
{
	public class TestCaseModelController : ModelController<TestCaseModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class TestCaseToCardImpl : ToCardControllerImpl<TestCaseModel>
		{
			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void GIJNKPAALAP()
			{
			}
		}

		[Serializable]
		private class TitleTextImpl : TextControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DetailedTitleTextImpl : TextControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DescriptionTextImpl : TextControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AssigneesTextImpl : TextControllerImpl<TestCaseModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TagsTextImpl : TextControllerImpl<TestCaseModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class IdTextImpl : TextControllerImpl<TestCaseModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClaimTestCaseButtonImpl : ButtonControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class UnclaimTestCaseButtonImpl : ButtonControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PassTestCaseButtonImpl : ButtonControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FailTestCaseButtonImpl : ButtonControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BlockTestCaseButtonImpl : ButtonControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RetestTestCaseButtonImpl : ButtonControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowRoomButtonImpl : LinkControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenTestCaseWebsiteButtonImpl : ButtonControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AddCommentButtonImpl : ButtonControllerImpl<TestCaseModel>
		{
			private sealed class BHOPNJJIDPO
			{
				public string inputFieldValue;

				public EMGKENGMCAG inputField;

				public AddCommentButtonImpl _003C_003E4__this;

				public DynamicUIDialogModel commentDialog;

				internal string _003COnButtonClicked_003Eb__1()
				{
					return null;
				}

				internal void _003COnButtonClicked_003Eb__2(string s)
				{
				}

				internal void _003COnButtonClicked_003Eb__3()
				{
				}

				internal void _003COnButtonClicked_003Eb__0(BaseDialogModel<DHAPPKCJJCA> dialog)
				{
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<TestCaseModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfClaimUnavailableImpl : HideableControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfUnclaimUnavailableImpl : HideableControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfBlockPassFailUnavailableImpl : HideableControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRetestUnavailableImpl : HideableControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowRoomUnavailableImpl : HideableControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfOpenWebsiteUnavailableImpl : HideableControllerImpl<TestCaseModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
