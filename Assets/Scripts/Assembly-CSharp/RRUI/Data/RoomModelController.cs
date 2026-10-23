using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class RoomModelController : ModelController<RoomModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class RoomWarningsHeaderTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private string canJoinText;

			[SerializeField]
			private string cantJoinText;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomWarningsSubTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private string canJoinText;

			[SerializeField]
			private string canJoinWithLocomotionSwitchText;

			[SerializeField]
			private string cantJoinText;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RejectRoomWarningsButtonTextImpl : TextControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FavoriteIconImpl : ImageControllerImpl<RoomModel>
		{
			[SerializeField]
			private Sprite canJoinSprite;

			[SerializeField]
			private Sprite cantJoinSprite;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class WarningsProceedButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class WarningsRejectButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ComfortModeToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RoomWarningDataFromUriImpl : FromUriControllerImpl<RoomModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfCantJoinRoomNowImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCantJoinRoomNowAndCantJoinWithLocomotionSwitch : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfJoiningDoesNotRequireSwitchToWalkVR : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NameTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PrivatizedNameTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DescriptionTextImpl : TextControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CreatorAccountUsernameTextImpl : TextControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CheerCountTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private bool formatMetric;

			[SerializeField]
			private string suffix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class VisitCountTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private bool formatMetric;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FriendCountTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private string suffix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FavoriteCountTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private bool formatMetric;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SmallestSubroomCapacityTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private string suffix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EntrySubroomCapacityTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private string suffix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomCapacityTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private string suffix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CustomWarningTextImpl : TextControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CanJoinStatusTextImpl : TextControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ActiveAICountTextImpl : TextControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AIBudgetPercentageTextImpl : TextControllerImpl<RoomModel>
		{
			[SerializeField]
			private Color warningColor;

			private Color defaultColor;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LoadingScreenTitleTextImpl : TextControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LoadingScreenSubtitleTextImpl : TextControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MainImageImpl : RecNetRawImageControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PrivatizedMainImageImpl : RecNetRawImageControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CreatorAccountProfileImageImpl : RecNetRawImageControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LoadingScreenImageImpl : RecNetRawImageControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NavigateToRoomButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MeetupCodeButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShareRoomCodeButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinPublicRoomButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ChangeRoomInstanceButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinPublicSubroomButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResumeButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinPrivateRoomButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ChangePrivateRoomInstanceButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinPrivateSubroomButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CopyButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RestoreButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DiscGolfHazardButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BowlingBumpersButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GameReviveButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GameStartButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GameEndButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SwitchTeamButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryChangeRoomNameButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryChangeRoomDescriptionButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryChangeRoomImageButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryPublishRoomButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryUnpublishRoomButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DeleteButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CreateNewSubroomButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ChangeCustomRoomWarningButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ChangeRoomCreatorButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ChangeLoadingScreenImageButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryChangeLoadingScreenButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DestroyAllAiButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RebakeNavMeshButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchRoomReportButtonImpl : ButtonControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchScoreboardButtonImpl : ButtonControllerImpl<RoomModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchRoomCommentsButtonImpl : ButtonControllerImpl<RoomModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchFrontierPassButtonImpl : ButtonControllerImpl<RoomModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchPermissionButtonImpl : ButtonControllerImpl<RoomModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchRolesButtonImpl : ButtonControllerImpl<RoomModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchInstancesButtonImpl : ButtonControllerImpl<RoomModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BookmarkToggleImpl : ToggleControllerImpl<RoomModel>
		{
			[SerializeField]
			private string amplitudeEventContextLabel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CheerToggleImpl : ToggleControllerImpl<RoomModel>
		{
			[SerializeField]
			private string amplitudeEventContextLabel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SupportsScreensToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SupportsWalkVRToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SupportsTeleportVRToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SupportsJuniorsToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CloningAllowedToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DisableMicAutoMuteToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DisableRoomCommentsToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AllowNewUsersToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class EncryptVoiceChatToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CreativeToolsBetaToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ObjectModelToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CreativeRolesToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CreatorMakerPenOverrideToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TagToggleImpl : ToggleControllerImpl<RoomModel>
		{
			private sealed class DHCJHHABILN
			{
				public string tagName;

				internal bool _003COnModelChanged_003Eb__1(string t)
				{
					return false;
				}
			}

			[SerializeField]
			private TextMeshProUGUI chipText;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private bool NOPJPIEKDHD(string IHPJCBCPLCM)
			{
				return false;
			}
		}

		[Serializable]
		private class RoomWarningToggleImpl : ToggleControllerImpl<RoomModel>
		{
			[SerializeField]
			private BBMLADAOMKF warningMask;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NavMeshVisibleToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AiIgnorePlayersToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MaxPlayerCountToggleImpl : ToggleControllerImpl<RoomModel>
		{
			[SerializeField]
			private AJKBDDEPMMF type;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LoadingScreenModeToggleImpl : ToggleControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NameInputFieldImpl : InputFieldControllerImpl<RoomModel>
		{
			[SerializeField]
			private TextMeshProUGUI counter;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class DescriptionInputFieldImpl : InputFieldControllerImpl<RoomModel>
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

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class TagCustomInputFieldImpl : TagInputFieldControllerImpl<RoomModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private bool LJNDLANGCDN(string IPMIIEAGJKC)
			{
				return false;
			}

			protected override void LEKIJHCGCLH(IReadOnlyList<string> CMBMOBEBGIN)
			{
			}
		}

		[Serializable]
		private class CustomWarningInputFieldImpl : InputFieldControllerImpl<RoomModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class LoadingScreenTitleInputFieldImpl : InputFieldControllerImpl<RoomModel>
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

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class LoadingScreenSubtitleInputFieldImpl : InputFieldControllerImpl<RoomModel>
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

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class RoomIdLinkImpl : LinkControllerImpl<RoomModel>
		{
			[SerializeField]
			protected ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CoOwnerLocalOnlyRoomLinkImpl : RoomIdLinkImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CoOwnerRoomLinkImpl : RoomIdLinkImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CanCreateCurrenciesRoomLink : RoomIdLinkImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomFromUriImpl : FromUriControllerImpl<RoomModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfCannotViewRoomCommentsImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRoomDataIsNotReadyImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPublicRoomImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotPublicRoomImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanChooseSubroomImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotChooseSubroomImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotEnoughSubroomsImpl : HideableControllerImpl<RoomModel>
		{
			[SerializeField]
			private int targetCount;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfDescriptionEmptyImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoFriendsInRoomImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotCreateCurrenciesImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasRoomRoleImpl : HideableControllerImpl<RoomModel>
		{
			[SerializeField]
			private bool hideByDefault;

			[SerializeField]
			private bool alwaysShowForDevs;

			[SerializeField]
			private bool alwaysShowForVolunteerMods;

			[SerializeField]
			private bool banned;

			[SerializeField]
			private bool none;

			[SerializeField]
			private bool host;

			[SerializeField]
			private bool moderator;

			[SerializeField]
			private bool coOwner;

			[SerializeField]
			private bool creator;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRoomWarningEmptyImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLinkedToRecRoomStudioImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotLinkedToRecRoomStudioImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfWarningMaskDisabledImpl : HideableControllerImpl<RoomModel>
		{
			[SerializeField]
			private BBMLADAOMKF maskType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfVoiceModerationDisabledImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfWarningMasksDisabledImpl : HideableControllerImpl<RoomModel>
		{
			[SerializeField]
			private BBMLADAOMKF[] maskTypes;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanJoinRoomNowOrWithLocomotionSwitchImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanJoinRoomNowOrCantJoinWithLocomotionSwitch : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotSaveRestoreRoomImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotCopyRoomImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoRoomImagesImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRoomNotLocalImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoGameChipImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRoomLocalImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInRecRoyaleImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInDiscGolfImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInBowlingImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotStartGameImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotEndGameImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotSelfReviveImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfSwitchTeamsNotSupportedImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRoomNotLocalAndNoFriendsHereImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideUnpublishedRoomWarningImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIncompatibleVersionWarningImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfOwnedByMeImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(bool PINDNKJOLOE)
			{
			}

			[CompilerGenerated]
			private void DDIIGNKCAOB(string GADDGJANIGG)
			{
			}
		}

		[Serializable]
		private class HideIfNotOwnedByMeImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(bool PINDNKJOLOE)
			{
			}

			[CompilerGenerated]
			private void DDIIGNKCAOB(string GADDGJANIGG)
			{
			}
		}

		[Serializable]
		private class HideIfNotMyDormImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(bool PINDNKJOLOE)
			{
			}

			[CompilerGenerated]
			private void DDIIGNKCAOB(string GADDGJANIGG)
			{
			}
		}

		[Serializable]
		private class HideIfLoadingScreenPreviewEnabledImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLoadingScreenPreviewDisabledImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCloudDataNotAvailable : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideJoinPublicRoomButtonImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInPublicInstanceImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideChangeInstanceButtonImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideJoinPrivateRoomButtonImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideChangePrivateInstanceButtonImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideJoinPrivateSubroomButtonImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCloudDataDisabled : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfBetaDisabled : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCreativeToolsBetaDisabledImpl : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfObjectModelDisallowed : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotCreateMeetupCode : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotShareRoom : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfDoesNotHaveRRPlusRoomRestriction : HideableControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PopularTagTogglesSpawnerImpl : PrefabSpawnerControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(int ONEGMPJFKJP)
			{
			}
		}

		[Serializable]
		private class TagsListSpawnerImpl : PrefabSpawnerControllerImpl<RoomModel>
		{
			private sealed class DPGEICMDJEF
			{
				public string tag;

				public TagsListSpawnerImpl _003C_003E4__this;

				internal void _003COnPopulateInstance_003Eg__SearchPlayMenuForTag_007C0()
				{
				}
			}

			[SerializeField]
			private bool searchPlayMenuOnClick;

			[SerializeField]
			private DBECJLAIPEL tagClickLoadSceneSource;

			private List<Button> tagButtons;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void OONHEMJFEOJ(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void AFELIDKEEFL()
			{
			}
		}

		[Serializable]
		private class FriendsInRoomSpawnerImpl : PrefabSpawnerControllerImpl<RoomModel>
		{
			[SerializeField]
			private int _maximum;

			[SerializeField]
			private TextMeshProUGUI andMoreText;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class SubroomSpawnerImpl : PrefabSpawnerControllerImpl<RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class RoomRoleAccountListSpawnerImpl : RecyclingListControllerImpl<RoomModel, BaseAccountModel>
		{
			[SerializeField]
			private bool banned;

			[SerializeField]
			private bool none;

			[SerializeField]
			private bool host;

			[SerializeField]
			private bool moderator;

			[SerializeField]
			private bool coOwner;

			[SerializeField]
			private bool creator;

			[NonSerialized]
			private List<int> accountIds;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private bool KONHDOBLACD(ANKKBKAPIJM GOJCEBCMFJK)
			{
				return false;
			}
		}

		[Serializable]
		private class RoomImagesListSpawnerImpl : RecyclingListControllerImpl<RoomModel, RecNetRawImage>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class KeepsakeIconListSpawnerImpl : RecyclingListControllerImpl<RoomModel, RecNetRawImage>
		{
			private bool isCurrentlySpawning;

			private List<BLIIKHLKHJA> roomKeepsakeCategories;

			private Dictionary<BLIIKHLKHJA, bool> keepsakeCategoryCollectionIsComplete;

			private readonly List<BLIIKHLKHJA> emptyCategoryList;

			protected override void NGFFCLPHKJN()
			{
			}

			private LAHBDKNMNHN LOBCDIJKBEF()
			{
				return null;
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private void PIFIIBENEDG(Dictionary<BLIIKHLKHJA, int> KEAGBJBHEEL)
			{
			}

			[CompilerGenerated]
			private void JJCFNHKOPKD(Dictionary<BLIIKHLKHJA, int> NMADJCIMEJA)
			{
			}

			[CompilerGenerated]
			private void MLMIABFJCCK()
			{
			}
		}

		[Serializable]
		private class RoomToCardImpl : ToCardControllerImpl<RoomModel>
		{
			[SerializeField]
			private bool showCreatorName;

			protected override AEBHFHIINHM CardData => null;
		}

		[Serializable]
		private class ToInventionListImpl : ControllerImplementation<RoomModel>
		{
			[SerializeField]
			private InventionListModel inventionListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToAccountListImpl : ControllerImplementation<RoomModel>
		{
			[SerializeField]
			private AccountListModel accountListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomToImageListImpl : ControllerImplementation<RoomModel>
		{
			[SerializeField]
			private ImageListModel imageListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToEventListImpl : ControllerImplementation<RoomModel>
		{
			[SerializeField]
			private EventListModel eventListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToActionCodeImpl : ControllerImplementation<RoomModel>
		{
			[SerializeField]
			private ActionCodeModel actionCodeModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomToSimilarRoomsListImpl : ControllerImplementation<RoomModel>
		{
			[SerializeField]
			private RoomListModel roomListModel;

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
