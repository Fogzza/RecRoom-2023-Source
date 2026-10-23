using System;
using RecRoom.Core;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenToolCreateShape : MakerPenToolCreate<Guid>
	{
		public abstract class BECHKGLEIKM : NENLBKDEKAE
		{
			protected readonly NNBAJLCGAOK JGEGKOOCOEH;

			protected readonly AMEPDCGKFOG LJGNKMONIGD;

			protected readonly Bounds DBPFJELGIGI;

			protected readonly float JDFDFBKKBPO;

			protected bool KILIILHCDNK;

			protected GHGLPHNCFAD MAIIBAAILHG;

public sealed override Bounds LJGAEEGLFMO
{
get 			{
				return default;
			}

}

public sealed override Quaternion BFFEBCMOFHH
{
get 			{
				return default;
			}

}

			protected BECHKGLEIKM(MakerPen BHCCDMJFHEO, Bounds DBPFJELGIGI, float JDFDFBKKBPO, bool KILIILHCDNK)
				: base(null)
			{
			}

			public sealed override void EFPNKMBLAPD(CreationController IJIAEDONGKE)
			{
			}

			public override void FJBCCJNFIEG(CreationController IJIAEDONGKE, Vector3 BAGMHHCMNNF, Quaternion DNEFKBEHEEC)
			{
			}

			public sealed override void MEBNEHKPHKE()
			{
			}

			public sealed override Quaternion MKKKCJMGKND(MakerPen BHCCDMJFHEO, Quaternion HEGBBJCMANH)
			{
				return default;
			}
		}

		public class EAFJEELDHCB : BECHKGLEIKM
		{
			private readonly bool HILBAKPFAPJ;

public override float EAFCCNDHBHA
{
get 			{
				return 0f;
			}

}

			public EAFJEELDHCB(MakerPen BHCCDMJFHEO, bool KILIILHCDNK)
				: base(null, default, 0f, KILIILHCDNK: false)
			{
			}

			private static float FDDCFFAEBPF(MakerPen BHCCDMJFHEO)
			{
				return 0f;
			}

			public override LAHBDKNMNHN CCGLPNCJJMM(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
			{
				return null;
			}

			public override GJEAOEFGMJC DCHMAEHJMMD(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
			{
				return null;
			}

			public override void NGNONKNDGGK(CreationController IJIAEDONGKE, Ray KJGMGHOAEMP, RaycastHit KNFIEECFHPI, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
			{
				INLGLHIPOMC = default;
				HEGBBJCMANH = default;
			}
		}

		public class GFGFPELCDML : BECHKGLEIKM
		{
			private Guid NAPOCDEMHHH;

public override float EAFCCNDHBHA
{
get 			{
				return 0f;
			}

}

			public GFGFPELCDML(MakerPen BHCCDMJFHEO, bool KILIILHCDNK)
				: base(null, default, 0f, KILIILHCDNK: false)
			{
			}

			private static Bounds KMONCAFINAI(MakerPen BHCCDMJFHEO)
			{
				return default;
			}

			public override LAHBDKNMNHN CCGLPNCJJMM(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
			{
				return null;
			}

			public override GJEAOEFGMJC DCHMAEHJMMD(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
			{
				return null;
			}

			public override void FJBCCJNFIEG(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
			{
			}

			public override void NGNONKNDGGK(CreationController IJIAEDONGKE, Ray KJGMGHOAEMP, RaycastHit KNFIEECFHPI, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
			{
				INLGLHIPOMC = default;
				HEGBBJCMANH = default;
			}

			private FCOHGGHPPMJ HLEDMFBCAHE()
			{
				return default;
			}

			private void HAEDMKFABFP(CreationController IJIAEDONGKE, Vector3 BAGMHHCMNNF)
			{
			}
		}

		private const float MOVABLE_SHAPE_SCALE = 0.5f;

		private string hudLabel;

		protected virtual bool AddToMask => false;

		public override string HudLabel => null;

		public override Sprite HudSprite => null;

		protected override bool IsCreateInputPressed => false;

		public override bool TouchTapSupported => false;

		protected override NENLBKDEKAE INEHLHCFPPG()
		{
			return null;
		}

		protected override void KJIPFGNEEBJ()
		{
		}

		protected override Quaternion LIMALKKILOO(Quaternion EIKMPMAOMIA)
		{
			return default;
		}

		protected override float PHIOEGBFLGO()
		{
			return 0f;
		}
	}
}
