using System;
using UnityEngine;

namespace RRUI.Data
{
	public class FaceShapeListModelController : ModelController<FaceShapeListModel>
	{
		[Serializable]
		private class FaceShapeListSpawnerImpl : RecyclingListControllerImpl<FaceShapeListModel, FaceShapeModel>
		{
			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FaceShadeCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<FaceShapeListModel, FaceShapeModel, FaceShapeModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, FaceShapeModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}
	}
}
