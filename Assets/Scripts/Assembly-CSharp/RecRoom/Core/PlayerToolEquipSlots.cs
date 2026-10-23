using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core
{
	public sealed class PlayerToolEquipSlots : MonoBehaviourPun
	{
		[SerializeField]
		private PlayerToolEquipSlot shoulderSlot;

		[SerializeField]
		private PlayerToolEquipSlot leftHipSlot;

		[SerializeField]
		private PlayerToolEquipSlot rightHipSlot;

		[SerializeField]
		private Player thisPlayer;

		private List<int> DBCHONHGBFI;

		private List<Tool> PBFOBAICEEO;

		private PlayerToolEquipSlot[] BADEPIMBOHG;

		public global::BPEPJJDICII<Tool, PlayerToolEquipSlot> ToolEquipEvent;

		public global::BPEPJJDICII<Tool, PlayerToolEquipSlot> ToolUnequipEvent;

		public EEANDDJEMJC EquipSlotsEnabledChangedEvent;

		public EEANDDJEMJC EquipRestrictionsChangedEvent;

		private FIHGBEHGLGB OGPOBBFGPOH;

		private global::MOBDJNEDDKC<DPOHPKHGJKL> MHKIOAEOFFP;

public PlayerToolEquipSlot ShoulderSlot
{
get 		{
			return null;
		}

}

public PlayerToolEquipSlot LeftHipSlot
{
get 		{
			return null;
		}

}

public PlayerToolEquipSlot RightHipSlot
{
get 		{
			return null;
		}

}

public PlayerToolEquipSlot DominantHandHipSlot
{
get 		{
			return null;
		}

}

public PlayerToolEquipSlot OffHandHipSlot
{
get 		{
			return null;
		}

}

public PlayerToolEquipSlot[] AllSlots
{
get 		{
			return null;
		}

private set {
		}
}

public bool AutomaticallyEquipToolOnDrop
{
set {
		}
}

public bool HotSwapToolOnDrop
{
set {
		}
}

public DPOHPKHGJKL HipSlotEnableMode
{
get 		{
			return DPOHPKHGJKL.ALL_DISABLED;
		}

set {
		}
}

public bool CanPickupShoulderTool
{
get 		{
			return false;
		}

}

		public PlayerToolEquipSlot GetEquipSlot(EAJPDHFNCOB HHOGFBCFGAB)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void AddShoulderSlotToolPickupRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveShoulderSlotToolPickupRestriction(object IALNODEHBNN)
		{
		}

		public PlayerToolEquipSlot GetEquipSlotHoldingTool(Tool IEGMBEPJMGC)
		{
			return null;
		}

		public bool TryEquipTool(Tool IEGMBEPJMGC, PlayerHand MDGEOKOCENN, bool EDNCELKHKEF = true)
		{
			return false;
		}

		public bool TryEquipTool(Tool IEGMBEPJMGC, PlayerHand MDGEOKOCENN, PlayerToolEquipSlot JMEEAMAPEDC, bool EDNCELKHKEF = true, bool EIPIGMJNLJE = true)
		{
			return false;
		}

		public bool EquipSlotCurrentlyEnabled(PlayerToolEquipSlot JMEEAMAPEDC)
		{
			return false;
		}

		public bool CanEquipTool(Tool IEGMBEPJMGC, PlayerHand MDGEOKOCENN, PlayerToolEquipSlot JMEEAMAPEDC, bool EIPIGMJNLJE = true)
		{
			return false;
		}

		public void DropAllTools()
		{
		}

		public void DropAllNotOwnedTools()
		{
		}

		public PlayerToolEquipSlot GetEquipSlotById(int IKHNIJKGJFD)
		{
			return null;
		}

		public PlayerToolEquipSlot GetNextEnabledEquipSlotById(ref int IKHNIJKGJFD, bool NCNJBBIMFKI, bool LHFONKHPJJD)
		{
			return null;
		}

		public void EquipTools(int[] CBCHJMCEHOH, Tool[] BEMKJDLJPKB)
		{
		}

		public void GetAllEquippedTools(out int[] CBCHJMCEHOH, out Tool[] BEMKJDLJPKB)
		{
			CBCHJMCEHOH = null;
			BEMKJDLJPKB = null;
		}

		private void EIDBPAPOEKJ(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
		{
		}

		private void JPAENMMICOG(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
		{
		}

		private static int GCIMDBENHNG(int KJBNEMDOMAC, int MOHMCFDNHKH, int IJKKMPMKJKH)
		{
			return 0;
		}

		private void GEMKGLFMEFN(bool BFDBCMGIOBG)
		{
		}

		private void NKIDEOMAKJI()
		{
		}
	}
}
