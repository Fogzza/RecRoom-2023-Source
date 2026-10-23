using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI.ToolUIs
{
	public class ClipboardPagedGrid : RecyclerPagedGrid<LFIOJFLIPFC, ClipboardButton>
	{
		[Serializable]
		public class SnapshotSelectedEvent : UnityEvent<LFIOJFLIPFC>
		{
		}

		private sealed class NHOBNEJKBPG
		{
			public ClipboardPagedGrid _003C_003E4__this;

			public ClipboardButton button;

			internal void _003CSetupNewChild_003Eb__0(RadioButton3D isOn)
			{
			}
		}

		public SnapshotSelectedEvent OnSnapshotSelectedEvent;

		[SerializeField]
		private RadioGroup3D radioGroup;

		[NonSerialized]
		private bool IJCJMKDCCHE;

		private RadioButton3D IECLCPKGPKH;

		private LFIOJFLIPFC PJADDILPMCM;

		private void OnDisable()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		public void Refresh(LFIOJFLIPFC KCAPLJEHMMI)
		{
		}

		public void SetSnapshots(IEnumerable<LFIOJFLIPFC> PAODFNENIAH, LFIOJFLIPFC KCAPLJEHMMI)
		{
		}

		protected override void ANLHNIJPJEC(LFIOJFLIPFC EEKOIHMJIDP, ClipboardButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}

		protected override void LKIICDHGCMD(ClipboardButton HHDMPJJAPJJ)
		{
		}

		private void GNOECPCHMPC()
		{
		}

		private void IGCANCOCOIH()
		{
		}

		private void JFAGLBIDFKL()
		{
		}

		[CompilerGenerated]
		private bool OPIOJOLBMGA(ClipboardButton FCCGDNMAHPA)
		{
			return false;
		}

		[CompilerGenerated]
		private bool KAPEDGDIOEH(RadioButton3D EFNJCAIBDLA)
		{
			return false;
		}
	}
}
