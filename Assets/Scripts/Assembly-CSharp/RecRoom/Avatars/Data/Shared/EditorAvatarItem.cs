using RecRoom.Avatars.Outfit;
using UnityEngine;

namespace RecRoom.Avatars.Data.Shared
{
	public class EditorAvatarItem : ScriptableObject
	{
		public string Name;

		[SerializeField]
		private OutfitPrefab _outfitPrefab;

		public AvatarItemData AvatarItemData;

		public AvatarItemMaterial[] AvatarItemMaterials;

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
	}
}
