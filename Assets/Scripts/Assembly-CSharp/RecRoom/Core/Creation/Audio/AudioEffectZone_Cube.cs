using UnityEngine;

namespace RecRoom.Core.Creation.Audio
{
	public class AudioEffectZone_Cube : AudioEffectZoneShape
	{

public override MFHOOFAIEIC Type
{
get 		{
			return MFHOOFAIEIC.Cube;
		}

}

		public override bool InBounds(Vector3 AECDEGDBFHD)
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
