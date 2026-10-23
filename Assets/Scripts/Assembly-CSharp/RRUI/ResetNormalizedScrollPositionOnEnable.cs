using UnityEngine;
using UnityEngine.UI;

namespace RRUI
{
	public class ResetNormalizedScrollPositionOnEnable : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect scrollRect;

		[SerializeField]
		private bool vertical;

		[SerializeField]
		private bool horizontal;

		private void OnEnable()
		{
		}
	}
}
