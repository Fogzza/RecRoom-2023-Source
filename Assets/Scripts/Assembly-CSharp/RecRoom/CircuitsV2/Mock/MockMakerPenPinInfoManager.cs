using RecRoom.Tools.MakerPenTools;
using UnityEngine;

namespace RecRoom.CircuitsV2.Mock
{
	[ExecuteInEditMode]
	public sealed class MockMakerPenPinInfoManager : MonoBehaviour
	{
		[SerializeField]
		private CV2MakerPenPinInfo pinInfo;

		[SerializeField]
		private Chip chip;

		[SerializeField]
		private Camera sceneCamera;

		private Port IGDMJKJCMFD;

		public void Bind()
		{
		}

		public void Unbind()
		{
		}

		public void Update()
		{
		}
	}
}
