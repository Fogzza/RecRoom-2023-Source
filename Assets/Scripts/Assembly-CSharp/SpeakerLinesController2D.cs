using System;
using UnityEngine;

public class SpeakerLinesController2D : MonoBehaviour
{
	[Serializable]
	public struct SpeakerLineConfig
	{
		public VoiceLineControl lineControl;

		public MicrophoneToolManager.EIANPLDHJEO speakerLineType;
	}

	[SerializeField]
	private SpeakerLineConfig[] speakerLines;

	[SerializeField]
	private SpeakerLineConfig shoutLines;

	[SerializeField]
	private VoiceLineControl.VoiceLineControlConfig speakerLineConfig;

	[SerializeField]
	private float maxAngleDiff;

	[SerializeField]
	private float offsetAngle;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void DJHMFICGBGM()
	{
	}
}
