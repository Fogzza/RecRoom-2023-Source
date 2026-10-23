using System;
using RRUI.Data;
using RecRoom.Core.Creation;
using RecRoom.Core.UI;
using UnityEngine;

namespace RecRoom.Tools
{
	public class TetheredUIBase : MonoBehaviour
	{
		private readonly struct AEGMLNPGOKP
		{
			public readonly Vector3 EGJKEDKNNAD;

			public readonly Quaternion IBHAEICNMJI;

			public readonly float KIJDIOHEBHG;

			public AEGMLNPGOKP(Vector3 BOGIPKDGJNP, Quaternion PKKLFHKHOBK, float JDFDFBKKBPO)
			{
				EGJKEDKNNAD = default;
				IBHAEICNMJI = default;
				KIJDIOHEBHG = 0f;
			}
		}

		public const float LERP_SPEED = 10f;

		[SerializeField]
		private RectTransform rectTransform;

		[SerializeField]
		private Vector3 preferredOffsetFromHead;

		[SerializeField]
		private float minScaleRatio;

		[SerializeField]
		private float maxScaleRatio;

		[SerializeField]
		private float tearoffDistanceOffset;

		[SerializeField]
		private Vector3 tearoffTargetLocalPosition;

		[SerializeField]
		private WireframeCube hoverOutline;

		[SerializeField]
		private WireframeCube selectedOutline;

		[SerializeField]
		private Canvas canvas;

		[SerializeField]
		private BrowserModel _browser;

		[SerializeField]
		private ScrollManagerModel _scrollManagerModel;

		[SerializeField]
		private bool scaleWithPlayerWorkspace;

		public static readonly global::BPEPJJDICII<TetheredUIBase, bool> LocalTetheredMenuVisibilityChangedEvent;

		public readonly EEANDDJEMJC TetheredStateChangedEvent;

		private readonly FIHGBEHGLGB DFMJAMCCMBF;

		private readonly FIHGBEHGLGB HCJMHIOCKFI;

		private bool FPFINNJICGO;

		[SerializeField]
		private bool avoidVRKeyboard;

		private GHHCOOGMCNH FLNKOBIALBM;

		public Func<bool> avoidKeyboardBehaviorVRDetachedCheck;

		private Vector3 BLHPNIHHLDP;

		private float AKJMGJMFCJG;

		private Vector3 EGJKEDKNNAD;

		private Quaternion IBHAEICNMJI;

		private float KIJDIOHEBHG;

		private AEGMLNPGOKP? HPPDPGHFPPA;

		[SerializeField]
		private bool isProUXFixedMenu;

		[SerializeField]
		private Vector3 proUXFixedMenuOffset;

		private bool BJBMCEBGLCL;

		private bool AAEPKHBFADA;

		private bool DHBOCLGCLPN;

		private bool IJFAHDAFKMO;

public BrowserModel Browser
{
get 		{
			return null;
		}

}

public bool IsVisible
{
get 		{
			return false;
		}

private set {
		}
}

public RectTransform RectTransform
{
get 		{
			return null;
		}

}

public float TearoffDistanceOffset
{
get 		{
			return 0f;
		}

}

public Vector3 TearoffTargetLocalPosition
{
get 		{
			return default;
		}

}

public bool IsPinnedInWorld
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsAutoRotationLocked
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsInitialDragActive
{
get 		{
			return false;
		}

set {
		}
}

public bool AGVirtualKeyboardBehaviorActive
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsAutoRotationAllowed
{
get 		{
			return false;
		}

}

public bool IsAutoRotationActive
{
get 		{
			return false;
		}

}

private static Vector3 JCFJCABLNKL
{
get 		{
			return default;
		}

}

private static Quaternion JOJLILDFCJG
{
get 		{
			return default;
		}

}

private static float BLMFNFEOPHB
{
get 		{
			return 0f;
		}

}

private int ANHCLGGIJAP
{
get 		{
			return 0;
		}

}

		private void Awake()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected void OnDestroy()
		{
		}

		private void IAILPEBNPCN()
		{
		}

		public void ResetTetheredMenu()
		{
		}

		public void ResetTetheredMenuToDefault()
		{
		}

		public void SetWorldPosition(Vector3 ADJINPMOILO, bool LBFEJCHAIDN = true)
		{
		}

		public void SetWorldRotation(Quaternion LLJPMBHCKEE)
		{
		}

		public bool TryGetLocalPropertiesToSave(out Vector3 INLGLHIPOMC, out Vector3 CFEMGDGPGFK, out float PDNBMOJFPKO, out bool BMGEHFPFCBJ, out bool BJBMCEBGLCL, out bool JLEPOJNJCBO)
		{
			INLGLHIPOMC = default;
			CFEMGDGPGFK = default;
			PDNBMOJFPKO = default;
			BMGEHFPFCBJ = default;
			BJBMCEBGLCL = default;
			JLEPOJNJCBO = default;
			return false;
		}

		public void SaveLastTransformData()
		{
		}

		public void SetLocalProperties(Vector3 INLGLHIPOMC, Vector3 CFEMGDGPGFK, float PDNBMOJFPKO, bool AFGGACOEEBI)
		{
		}

		public void SetLocalScale(float JDFDFBKKBPO)
		{
		}

		public void ResetLocalScale()
		{
		}

		public void TogglePinnedInWorld()
		{
		}

		public void ToggleRotationLock()
		{
		}

		private void AOGGJGIAKIF()
		{
		}

		public void OnMoveUIHandleDragged(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
		{
		}

		public void OnResizeUIHandleDragged(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
		{
		}

		public void OnDistanceUIHandleDragged(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
		{
		}

		private void MKBOJDKLDGG()
		{
		}

		private void HAPNOFPIIIG()
		{
		}

		private void KIIAMKOJLID()
		{
		}

		private void LHFJCFADOJA()
		{
		}

		private void ANDLOEJGFGP()
		{
		}

		private void BDNJJCMGCKE()
		{
		}

		private Vector3 KMIMLBHEKIB()
		{
			return default;
		}

		private Quaternion IOEKGNDAKLC()
		{
			return default;
		}

		private Quaternion AFDEMADOIPE()
		{
			return default;
		}

		public void OnAGVirtualKeyboardOpened()
		{
		}

		public void OnAGVirtualKeyboardClosed()
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public virtual void SetVisible(bool BMGEHFPFCBJ)
		{
		}

		public void FreezeCanvasUpdates()
		{
		}

		public void SetOutlineFlags(object IALNODEHBNN, bool JGLLBKBIBMI, bool FPMKKJKAHFN)
		{
		}

		private void GCHIKBEAGAH()
		{
		}
	}
}
