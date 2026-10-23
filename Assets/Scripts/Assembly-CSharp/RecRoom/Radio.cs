using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace RecRoom
{
	public class Radio : MonoBehaviourPun, DJLCHGFCFAD
	{
		private sealed class GOJIGEOGJIN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public Radio _003C_003E4__this;

			private JNDHCGAMLML _003Cschedule_003E5__2;

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
			public GOJIGEOGJIN(int _003C_003E1__state)
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

		public EEANDDJEMJC OnCurrentTrackChanged;

		[SerializeField]
		private AudioSource audioSource;

		[SerializeField]
		private SFXTrack[] tracks;

		[SerializeField]
		private bool pauseDuringGameInProgress;

		[SerializeField]
		private bool randomInitialTrack;

		[SerializeField]
		private int defaultInitialTrack;

		[SerializeField]
		private bool defaultToTrackLoop;

		[SerializeField]
		private TextMeshPro trackTextMesh;

		[SerializeField]
		private Tool _tool;

		private RadioScreen FMMJJPBEBFB;

		private int NHCMMKOEJIB;

		private bool NFHCNHMLNJG;

		private float GCIICMIPPHF;

		private bool ELONIJNMMAA;

		private bool ICBPKFILOPP;

public Tool Tool
{
get 		{
			return null;
		}

}

private RadioScreen GEIPLCPCPFJ
{
get 		{
			return null;
		}

set {
		}
}

private bool NCDPIGEACCH
{
get 		{
			return false;
		}

}

public bool Looping
{
get 		{
			return false;
		}

set {
		}
}

public bool Shuffle
{
get 		{
			return false;
		}

set {
		}
}

private string BMFMCDKBFJJ
{
get 		{
			return null;
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

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Start()
		{
		}

		public void PlayNextTrack()
		{
		}

		public void PlayPreviousTrack()
		{
		}

		public string GetNowPlayingString()
		{
			return null;
		}

		public void OnCircuitInput()
		{
		}

		private void JHFMMOILFHF(ushort KPONEIMIAMD, ushort LDJONJEEOBK, ushort JJDONGLNIFG, ushort OOLLFFPGBAC)
		{
		}

		private void LHCDMEIAGPC()
		{
		}

		public void TogglePause()
		{
		}

		public void SetPause(bool PBAEEBGJNPN)
		{
		}

		private IEnumerator<EGGPGCCKPCO> GFBDBNLFPGB()
		{
			return null;
		}

		private void KJAHDDBFHKE(int MKGEBCOGAKG)
		{
		}

		private void GPBFHHCJOGE(bool AFEAPDGOIBO = false)
		{
		}

		private void OnPhotonPlayerConnected(CHILKDJABBF DEODPCHAFKO)
		{
		}

		[PBOMGCLBFHF]
		private void RpcRadioSyncState(int MKGEBCOGAKG, float BBGNJMKOHPL, bool MCCFPMJFIOI, bool IFPKOHGHENI, bool NFHCNHMLNJG)
		{
		}

		private void HEHDFIOBIHF()
		{
		}

		private void IGLFKGDFMNH(Tool IEGMBEPJMGC)
		{
		}

		private void BGMIIIHICDA()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}
	}
}
