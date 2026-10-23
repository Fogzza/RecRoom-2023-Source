using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRPanorama;

namespace RecRoom.Systems.StreamingCamera
{
	public class StreamingCameraController : SingletonMonoBehaviour<StreamingCameraController>, EHIGGKJFCDL
	{
		public enum JHDBKKPINJP
		{
			_15 = 15,
			_30 = 30,
			_45 = 45,
			_60 = 60,
			_90 = 90
		}

		public enum PLGPJGPONJL
		{
			TwentyDegrees = 20,
			FiftyDegrees = 50,
			Default = 60,
			NinetyDegrees = 90,
			OneHundredTwentyDegrees = 120,
			ThreeHundredSixtyDegrees = 360
		}

		public enum DCHKLOPKEMJ
		{
			Off = 0,
			TwoMeters = 2,
			FiveMeters = 5,
			TenMeters = 10,
			OneHundredMeters = 100
		}

		public enum PEBNLHNMBGI
		{
			OFF = 0,
			ON = 1
		}

		public enum LEBEJPADBEE
		{
			Player = 0,
			StreamCamera = 1
		}

		public enum BALGCJONOAC
		{
			None = 0,
			WatchUI = 1,
			ScreenUI = 2,
			TutorialCam = 3,
			HandheldTool = 4
		}

		private const float DNDDNIKJEJA = 1000f;

		private const string BAEGGPMOCAG = "StreamerCam.FrameRate";

		private const string ICBCBMLFOPO = "StreamerCam.FOV";

		private const string FLBICMFELGA = "StreamerCam.LightIntensity";

		private const string DJIOFOLEMNI = "StreamerCam.LightRange";

		private const string KHADABJDEJD = "StreamerCam.ForceAllMatrixRecalculationPerRender";

		[SerializeField]
		private Transform visualRoot;

		[SerializeField]
		private Camera streamingCamera;

		[SerializeField]
		private float backOffset;

		[SerializeField]
		private float rightOffset;

		[SerializeField]
		private float upOffset;

		[SerializeField]
		private float rotationSmoothingTime;

		[SerializeField]
		private float positionSmoothingTime;

		[SerializeField]
		private Canvas screenCanvas;

		[SerializeField]
		private Camera secondaryDisplayCamera;

		[SerializeField]
		private RawImage rawImage;

		[SerializeField]
		private Transform loadingImage;

		[SerializeField]
		private GameObject vrOnlyPreviewCamera;

		[SerializeField]
		private Light cameraLight;

		private Vector3 INAAEPEFNIM;

		private Vector3 OIEPDFJCEHE;

		private Vector3 INKGHPCDMCG;

		private Quaternion OOFIIEKBKAE;

		private Action<PEBNLHNMBGI> BMOEGMABPKF__BackingField;

		private bool BJDBMALMPJN;

		private bool FMBDGLAJLFD;

		private bool CENEKBCLNJD;

		private RenderTexture KAACGMLIKHK;

		private float AFGAMKGGHFF;

		private int HHMLGOAFINP;

		private int JGHGMJNANEJ;

		private bool EMNHLKMDACB;

		private int FPNFPIICFIB;

		private int ICCOHJGBMPC;

		private static JHDBKKPINJP AHJPHOIPFKN;

		private static PLGPJGPONJL GBPGDPKNOAD;

		public VRCapture PanoramaCapture;

		[HideInInspector]
		public List<Camera> streaming360Cameras;

		private static LEBEJPADBEE JMHMNJAMPFD;

		private static DCHKLOPKEMJ NKLMJOMMPIK;

		private static float EEELAINELFE;

		private static float JGLCOKIPGAE;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private IDisposable NMBBMPMCNNA;

		private Action<AIJCNLJNCFM> HFLCMMJFLFJ__BackingField;

		private AIJCNLJNCFM CLADOLCKLEL;

		private AIJCNLJNCFM BBONAPNFMAF;

		private static bool OKKEDNDPIKP;

public bool IsOn
{
get 		{
			return false;
		}

}

private PEBNLHNMBGI MDEOCKDFDNK
{
get 		{
			return PEBNLHNMBGI.OFF;
		}

set {
		}
}

public Camera StreamingCamera
{
get 		{
			return null;
		}

}

public JHDBKKPINJP FrameRate
{
get 		{
			return (JHDBKKPINJP)0;
		}

private set {
		}
}

public PLGPJGPONJL FoV
{
get 		{
			return (PLGPJGPONJL)0;
		}

set {
		}
}

public LEBEJPADBEE AudioListenerMode
{
get 		{
			return LEBEJPADBEE.Player;
		}

private set {
		}
}

public DCHKLOPKEMJ GreenScreenMode
{
get 		{
			return DCHKLOPKEMJ.Off;
		}

private set {
		}
}

public float LightIntensity
{
get 		{
			return 0f;
		}

private set {
		}
}

public float LightRange
{
get 		{
			return 0f;
		}

private set {
		}
}

public AIJCNLJNCFM DefaultCameraTransformToFollow
{
get 		{
			return null;
		}

set {
		}
}

public AIJCNLJNCFM CameraTransformToFollow
{
get 		{
			return null;
		}

private set {
		}
}

public static bool IsVRMode
{
get 		{
			return false;
		}

}

public static bool CanUseStreamingCam
{
get 		{
			return false;
		}

}

public static Transform MainCameraTransform
{
get 		{
			return null;
		}

}

private static bool PIEJCGCJPIE
{
get 		{
			return false;
		}

}

private static bool FPMDMLMMANM
{
get 		{
			return false;
		}

}

private static bool EMAPDMMAKEA
{
get 		{
			return false;
		}

}

private static bool KJNAHPKGAEJ
{
get 		{
			return false;
		}

}

private static int LOKOMBPGJBF
{
get 		{
			return 0;
		}

}

private static int KAENEHNOFHI
{
get 		{
			return 0;
		}

}

private static Display NMPEDPNBLGO
{
get 		{
			return null;
		}

}

public event Action<PEBNLHNMBGI> StreamingCameraModeChanged {
add {
		}
remove {
		}
}

public event Action<AIJCNLJNCFM> CameraTransformToFollowChanged {
add {
		}
remove {
		}
}

		public void SetMode(PEBNLHNMBGI DNLPIHIBJDP, BALGCJONOAC GLLFHCCFIGK)
		{
		}

		public void SetFrameRate(JHDBKKPINJP GFNKELGIPNM, BALGCJONOAC GLLFHCCFIGK)
		{
		}

		public void SetFieldOfView(PLGPJGPONJL NLIFLBODAJM, BALGCJONOAC GLLFHCCFIGK)
		{
		}

		public void SetAudioListenerMode(int MIIDEIDAFFP, BALGCJONOAC GLLFHCCFIGK)
		{
		}

		public void SetGreenScreen(DCHKLOPKEMJ DNLPIHIBJDP, BALGCJONOAC GLLFHCCFIGK)
		{
		}

		public void SetLightIntensity(float DOEJGDJILAD, BALGCJONOAC CPELKAGLFFJ)
		{
		}

		public void SetLightRange(float IIGHOHLJPIF, BALGCJONOAC CPELKAGLFFJ)
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void JEHJOLANBFH()
		{
		}

		private void PEPCBJDNFCF()
		{
		}

		private void KCFOFBAFNDN()
		{
		}

		private void OLMLNFIHBED(float OKBAJEAPIHG)
		{
		}

		private void PLBINMJIEFG()
		{
		}

		protected void MLMGDOIAOEE(bool BIJHPJHGOEF, bool CLOJHJPNBPD)
		{
		}

		private void MHIAGFHKDED(Scene JADNNNKLJKD, Scene DGLPLIPOBGE)
		{
		}

		private void HFAOLPCEEKA()
		{
		}

		private void PNNLIHOKFCJ()
		{
		}

		private void PGDNCLPNKJA()
		{
		}

		private void ENDPKBHDALP()
		{
		}

		public void SetCameraTransformToFollow(AIJCNLJNCFM BAIEFEDBPOF, BALGCJONOAC GLLFHCCFIGK)
		{
		}

		public void SnapToTarget()
		{
		}

		private void EPGENLDEGNI()
		{
		}

		public void OverrideRenderTexture(RenderTexture JELBNCEFKFJ)
		{
		}

		public bool IsPointOfInterestActive()
		{
			return false;
		}

		public Vector3 GetPointOfInterestPosition()
		{
			return default;
		}

		[CompilerGenerated]
		private void AALEFHGJDOO()
		{
		}
	}
}
