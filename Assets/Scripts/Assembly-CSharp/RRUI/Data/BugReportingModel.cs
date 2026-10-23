using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace RRUI.Data
{
	public class BugReportingModel : ListModel
	{
		private sealed class KHIEAIBNLFG
		{
			public bool screenshotTextureAttached;

			public bool limitToSingleScreenshot;

			public BugReportingModel _003C_003E4__this;

			public Texture2D screenshotTexture;

			public DHAPPKCJJCA screenshotDialog;

			public RenderTexture screenshotTempRenderTexture;

			internal void _003CTakeScreenshot_003Eb__0()
			{
			}

			internal void _003CTakeScreenshot_003Eb__1()
			{
			}
		}

		private sealed class LDCLNDAHJDH
		{
			public BugReportingModel _003C_003E4__this;

			public DHAPPKCJJCA confirmationDialog;

			internal void _003CClearReportProgress_003Eb__0()
			{
			}

			internal void _003CClearReportProgress_003Eb__1()
			{
			}
		}

		private sealed class CKGKFAFKGEB
		{
			public IPGOOJIFBAB feedbackDialog;

			public bool success;

			public BugReportingModel _003C_003E4__this;

			internal void _003CShowInitialGameLogReportFeedback_003Eb__0()
			{
			}

			internal void _003CShowInitialGameLogReportFeedback_003Eb__1()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct DFJCKCLDICI : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public BugReportingModel _003C_003E4__this;

			private TaskAwaiter<DPNKKPCMHPE> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const int HBOKKHLLBDO = 2560;

		private const int LJINEPFLGPL = 1440;

		private const int BOBLCPNIKOK = 24;

		private const int DPCGIADPEEP = 1024;

		private const int JGBILABEOIP = 576;

		public const int TITLE_MAXIMUM_LENGTH = 255;

		public const int PHOTO_ATTACHMENTS_MAXIMUM = 10;

		[SerializeField]
		private Material opaqueBlitMaterial;

		[SerializeField]
		private Sprite genericSuccessIcon;

		[SerializeField]
		private Sprite genericFailIcon;

		private Camera NKOGOBKOICH;

		private string HEJBKFDPPID;

		private string GMGPHGGHCIB;

		private KJNNABNBICI FAMIJFLADGP;

		private List<Texture2D> PPGAKBLCIHK;

		private readonly List<byte[]> GNMJOAHCLJB;

		private bool JGEPOLOLMAD;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public string Title
{
get 		{
			return null;
		}

set {
		}
}

public string Description
{
get 		{
			return null;
		}

set {
		}
}

public KJNNABNBICI SelectedSdlcPhase
{
get 		{
			return KJNNABNBICI.PreBVT;
		}

set {
		}
}

public IReadOnlyList<Texture2D> AttachmentImages
{
get 		{
			return null;
		}

}

public bool UseBugKeyWordForGameLog
{
get 		{
			return false;
		}

}

public override bool IsEmpty
{
get 		{
			return false;
		}

}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		protected override void KPOHBHPPGBM()
		{
		}

		private void MCGADPOEILP()
		{
		}

		public void TakeScreenshot(bool FBBHMMCAAHK)
		{
		}

		public void ClearReportProgress()
		{
		}

		public void SubmitGameLogReport()
		{
		}

		private string AGDNKBBKCKB(string COKEHKMDIDL)
		{
			return null;
		}

		private void LFIDLANHAFE(bool EGJEBAFNALL, string NLJOHEKGNDH = null)
		{
		}

		public Task SubmitBug()
		{
			return null;
		}

		private string GPOJHCFHKLC()
		{
			return null;
		}

		private RenderTexture LKOFKPKGJJN()
		{
			return null;
		}

		private Texture2D AJBHOILIMKG(RenderTexture KAACGMLIKHK)
		{
			return null;
		}

		[CompilerGenerated]
		private void HDBBPEPGAJL(string COKEHKMDIDL)
		{
		}

		[CompilerGenerated]
		private void LIJOLEDJDGL()
		{
		}
	}
}
