using System;
using System.Collections.Generic;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI.ToolUIs
{
	public class MakerPenColorButtonPagedGrid : RecyclerPagedGrid<JLHLKDMLBPK, MakerPenColorButton>
	{
		[Serializable]
		public class ColorSelectedEvent : UnityEvent<JLHLKDMLBPK>
		{
		}

		private sealed class CEHLPOHBIJH
		{
			public MakerPenColorButtonPagedGrid _003C_003E4__this;

			public MakerPenColorButton button;

			internal void _003CSetupNewChild_003Eb__0(RadioButton3D isOn)
			{
			}
		}

		private sealed class NDPNKHKNONH
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

		[SerializeField]
		private MakerPenMaterialButtonPagedGrid materialButtonPagedGrid;

		public ColorSelectedEvent OnColorSelectedEvent;

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

		public void ResetSelectedColor()
		{
		}

		public void SetShapeColors(IEnumerable<JLHLKDMLBPK> IEHHIPOJDBG, JLHLKDMLBPK KCAPLJEHMMI)
		{
		}

		protected override void ANLHNIJPJEC(JLHLKDMLBPK LNBGDJLPKJM, MakerPenColorButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
