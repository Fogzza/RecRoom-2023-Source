using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Comfort
{
	public class VRLocomotionComfortMode : MonoBehaviour
	{
		[Serializable]
		public struct SerializedSettings
		{
			public string Mode;

			public string Technique;

			public float Size;

			public static readonly SerializedSettings Default;

			public HIBCGAAJJPA ModeAsEnum => HIBCGAAJJPA.Off;

			public OACKHDNDIMI TechniqueAsEnum => OACKHDNDIMI.Screen;

			public SerializedSettings(HIBCGAAJJPA DNLPIHIBJDP, OACKHDNDIMI FKJKFPOPDCH, float CAPKFCHDLFA)
			{
				Mode = null;
				Technique = null;
				Size = 0f;
			}

			public override string ToString()
			{
				return null;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public override bool Equals(object ICHBECDKHOJ)
			{
				return false;
			}

			[SpecialName]
			public static bool IGOCGGBJBII(SerializedSettings NNMPJECKECI, SerializedSettings EFNJCAIBDLA)
			{
				return false;
			}

			[SpecialName]
			public static bool BHBKJCPJNJN(SerializedSettings NNMPJECKECI, SerializedSettings EFNJCAIBDLA)
			{
				return false;
			}
		}

		public enum HIBCGAAJJPA
		{
			Off = 0,
			OnlyVehicles = 1,
			On = 2
		}

		public enum OACKHDNDIMI
		{
			Screen = 0,
			Vignette = 1
		}

		[Serializable]
		public struct ScreenSettings
		{
			public float Depth;

			public float Fov;
		}

		private sealed class GCIDKDCDMLB
		{
			public Camera hmdCamera;

			public int previousCullingMask;

			public CameraClearFlags previousClearFlags;

			public UniversalAdditionalCameraData hmdCameraAdditionalData;

			public uint previousFastLinesCullingMask;

			public VRLocomotionComfortMode _003C_003E4__this;

			public Skybox skybox;

			public Material previousSkyboxOverride;

			internal void _003CSetupScreensComfortMode_003Eb__0()
			{
			}
		}

		public const OACKHDNDIMI DefaultTechnique = OACKHDNDIMI.Screen;

		public const HIBCGAAJJPA DefaultMode = HIBCGAAJJPA.Off;

		public const float DefaultEffectSize = 1f;

		private OACKHDNDIMI PGECMGPGHPJ;

		private HIBCGAAJJPA POADJFADCHJ;

		private float FAGDBFHKALK;

		[SerializeField]
		private GameObject ScreenObject;

		[SerializeField]
		private GameObject ScreenEnvironmentPrefab;

		private GameObject OCIOJCIMIEJ;

		[SerializeField]
		private float vignetteAnimateTime;

		[SerializeField]
		private Camera comfortModeCamera;

		[SerializeField]
		private Renderer comfortScreenRenderer;

		[SerializeField]
		private int screenVerticalResolution;

		[SerializeField]
		private Material skyboxOverride;

		[SerializeField]
		private ScreenSettings defaultScreen;

		[SerializeField]
		private ScreenSettings smallScreen;

		private long HDDCNDLOELP;

		private bool EIDKPPLDOEA;

public OACKHDNDIMI Technique
{
get 		{
			return OACKHDNDIMI.Screen;
		}

set {
		}
}

public HIBCGAAJJPA Mode
{
get 		{
			return HIBCGAAJJPA.Off;
		}

set {
		}
}

public float EffectSize
{
get 		{
			return 0f;
		}

set {
		}
}

public Camera ScreenCamera
{
get 		{
			return null;
		}

}

public bool Active
{
get 		{
			return false;
		}

set {
		}
}

public long EnabledForNextRoomId
{
get 		{
			return 0L;
		}

set {
		}
}

public bool EnabledForThisRoomOverride
{
get 		{
			return false;
		}

set {
		}
}

		public void OnVRPlayerControllerInitialization()
		{
		}

		public void OnVRPlayerControllerCleanup()
		{
		}

		private void EJAKPJANFMJ()
		{
		}

		private void COHHFEHDFBA()
		{
		}

		public IDisposable ApplyCurrentComfortModeSettings(Camera KBLKLNLIKCG)
		{
			return null;
		}

		private IDisposable IMJCPMMOAPP()
		{
			return null;
		}

		private void KIAKAOABDDG()
		{
		}

		private IDisposable OOBGIPKNJLI(Camera KBLKLNLIKCG)
		{
			return null;
		}

		private void HFHCBNNGBHO()
		{
		}
	}
}
