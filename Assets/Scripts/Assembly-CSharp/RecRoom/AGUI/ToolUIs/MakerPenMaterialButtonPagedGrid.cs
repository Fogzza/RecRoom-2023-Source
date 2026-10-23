using System;
using System.Collections.Generic;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI.ToolUIs
{
	public class MakerPenMaterialButtonPagedGrid : RecyclerPagedGrid<MJGMBIJIKFH, MakerPenColorButton>
	{
		[Serializable]
		public class MaterialSelectedEvent : UnityEvent<MJGMBIJIKFH>
		{
		}

		private sealed class LMHJAFAEKEE
		{
			public MakerPenMaterialButtonPagedGrid _003C_003E4__this;

			public MakerPenColorButton button;

			internal void _003CSetupNewChild_003Eb__0(RadioButton3D isOn)
			{
			}
		}

		private sealed class LDIFDOMGPFG
		{
			public RadioButton3D selectedRadioButton;

			internal bool _003CUpdateSelectedButtonState_003Eb__0(RadioButton3D b)
			{
				return false;
			}
		}

		[SerializeField]
		private MakerPenPaletteMainScreen uiFlowBase;

		[SerializeField]
		private RadioGroup3D radioGroup;

		[SerializeField]
		private Subscreen subscreen;

		public MaterialSelectedEvent OnMaterialSelectedEvent;

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void CHAFJFDDMOE(bool FBHDABEFLKL)
		{
		}

		protected override void LKIICDHGCMD(MakerPenColorButton HHDMPJJAPJJ)
		{
		}

		public void UpdateSelectedButtonState()
		{
		}

		public void ResetSelectedMaterial()
		{
		}

		public void SetShapeMaterials(IEnumerable<MJGMBIJIKFH> IAPNMPFINIK, MJGMBIJIKFH KCAPLJEHMMI)
		{
		}

		protected override void ANLHNIJPJEC(MJGMBIJIKFH APGHJHBHCFA, MakerPenColorButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
