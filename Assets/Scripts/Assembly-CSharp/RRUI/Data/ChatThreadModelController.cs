using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RRUI.Data
{
	public class ChatThreadModelController : ModelController<ChatThreadModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class NameTextImpl : TextControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PreviewTextImpl : TextControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BoldIfUnreadTextImpl : TextControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DisplayImageImpl : ControllerImplementation<ChatThreadModel>
		{
			[SerializeField]
			private GameObject directChatGameObject;

			[HideInInspector]
			[SerializeField]
			private RecNetRawImage directChatRecNetRawImage;

			[SerializeField]
			private GameObject groupChatGameObject;

			[HideInInspector]
			[SerializeField]
			private RecNetRawImage[] groupChatRecNetRawImages;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AddPlayersToChatButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitMessageButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LeaveChatButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RenameChatButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PartyInviteButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AddPhotoButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AddRoomButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AddClubButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AddEventButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CloseMediaMenuButtonImpl : ButtonControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NotificationsToggleImpl : ToggleControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FavoritedToggleImpl : ToggleControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AddMediaToggleImpl : ToggleControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MessageInputFieldImpl : InputFieldControllerImpl<ChatThreadModel>
		{
			private sealed class ECJBHBPFHIN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public int numFrames;

				public MessageInputFieldImpl _003C_003E4__this;

				private int _003Ci_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public ECJBHBPFHIN(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			private const int NUM_FRAMES_TO_WAIT_FOR_SOFT_KEYBOARD = 20;

			[SerializeField]
			private RecyclingListScrollRect messagesScrollRect;

			private long chatThreadId;

			private long lastMessageId;

			private bool ShouldAutoFocusInputField => false;

			private bool ShouldSubmitOnSoftKeyboardDone => false;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void CFAGLOHHMPE(string IPMIIEAGJKC)
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}

			protected override void GENPHPPAJEG(string IPMIIEAGJKC)
			{
			}

			private IEnumerator<EGGPGCCKPCO> NEHKANGDLBB(int EIANJMMFFMN)
			{
				return null;
			}

			private void NBFHHMPEBLK()
			{
			}

			private void JPEBHGLDFEP()
			{
			}
		}

		[Serializable]
		private class ChatThreadIdLinkImpl : LinkControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<ChatThreadModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class ChatMessageSpawnerImpl : MultiPrefabRecyclingListControllerImpl<ChatThreadModel, ChatMessageModel>
		{
			private sealed class DBMOOKOKIBD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public ChatMessageSpawnerImpl _003C_003E4__this;

				private int _003Ci_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public DBMOOKOKIBD(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				private void _003C_003Em__Finally1()
				{
				}

				[DebuggerHidden]
				private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			private sealed class CLGDJHOMAOC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public int numFrames;

				public ChatMessageSpawnerImpl _003C_003E4__this;

				private int _003Ci_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public CLGDJHOMAOC(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			private const int FRAMES_TO_WAIT_FOR_NEW_THREAD_TO_LOAD = 30;

			private const float SCROLLED_UP_THRESHOLD = 0.05f;

			[SerializeField]
			private ChatMessageModel systemMessagePrefab;

			[SerializeField]
			private ChatMessageModel textMessagePrefab;

			[SerializeField]
			private ChatMessageModel partyInviteMessagePrefab;

			[SerializeField]
			private ChatMessageModel localPartyInviteMessagePrefab;

			[SerializeField]
			private ChatMessageModel photoMessagePrefab;

			[SerializeField]
			private GameObject _threadLoadingSpinner;

			[SerializeField]
			private RectTransform _layoutGroupRoot;

			private long currentChatThreadId;

			public override bool OnModelChangedCanBeQueued => false;

			protected override bool RecomputeLayoutOnModelRefresh => false;

			protected override bool ResetPositionWhenSizeChanges => false;

			private bool PreventResetPositionOnModelChanged => false;

			private bool UserIsScrolledUp => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override GameObject CDEDHHMKKNP(int GMEHLIHLGEH)
			{
				return null;
			}

			protected override void MAGCPNIBJPL(GameObject GDEKLMNKJBC, int GMEHLIHLGEH)
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private IEnumerator<EGGPGCCKPCO> DKIIPLGLCOI()
			{
				return null;
			}

			private IEnumerator<EGGPGCCKPCO> OHPIDIJGAGC(int EIANJMMFFMN)
			{
				return null;
			}
		}

		[Serializable]
		private class FetchOlderMessagesScrollRectImpl : RecyclingListScrollRectControllerImpl<ChatThreadModel>
		{
			private const float MAX_SCROLL_POSITION = 1f;

			private const float MIN_TIME_BETWEEN_FETCHING_OLDER_MESSAGES = 1.5f;

			private float nextTimeCanFetchOlderMessages;

			protected override void IKFDENJGPJG(double GACEEHCHKKI)
			{
			}
		}

		public enum COEOGPHFGBL
		{
			IsUnread = 0,
			IsNotUnread = 1
		}

		[Serializable]
		private class HideIfNotUnreadImpl : HideableControllerImpl<ChatThreadModel>, global::NOPBJEAADPE<COEOGPHFGBL>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfChatThreadIdNotSetImpl : HideableControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfChatThreadIdSetImpl : HideableControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfClubChatImpl : HideableControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideAddMediaMenuImpl : HideableControllerImpl<ChatThreadModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChatThreadToCardImpl : ToCardControllerImpl<ChatThreadModel>
		{
			private const int MAX_UNREAD_MESSAGE_COUNT = 25;

			protected override AEBHFHIINHM CardData => null;

			private string JCCEEFGBJKM()
			{
				return null;
			}

			private string CDHDMPJHGIP()
			{
				return null;
			}
		}

		[Serializable]
		private class ToAccountListImpl : ControllerImplementation<ChatThreadModel>
		{
			[SerializeField]
			private AccountListModel accountListModel;

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
