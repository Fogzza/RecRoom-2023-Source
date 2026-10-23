using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RecRoom.Players.Watch;
using UnityEngine;

namespace RecRoom.AGUI
{
	public class ToolMenuProjector : MenuProjector
	{
		public enum GEECNBHFPDG
		{
			Hidden = 0,
			Hydrate = 1,
			Visible = 2,
			Dehydrate = 3,
			PlayerMenu_Transition = 4,
			PlayerMenu_Refresh = 5
		}

		private sealed class MOIBPFAEOIE : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ToolMenuProjector _003C_003E4__this;

			public float duration;

			private ToolUI _003CtoolMenu_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MOIBPFAEOIE(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private Transform menuAnchor;

		[SerializeField]
		private GameObject projectionRoot;

		[SerializeField]
		private GameObject screenRoot;

		[SerializeField]
		private Renderer projectionRenderer;

		[SerializeField]
		private WatchGazeTracker.GazeParameters menuOpenParameters;

		[SerializeField]
		private WatchGazeTracker.GazeParameters menuCloseParameters;

		[SerializeField]
		private float menuDistanceFromProjectionRoot;

		[SerializeField]
		private TapToOpenVisual dwellVisual;

		[SerializeField]
		private Transform localMenuRoot;

		[SerializeField]
		private Transform remoteMenuRoot;

		[SerializeField]
		private bool menuOpenDwellEnabled;

		[SerializeField]
		private float menuOpenDwellDuration;

		[SerializeField]
		private bool detachMenuOnUnlockButtonPressed;

		[SerializeField]
		private bool dismissMenuWhenNotGazing;

		[SerializeField]
		private Vector3 attachedLocalPosition;

		[SerializeField]
		private Vector3 attachedLocalAngles;

		[SerializeField]
		private bool detachOnKeyboardAutoOpen;

		[SerializeField]
		private bool toolMenuProjectorVRIgnoreParentToolScale;

		private float BFIMNAPCNBP;

		private Coroutine JNDMNMNBGFK;

		private bool FPDHOOLFOPO;

		private bool JKBEHOGDEMP;

		private float KGJKEGNMEPK;

		private bool GDNNFKNHCNF;

		private float HCOCFBBGAIF;

		private Vector3 LBBJHFHGHBE;

		private Vector3 LILCKDIHMMG;

		private Vector3 IFJLJNLMMFM;

		private Vector3 GBDEHOGOHNF;

		private readonly Dictionary<int, GEECNBHFPDG> OFEMBBNDNMM;

		private Animator PEOHIKKGEKN;

		private Tool GAPEICCMANI;

		private bool NLOOLLLBCLB;

		[NonSerialized]
		public bool GazeOpenSupported;

		public bool ForceMenuClose;

		private global::MOBDJNEDDKC<bool> OGPEGMPOECF;

		private bool LIFJGFLMMLJ;

		[SerializeField]
		private bool shouldUseNetworkVisibility;

		public readonly global::HHOBPMOCKMJ<bool> MenuOpenChangedAction;

		public readonly global::HHOBPMOCKMJ<bool> MenuHydrateDehydrateAction;

		private global::MDAHOKBAGPC<bool, Vector3, Quaternion> DAAHEPILHBP;

		public readonly EEANDDJEMJC ProjectorDetachInfoChangedEvent;

		private Action<bool> OAOODGOEKBN;

		public Func<bool> TapToOpenToolEnabledCallback;

		private Sprite GFLKOLMKJBC;

private Animator CIOPHAMGMHB
{
get 		{
			return null;
		}

set {
		}
}

public Tool Tool
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsMenuOpen
{
get 		{
			return false;
		}

private set {
		}
}

public bool DismissMenuWhenNotGazing
{
get 		{
			return false;
		}

set {
		}
}

public TapToOpenVisual TapToOpenToolVisual
{
get 		{
			return null;
		}

}

public bool IsMenuVisible
{
get 		{
			return false;
		}

set {
		}
}

public bool TapToOpenToolEnabled
{
get 		{
			return false;
		}

}

public bool IsAttachedToTool
{
get 		{
			return false;
		}

}

public Vector3 DetachedPosition
{
get 		{
			return default;
		}

}

public Quaternion DetachedRotation
{
get 		{
			return default;
		}

}

public Sprite Sprite
{
get 		{
			return null;
		}

set {
		}
}

public override Transform ScreensAnchorRoot
{
get 		{
			return null;
		}

}

public bool IsMenuAnimationVisible
{
get 		{
			return false;
		}

}

public GEECNBHFPDG MenuAnimationState
{
get 		{
			return GEECNBHFPDG.Hidden;
		}

}

private bool CCLNNCKJGBM
{
get 		{
			return false;
		}

}

private Transform KOCOPCJGING
{
get 		{
			return null;
		}

}

private bool JGKLJJFONJM
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void NIAGGANPFDP()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void KANLBNDIAEK()
		{
		}

		public void ForceMenuOpenUntilGazed()
		{
		}

		private bool BJGAHBFJLBO(WatchGazeTracker.GazeParameters HMJOKPKOPCN)
		{
			return false;
		}

		private void LAJBFLKOCKG()
		{
		}

		public void OpenMenuIfOwner(PhysicalButtonBase physicalButtonBase, Player player)
		{
		}

		public void OpenMenu()
		{
		}

		public void CloseMenu()
		{
		}

		private void EIFBCHMJCCB()
		{
		}

		private void NPHIMGHDEIM()
		{
		}

		public void SetCustomSetChildrenActiveBehaviour(Action<bool> NPODHMILIGI)
		{
		}

		private void MNKHNNOGKMJ(bool FBHDABEFLKL)
		{
		}

		private void MBIOLEBFOOM(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private void BOGLMPCCMDC(Tool IEGMBEPJMGC)
		{
		}

		private void FECLHJOGDHF(Tool IEGMBEPJMGC)
		{
		}

		private bool GHCECCNCJCB()
		{
			return false;
		}

		private bool FMKAMJKGONJ()
		{
			return false;
		}

		protected override void EKAOMAJGBIA(bool HBCMKJDHJNJ)
		{
		}

		public void AuthorityDetachMenuFromTool()
		{
		}

		public void AuthorityDetachMenuFromTool(Vector3 DILCIPNLOGC, Quaternion CGMFAEGBIKB)
		{
		}

		public void AuthorityAttachMenuToTool()
		{
		}

		private void DLHKIGGLKPM()
		{
		}

		private void PLGHCHOADBM()
		{
		}

		private void JGGFPLJJEPE()
		{
		}

		private void JPOMDJGGMOM(Player ANINOIFFADJ)
		{
		}

		public void TemporarilyPauseMenuInteraction(float FGBPJMKCMAO)
		{
		}

		private IEnumerator HLPHGCGJFIL(float FGBPJMKCMAO)
		{
			return null;
		}

		[CompilerGenerated]
		private void GIGAMHDOKFC()
		{
		}

		[CompilerGenerated]
		private void CPGJANFKLFP()
		{
		}
	}
}
