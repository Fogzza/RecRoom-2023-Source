using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AGUI.StackedUI
{
	public class SavedOutfitsPagedGrid : RecyclerPagedGrid<GEMIGMENNNE, SavedOutfitSlotButton>
	{
		[Serializable]
		public class OutfitSelectedEvent : UnityEvent<DLCBGFLGNLN>
		{
		}

		private sealed class MPGHFBINGNI
		{
			public SavedOutfitsPagedGrid _003C_003E4__this;

			public SavedOutfitSlotButton button;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}

			internal void _003CSetupNewChild_003Eb__1()
			{
			}
		}

		public OutfitSelectedEvent OnLoadOutfitSelectedEvent;

		public OutfitSelectedEvent OnSaveOutfitSelectedEvent;

		[SerializeField]
		private Texture2D emptySlotTexture;

		[SerializeField]
		private Texture2D loadingPreviewSlotTexture;

		public void SetItems(IEnumerable<GEMIGMENNNE> JNAAHMPCPAB, bool OPKEFNEECKK)
		{
		}

		protected override void ANLHNIJPJEC(GEMIGMENNNE BOHMGLHFNGG, SavedOutfitSlotButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}

		protected override void LKIICDHGCMD(SavedOutfitSlotButton HHDMPJJAPJJ)
		{
		}
	}
}
