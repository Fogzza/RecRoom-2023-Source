using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Photon.Voice.Unity;
using RecRoom.Core.Studio;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;

namespace RecRoom.Audio
{
	public class AudioManager : SingletonMonoBehaviour<AudioManager>
	{
		private class DELBGLAFOAG
		{
			public readonly AudioMixer BNJPHPEOCAC;

			public readonly AudioMixerGroup CDDLBCNIEPE;

			public readonly string LOBJJJIMDEL;

			public DELBGLAFOAG(AudioMixer NHNPGBJIGBI, AudioMixerGroup PECJKBJALKI, string GNGHOIJOFHJ)
			{
			}
		}

		private sealed class GCEJFLPDIJL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public AudioSource audio;

			public float from;

			public float duration;

			public float to;

			private float _003Ctimer_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public GCEJFLPDIJL(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class AEFBKHCKJJJ
		{
			public Action<SFXAudioSource> onAudioSourceReleasedCallback;

			internal void _003CPlaySFX_003Eg__OnAudioSourceReleased_007C0(SFXAudioSource sfxAudioSource)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct HFKBBKOLMBN : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public AssetReference clipReference;

			public SFXAudioSource.JAIOLKMHIGA playParams;

			public LPDDNINEKAP type;

			private global::EHOCIICLNGN<AudioClip> _003CclipHandle_003E5__2;

			private TaskAwaiter<AudioClip> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct CNLAAMBPAEF : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public LPDDNINEKAP type;

			public AudioClip clip;

			public SFXAudioSource.JAIOLKMHIGA playParams;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const float FDCJKFHCBAO = 20f;

		private const float HGANKDCPJKP = -80f;

		private const float FNGMPEOAGJF = 0f;

		private const float KCCBIBJBPBO = 3f;

		private const string NDFCIKMHFMO = "Ambience";

		private const string CIONEBHHNLD = "Music";

		private const string HJCDIHHMAJM = "SFX";

		private const string MCDLHEPPKCN = "VOIP_Master";

		private const float PFFHIECIAJN = 0.001f;

		private AudioMixer HIEDPBBKPKL;

		private readonly Dictionary<string, DELBGLAFOAG> MGFIDCKIENH;

		private static int GDCABFAKGPA;

		private readonly Dictionary<string, string> DBAKJEENDOJ;

		public float SFXMixerVolumeLow;

		public float VoiceMixerVolumeLow;

		public float NonCoachVolumeLow;

		[SerializeField]
		private MicrophoneInputDetector microphoneInputDetector;

		[SerializeField]
		private SFXAudioSource sfx3DAudioSourcePrefab;

		[SerializeField]
		private SFXAudioSource sfx2DAudioSourcePrefab;

		[SerializeField]
		private AudioSource ambientAudioSource;

		[SerializeField]
		private AudioSource musicAudioSource;

		[SerializeField]
		private AudioRolloff default3DSFXRolloff;

		public RecRoomAudioClip ToolFavoriteSkinAudio;

		public RecRoomAudioClip ToolLockedAudio;

		public RecRoomAudioClip ToolUnLockedAudio;

		public RecRoomAudioClip ToolConsumableSpawnedAudio;

		public Dictionary<NOMDJBMGHMJ, AudioMixerGroup> VOIPFilterAudioMixerGroups;

		public static EEANDDJEMJC MusicStartStopEvent;

		private static int EKPFFLNCIKA;

		private static int EAADGNNOOLA;

		private bool HOCFFNMCCJJ;

		private OGPEGJKGBEE PHHEGDAFFNC;

		private global::MKJNCDLHHNA<RecRoomAudioClip> JNINPPLFFEJ;

		private global::MKJNCDLHHNA<AudioRolloff> GFNLOIGLIHL;

		private NCIMIGIHJDN FNOIHALCJCM;

		private FIHGBEHGLGB HMLBLAONHIP;

		private LKGILLBEJEK JADHIAMMPDH;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private OODBKEOANFB NDLPCLDABJH;

		private readonly List<(string, PDAIIFPEFAG)> JMOENAFPHNM;

		private const string MJFBIILKBAJ = "Ambience";

		private const string CILPIPMMGCO = "Music";

		private const string MDDBPAODJDG = "Sounds";

		private const string IHEGHFIMPNL = "Voice";

		private static readonly Dictionary<string, MIBJNNKFLND> OOLOLJFBBMG;

		private static readonly float AKPCNGPBNGL;

		private const string JHCNOLCFEAC = "MUSIC_VOLUME_PERCENT_PREF";

		private float FCPDKILOOKC;

		private float OILGBHKOIJF;

		private float EMHLJMPJDLH;

		private float DECIHBHKBAA;

		private IDisposable KEELFLBNJAH;

		private const string AGOMIMBNPJK = "AMBIENCE_VOLUME_PERCENT_PREF";

		private float GNLLLHKBFAK;

		private float FJIGFPBICJE;

		private float JIDPNEDGDFJ;

		private float HKALFAKOAGF;

		private const string MMBCNONCEMC = "VOICE_VOLUME_PERCENT_PREF";

		private float JMMDFAEMACD;

		private float CHPIHEBNBLP;

		private float ONGDGJFANFD;

		private global::BANDHPLOOPI<float> MBCHJOCNKOJ;

		private const string CFHMMDAHKGL = "SFX_VOLUME_PERCENT_PREF";

		private float ADLLCPGJJMO;

		private bool HHOACOMGNJH;

		private float HJIKMACEMHM;

		private float NEGMKEPDGHO;

		private float HDKDABLCABF;

		private float KGHOBOKHJJB;

		private float HMCPEGPAOFA;

		private float FHHJLFEOMIA;

		private float IGJGGCNADHN;

		private float OHPNKFIIMIH;

		private float MCBBHMNMOKH;

		private float? ODJHFKFMNJA;

		public NEBBJIMOIIO MicSpamMonitor;

public int CurrentlyPlayingSFXAudioSourceCount
{
get 		{
			return 0;
		}

}

public AudioMixer MasterMixer
{
get 		{
			return null;
		}

}

public AnimationCurve DefaultRolloffCurve
{
get 		{
			return null;
		}

}

public static OGPEGJKGBEE MusicMixer
{
get 		{
			return null;
		}

}

public float MusicVolumePercentage
{
get 		{
			return 0f;
		}

set {
		}
}

public float AmbienceVolumePercentage
{
get 		{
			return 0f;
		}

set {
		}
}

public float VoiceVolumePercentage
{
get 		{
			return 0f;
		}

}

public bool VoiceVolumeOverridden
{
get 		{
			return false;
		}

}

public float SfxVolumePercentage
{
get 		{
			return 0f;
		}

set {
		}
}

public float LocalMicTransmissionVolumeMultiplier
{
get 		{
			return 0f;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void SetVoiceVolumePercentage(float ONBBIIAKPFC)
		{
		}

		public void OverrideVoiceVolumePercentage(float ONBBIIAKPFC, object IALNODEHBNN, int LAGADKBKLAD = int.MaxValue)
		{
		}

		public void RemoveVoiceVolumePercentageOverride(object IALNODEHBNN)
		{
		}

		private void GEPAHLFJLHF(float ENOPMDPDIGJ)
		{
		}

		public void Initialize()
		{
		}

		private void NJLABJMKAFE()
		{
		}

		public IEnumerator<EGGPGCCKPCO> RunChangeAudioVolume(AudioSource JCNDDPGMCDL, float PGGPDMLNFLP, float FKGDJKOLCNN, float FGBPJMKCMAO)
		{
			return null;
		}

		public void SetSourceToVOIPMixer(AudioSource GLLFHCCFIGK, NOMDJBMGHMJ HNGJGPJCNBJ)
		{
		}

		private void HKDMGJAOKCD()
		{
		}

		private void MJOIKMGJEEK(string NODOEAALBFO, float COFONCKAJCK, string FLLCBBBBJOE = null)
		{
		}

		private void CNPAFBPDMDJ()
		{
		}

		private void OBMNHDKMEAD()
		{
		}

		private float EOGEMPNDHKF(float COFONCKAJCK, float EEDMBMIEFIA)
		{
			return 0f;
		}

		private AudioMixerGroup NJAKEPCGJCE(NOMDJBMGHMJ HNGJGPJCNBJ)
		{
			return null;
		}

		public AudioMixerGroup GetAudioMixerGroupByChannel(HHOIEGJNNEC LAEAGAJDAFO)
		{
			return null;
		}

		public AudioMixerGroup GetAudioMixerGroupByChannelAndSubChannel(PDAIIFPEFAG IMHIOOKAHPC)
		{
			return null;
		}

		public Dictionary<string, MIBJNNKFLND> GetAudioChannelConfigurationOptions()
		{
			return null;
		}

		public IList<(string, PDAIIFPEFAG)> GetAudioChannelAndSubChannelOptions()
		{
			return null;
		}

		private static void GLEIOLNNIJM(IList<(string, PDAIIFPEFAG)> JAAGBDPDCIE, HHOIEGJNNEC LAEAGAJDAFO, DNAEDILGHHA GPDMEKDINAH)
		{
		}

		public JKHCJAJHGAO DetectMicrophoneInput(Recorder GGLNKPFPBCB)
		{
			return null;
		}

		private void PNNLIHOKFCJ()
		{
		}

		public static void Mute(object IALNODEHBNN)
		{
		}

		public static void Unmute(object IALNODEHBNN)
		{
		}

		public static void SetMute(object IALNODEHBNN, bool FPNALMLOHHH)
		{
		}

		public static void SetVolumeMultiplier(object IALNODEHBNN, float COFONCKAJCK)
		{
		}

		public static void RemoveVolumeMultiplier(object IALNODEHBNN)
		{
		}

		public static void Add3DSFXRolloff(AudioRolloff EOFMABJLPAB, object IALNODEHBNN)
		{
		}

		public static void Remove3DSFXRolloff(object IALNODEHBNN)
		{
		}

		public static SFXAudioSource PlaySFX(RecRoomAudioClip DLLECDOAMDE, Transform EHFFICIAODF = null, AudioRolloff ENIEACGHHDC = null, Action<SFXAudioSource> JLEAAAFEOJN = null)
		{
			return null;
		}

		public static SFXAudioSource PlaySFX(AudioClip DLLECDOAMDE, Transform EHFFICIAODF = null, AudioRolloff ENIEACGHHDC = null, Action<SFXAudioSource> JLEAAAFEOJN = null)
		{
			return null;
		}

		public static SFXAudioSource Play2DSFX(RecRoomAudioClip DLLECDOAMDE, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource Play2DSFX(AudioClip DLLECDOAMDE, float COFONCKAJCK)
		{
			return null;
		}

		public static SFXAudioSource Play2DSFX(AudioClip DLLECDOAMDE, Action<SFXAudioSource> JLEAAAFEOJN = null)
		{
			return null;
		}

		public static SFXAudioSource Play2DSFX(AudioClip DLLECDOAMDE, Vector3 PDFEDMAOMNH, float COFONCKAJCK = 1f, float EOBDFMAAGOG = 0f, float HGLGKIJHMBG = 0f, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource Play2DSFX(RecRoomAudioClip DLLECDOAMDE, float COFONCKAJCK, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource Play3DSFX(RecRoomAudioClip DLLECDOAMDE, Vector3 PDFEDMAOMNH, AudioRolloff OGHABJFFBOB = null, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource Play3DSFX(RecRoomAudioClip DLLECDOAMDE, Vector3 PDFEDMAOMNH, bool MKBGHFKCHHO, AudioRolloff OGHABJFFBOB = null, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource Play3DSFX(RecRoomAudioClip OAAADBMOMNE, Transform EHFFICIAODF, AudioRolloff OGHABJFFBOB = null, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource Play3DSFX(AudioClip DLLECDOAMDE, Vector3 PDFEDMAOMNH, float COFONCKAJCK = 1f, float EOBDFMAAGOG = 0f, float HGLGKIJHMBG = 0f, bool MKBGHFKCHHO = false, AudioRolloff OGHABJFFBOB = null, float MJHCPDDFHJH = 1f, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource Play3DSFX(AudioClip DLLECDOAMDE, Transform EHFFICIAODF, float COFONCKAJCK = 1f, float EOBDFMAAGOG = 0f, float HGLGKIJHMBG = 0f, AudioRolloff OGHABJFFBOB = null, float MJHCPDDFHJH = 1f, Action<SFXAudioSource> JLEAAAFEOJN = null)
		{
			return null;
		}

		public static SFXAudioSource PlayRandom2DSFX(RecRoomAudioClip[] CADPONIDLFD, bool EIEJDGDJAAM = false, float MJHCPDDFHJH = 1f, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource PlayRandom3DSFX(RecRoomAudioClip[] CADPONIDLFD, Vector3 PDFEDMAOMNH, AudioRolloff OGHABJFFBOB = null, bool EIEJDGDJAAM = false, float BJPOFCOMKDH = 1f, Action<SFXAudioSource> JLEAAAFEOJN = null)
		{
			return null;
		}

		public static SFXAudioSource PlayRandom3DSFX(RecRoomAudioClip[] CADPONIDLFD, Transform EHFFICIAODF, AudioRolloff OGHABJFFBOB = null, bool EIEJDGDJAAM = false, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource StartLooping3DSFX(RecRoomAudioClip DLLECDOAMDE, Transform EHFFICIAODF, AudioRolloff OGHABJFFBOB = null, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		public static SFXAudioSource StartLooping3DSFX(RecRoomAudioClip DLLECDOAMDE, Vector3 PDFEDMAOMNH, AudioRolloff OGHABJFFBOB = null, Action<SFXAudioSource> JLEAAAFEOJN = null)
		{
			return null;
		}

		public static SFXAudioSource StartLooping2DSFX(RecRoomAudioClip DLLECDOAMDE, Action<SFXAudioSource> JLEAAAFEOJN = null)
		{
			return null;
		}

		public static void StopLoopingSFX(SFXAudioSource PLIJJENJJOP)
		{
		}

		public static void AddAmbientAudio(RecRoomAudioClip MJAJDCDHLKJ, object IALNODEHBNN)
		{
		}

		public static void RemoveAmbientAudio(object IALNODEHBNN)
		{
		}

		public static void PlayAmbientAudio()
		{
		}

		public static void StopAmbientAudio()
		{
		}

		private static void AEEHPELOKCG()
		{
		}

		public static void PlayMusic(RecRoomAudioClip MHNDMEJNOLH, float HDGFHFCPNPD, bool KNMILELNMFH, float? JJJKOMLIIFE = null)
		{
		}

		public static void StopMusic()
		{
		}

		public static AudioClip CurrentMusicAudioClip()
		{
			return null;
		}

		public static bool IsPlayingMusic()
		{
			return false;
		}

		public static float GetMusicTime()
		{
			return 0f;
		}

		public static LKGILLBEJEK FadeMusic(float HOMCFGHFNFF, float FGBPJMKCMAO)
		{
			return null;
		}

		public static LKGILLBEJEK FadeSFX(SFXAudioSource PLIJJENJJOP, float HOMCFGHFNFF, float FGBPJMKCMAO)
		{
			return null;
		}

		public static void ConfigureAudioSource(AudioSource GLLFHCCFIGK, AudioClip DLLECDOAMDE, HHOIEGJNNEC LAEAGAJDAFO, LPDDNINEKAP BPNMJOGGMFC, float ONJEDBFDBNP, float COFONCKAJCK, float KMNHJLOHLGC, float JEBCOJDMMPO)
		{
		}

		public static void ChangeChannel(AudioSource GLLFHCCFIGK, HHOIEGJNNEC LAEAGAJDAFO)
		{
		}

		public static void ChangeChannel(AudioMixer GLLFHCCFIGK, HHOIEGJNNEC LAEAGAJDAFO)
		{
		}

		public static void ChangeSfxType(AudioSource GLLFHCCFIGK, LPDDNINEKAP PLCOIGCJCEF)
		{
		}

		public static void ChangeAudioType(AudioSource GLLFHCCFIGK, LPDDNINEKAP PLCOIGCJCEF)
		{
		}

		public static void ChangeAudioPriority(AudioSource GLLFHCCFIGK, HHOIEGJNNEC LAEAGAJDAFO)
		{
		}

		public static void ChangeAudioPriority(AudioSource GLLFHCCFIGK, ANEPFKDNBGP LAGADKBKLAD = ANEPFKDNBGP.Default)
		{
		}

		public static void ChangeVolume(AudioSource GLLFHCCFIGK, float COFONCKAJCK)
		{
		}

		public static void SetStartPosition(AudioSource GLLFHCCFIGK, float ONJEDBFDBNP, float KMNHJLOHLGC, float JEBCOJDMMPO)
		{
		}

		public static bool ReachedEndPosition(AudioSource GLLFHCCFIGK, float KMNHJLOHLGC, float JEBCOJDMMPO)
		{
			return false;
		}

		public static void ChangePitch(AudioSource GLLFHCCFIGK, float CFOKOLCIDIC)
		{
		}

		private static SFXAudioSource JAFBMDONINP(LPDDNINEKAP NIFOGEBEDNG, AudioClip DLLECDOAMDE, Vector3 PDFEDMAOMNH, float COFONCKAJCK, float EOBDFMAAGOG, float HGLGKIJHMBG, bool MKBGHFKCHHO, AudioRolloff OGHABJFFBOB = null, Action<SFXAudioSource> JLEAAAFEOJN = null, PDAIIFPEFAG? LAEAGAJDAFO = null)
		{
			return null;
		}

		private static int ICILAEDNOFG(int DLEJLKOCKAN, int NENKJONBEPB, bool EIEJDGDJAAM)
		{
			return 0;
		}

		public static Task Play3DSFXAsync(AssetReference NFNALNAHEMC, SFXAudioSource.JAIOLKMHIGA GBGDOBKHAFC, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public static Task Play3DSFXAsync(AudioClip DLLECDOAMDE, SFXAudioSource.JAIOLKMHIGA GBGDOBKHAFC, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public static Task Play2DSFXAsync(AssetReference NFNALNAHEMC, SFXAudioSource.JAIOLKMHIGA GBGDOBKHAFC, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public static Task Play2DSFXAsync(AudioClip DLLECDOAMDE, SFXAudioSource.JAIOLKMHIGA GBGDOBKHAFC, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private static Task BOEAOPECICD(LPDDNINEKAP NIFOGEBEDNG, AssetReference NFNALNAHEMC, SFXAudioSource.JAIOLKMHIGA GBGDOBKHAFC, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private static Task BOEAOPECICD(LPDDNINEKAP NIFOGEBEDNG, AudioClip DLLECDOAMDE, SFXAudioSource.JAIOLKMHIGA GBGDOBKHAFC, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public static void SetAudioRolloff(AudioSource PLIJJENJJOP)
		{
		}

		internal void GBAMFGMGAGP(RecRoomAudioMixerRegistry MEGPPAHMIGP)
		{
		}
	}
}
