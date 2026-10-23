using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RecRoom.Core.Creation.Audio;
using UnityEngine;

public class UGCAudioTrackManager : SingletonMonoBehaviour<UGCAudioTrackManager>
{
	private sealed class EAPHJHPNJNE
	{
		public UGCAudioTrackManager _003C_003E4__this;

		public string blobName;

		internal void _003CGetBlobData_003Eb__0(DDKGJCDICCB b)
		{
		}
	}

	private sealed class EJELCCIBCIN
	{
		public UGCAudioTrackManager _003C_003E4__this;

		public string blobName;

		public DDKGJCDICCB DataBlob;

		internal global::NCOKFFGPIJM<DDKGJCDICCB> _003CTryGetBlobData_003Eb__0(EKJDFEMBJGH.GOAHNLAOBJK b)
		{
			return null;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct FBKOIACKKFB : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public bool preload;

		public UGCAudioTrackManager _003C_003E4__this;

		public string audioId;

		public float sampleLength;

		public string audioName;

		private TaskAwaiter<MHLDMCJALLH> _003C_003Eu__1;

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
	private struct MOBJLLFOMKF : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<MHLDMCJALLH> _003C_003Et__builder;

		public string audioId;

		public float sampleLength;

		public string audioName;

		public bool alwaysKeep;

		private JNLIEHHDBDM _003CaudioWrapper_003E5__2;

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

	[SerializeField]
	private CV2AudioSource cv2AudioSourcePrefab;

	[SerializeField]
	private AudioRecorder audioRecorder;

	private const int IAMAOGAELEB = 900;

	public global::PCKOBNFDEOF<string, MHLDMCJALLH> loadedSampleAudioTracks;

	private global::PFCCOJONNHA<string, DDKGJCDICCB> IIBJLBOFJIJ;

	private static int EOKLHGGFPKC(MHLDMCJALLH LFHJCLPPJMG)
	{
		return 0;
	}

	public global::NCOKFFGPIJM<DDKGJCDICCB> GetBlobData(string AIGKNOMENDE)
	{
		return null;
	}

	public MHLDMCJALLH GetCV2AudioSample(string AIGKNOMENDE, float MHGGMDKJNLA, string OGDHBHIPPMA)
	{
		return null;
	}

	public MHLDMCJALLH GetCV2AudioSFX(Guid JMIFIJDBMNM)
	{
		return null;
	}

	private global::NCOKFFGPIJM<DDKGJCDICCB> GCPDKOBDKPE(string AIGKNOMENDE)
	{
		return null;
	}

	public CV2AudioSource GetAudioSource()
	{
		return null;
	}

	public void ReleaseAudioSource(CV2AudioSource PLIJJENJJOP)
	{
	}

	public Task<bool> OnPreloadSampleChanged(string CBINKECHJFB, float MHGGMDKJNLA, string OGDHBHIPPMA, bool NLHJEOIDFEF)
	{
		return null;
	}

	public Task<MHLDMCJALLH> LoadAudioSample(string CBINKECHJFB, float MHGGMDKJNLA, string OGDHBHIPPMA, bool MACLHFIEECK = false)
	{
		return null;
	}

	public void UnloadAudioSample(string CBINKECHJFB)
	{
	}

	public bool CanPreloadAudioSample(string CBINKECHJFB, float MHGGMDKJNLA, string OGDHBHIPPMA)
	{
		return false;
	}

	public AudioRecorder GetAudioRecorder()
	{
		return null;
	}
}
