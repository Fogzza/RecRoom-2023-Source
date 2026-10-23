using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RRUI.Utils
{
	public class RawImageColorPicker : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		private RectTransform cursor;

		[SerializeField]
		private RawImage rawImage;

		[SerializeField]
		private RectTransform rectTransform;

		private Action<Color> HDFPIIEDKJJ__BackingField;

public event Action<Color> ColorPicked {
add {
		}
remove {
		}
}

		void IDragHandler.OnDrag(PointerEventData OEPDOIOJPHD)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData OEPDOIOJPHD)
		{
		}

		public void PickColor(float DMOPJMOOIAJ, float GGKIBLKPJLP, float IPMIIEAGJKC)
		{
		}

		private void OnEnable()
		{
		}

		private void BJJLKKGBIDB(PointerEventData OEPDOIOJPHD)
		{
		}

		private void Start()
		{
		}

		private void MJILPCFCDIO(float BGMHDEHCKDL, float LOCMEGNHNDI)
		{
		}
	}
}
