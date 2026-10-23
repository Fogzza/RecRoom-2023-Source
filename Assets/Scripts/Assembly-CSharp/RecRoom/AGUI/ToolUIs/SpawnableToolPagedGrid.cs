using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI.ToolUIs
{
	public class SpawnableToolPagedGrid : RecyclerPagedGrid<JBGFOIKBKED, SpawnableToolButton>
	{
		[Serializable]
		public class SpawnableToolSelectedEvent : UnityEvent<JBGFOIKBKED>
		{
		}

		private sealed class KNPKBDCDPAM
		{
			public SpawnableToolPagedGrid _003C_003E4__this;

			public SpawnableToolButton button;

			internal void _003CSetupNewChild_003Eb__0(RadioButton3D isOn)
			{
			}
		}

		[SerializeField]
		private StackedUIFlowBase uiFlowBase;

		[SerializeField]
		private RadioGroup3D radioGroup;

		public SpawnableToolSelectedEvent OnSpawnableToolSelectedEvent;

		private JBGFOIKBKED OOAEHPDMNMK;

		private RadioButton3D IECLCPKGPKH;

		private bool IJCJMKDCCHE;

		private const float INGLDBLGIDA = 0.05f;

		private void Start()
		{
		}

		protected override void LKIICDHGCMD(SpawnableToolButton HHDMPJJAPJJ)
		{
		}

		private void JFAGLBIDFKL()
		{
		}

		private void GIFNGAEPLAL()
		{
		}

		public void SetSpawnableTools(IEnumerable<JBGFOIKBKED> BFAKBIJCJAF, JBGFOIKBKED KCAPLJEHMMI)
		{
		}

		public void AddAdditionalSpawnableTools(IEnumerable<JBGFOIKBKED> BFAKBIJCJAF)
		{
		}

		protected override void ANLHNIJPJEC(JBGFOIKBKED GPGEOGFOCMP, SpawnableToolButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}

		[CompilerGenerated]
		private bool JAGJFGJNAMJ(RadioButton3D EFNJCAIBDLA)
		{
			return false;
		}
	}
}
