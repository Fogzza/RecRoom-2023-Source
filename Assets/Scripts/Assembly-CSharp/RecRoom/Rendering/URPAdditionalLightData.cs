using UnityEngine;

namespace RecRoom.Rendering
{
	[DisallowMultipleComponent]
	public class URPAdditionalLightData : MonoBehaviour
	{
		[SerializeField]
		private bool m_UsePipelineSettings;

		[SerializeField]
		private float m_shadowSampleBias;

public bool usePipelineSettings
{
get 		{
			return false;
		}

set {
		}
}

public float shadowSampleBias
{
get 		{
			return 0f;
		}

set {
		}
}
	}
}
