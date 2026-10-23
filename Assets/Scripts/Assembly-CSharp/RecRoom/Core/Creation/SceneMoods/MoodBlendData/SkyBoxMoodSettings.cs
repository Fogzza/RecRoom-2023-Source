using System;
using UnityEngine;

namespace RecRoom.Core.Creation.SceneMoods.MoodBlendData
{
	[Serializable]
	public class SkyBoxMoodSettings : MoodBlendData<SkyBoxMoodSettings>
	{
		private static bool globalsInitilized;

		private const string skyBottomColorShaderPropertyName = "_SkyBottom";

		private static int skyBottomColorShaderId;

		private const string skyTopColorShaderPropertyName = "_SkyTop";

		private static int skyTopColorShaderId;

		private const string groundBottomColorShaderPropertyName = "_GroundBottom";

		private static int groundBottomColorShaderId;

		private const string groundTopColorShaderPropertyName = "_GroundTop";

		private static int groundTopColorShaderId;

		private const string horizonColorShaderPropertyName = "_HorizonColor";

		private static int horizonColorShaderId;

		private const string horizonSizeShaderPropertyName = "_HorizonSize";

		private static int horizonSizeShaderId;

		private const string horizonStrengthShaderPropertyName = "_HorizonStrength";

		private static int horizonStrengthShaderId;

		public Color skyTopColor;

		public Color skyBottomColor;

		public Color groundTopColor;

		public Color groundBottomColor;

		public Color horizonColor;

		public float horizonSize;

		public float horizonStrength;

		public float ambientLightIntensity;

		public static void HNGHNAHGNCD()
		{
		}

		public void PJGLMGKPNKP(Material MLMOLKMGEPP)
		{
		}

		public override void CMLCAEKNDEO(SkyBoxMoodSettings PMNFADKEJAH, float EGIHMOEGBHH)
		{
		}

		public override void KFIHMLODGME()
		{
		}
	}
}
