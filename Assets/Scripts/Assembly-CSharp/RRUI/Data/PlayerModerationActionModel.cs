using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;

namespace RRUI.Data
{
	public class PlayerModerationActionModel : RRUIModel
	{
		public enum OMNFIELKEAJ
		{
			Warning = 0,
			Report = 1
		}

		private sealed class OCJBGDOCIHP
		{
			public PlayerModerationActionModel _003C_003E4__this;

			public BaseDialogModel<DHAPPKCJJCA> activeDialog;

			internal object _003CShowPrecannedDescriptionsMenu_003Eb__2()
			{
				return null;
			}

			internal void _003CShowPrecannedDescriptionsMenu_003Eb__3(object key)
			{
			}

			internal void _003CShowPrecannedDescriptionsMenu_003Eb__4()
			{
			}

			internal void _003CShowPrecannedDescriptionsMenu_003Eb__1(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class NOMHDCMAINN
		{
			public PlayerModerationActionModel _003C_003E4__this;

			public OMNFIELKEAJ actionType;

			public string amplitudeCommandContext;

			internal void _003COpenModerationActionConfirmationDialog_003Eb__1()
			{
			}

			internal void _003COpenModerationActionConfirmationDialog_003Eb__2()
			{
			}

			internal void _003COpenModerationActionConfirmationDialog_003Eb__0(BaseDialogModel<IPGOOJIFBAB> dialogModel)
			{
			}
		}

		private sealed class GOLJPOMBKCD
		{
			public PlayerModerationActionModel _003C_003E4__this;

			public string amplitudeCommandContext;

			internal void _003CIssueWarning_003Eb__0(FOKGKPOPJPF result)
			{
			}
		}

		private sealed class FBKDMOGBJDG
		{
			public PlayerModerationActionModel _003C_003E4__this;

			public bool playerPresent;

			public string amplitudeCommandContext;

			internal void _003CReportPlayer_003Eb__0(BJMGAOAAKMM result)
			{
			}
		}

		public const string ACCOUNT_ID_URI_KEY = "AccountId";

		public const string ACCOUNT_DISPLAY_NAME_URI_KEY = "AccountDisplayName";

		public const string AMPLITUDE_COMMAND_CONTEXT_URI_KEY = "AmplitudeCommandContext";

		public const int CUSTOM_REPORT_DESCRIPTION_MAX_LENGTH = 1000;

		private MessageDialogModel FAPJFJHFGLO;

		private IPGOOJIFBAB MKAJFEFEAPH;

		private OMNFIELKEAJ DGGHMHICGGL;

		private int MBAAIINANMC;

		private string GPMFCHIGNJL;

		private IBPKDJLFBHM.OMLBCKDFMHL BEEMIJPBGBA;

		private string DDHMFAPFMDE;

		private string BDMCPLONLJD;

public string AccountDisplayName
{
get 		{
			return null;
		}

}

public IBPKDJLFBHM.OMLBCKDFMHL ReportCategory
{
get 		{
			return IBPKDJLFBHM.OMLBCKDFMHL.Unknown;
		}

set {
		}
}

public string PrecannedDescription
{
get 		{
			return null;
		}

set {
		}
}

public string CustomDescription
{
get 		{
			return null;
		}

set {
		}
}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void Set(int EJIHLJJMOBD, string MGFBHPPJIHK)
		{
		}

		public void ShowPrecannedDescriptionsMenu()
		{
		}

		private IList<string> DHPMMPLJMNE()
		{
			return null;
		}

		public void OpenModerationActionConfirmationDialog(string LDPCFDMCJLH, OMNFIELKEAJ PDJADLFJKHE)
		{
		}

		private void EDJJMAKDKHK(string LDPCFDMCJLH)
		{
		}

		private void GAGADONGEIB(string LDPCFDMCJLH)
		{
		}

		private void HEMKOBLJGIL(string LDPCFDMCJLH)
		{
		}

		private void DCANABBKNCD(string LDPCFDMCJLH)
		{
		}

		[CompilerGenerated]
		private void MADAOLEHDJC()
		{
		}

		[CompilerGenerated]
		private void JKFMDJOIHDI(string NLJOHEKGNDH)
		{
		}
	}
}
