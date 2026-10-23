using UnityEngine;

namespace RecRoom.Core.Creation.Preview
{
	public class PreviewComponent : MonoBehaviour
	{
		public virtual Bounds CalculateWorldBounds()
		{
			return default;
		}
	}
}
