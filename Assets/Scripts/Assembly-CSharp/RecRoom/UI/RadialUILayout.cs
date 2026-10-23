using UnityEngine;

namespace RecRoom.UI
{
	public class RadialUILayout : MonoBehaviour
	{
		[SerializeField]
		private RectTransform[] children;

		[SerializeField]
		private float startArcAngle;

		[SerializeField]
		private float endArcAngle;

		[SerializeField]
		private bool closedArc;

		[SerializeField]
		private float radius;

		[SerializeField]
		private bool rotateChildren;

		[SerializeField]
		private bool childElementsShouldCounterRotateContents;

		public void OnValidate()
		{
		}

		public void ApplyLayout(int JAHCFCKMOBK = int.MaxValue)
		{
		}
	}
}
