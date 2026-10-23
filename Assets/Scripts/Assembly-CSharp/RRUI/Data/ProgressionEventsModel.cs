using System;
using System.Collections.Generic;
using RecNet;

namespace RRUI.Data
{
	public class ProgressionEventsModel : RRUIModel
	{
		private sealed class ACGEJKJGDLE
		{
			public long roomId;

			public Func<KeepsakeRoomDTO, bool> _003C_003E9__0;

			internal bool _003CGetKeepsakeRoomDesc_003Eb__0(KeepsakeRoomDTO keepsakeRoom)
			{
				return false;
			}
		}

		public readonly DateTime INVALID_UNLOCK_TIME;

		private EAOCHKEGDFJ BBHMAAACAIO;

		private PNPHOOBLIIO KKGOHIDNJOL;

		private HEIKEFEIKLD LACOFCFHKCA;

		private FBDMPCDHLHH LDNDJAMEJDG;

		private MLCEGEIFEAK AJFLAGMMAIL;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public bool IsEventActive
{
get 		{
			return false;
		}

}

public bool IsActiveEventKeepsakeEvent
{
get 		{
			return false;
		}

}

public IENHNBAOAMH CurrentStatus
{
get 		{
			return IENHNBAOAMH.Inactive;
		}

}

public IReadOnlyList<KeepsakeRoomListDTO> AllKeepsakeRoomLists
{
get 		{
			return null;
		}

}

public IReadOnlyList<KeepsakeRoomListDTO> StandardKeepsakeRoomLists
{
get 		{
			return null;
		}

}

public IReadOnlyList<KeepsakeRoomListDTO> PremiumKeepsakeRoomLists
{
get 		{
			return null;
		}

}

public ProgressionEventDTO ActiveProgressionEvent
{
get 		{
			return null;
		}

}

public ProgressionEventRecordDTO ActiveProgressionEventRecord
{
get 		{
			return null;
		}

}

public TimeSpan TimeLeft
{
get 		{
			return default;
		}

}

public float TimeLeftPercentage
{
get 		{
			return 0f;
		}

}

public TimeSpan CollectionTimeLeft
{
get 		{
			return default;
		}

}

public float CollectionTimeLeftPercentage
{
get 		{
			return 0f;
		}

}

public int MainRewardIndex
{
get 		{
			return 0;
		}

}

public int ActiveRewardIndex
{
get 		{
			return 0;
		}

}

public bool AreActiveEventUpsellItemsOwned
{
get 		{
			return false;
		}

}

public bool HasStartedProgressionEventIntroTutorial
{
get 		{
			return false;
		}

}

private IReadOnlyDictionary<long, string> GOPHNPHKAFC
{
get 		{
			return null;
		}

}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		public void OnPlayerViewedEventXp()
		{
		}

		public void ShowInfoDialog()
		{
		}

		public string GetConfigurableText(IOEIFEGHMIF NMADGLNNHNM)
		{
			return null;
		}

		public string GetConfigurableTextBySubstringIndex(IOEIFEGHMIF NMADGLNNHNM, int ADDEMMFIBPI)
		{
			return null;
		}

		public string GetConfigurableTextByRoomId(IOEIFEGHMIF NMADGLNNHNM, long EPOBIFCHLNM)
		{
			return null;
		}

		public DateTime GetNextKeepsakeRoomUnlockTime(long HJPNFJHJPBE)
		{
			return default;
		}

		public long GetKeepsakeRoomListIdFromRoomId(long EPOBIFCHLNM)
		{
			return 0L;
		}

		public global::NCOKFFGPIJM<JCDPHCELKHI> GetRoomFromUpsellGiftDropId(long FAKOICJDABG)
		{
			return null;
		}

		public void ShowChallengesPage()
		{
		}

		private void MPCOLNGLACE()
		{
		}

		private void HAAKMPNENBG()
		{
		}

		private void JAHAACOJEDE()
		{
		}

		private void DFNMMPEJHFM(Guid? GADDGJANIGG)
		{
		}

		public void PromptUserToUpdateClient()
		{
		}

		public EOKBGGOAFLF GetUpsellItemGiftDrop(long HJPNFJHJPBE)
		{
			return null;
		}

		public long GetHighlightKeepsakeRoomId(long HJPNFJHJPBE)
		{
			return 0L;
		}

		public global::NCOKFFGPIJM<IEnumerable<Guid>> GetAllKeepsakeInstanceIdsForRoom(long EPOBIFCHLNM, long LEBNGAGIGPK, BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<IEnumerable<Guid>> GetUncollectedKeepsakeInstanceIdsForRoom(long EPOBIFCHLNM, long LEBNGAGIGPK, BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<int> GetTotalKeepsakeCountForRoom(long EPOBIFCHLNM, long LEBNGAGIGPK, BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<int> GetUncollectedKeepsakeCountForRoom(long EPOBIFCHLNM, long LEBNGAGIGPK, BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public string GetKeepsakeCategoryOutlineImageName(BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public string GetKeepsakeCategoryFilledImageName(BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public string GetKeepsakeRoomDesc(long EPOBIFCHLNM)
		{
			return null;
		}

		public bool IsKeepsakeRoomListUpsellItemOwned(long HJPNFJHJPBE)
		{
			return false;
		}

		public Guid? GetPurchasableXpBoostId()
		{
			return null;
		}

		public string GetKeepsakeName(BLIIKHLKHJA DNPADHKNGNL)
		{
			return null;
		}

		public string GetKeepsakeNameUpsellStringForCurrentEvent()
		{
			return null;
		}

		public void OnCountdownElapsed()
		{
		}

		private void AHEKNHHMAOK(GKPEKOLBBJL NIFOGEBEDNG, long JKPJELBKKGN)
		{
		}

		public bool ActiveEventInCollectionGracePeriod()
		{
			return false;
		}
	}
}
