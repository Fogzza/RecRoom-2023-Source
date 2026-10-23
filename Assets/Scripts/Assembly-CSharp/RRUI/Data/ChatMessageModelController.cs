using System;
using RRUI.Navigation;
using RRUI.Theme;
using RecNet;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RRUI.Data
{
	public class ChatMessageModelController : ModelController<ChatMessageModel>
	{
		[Serializable]
		private class ChatMessageFormatImpl : ControllerImplementation<ChatMessageModel>
		{
			private bool initialized;

			private bool isFromLocalPlayer;

			[SerializeField]
			private Transform senderIcon;

			[SerializeField]
			private Transform emptySpace;

			[SerializeField]
			private SurfaceTheme[] backgroundThemes;

			[SerializeField]
			private RoundedCorners backgroundCorners;

			[SerializeField]
			private LabelTheme[] primaryLabelThemes;

			[SerializeField]
			private GraphicTheme[] primaryGraphicThemes;

			[SerializeField]
			private LabelTheme[] secondaryLabelThemes;

			[SerializeField]
			private GraphicTheme[] secondaryGraphicThemes;

			[SerializeField]
			private NGBJAKFDFHA mineBackgroundColor;

			[SerializeField]
			private JDOLBJAOGPC mineLabelPrimaryColor;

			[SerializeField]
			private JDOLBJAOGPC mineLabelSecondaryColor;

			[SerializeField]
			private JDOLBJAOGPC mineGraphicPrimaryColor;

			[SerializeField]
			private JDOLBJAOGPC mineGraphicSecondaryColor;

			[SerializeField]
			private NGBJAKFDFHA otherBackgroundColor;

			[SerializeField]
			private JDOLBJAOGPC otherLabelPrimaryColor;

			[SerializeField]
			private JDOLBJAOGPC otherLabelSecondaryColor;

			[SerializeField]
			private JDOLBJAOGPC otherGraphicPrimaryColor;

			[SerializeField]
			private JDOLBJAOGPC otherGraphicSecondaryColor;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChatMessageClickableImpl : ClickableControllerImpl<ChatMessageModel>
		{
			private ChatThreadModel threadModel;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BHODPBAMMID(PointerEventData GADDGJANIGG)
			{
			}

			protected override void KAFHJAJDCMP(PointerEventData GADDGJANIGG)
			{
			}

			protected override void DBMIDNFELCA(PointerEventData HLMEKEJJPIN)
			{
			}

			private void HMNLFJILECA(ChatMessage OFCFPGACNJB)
			{
			}
		}

		[Serializable]
		private class TimestampTextImpl : TextControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SenderAccountUsernameImpl : TextControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ContentTextImpl : TextControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClickableContentTextImpl : ClickableTextControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void AJKKKHIDPHF(TMP_LinkInfo DJLDBHOPNND)
			{
			}
		}

		[Serializable]
		private class SenderAccountImageImpl : RecNetRawImageControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DeleteMessageButtonImpl : ButtonControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		private abstract class ContentLinkImpl<TContentModel> : LinkControllerImpl<ChatMessageModel> where TContentModel : NJIIBNCBBMK
		{
			[SerializeField]
			private TContentModel contentModel;

			[SerializeField]
			private string dialogTitle;

			[SerializeField]
			private string dialogMessage;

			[SerializeField]
			private Sprite dialogSprite;

protected TContentModel KIAJCOMFHNP
{
get 			{
				return default;
			}

}

			protected override void NGFFCLPHKJN()
			{
			}

			protected abstract RRUI.Navigation.Uri IBHABLOFDPA(string LGENGCEEBPB);

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RoomIdLinkImpl : ContentLinkImpl<RoomModel>
		{
			protected override RRUI.Navigation.Uri IBHABLOFDPA(string LGENGCEEBPB)
			{
				return null;
			}
		}

		[Serializable]
		private class ClubIdLinkImpl : ContentLinkImpl<ClubModel>
		{
			protected override RRUI.Navigation.Uri IBHABLOFDPA(string LGENGCEEBPB)
			{
				return null;
			}
		}

		[Serializable]
		private class EventIdLinkImpl : ContentLinkImpl<EventModel>
		{
			protected override RRUI.Navigation.Uri IBHABLOFDPA(string LGENGCEEBPB)
			{
				return null;
			}
		}

		public enum FHJFHLADOHJ
		{
			IsPending = 0,
			IsNotPending = 1
		}

		[Serializable]
		private class HideIfNotPendingImpl : HideableControllerImpl<ChatMessageModel>, global::NOPBJEAADPE<FHJFHLADOHJ>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoTaggedRoomsImpl : HideableControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoTaggedClubsImpl : HideableControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoTaggedPlayerEventsImpl : HideableControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfDirectRoomShareImpl : HideableControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfActionToolbarNotActiveImpl : HideableControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCantDeleteMessageImpl : HideableControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfMessageDeletedImpl : HideableControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfMessageNotDeletedImpl : HideableControllerImpl<ChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChatMessageToSenderAccountImpl : ControllerImplementation<ChatMessageModel>
		{
			[SerializeField]
			private AccountModel accountModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChatMessageToTaggedRoomImpl : ControllerImplementation<ChatMessageModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChatMessageToTaggedClubImpl : ControllerImplementation<ChatMessageModel>
		{
			[SerializeField]
			private ClubModel clubModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChatMessageToTaggedPlayerEventImpl : ControllerImplementation<ChatMessageModel>
		{
			[SerializeField]
			private EventModel eventModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
