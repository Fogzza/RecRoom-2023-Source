using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class GlassPaneShape : MonoBehaviour
	{
		public enum BHKGCPHCMLL
		{
			Cube = 0,
			Sphere = 1
		}

		[SerializeField]
		private BHKGCPHCMLL shape;

public BHKGCPHCMLL Type
{
get 		{
			return BHKGCPHCMLL.Cube;
		}

}
	}
}
