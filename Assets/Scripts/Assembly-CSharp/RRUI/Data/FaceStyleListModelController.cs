using System;
using UnityEngine;

namespace RRUI.Data
{
	public class FaceStyleListModelController : ModelController<FaceStyleListModel>
	{
		[Serializable]
		private class FaceStyleListSpawnerImpl : RecyclingListControllerImpl<FaceStyleListModel, FaceStyleModel>
		{
			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FaceStyleCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<FaceStyleListModel, FaceStyleModel, FaceStyleModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, FaceStyleModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}
	}
}
