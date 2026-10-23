using System;
using RecRoom.AGUI.ToolUIs;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public class ColorInputUIDialog : UIDialog<string, string, ColorInputUIDialog.NAPKJMELOIH, ColorInputUIDialog.KKIDIEKNOPK>
	{
		public delegate bool NAPKJMELOIH(TextMeshProUGUI HADMIMJGCHD, string KAEDAICECGN);

		public struct KKIDIEKNOPK
		{
			public int GMIENJMNJDD;

			public HGKINAOMNIF IAMHCABOCOA;
		}

		[SerializeField]
		private TextMeshProUGUI titleText;

		[SerializeField]
		private TextMeshProUGUI okText;

		[SerializeField]
		private TextMeshProUGUI infoText;

		[SerializeField]
		private MakerPenColorGrid colorButtonPagedGrid;

		private int BKCAHNGJKJH;

		public Action<int> Preview;

		private NAPKJMELOIH KNOFOIMNEID;

		private static KKIDIEKNOPK GGENACNGOHD;

		private bool AMDJBMBPDNA;

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		public void RefreshShapeColorButtons()
		{
		}

		public void Button_SelectColor(JLHLKDMLBPK shapeColor)
		{
		}

		public override global::NCOKFFGPIJM<KKIDIEKNOPK> ShowDialog(string BOGCJKAMALE, string JINHPNDAHKP = "Ok", NAPKJMELOIH KNOFOIMNEID = null)
		{
			return null;
		}

		public void Button_Submit()
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		public void Button_Cancel()
		{
		}

		public override void ForceCancel(bool EDLFMMEDNGP)
		{
		}
	}
}
