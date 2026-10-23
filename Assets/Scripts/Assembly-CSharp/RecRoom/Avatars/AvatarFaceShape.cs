using UnityEngine;

namespace RecRoom.Avatars
{
	public class AvatarFaceShape : ScriptableObject
	{
		[HideInInspector]
		[SerializeField]
		public string guidString;

		public string FriendlyName;

		[SerializeField]
		private Sprite menuButtonSprite;

		public AvatarFaceShapeData[] map;

		public string Guid => null;

		public Sprite MenuButtonSprite => null;
	}
}
