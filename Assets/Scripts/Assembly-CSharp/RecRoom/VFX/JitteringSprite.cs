using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace RecRoom.VFX
{
	[Serializable]
	public class JitteringSprite
	{
		public Renderer renderer;

		public bool applyToOnlyOneRendererMaterial;

		public int rendererMaterialIndex;

		public Sprite sprite;

		public int jitterFPS;

		public Vector2 maxJitterOffset;

		public Vector2 maxJitterScale;

		public NPGKGKMPDGD offsetMode;

		public float phaseOffset;

		private float lastJitterPhase;

		private Vector2 jitterOffset;

		private Vector3 jitterScale;

		private static int mainTexId;

		private static int scaleOffsetId;

		private static int srcBlendId;

		private static int destBlendId;

		private int srcBlend;

		private int destBlend;

		public bool UseOneMaterialMode => false;

		public MaterialPropertyBlock MaterialProperties { get; private set; }

		public void FKIHAHEHJMK(BlendMode NCLIDGLFPDM, BlendMode KDNMJDLECIF)
		{
		}

		public void HGOJONOKPIJ(Sprite MHMBHPJEMGB = null)
		{
		}

		private void OBIEHEFGHEM(Vector2 MOHMCFDNHKH, Vector2 JDFDFBKKBPO)
		{
		}

		private void MBNBNOEBIOM(Vector2 MOHMCFDNHKH, Vector2 JDFDFBKKBPO)
		{
		}
	}
}
