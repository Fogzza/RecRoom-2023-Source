using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.RRUI.Models.Rewards;
using RRUI.Dialogs;
using UnityEngine;

namespace RRUI.Data
{
	public class RewardSelectionModel : RRUIModel
	{
		private sealed class OBOFDBCDNAE
		{
			public RewardSelectionModel _003C_003E4__this;

			public DBFJJLIGAFA giftDrop1;

			public DBFJJLIGAFA giftDrop2;

			public DBFJJLIGAFA giftDrop3;

			public bool doubleRewardAvailable;

			internal void _003CGetItemModelData_003Eb__0()
			{
			}

			internal void _003CGetItemModelData_003Eb__1()
			{
			}

			internal void _003CGetItemModelData_003Eb__2()
			{
			}

			internal void _003CGetItemModelData_003Eb__3()
			{
			}
		}

		private sealed class HFJIOEEIBKD
		{
			public RRPlusDoubleRewardDialogModel rrPlusRewardsModel;

			public RewardSelectionModel _003C_003E4__this;

			internal void _003CShowDoubleRewardOfferDialog_003Eb__2()
			{
			}
		}

		private sealed class EAAFCMBFBOJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public int secondsToWait;

			public RewardSelectionModel _003C_003E4__this;

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
			public EAAFCMBFBOJ(int _003C_003E1__state)
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

		[SerializeField]
		private CurrencyLevel[] CurrencyLevels;

		private PEIGAAKDIDI HMAOFGOICJC;

		private JKHCJAJHGAO LNLLEOLHPIN;

		private OFOJMMEANHP.GNBEMBCEKHE BPDFOALMCGP;

public PEIGAAKDIDI RewardSelectionData
{
get 		{
			return null;
		}

private set {
		}
}

public OFOJMMEANHP.GNBEMBCEKHE RewardSelection
{
get 		{
			return null;
		}

private set {
		}
}

private bool LOODEMDNIIP
{
get 		{
			return false;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void Set(PEIGAAKDIDI FCBLPKPPJKA)
		{
		}

		public void AutoSelectReward()
		{
		}

		public void SelectReward(int? FAKOICJDABG, bool GEMFLFKNMJM = false)
		{
		}

		public EOKMLCNIEBH[] GetItemModelData()
		{
			return null;
		}

		private void BOCBAHDCHJC()
		{
		}

		public void StartRewardExpirationTimer()
		{
		}

		public void CancelRewardExpirationTimer()
		{
		}

		private IEnumerator<EGGPGCCKPCO> KNOOGJMGLNG(int HHGNBGPHECE)
		{
			return null;
		}

		private void JAEOCPJIODG()
		{
		}

		private Texture KOIEBBMJKDA(DBFJJLIGAFA OPKDMEIFDHL)
		{
			return null;
		}

		[CompilerGenerated]
		private void BBLEPGAJBCI(BaseDialogModel<DBOLANDDOAE> GDMKJGAKCND)
		{
		}
	}
}
