using System;
using RecRoom.Avatars.Outfit;
using UnityEngine;

namespace RecRoom.Avatars.Data.Editor
{
	[Serializable]
	public class EditorAvatarItemCombination : IEquatable<EditorAvatarItemCombination>, ISerializationCallbackReceiver
	{
		public string name;

		[SerializeField]
		private EditorAvatarOutfitPrefabReference editorOutfitPrefabReference;

		[HideInInspector]
		[SerializeField]
		private OutfitPrefab outfitPrefabReference;

		public AvatarItemMaterial ItemMaterial;

		[Obsolete]
		public EditorAvatarOutfitPrefabReference EditorOutfitPrefabReference => null;

		[Obsolete]
		public OutfitPrefab LegacyOutfitPrefabReference => null;

		public OutfitPrefab OutfitPrefab
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Equals(EditorAvatarItemCombination HNPEBINPOBO)
		{
			return false;
		}

		public override bool Equals(object ICHBECDKHOJ)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
