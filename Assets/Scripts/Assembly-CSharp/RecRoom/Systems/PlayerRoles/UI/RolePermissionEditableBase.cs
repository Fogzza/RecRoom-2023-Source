using AGUI.StackedUI;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles.UI
{
	public abstract class RolePermissionEditableBase<TRole, RoleIdType, RolePermissionType> : RolePermissionEditable, global::IELKMGOJJEL<RoleIdType> where TRole : global::NALCDCIGNGH<RolePermissionType> where RoleIdType : struct where RolePermissionType : struct
	{
		[SerializeField]
		protected RolePermissionType permission;

		[SerializeField]
		protected ToggleButton3D overridesToggle;

		private RoleIdType LAEAPHAEFHL;

		private TRole EDCLOMLOBIA;

		private bool DDOKNLGFEDM;

		private PCKIFBMBPJF FEKLOPOGGHF;

public bool Interactable
{
get 		{
			return false;
		}

}

protected RoleIdType CJBDBJLMALK
{
get 		{
			return default;
		}

private set {
		}
}

protected TRole LHKMCKHMMBC
{
get 		{
			return default;
		}

private set {
		}
}

protected bool OPMMCJJOBIC
{
get 		{
			return false;
		}

private set {
		}
}

protected PCKIFBMBPJF ICAICEFOKCI
{
get 		{
			return PCKIFBMBPJF.View;
		}

private set {
		}
}

		protected abstract TRole EOAPGBLAICK(bool MKMOHFDABBN);

		public abstract void Button_ToggleOverride(bool NCPDDNBABLF);

		protected void FJCDACMGKLC()
		{
		}

		protected abstract void AOMMEMMMDKL();

		protected abstract bool FKGHLHHACKG(RolePermissionType HEGLKMIJHAM);

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetRoleId(RoleIdType CJFOLKFCHOA, PCKIFBMBPJF CJNPNDHFGGK, bool LBJBJLDMELJ)
		{
		}

		private void MBJJANCBHGF()
		{
		}

		private void MBJJANCBHGF(RolePermissionType IOAELNBANCC)
		{
		}

		protected abstract void KHAIHIGFJHC(RolePermissionType PFOJHOOBCNO);
	}
}
