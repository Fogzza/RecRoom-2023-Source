using System;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomKeyListModelController : ModelController<RoomKeyListModel>
	{
		[Serializable]
		private class TryCreateLinkImpl : LinkControllerImpl<RoomKeyListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromSearchUriImpl : FromUriControllerImpl<RoomKeyListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class RoomKeyListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<RoomKeyListModel, RoomKeyModel, RoomKeyModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, RoomKeyModel MDENKAMNHAJ, JLOCLGGLOPP DIDNBMKAMCA)
			{
			}
		}

		[Serializable]
		private class RoomKeyListSpawnerImpl : RecyclingListControllerImpl<RoomKeyListModel, RoomKeyModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}
	}
}
