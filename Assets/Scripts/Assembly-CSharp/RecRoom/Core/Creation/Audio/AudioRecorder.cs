using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Core.Creation.Audio
{
	public class AudioRecorder : MonoBehaviour
	{
		private sealed class ENNDAKMIMFC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AudioRecorder _003C_003E4__this;

			public float startOffset;

			public float endOffset;

			private int _003Cstart_003E5__2;

			private int _003Cend_003E5__3;

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
			public ENNDAKMIMFC(int _003C_003E1__state)
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

		private sealed class KLLCGLJEMDA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AudioRecorder _003C_003E4__this;

			public int duration;

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
			public KLLCGLJEMDA(int _003C_003E1__state)
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

		[SerializeField]
		protected MicAudioRecorder micAudioRecorder;

		[SerializeField]
		protected AudioSource audioSource;

		[SerializeField]
		protected float MaxAudioDuration;

		private int LIJGJGIGLOD;

		private float DDKCONDPEJF;

		private const int IKPBFNPABIH = -1;

		internal MDEJADHJOEJ KLOLMMOJNHJ;

		private readonly GKJKDACBMLG NNMPIIKEMEB;

		private DDKGJCDICCB JDOPGAIICCL;

		public Action<string, float> OnSampleDataChangedEvent;

		public Action OnAnyStateChangedEvent;

		public Action OnBlobDataUploaded;

		public Action UIChangeInvoke;

		public Action OnRecorderSampleUpdated;

		public Action OnStartLocalRecording;

		public Action<bool> PreviewChangeEvent;

		private Coroutine GINLAFKKMKE;

		private Coroutine ONELLDGKOHD;

		protected DDKGJCDICCB IHNIPCOJINH;

		private float COOCLFABLPH;

		private float GENPLLHJIGB;

		private float MLBCGCAJLDF;

		private string CPHKGFKEJEF;

		private bool FFPOJKDKJPA;

		private bool PHBPPDDABCC;

private DDKGJCDICCB FJBMPFHBEBO
{
get 		{
			return null;
		}

set {
		}
}

public bool MicAvailable
{
get 		{
			return false;
		}

}

public bool HasData
{
get 		{
			return false;
		}

}

public float ClipLength
{
get 		{
			return 0f;
		}

}

public float StartOffsetSeconds
{
get 		{
			return 0f;
		}

set {
		}
}

public float EndOffsetSeconds
{
get 		{
			return 0f;
		}

set {
		}
}

public string CurrentBlobName
{
get 		{
			return null;
		}

set {
		}
}

internal EONFCPODAAO NGGIEBACIHB
{
get 		{
			return EONFCPODAAO.IDLE;
		}

}

internal DDIAKHLOAAL OOMJPPOLKNM
{
get 		{
			return DDIAKHLOAAL.DATA;
		}

}

internal AJOKOGFKPNE LHPHIGBPMGA
{
get 		{
			return AJOKOGFKPNE.COUNTDOWN;
		}

}

internal HNLCONOJMHB EOHKIGHGONE
{
get 		{
			return HNLCONOJMHB.ACTIVE;
		}

}

internal bool ACAELAPAEMJ
{
get 		{
			return false;
		}

set {
		}
}

internal bool LKFDMBJCHGO
{
get 		{
			return false;
		}

set {
		}
}

private bool NEMDEFFNDFG
{
get 		{
			return false;
		}

}

private bool LENOOFCGCHP
{
get 		{
			return false;
		}

}

private bool FJKEJMGPMIJ
{
get 		{
			return false;
		}

}

private bool ONFMCNNNLPA
{
get 		{
			return false;
		}

}

private bool BIDMCMNFENB
{
get 		{
			return false;
		}

}

private float OKIKKDFHHIJ
{
get 		{
			return 0f;
		}

}

		protected void Awake()
		{
		}

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		public void InitializeRecorderUI()
		{
		}

		public void InitializeRecorderData(string AIGKNOMENDE, Action<string, float> OFANDJNIKGO)
		{
		}

		private void KHCLBMBFPLC(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		private void GADGNIGOFND(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void PBECKAIBLPA(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		private void GCAHCGFHLHC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void DFDANMMLNKC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MFGNNGOPDNM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void ECEHOMGKOGP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void LFMPBECOMEP()
		{
		}

		private void FAHGOGGDHEA()
		{
		}

		private void GMGPONDHGFA()
		{
		}

		private void DPOJMHIAPNI(float KMNHJLOHLGC, float JEBCOJDMMPO)
		{
		}

		private void IBHOBCLDKHO()
		{
		}

		private IEnumerator GBBHGBFINCH(float KMNHJLOHLGC, float JEBCOJDMMPO)
		{
			return null;
		}

		private void NALNMPJBAJN()
		{
		}

		private void BFKFAMDOIPA()
		{
		}

		private void CIFBDCEFOHN()
		{
		}

		private void BMIMKNGBFOO()
		{
		}

		private void MFMAEHFCDHL(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		private void BBBDOCKAMAK(ushort ANAKIMJNHMH, ushort KJLHJFEJJGM)
		{
		}

		public void TryFinishRecording()
		{
		}

		private void IAKMFHGOONG()
		{
		}

		private void LLNFKHHNLLJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private IEnumerator IMANHGIEFLA(int FGBPJMKCMAO)
		{
			return null;
		}

		public int GetTimer()
		{
			return 0;
		}

		public void TryStartRecording()
		{
		}

		private void IABHHFKCGJO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected void PBKHIGPABCP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void JBGMNNKCHGC()
		{
		}

		private void HAAACFCNGJJ(out global::NCOKFFGPIJM<LDCCJDCBBPA> DPGHLBJJLJP)
		{
			DPGHLBJJLJP = null;
		}

		private void FNPPLBALDJL()
		{
		}

		private void DNBBAAJCLHK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void MDAKLHLDCEO()
		{
		}

		private void JNNMOKMPBKP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void COIOHLNPLBI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void POCPDPLFEDJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void MCMPDHGFPEH()
		{
		}

		private DDKGJCDICCB NJCEGKLCIHO()
		{
			return null;
		}

		private void OILOHHLKKKL()
		{
		}

		public float GetProgress()
		{
			return 0f;
		}

		public void OnRecordButtonPressed()
		{
		}

		public void OnStopRecButtonPressed()
		{
		}

		public void OnStopPlayButtonPressed()
		{
		}

		public void OnDeleteButtonPressed()
		{
		}

		public void OnOffsetHandleChanged(float KMNHJLOHLGC, float JEBCOJDMMPO)
		{
		}

		public void OnPreviewButtonPressed(float KMNHJLOHLGC, float JEBCOJDMMPO)
		{
		}

		public void OnSaveButtonPressed(float ECICJMAPIMI, float BOGNGIGCFCH)
		{
		}

		private void HKLCLAPNICE()
		{
		}

		private void FDILJNJKEMH()
		{
		}

		private void JDAOFNOOMFA(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		private void IKMPEBNLDEB(DDKGJCDICCB PCPEJHIMHJJ = null)
		{
		}

		public AudioClip DangerouslyGetPreloadedAudioClip()
		{
			return null;
		}

		private void BLLMFEPDPML(float DJNOOBMNBFK, float LHFPANIHENE)
		{
		}

		private bool DFBEABIELNN()
		{
			return false;
		}

		private int KKDJPAMMGDF(float BGGBEMDBOHE)
		{
			return 0;
		}

		private bool CGPIDJMGJJM(int EBEICGFALNG, int OGINPOLMPBC)
		{
			return false;
		}

		public void OnHide()
		{
		}

		public void DoneEditing()
		{
		}

		private void IHBPDENALIJ()
		{
		}

		private void NBDKFDNMLEB()
		{
		}

		[CompilerGenerated]
		private void FMANFAEBOPI(DDKGJCDICCB NEJDDAMJBFJ)
		{
		}

		[CompilerGenerated]
		private void HBFKMAJIBII(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void EOOMMIFEDKA(LDCCJDCBBPA MMEDLDHCDLP)
		{
		}

		[CompilerGenerated]
		private void AMILAHKKCCN()
		{
		}

		[CompilerGenerated]
		private void CMCHJBAHFBP(LDCCJDCBBPA PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private void GPFKPANJJNI(string AIGKNOMENDE)
		{
		}

		[CompilerGenerated]
		private void IEJDIIOBNPH()
		{
		}
	}
}
