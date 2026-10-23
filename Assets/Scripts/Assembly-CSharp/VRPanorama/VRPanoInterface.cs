using UnityEngine;
using UnityEngine.UI;

namespace VRPanorama
{
	public class VRPanoInterface : MonoBehaviour
	{
		public float progressInd;

		public string timeCounterText;

		public Image texLoader;

		public Text timeCounter;

		public int width;

		public int height;

		public Camera PanoramaCam;

		public GameObject hQCam;

		public bool rt;

		public bool mono;

		public bool sbs;

		public GameObject quadR;

		public GameObject quadL;

		public GameObject hQPlane;

		public bool hQ;

		public int step;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
