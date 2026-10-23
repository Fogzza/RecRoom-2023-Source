using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Avatars
{
	public class HairPatternVault : MonoBehaviour
	{
		public string Label;

		public AvatarHairPattern Default;

		[SerializeField]
		protected List<AvatarHairPattern> patterns;

		private readonly Dictionary<string, AvatarHairPattern> DJOCODIOBFN;

public IReadOnlyList<AvatarHairPattern> Patterns
{
get 		{
			return null;
		}

}

		protected virtual void Awake()
		{
		}

		public AvatarHairPattern Find(string KBBOBGAABOC)
		{
			return null;
		}

		public AvatarHairPattern GetRandomDefault()
		{
			return null;
		}

		public AvatarHairPattern GetRandomUnlocked()
		{
			return null;
		}
	}
}
