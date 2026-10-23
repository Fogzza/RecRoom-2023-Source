using System;
using System.Collections.Generic;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI.ToolUIs
{
	public class MakerPenColorableSnapshotButtonPagedGrid : RecyclerPagedGrid<JECDPJHHBNL, MakerPenColorableSnapshotButton>
	{
		[Serializable]
		public class ColorSelectedEvent : UnityEvent<JECDPJHHBNL>
		{
		}

		private sealed class JNEKKEGKKJE
		{
			public RadioButton3D selectedRadioButton;

			internal bool _003CUpdateSelectedButtonState_003Eb__0(RadioButton3D b)
			{
				return false;
			}
		}

		private sealed class INGOLPDCGOM
		{
			public MakerPenColorableSnapshotButtonPagedGrid _003C_003E4__this;

			public MakerPenColorableSnapshotButton button;

			internal void _003CSetupNewChild_003Eb__0(RadioButton3D isOn)
			{
			}
		}

		public ColorSelectedEvent OnColorSelectedEvent;

		[SerializeField]
		private RadioGroup3D radioGroup;

		[SerializeField]
		private Subscreen subscreen;

		[SerializeField]
		private MakerPenPaletteMainScreen uiFlowBase;

		public void Refresh(JECDPJHHBNL KCAPLJEHMMI)
		{
		}

		public void ResetSelectedSnapshot()
		{
		}

		public void SetColorableSnapshots(IEnumerable<JECDPJHHBNL> ECBMNKHFPIH, JECDPJHHBNL KCAPLJEHMMI)
		{
		}

		public void UpdateSelectedButtonState()
		{
		}

		protected override void Awake()
		{
		}

		protected override void ANLHNIJPJEC(JECDPJHHBNL HDMIPGPFAPH, MakerPenColorableSnapshotButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}

		protected override void LKIICDHGCMD(MakerPenColorableSnapshotButton HHDMPJJAPJJ)
		{
		}

		private void CHAFJFDDMOE(bool FBHDABEFLKL)
		{
		}

		private void GNOECPCHMPC()
		{
		}

		private void OnDisable()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}
	}
}
