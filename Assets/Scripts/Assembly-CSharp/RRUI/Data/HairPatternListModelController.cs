using System;
using UnityEngine;

namespace RRUI.Data
{
	public class HairPatternListModelController : ModelController<HairPatternListModel>
	{
		[Serializable]
		private class HairPatternListSpawnerImpl : RecyclingListControllerImpl<HairPatternListModel, HairPatternModel>
		{
			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HairPatternCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<HairPatternListModel, HairPatternModel, HairPatternModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, HairPatternModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}
	}
}
