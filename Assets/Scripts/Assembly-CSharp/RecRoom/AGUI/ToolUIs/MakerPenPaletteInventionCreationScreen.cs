using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using RecRoom.Core.Creation;
using RecRoom.Utils.Image;
using TMPro;
using UnityEngine;

namespace RecRoom.AGUI.ToolUIs
{
	public class MakerPenPaletteInventionCreationScreen : MakerPenPaletteUIFlowBase
	{
		private struct BIOHHJLCDLA
		{
			public OEBAEGDPBLA IKPNKMMNJNA;

			public string PPPIABKMNIH;

			public string EGLLIKNOMIP;

			public DHJLEHBOGBG[] MAMIBICDLAK;

public long? CGJHNALGPFH
{
get 			{
				return null;
			}

}
		}

		private sealed class IBFMBCNBMAC
		{
			private sealed class _003C_003CShowTakePictureDialog_003Eg__CancelInventionCreationAndPickupMakerPen_007C2_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public IBFMBCNBMAC _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CShowTakePictureDialog_003Eg__CancelInventionCreationAndPickupMakerPen_007C2_003Ed(int _003C_003E1__state)
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

			public MakerPenPaletteInventionCreationScreen _003C_003E4__this;

			public BIOHHJLCDLA context;

			public Action _003C_003E9__3;

			internal void _003CShowTakePictureDialog_003Eb__0()
			{
			}

			internal IEnumerator<EGGPGCCKPCO> _003CShowTakePictureDialog_003Eg__CancelInventionCreationAndPickupMakerPen_007C2()
			{
				return null;
			}

			internal void _003CShowTakePictureDialog_003Eb__1(RenderTexture renderTex)
			{
			}

			internal void _003CShowTakePictureDialog_003Eb__3()
			{
			}

			internal bool _003CShowTakePictureDialog_003Eg__TryGrabMakerPen_007C5(PlayerHand hand)
			{
				return false;
			}
		}

		private sealed class MAPHOANOEED
		{
			public MakerPenPaletteInventionCreationScreen _003C_003E4__this;

			public long targetInventionId;

			public Action<string> _003C_003E9__2;

			internal void _003CUpdateInventionImage_003Eb__0(string error)
			{
			}

			internal void _003CUpdateInventionImage_003Eb__1(string imageName)
			{
			}

			internal void _003CUpdateInventionImage_003Eb__2(string error)
			{
			}
		}

		private const int MKJMMOLIFKA = 2;

		[SerializeField]
		private GameObject instructionsSubscreen;

		[SerializeField]
		private GameObject resultSubscreen;

		[SerializeField]
		private Button3D nextButton;

		[SerializeField]
		private GameObject deselectContainer;

		[SerializeField]
		private TextMeshProUGUI mainText;

		[SerializeField]
		private TextMeshProUGUI objectCountText;

		[SerializeField]
		private TextMeshProUGUI resultText;

		[SerializeField]
		private float minUpdateInventionInterval;

		[SerializeField]
		private EnterInventionNameDialog enterInventionNameDialog;

		[SerializeField]
		private EnterInventionDescriptionDialog enterInventionDescriptionDialog;

		private OEBAEGDPBLA HGKKLODLHNC;

		private readonly ManagedTexture DGAGIFCLLPF;

		private string LEJMENICLLJ;

		private string FLHPCHFDAML;

		private float PMJADHJLHOH;

		private bool LDJGPPMMDLL;

		private bool NIDGIHJDDBF;

		private Guid FGCKBNAKAFN;

		private List<DHJLEHBOGBG> GJHKADIKJMI;

		private GAKCKDDEEIK MBDJEOJKIPB;

		private bool FAEJHEOBAFI;

		private bool JCKFOJLOMMP;

		private UIDialog<OEBAEGDPBLA, HENPPMLGJNP> OPPDAJHCKEM;

		private bool MAFIFKNHLOB;

		public static void PopScreenAndSubScreensFromMenu(StackedUIBase GHEKMMAFLHA)
		{
		}

		public static bool IsInventionCreationScreenOrSubScreen(StackedUIFlowBase ELNPJBMKDAE)
		{
			return false;
		}

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OCFMEFDFNJH(bool GJGODIHKAHN)
		{
		}

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		private void FEKNAMLKHJJ(bool FAEJHEOBAFI)
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		public void Button_Done()
		{
		}

		public void Button_Cancel()
		{
		}

		public void Button_DeselectObjectsThatPreventSaving()
		{
		}

		public void SetSelectionPrevalidated(bool CCOMONEJEGO)
		{
		}

		public void SetSkipObjectSelection(bool LOHCDOECAMB)
		{
		}

		public void ResetToInitialState()
		{
		}

		public void SetCancelOnReturnToMainScreen(bool NIDGIHJDDBF)
		{
		}

		private void LLLKJMKDEFP()
		{
		}

		private void DAHHHOIHANG()
		{
		}

		private void PMICECGGJOG()
		{
		}

		private bool DKIFPOGHCIO(BIOHHJLCDLA DELCOFCGDFF)
		{
			return false;
		}

		private void PNPDANJCBCK()
		{
		}

		private void HCIKFMIADBB(long OKEABHINDCP)
		{
		}

		private void JAGKEDEPBAJ(long OKEABHINDCP)
		{
		}

		private void LIJMNKBDMIB(CreationManager.HGDLKGAFGLC.PODFOMGJNCI MLDANHIGANI)
		{
		}

		private void JJMKONHMOLL(CreationManager.HGDLKGAFGLC.PODFOMGJNCI MLDANHIGANI)
		{
		}

		private void NJCHEFBNILH(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		private void FNJMAFIGDAA(string HLIGBKANEEA)
		{
		}

		private void BMNKOEHFDFC(DHJLEHBOGBG ICHBECDKHOJ, bool KCAPLJEHMMI)
		{
		}

		private void HHLDDEGPLKP(FBEHJNCKJPN CIMCLAFMGFE, HHNPLBOFAGE IACECANFEKI)
		{
		}

		public void SetTargetInvention(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		private void KAMIKBEIDHF(int NFHBKPDBBIM)
		{
		}

		private static bool PGNLCMJMHEN(StackedUIFlowBase ELNPJBMKDAE)
		{
			return false;
		}

		private void EOCIMFOPPCC(bool CCOMONEJEGO)
		{
		}

		[CompilerGenerated]
		private void GDIACPJMAAH(HENPPMLGJNP FEGCJGMIGKM)
		{
		}

		[CompilerGenerated]
		private void HHIGFBPPJCM()
		{
		}

		[CompilerGenerated]
		private void LHABGHKDMIB(HGKINAOMNIF MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void JEHMPCEIMKL(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void CDOIHABJINN(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void JFJELMBOHFL(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		[CompilerGenerated]
		private void IENFEJOJJHN(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		[CompilerGenerated]
		private void DFNBMDAIGNA()
		{
		}

		[CompilerGenerated]
		private void JKAPEPDKEHF()
		{
		}
	}
}
