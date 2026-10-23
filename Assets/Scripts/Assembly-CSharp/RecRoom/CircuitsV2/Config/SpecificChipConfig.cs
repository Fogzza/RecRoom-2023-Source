using System;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class SpecificChipConfig : ScriptableObject, ISerializationCallbackReceiver
	{
		private sealed class MCHNEJGDDFB
		{
			public string[] prefix;

			internal string[] _003CGetFiltersForPrefix_003Eb__0(NodeFilter i)
			{
				return null;
			}
		}

		[EFEFIKFHIDK]
		[SerializeField]
		private string paletteName;

		[EFEFIKFHIDK]
		[SerializeField]
		private string chipName;

		[SerializeField]
		[EFEFIKFHIDK]
		private string className;

		[SerializeField]
		private SerializedGuid nodeId;

		[SerializeField]
		private string description;

		[SerializeField]
		private Sprite icon;

		[SerializeField]
		private bool isBetaChip;

		[SerializeField]
		private bool isHiddenInPalette;

		[SerializeField]
		private bool isDevChip;

		[SerializeField]
		private bool isStudioChip;

		[SerializeField]
		private bool isTrollingRisk;

		[SerializeField]
		private bool isRoleAssignmentRisk;

		[SerializeField]
		private DeprecationStage deprecationStage;

		[SerializeField]
		private NameSourceKind paletteNameSource;

		[SerializeField]
		private NameSourceKind chipNameSource;

		[SerializeField]
		private NodeDescConfig[] nodeDescs;

		[SerializeField]
		private NodeFilter[] filters;

		[SerializeField]
		private bool forceReserialize;

		private static readonly string[] circuitsV2FilterPrefix;

		private static int throughput;

		public string PaletteName => null;

		public string ChipName => null;

		public string ClassName => null;

		public SerializedGuid SerializeNodeId => null;

		public Guid NodeId => default;

		public string Description => null;

		public Sprite Icon => null;

		public bool IsBetaChip => false;

		public bool IsHiddenInPalette => false;

		public bool IsDevChip => false;

		public bool IsStudioChip => false;

		public bool IsTrollingRisk => false;

		public bool IsRoleAssignmentRisk => false;

		public DeprecationStage DeprecationStage => DeprecationStage.Active;

		public NameSourceKind PaletteNameSource => NameSourceKind.FirstNodeDesc;

		public NameSourceKind ChipNameSource => NameSourceKind.FirstNodeDesc;

		public string[][] NCCLBMGCLCE()
		{
			return null;
		}

		private string[][] KJPGNAALCMC(string[] KHCNDENCFFO)
		{
			return null;
		}

		public bool CHIGFEAGFJM(int GMEHLIHLGEH, out NodeDescConfig PCNFGFNPHPE)
		{
			PCNFGFNPHPE = null;
			return false;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
