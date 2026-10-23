using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class AudioPlayer : MonoBehaviourPun, GFLPAFBGELM, DJLCHGFCFAD, NEKJJEGPHFG, PJINIJOHANN, GAAKCFPLMHN
	{
		[StructLayout((LayoutKind)3)]
		private struct EMMENEKFJKI : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AudioPlayer _003C_003E4__this;

			public MHLDMCJALLH audioWrapper;

			public float clipVolume;

			public float clipPlaybackSpeedShift;

			private TaskAwaiter<AudioClip> _003C_003Eu__1;

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

		private const float DAPGEMNAAPI = 0.5f;

		private const float NHPNNNPEJDP = 1f;

		private const float KGFDOOGEBLE = 60f;

		private const float BDAEGBPDGHP = 2f;

		private const float OPBDGPALLME = 0f;

		private const float IPLAKGOEOEB = 10f;

		private const float OFGBHBMADFE = 0f;

		private const float JMGJLGOEHNC = 1f;

		private CV2AudioSource LCOAOKBNCMK;

		[SerializeField]
		protected SyncedComponentV2 syncComponent;

		public const IALAJKBOKBN DEFAULT_COLLISION_LAYER = IALAJKBOKBN.DynamicPhysicsIgnoreDynamicPhysics;

		[SerializeField]
		private string use3dAudioSettingDescription;

		[SerializeField]
		private string loopAudioSettingDescription;

		[SerializeField]
		private string interruptCurrentSoundDescription;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		private global::CDLJMENCODC<bool> HEENFFGPCCE;

		private global::CDLJMENCODC<bool> OEAANJHOOBN;

		private global::CDLJMENCODC<bool> KPLHAGBDFKN;

		private global::CDLJMENCODC<HHOIEGJNNEC> ABNAANGBJOH;

		private global::CDLJMENCODC<float> EEPDKLIDAHI;

		private global::CDLJMENCODC<float> LNDDNMELALM;

		private global::CDLJMENCODC<float> HPGKLLANEAB;

		private global::CDLJMENCODC<OGJHFKGLLGE> EIDMEKJEKKM;

		private global::CDLJMENCODC<bool> JAFOFGHEEJL;

		private global::CDLJMENCODC<float> PPFNLALPBHE;

		[SerializeField]
		private RigidbodyEx rigidbodyEx;

		private MGDHHGCAICD LBAJJDADBHG;

public string AudioId
{
get 		{
			return null;
		}

}

public float ClipVolume
{
get 		{
			return 0f;
		}

}

public float ClipSpeed
{
get 		{
			return 0f;
		}

}

public bool UseSpatialAudio
{
get 		{
			return false;
		}

set {
		}
}

public bool LoopAudio
{
get 		{
			return false;
		}

set {
		}
}

public bool InterruptCurrentSound
{
get 		{
			return false;
		}

set {
		}
}

public HHOIEGJNNEC AudioChannel
{
get 		{
			return HHOIEGJNNEC.Voice;
		}

set {
		}
}

public float VolumeModifier
{
get 		{
			return 0f;
		}

set {
		}
}

public float SpeedModifier
{
get 		{
			return 0f;
		}

set {
		}
}

public float MaxRolloffDistance
{
get 		{
			return 0f;
		}

set {
		}
}

public OGJHFKGLLGE RolloffCurve
{
get 		{
			return OGJHFKGLLGE.Logarithmic;
		}

set {
		}
}

public bool DopplerEnabled
{
get 		{
			return false;
		}

set {
		}
}

public float PlaybackPosition
{
get 		{
			return 0f;
		}

set {
		}
}

protected float PGFHCNEMNMI
{
get 		{
			return 0f;
		}

set {
		}
}

protected float PJMHPMAPOEH
{
get 		{
			return 0f;
		}

set {
		}
}

protected float CMMKCBAPIMG
{
get 		{
			return 0f;
		}

set {
		}
}

protected OGJHFKGLLGE FHDPHMCOJLL
{
get 		{
			return OGJHFKGLLGE.Logarithmic;
		}

set {
		}
}

protected bool ABMPKHBLIHP
{
get 		{
			return false;
		}

set {
		}
}

public bool IsPlaying
{
get 		{
			return false;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
		}

}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetVolumeModifier(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetSpeedModifier(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetMaxRolloffDistance(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetTimeStamp(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void GFOCMFGOFNC(bool BLOCPPAOJDM)
		{
		}

		void PJINIJOHANN.SetSynchronizing(bool BLOCPPAOJDM)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GFOCMFGOFNC
			this.GFOCMFGOFNC(BLOCPPAOJDM);
		}

		private void LMLAPKCIDDI()
		{
		}

		void GAAKCFPLMHN.ResetObject()
		{
			//ILSpy generated this explicit interface implementation from .override directive in LMLAPKCIDDI
			this.LMLAPKCIDDI();
		}

		private void NEMGGIMCHCJ()
		{
		}

		private void MGMOGNAPDKF()
		{
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> FFPBPAAHHKH(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		private void PIPMEIAEHPK()
		{
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> BAOOHGDOAAI(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		private void LGKHLADDMJB()
		{
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> PADDAMJIAFN(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		private void LHKEEGNNDJN()
		{
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> FFMGDGILDDF(JEGAPHLGBJA GCBHEJANCJK, float IPMIIEAGJKC)
		{
			return default;
		}

		private void HLLIABBEIAC()
		{
		}

		private void EAKFPOOKBPD()
		{
		}

		private void ABPAHLBMGMP()
		{
		}

		private void FBBIDEAMGPB()
		{
		}

		private void NBEOOJFJACA()
		{
		}

		public bool AudioSpatial_Get()
		{
			return false;
		}

		public void AudioSpatial_Set(bool GJBHOGGEAMA)
		{
		}

		public bool LoopAudio_Get()
		{
			return false;
		}

		public void LoopAudio_Set(bool KNMILELNMFH)
		{
		}

		public bool AudioInterrupt_Get()
		{
			return false;
		}

		public void AudioInterrupt_Set(bool DMDOLDIPIMF)
		{
		}

		public void AudioChannel_Set(int DLEMNBPMGBG)
		{
		}

		public int AudioChannel_Get()
		{
			return 0;
		}

		public float PlaybackPosition_Get()
		{
			return 0f;
		}

		public void PlaybackPosition_Set(float INLGLHIPOMC)
		{
		}

		[PBOMGCLBFHF]
		private void RpcInvokeOnChangePlaybackPosition()
		{
		}

		[PBOMGCLBFHF]
		private void RpcPlaySample(string AIGKNOMENDE, float AAMPPPKCFEH, string OGDHBHIPPMA)
		{
		}

		[PBOMGCLBFHF]
		private void RpcPlaySFX(Guid JMIFIJDBMNM, float COFONCKAJCK, float GNDCFGOIDDP)
		{
		}

		[PBOMGCLBFHF]
		private void RpcStop()
		{
		}

		public void Stop()
		{
		}

		[PBOMGCLBFHF]
		private void RpcPause()
		{
		}

		public void Pause()
		{
		}

		private void NLGCAHNKAFN(MHLDMCJALLH LFHJCLPPJMG, float MFNDKKBDMOF, float DKBJMHIHPPL)
		{
		}

		private void CHCOIKCNOND(string AIGKNOMENDE, float AAMPPPKCFEH, string OGDHBHIPPMA)
		{
		}

		private void JAFBMDONINP(Guid JMIFIJDBMNM, float COFONCKAJCK, float GNDCFGOIDDP)
		{
		}

		private void HIEFKPOJFJD(MHLDMCJALLH LFHJCLPPJMG, float MFNDKKBDMOF, float DKBJMHIHPPL)
		{
		}

		private void PLKJFOICIGE()
		{
		}

		public float GetTimeStamp()
		{
			return 0f;
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		protected void OnPhotonPlayerConnected(CHILKDJABBF DEODPCHAFKO)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2PlayAudio(JEGAPHLGBJA GCBHEJANCJK, COHEJBHFAKE LFHJCLPPJMG)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Stop(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Pause(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		private void DJELDJJBINK()
		{
		}

		private void FINCPJOJOPD()
		{
		}

		private global::FAIKNKAIPLB<OHAJOLBEFND> DCBNIOPDHIN(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		global::FAIKNKAIPLB<OHAJOLBEFND> GFLPAFBGELM.Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DCBNIOPDHIN
			return this.DCBNIOPDHIN(GCBHEJANCJK);
		}

		[CompilerGenerated]
		private float KCEKOPGDIMN()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void JDHBLNCBCAB(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool OAGGOAHCPPG()
		{
			return false;
		}

		[CompilerGenerated]
		private float PADLILDHCDM()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void IDGOOJMPFMO(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool JBAKGDGDLLC()
		{
			return false;
		}

		[CompilerGenerated]
		private float NNLNMHGDJFK()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void GFAIGNIOAAC(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool AEGKJLNBHEI()
		{
			return false;
		}

		[CompilerGenerated]
		private OGJHFKGLLGE FKBEAGOAPBN()
		{
			return OGJHFKGLLGE.Logarithmic;
		}

		[CompilerGenerated]
		private void JCLHAAHDICP(OGJHFKGLLGE MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool DMEINCGNCPD()
		{
			return false;
		}

		[CompilerGenerated]
		private void GCMPAJGJBHA(bool MLIPDLAHDHI)
		{
		}
	}
}
