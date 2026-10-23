using System;
using UnityEngine;

namespace RRUI.Data
{
	public class SessionModelController : ModelController<SessionModel>
	{
		[Serializable]
		private class OpenExitDialogButtonImpl : ButtonControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenSafetyDialogButtonImpl : ButtonControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class QuitButtonImpl : ButtonControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LogoutButtonImpl : ButtonControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToDefaultRoomButtonImpl : ButtonControllerImpl<SessionModel>
		{
			[SerializeField]
			private DBECJLAIPEL loadSceneSource;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToDormButtonImpl : ButtonControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToClubhouseButtonImpl : ButtonControllerImpl<SessionModel>
		{
			[SerializeField]
			private DBECJLAIPEL loadSceneSource;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToRecCenterButtonImpl : ButtonControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToConfigDefinedRoomButtonImpl : ButtonControllerImpl<SessionModel>
		{
			[SerializeField]
			private string configKey;

			[SerializeField]
			private DBECJLAIPEL loadSceneSource;

			private long roomId;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DefaultRoomImageImpl : ImageControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DefaultRoomTextImpl : TextControllerImpl<SessionModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LogoutButtonTextImpl : TextControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanNotGoToDefaultRoomImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanNotGoToRecCenterRoomImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanNotLogoutImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanNotQuitImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfTotalSessionCountLessThan : HideableControllerImpl<SessionModel>
		{
			[SerializeField]
			private int value;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfTotalSessionCountMoreThan : HideableControllerImpl<SessionModel>
		{
			[SerializeField]
			private int value;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfTotalRoomsVisitedCountLessThan : HideableControllerImpl<SessionModel>
		{
			[SerializeField]
			private int value;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfTotalRoomsVisitedCountMoreThan : HideableControllerImpl<SessionModel>
		{
			[SerializeField]
			private int value;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfAccountIsOlderThan : HideableControllerImpl<SessionModel>
		{
			[SerializeField]
			private int days;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfAccountIsNotOlderThan : HideableControllerImpl<SessionModel>
		{
			[SerializeField]
			private int days;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotVRModeImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfDefaultRoomIsClubImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfDefaultRoomIsNotClubImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanNotGoToDormImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanNotGoToClubhouseImpl : HideableControllerImpl<SessionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
