using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Video;

namespace RecRoom.Core.Creation.Videos
{
	public class RemoteVideoPlayer : MonoBehaviourPun, DJLCHGFCFAD, GFLPAFBGELM, NEKJJEGPHFG, PJINIJOHANN
	{
		private sealed class KHALAALDCPE : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RemoteVideoPlayer _003C_003E4__this;

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
			public KHALAALDCPE(int _003C_003E1__state)
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

		private sealed class OALEOCMBPCE
		{
			public RemoteVideoPlayer _003C_003E4__this;

			public string newVideoUrl;

			internal void _003COnVideoUrlChanged_003Eb__0(string resolvedUrl)
			{
			}
		}

		private const string MEBODIKHJBG = "Video.MaxVideoDesyncSeconds";

		private const float BHILLDNCGCN = 3f;

		private const string MFOMKMDNHEL = "Video.IOSSeekCooldownSeconds";

		private const float FMKHOCHICCA = 2f;

		private const bool JOKFAMCNBLB = false;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private VideoPlayer videoPlayer;

		[SerializeField]
		private AudioSource audioSource;

		[SerializeField]
		protected SyncedComponentV2 syncComponent;

		[SerializeField]
		private GameObject screen;

		[SerializeField]
		private int settingsPriority;

		private PPIBEEFCLFK LGPHHMHMDMC;

		private OFLODDBBNLD PHPAOIONLNN;

		private global::CDLJMENCODC<string> JCNAFFPJDLI;

		private IILDCCEMGBA PFGCMJCEEMA;

		private MGDHHGCAICD LBAJJDADBHG;

		private float? JAAFJFMIOLB;

		private float? CMOKOBBMAMF;

		private Coroutine NLGDFDNFNCI;

		private float GDBHHMGJOAL;

		private bool COHOEGIELID;

public PPIBEEFCLFK PlaybackControls
{
get 		{
			return null;
		}

private set {
		}
}

public OFLODDBBNLD AudioPlayback
{
get 		{
			return null;
		}

private set {
		}
}

public string VideoUrl
{
get 		{
			return null;
		}

}

private bool CCMGDINDJPD
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

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		private void GGFANHCLFJG()
		{
		}

		private void AOHOPKHANAP()
		{
		}

		private void FPHOINFPPJK()
		{
		}

		private void JDBAIOMCFDG()
		{
		}

		private IEnumerator EPONLIHAPML()
		{
			return null;
		}

		private void BNHJAFPFCIH()
		{
		}

		private void IEPLGGGGMEI()
		{
		}

		private void AADKCJDKPJC()
		{
		}

		private void OBEPIADMOEI()
		{
		}

		private void NGNKKBJLFCE()
		{
		}

		private void BJBDIPJBHGO()
		{
		}

		private void NEMFHMGOPEG()
		{
		}

		private float OMPOAEBGAFO()
		{
			return 0f;
		}

		private float MBIPDLKDOHK()
		{
			return 0f;
		}

		protected override void OnDestroy()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetVideoUrl(JEGAPHLGBJA GCBHEJANCJK, string PEDLJMJDBPA)
		{
			return default;
		}

		public global::FAIKNKAIPLB<OHAJOLBEFND> Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public void SetSynchronizing(bool BLOCPPAOJDM)
		{
		}

		[CompilerGenerated]
		private string NFMMIPFGCLD()
		{
			return null;
		}

		[CompilerGenerated]
		private void HOHPNCDEOAB(string IPMIIEAGJKC)
		{
		}
	}
}
