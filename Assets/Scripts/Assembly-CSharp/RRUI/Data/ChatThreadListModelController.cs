using System;
using UnityEngine;

namespace RRUI.Data
{
	public class ChatThreadListModelController : ModelController<ChatThreadListModel>
	{
		[Serializable]
		private class StartChatButtonImpl : ButtonControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DirectMessagesToggleImpl : ToggleControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubChatsToggleImpl : ToggleControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FilterInputFieldImpl : InputFieldControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class HideIfFilterHasResultsImpl : HideableControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfFilterHasNoResultsImpl : HideableControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlayerHasChatThreadsImpl : HideableControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlayerHasNoChatThreadsImpl : HideableControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfSourceMatches : HideableControllerImpl<ChatThreadListModel>
		{
			[SerializeField]
			private MFGJOELPIIL source;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoClubChatsImpl : HideableControllerImpl<ChatThreadListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChatThreadListSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ChatThreadListModel, ChatThreadModel, ChatThreadModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ChatThreadModel DEKDGEHLBOM, JLOCLGGLOPP JFENEHDEKMP)
			{
			}
		}

		[Serializable]
		private class SelectableChatThreadListSpawnerImpl : SelectableRecyclingListCardSpawnerControllerImpl<ChatThreadListModel, ChatThreadModel, ChatThreadModelController>
		{
			private sealed class JINEHCCIGCN
			{
				public SelectableChatThreadListSpawnerImpl _003C_003E4__this;

				public long chatThreadId;

				internal bool _003COnPopulateInstance_003Eb__0()
				{
					return false;
				}
			}

			public override bool OnModelChangedCanBeQueued => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ChatThreadModel DEKDGEHLBOM, JLOCLGGLOPP JFENEHDEKMP)
			{
			}

			protected override void IGNBBEJIBJO(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ChatThreadModel DEKDGEHLBOM)
			{
			}

			protected override void HIJIPGOHFLH(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void NBJOAGICLDD(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class ChatThreadListSingleCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ChatThreadListModel, ChatThreadModel, ChatThreadModelController>
		{
			private sealed class ONCIAEIKHFG
			{
				public ChatThreadListSingleCardSpawnerImpl _003C_003E4__this;

				public int index;

				public ChatThreadModel fromModel;

				internal bool _003COnPopulateInstance_003Eb__0()
				{
					return false;
				}

				internal void _003COnPopulateInstance_003Eb__2()
				{
				}
			}

			[SerializeField]
			private bool hideUnreadMessages;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ChatThreadModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<ChatThreadListModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void AGLPOPGOHMJ()
			{
			}

			private void AAJKCBDBJGF()
			{
			}
		}
	}
}
