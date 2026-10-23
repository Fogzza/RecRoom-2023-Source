using System;
using RecRoom.Core.Creation.SceneMoods;
using RecRoom.Core.Creation.SceneMoods.MoodBlendData;
using UnityEngine;
using UnityEngine.Rendering;

namespace RecRoom.Core.Scene
{
	[Serializable]
	public class SceneMoodSettings : NMIKADGOIOE
	{
		[SerializeField]
		private MoodSetting[] availableMoods;

		[SerializeField]
		private MoodSetting defaultMood;

		[SerializeField]
		private Volume volume;

		private VolumeProfile defaultVolumeProfile;

		[SerializeField]
		private VolumeProfile defaultStudioVolumeProfile;

		[SerializeField]
		private ReflectionProbe[] reflectionProbes;

		private bool isEnabled;

		private float reflectionIntensity;

		private float ambientLightIntensity;

		private bool skyboxDirty;

		private BackgroundObjectsRoot _backgroundObjectsRoot;

		private float lastReflectionProbeUpdateTime;

		private int lastQualityLevel;

		private global::MOBDJNEDDKC<int> _currentRoomMoodIndex;

		private bool hasRecRoomSkyboxShader;

		private bool hasSunSource;

		private const int CUBE_FACE_WIDTH = 4;

		private const int CUBE_FACE_PIXELS = 16;

		public EEANDDJEMJC OnCurrentRoomMoodChanged;

		public bool RoomMoodsEnabled => false;

		public global::IBHLEFGNKPJ<SkyBoxMoodSettings> SkyBoxMoodSettingsBlender { get; }

		public global::IBHLEFGNKPJ<SunMoodSettings> SunMoodSettingsBlender { get; }

		public global::IBHLEFGNKPJ<FogMoodSettings> FogMoodSettingsBlender { get; }

		public global::IBHLEFGNKPJ<BloomMoodSettings> BloomMoodSettingsBlender { get; }

		public global::IBHLEFGNKPJ<ColorGradingMoodSettings> ColorGradingMoodSettingsBlender { get; }

		public global::IBHLEFGNKPJ<BackgroundObjectsMoodSettings> BackgroundObjectsMoodSettingsBlender { get; }

		public float ReflectionIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AmbientLightIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BackgroundObjectsRoot BackgroundObjectsRoot => null;

		public MoodSetting CurrentMood => null;

		public bool SupportsMoodCircuits => false;

		private MoodSetting PrevMood { get; set; }

		public int CurrentRoomMoodIndex
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		private MoodSetting studioRoomUnityMood { get; set; }

		public bool HasRecRoomSkyboxShader => false;

		public bool HasSunSource => false;

		public bool IsUsingStudioMoods => false;

		public Volume Volume => null;

		public VolumeProfile DefaultVolumeProfile => null;

		private Cubemap reflectionCubeMap { get; set; }

		public VolumeProfile ActiveVolumeProfile { get; private set; }

		public void KEKBKJGNAEM(bool BFDBCMGIOBG)
		{
		}

		public void JGHENDHCBHF(RecRoomSceneManager MACMCOFLIIO)
		{
		}

		public void BJDNGFKFKPK()
		{
		}

		public void LJODMHLJPAD()
		{
		}

		private void IFBMMEFNMAA(VolumeProfile KJODMOMNBCK)
		{
		}

		public void FHDNBNFKHEE(Guid JMIFIJDBMNM)
		{
		}

		public void KGGPAKIFNBH(VolumeProfile FGHLJIFOMBA)
		{
		}

		public void FALIINPAFLM()
		{
		}

		private void KBBPNOECHID()
		{
		}

		public void MOGLPKPIPIF()
		{
		}

		public void IGNKMPOIDHL()
		{
		}

		public void HEACDLOFJHA(MoodSetting ADCDGFNDOEJ)
		{
		}

		private void ECMCOOHADCB()
		{
		}

		public void CDJHKCNAIKI()
		{
		}

		private void FLEPPDNJEPO(Color AEELHBFHBLO, Color ACIMOCDEAKB, Color OOPGMKKFOCM)
		{
		}

		private void NGFHKEDLIFK(Color MAKNKGFNPMJ, Color PLIADGJMDON, CubemapFace KAJJOBOBAIK)
		{
		}

		private void NNMLLDEKFCA()
		{
		}

		public void KPFOBOPDHJM()
		{
		}

		public void NNLAKHMGIOA()
		{
		}

		private void CHFDMNHALAP()
		{
		}

		private void ICEEOFKNEMN()
		{
		}

		private void EKDCLJGANKN(DHJLEHBOGBG ICHBECDKHOJ, bool FPMKKJKAHFN)
		{
		}
	}
}
