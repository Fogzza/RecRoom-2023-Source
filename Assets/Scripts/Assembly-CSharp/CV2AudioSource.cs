using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

public class CV2AudioSource : MonoBehaviour
{
	private sealed class LOEMBOEBDPP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CV2AudioSource _003C_003E4__this;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public LOEMBOEBDPP(int _003C_003E1__state)
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

	[StructLayout((LayoutKind)3)]
	private struct NFDAHCCFOFL : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AudioClip> _003C_003Et__builder;

		public CV2AudioSource _003C_003E4__this;

		public float clipVolume;

		public float clipPlaybackSpeedShift;

		public MHLDMCJALLH audioWrapper;

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

	public AudioMixer MasterMixer;

	[SerializeField]
	private AudioSource _audioSource;

	private Transform NFABAIKELNN;

	public Action finishedPlaying;

	private float JFPEBEMJNMG;

	private float GHJJDNLAELC;

	private float MFNDKKBDMOF;

	private float DKBJMHIHPPL;

	private string CBKCEBIBIIF;

	private Coroutine ENOJOIGJMNG;

	private MGDHHGCAICD LBAJJDADBHG;

public Transform FollowTarget
{
get 	{
		return null;
	}

set {
	}
}

public AudioClip audioClip
{
get 	{
		return null;
	}

}

public string AudioId
{
get 	{
		return null;
	}

set {
	}
}

public float ClipVolume
{
get 	{
		return 0f;
	}

}

public float ClipPlaybackSpeedShift
{
get 	{
		return 0f;
	}

}

public AudioSource AudioSource
{
get 	{
		return null;
	}

}

	private void Awake()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public IEnumerator PlayAudioCoroutine()
	{
		return null;
	}

	public void PlayAudio()
	{
	}

	public void PauseAudio()
	{
	}

	public void StopAudio()
	{
	}

	private bool CGPIDJMGJJM()
	{
		return false;
	}

	internal Task<AudioClip> HOLNJPJLNIJ(MHLDMCJALLH LFHJCLPPJMG, float MFNDKKBDMOF, float DKBJMHIHPPL)
	{
		return null;
	}

	internal void OGGCCGAIEKJ(bool KHIKCBMPEGK)
	{
	}

	internal void OFFAOIHDMIH(bool IMBPFGEBEBE)
	{
	}

	internal void AGFKIPAJGKL(HHOIEGJNNEC LAEAGAJDAFO)
	{
	}

	internal void PCIIPLHBGCH(float LLPMKBBEDJN)
	{
	}

	internal bool AFMFFNMPDJK()
	{
		return false;
	}

	internal void BAOOHGDOAAI(float FIMALPLGOOD)
	{
	}

	private void BGMIIIHICDA()
	{
	}

	private void MPJEOFDBGGE()
	{
	}
}
