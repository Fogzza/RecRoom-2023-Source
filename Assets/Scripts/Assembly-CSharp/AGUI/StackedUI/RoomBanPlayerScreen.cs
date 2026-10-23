using CodeStage.AntiCheat.ObscuredTypes;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class RoomBanPlayerScreen : WatchUIFlow
	{
		private sealed class DKMICHLEEIB
		{
			public ObscuredLong roomId;

			public RoomBanPlayerScreen _003C_003E4__this;

			internal void _003CRoomBanPlayer_003Eb__0()
			{
			}

			internal void _003CRoomBanPlayer_003Eb__1(string error)
			{
			}
		}

		[SerializeField]
		private ToggleButton3D moderatedToggle;

		[SerializeField]
		private ToggleButton3D coOwnedToggle;

		[SerializeField]
		private ToggleButton3D createdToggle;

		[SerializeField]
		private Button3D banButton;

		[SerializeField]
		private TextMeshProUGUI descriptionText;

		[SerializeField]
		private TextMeshProUGUI alsoBanFromText;

		[SerializeField]
		private TextMeshProUGUI infoText;

		private long CEJHIILLHIK;

		private bool CBDFPIEDDBC;

		private int NEEIOEKMILD;

		private const string GJKINEFCECG = "ROOM_BAN_PREF";

		private BHNJIBDJFAL NJPJBDDAEFH;

private GDIFHKCAAED NKPIJHJCLJD
{
get 		{
			return GDIFHKCAAED.ThisRoomOnly;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		public void Show(DFDECAEJBIO ACBGBAAHOIM, bool CBDFPIEDDBC)
		{
		}

		private void DJJALKLENKD()
		{
		}

		private void NADNEOKPDBN(string HLIGBKANEEA, bool PCNPMPMHGHF)
		{
		}

		private void NMPOLNMDEMI(GDIFHKCAAED LJKBLEAMCFM, bool KCAPLJEHMMI)
		{
		}

		public void Toggle_Moderated(bool isOn)
		{
		}

		public void Toggle_CoOwned(bool isOn)
		{
		}

		public void Toggle_Created(bool isOn)
		{
		}

		public void Button_Ban()
		{
		}
	}
}
