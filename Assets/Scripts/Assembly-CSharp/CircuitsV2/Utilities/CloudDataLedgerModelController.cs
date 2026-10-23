using System;
using RRUI.Data;
using UnityEngine;

namespace CircuitsV2.Utilities
{
	public class CloudDataLedgerModelController : ModelController<CloudDataLedgerModel>
	{
		[Serializable]
		private class NameTextImpl : TextControllerImpl<CloudDataLedgerModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CloudDataLedgerEntrySpawnerOldImpl : PrefabSpawnerControllerImpl<CloudDataLedgerModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class CloudDataLedgerEntrySpawnerImpl : RecyclingListControllerImpl<CloudDataLedgerModel, MGBCICMHCOL>
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
