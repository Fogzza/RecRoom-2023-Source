using System;
using UnityEngine;

namespace RRUI.Data
{
	public class BeardPatternListModelController : ModelController<BeardPatternListModel>
	{
		[Serializable]
		private class BeardPatternListSpawnerImpl : RecyclingListControllerImpl<BeardPatternListModel, BeardPatternModel>
		{
			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BeardPatternCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<BeardPatternListModel, BeardPatternModel, BeardPatternModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, BeardPatternModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}
	}
}
