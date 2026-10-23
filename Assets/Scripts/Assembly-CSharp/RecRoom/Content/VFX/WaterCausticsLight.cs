using UnityEngine;

namespace RecRoom.Content.VFX
{
	[ExecuteInEditMode]
	public class WaterCausticsLight : MonoBehaviour
	{
		[SerializeField]
		private Texture alphaMap;

		[SerializeField]
		private Texture displacementNormals;

		[SerializeField]
		private RenderTexture cookie;

		[SerializeField]
		private Shader causticsShader;

		[SerializeField]
		private float distortAmount;

		[SerializeField]
		private Vector2 alphaSpeed;

		[SerializeField]
		private Vector2 distortSpeed;

		private Vector4 MDDHLMNOMPI;

		[SerializeField]
		private float causticsAmount;

		[SerializeField]
		private bool useHeightBlend;

		[SerializeField]
		private float heightBlendStart;

		[SerializeField]
		private Color heightBlendStartLightColor;

		[SerializeField]
		private float heightBlendEnd;

		[SerializeField]
		private Color heightBlendEndLightColor;

		private Material NDJKHGGNEEI;

		private static readonly int PIBPHPFLDMP;

		private static readonly int MJLIBKCMNIE;

		private static readonly int DHLFNLAIGHG;

		private static readonly int HACIGFOKELE;

		private Light CFCILDMOBMN;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
