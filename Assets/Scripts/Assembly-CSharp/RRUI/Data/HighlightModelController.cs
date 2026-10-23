using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class HighlightModelController : ModelController<HighlightModel>
	{
		[Serializable]
		private class ResetScrollOnHighlightImpl : ControllerImplementation<HighlightModel>
		{
			[SerializeField]
			[HNDJNPOHFJK]
			private string highlightElement;

			[SerializeField]
			private ScrollRect scrollRect;

			[SerializeField]
			private Vector2 normalizedScrollPos;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void GLDMBJIMPBM()
			{
			}
		}

		[Serializable]
		private class ResetRecyclingScrollOnHighlightImpl : ControllerImplementation<HighlightModel>
		{
			[SerializeField]
			[HNDJNPOHFJK]
			private string highlightElement;

			[SerializeField]
			private RecyclingListScrollRect scrollRect;

			[SerializeField]
			private int targetElementIndex;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void GLDMBJIMPBM()
			{
			}
		}

		[Serializable]
		private class DisableScrollOnHighlinightImpl : ControllerImplementation<HighlightModel>
		{
			[SerializeField]
			[HNDJNPOHFJK]
			private string highlightElement;

			[SerializeField]
			private RecyclingListScrollRect scrollRect;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DisableComponentOnHighlightImpl : ControllerImplementation<HighlightModel>
		{
			[HNDJNPOHFJK]
			[SerializeField]
			private string highlightElement;

			[SerializeField]
			private MonoBehaviour component;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ResetMakerPenPaletteSearchOnHighlightImpl : ControllerImplementation<HighlightModel>
		{
			[SerializeField]
			[HNDJNPOHFJK]
			private string highlightElement;

			[SerializeField]
			private MakerPenPaletteSearchModel searchModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OverrideCachedViewStateModelOnHighlightImpl : ControllerImplementation<HighlightModel>
		{
			[SerializeField]
			[HNDJNPOHFJK]
			private string highlightElement;

			[SerializeField]
			private CachedViewStateModel cacheModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
