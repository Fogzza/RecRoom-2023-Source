using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core
{
	public class CameraIgnoreBubble : MonoBehaviour
	{
		public static readonly List<CameraIgnoreBubble> AllBubbles;

		[SerializeField]
		private Camera _camera;

		private List<Camera> CEGMDKCFAEH;

		[SerializeField]
		private bool supportsIgnoringLocalPlayer;

		[SerializeField]
		private float radius;

		[SerializeField]
		private float fadeStartDistance;

		[SerializeField]
		private float fadeCompleteDistance;

		[SerializeField]
		private float minAlpha;

public Camera Camera
{
get 		{
			return null;
		}

}

public List<Camera> CameraList
{
get 		{
			return null;
		}

}

public bool SupportsIgnoringLocalPlayer
{
get 		{
			return false;
		}

}

public float Radius
{
get 		{
			return 0f;
		}

}

public float RadiusSqr
{
get 		{
			return 0f;
		}

}

public float FadeStartDistance
{
get 		{
			return 0f;
		}

}

public float FadeCompleteDistance
{
get 		{
			return 0f;
		}

}

public float MinAlpha
{
get 		{
			return 0f;
		}

}

public bool IsActive
{
get 		{
			return false;
		}

}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
