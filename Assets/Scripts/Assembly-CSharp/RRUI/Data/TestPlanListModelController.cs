using System;
using UnityEngine;

namespace RRUI.Data
{
	public class TestPlanListModelController : ModelController<TestPlanListModel>
	{
		[Serializable]
		private class TestPlanListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<TestPlanListModel, TestPlanModel, TestPlanModelController>
		{
			private sealed class ONKCJPJKHEJ
			{
				public uint testPlanId;

				internal bool _003COnPopulateInstance_003Eb__0()
				{
					return false;
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, TestPlanModel HPGFNJIFDAN, JLOCLGGLOPP LBIFEHHFLIO)
			{
			}
		}

		[Serializable]
		private class LinkButtonImpl : ButtonControllerImpl<TestPlanListModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
