using System;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class SearchModelController : ModelController<SearchModel>
	{
		[Serializable]
		private class GoToPlayMenuSearchPageButtonImpl : ButtonControllerImpl<SearchModel>
		{
			[SerializeField]
			private TMP_InputField searchQueryInput;

			[SerializeField]
			private DBECJLAIPEL loadSceneSource;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClearTextOnModelChangedImpl : ControllerImplementation<SearchModel>
		{
			[SerializeField]
			private TMP_InputField textMeshProInput;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
