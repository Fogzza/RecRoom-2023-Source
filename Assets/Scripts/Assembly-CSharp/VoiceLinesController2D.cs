using System;
using Photon.Pun;
using UnityEngine;

public class VoiceLinesController2D : MonoBehaviourPun
{
	[Serializable]
	public struct VoiceLineConfig
	{
		public VoiceLineControl lineControl;

		public float threshold;
	}

	public Player thisPlayer;

	[SerializeField]
	private Transform voiceLinesAnchor;

	[SerializeField]
	private VoiceLineConfig[] voiceLines;

	[SerializeField]
	private VoiceLineConfig shoutConfig;

	[SerializeField]
	private VoiceLineControl.VoiceLineControlConfig voiceLineConfig;

	[SerializeField]
	private float minVisualizationDistance;

	[SerializeField]
	private float maxVisualizationDistance;

	[SerializeField]
	private float maxAngleDiff;

	[SerializeField]
	private float offsetAngle;

	private JNKNMMDAHCF DHCLACKALOF;

public Transform VoiceLinesAnchor
{
get 	{
		return null;
	}

}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	protected void OnDrawGizmosSelected()
	{
	}

	private void Update()
	{
	}
}
