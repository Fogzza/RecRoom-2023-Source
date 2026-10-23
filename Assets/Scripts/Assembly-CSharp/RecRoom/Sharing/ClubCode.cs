using System;
using RRUI.Navigation;
using UnityEngine;

namespace RecRoom.Sharing
{
	public class ClubCode : ActionCode
	{
		[Serializable]
		private struct ClubData
		{
			public long ClubId;

			public JFFJOJHMNAM Joinability;

			public HKKNCOIOGPO Visibility;
		}

		private sealed class FNJBCGCOONB
		{
			public object args;

			internal NMLEIPDLABI _003CCreate_003Eb__0(NMLEIPDLABI code)
			{
				return default;
			}
		}

		private sealed class HBOMJEIMGDM
		{
			public Route RRUIShareRoute;

			public ClubCode _003C_003E4__this;

			public bool removeCurrentUriFromHistory;

			internal void _003CCreateAndShare_003Eb__0(NMLEIPDLABI result)
			{
			}
		}

		private sealed class EJNFPEDJEJE
		{
			public EPILDIJELPG club;

			public LinkManager.OPICCOMKOOF pendingLink;

			public ClubCode _003C_003E4__this;

			public ClubData data;

			public bool joined;

			public Action _003C_003E9__3;

			public Action _003C_003E9__4;

			internal LAHBDKNMNHN _003CHandle_003Eb__0(EPILDIJELPG c)
			{
				return null;
			}

			internal LAHBDKNMNHN _003CHandle_003Eb__2()
			{
				return null;
			}

			internal void _003CHandle_003Eb__3()
			{
			}

			internal void _003CHandle_003Eb__4()
			{
			}
		}

		[SerializeField]
		private string cantShowClubBody;

		[SerializeField]
		private string cantShowClubTitle;

		[SerializeField]
		private string clubJoined;

		[SerializeField]
		private string juniorCantJoinBody;

		[SerializeField]
		private string juniorCantJoinTitle;

		private FEIKFKAICHC HKNAHLAFLPC;

		public override bool SupportsDirectShareInChat(object DELCOFCGDFF)
		{
			return false;
		}

		private void Awake()
		{
		}

		public override global::NCOKFFGPIJM<NMLEIPDLABI> Create(object ADCFFAJGNAM)
		{
			return null;
		}

		public override OFPDFAGJKLH.DBGOCJDEIIN GetChatShareMessage(NMLEIPDLABI ABPFMLKOJAM, bool MHIOBEJKDFA)
		{
			return null;
		}

		public override LAHBDKNMNHN CreateAndShare(Route JGMLNNDKOOH, bool GMEKLDALJKC, object ADCFFAJGNAM)
		{
			return null;
		}

		public override void CreateButtonPressed()
		{
		}

		public override LAHBDKNMNHN Handle(LinkManager.OPICCOMKOOF EDDMIJOKMNC)
		{
			return null;
		}

		public override void ModifyPreAuthLaunchTarget(BootSequence.NJIJPADHPEC DBGKIJIDIGJ, LinkManager.OPICCOMKOOF EDDMIJOKMNC)
		{
		}
	}
}
