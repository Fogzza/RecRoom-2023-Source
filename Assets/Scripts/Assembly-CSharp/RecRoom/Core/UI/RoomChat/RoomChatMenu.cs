using System.Collections.Generic;
using RecRoom.Audio;
using RecRoom.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Core.UI.RoomChat
{
	public class RoomChatMenu : MonoBehaviour
	{
		private enum KCEEJLLMEFE
		{
			Hidden = 0,
			Preview = 1,
			Expanded = 2
		}

		private sealed class HINNOJFNAMO
		{
			public string message;

			internal bool _003CSelectCannedChatCategory_003Eb__0(CannedChat c)
			{
				return false;
			}
		}

		[SerializeField]
		private TMP_InputField inputField;

		[SerializeField]
		private ScreenHUDElement screenHudElement;

		[SerializeField]
		private GameObject previewRoot;

		[SerializeField]
		private GameObject expandedRoot;

		[SerializeField]
		private RecRoomAudioClip expandMenuSFX;

		[SerializeField]
		private RecRoomAudioClip previewMenuSFX;

		public readonly EEANDDJEMJC MenuExpandedEvent;

		public readonly EEANDDJEMJC InputFieldBecameInteractableEvent;

		private bool OGANPKFJPHN;

		private readonly List<RoomChatLogDialog> FGEHPGOOJFM;

		private readonly List<RoomChatLogDialog> IEDHIPDGEAF;

		private readonly List<RoomChatLogDialog> JPNHJFGABJK;

		private int FODOAONGKBI;

		private int MCMFFIJIMFB;

		private int CFAJMKNIEDC;

		private int LIFDPIOBDGK;

		[SerializeField]
		private Transform contentRoot;

		[SerializeField]
		private Toggle toggleCannedChatButton;

		[SerializeField]
		private GameObject cannedChatPrefab;

		[SerializeField]
		private GameObject cannedChatMenu;

		private List<int> CNBCHIEHOIO;

		private List<int> NAMGHNLKMMB;

		private List<CannedChat> BMGDCNOEFBN;

		private KCEEJLLMEFE DADHJJNJEFA;

		private bool PBGCEKIHJLA;

public bool CannedChatOpen
{
get 		{
			return false;
		}

private set {
		}
}

public ScreenHUDElement ScreenHudElement
{
get 		{
			return null;
		}

}

public bool IsExpanded
{
get 		{
			return false;
		}

}

public bool IsPreview
{
get 		{
			return false;
		}

}

public bool IsHidden
{
get 		{
			return false;
		}

}

public bool IsVisible
{
get 		{
			return false;
		}

}

public bool HasUnreadMessages
{
get 		{
			return false;
		}

private set {
		}
}

public Vector2 InputFieldCenterWorldPosition
{
get 		{
			return default;
		}

}

private bool DELBFIEHINC
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void EnableScreenHUDElementForFrame()
		{
		}

		private void LLBOFMIINLO(int AIABLOJDPKA)
		{
		}

		private void LMDNMDLBMGI(string DLEMNBPMGBG)
		{
		}

		private void ANNCPAKHPNK()
		{
		}

		private void KLFKCMEOOOK()
		{
		}

		public bool UpdateContainerForTouchKeyboard()
		{
			return false;
		}

		public void RepaintMessageLines()
		{
		}

		private bool MKNBNADGELE(List<RoomChatLogDialog> NNMPHPICELH, ref int LJBLEJHAENP, ref int IPDNLCHDBDH, bool DKEFDCANEIE)
		{
			return false;
		}

		public void SetInputFieldInteractable(bool PCNPMPMHGHF)
		{
		}

		private void PJHDDAPBICF()
		{
		}

		private void EKMMADLJNAM()
		{
		}

		private void NGHHEMGDEIG()
		{
		}

		private void JPCALNPAGGD()
		{
		}

		public void SelectCannedChatCategory(int GMEHLIHLGEH, string OFCFPGACNJB)
		{
		}

		public void ActivateInputField()
		{
		}

		public void DeselectInputField()
		{
		}

		public bool IsUsingInputField()
		{
			return false;
		}

		public void SendChatMessage(string OFCFPGACNJB)
		{
		}

		public void SendCannedChatMessage(string NBEEAFMOGKN)
		{
		}

		private void EGIAOKCAJCB(string OFCFPGACNJB, bool HBEABHHPBHH)
		{
		}

		public void GoBackInCannedChat()
		{
		}

		public void ToggleCannedChat(bool isOpen)
		{
		}

		public void CloseCannedChat()
		{
		}

		private void BCJEOIHOLPD(bool LNBOCMEBNEB)
		{
		}

		public void SendChatMessage()
		{
		}

		public void Expand(bool playSFX = true)
		{
		}

		public void Preview(bool playSFX = true)
		{
		}

		public void Hide()
		{
		}
	}
}
