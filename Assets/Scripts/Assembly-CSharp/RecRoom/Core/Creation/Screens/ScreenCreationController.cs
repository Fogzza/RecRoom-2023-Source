using System;
using RecRoom.Tools;
using UnityEngine;

namespace RecRoom.Core.Creation.Screens
{
	[Serializable]
	public class ScreenCreationController : CreationController
	{
		public enum MKIDDCEJELD
		{
			Free = 0,
			Orbit = 1,
			ZoomTranslateTwist = 2
		}

		public const float DEFAULT_CREATION_DISTANCE_FROM_CAMERA = 0.66f;

		public const float DEFAULT_SELF_SCALE_PIVOT_DISTANCE = 3f;

		public const float MIN_SELF_SCALE_PIVOT_DISTANCE = 0.1f;

		public const float MAX_SELF_SCALE_PIVOT_DISTANCE = 250f;

		[NonSerialized]
		private ScreenPlayerController screenPlayerController;

		[NonSerialized]
		private AECAHLPIFOC screenInputHandler;

		[NonSerialized]
		private ScreenHUD hud;

		[NonSerialized]
		private Camera camera;

		[NonSerialized]
		private FMNJCGLEDJO primaryActionControl;

		[NonSerialized]
		private FMNJCGLEDJO activeInputControlType;

		protected override Transform InternalTransform => null;

		public override DLLIMLHNBON SelectInputButtonState => default;

		public override float AnalogInputValue => 0f;

		public bool AreSelectKeyActive { private get; set; }

		public bool IsProUXSelectHeld => false;

		public bool IsProUXDeselectHeld => false;

		public bool IsProUXDeselectAllHeld => false;

		public bool IsProUXPreventingSelect => false;

		private FMNJCGLEDJO TouchPressControlType => FMNJCGLEDJO.SmartInteractButton;

		private FMNJCGLEDJO TouchDragControlType => FMNJCGLEDJO.SmartInteractButton;

		private FMNJCGLEDJO TouchPencilControlType => FMNJCGLEDJO.SmartInteractButton;

		private Vector2 InputViewportPosition => default;

		public static float SelfScaleMaxPivotDistance => 0f;

		public override Ray GFDICPJIEJB()
		{
			return default;
		}

		public override Vector3 ILLMHPKDFLD(float PNJHHGDHBEC)
		{
			return default;
		}

		public void BJDNGFKFKPK(ScreenPlayerController IOGLKJIGMPG, Camera GAPPCJHIBEK, ScreenHUD JOGBBEAGAAN, AECAHLPIFOC KAEDAICECGN, MakerPen BHCCDMJFHEO)
		{
		}

		public void EHMICKMBCPH(FMNJCGLEDJO KJFCANKEENJ)
		{
		}

		private void IBEBEKKLHOM(Player ICHBECDKHOJ)
		{
		}

		public override void KENBMBNOMKI()
		{
		}

		public void HPMFAKCHHPH()
		{
		}

		public void AKEBCIDJNHJ()
		{
		}

		public void BKEIECIODIE()
		{
		}

		public void NGDNBEFJOEI()
		{
		}

		public override void FLBEPMPANEL(object IALNODEHBNN)
		{
		}

		public override void AMFPGMNBIDB(object IALNODEHBNN)
		{
		}

		public override bool HCLGHJAMCNC()
		{
			return false;
		}

		public Vector3 KLCNLGBAMJI()
		{
			return default;
		}

		private bool LOIPBAMOHFM(IOCPDIHFMFC KAEDAICECGN, Touch DCBELOGCCHD)
		{
			return false;
		}

		private bool JCAIHLKDBHG(IOCPDIHFMFC KAEDAICECGN, Touch DCBELOGCCHD)
		{
			return false;
		}

		private void BEBEICNHIAP()
		{
		}

		private void CAJPLHFAGLM(out DLLIMLHNBON ONMKHCBEKPF, out Vector2 OADOFEDJPMP, out float LOKHOFDDODO)
		{
			ONMKHCBEKPF = default;
			OADOFEDJPMP = default;
			LOKHOFDDODO = default;
		}

		public bool NJBDFOFGEFM()
		{
			return false;
		}

		public static bool PJNKJEJDNKN(AECAHLPIFOC KAEDAICECGN)
		{
			return false;
		}

		public static bool MNBEOLJPFOC(AECAHLPIFOC KAEDAICECGN)
		{
			return false;
		}

		public static bool DNKMPKHCFIF(AECAHLPIFOC KAEDAICECGN)
		{
			return false;
		}

		public static bool PPDBPLCGNMG(AECAHLPIFOC KAEDAICECGN)
		{
			return false;
		}

		private static bool GEINEDDPPGM(AECAHLPIFOC KAEDAICECGN, Vector2 DCOCEALLNNI, ref MKIDDCEJELD EDMEIHBCFLJ, out float CLGOJDJAIHF, out Vector2 HLGFOMEHPOH, out Vector2 DFDLLPFGAGA)
		{
			CLGOJDJAIHF = default;
			HLGFOMEHPOH = default;
			DFDLLPFGAGA = default;
			return false;
		}

		public static void BAMKBIBCKNA(Player EKOFNPFCLMO, AECAHLPIFOC KAEDAICECGN, Vector3 DBGNCAACKOB, Quaternion LHNKPBJILBF, Vector2 DCOCEALLNNI, Vector3 BMPPENMBABF, ref MKIDDCEJELD EDMEIHBCFLJ, ref float NMMMFOOAFFE, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
		}

		public static void LDBKEIDDPPI(Player EKOFNPFCLMO, Vector3 DBGNCAACKOB, Quaternion LHNKPBJILBF, Vector3 HKIMHJLMCPC, Vector3 BMPPENMBABF, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
		}
	}
}
