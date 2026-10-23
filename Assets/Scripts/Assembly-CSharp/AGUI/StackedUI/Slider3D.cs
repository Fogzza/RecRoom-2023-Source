using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class Slider3D : Slider
	{
		[Serializable]
		public class OnSlider3DValueUpdateEvent : UnityEvent<float>
		{
		}

		[Serializable]
		public struct SliderValue
		{
			public int Value;

			public string Label;
		}

		public OnSlider3DValueUpdateEvent OnSlider3DValueChanged;

		public OnSlider3DValueUpdateEvent OnSlider3DReleased;

		private StackedUIBase MKHLKCMEBLE;

		[SerializeField]
		private SliderHandleButton Handle;

		[SerializeField]
		private TextMeshProUGUI textLabelPrefab;

		[SerializeField]
		private GameObject slotPrefab;

		public TextMeshProUGUI titleText;

		[SerializeField]
		private Transform slotsParent;

		[SerializeField]
		private Transform textLabelsParent;

		[SerializeField]
		private bool UseWholeNumbers;

		private float PGNJKIGMDAG;

		private bool GABBFJDJOCG;

		private TextMeshProUGUI[] FICKIAAGEPI;

		private float HFIFNFKJCNA;

		private float? MEHKMAPFFOF;

protected StackedUIBase OODKHJEMACH
{
get 		{
			return null;
		}

}

public bool UsingWholeNumbers
{
get 		{
			return false;
		}

}

public TextMeshProUGUI[] TextLabels
{
get 		{
			return null;
		}

}

public bool Interactable
{
get 		{
			return false;
		}

set {
		}
}

public float FloatOrRoundedValue
{
get 		{
			return 0f;
		}

}

		protected override void Awake()
		{
		}

		private void JIKNJJKOJEF(float IPMIIEAGJKC)
		{
		}

		protected override void Update()
		{
		}

		public void PhysicalButtonDownEvent(bool JGBEGFNGCKM)
		{
		}

		public void PhysicalButtonUpEvent(bool JGBEGFNGCKM)
		{
		}

		public override void OnPointerDown(PointerEventData OEPDOIOJPHD)
		{
		}

		public override void OnPointerUp(PointerEventData OEPDOIOJPHD)
		{
		}

		public override void OnDrag(PointerEventData OEPDOIOJPHD)
		{
		}

		public void SetUpSlider(string OFMGPNLDCAB, SliderValue[] DHEBHAPIANM, float GFLAEOLMKMC, bool IPFKEKEKMCJ = true)
		{
		}

		public void SetUpSlider(string OFMGPNLDCAB, int[] NGCPJOCIMLL, float GFLAEOLMKMC, bool IPFKEKEKMCJ = true)
		{
		}

		public void SpawnSlots(SliderValue[] DHEBHAPIANM, GameObject DAJKCNCHHCP, Transform DGHMEOHBNBD)
		{
		}

		public void SpawnTextLabels(SliderValue[] DHEBHAPIANM, TextMeshProUGUI LNDFMJLPINJ, Transform ONMMCOIGPNP)
		{
		}

		private void KDHJPHKKPEK()
		{
		}

		private void GIOABKGMBHG()
		{
		}

		private void DJPGGBPBKOJ(RectTransform FGNGGLFNLIP, float IPMIIEAGJKC, int IGIBKIGIOAM = -1, bool LKONBONMKNO = false)
		{
		}
	}
}
