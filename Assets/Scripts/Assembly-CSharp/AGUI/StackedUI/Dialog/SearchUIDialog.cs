using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public class SearchUIDialog : UIDialog<SearchUIDialog.JFJINAGJLHB, SearchUIDialog.KOLHAAIFEBM>
	{
		public delegate void JGNDCJAOFFK(long IKHNIJKGJFD);

		public delegate global::NCOKFFGPIJM<string> IJLILCCPNLJ(long IKHNIJKGJFD);

		public delegate global::NCOKFFGPIJM<Texture2D> HDNHNAANPEF(long IKHNIJKGJFD, out float GDMKKLNFDOP);

		public delegate global::NCOKFFGPIJM<IEnumerable<long>> DOMGBJNEGED(string JDPGCELOKNO);

		public struct JFJINAGJLHB
		{
			public string DNBDJDKKOMO;

			public string AOFJGDCOGFO;

			public string KJCCCAHKINH;

			public DOMGBJNEGED ICCAFJNLIEJ;

			public IJLILCCPNLJ DJIJJKNKGCF;

			public Action<long, SearchResultView> NPOLNKIHNIP;
		}

		public struct KOLHAAIFEBM
		{
			public long GHIEHEOOCPN;

			public HGKINAOMNIF IAMHCABOCOA;
		}

		private static readonly KOLHAAIFEBM KEJCDHMONAL;

		[SerializeField]
		private TMP_Text titleText;

		[SerializeField]
		private TMP_Text okText;

		[SerializeField]
		private TMP_Text infoText;

		[SerializeField]
		private TMP_InputField searchQueryText;

		[SerializeField]
		private TMP_Text searchPlaceholderText;

		[SerializeField]
		private Button3D submitButton;

		[SerializeField]
		private SearchResultsPagedGrid searchResultsPagedGrid;

		private bool AMDJBMBPDNA;

		private DOMGBJNEGED MKFACJJLLIL;

		private long EPFPJOGEEEB;

		public override global::NCOKFFGPIJM<KOLHAAIFEBM> ShowDialog(JFJINAGJLHB GEEJKKJIMNE)
		{
			return null;
		}

		private void NOMNPPCOBAM(long EPFPJOGEEEB)
		{
		}

		private void PACMJFNMALL()
		{
		}

		public override void ForceCancel(bool EDLFMMEDNGP)
		{
		}

		private void PMPDGPLFJOL(string ADGIOFAMOGF)
		{
		}

		public void Button_Search()
		{
		}

		public void Button_Submit()
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		[CompilerGenerated]
		private void GEHGOBPCPAI(IEnumerable<long> ILJGHKGMILC)
		{
		}
	}
}
