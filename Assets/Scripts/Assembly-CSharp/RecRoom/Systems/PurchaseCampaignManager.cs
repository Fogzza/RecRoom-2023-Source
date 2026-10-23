using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace RecRoom.Systems
{
	public class PurchaseCampaignManager : SingletonMonoBehaviour<PurchaseCampaignManager>
	{
		private sealed class EBIMKMLKCOI
		{
			public MBPOJAEGNPN campaignManager;

			public PurchaseCampaignManager _003C_003E4__this;

			public POPLPJGHHIA.EGCCHLKLIIL trigger;

			public bool waitForWatch;

			public bool popUp;

			internal void _003CTryShowPurchaseCampaign_003Eb__0(POPLPJGHHIA.LOBKJCHKJAA purchaseCampaign)
			{
			}
		}

		private sealed class JFJFEGIEEPM
		{
			public POPLPJGHHIA.LOBKJCHKJAA purchaseCampaign;

			public EBIMKMLKCOI CS_0024_003C_003E8__locals1;

			public Func<POPLPJGHHIA.KAEKKCCLKLH, bool> _003C_003E9__2;

			internal void _003CTryShowPurchaseCampaign_003Eb__1(List<POPLPJGHHIA.KAEKKCCLKLH> skus)
			{
			}

			internal bool _003CTryShowPurchaseCampaign_003Eb__2(POPLPJGHHIA.KAEKKCCLKLH sku)
			{
				return false;
			}
		}

		private sealed class COHMLLIDOEB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public bool waitForWatch;

			public PurchaseCampaignManager _003C_003E4__this;

			public POPLPJGHHIA.OCDCJKGHBON purchaseCampaignSku;

			public bool popUp;

			public POPLPJGHHIA.EGCCHLKLIIL trigger;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public COHMLLIDOEB(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private BHNJIBDJFAL NJPJBDDAEFH;

		private POPLPJGHHIA.EGCCHLKLIIL PKEPLHJMOLE;

		private static readonly int AAHEFDKNLDD;

		private const string PBCPKHNENLL = "econ_q2_campaign_popup_cooldown";

		private const string GKOPNKHODMB = "cooldownInMinutes";

		private const string NKDNEADJJIL = "nextPurchaseCampaignShowTime";

		protected override void Awake()
		{
		}

		public void AddPurchaseCampaignPendingTrigger(POPLPJGHHIA.EGCCHLKLIIL CFIDCKKKJCI)
		{
		}

		public void ShowPurchaseCampaignOnRoomEnter()
		{
		}

		public void TryShowPurchaseCampaign(POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD, bool OGBFBICPLGP = true, bool ECDGLCEGHCN = true)
		{
		}

		private void HDPIKBLDHIN(POPLPJGHHIA.LOBKJCHKJAA GJGNFOHEKFO, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD)
		{
		}

		private IEnumerator<EGGPGCCKPCO> HGMMAEGPGDC(POPLPJGHHIA.OCDCJKGHBON LJFOOMOHAMI, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD, bool OGBFBICPLGP = true, bool ECDGLCEGHCN = true)
		{
			return null;
		}

		public void InvalidatePurchaseCampaignCache()
		{
		}

		public void ResetNextCampaignShowTime()
		{
		}
	}
}
