using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Avatars.Data.Runtime;
using RecRoom.Core.Imposters;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RRUI.Data
{
	public class CustomAvatarItemDetailsModel : CustomAvatarItemModel
	{
		private sealed class BCIOMNPCHEE
		{
			public byte[] designPng;

			public byte[] thumbnailPng;

			public int baseAvatarItemId;

			public CustomAvatarItemDetailsModel _003C_003E4__this;

			internal void _003CInternalSaveCustomAvatarItem_003Eb__2(byte[] png)
			{
			}

			internal void _003CInternalSaveCustomAvatarItem_003Eb__4(byte[] png)
			{
			}

			internal global::NCOKFFGPIJM<LINLOKECLME> _003CInternalSaveCustomAvatarItem_003Eb__5(byte[] _)
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct NKIFIPPGLLI : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CustomAvatarItemDetailsModel _003C_003E4__this;

			private AvatarItem _003CbaseAvatarItem_003E5__2;

			private GameObject _003Cimposter_003E5__3;

			private RenderTexture _003CrenderTexture_003E5__4;

			private TaskAwaiter<GameObject> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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

		private Color NPDOGKKCFNO;

		private Texture2D NBBJKNHIFEN;

		private ManagedTexture MDNCPEOLOJF;

		private Lazy<IILDCCEMGBA> PBGJGLECDCA;

		[SerializeField]
		private string openCoCWebpageTitleText;

		[SerializeField]
		private string openCoCWebpageMessageText;

		[SerializeField]
		private ImposterRenderConfig thumbnailRenderConfig;

		private bool PILAANBLHCN;

		private MessageDialogModel AFBMIKGKBGL;

		private IPGOOJIFBAB FAOPHMJHFKK;

		private CancellationTokenSource FNOELDKJMNH;

		private IPGOOJIFBAB OIPOMJPJNJK;

		private IPGOOJIFBAB CDPODJIFEFL;

		private IPGOOJIFBAB GNACBLIJPHJ;

		private DHAPPKCJJCA BBCGEIINFJK;

public bool ShouldSaveButtonBeInteractable
{
get 		{
			return false;
		}

}

public bool ShouldUpsellRRPlus
{
get 		{
			return false;
		}

}

public bool IsEditingNonPublishedCustomAvatarItem
{
get 		{
			return false;
		}

}

public Color CustomAvatarItemBaseColor
{
get 		{
			return default;
		}

private set {
		}
}

public Texture2D CustomAvatarItemThumbnail
{
get 		{
			return null;
		}

private set {
		}
}

public RenderTexture CustomAvatarItemDesign
{
get 		{
			return null;
		}

}

private IILDCCEMGBA LCPOIILBNLD
{
get 		{
			return null;
		}

}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void Set(ManagedTexture HAIIBGAPAGB, Color HMCAFGCGFJF, PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG = PJGPBJDBNEK.BDOPNLLKBPB.None)
		{
		}

		public void SaveCustomAvatarItem()
		{
		}

		private void CIJOBNGGIEN()
		{
		}

		private void DBKMONOKJCK()
		{
		}

		public void DeleteCustomAvatarItem()
		{
		}

		protected override void CCFANAFACDK(LINLOKECLME LNKODFBLOKJ)
		{
		}

		private Task EHNBJMNDMDM()
		{
			return null;
		}

		private void AHGMFELDCHJ()
		{
		}

		private void ILFFNLGGHDO()
		{
		}

		private void NHNABLDMIKO()
		{
		}

		private void ADMLAIGAHGA()
		{
		}

		private void EHCAICJPBNH()
		{
		}

		public void ShowPermissionDialogPopUp()
		{
		}

		[CompilerGenerated]
		private void EDLNGPIGLME()
		{
		}

		[CompilerGenerated]
		private void MBCBKGCJNGI()
		{
		}

		[CompilerGenerated]
		private void LOONINCECPK()
		{
		}

		[CompilerGenerated]
		private void FJBIPBGBIEC(BaseDialogModel<IPGOOJIFBAB> DKIIJDODEMG)
		{
		}

		[CompilerGenerated]
		private void AOLAEIGFGGE(LINLOKECLME ONCGIPFNENB)
		{
		}

		[CompilerGenerated]
		private void KBJHKLFABGE()
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<byte[]> GNHMHPNMIGG(byte[] GADDGJANIGG)
		{
			return null;
		}

		[CompilerGenerated]
		private void MBGOIADIAPD(LINLOKECLME ONCGIPFNENB)
		{
		}

		[CompilerGenerated]
		private void FCMPJGEMNIB()
		{
		}

		[CompilerGenerated]
		private void GHCIEALBDGM()
		{
		}

		[CompilerGenerated]
		private void DPKDKFPELPF()
		{
		}

		[CompilerGenerated]
		private void IOJBPCACBAG()
		{
		}

		[CompilerGenerated]
		private void IDAPJLAAEKF()
		{
		}

		[CompilerGenerated]
		private void PGPHJPGNMKJ()
		{
		}

		[CompilerGenerated]
		private bool AIOONJNMHPA(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
			return false;
		}

		[CompilerGenerated]
		private void HDJMLBJFNGC()
		{
		}

		[CompilerGenerated]
		private void BCDDALBBJFD()
		{
		}

		[CompilerGenerated]
		private object AOOCANFCABM()
		{
			return null;
		}

		[CompilerGenerated]
		private void JCLOCJGMEEI(object FDAIMOMOHIG)
		{
		}
	}
}
