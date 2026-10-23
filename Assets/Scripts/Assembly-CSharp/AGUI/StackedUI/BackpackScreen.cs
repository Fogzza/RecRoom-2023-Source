using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RecRoom.Consumable;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class BackpackScreen : WatchUIFlow
	{
		public enum DFNLMMONNOI
		{
			Invalid = -1,
			Tools = 0,
			Skins = 1,
			Food = 2,
			Other = 3
		}

		[SerializeField]
		private RadioButton3D toolsTabButton;

		[SerializeField]
		private RadioButton3D skinsTabButton;

		[SerializeField]
		private RadioButton3D foodTabButton;

		[SerializeField]
		private RadioButton3D otherTabButton;

		[SerializeField]
		private RadioButton3D thisRoomTabButton;

		[SerializeField]
		private RectTransform favoriteToolInfo;

		[SerializeField]
		private BackpackToolButtonPagedGrid backpackToolPagedGrid;

		[SerializeField]
		private EquipmentsPagedGrid skinsPagedGrid;

		[SerializeField]
		private ConsumablesPagedGrid consumablesPagedGrid;

		private List<IELGHJEOPKB> HPIJJMINNME;

		private ConsumableManager IMLPFOHNCBN;

		private EquipmentManager CCMOEDBLGBI;

		private DFNLMMONNOI CIECFEBDHMM;

private DFNLMMONNOI HJFFDKOMMCN
{
get 		{
			return DFNLMMONNOI.Tools;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void JHMCPBKGAFC()
		{
		}

		private void BDAGMPAOHJB()
		{
		}

		private List<IELGHJEOPKB> HHHAJALKHPD()
		{
			return null;
		}

		private List<IELGHJEOPKB> ENCIFFKAMIN()
		{
			return null;
		}

		private List<IELGHJEOPKB> DKEFMPDCJFG()
		{
			return null;
		}

		private void KCDPAONFOBA(DFNLMMONNOI AIDOCIKAKCJ)
		{
		}

		private void HNKADFIPEMM(IELGHJEOPKB KIJHICGIKFM, bool FEAFMCKIFHC)
		{
		}

		private void KBPOAKFJFKL(FFNCPFGBPND CKAPBBGHJEC)
		{
		}

		public void Button_ToggleActiveState(IELGHJEOPKB consumable)
		{
		}

		public void Button_ToggleEquipmentEquipped(FFNCPFGBPND equipment)
		{
		}

		public void Button_SetToolsDisplayMode()
		{
		}

		public void Button_SetSkinsDisplayMode()
		{
		}

		public void Button_SetFoodDisplayMode()
		{
		}

		public void Button_SetOtherDisplayMode()
		{
		}

		public void Button_ShowForThisRoomTab()
		{
		}

		public void Toggle_FavoriteTool(bool isOn, BKMDFCCNPGE favoriteToolType)
		{
		}

		public void Toggle_UseTool(bool isOn, BKMDFCCNPGE toolType)
		{
		}

		[CompilerGenerated]
		private void PIIDHNFGLHK()
		{
		}
	}
}
