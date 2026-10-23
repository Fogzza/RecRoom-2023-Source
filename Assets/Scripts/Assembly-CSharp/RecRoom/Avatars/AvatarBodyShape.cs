using UnityEngine;

namespace RecRoom.Avatars
{
	public class AvatarBodyShape : ScriptableObject
	{
		[HideInInspector]
		[SerializeField]
		public string guidString;

		public string FriendlyName;

		[SerializeField]
		private Sprite menuButtonSprite;

		public AvatarBodyShapeData[] map;

		public string Guid => null;

		public Sprite MenuButtonSprite => null;
	}
}
