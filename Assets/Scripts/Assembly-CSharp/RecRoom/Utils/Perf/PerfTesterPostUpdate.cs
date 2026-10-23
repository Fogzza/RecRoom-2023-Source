using UnityEngine;

namespace RecRoom.Utils.Perf
{
	public class PerfTesterPostUpdate : MonoBehaviour
	{
		[SerializeField]
		private PerfTesterPreUpdate preUpdate;

		[SerializeField]
		private int captureFrameCount;

		private void Update()
		{
		}
	}
}
