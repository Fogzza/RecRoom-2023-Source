using System;
using System.Collections.Generic;
using RRUI.Data;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public class LoadRoomSaveModelController : ModelController<LoadRoomSaveModel>
	{
		[Serializable]
		private class RoomName_Text : TextControllerImpl<LoadRoomSaveModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LoadRoomSaveVersionList : RecyclingListCardSpawnerControllerImpl<LoadRoomSaveModel, RoomSaveCardModel, RoomSaveCardModelController>
		{
			private sealed class NMDEDILMNLF
			{
				public LoadRoomSaveVersionList _003C_003E4__this;

				public int index;

				internal bool _003COnPopulateInstance_003Eb__0()
				{
					return false;
				}

				internal void _003COnPopulateInstance_003Eb__1()
				{
				}
			}

			private List<IPKJBIFKDKF> cachedSaved;

			private HLNFDOBEGJO roomManager;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, RoomSaveCardModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class SaveButtonImpl : ButtonControllerImpl<LoadRoomSaveModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LoadAutoSaveButtonImpl : ButtonControllerImpl<LoadRoomSaveModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LoadAutoSaveButton_Text : TextControllerImpl<LoadRoomSaveModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotPublicImpl : HideableControllerImpl<LoadRoomSaveModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
