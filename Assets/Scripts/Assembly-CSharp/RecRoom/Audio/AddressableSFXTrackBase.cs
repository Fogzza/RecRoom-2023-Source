using System;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Audio
{
	[Serializable]
	public abstract class AddressableSFXTrackBase : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		protected string friendlyName;

		[SerializeField]
		protected SerializedGuid guid;

		[SerializeField]
		protected SFXTrack.HNEPMEHHPBE trackType;

		public string FriendlyName => null;

		public Guid Guid => default;

		public abstract float ClipLengthSeconds { get; }

		public SFXTrack.HNEPMEHHPBE TrackType => SFXTrack.HNEPMEHHPBE.SFX;

		protected void CICIFAGPOHD(string CEEBKJJBEMB, SFXTrack.HNEPMEHHPBE LMIEGIDJFIN, Guid JMIFIJDBMNM)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
