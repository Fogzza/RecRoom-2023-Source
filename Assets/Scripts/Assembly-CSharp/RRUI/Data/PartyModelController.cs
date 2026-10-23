using System;

namespace RRUI.Data
{
	public class PartyModelController : ModelController<PartyModel>
	{
		[Serializable]
		private class PartyMemberCountTextImpl : TextControllerImpl<PartyModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PartyColorController : ImageControllerImpl<PartyModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInPartyController : HideableControllerImpl<PartyModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInPartyController : HideableControllerImpl<PartyModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
