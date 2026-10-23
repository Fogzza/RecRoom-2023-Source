using System;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.AGUI.ToolUIs
{
	public class MoveableToolMenu : MonoBehaviourPun
	{
		public enum EBPGMFDOKPN
		{
			Up = 0,
			Down = 1,
			Left = 2,
			Right = 3
		}

		[SerializeField]
		protected Vector3 defaultOffsetFromHead;

		[SerializeField]
		private Tool _tool;

		private global::MOBDJNEDDKC<bool> BBJNMCDCCLI;

		private PhotonView PNLELPKCPKN;

		private Action<bool> LBGOFIOPBPL__BackingField;

		private Action<EBPGMFDOKPN> PNLAJDHJFHB__BackingField;

public Tool Tool
{
get 		{
			return null;
		}

}

public bool IsMenuVisible
{
get 		{
			return false;
		}

}

protected virtual Vector3 KBLBLLKGFKE
{
get 		{
			return default;
		}

}

public event Action<bool> OnMenuOpenCloseEvent {
add {
		}
remove {
		}
}

public event Action<EBPGMFDOKPN> MoveRequested {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void HLIJJAKEKDH(EBPGMFDOKPN HLFIBIDOLEF)
		{
		}

		public virtual Selectable TryGetMoveRequestUI(EBPGMFDOKPN HLFIBIDOLEF)
		{
			return null;
		}

		private void BADODPLCJNK(Tool PMEFICGEDFK)
		{
		}

		private void NKCFKBLMBMM()
		{
		}

		public void ShowMenu()
		{
		}

		public void ShowMenuMainScreen()
		{
		}

		public void OpenAndAttachMenu(PhotonView EOEAGKFEGDP)
		{
		}

		public virtual void HideMenu()
		{
		}

		private void BAFMLCJPHPO(bool KBHLDNPHEKG)
		{
		}

		[CompilerGenerated]
		private void IMAAGKGBJFJ()
		{
		}
	}
}
