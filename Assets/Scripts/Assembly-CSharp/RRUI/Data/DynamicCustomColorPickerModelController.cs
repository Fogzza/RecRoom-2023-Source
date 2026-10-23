using System;
using System.Text.RegularExpressions;
using RRUI.Utils;
using UnityEngine;

namespace RRUI.Data
{
	public class DynamicCustomColorPickerModelController : ModelController<DynamicCustomColorPickerModel>
	{
		[Serializable]
		private class ColorInputFieldImpl : InputFieldControllerImpl<DynamicCustomColorPickerModel>
		{
			public enum GANJPMLBANN
			{
				RGB = 0,
				HSV = 1,
				HEX = 2
			}

			private const int ALPHA = 1;

			private static readonly Regex floatsRegex;

			[SerializeField]
			private GANJPMLBANN inputType;

			protected override void CLOGAKFNBGH(string IPMIIEAGJKC)
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private string KAIPGNAPHBA(Color DHNNLHJMKIH)
			{
				return null;
			}

			private string BKABFADPODE(Color JHBHAPMBJAJ)
			{
				return null;
			}

			private bool KGJLILKHDAI(string IPMIIEAGJKC, out Color HMCAFGCGFJF)
			{
				HMCAFGCGFJF = default;
				return false;
			}

			private float[] JJDOHGHHLIO(string IPMIIEAGJKC, Func<float, float> OAOFIBLHLKC)
			{
				return null;
			}

			private bool BHIHBHPPBLB(string IPMIIEAGJKC, out Color HMCAFGCGFJF)
			{
				HMCAFGCGFJF = default;
				return false;
			}

			private bool BPJHMMFPCCD(string IPMIIEAGJKC, out Color HMCAFGCGFJF)
			{
				HMCAFGCGFJF = default;
				return false;
			}

			private bool CBKELLJKGGF(string IPMIIEAGJKC, out Color HMCAFGCGFJF)
			{
				HMCAFGCGFJF = default;
				return false;
			}
		}

		[Serializable]
		private class DoneButtonImpl : ButtonControllerImpl<DynamicCustomColorPickerModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RawImageColorPickerImpl : ControllerImplementation<DynamicCustomColorPickerModel>
		{
			[SerializeField]
			private RawImageColorPicker colorPicker;

			protected override void AFELIDKEEFL()
			{
			}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void HDFPIIEDKJJ(Color HMCAFGCGFJF)
			{
			}
		}

		[Serializable]
		private class ValueSliderImpl : SliderControllerImpl<DynamicCustomColorPickerModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void FHPNDLFMODO(float IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class PickedColorImageImpl : ImageControllerImpl<DynamicCustomColorPickerModel>
		{
			public bool forceMaxValue;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PickedColorNameImpl : TextControllerImpl<DynamicCustomColorPickerModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class InfoTextImpl : TextControllerImpl<DynamicCustomColorPickerModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
