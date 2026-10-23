using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class BaseRoomButton : MonoBehaviour
	{
		public JCDPHCELKHI CurrentRoom;

		[SerializeField]
		private RoomOrPlaylistImage roomImage;

		[SerializeField]
		private TextMeshProUGUI roomNameText;

		[SerializeField]
		private Button3D button;

		[SerializeField]
		private Image panel;

		[SerializeField]
		private GameObject notYetSupportedBanner;

public Button3D.OnButton3DClick ButtonAction
{
get 		{
			return null;
		}

}

		private void OnEnable()
		{
		}

		public void SetRoom(JCDPHCELKHI KPFNANKNKLE)
		{
		}
	}
}
