using System;
using System.Collections.Generic;
using RecRoom.Core.FastLines;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class TypeConfig
	{
		[SerializeField]
		private Mesh[] valueMeshOverrides;

		[SerializeField]
		private Mesh[] valuePlugMeshOverrides;

		[SerializeField]
		private Mesh[] referenceMeshOverrides;

		[SerializeField]
		private Mesh[] referencePlugMeshOverrides;

		[SerializeField]
		private Color disconnectedColor;

		[SerializeField]
		private Color disconnectedEmissiveColor;

		[SerializeField]
		private Color connectedColor;

		[SerializeField]
		private Color connectedEmissiveColor;

		[SerializeField]
		private bool isOutputFlipped;

		[SerializeField]
		private FastLineSettings lineSettings;

		[SerializeField]
		private TypeHighlightSettings highlightSettings;

		public IReadOnlyList<Mesh> ValueMeshOverrides => null;

		public IReadOnlyList<Mesh> ValuePlugMeshOverrides => null;

		public IReadOnlyList<Mesh> ReferenceMeshOverrides => null;

		public IReadOnlyList<Mesh> ReferencePlugMeshOverrides => null;

		public Color DisconnectedColor => default;

		public Color DisconnectedEmissiveColor => default;

		public Color ConnectedColor => default;

		public Color ConnectedEmissiveColor => default;

		public bool IsOutputFlipped => false;

		public FastLineSettings LineSettings => null;

		public TypeHighlightSettings HighlightSettings => null;
	}
}
