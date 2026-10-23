using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Core.Creation.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class AudioRecorderImpl : MonoBehaviour, EAGGEJMPGHG
	{
		private sealed class IHGLJAODHNA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AudioRecorderImpl _003C_003E4__this;

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
			public IHGLJAODHNA(int _003C_003E1__state)
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

		protected AudioRecorder ILHINBMJFNO;

		[SerializeField]
		protected float MaxAudioDuration;

		[SerializeField]
		protected Button recordButton;

		[SerializeField]
		protected Button previewButton;

		[SerializeField]
		protected Button clearButton;

		[SerializeField]
		protected Button stopRecButton;

		[SerializeField]
		protected Button stopPlayButton;

		[SerializeField]
		protected Button saveData;

		[SerializeField]
		protected ProgressBar recordingProgress;

		[SerializeField]
		protected TMP_Text MicMessage;

		[SerializeField]
		protected GameObject timer;

		[SerializeField]
		protected TMP_Text timerText;

		[SerializeField]
		protected InputFieldRangeSlider rangeSlider;

		[SerializeField]
		protected TMP_InputField startOffsetInput;

		[SerializeField]
		protected TMP_InputField endOffsetInput;

		[SerializeField]
		protected Waveform waveform;

		private const string BJFJBJHDKJK = "TURN MIC ON TO RECORD!";

		private const string NFHHMGIMHDK = "PRESS SAVE TO KEEP CHANGES!\nTrimmed portion will be lost";

		private const string FLINDIOAAED = "PRESS SAVE TO UPLOAD RECORDING!\nTrimmed portion will be lost";

		private const string ACDGHLKKFNC = "Uploading Sample!";

		private const string CICAOFODFPE = "SAMPLE UPLOADED!";

		private bool OEMLHACNBHF;

		private Coroutine CEOCOGLGEFN;

private bool CBGHBKHDBNP
{
get 		{
			return false;
		}

}

		protected void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void OnDestroy()
		{
		}

		public void InitializeRecorderData(string AIGKNOMENDE, Action<string, float> OFANDJNIKGO)
		{
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

		public void OnOffsetHandleChanged()
		{
		}

		public void OnPreviewButtonPressed()
		{
		}

		public void OnSaveButtonPressed()
		{
		}

		private void JDAOFNOOMFA()
		{
		}

		private void EKMJPLCOGAP()
		{
		}

		private void LKENLHAFKPO()
		{
		}

		private void GDMMBAPLAJH()
		{
		}

		private void CNMCGCLLEFA(bool GMOPMKADHKL)
		{
		}

		private void IJKAGHGELMP()
		{
		}

		private IEnumerator OACJBIHFJHL()
		{
			return null;
		}

		private void CEPLPMBCGDK()
		{
		}

		private void PACBBEIINBM()
		{
		}

		private void FFCBNGLNCOE()
		{
		}

		private void HMFPMFMLOKG()
		{
		}

		private void MCFBKDJCKCC()
		{
		}

		public void OnHide()
		{
		}

		public void DoneEditing()
		{
		}
	}
}
