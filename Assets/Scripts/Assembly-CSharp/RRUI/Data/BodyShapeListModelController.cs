using System;
using UnityEngine;

namespace RRUI.Data
{
	public class BodyShapeListModelController : ModelController<BodyShapeListModel>
	{
		[Serializable]
		private class BodyShapeListSpawnerImpl : RecyclingListControllerImpl<BodyShapeListModel, BodyShapeModel>
		{
			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BodyShapeCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<BodyShapeListModel, BodyShapeModel, BodyShapeModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, BodyShapeModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}
	}
}
