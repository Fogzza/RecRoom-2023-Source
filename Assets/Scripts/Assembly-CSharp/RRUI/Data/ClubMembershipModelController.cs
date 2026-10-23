using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubMembershipModelController : ModelController<ClubMembershipModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class ClubMembershipTypeTextImpl : TextControllerImpl<ClubMembershipModel>
		{
			[SerializeField]
			private string textToAppend;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubMembershipJoinedAtTextImpl : TextControllerImpl<ClubMembershipModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubMembershipBanButtonImpl : ButtonControllerImpl<ClubMembershipModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubMembershipChangeMembershipTypeButtonImpl : ButtonControllerImpl<ClubMembershipModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubMembershipRemoveButtonImpl : ButtonControllerImpl<ClubMembershipModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubMembershipChangeMembershipTypeDropdownImpl : DropdownControllerImpl<ClubMembershipModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OBNGIJHLCJE(int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class ClubIdMembershipIdFromClubMembershipLinkImpl : LinkControllerImpl<ClubMembershipModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubMembershipFromUriImpl : FromUriControllerImpl<ClubMembershipModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class ClubMembershipToCardImpl : ToCardControllerImpl<ClubMembershipModel>
		{
			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void GIJNKPAALAP()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
