using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class MakerPenPaletteModelController : ModelController<MakerPenPaletteSearchModel>
	{
		[Serializable]
		private class Text_SelectedShape : TextControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_ChangeToolMode : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private FBEHJNCKJPN toolMode;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_ChangeTargetMode : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private HHNPLBOFAGE targetMode;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_ShowForToolMode : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private FBEHJNCKJPN toolMode;

			[SerializeField]
			private bool RequireTargetMode_Gadgets;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_ShapesHeader : TextControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_ShapesAdvancedToggle : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Hideable_HideIfNotAllowAdvancedShapes : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_ShapesAdvancedToggle : TextControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Image_ShapesAdvancedToggle : ImageControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private Sprite disabledSprite;

			[SerializeField]
			private Sprite enabledSprite;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Spawner_Shapes : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, MakerPenPaletteSearchItemModel, MakerPenPaletteSearchItemModelController>
		{
			private List<OMEIEHCDNDP> shapes;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, MakerPenPaletteSearchItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class Spawner_Circuit_Test : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, MakerPenPaletteSearchItemModel, MakerPenPaletteSearchItemModelController>
		{
			private sealed class HDABBFLAIAK
			{
				public Spawner_Circuit_Test _003C_003E4__this;

				public string formattedCategory;

				internal void _003COnModelChanged_003Eb__0()
				{
				}
			}

			[NonSerialized]
			private uint lastRefreshVersion;

			private List<OMEIEHCDNDP> resultsToDisplay;

			[SerializeField]
			private string DefaultCategory;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, MakerPenPaletteSearchItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class Spawner_Search_Subpage : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, MakerPenPaletteSearchItemModel, MakerPenPaletteSearchItemModelController>
		{
			[NonSerialized]
			private uint lastRefreshVersion;

			private List<OMEIEHCDNDP> resultsToDisplay;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, MakerPenPaletteSearchItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class Spawner_Favorites : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, MakerPenPaletteSearchItemModel, MakerPenPaletteSearchItemModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, MakerPenPaletteSearchItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class Spawner_Props : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, MakerPenPaletteSearchItemModel, MakerPenPaletteSearchItemModelController>
		{
			private sealed class CNJHOLJGHBE
			{
				public MakerPenPaletteSearchItemModel fromModel;

				internal bool _003COnPopulateInstance_003Eb__0()
				{
					return false;
				}
			}

			[SerializeField]
			private MakerPenCarouselModel carouselModel;

			[SerializeField]
			private JNODIIINKKJ.GEKLJFFEACO sortOption;

			[SerializeField]
			private bool allowElementsHighlight;

			private string highlightedElement;

			private List<OMEIEHCDNDP> existingCarousel;

			private bool shouldRecordPositionChanges;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private void MJOFJEBBPOJ(double CDCEFBJHIAN)
			{
			}

			private void OJEJICBCKNL()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, MakerPenPaletteSearchItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}

			[CompilerGenerated]
			private void OKMJDKAFAOI()
			{
			}
		}

		[Serializable]
		private class Spawner_InventionStore : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, MakerPenPaletteSearchItemModel, MakerPenPaletteSearchItemModelController>
		{
			[NonSerialized]
			private uint lastInventionStoreVersion;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, MakerPenPaletteSearchItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class Button_InventionStore : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Spawner_SwatchToCardSpawner : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, ShapeSwatchInfoModel, ShapeSwatchInfoController>
		{
			private sealed class BMEOCNOHFCP
			{
				public Spawner_SwatchToCardSpawner _003C_003E4__this;

				public ShapeSwatchInfoModel fromModel;

				public int index;

				internal void _003COnPopulateInstance_003Eb__0()
				{
				}

				internal bool _003COnPopulateInstance_003Eb__1()
				{
					return false;
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ShapeSwatchInfoModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class Spawner_ObjectSnapshotToCardSpawner : RecyclingListCardSpawnerControllerImpl<MakerPenPaletteSearchModel, ObjectSnapshotModel, ObjectSnapshotController>
		{
			private sealed class FALKPLLLPMF
			{
				public LFIOJFLIPFC item;

				public Spawner_ObjectSnapshotToCardSpawner _003C_003E4__this;

				internal void _003COnPopulateInstance_003Eb__0()
				{
				}

				internal bool _003COnPopulateInstance_003Eb__1()
				{
					return false;
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ObjectSnapshotModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class Hideable_HideIfNoInventions : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_HideIfNoCertifiedInventions : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_HideIfNoDownloadedInventions : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_HideIfNoMyInventions : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_HideIfNoPublishedInventions : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_HideIfClipboardHasItems : HideableControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}
		}

		[Serializable]
		private class Link_PaletteTab : LinkControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			protected ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}
		}

		[Serializable]
		private class Button_Swatches_SaveAsNew : ButtonControllerImpl<MakerPenPaletteSearchModel>
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
		private class Button_Swatches_Save : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Swatches_Restore : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Swatches_Delete : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Swatches_Color : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private TextMeshProUGUI text;

			[SerializeField]
			private Image icon;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Swatches_Material : ButtonControllerImpl<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private TextMeshProUGUI text;

			[SerializeField]
			private MaskedMaterialImage icon;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Card_SwatchPreview : ControllerImplementation<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private CardModel card;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Slider_ConfigureUVScale : ControllerImplementation<MakerPenPaletteSearchModel>
		{
			[SerializeField]
			private DynamicSliderModel dynamicSlider;

			private LFHCAENGLBN sliderData;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private float CPIGDEKABHN()
			{
				return 0f;
			}

			[CompilerGenerated]
			private void DFFFLDBHEJL(float IPMIIEAGJKC)
			{
			}
		}
	}
}
