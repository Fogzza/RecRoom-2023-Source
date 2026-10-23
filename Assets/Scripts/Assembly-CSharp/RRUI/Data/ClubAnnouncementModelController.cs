using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubAnnouncementModelController : ModelController<ClubAnnouncementModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class ActionTextImpl : TextControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(string IEACNHGAIIE)
			{
			}
		}

		[Serializable]
		private class SummaryTextImpl : TextControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(string IEACNHGAIIE)
			{
			}
		}

		[Serializable]
		private class BodyTextImpl : TextControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CreatedAtImpl : TextControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TitleTextImpl : TextControllerImpl<ClubAnnouncementModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private string postfix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ImageImpl : RecNetRawImageControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ActionButtonImpl : ButtonControllerImpl<ClubAnnouncementModel>
		{
			[SerializeField]
			private string actionSource;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private void NOPJPIEKDHD(bool LJKOIPDOEIN)
			{
			}
		}

		[Serializable]
		private class DeleteLinkImpl : LinkControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class EditLinkImpl : LinkControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LinkImpl : LinkControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<ClubAnnouncementModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfNoActionImpl : HideableControllerImpl<ClubAnnouncementModel>, global::NOPBJEAADPE<MDBOJJGFLJC>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotClubAnnouncementTypeMatchImpl : HideableControllerImpl<ClubAnnouncementModel>, global::NOPBJEAADPE<MDBOJJGFLJC>
		{
			[SerializeField]
			private MDBOJJGFLJC announcementType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfClubAnnouncementTypeMatchImpl : HideableControllerImpl<ClubAnnouncementModel>
		{
			[SerializeField]
			private MDBOJJGFLJC announcementType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotDeletableImpl : HideableControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotEditableImpl : HideableControllerImpl<ClubAnnouncementModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfReadImpl : HideableControllerImpl<ClubAnnouncementModel>, global::NOPBJEAADPE<KDOHOBLOICP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubAnnouncementToCardImpl : ToCardControllerImpl<ClubAnnouncementModel>
		{
			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void GIJNKPAALAP()
			{
			}

			[CompilerGenerated]
			private void CGGLEJAOPLB()
			{
			}

			[CompilerGenerated]
			private void KPBPKNOPGJK()
			{
			}
		}

		[Serializable]
		private class ClubAnnouncementToCreatorAccountImpl : ControllerImplementation<ClubAnnouncementModel>
		{
			[SerializeField]
			private AccountModel accountModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubAnnouncementToInventionImpl : ControllerImplementation<ClubAnnouncementModel>
		{
			[SerializeField]
			private InventionModel inventionModel;

			[SerializeField]
			private bool includeAccount;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubAnnouncementToRoomImpl : ControllerImplementation<ClubAnnouncementModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			[SerializeField]
			private bool includeDetails;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubAnnouncementToEventImpl : ControllerImplementation<ClubAnnouncementModel>
		{
			[SerializeField]
			private EventModel eventModel;

			[SerializeField]
			private bool includeDetails;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MarkAsReadImpl : ControllerImplementation<ClubAnnouncementModel>
		{
			[SerializeField]
			private string viewSource;

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
