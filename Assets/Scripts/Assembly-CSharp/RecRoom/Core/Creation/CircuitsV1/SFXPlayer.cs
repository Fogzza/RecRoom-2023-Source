using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.CircuitsV2.GraphNodes;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class SFXPlayer : MonoBehaviourPun, GFLPAFBGELM, DJLCHGFCFAD, NEKJJEGPHFG, ISerializationCallbackReceiver
	{
		[Serializable]
		public struct ClipConfig
		{
			public string FriendlyName;

			public RecRoomAudioClip Clip;
		}

		private sealed class LLAALCHDHOI
		{
			public SFXTrack clip;

			internal bool _003COnBeforeSerialize_003Eb__1(RuntimeAddressableSFXTrack t)
			{
				return false;
			}
		}

		[SerializeField]
		[HideInInspector]
		private SFXTrack[] availableSFXClips;

		[HideInInspector]
		[SerializeField]
		private List<RuntimeAddressableSFXTrack> availableSfxTracks;

		public const IALAJKBOKBN DEFAULT_COLLISION_LAYER = IALAJKBOKBN.DynamicPhysicsIgnoreDynamicPhysics;

		private string MMCHLBFLMCH;

		[SerializeField]
		private string use3dAudioSettingDescription;

		[SerializeField]
		private string interruptCurrentSoundDescription;

		[SerializeField]
		private string volumeDescription;

		[SerializeField]
		private string playForAllDescription;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		private float FHCBGGKMJGJ;

		private global::CDLJMENCODC<int> PGLCCCIAINC;

		private global::MOBDJNEDDKC<bool> HEENFFGPCCE;

		private global::MOBDJNEDDKC<bool> KPLHAGBDFKN;

		private global::CDLJMENCODC<int> EEPDKLIDAHI;

		private global::MOBDJNEDDKC<bool> HCPANHCPGJM;

		[SerializeField]
		private RigidbodyEx rigidbodyEx;

		private Task<SFXAudioSource> CJDMDBMGDNA;

		private global::EHOCIICLNGN<AudioClip> CGODMOJJKHM;

		private CancellationTokenSource IHELDNALJPL;

		private Task DCPINFJNGEE;

public IReadOnlyList<RuntimeAddressableSFXTrack> AvailableSFXTracks
{
get 		{
			return null;
		}

}

public int SelectedSFXIndex
{
get 		{
			return 0;
		}

private set {
		}
}

private bool MKMCKGDOEPB
{
get 		{
			return false;
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

public bool InterruptCurrentSound
{
get 		{
			return false;
		}

set {
		}
}

public int VolumeModifier
{
get 		{
			return 0;
		}

set {
		}
}

public bool PlayForAll
{
get 		{
			return false;
		}

set {
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

public CancellationTokenSource PlaySfxCancellationTokenSource
{
get 		{
			return null;
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

		public void CV2SetVolumeModifier(JEGAPHLGBJA GCBHEJANCJK, int IPMIIEAGJKC)
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void EEPJOANCPHB()
		{
		}

		private void Start()
		{
		}

		public bool SFXSpatial_Get()
		{
			return false;
		}

		public void SFXSpatial_Set(bool GJBHOGGEAMA)
		{
		}

		public int SFXIndex_Get()
		{
			return 0;
		}

		public void SFXIndex_Set(int GMEHLIHLGEH)
		{
		}

		public bool SFXInterrupt_Get()
		{
			return false;
		}

		public void SFXInterrupt_Set(bool DMDOLDIPIMF)
		{
		}

		public int Volume_Get()
		{
			return 0;
		}

		public void Volume_Set(int IPMIIEAGJKC)
		{
		}

		public bool PlayForAll_Get()
		{
			return false;
		}

		public void PlayForAll_Set(bool IPMIIEAGJKC)
		{
		}

		[PBOMGCLBFHF]
		private void RpcPlaySelectedSfx()
		{
		}

		public void Event_PlaySelectedSFX()
		{
		}

		[PBOMGCLBFHF]
		private void RpcStop()
		{
		}

		public void Stop()
		{
		}

		private void ENPFNJHMMCL(bool CKAFMGAAAHM = false)
		{
		}

		private void OHHOOIHCBPK(bool CKAFMGAAAHM)
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Play(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Stop(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
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

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		[CompilerGenerated]
		private bool FOGOOMCELPF()
		{
			return false;
		}
	}
}
