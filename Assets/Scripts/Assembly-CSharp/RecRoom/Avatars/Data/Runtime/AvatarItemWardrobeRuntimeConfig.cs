using System;
using System.Collections.Generic;
using RecRoom.Avatars.Data.Shared;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RecRoom.Avatars.Data.Runtime
{
	[Serializable]
	public class AvatarItemWardrobeRuntimeConfig : ScriptableObject
	{
		[Serializable]
		public class GuidReferenceArrayDictionary : SerializedDictionary<string, AssetReference[], GuidReferenceArrayDictionary.KeyVal>
		{
			[Serializable]
			public class KeyVal : SerializedKeyVal<string, AssetReference[]>
			{
			}
		}

		[Serializable]
		public class GuidReferenceDictionary : SerializedDictionary<string, AssetReference, GuidReferenceDictionary.KeyVal>
		{
			[Serializable]
			public class KeyVal : SerializedKeyVal<string, AssetReference>
			{
			}
		}

		[Serializable]
		public class GuidAvatarDataDictionary : SerializedDictionary<string, AvatarItemData, GuidAvatarDataDictionary.KeyVal>
		{
			[Serializable]
			public class KeyVal : SerializedKeyVal<string, AvatarItemData>
			{
			}
		}

		[Serializable]
		private class GuidMaterialDictionary : SerializedDictionary<string, string, GuidMaterialDictionary.KeyVal>
		{
			[Serializable]
			public class KeyVal : SerializedKeyVal<string, string>
			{
			}
		}

		private sealed class BBLOHHMLJOE
		{
			public Player.NBPIPAJOGLC bodyPart;

			internal bool _003CGetDefaultUnknownAvatarItemSelection_003Eb__0(AvatarItemSelection item)
			{
				return false;
			}
		}

		[NonSerialized]
		private static AvatarItemWardrobeRuntimeConfig _config;

		[SerializeField]
		private GuidReferenceArrayDictionary materialGuidToAssetRefArray;

		[SerializeField]
		private GuidAvatarDataDictionary avatarItemDataLookup;

		[SerializeField]
		private GuidReferenceDictionary avatarItemPrefabLookup;

		[SerializeField]
		private GuidReferenceDictionary combinationLookup;

		[SerializeField]
		private List<AvatarItemSelection> teamAvatarItemSelections;

		[SerializeField]
		private List<AvatarItemSelection> teamEmissiveAvatarItemSelections;

		[SerializeField]
		private List<AvatarItemSelection> defaultUnknownAvatarItemSelections;

		private List<string> defaultUnknownAvatarItemGuids;

		[SerializeField]
		private AvatarItemSelection defaultHelmetHairItemSelection;

		[SerializeField]
		private List<AvatarItemSelection> helmetHairItemSelections;

		[SerializeField]
		private List<AvatarItem> defaultUnlockedAvatarItems;

		[SerializeField]
		private List<AvatarItem> initialAvatarItems;

		[SerializeField]
		private List<AvatarItem> defaultTorsoAvatarItems;

		[SerializeField]
		private List<AvatarItem> defaultLegsAvatarItems;

		[SerializeField]
		private List<AvatarItem> defaultShoesAvatarItems;

		[SerializeField]
		private List<AvatarItem> allPossibleCombinations;

		public static AvatarItemWardrobeRuntimeConfig Config => null;

		public IReadOnlyList<AvatarItemSelection> TeamAvatarItemSelections => null;

		public IReadOnlyList<AvatarItemSelection> TeamEmissiveAvatarItemSelections => null;

		public IReadOnlyList<AvatarItemSelection> DefaultUnknownAvatarItemSelections => null;

		public IReadOnlyList<string> DefaultUnknownAvatarItemGuids => null;

		public AvatarItemSelection DefaultHelmetHairItem => default;

		public IReadOnlyList<AvatarItemSelection> HelmetHairItemSelections => null;

		public IReadOnlyList<AvatarItem> DefaultUnlockedAvatarItems => null;

		public IReadOnlyList<AvatarItem> InitialAvatarItems => null;

		public IReadOnlyList<AvatarItem> DefaultTorsoAvatarItems => null;

		public IReadOnlyList<AvatarItem> DefaultFullBodyTorsoAvatarItems => null;

		public IReadOnlyList<AvatarItem> DefaultLegsAvatarItems => null;

		public IReadOnlyList<AvatarItem> DefaultShoesAvatarItems => null;

		public IReadOnlyList<AvatarItem> AllPossibleCombinations => null;

		public AssetReference[] MGDPFHOOEAD(AvatarItemVisualData ONCGIPFNENB)
		{
			return null;
		}

		public AvatarItemData BPLKPMAHBAJ(string JMIFIJDBMNM)
		{
			return null;
		}

		public AssetReference EDPKGEGGCBD(string JMIFIJDBMNM)
		{
			return null;
		}

		public AssetReference MHAGMLLHENO(string JMIFIJDBMNM)
		{
			return null;
		}

		public AvatarItemSelection FDKBCCMBIDC(Player.NBPIPAJOGLC MKLOBAIKINA = Player.NBPIPAJOGLC.None)
		{
			return default;
		}
	}
}
