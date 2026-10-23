using System;
using System.Collections.Generic;
using RecRoom.Core.Comfort;
using RecRoom.Core.ImageEffects;
using RecRoom.Core.Rendering;
using RecRoom.UI.Notifications;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace RecRoom.Core
{
	[DisallowMultipleComponent]
	public class CameraRig : InjectedSingletonMonoBehaviour<LHHINNFLJMD, CameraRig>, LHHINNFLJMD
	{
		private static readonly string[] MCNIFHJFPNA;

		[SerializeField]
		private Camera vrModeHmdCamera;

		private UniversalAdditionalCameraData PCLGPDFALPH;

		[SerializeField]
		private VRTrackedController vrLeftHandTrackedController;

		[SerializeField]
		private VRTrackedController vrRightHandTrackedController;

		[SerializeField]
		private VRModeScreenSpaceNotificationConfig vrModeScreenSpaceNotificationConfig;

		[SerializeField]
		private VROverlayHUD vrOverlayHUD;

		[SerializeField]
		private Camera screenModeCamera;

		private UniversalAdditionalCameraData MGBLMAGHGGJ;

		[SerializeField]
		private VRLocomotionComfortMode vrLocomotionComfortMode;

		[SerializeField]
		private AudioListener audioListener;

		[SerializeField]
		private PostProcessingEffectStack postProcessEffectStack;

		[SerializeField]
		private WorldFadeMaterialsConfig worldFadeMaterials;

		[SerializeField]
		private SelectionMaterialsConfig selectionMaterials;

		[SerializeField]
		private HeightOffsetPoint juniorModeOffsetPoint;

		[SerializeField]
		private HeightOffsetPoint seatedModeOffsetPoint;

		[SerializeField]
		private float standingScaleStartAngle;

		[SerializeField]
		private float standingScaleEndAngle;

		public static EEANDDJEMJC ActiveCameraChangeEvent;

		private const float IPFFDCDELEI = 0.15f;

		private readonly List<Camera> FECNLHPDKNN;

		private PostProcessingEffectStack KLNMGHNBEJJ;

		private ScreenHUD PEHOBFKIIEM;

		private Transform FDPGJIADNLE;

		private BLNKKABFHJD HAJHFDIGAPH;

		private Dictionary<int, float> PCAJPBMHMKO;

		private float GIAPGIPLMJJ;

		private object IKEKBCMBKCK;

		private object ODMJIPMPAMM;

		private IDisposable DCKDGPDAHMF;

public IReadOnlyList<Camera> ActiveCameraAndActiveFirstPersonCameras
{
get 		{
			return null;
		}

}

public IReadOnlyList<Camera> ActiveFirstPersonCamerasOnly
{
get 		{
			return null;
		}

}

public Camera ActiveCamera
{
get 		{
			return null;
		}

}

public Camera VrModeHmdCamera
{
get 		{
			return this.vrModeHmdCamera;
		}

}

public Camera ScreenModeCamera
{
get 		{
			return this.screenModeCamera;
		}

}

public UniversalAdditionalCameraData VrModeHmdUniversalCameraAdditionalData
{
get 		{
			return this.PCLGPDFALPH;
		}

}

public UniversalAdditionalCameraData ScreenModeUniversalCameraAdditionalData
{
get 		{
			return this.MGBLMAGHGGJ;
		}

}

public PostProcessingEffectStack ImageEffects
{
get 		{
			return this.KLNMGHNBEJJ;
		}

private set {
		}
}

public ScreenHUD ScreenModeHUD
{
get 		{
			return this.PEHOBFKIIEM;
		}

private set {
		}
}

public Transform VrModeHMDCameraTransformYawOnly
{
get 		{
			return this.FDPGJIADNLE;
		}

private set {
		}
}

public Vector3 VrModeHmdCameraFloorOffsetLocalSpace
{
get 		{
			return default;
		}

}

public Vector3 ActiveCameraWorldPosition
{
get 		{
			return default;
		}

}

public Vector3 ActiveCameraDirection
{
get 		{
			return default;
		}

}

public HeightOffsetPoint JuniorModeOffsetPoint
{
get 		{
			return this.juniorModeOffsetPoint;
		}

}

public HeightOffsetPoint SeatedModeOffsetPoint
{
get 		{
			return this.seatedModeOffsetPoint;
		}

}

public VROverlayHUD VrWatchNotificationDialog
{
get 		{
			return this.vrOverlayHUD;
		}

}

public bool VrLocomotionComfortModeEnabled
{
get 		{
			return false;
		}

set {
		}
}

public VRLocomotionComfortMode VrLocomotionComfortMode
{
get 		{
			return this.vrLocomotionComfortMode;
		}

}

		[Obsolete]

public static float ActiveCameraScale
{
get 		{
			return 0f;
		}

}

public GameObject WorldSpaceUICameraAttachedObject
{
get 		{
			return null;
		}

}

		public void AddActiveFirstPersonCamera(Camera GAPPCJHIBEK)
		{
		}

		public void RemoveActiveFirstPersonCamera(Camera GAPPCJHIBEK)
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void DNFAKKNDPGP()
		{
		}

		private void PMKNJCDNLPO()
		{
		}

		private void PONCEJGGKKF()
		{
		}

		private void EJKPMJDGCAE(GHCCKFEJDOA PKJIEOPNCHK)
		{
		}

		private void NNAKELHEGML(UnityEngine.SceneManagement.Scene PBLCKBNCAFM, LoadSceneMode FFDKLDFJBMF)
		{
		}

		private void GHBMKBHPGNH(bool OEOOMHKLNMA)
		{
		}

		public VRTrackedController GetTrackedController(VRTrackedController.EGONEFPMCNI BNNHCJJILFB)
		{
			return null;
		}

		public void UpdateVSync()
		{
		}

		public void UpdateRenderer()
		{
		}

		private void PPBFBDKNPEB()
		{
		}

		private void CFJFOLEMEDG()
		{
		}

		public static float CalcLODBias(float MCJDGJKGDBH, float BFBAEFFKAIM, float LACHBHPAEKC)
		{
			return 0f;
		}

		public Vector3 GetClosestPointInFieldOfView(Vector3 JKKAKJBFOKN)
		{
			return default;
		}

		public void AttachTransformToActiveCamera(Transform FGNGGLFNLIP)
		{
		}

		private void MKKNINLGNGH(Transform FGNGGLFNLIP, Camera GAPPCJHIBEK)
		{
		}

		public void SetTransform(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
		{
		}
	}
}
