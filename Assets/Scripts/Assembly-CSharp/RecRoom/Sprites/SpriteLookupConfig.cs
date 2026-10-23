using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Sprites
{
	public class SpriteLookupConfig : ScriptableObject
	{
		[EFEFIKFHIDK]
		[SerializeField]
		private Texture legacySourceTexture;

		[EFEFIKFHIDK]
		[SerializeField]
		private Object sourceAsset;

		[EFEFIKFHIDK]
		[SerializeField]
		private List<Sprite> sprites;

		public Object SourceAsset => null;

		public IReadOnlyList<Sprite> Sprites => null;
	}
}
