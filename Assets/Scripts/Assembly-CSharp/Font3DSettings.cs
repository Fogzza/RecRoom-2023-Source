using System;
using UnityEngine;

public class Font3DSettings : ScriptableObject
{
	[Serializable]
	public class GlyphInfo
	{
		public char Character;

		public Vector3 ScaleModifier;

		public GameObject[] PrefabLODs;

		[HideInInspector]
		public Vector3 MeshExtents;
	}

	[Serializable]
	private class RendererToGlyphLODSettings
	{
		public CCONJEHGIDD MinMemoryTier;

		public int[] RendererToGlyphLODMapping;
	}

	[SerializeField]
	private char startAsciiIndex;

	[SerializeField]
	private char endAsciiIndex;

	[SerializeField]
	private GameObject fontPrefab;

	[SerializeField]
	private Vector3 baseRotation;

	[SerializeField]
	private float baseThickness;

	[SerializeField]
	private int lodLevels;

	[SerializeField]
	private RendererToGlyphLODSettings[] rendererToGlyphLodSettings;

	[SerializeField]
	private GlyphInfo[] Glyphs;

	public bool DFMBIIJNBBD(char DHNNLHJMKIH, int EMMLNOGJBFM, out Mesh AAKOJGEOGGC, out Vector3 DDPIGAEGHEA, out Quaternion OLJLIHCNADH, out Vector3 PDPPIGLJABM)
	{
		AAKOJGEOGGC = null;
		DDPIGAEGHEA = default;
		OLJLIHCNADH = default;
		PDPPIGLJABM = default;
		return false;
	}

	public int[] HIPKKILJAOD()
	{
		return null;
	}

	private bool ANAKEHJKAGA(char DHNNLHJMKIH, out GlyphInfo AKOKILEPANJ)
	{
		AKOKILEPANJ = null;
		return false;
	}
}
