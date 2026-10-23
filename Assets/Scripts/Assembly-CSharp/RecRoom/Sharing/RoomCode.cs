using System;
using RRUI.Navigation;

namespace RecRoom.Sharing
{
	public class RoomCode : ActionCode
	{
		[Serializable]
		private struct RoomCodeData
		{
			public long RoomId;
		}

		private sealed class LNLNOIHCDCO
		{
			public LCEKCFEIEGJ roomDetails;

			internal NMLEIPDLABI _003CCreate_003Eb__0(NMLEIPDLABI code)
			{
				return default;
			}
		}

		private sealed class AKIEJKPEIEI
		{
			public Route RRUIShareRoute;

			public RoomCode _003C_003E4__this;

			public bool removeCurrentUriFromHistory;

			public Action<DPKIGFPJMOG> _003C_003E9__1;

			internal void _003CCreateAndShare_003Eb__0(NMLEIPDLABI result)
			{
			}

			internal void _003CCreateAndShare_003Eb__1(DPKIGFPJMOG ev)
			{
			}
		}

		private sealed class HPPMLCCCFCE
		{
			public RoomCodeData roomData;

			public RoomCode _003C_003E4__this;

			public LinkManager.OPICCOMKOOF pendingLink;

			internal void _003CHandle_003Eb__0(DPKIGFPJMOG ev)
			{
			}

			internal void _003CHandle_003Eb__1(bool success)
			{
			}
		}

		private FEIKFKAICHC HKNAHLAFLPC;

		private static bool? PJOOHOLHHOA;

		private RoomCodeData NJFCIBOBLPA;

		private static bool IGCFOMCIPGK(FEIKFKAICHC HKNAHLAFLPC)
		{
			return false;
		}

		public static bool SupportsDirectShareInChat(LCEKCFEIEGJ BBHINKGKDBL, FEIKFKAICHC HKNAHLAFLPC)
		{
			return false;
		}

		public override bool SupportsDirectShareInChat(object DELCOFCGDFF)
		{
			return false;
		}

		private void Awake()
		{
		}

		public override string GetTitleText()
		{
			return null;
		}

		public override OFPDFAGJKLH.DBGOCJDEIIN GetChatShareMessage(NMLEIPDLABI ABPFMLKOJAM, bool MHIOBEJKDFA)
		{
			return null;
		}

		public override global::NCOKFFGPIJM<NMLEIPDLABI> Create(object ADCFFAJGNAM)
		{
			return null;
		}

		public override LAHBDKNMNHN CreateAndShare(Route JGMLNNDKOOH, bool GMEKLDALJKC, object ADCFFAJGNAM)
		{
			return null;
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
