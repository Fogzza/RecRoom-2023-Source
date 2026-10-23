using UnityEngine;

namespace RecRoom.Core.Creation.Holotars
{
	[FBAOLELDODL]
	public class HolotarDataOverride : MonoBehaviour
	{
		[SerializeField]
		private TextAsset[] resourceAssets;

		[SerializeField]
		private bool billboardPlayback;

		[SerializeField]
		private HolotarCV1 holotar;

		[SerializeField]
		private Tool tool;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void MasterPickRandomAsset()
		{
		}
	}
}
