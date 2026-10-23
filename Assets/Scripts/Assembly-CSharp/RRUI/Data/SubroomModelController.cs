using System;
using RRUI.Theme;
using RecRoom.Core.Creation.SceneMoods;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class SubroomModelController : ModelController<SubroomModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class NameTextImpl : TextControllerImpl<SubroomModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private bool includeParentRoom;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MaxPlayerBackingDataTextImpl : TextControllerImpl<SubroomModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class GoToSubroomButtonImpl : ButtonControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CloneSubroomButtonImpl : ButtonControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MoveSubroomButton : ButtonControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DeleteSubroomButtonImpl : ButtonControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveSubroomButtonImpl : ButtonControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class EntrySubroomToggleImpl : ToggleControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HostOnlyAreasEnabledToggleImpl : ToggleControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InvisibleWallsEnabledToggleImpl : ToggleControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GadgetsToAllEnabledToggleImpl : ToggleControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RemoveGriefableChipsToggleImpl : ToggleControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class UseNewMaterialsToggleImpl : ToggleControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DirectionalVoiceChatEnabledToggleImpl : ToggleControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MoodSettingToggleImpl : ToggleControllerImpl<SubroomModel>
		{
			[SerializeField]
			private MoodSetting mood;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NameInputFieldImpl : InputFieldControllerImpl<SubroomModel>
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
		private class ChangeSaveVersionButtonImpl : ButtonControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveVersionTextImpl : TextControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MaxPlayersInputFieldImpl : InputFieldControllerImpl<SubroomModel>
		{
			private int maxPlayersUpperLimit;

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
		private class SubroomIdLinkImpl : LinkControllerImpl<SubroomModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RoomFromUriImpl : FromUriControllerImpl<SubroomModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfRoomMoodsDisabledImpl : HideableControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfMakerPenRoomSceneImpl : HideableControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfSubroomNotLocalImpl : HideableControllerImpl<SubroomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotEnoughSubroomsImpl : HideableControllerImpl<SubroomModel>
		{
			[SerializeField]
			private int targetCount;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SubroomToCardImpl : ToCardControllerImpl<SubroomModel>
		{
			protected override AEBHFHIINHM CardData => null;
		}

		[Serializable]
		private class MaxPlayersSliderImpl : SliderControllerImpl<SubroomModel>
		{
			[SerializeField]
			private TextMeshProUGUI maxValueText;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void FHPNDLFMODO(float IPMIIEAGJKC)
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
