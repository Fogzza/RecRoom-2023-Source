using System;
using UnityEngine;

namespace RRUI.Data
{
	public class PlayerReferralRewardListModelController : ModelController<PlayerReferralRewardListModel>
	{
		[Serializable]
		private class VerifiedFriendCountTextImpl : TextControllerImpl<PlayerReferralRewardListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardsClaimedCountTextImpl : TextControllerImpl<PlayerReferralRewardListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoVerifiedReferralsImpl : HideableControllerImpl<PlayerReferralRewardListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasVerifiedReferralsImpl : HideableControllerImpl<PlayerReferralRewardListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PlayerReferralRewardListSpawnerImpl : RecyclingListControllerImpl<PlayerReferralRewardListModel, PlayerReferralRewardModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}
	}
}
