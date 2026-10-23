using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RecRoom.Core.Creation;
using UnityEngine;

namespace RRUI.Data
{
	public class MakerPenSwatchModel : MakerPenModelBase
	{
		private sealed class HIHHGGIIBLK
		{
			public ShapeMaterialInfo[] materials;

			public ShapeColorInfo selectedColorInfo;

			public bool forceTransparentQueue;

			public bool cameraLit;

			public MakerPenSwatchModel _003C_003E4__this;

			public BaseDialogModel dialog;

			public Func<ShapeMaterialInfo, bool> _003C_003E9__4;

			internal void _003CShowSwatchMaterialDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, ShapeMaterialInfoModel fromModel, JLOCLGGLOPP toController)
			{
			}

			internal int _003CShowSwatchMaterialDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CShowSwatchMaterialDialog_003Eb__4(ShapeMaterialInfo color)
			{
				return false;
			}

			internal void _003CShowSwatchMaterialDialog_003Eb__2(int index)
			{
			}

			internal void _003CShowSwatchMaterialDialog_003Eb__3(BaseDialogModel<KCOKPCOFDIM> d)
			{
			}
		}

		public const string SWATCH_ROUTE_STRING = "MakerPenRoutes/(Makerpen_Palette_Color_And_Material)";

		private ShapeSwatchInfo FGEGCNOOOOF;

		private IReadOnlyList<ShapeSwatchInfo> BBKFLAKNIPO;

		private Material HIBLHCDMBNM;

public ShapeSwatchInfo TempSwatch
{
get 		{
			return null;
		}

}

public IReadOnlyList<ShapeSwatchInfo> ShapeSwatchInfos
{
get 		{
			return null;
		}

}

public float UVScale
{
get 		{
			return 0f;
		}

}

public Material UIShapeMaterialInstance
{
get 		{
			return null;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		public void OnSwatchesChanged()
		{
		}

		public void RestoreSwatch()
		{
		}

		public void ShowSwatchColorDialog()
		{
		}

		public void ShowSwatchMaterialDialog()
		{
		}

		public void SelectCreationData(JLHLKDMLBPK? HMCAFGCGFJF = null, MJGMBIJIKFH? PMPDPBDKGPF = null, float? PALJJNGJNBE = null)
		{
		}

		private void IBOOKMCGJIP(bool BKJEKHGCKGF = true)
		{
		}

		private void IBOOKMCGJIP()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(RRUIModel.AAHMEOHNDKA KMDKPCPJKJH)
		{
			return null;
		}

		[CompilerGenerated]
		private int LKFLMCDCMLN()
		{
			return 0;
		}

		[CompilerGenerated]
		private void JNMOMNNEHIP(int HMCAFGCGFJF)
		{
		}

		[CompilerGenerated]
		private void JFKDKKEGOPN(CLKEJFGKNDK NIFOGEBEDNG, AMFPEDOFIGE PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private void DIOLMCEJIEK()
		{
		}
	}
}
