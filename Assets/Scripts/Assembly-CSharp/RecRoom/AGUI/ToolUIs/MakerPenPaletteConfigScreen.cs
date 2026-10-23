using System.Collections.Generic;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;

namespace RecRoom.AGUI.ToolUIs
{
	public class MakerPenPaletteConfigScreen : MakerPenPaletteUIFlowBase
	{
		[SerializeField]
		private PagedGrid pagedGrid;

		public CreationObjectSettingBooleanUIControl DefaultBoolUIControlPrefab;

		public CreationObjectSettingStringUIControl DefaultStringUIControlPrefab;

		public CreationObjectSettingIntUIControl DefaultIntUIControlPrefab;

		public CreationObjectSettingIntSliderUIControl DefaultIntSliderUIControlPrefab;

		public CreationObjectSettingFloatUIControl DefaultFloatUIControlPrefab;

		public CreationObjectSettingFriendlyIntControl DefaultEnumUIControlPrefab;

		public CreationObjectSettingFriendlyFlagsControl DefaultFlagsUIControlPrefab;

		public CreationObjectSettingToolCleanupUIControl DefaultToolCleanupUIControlPrefab;

		public CreationObjectSettingButtonUIControl DefaultButtonUIControlPrefab;

		public CreationObjectSettingButtonUIControl EditTagsButtonUIControlPrefab;

		public CreationObjectSettingStringUIControl TagInputFieldUIControlPrefab;

		public RoleGuidEditableUIControl RoleEditControlUIPrefab;

		public RoleGuidSetEditableUIControl RoleSetEditControlUIPrefab;

		public CreationObjectSettingColorUIControl DefaultColorUIControlPrefab;

		public KeyGuidEditableUIControl KeyEditControlUIPrefab;

		[SerializeField]
		public NodeGroupEditable NodeGroupEditableUIPrefab;

		public CreationObjectSettingObjectUIControl DefaultObjectUIControlPrefab;

		public CreationObjectSettingSearchIdUIControl DefaultSearchUIControlPrefab;

		private IDHANFFPOIF KIOGBBPIKCI;

		private List<BaseCreationObjectSettingPropertyUIControl> ABBMJCFBGLJ;

public IDHANFFPOIF TargetConfigurable
{
get 		{
			return null;
		}

set {
		}
}

		public override void StackedUIOpened()
		{
		}

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		private void AELIAPCMFPA()
		{
		}

		private void ELIOFEMFCCH()
		{
		}
	}
}
