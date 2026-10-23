using UnityEngine;

namespace RecRoom.Core.Creation.Audio
{
	public abstract class AudioEffectZoneShape : MonoBehaviour
	{
		public enum MFHOOFAIEIC
		{
			Cube = 0,
			Sphere = 1
		}

		[SerializeField]
		protected AudioEffectZone audioEffectZone;

public abstract MFHOOFAIEIC Type
{
get ;
}

		public abstract bool InBounds(Vector3 AECDEGDBFHD);
	}
}
