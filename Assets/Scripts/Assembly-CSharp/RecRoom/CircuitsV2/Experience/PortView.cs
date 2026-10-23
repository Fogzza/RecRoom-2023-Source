using System;
using System.Runtime.CompilerServices;
using Circuits.Shared.Utilities;
using RecRoom.CircuitsV2.Config;
using TMPro;
using UnityEngine;

namespace RecRoom.CircuitsV2.Experience
{
	[Serializable]
	public sealed class PortView
	{
		[SerializeField]
		private TextMeshPro text;

		[SerializeField]
		private TextMeshPro defaultValueText;

		[SerializeField]
		private GameObject portVisualRoot;

		[SerializeField]
		private GameObject meshParent;

		[SerializeField]
		private MeshFilterAndRenderer[] portComponents;

		[SerializeField]
		private MeshFilterAndRenderer[] plugComponents;

		[SerializeField]
		private MeshFilterAndRenderer[] defaultValueComponents;

		[SerializeField]
		private GameObject iconsRoot;

		[SerializeField]
		private GameObject arrayIcon;

		[SerializeField]
		private GameObject syncIcon;

		private string lastDefaultValueText;

		private MaterialPropertyBlock _defaultValueMaterialPropertyBlock;

		private MaterialPropertyBlock _portMaterialPropertyBlock;

		private Port portGameObject;

		private static int _materialHighlightColorsInitFrame;

		private int _validHighlightRequestId;

		private bool _hasRequestedHighlight;

		private int _lastHighlightRequestFrame;

		public TextMeshPro Text => null;

		public TextMeshPro DefaultValueText => null;

		public Transform VisualTransform => null;

		public float LayoutWidth { get; private set; }

		private MaterialPropertyBlock DefaultValueMaterialPropertyBlock => null;

		private MaterialPropertyBlock PortMaterialPropertyBlock => null;

		public void IFIGMJHIABP(HEJEFJABMHN ELCLBJBCJFB, ChipConfig KILCCDFGMGN, DGNNDGAENKL FAHEJHOHAFA, Port KNPJEMEMOEF, IOKind FNHCAJMGKEP)
		{
		}

		private bool ENDMCNOPBPO()
		{
			return false;
		}

		private void LBBJMPHDEDH(CircuitsV2Config NEMCFGENMLA, DGNNDGAENKL AECGBKJAICN, TypeConfig JALCAFDFJIA, IOKind FNHCAJMGKEP)
		{
		}

		private void FCHFILHCHHD(DGNNDGAENKL AECGBKJAICN, TypeConfig JALCAFDFJIA, bool HKAJIIDAPPC)
		{
		}

		private void NCHAILPCCEN(CircuitsV2Config DJOEDCPNAOE)
		{
		}

		private void ELEEJEMJLCO()
		{
		}

		private void OBGOEAMEENB(HEJEFJABMHN ELCLBJBCJFB, DGNNDGAENKL AECGBKJAICN)
		{
		}

		public void LLMDGPBECDH(CircuitsV2Config NEMCFGENMLA, DGNNDGAENKL AECGBKJAICN, int AMGNCPLIAAC)
		{
		}

		private void JEFPBGANIOA()
		{
		}

		private void PEEBKDKKMIN(CircuitsV2Config NEMCFGENMLA, DGNNDGAENKL AECGBKJAICN)
		{
		}

		private void HJOLABCAAIL(DGNNDGAENKL AECGBKJAICN, bool HKAJIIDAPPC)
		{
		}

		private void IOHPIPCJLGJ(CircuitsV2Config NEMCFGENMLA, DGNNDGAENKL AECGBKJAICN)
		{
		}

		private void KBLIJIFKJPD(CircuitsV2Config NEMCFGENMLA, DGNNDGAENKL FAHEJHOHAFA, IOKind FNHCAJMGKEP)
		{
		}

		public void PALNEGFBMHA(HEJEFJABMHN ELCLBJBCJFB, DGNNDGAENKL AECGBKJAICN, IOKind FNHCAJMGKEP)
		{
		}

		public void IAFCJCKIFEN(HEJEFJABMHN ELCLBJBCJFB, DGNNDGAENKL AECGBKJAICN, IOKind FNHCAJMGKEP)
		{
		}

		public void EIJNLGPPMKE(HEJEFJABMHN ELCLBJBCJFB, DGNNDGAENKL AECGBKJAICN)
		{
		}

		public void PLMCKILJKOE(HEJEFJABMHN ELCLBJBCJFB, DGNNDGAENKL AECGBKJAICN, in MEKIBDBDLCM MNJIEOBJGJG)
		{
		}

		public Renderer[] BOLGHCADMFJ()
		{
			return null;
		}

		public void MOKLDKICINM(bool BMGEHFPFCBJ)
		{
		}

		public void HNOIAJPOCAL(bool BMGEHFPFCBJ)
		{
		}

		private static void HIMGBACNCPJ()
		{
		}

		[CompilerGenerated]
		private object NBOCFMJMEGH(in DGNNDGAENKL OBMFEGLDKLB)
		{
			return null;
		}

		[CompilerGenerated]
		private object NMFFECDLLNF(in DGNNDGAENKL OBMFEGLDKLB)
		{
			return null;
		}

		[CompilerGenerated]
		private object CLFFBMFLOFG(in DGNNDGAENKL OBMFEGLDKLB)
		{
			return null;
		}

		[CompilerGenerated]
		internal static Color MJFILMGIHII(Color HMCAFGCGFJF)
		{
			return default;
		}

		[CompilerGenerated]
		internal static void IPLOHEOOLFI(MeshFilterAndRenderer[] JMJJOBEMJFO, MaterialPropertyBlock CCJNODPJDNN)
		{
		}

		[CompilerGenerated]
		private object EICJILJAGHK(in (DGNNDGAENKL, bool) OBMFEGLDKLB)
		{
			return null;
		}

		[CompilerGenerated]
		private object HJANHNKMBEP(in (DGNNDGAENKL, string, string) OBMFEGLDKLB)
		{
			return null;
		}

		[CompilerGenerated]
		private object AOFMDFCKMLD(in DGNNDGAENKL OBMFEGLDKLB)
		{
			return null;
		}
	}
}
