using System;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom
{
	public class SFXTrack : ScriptableObject
	{
		public enum HNEPMEHHPBE
		{
			SFX = 0,
			Music = 1,
			Ambience = 2
		}

		[SerializeField]
		private string friendlyName;

		[SerializeField]
		private HNEPMEHHPBE clipType;

		[SerializeField]
		private SerializedGuid guid;

		[EFEFIKFHIDK]
		[SerializeField]
		private AudioClip clip;

		public string FriendlyName => null;

		public HNEPMEHHPBE ClipType => HNEPMEHHPBE.SFX;

		public Guid Guid => default;

		public AudioClip Clip => null;
	}
}
