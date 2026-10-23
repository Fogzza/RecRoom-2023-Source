using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace AGUI.StackedUI
{
	public class AccountIdPagedGrid : RecyclerPagedGrid<int, PlayerButton>
	{
		[Serializable]
		public class ShowPlayerDetailsEvent : UnityEvent<DFDECAEJBIO>
		{
		}

		private sealed class CNMLOLHMANL
		{
			public AccountIdPagedGrid _003C_003E4__this;

			public PlayerButton button;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}
		}

		private sealed class IOMHMNDKMCI
		{
			public AccountIdPagedGrid _003C_003E4__this;

			public IList<int> activeChildren;

			internal void _003CActivateCurrentPageActiveChildren_003Eb__0(List<DFDECAEJBIO> accounts)
			{
			}
		}

		[SerializeField]
		private string noResultsString;

		[SerializeField]
		private ShowPlayerDetailsEvent ShowDetailsEvent;

		private bool LAJGEJCMFLC;

		private int PKOOBAMGFBM;

		private void Start()
		{
		}

		protected override void LKIICDHGCMD(PlayerButton HHDMPJJAPJJ)
		{
		}

		public void SetAccountIds(IEnumerable<int> AEBIAAMBKED, bool OPKEFNEECKK)
		{
		}

		protected override void KLHEKFJOJIA(IList<int> HHDINJFMAFO)
		{
		}

		protected override void ANLHNIJPJEC(int EJIHLJJMOBD, PlayerButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private void NBECFFIAJMM(IList<int> HHDINJFMAFO)
		{
		}
	}
}
