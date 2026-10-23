using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI.ToolUIs
{
	public class InventionPagedGrid : RecyclerPagedGrid<OEBAEGDPBLA, InventionButton>
	{
		[Serializable]
		public class InventionSelectedEvent : UnityEvent<OEBAEGDPBLA>
		{
		}

		private sealed class PEIDHJPBPFA
		{
			public InventionPagedGrid _003C_003E4__this;

			public InventionButton button;

			internal void _003CSetupNewChild_003Eb__0(RadioButton3D isOn)
			{
			}

			internal void _003CSetupNewChild_003Eb__1()
			{
			}
		}

		[SerializeField]
		private RadioGroup3D radioGroup;

		public InventionSelectedEvent OnInventionSelectedEvent;

		public InventionSelectedEvent OnInventionInfoEvent;

		private OEBAEGDPBLA JCIJHAKCGPM;

		private RadioButton3D IECLCPKGPKH;

		private bool IJCJMKDCCHE;

		private void Start()
		{
		}

		private void JFAGLBIDFKL()
		{
		}

		protected override void LKIICDHGCMD(InventionButton HHDMPJJAPJJ)
		{
		}

		private void CHFOONAECLN()
		{
		}

		public void SetInventions(IEnumerable<OEBAEGDPBLA> AMIAEMLONAO, OEBAEGDPBLA KCAPLJEHMMI)
		{
		}

		protected override void ANLHNIJPJEC(OEBAEGDPBLA EGDOIKMDMJM, InventionButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}

		[CompilerGenerated]
		private bool HIJIHGGGFNC(RadioButton3D EFNJCAIBDLA)
		{
			return false;
		}
	}
}
