using System;
using System.Runtime.CompilerServices;

namespace RRUI.Data
{
	public class TestPassModelController : ModelController<TestPassModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class TestPassToCardImpl : ToCardControllerImpl<TestPassModel>
		{
			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void GIJNKPAALAP()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<TestPassModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class TestPassNameTextImpl : TextControllerImpl<TestPassModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TestPassSummaryTextImpl : TextControllerImpl<TestPassModel>
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
