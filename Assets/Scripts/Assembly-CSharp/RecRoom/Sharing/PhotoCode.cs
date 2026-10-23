using System;
using RRUI.Navigation;
using UnityEngine;

namespace RecRoom.Sharing
{
	public class PhotoCode : ActionCode
	{
		[Serializable]
		private struct CodeData
		{
			public long ImageId;
		}

		private sealed class OBNNMNOCCPA
		{
			public Route RRUIShareRoute;

			public PhotoCode _003C_003E4__this;

			public bool removeCurrentUriFromHistory;

			public Action<DPKIGFPJMOG> _003C_003E9__1;

			internal void _003CCreateAndShare_003Eb__0(NMLEIPDLABI result)
			{
			}

			internal void _003CCreateAndShare_003Eb__1(DPKIGFPJMOG ev)
			{
			}
		}

		private sealed class GOGLGGIIIAG
		{
			public CodeData codeData;

			public LinkManager.OPICCOMKOOF pendingLink;

			public PhotoCode _003C_003E4__this;

			internal void _003CHandle_003Eb__0(DPKIGFPJMOG ev)
			{
			}

			internal void _003CHandle_003Eb__1(bool success)
			{
			}
		}

		public const string PHOTO_LINK_EXPERIMENT_NAME = "social_q2_photo_content_linking_in_chat";

		public const string PHOTO_LINK_PARAMETER_NAME = "show_share_in_chat_button";

		private FEIKFKAICHC HKNAHLAFLPC;

		private bool? PJOOHOLHHOA;

		[SerializeField]
		private Route photoDetailsRoute;

		private CodeData NJFCIBOBLPA;

private bool IGCFOMCIPGK
{
get 		{
			return false;
		}

}

public override OFPDFAGJKLH.BLBMLHFICJK MessageContentType
{
get 		{
			return OFPDFAGJKLH.BLBMLHFICJK.Text;
		}

}

public override bool SupportsShareWithCode
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		public override bool SupportsDirectShareInChat(object DELCOFCGDFF)
		{
			return false;
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
