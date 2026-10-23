using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.UI;
using VRPanorama;

namespace RecRoom.Systems.StreamingCamera
{
	public class SpectatorWatchUIFlow : WatchUIFlow
	{
		[Serializable]
		private struct SliderToFrameRateSetting
		{
			public string name;

			public int SliderValue;

			public StreamingCameraController.JHDBKKPINJP frameRate;
		}

		[Serializable]
		private struct SliderToFOVSetting
		{
			public string name;

			public int SliderValue;

			public StreamingCameraController.PLGPJGPONJL fov;
		}

		[Serializable]
		private struct SliderToGreenScreenSetting
		{
			public string name;

			public int SliderValue;

			public StreamingCameraController.DCHKLOPKEMJ mode;
		}

		[Serializable]
		private struct SliderToLightSetting
		{
			public string name;

			public int SliderValue;

			public float intensity;
		}

		[Serializable]
		private struct SliderToLightRangeSetting
		{
			public string name;

			public int SliderValue;

			public float range;
		}

		private sealed class LNJPONLCBHI
		{
			public SpectatorStreamPreviewScreen screen;

			internal bool _003CAssignNextAvailableCameraTransform_003Eb__0(AIJCNLJNCFM c)
			{
				return false;
			}
		}

		private sealed class BNOPLBJJGKM
		{
			public SpectatorStreamPreviewScreen screen;

			internal bool _003CAssignNextAvailableCameraTransformOfType_003Eb__0(AIJCNLJNCFM c)
			{
				return false;
			}
		}

		private sealed class HKFDJOGIGAL : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpectatorWatchUIFlow _003C_003E4__this;

			private VRCapture _003Cpanorama_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public HKFDJOGIGAL(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public RawImage StreamerCamMainImage;

		public Text CurrentPreviewName;

		[SerializeField]
		private Vector2 previewResolution;

		[SerializeField]
		private Texture2D streamNotAvailableTexture;

		[SerializeField]
		private Texture2D selectStreamTexture;

		[SerializeField]
		private SliderToFrameRateSetting[] sliderToFrameRateSettings;

		[SerializeField]
		private SliderToFOVSetting[] sliderToFOVSettings;

		[SerializeField]
		private SliderToGreenScreenSetting[] sliderToGreenScreenSettings;

		[SerializeField]
		private SliderToLightSetting[] sliderToLightSettings;

		[SerializeField]
		private SliderToLightRangeSetting[] sliderToLightRangeSettings;

		[SerializeField]
		private Slider3D fpsSlider;

		[SerializeField]
		private Slider3D fovSlider;

		[SerializeField]
		private Slider3D audioListenerPositionSlider;

		[SerializeField]
		private Slider3D greenScreenSlider;

		[SerializeField]
		private Slider3D lightIntensitySlider;

		[SerializeField]
		private Slider3D lightRangeSlider;

		[SerializeField]
		private ToggleButton3D useHandheldToggle;

		[SerializeField]
		private ToggleButton3D panoramaToggle;

		[SerializeField]
		private GameObject handheldCameraPrefab;

		[SerializeField]
		private GameObject _360UI;

		private Camera NJCHENCMJHH;

		private SpectatorStreamPreviewScreen[] CHBOJILIJMK;

		private int LCPJBEFEHEN;

		private AIJCNLJNCFM CMAEKMHEGJD;

		private Texture2D HHAKCAKDCEL;

		private RenderTexture LBDOOHBEGPP;

		private RenderTexture HLACIGNCBEI;

		private static HandheldStreamerCamera ODBOAJHKNPB;

		private static List<AIJCNLJNCFM> LPMPNOBJPCM;

		private static int LBJBCIOCEMA;

		private bool FJFPKMPDIMB;

		private static AIJCNLJNCFM.PDJEKLDPCKF MPLELCBBJDJ;

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		private void LEMKGFIFHOC(AIJCNLJNCFM BAIEFEDBPOF)
		{
		}

		private void OCPADBPEABA()
		{
		}

		private void Update()
		{
		}

		private void NNMCGHJHNDL(AIJCNLJNCFM GAPPCJHIBEK, ref Texture2D CIONKGJFLOB, bool ADHBGJBLFME = false)
		{
		}

		private void OnEnable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void HMKLDEJGFGF(Player EKOFNPFCLMO)
		{
		}

		public static void LocalSetCameraTransformToFollowByType(AIJCNLJNCFM.PDJEKLDPCKF GGIAMACIBEA, StreamingCameraController.BALGCJONOAC GLLFHCCFIGK)
		{
		}

		private static void GCKPCBLPNEJ(AIJCNLJNCFM BAIEFEDBPOF, StreamingCameraController.BALGCJONOAC GLLFHCCFIGK)
		{
		}

		private void AGOFEKOJJNC()
		{
		}

		private void HGIDGAMECOP(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		private void FEJPMHJLDPP()
		{
		}

		private void HGOLGGEMFKK(SpectatorStreamPreviewScreen PAIGGIFGLMH, SpectatorStreamPreviewScreen.FGNOBDGHJMH EMFDNONIEIA)
		{
		}

		private void FBMCIBEHNGO(SpectatorStreamPreviewScreen PAIGGIFGLMH, int HLFIBIDOLEF)
		{
		}

		private void MCMLFODBCHF(SpectatorStreamPreviewScreen PAIGGIFGLMH, AIJCNLJNCFM.PDJEKLDPCKF NIFOGEBEDNG)
		{
		}

		public void Button_ToggleHandheldCamera(bool on)
		{
		}

		public void UseHandheldCamera()
		{
		}

		public void RecallHandheldCamera()
		{
		}

		private void OBIHPLAOFBA(Tool PMEFICGEDFK)
		{
		}

		public void Slider_FrameRateValueChange(float value)
		{
		}

		public void Slider_FOVValueChange(float value)
		{
		}

		public void Slider_AudioListenerPositionValueChange(float value)
		{
		}

		public void Slider_GreenScreenValueChange(float value)
		{
		}

		public void Slider_LightValueChange(float value)
		{
		}

		public void Slider_LightRangeValueChange(float value)
		{
		}

		public void Toggle_360Panorama(bool value)
		{
		}

		private IEnumerator BFLIDEJFCMG()
		{
			return null;
		}

		private void DNNJJLPCOMD()
		{
		}

		public static bool RegisterStreamPoint(SpectatorStreamPoint PDFEDMAOMNH)
		{
			return false;
		}

		public static bool UnregisterStreamPoint(SpectatorStreamPoint PDFEDMAOMNH)
		{
			return false;
		}

		public static string GetNumberedStreamPointName(string KNOPFGAGMCN)
		{
			return null;
		}
	}
}
