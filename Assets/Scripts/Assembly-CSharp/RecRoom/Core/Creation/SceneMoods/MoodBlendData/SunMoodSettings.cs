using System;
using UnityEngine;

namespace RecRoom.Core.Creation.SceneMoods.MoodBlendData
{
	[Serializable]
	public class SunMoodSettings : MoodBlendData<SunMoodSettings>
	{
		private const float DEFAULT_SUN_CLIP_OFFSET = 0.03f;

		private static bool globalsInitilized;

		private const string sunDirShaderPropertyName = "_SunDir";

		private static int sunDirShaderId;

		private const string sunColorShaderPropertyName = "_SunColor";

		private static int sunColorShaderId;

		private const string discSizeShaderPropertyName = "_DiscSize";

		private static int discSizeShaderId;

		private const string sunGlowColorShaderPropertyName = "_GlowColor";

		private static int sunGlowColorShaderId;

		private const string sunGlowSizeShaderPropertyName = "_SunGlowSize";

		private static int sunGlowSizeShaderId;

		private const string sunGlowStrengthShaderPropertyName = "_GlowStrength";

		private static int sunGlowStrengthShaderId;

		private const string sunGlowHorizonShaderPropertyName = "_GlowHorizon";

		private static int sunGlowHorizonShaderId;

		private const string sunClipOffsetShaderPropertyName = "_SunClipOffset";

		private static int sunClipOffsetShaderId;

		public Color sunColor;

		public float sunIntensity;

		public float discSize;

		public Quaternion sunDirection;

		public float shadowStrength;

		public float reflectionIntensity;

		public Color sunGlowColor;

		public float sunGlowSize;

		public float sunGlowStrength;

		public float sunGlowHorizon;

		public bool clipSun;

		private static Quaternion studioStartSunDirection;

		private static Color studioStartSunColor;

		public bool BlendSunDirection { get; set; }

		public static void HNGHNAHGNCD()
		{
		}

		public void PJGLMGKPNKP(Material MLMOLKMGEPP)
		{
		}

		public override void CMLCAEKNDEO(SunMoodSettings PMNFADKEJAH, float EGIHMOEGBHH)
		{
		}

		public override void KFIHMLODGME()
		{
		}
	}
}
