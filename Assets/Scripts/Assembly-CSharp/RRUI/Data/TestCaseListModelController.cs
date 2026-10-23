using System;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class TestCaseListModelController : ModelController<TestCaseListModel>
	{
		[Serializable]
		private class TestCaseListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<TestCaseListModel, TestCaseModel, TestCaseModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected sealed override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, TestCaseModel OMHJMCFKBCH, JLOCLGGLOPP JECDMGMOGJD)
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<TestCaseListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class CategoryTagToggleImpl : ToggleControllerImpl<TestCaseListModel>
		{
			[SerializeField]
			private TextMeshProUGUI chipText;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TagSpawnerImpl : PrefabSpawnerControllerImpl<TestCaseListModel>
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
