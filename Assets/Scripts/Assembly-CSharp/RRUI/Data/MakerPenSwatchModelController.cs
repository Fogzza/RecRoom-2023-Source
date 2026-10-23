using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class MakerPenSwatchModelController : ModelController<MakerPenSwatchModel>
	{
		[Serializable]
		private class Button_Swatches_SaveAsNew : ButtonControllerImpl<MakerPenSwatchModel>
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
		private class Button_Swatches_Save : ButtonControllerImpl<MakerPenSwatchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Swatches_Restore : ButtonControllerImpl<MakerPenSwatchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Swatches_Delete : ButtonControllerImpl<MakerPenSwatchModel>
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
		private class Button_Swatches_Color : ButtonControllerImpl<MakerPenSwatchModel>
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
		private class Button_Swatches_Material : ButtonControllerImpl<MakerPenSwatchModel>
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
		private class Card_SwatchPreview : ControllerImplementation<MakerPenSwatchModel>
		{
			[SerializeField]
			private CardModel card;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Slider_ConfigureUVScale : ControllerImplementation<MakerPenSwatchModel>
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

		[Serializable]
		private class Spawner_SwatchToCardSpawner : RecyclingListCardSpawnerControllerImpl<MakerPenSwatchModel, ShapeSwatchInfoModel, ShapeSwatchInfoController>
		{
			private sealed class OCHACMLDFAP
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
	}
}
