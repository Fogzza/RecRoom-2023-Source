using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RecRoom.Audio
{
	[Serializable]
	public class SFXTracklistRuntimeConfig : ScriptableObject
	{
		private sealed class MLIOOFALNDL
		{
			public int i;

			internal global::IDEIBFFIHHC<System.Guid>.PMJFLPOGIBH _003Cget_GuidMap_003Eb__0(RuntimeAddressableSFXTrack track)
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				return default;
			}
		}

		private static SFXTracklistRuntimeConfig runtimeConfigAsset;

		private global::IDEIBFFIHHC<Guid> guidMap;

		[SerializeField]
		private List<RuntimeAddressableSFXTrack> trackList;

		public static SFXTracklistRuntimeConfig RuntimeConfigAsset => null;

		public global::IDEIBFFIHHC<Guid> GuidMap => null;

		public IReadOnlyList<RuntimeAddressableSFXTrack> TrackList => null;

		public global::EHOCIICLNGN<AudioClip> LLBEMFIKOMC(Guid NEKNDACCLHG)
		{
			return null;
		}

		private global::EHOCIICLNGN<AudioClip> LLBEMFIKOMC(AssetReference NFNALNAHEMC)
		{
			return null;
		}
	}
}
