using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class MakerPenPaletteSearchModelController : ModelController<MakerPenPaletteSearchModel>
	{
		[Serializable]
		private class Hideable_HideIfCV2 : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private bool shouldShowIfCV2;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ScrollRect_ResetScroll : ControllerImplementation<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private ScrollRect scrollRect;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Spawner_PaletteSearchItemToCardSpawner : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, MakerPenPaletteSearchItemModel, MakerPenPaletteSearchItemModelController>
		{
			[NonSerialized]
			private uint lastRefreshVersion;

			private List<OMEIEHCDNDP> resultsToDisplay;

			private JNODIIINKKJ.GEKLJFFEACO previousSortOption;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, MakerPenPaletteSearchItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class InputField_SearchBar : InputFieldControllerImpl<MakerPenPaletteSearchModel>
		{
			private bool suppressOnChangeEvent;

			private bool ShouldFocusSearchOnShow => false;

			protected override void LMDNMDLBMGI(string JDPGCELOKNO)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}
		}

		[Serializable]
		private class InputField_SearchBar_Circuits : InputFieldControllerImpl<MakerPenPaletteSearchModel>
		{
			private bool suppressOnChangeEvent;

			[SerializeField]
			private string SearchHeader;

			protected override void LMDNMDLBMGI(string JDPGCELOKNO)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}
		}

		[Serializable]
		private class CategoryTagTogglesSpawnerImpl : PrefabSpawnerControllerImpl<MakerPenPaletteSearchModel>
		{
			private sealed class ICIGMJDGGEH
			{
				public CategoryTagTogglesSpawnerImpl _003C_003E4__this;

				public int index;

				internal void _003COnPopulateInstance_003Eg__OnButtonPress_007C0()
				{
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class ActiveFilterTagTogglesSpawnerImpl : PrefabSpawnerControllerImpl<MakerPenPaletteSearchModel>
		{
			private sealed class BAJKIDMNDIA
			{
				public ActiveFilterTagTogglesSpawnerImpl _003C_003E4__this;

				public int index;

				internal void _003COnPopulateInstance_003Eg__OnButtonPress_007C0()
				{
				}
			}

			private List<string> activeFilters;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class HideIfNoFilterTagTogglesImpl : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_FilterBackButton : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_FilterLabelButton : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			private TextMeshProUGUI text;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_ToggleSearchActive : ToggleControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void GAPFBOGKOON()
			{
			}
		}

		[Serializable]
		private class Button_ViewMoreToggleSearchActive : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private MakerPenCarouselModel carouselModel;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_SetSearchTerm : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private string SearchTerm;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_ClearSerach : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Sort : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			private List<JNODIIINKKJ.GEKLJFFEACO> availableSortOptions;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private JNODIIINKKJ.GEKLJFFEACO JOICBLOINIC()
			{
				return JNODIIINKKJ.GEKLJFFEACO.None;
			}

			[CompilerGenerated]
			private void OEFONNCHKOD(JNODIIINKKJ.GEKLJFFEACO IPMIIEAGJKC)
			{
			}

			[CompilerGenerated]
			private JNODIIINKKJ.GEKLJFFEACO CEJPHOAAKOO()
			{
				return JNODIIINKKJ.GEKLJFFEACO.None;
			}

			[CompilerGenerated]
			private void JAHJHDDINLK(JNODIIINKKJ.GEKLJFFEACO IPMIIEAGJKC)
			{
			}
		}
	}
}
