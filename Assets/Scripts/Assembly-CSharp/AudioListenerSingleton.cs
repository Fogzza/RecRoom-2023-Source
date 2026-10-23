using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioListenerSingleton : SingletonMonoBehaviour<AudioListenerSingleton>
{
	public enum PBDPLBGCFIP
	{
		None = 0,
		Space = 1,
		Mines = 2,
		Underwater = 10,
		Cave_Small = 20,
		Cave_Big = 21,
		Fog = 22,
		RuntimeLerp = 1000
	}

	[Serializable]
	public struct HighPassSettings
	{
		public static readonly HighPassSettings Default;

		public static readonly HighPassSettings Max;

		public static readonly HighPassSettings None;

		public bool enabled;

		public float cutoffFrequency;

		public static HighPassSettings IHGPMJMOOAL(HighPassSettings NNMPJECKECI, HighPassSettings EFNJCAIBDLA, float IHPJCBCPLCM)
		{
			return default;
		}

		public void FCHPJDINKJI(AudioHighPassFilter FEPCOBNCBHL)
		{
		}
	}

	[Serializable]
	public struct LowPassSettings
	{
		public static readonly LowPassSettings Default;

		public static readonly LowPassSettings Max;

		public static readonly LowPassSettings None;

		public float cutoffFrequency;

		public static LowPassSettings IHGPMJMOOAL(LowPassSettings NNMPJECKECI, LowPassSettings EFNJCAIBDLA, float IHPJCBCPLCM)
		{
			return default;
		}

		public void FCHPJDINKJI(AudioLowPassFilter BLJBMLACICD)
		{
		}
	}

	[Serializable]
	public struct ReverbSettings
	{
		public static readonly ReverbSettings Default;

		public static readonly ReverbSettings None;

		public float dryLevel;

		public float room;

		public float roomHF;

		public float roomLF;

		public float decayTime;

		public float decayHFRatio;

		public float reflectionsLevel;

		public float reflectionsDelay;

		public float reverbLevel;

		public float reverbDelay;

		public float hfReference;

		public float lfReference;

		public float diffusion;

		public float density;

		public static ReverbSettings IHGPMJMOOAL(ReverbSettings NNMPJECKECI, ReverbSettings EFNJCAIBDLA, float IHPJCBCPLCM)
		{
			return default;
		}

		public void FCHPJDINKJI(AudioReverbFilter AJGMDOCEDHO)
		{
		}
	}

	[Serializable]
	public struct AudioEffectSettings
	{
		public static readonly AudioEffectSettings None;

		public string name;

		public string tooltip;

		public PBDPLBGCFIP effectType;

		public LowPassSettings lowPass;

		public HighPassSettings highPass;

		public ReverbSettings reverb;

		public bool excludeFromUI;

		public static readonly AudioEffectSettings Default;

		public static AudioEffectSettings IHGPMJMOOAL(AudioEffectSettings NNMPJECKECI, AudioEffectSettings EFNJCAIBDLA, float IHPJCBCPLCM)
		{
			return default;
		}
	}

	private sealed class KIKLBBFPFJD
	{
		public Func<AudioEffectSettings, int> enumValue;

		internal MIBJNNKFLND _003CEnumChoiceData_003Eb__2(AudioEffectSettings e)
		{
			return default;
		}
	}

	private sealed class JNNIGGFNBDI
	{
		public PBDPLBGCFIP type;

		internal bool _003CGetRROEffect_003Eb__0(AudioEffectSettings s)
		{
			return false;
		}
	}

	[SerializeField]
	private AudioLowPassFilter lowPassFilter;

	[SerializeField]
	private AudioReverbFilter reverbFilter;

	[SerializeField]
	private AudioHighPassFilter highPassFilter;

	[SerializeField]
	private AudioEffectSettings[] RROEffects;

	[EFEFIKFHIDK]
	[SerializeField]
	private AudioEffectSettings targetEffect;

	private static float CMDCIKCGIDN;

	private static AudioEffectSettings GEEKDPFNIAI;

	private PBDPLBGCFIP NCOMFKMBPMI;

	private static readonly HashSet<CNDHJIBBLCN> EDEDANJFKIN;

public PBDPLBGCFIP LastAudioEffectType
{
get 	{
		return PBDPLBGCFIP.None;
	}

private set {
	}
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

	public Dictionary<string, MIBJNNKFLND> EnumChoiceData(Func<AudioEffectSettings, int> MFCNJMCAPLA)
	{
		return null;
	}

	public void ApplyAudioEffect(PBDPLBGCFIP NIFOGEBEDNG)
	{
	}

	public AudioEffectSettings? GetRROEffect(PBDPLBGCFIP NIFOGEBEDNG)
	{
		return null;
	}

	private void HHLHAKEJKPN(AudioEffectSettings? GHICKOKIDPF, float FIEBIJJCMCJ = 1f)
	{
	}

	private void GLAGAMCKCNN(PBDPLBGCFIP NIFOGEBEDNG)
	{
	}

	private void LBDNCOCMDIJ(CNDHJIBBLCN FCAOAGCHDMG)
	{
	}

	private void NNAKELHEGML(Scene PBLCKBNCAFM, LoadSceneMode FFDKLDFJBMF)
	{
	}

	public bool RegisterEffectZone(CNDHJIBBLCN FCAOAGCHDMG)
	{
		return false;
	}

	public bool UnregisterEffectZone(CNDHJIBBLCN FCAOAGCHDMG)
	{
		return false;
	}

	private void EPDENLDGEBB()
	{
	}
}
