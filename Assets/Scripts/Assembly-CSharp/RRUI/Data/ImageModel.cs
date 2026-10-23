using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ImageModel : RRUIModel
	{
		private sealed class JMGIHAPPNDA
		{
			public int refreshInstanceId;

			public ImageModel _003C_003E4__this;

			internal bool _003CRefreshInternal_003Eb__0()
			{
				return false;
			}
		}

		private sealed class NPFEFPPCOCC
		{
			public Func<bool> shouldUpdateModel;

			public ImageModel modelToUpdate;

			public Func<GDHOAGNFOBD.BAPBAPCBDIJ, bool> _003C_003E9__8;

			internal void _003CRefreshImageModel_003Eb__0(GDHOAGNFOBD.FPPNEFOBPMC image)
			{
			}

			internal void _003CRefreshImageModel_003Eb__1(GDHOAGNFOBD.FPPNEFOBPMC image)
			{
			}

			internal void _003CRefreshImageModel_003Eb__3(List<DFDECAEJBIO> accounts)
			{
			}

			internal void _003CRefreshImageModel_003Eb__4(List<GDHOAGNFOBD.BAPBAPCBDIJ> savedCheer)
			{
			}

			internal bool _003CRefreshImageModel_003Eb__8(GDHOAGNFOBD.BAPBAPCBDIJ sc)
			{
				return false;
			}

			internal void _003CRefreshImageModel_003Eb__5(int cheerCount)
			{
			}

			internal void _003CRefreshImageModel_003Eb__6(JCDPHCELKHI r)
			{
			}

			internal void _003CRefreshImageModel_003Eb__7(IMIJPHJKLIM e)
			{
			}
		}

		private sealed class MJPPFADEIIK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public Func<bool> shouldUpdateModel;

			public ImageModel modelToUpdate;

			private NPFEFPPCOCC _003C_003E8__1;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MJPPFADEIIK(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class NCCLDAHAPBH
		{
			public bool cheeringPhoto;

			public ImageModel _003C_003E4__this;

			public bool useToast;

			internal void _003CToggleImageCheered_003Eb__0()
			{
			}

			internal void _003CToggleImageCheered_003Eb__1(string message)
			{
			}
		}

		private sealed class FGECMNOJJGJ
		{
			public ImageModel _003C_003E4__this;

			public GDHOAGNFOBD.BEMJBPJDCNF targetAccessibility;

			internal void _003CToggleImageAccessibility_003Eb__0()
			{
			}
		}

		private sealed class JBIPLOFHBFK
		{
			public ImageModel _003C_003E4__this;

			public bool browserNavigateBackOnConfirm;

			internal void _003CShowReportImageDialog_003Eg__confirmAction_007C0()
			{
			}

			internal void _003CShowReportImageDialog_003Eb__2()
			{
			}

			internal void _003CShowReportImageDialog_003Eb__3(string message)
			{
			}

			internal void _003CShowReportImageDialog_003Eg__cancelAction_007C1()
			{
			}
		}

		private sealed class HHMPDJBFMAM
		{
			public ImageModel _003C_003E4__this;

			public GDHOAGNFOBD.KEIAPDLHGPG cachedImageHandle;

			internal void _003CPrintImage_003Eb__0(Texture2D imageTexture)
			{
			}

			internal void _003CPrintImage_003Eb__1()
			{
			}
		}

		[SerializeField]
		private string amplitudeCommandContext;

		[SerializeField]
		private UnityEngine.Animation imageCheerAnimation;

		private GDHOAGNFOBD.FPPNEFOBPMC IBJDGNNBIPF;

		private int LBJNAECCLKC;

		private long DAGJCGECEIH;

		private IReadOnlyList<DFDECAEJBIO> LDKAMGNFKOJ;

		private bool IOGJGEBFFNG;

		private bool? OINDJKAMDKE;

		private bool CFGNKHMAKAK;

		private bool MPGNNCNFLJF;

		private bool JPEDNLNMBFE;

		private JKHCJAJHGAO KNDDHGPEFKM;

		private int FKFPLCDPKMI;

		private bool EFCHGPAGNLL;

		private bool FJKIKDDNLAO;

		private JCDPHCELKHI ENHPMBIJPEI;

		private IMIJPHJKLIM CCALDDGMILH;

		private EPILDIJELPG DHAANFNKHAP;

		private string NPOEAPJKNFN;

		private readonly EEANDDJEMJC MGLHOFIGOOK;

		protected KIDPMAMHDFB.PHCMFADNOHN OBLPKOAPPFJ;

public GDHOAGNFOBD.FPPNEFOBPMC Image
{
get 		{
			return null;
		}

private set {
		}
}

public int CheerCount
{
get 		{
			return 0;
		}

private set {
		}
}

public long ImageId
{
get 		{
			return 0L;
		}

private set {
		}
}

public IReadOnlyList<DFDECAEJBIO> TaggedPlayers
{
get 		{
			return null;
		}

private set {
		}
}

public bool CanReportImage
{
get 		{
			return false;
		}

private set {
		}
}

private bool GDBDCDEIBDB
{
get 		{
			return false;
		}

}

private bool GLKMEOGBKHC
{
get 		{
			return false;
		}

}

private bool HIPJOFDOJLM
{
get 		{
			return false;
		}

}

public bool CanPrintImage
{
get 		{
			return false;
		}

}

public bool CanChangeImageAccessibility
{
get 		{
			return false;
		}

}

public bool IsTakenByLocalPlayer
{
get 		{
			return false;
		}

}

public bool IsPublicOrMine
{
get 		{
			return false;
		}

}

public bool HasRoomMetadata
{
get 		{
			return false;
		}

}

public bool HasPublicRoomMetadata
{
get 		{
			return false;
		}

}

public string PublicRoomName
{
get 		{
			return null;
		}

}

public bool HasPublicEventMetadata
{
get 		{
			return false;
		}

}

public string PublicEventName
{
get 		{
			return null;
		}

}

public bool HasPublicClubMetadata
{
get 		{
			return false;
		}

}

public string PublicClubName
{
get 		{
			return null;
		}

}

public bool HasLocalPlayerCheered
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsSelectingProfileImage
{
get 		{
			return false;
		}

set {
		}
}

public bool CanSelectAsProfileImage
{
get 		{
			return false;
		}

}

public bool JustTakenByShareCamera
{
get 		{
			return false;
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

public EEANDDJEMJC ReportEvent
{
get 		{
			return null;
		}

}

		public void Set(string NPOEAPJKNFN, bool EFCHGPAGNLL, bool FJKIKDDNLAO)
		{
		}

		public void Set(long IPLCNNFIFHC, bool EFCHGPAGNLL, bool FJKIKDDNLAO)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		private static IEnumerator<EGGPGCCKPCO> DBMFFGAKGPB(ImageModel NJOMCPPGDBP, Func<bool> MPDNLPHIEIM)
		{
			return null;
		}

		public void LogButtonTelemetry(string EFPCNACDLLD)
		{
		}

		public void ToggleImageCheered(bool CGMGGDBONEE = true)
		{
		}

		public void ToggleImageAccessibility()
		{
		}

		public void ShowReportImageDialog(bool FOPDBCIGBDB = true)
		{
		}

		public void ShowDeleteImageDialog()
		{
		}

		public void PrintImage()
		{
		}

		public void TrySharePhoto()
		{
		}

		public void ShowTaggedPlayersDialog()
		{
		}

		public void TrySetProfileImage()
		{
		}

		private void ACJLPJGMEGN(long IPLCNNFIFHC)
		{
		}

		[CompilerGenerated]
		private void ACHFCGFPGBB()
		{
		}

		[CompilerGenerated]
		private void DNKMDJFOCCF()
		{
		}

		[CompilerGenerated]
		private void PAGELOOKLOC(string OFCFPGACNJB)
		{
		}

		[CompilerGenerated]
		private void FGKDDPHIFMM()
		{
		}

		[CompilerGenerated]
		private void AACCBPJIIIF(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void EKCLKGGKLLJ()
		{
		}
	}
}
