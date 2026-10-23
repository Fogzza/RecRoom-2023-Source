using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RRUI.Data;
using UnityEngine;

namespace RecRoom.Tutorials
{
	public class MakerPenIntro : MonoBehaviour, MAJPKEBMCFC, PMCNOFPBHIG
	{
		private sealed class OADKIBPNDND : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MakerPenIntro _003C_003E4__this;

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
			public OADKIBPNDND(int _003C_003E1__state)
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

		private sealed class GFPGDOBPGOK
		{
			public ConfirmationModel confirmationModel;

			public Action onCancel;

			public Action onExitTutorial;

			public Action onContinue;

			internal void _003CDisplayContinueFlowDialogue_003Eb__4()
			{
			}

			internal void _003CDisplayContinueFlowDialogue_003Eb__5()
			{
			}

			internal void _003CDisplayContinueFlowDialogue_003Eb__0(UriPropagatedDataModel initializedModel)
			{
			}

			internal void _003CDisplayContinueFlowDialogue_003Eg__Cancel_007C1(bool dismiss)
			{
			}

			internal void _003CDisplayContinueFlowDialogue_003Eg__ExitTutorial_007C2()
			{
			}

			internal void _003CDisplayContinueFlowDialogue_003Eg__Continue_007C3()
			{
			}
		}

		private sealed class APNJBPCABBD
		{
			public Tool makerPenTool;

			internal bool _003CEquipMakerPen_003Eb__0()
			{
				return false;
			}
		}

		private sealed class NJABGDNHNEM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			private APNJBPCABBD _003C_003E8__1;

			private Player _003Cplayer_003E5__2;

			private PlayerHand _003Chand_003E5__3;

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
			public NJABGDNHNEM(int _003C_003E1__state)
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

		[SerializeField]
		private SurfacePlacementIndicator surfaceIndicator;

		[SerializeField]
		private MakerPenIntroOpenMenu openMakerPenMenuPrompt;

		[SerializeField]
		private MakerPenIntroTutorialPrompt initialTutorialPrompt;

		[SerializeField]
		private MakerPenIntroOpenMenuPrompt openMenuPrompt;

		[SerializeField]
		private MakerPenIntroPressButtonStep pressPaletteButton;

		[SerializeField]
		private MakerPenIntroPressButtonStep pressPropsButton;

		[SerializeField]
		private MakerPenIntroPressButtonStep selectProp;

		[SerializeField]
		private MakerPenIntroPlacePropPrompt placePropPrompt;

		[SerializeField]
		private MakerPenIntroTransformIntro transformIntro;

		[SerializeField]
		private MakerPenIntroTransformMove transformMove;

		[SerializeField]
		private MakerPenIntroTransformRotate transformRotate;

		[SerializeField]
		private MakerPenIntroTransformScale transformScale;

		[SerializeField]
		private MakerPenIntroOpenMenuPrompt postTransformOpenMenu;

		[SerializeField]
		private MakerPenIntroDeleteButton deleteButton;

		[SerializeField]
		private MakerPenIntroUndoButton undoButton;

		[SerializeField]
		private MakerPenIntroSnappingSimple snappingSimple;

		[SerializeField]
		private MakerPenIntroGridSimple gridSimple;

		[SerializeField]
		private MakerPenIntroSaving saving;

		[SerializeField]
		private MakerPenIntroTutorialComplete tutorialComplete;

		[SerializeField]
		private string resumePopupTitle;

		[TextArea]
		[SerializeField]
		private string resumePopupText;

		[SerializeField]
		private string resumePopupExitButton;

		[SerializeField]
		private string resumePopupContinueButton;

		private bool LPOOJLHHGGJ;

		private bool MKNOLGONFGE;

		private bool GENMAAHIGLN;

		private LJBNECHALJM MOKMOMIMMAP;

		private LKDMDLACMHN KLPJCNPJHEA;

		private IBBJEKFHEHP KOCEBFDCIGD;

		private bool BINEBDPPLAO;

		private bool PHBIHODBCCG;

		private bool HLKKKPJMKJH;

		private JNODIIINKKJ.PBDGIEELIHN AFHLKHJLGAK;

		private Action NDPGNHABKDE__BackingField;

public string TutorialName
{
get 		{
			return null;
		}

}

public string TutorialNameSnakeCase
{
get 		{
			return null;
		}

}

public bool Finished
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsInitialized
{
get 		{
			return false;
		}

private set {
		}
}

public int Priority
{
get 		{
			return 0;
		}

}

public bool OnlyRunAsTheFirstTutorialOfTheSession
{
get 		{
			return false;
		}

}

public bool IsActive
{
get 		{
			return false;
		}

}

public bool HasSnappingModeOverride
{
get 		{
			return false;
		}

private set {
		}
}

public JNODIIINKKJ.PBDGIEELIHN SnappingModeOverride
{
get 		{
			return JNODIIINKKJ.PBDGIEELIHN.NO_SNAPPING;
		}

private set {
		}
}

public bool ApplyGridSnappingOverride
{
get 		{
			return false;
		}

}

public float GridSnappingSize
{
get 		{
			return 0f;
		}

}

public event Action TutorialStarted {
add {
		}
remove {
		}
}

		private void Awake()
		{
		}

		public void RunTutorial()
		{
		}

		public void HideTutorial()
		{
		}

		public void Init()
		{
		}

		public void StartFlow()
		{
		}

		public void CancelFlow()
		{
		}

		public void ResetState()
		{
		}

		public void SetSnappingModeOverride(JNODIIINKKJ.PBDGIEELIHN GLMKCLLFLBE)
		{
		}

		public void RemoveSnappingModeOverride()
		{
		}

		public void NotifyAboutObjectCreation(RuntimeSpawnableToolConfig PNIFPJCIBBO)
		{
		}

		public void ShowSurfacePlacementIndicator(Vector3 INLGLHIPOMC)
		{
		}

		public void HideSurfacePlacementIndicator()
		{
		}

		public void ToggleSurfacePlacementIndicator(bool FBHDABEFLKL)
		{
		}

		private IEnumerator<EGGPGCCKPCO> JGONFPPMDPK()
		{
			return null;
		}

		private void LNGMMMGOCAM(Action IADAEHBPOIL, Action KANPOCECECA, Action ICIJNFGMPCA)
		{
		}

		private IEnumerator<EGGPGCCKPCO> LKKAFDBCJDD()
		{
			return null;
		}

		[CompilerGenerated]
		private void DMDGICEMMOH(JDEBFBMMLBK CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void HAHMLKCFLCN()
		{
		}

		[CompilerGenerated]
		private void GNOEBDCLBMF()
		{
		}

		[CompilerGenerated]
		private void JBOOKHNFPEE()
		{
		}
	}
}
