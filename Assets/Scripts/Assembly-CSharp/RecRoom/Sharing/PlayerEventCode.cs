using System;
using RRUI.Navigation;

namespace RecRoom.Sharing
{
	public class PlayerEventCode : ActionCode
	{
		[Serializable]
		private struct CodeData
		{
			public long PlayerEventId;
		}

		private sealed class JOLHJIJDEED
		{
			public IMIJPHJKLIM playerEvent;

			public object args;

			internal NMLEIPDLABI _003CCreate_003Eb__0(NMLEIPDLABI code)
			{
				return default;
			}
		}

		private sealed class BHHKGNCOJGH
		{
			public Route RRUIShareRoute;

			public PlayerEventCode _003C_003E4__this;

			public bool removeCurrentUriFromHistory;

			internal void _003CCreateAndShare_003Eb__0(NMLEIPDLABI result)
			{
			}
		}

		private sealed class AJPIPKICJAF
		{
			public LinkManager.OPICCOMKOOF pendingLink;

			public PlayerEventCode _003C_003E4__this;

			public Action<bool> _003C_003E9__1;

			internal LAHBDKNMNHN _003CHandle_003Eb__0(NCBAEFEDLMK eventDetails)
			{
				return null;
			}

			internal void _003CHandle_003Eb__1(bool success)
			{
			}
		}

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

		public override void CreateButtonPressed()
		{
		}

		public override OFPDFAGJKLH.DBGOCJDEIIN GetChatShareMessage(NMLEIPDLABI ABPFMLKOJAM, bool MHIOBEJKDFA)
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
