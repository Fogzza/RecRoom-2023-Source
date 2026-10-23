using System;
using UnityEngine;

namespace RRUI.Data
{
	public class AvatarColorListModelController : ModelController<AvatarColorListModel>
	{
		[Serializable]
		private class AvatarColorListSpawnerImpl : RecyclingListControllerImpl<AvatarColorListModel, AvatarColorModel>
		{
			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AvatarColorCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<AvatarColorListModel, AvatarColorModel, AvatarColorModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AvatarColorModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}
	}
}
