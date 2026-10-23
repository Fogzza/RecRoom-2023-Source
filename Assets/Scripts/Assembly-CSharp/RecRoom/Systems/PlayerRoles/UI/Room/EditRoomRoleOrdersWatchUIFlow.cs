using System;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles.UI.Room
{
	public class EditRoomRoleOrdersWatchUIFlow : WatchUIFlow
	{
		[SerializeField]
		private TextInputUIDialog textInputDialogPrefab;

		[SerializeField]
		private ToggleButton3D showOnlyMyRolesToggle;

		[SerializeField]
		private GameObject showOnlyMyRolesContainer;

		[SerializeField]
		private RoomRolePagedGrid grid;

		public LCEKCFEIEGJ TargetRoomDetails;

		private Action<PCKIFBMBPJF> PJCNLNIKIKK__BackingField;

		private PCKIFBMBPJF NBGEHLCGIMP;

		private CGOPOAFDIDN AAKFKPKFDJJ;

private bool GDNLEFBJAIJ
{
get 		{
			return false;
		}

}

public PCKIFBMBPJF RoleViewMode
{
get 		{
			return PCKIFBMBPJF.View;
		}

set {
		}
}

private bool NFCDBCKECHF
{
get 		{
			return false;
		}

}

public event Action<PCKIFBMBPJF> OnRoleViewModeChangedEvent {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		private void ENGIMCOBPLG(long EPOBIFCHLNM)
		{
		}

		private void MMGPNPCHCPP(JDCIJIEOFOL EKOFNPFCLMO)
		{
		}

		public void Toggle_ShowOnlyMyRoles()
		{
		}
	}
}
