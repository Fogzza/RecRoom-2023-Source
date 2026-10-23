using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MicrophoneToolManager : SingletonMonoBehaviour<MicrophoneToolManager>
{
	public enum EIANPLDHJEO
	{
		OFF = 0,
		LEVEL_1 = 1,
		LEVEL_2 = 2,
		LEVEL_3 = 3,
		LEVEL_4 = 4
	}

	[Serializable]
	public struct SpeakerLineLevelThreshold
	{
		public EIANPLDHJEO lineLevel;

		public float volumeThreshold;
	}

	private sealed class NNLEJKBLDCC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MicrophoneToolManager _003C_003E4__this;

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
		public NNLEJKBLDCC(int _003C_003E1__state)
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

	private sealed class FNAPEHPGNBP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float micHitAudioDuration;

		public MicrophoneToolManager _003C_003E4__this;

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
		public FNAPEHPGNBP(int _003C_003E1__state)
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

	private List<Player> BAILIMLNNGP;

	private EIANPLDHJEO GFHKAHPGJBN;

	private EIANPLDHJEO ELCGFJILOHA;

	[SerializeField]
	private SpeakerLineLevelThreshold[] speakerLineLevelThresholds;

	private float GMBEDJNBMNH;

	private Coroutine BPDOEJAKKGJ;

	private Coroutine EPIGALNKDBH;

public EIANPLDHJEO CurrentSpeakerLineLevel
{
get 	{
		return EIANPLDHJEO.OFF;
	}

private set {
	}
}

	protected override void Awake()
	{
	}

	private void Update()
	{
	}

	public void ScheduleDestroy()
	{
	}

	private IEnumerator MKFENIBBIEJ()
	{
		return null;
	}

	public void MicAdded()
	{
	}

	public void OnMicUseEvent(Player EKOFNPFCLMO, bool MAJAGKLGLAD)
	{
	}

	public void OnMicSpeakerLinesEvent(float EAIJOEPLFNJ, EIANPLDHJEO IHHGCGJIFMM)
	{
	}

	private EIANPLDHJEO MFAPJAPKLAC(float COFONCKAJCK)
	{
		return EIANPLDHJEO.OFF;
	}

	private void MKOEBPLPAHL()
	{
	}

	private IEnumerator PLFKIABCOIJ(float NDJHKPDGAFJ)
	{
		return null;
	}
}
