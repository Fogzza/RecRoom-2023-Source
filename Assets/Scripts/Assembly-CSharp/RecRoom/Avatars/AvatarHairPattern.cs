using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Avatars
{
	[Serializable]
	public class AvatarHairPattern : ScriptableObject, IEquatable<AvatarHairPattern>
	{
		public string friendlyName;

		[HideInInspector]
		[SerializeField]
		public string guidString;

		public Texture2D texture;

		[SerializeField]
		private Sprite menuButtonSprite;

		public Sprite MenuButtonSprite => null;

		public bool Unlocked { get; set; }

		public EOKBGGOAFLF PurchasableGiftDrop { get; set; }

		public override bool Equals(object ICHBECDKHOJ)
		{
			return false;
		}

		public bool Equals(AvatarHairPattern HNPEBINPOBO)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		[SpecialName]
		public static bool BHBKJCPJNJN(AvatarHairPattern BLFKABPCHLN, AvatarHairPattern NPFMAENOPCH)
		{
			return false;
		}

		[SpecialName]
		public static bool IGOCGGBJBII(AvatarHairPattern BLFKABPCHLN, AvatarHairPattern NPFMAENOPCH)
		{
			return false;
		}
	}
}
