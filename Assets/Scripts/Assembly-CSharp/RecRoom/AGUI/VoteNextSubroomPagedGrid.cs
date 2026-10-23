using System;
using System.Collections.Generic;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI
{
	public class VoteNextSubroomPagedGrid : RecyclerPagedGrid<string, VoteNextSubroomButton>
	{
		[Serializable]
		public class NextSubroomVoted : UnityEvent<bool, string>
		{
		}

		private sealed class BBCBFFLHCMG
		{
			public VoteNextSubroomPagedGrid _003C_003E4__this;

			public VoteNextSubroomButton button;

			internal void _003CSetupNewChild_003Eb__0(RadioButton3D isOn)
			{
			}
		}

		[SerializeField]
		private RadioGroup3D radioGroup;

		public NextSubroomVoted OnNextSubroomVotedEvent;

		protected override void LKIICDHGCMD(VoteNextSubroomButton HHDMPJJAPJJ)
		{
		}

		public void UpdateButtonsVoteCount()
		{
		}

		public void SetSceneNames(IEnumerable<string> KLGBDEEMBOL)
		{
		}

		protected override void ANLHNIJPJEC(string PAKKJAPOGPN, VoteNextSubroomButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
