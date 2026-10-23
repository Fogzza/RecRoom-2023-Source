using System;
using UnityEngine;

namespace RecRoom.Core.Rendering
{
	[Serializable]
	public class FogSettings
	{
		public enum BLNCGPLGMJN
		{
			Never = 0,
			AsNeeded = 1,
			Always = 2
		}

		[SerializeField]
		private bool fog;

		[SerializeField]
		private FogMode fogMode;

		[SerializeField]
		private Color fogColor;

		[SerializeField]
		private float fogStartDistance;

		[SerializeField]
		private float fogEndDistance;

		[SerializeField]
		private float fogDensity;

		[SerializeField]
		private BLNCGPLGMJN fogClippingBehavior;

		private static FogSettings defaultSceneSettings;

		private static Color initialClearColor;

		private static float initialFarClip;

		private static CameraClearFlags initialClearFlags;

		public void MAHLEKHKDGC()
		{
		}

		public void EIPJIMFJMJH()
		{
		}

		public static void BGGJNIAGIPH()
		{
		}

		public static void PKCFNDNKGFN()
		{
		}
	}
}
