using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct RendererMaterialPair
{
	private static readonly int[] EMPTY_IDS;

	[SerializeField]
	private Renderer renderer;

	[SerializeField]
	private int materialIndex;

	[SerializeField]
	private string[] customProperties;

	private int[] propertyIds;

	public IReadOnlyList<int> CustomPropertyIds => null;

	public Material Material => null;

	public Material SharedMaterial => null;
}
