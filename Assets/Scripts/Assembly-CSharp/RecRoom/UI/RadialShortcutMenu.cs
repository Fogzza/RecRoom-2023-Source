using RecRoom.Inputs.Touch;
using UnityEngine;

namespace RecRoom.UI
{
	public class RadialShortcutMenu : ScreenHUDElement
	{
		private enum HKNDGKBCHPG : ushort
		{
			Disabled = 0,
			Closed = 1,
			Open = 2
		}

		private const float EABIHHGEDNG = 1f;

		private const float KIMLNKMIAEO = 0.35f;

		[SerializeField]
		private RadialUILayout radialLayout;

		[SerializeField]
		private RadialShortcutMenuPageEntry centerDisplay;

		[SerializeField]
		private RadialHighlightSlice radialHighlightSlice;

		[SerializeField]
		private Transform animatedScaleRoot;

		[SerializeField]
		private float mouseLocalPositionDeadzone;

		[SerializeField]
		private float gamepadInputDeadzone;

		[SerializeField]
		private float gamepadInputSmoothingDeadzone;

		[SerializeField]
		private float gamepadInputSmoothingLerpSpeed;

		[SerializeField]
		private TouchRegion touchRegion;

		[SerializeField]
		private float touchJoystickSwipeDeadzone;

		[SerializeField]
		private float selectedIconLerpSpeed;

		[SerializeField]
		private float unselectedIconLerpSpeed;

		[SerializeField]
		private AnimationCurve newPageEntryMinimizedPercentByEntryIndex;

		private Vector2 ECOMBKNNHEB;

		private float NEBINCJNNDD;

		private NIDCMIFCEGJ BDHAJAPELBD;

		private bool DOOEPDNJJBD;

		private bool MHJLKHJEAGG;

		private bool CGOMGPAKBMN;

		private bool LKPLOLPCOAM;

		private RadialShortcutMenuPageEntry CPKAPAPEDCN;

		private RadialShortcutMenuPageEntry[] LLMMHKMELMO;

		private MDEJADHJOEJ BGBIFFLGANM;

		private FMNJCGLEDJO IHNEJEMJBBL;

		private AECAHLPIFOC GHMJAHMDKGH;

		private ScreenPlayerController DHHICLJMBED;

private RadialShortcutMenuPageEntry IACMFIGDIKI
{
get 		{
			return null;
		}

set {
		}
}

private bool FMLIHDJFGOC
{
get 		{
			return false;
		}

}

private RadialShortcutMenuPageEntry[] DCCFNLFKBKD
{
get 		{
			return null;
		}

}

public bool IsOpen
{
get 		{
			return false;
		}

}

		protected void Awake()
		{
		}

		public void Open(FMNJCGLEDJO POINFDHCNCM)
		{
		}

		public void Close()
		{
		}

		public void UpdateInput(AECAHLPIFOC JLFMCCADIKH, ScreenPlayerController BIEDNOLFJBE)
		{
		}

		private void PGHOICPFDBL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void PBBMGJOENJO()
		{
		}

		private void GKADLLEJHBO(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void JEMNBBBFGEO()
		{
		}

		public void DisplayPageConfig(NIDCMIFCEGJ AFANIHEKLBP)
		{
		}

		public void StartNewPageAnimation()
		{
		}

		private void LBEGKPILIIA()
		{
		}

		public void UpdateHighlightedEntry(bool PEMDKGAGOJJ, Vector2 FGIMEEKBBHC)
		{
		}

		private int KEMCFNKLLJD(Vector2 ABPGDDFLILD)
		{
			return 0;
		}

		private float BNMCHOOAHNA(int GMEHLIHLGEH)
		{
			return 0f;
		}

		private void PCMAEGDKHMP(int IEBMIJGBFDP)
		{
		}

		private bool GFJBBNGKAOG(Vector2 INLGLHIPOMC, out Vector2 IHDOOILAPFK)
		{
			IHDOOILAPFK = default;
			return false;
		}

		private void CAJPLHFAGLM(out Vector2 OBEIAKKHMDK, out bool PEMDKGAGOJJ, out bool CCPDFPFMJGD, out bool EGLOMEGHIGK)
		{
			OBEIAKKHMDK = default;
			PEMDKGAGOJJ = default;
			CCPDFPFMJGD = default;
			EGLOMEGHIGK = default;
		}
	}
}
