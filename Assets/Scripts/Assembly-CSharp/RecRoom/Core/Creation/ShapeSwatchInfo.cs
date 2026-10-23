using System;

namespace RecRoom.Core.Creation
{
	[Serializable]
	public class ShapeSwatchInfo
	{
		[Serializable]
		public struct JsonShapeSwatch
		{
			public int c;

			public int m;

			public float u;

			public JsonShapeSwatch(ShapeSwatchInfo FEFIPNEBHPB)
			{
				c = 0;
				m = 0;
				u = 0f;
			}
		}

		[Serializable]
		public struct JsonShapeSwatches
		{
			public JsonShapeSwatch[] s;

			public JsonShapeSwatches(ShapeSwatchInfo[] EEJOJPOAPMB)
			{
				s = null;
			}
		}

		public JLHLKDMLBPK ShapeColorId;

		public MJGMBIJIKFH ShapeMaterialId;

		public float UVScale;

		public static float DefaultUVScale => 0f;

		public ShapeSwatchInfo(JLHLKDMLBPK JGFCLDGKBAO, MJGMBIJIKFH PLHDLMBFDHN, float PALJJNGJNBE)
		{
		}

		public static ShapeSwatchInfo[] MCMOGKFAICA(string EDEOADKJLJK)
		{
			return null;
		}

		public static string GAGIABKBDFD(ShapeSwatchInfo[] EEJOJPOAPMB)
		{
			return null;
		}

		public ShapeSwatchInfo PLNNNEBOBNE()
		{
			return null;
		}

		public bool INPBKODPGAA(ShapeSwatchInfo PCPEJHIMHJJ)
		{
			return false;
		}

		public bool INPBKODPGAA(MJGMBIJIKFH APGHJHBHCFA, JLHLKDMLBPK LNBGDJLPKJM, float PALJJNGJNBE)
		{
			return false;
		}

		public bool AODOJIDBNMP()
		{
			return false;
		}
	}
}
