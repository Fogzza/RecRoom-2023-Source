using UnityEngine;

namespace RecRoom
{
	public class AutoAdjustHeight : MonoBehaviour
	{
		[SerializeField]
		private float minYOffset;

		[SerializeField]
		private float maxYOffset;

		[SerializeField]
		private float baseHeight;

		[SerializeField]
		private Interpolator interpolator;

		private bool PODEOBPGBAD;

		private void Update()
		{
		}
	}
}
