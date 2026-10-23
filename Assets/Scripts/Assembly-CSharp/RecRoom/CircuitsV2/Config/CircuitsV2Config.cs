using System;
using System.Collections.Generic;
using Circuits.All.RecRoom.Integration.Adapter;
using RecRoom.Audio;
using RecRoom.CircuitsV2.Adapter;
using RecRoom.Core.FastLines;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class CircuitsV2Config : ScriptableObject
	{
		[Serializable]
		public sealed class TypeConfigDictionary : EditableSerializedDictionary<TypeKey, TypeConfig, TypeConfigDictionary.Kvp>
		{
			[Serializable]
			public sealed class Kvp : SerializedKeyVal<TypeKey, TypeConfig>
			{
			}
		}

		[Serializable]
		public sealed class ChipConfigDictionary : EditableSerializedDictionary<NodeVisualizationKey, ChipConfig, ChipConfigDictionary.Kvp>
		{
			[Serializable]
			public sealed class Kvp : SerializedKeyVal<NodeVisualizationKey, ChipConfig>
			{
			}
		}

		[Serializable]
		public sealed class SpecificChipConfigDictionary : EditableSerializedDictionary<SerializedGuid, SpecificChipConfig, SpecificChipConfigDictionary.Kvp>
		{
			[Serializable]
			public sealed class Kvp : SerializedKeyVal<SerializedGuid, SpecificChipConfig>
			{
				[EFEFIKFHIDK]
				[SerializeField]
				public string Name;

				[SerializeField]
				[EFEFIKFHIDK]
				public string ClassName;

				public override void NCDEMEJJJGK()
				{
				}
			}

			private sealed class HDPKNICBPIA
			{
				public Comparer<string> comparer;

				internal int _003Cget_Comparison_003Eb__0(Kvp lhs, Kvp rhs)
				{
					return 0;
				}
			}

			protected override Comparison<Kvp> Comparison => null;

			protected override string JEBHFECOOHJ(Kvp OJLALMPBEAD)
			{
				return null;
			}
		}

		[Serializable]
		public struct ErrorSFXClips
		{
			[SerializeField]
			private RecRoomAudioClip @default;

			[SerializeField]
			private RecRoomAudioClip cpuLimit;

			[SerializeField]
			private RecRoomAudioClip netLimit;

			[SerializeField]
			private RecRoomAudioClip unconfigured;

			[SerializeField]
			private RecRoomAudioClip invalid;

			[SerializeField]
			private RecRoomAudioClip warning;

			public RecRoomAudioClip Default => null;

			public RecRoomAudioClip CpuLimit => null;

			public RecRoomAudioClip NetLimit => null;

			public RecRoomAudioClip Unconfigured => null;

			public RecRoomAudioClip Invalid => null;

			public RecRoomAudioClip Warning => null;
		}

		[SerializeField]
		private Material wireMaterial;

		[SerializeField]
		private float wireWidth;

		[SerializeField]
		private Port port;

		[SerializeField]
		private BusConfigButton boardBusConfigButton;

		[SerializeField]
		private ChipFunctionHeader functionHeader;

		[SerializeField]
		private float portTextZ;

		[SerializeField]
		private float portYSize;

		[SerializeField]
		private float fakePortXAdjustment;

		[SerializeField]
		private float fakePortIconZAdjustment;

		[SerializeField]
		private float fakePortIconScale;

		[SerializeField]
		private float interactableSelfPortXAdjustment;

		[SerializeField]
		private float portGroupYMargin;

		[SerializeField]
		private float portDefaultValueMargin;

		[SerializeField]
		private int portDefaultValueMaxLength;

		[SerializeField]
		private Vector2 innerContextIconTopRightMargin;

		[SerializeField]
		private Vector2 syncIconTopRightMargin;

		[SerializeField]
		private Vector2 eventSenderIconBottomRightMargin;

		[SerializeField]
		private Vector2 customIconTopLeftMargin;

		[SerializeField]
		private float eventReceiverIconLeftMargin;

		[SerializeField]
		private Color eventIconNotRegisteredColor;

		[SerializeField]
		private Color eventIconEmissiveNotRegisteredColor;

		[SerializeField]
		private Color eventIconRegisteredColor;

		[SerializeField]
		private Color eventIconEmissiveRegisteredColor;

		[SerializeField]
		private Sprite syncIconSprite;

		[SerializeField]
		private Sprite cloudIconSprite;

		[SerializeField]
		private Sprite cv2PaletteSprite;

		[SerializeField]
		private Mesh[] valueMeshes;

		[SerializeField]
		private Mesh[] valuePlugMeshes;

		[SerializeField]
		private Mesh[] referenceMeshes;

		[SerializeField]
		private Mesh[] referencePlugMeshes;

		[SerializeField]
		private Mesh[] fakePortMeshes;

		[SerializeField]
		private Mesh[] fakePlugMeshes;

		[SerializeField]
		private Mesh[] defaultValueMeshes;

		[SerializeField]
		private TypeConfigDictionary typeConfigs;

		[SerializeField]
		private TypeConfig undefinedTypeConfig;

		[SerializeField]
		public Color defaultColor;

		[SerializeField]
		private ChipConfigDictionary chipConfigs;

		[SerializeField]
		private ChipConfig undefinedChipConfig;

		[SerializeField]
		private FastLineSettings controlPanelTetherSettings;

		[SerializeField]
		private LimitConfig limits;

		[SerializeField]
		private GameConfig gameConfig;

		[SerializeField]
		private AnalyticsConfig analyticsConfig;

		[SerializeField]
		private SpecificChipConfigDictionary specificChipConfigs;

		[SerializeField]
		private PreviewConfig previewConfig;

		[SerializeField]
		private ErrorSFXClips errorSfx;

		[SerializeField]
		private GlobalHighlightConfig globalHighlightConfig;

		[SerializeField]
		private GlobalChipConfig globalChipConfig;

		public Material WireMaterial => null;

		public float WireWidth => 0f;

		public Port Port => null;

		public BusConfigButton BoardBusConfigButton => null;

		public ChipFunctionHeader FunctionHeader => null;

		public float PortTextZ => 0f;

		public float PortYSize => 0f;

		public float FakePortXAdjustment => 0f;

		public float FakePortIconZAdjustment => 0f;

		public float FakePortIconScale => 0f;

		public float InteractableSelfPortXAdjustment => 0f;

		public float PortGroupYMargin => 0f;

		public float PortDefaultValueMargin => 0f;

		public int PortDefaultValueMaxLength => 0;

		public Vector2 InnerContextIconTopRightMargin => default;

		public Vector2 SyncIconTopRightMargin => default;

		public Vector2 EventSenderIconBottomRightMargin => default;

		public Vector2 CustomIconTopLeftMargin => default;

		public float EventReceiverIconLeftMargin => 0f;

		public Color EventIconNotRegisteredColor => default;

		public Color EventIconEmissiveNotRegisteredColor => default;

		public Color EventIconRegisteredColor => default;

		public Color EventIconEmissiveRegisteredColor => default;

		public Sprite SyncIconSprite => null;

		public Sprite CloudIconSprite => null;

		public Sprite Cv2PaletteSprite => null;

		public IReadOnlyList<Mesh> ValueMeshes => null;

		public IReadOnlyList<Mesh> ValuePlugMeshes => null;

		public IReadOnlyList<Mesh> ReferenceMeshes => null;

		public IReadOnlyList<Mesh> ReferencePlugMeshes => null;

		public IReadOnlyList<Mesh> FakePortMeshes => null;

		public IReadOnlyList<Mesh> FakePlugMeshes => null;

		public IReadOnlyList<Mesh> DefaultValueMeshes => null;

		public IReadOnlyDictionary<TypeKey, TypeConfig> TypeConfigs => null;

		public FastLineSettings ControlPanelTetherSettings => null;

		public LimitConfig Limits => null;

		public GameConfig GameConfig => null;

		public AnalyticsConfig AnalyticsConfig => null;

		public PreviewConfig PreviewConfig => null;

		public ErrorSFXClips ErrorSfx => default;

		public GlobalHighlightConfig GlobalHighlightConfig => null;

		public GlobalChipConfig GlobalChipConfig => null;

		public TypeConfig LPLDDMDJNFO(TypeKey NIFOGEBEDNG)
		{
			return null;
		}

		public ChipConfig NMHNGCNCEGB(NodeVisualizationKey JJMNDCAFBDA)
		{
			return null;
		}

		public bool IDPCHLBOJFK(in Guid JMIFIJDBMNM, out SpecificChipConfig FPJKGKBOAOA)
		{
			FPJKGKBOAOA = null;
			return false;
		}

		public void IHEKMEOIBOI()
		{
		}

		public void DPHICADNPGH()
		{
		}
	}
}
