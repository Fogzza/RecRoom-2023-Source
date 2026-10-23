using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AGUI.StackedUI
{
	public sealed class AccountSpecificUIBehaviour : MonoBehaviour
	{
		[Serializable]
		public enum PlayerDisplayMode
		{
			None = 0,
			Friends = 2,
			Club = 3,
			Recent = 4,
			Find = 5,
			SuggestedFriends = 6,
			Party = 7
		}

		public EEANDDJEMJC PlayerAccountReady;

		public EEANDDJEMJC PlayerAccountUpdated;

		[SerializeField]
		private bool includeReputation;

		[SerializeField]
		private bool includePlatformNotificationRegistrationStatus;

		private PlayerDisplayMode AIDOCIKAKCJ;

		public bool IsInvitingMe;

		private int? BCBIFFAJPAN;

		private bool BCDBDJNBPBO;

public PlayerDisplayMode DisplayMode
{
get 		{
			return PlayerDisplayMode.None;
		}

}

public int? AccountId
{
get 		{
			return null;
		}

private set {
		}
}

public DFDECAEJBIO CurrentAccount
{
get 		{
			return null;
		}

}

public IGBPGJHGFFP CurrentReputation
{
get 		{
			return null;
		}

}

public bool CanReceiveOfflineInvitePlatformNotifications
{
get 		{
			return false;
		}

}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void SetPlayer(int? IKHNIJKGJFD, PlayerDisplayMode AIDOCIKAKCJ = PlayerDisplayMode.None)
		{
		}

		private void LFMPLNAOFMG(int EJIHLJJMOBD)
		{
		}

		private void EDDHDFGPBHP(int EJIHLJJMOBD)
		{
		}

		public static global::NCOKFFGPIJM<string> GetStatusText(DFDECAEJBIO ACBGBAAHOIM, PlayerDisplayMode AIDOCIKAKCJ, MNIEBEJFEHJ FOMIOEDECEP, bool OCKLKNHADMG = false, bool LAKDCAJHGOC = false)
		{
			return null;
		}

		[CompilerGenerated]
		private void BAMAFEAEJPC(DFDECAEJBIO ACBGBAAHOIM)
		{
		}

		[CompilerGenerated]
		private void DLNJFDEMBDL(IGBPGJHGFFP MADEEKOIJKH)
		{
		}

		[CompilerGenerated]
		private void KFHPHLHLEKI(bool AJLDNMPIGNP)
		{
		}
	}
}
