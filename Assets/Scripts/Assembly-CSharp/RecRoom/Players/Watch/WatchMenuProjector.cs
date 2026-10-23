using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.AGUI;
using UnityEngine;

namespace RecRoom.Players.Watch
{
	public class WatchMenuProjector : MenuProjector, HENLAGEACNC
	{
		public enum NKNEMPIFGPD
		{
			Hidden = 0,
			Hydrate = 1,
			Visible = 2,
			Dehydrate = 3,
			PlayerMenu_Transition = 4,
			PlayerMenu_Refresh = 5,
			PlayerMenu_KeyboardActive = 6,
			PlayerMenu_KeyboardInactive = 7
		}

		private sealed class PDNLHPNCOFB : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WatchMenuProjector _003C_003E4__this;

			public float duration;

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
			public PDNLHPNCOFB(int _003C_003E1__state)
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

		private const float MNGGKFBIGDD = 0.5f;

		[SerializeField]
		private GameObject projectionRoot;

		[SerializeField]
		private GameObject keyboardRoot;

		[SerializeField]
		private GameObject XLKeyboardRoot;

		[SerializeField]
		private Renderer projectionRenderer;

		[SerializeField]
		private TapToOpenVisual watchVisualLocalPrefab;

		[SerializeField]
		private TapToOpenVisual watchVisualRemotePrefab;

		[SerializeField]
		private Transform remoteVisualRoot;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private WatchGazeTracker watchGazeTracker;

		[SerializeField]
		private Transform leftHandWatchAnchor;

		[SerializeField]
		private Transform rightHandWatchAnchor;

		public readonly global::HHOBPMOCKMJ<bool> MenuDetachedChangedAction;

		public readonly global::HHOBPMOCKMJ<bool> MenuOpenChangedAction;

		public readonly global::HHOBPMOCKMJ<bool> MenuHydrateDehydrateAction;

		public EEANDDJEMJC WatchMenuAnimationNowVisible;

		private Action<bool> OAOODGOEKBN;

		[NonSerialized]
		public bool WatchGazeOpeningEnabled;

		private float NNFMKMKILDL;

		private Coroutine MACPJFBBLIH;

		private Dictionary<int, NKNEMPIFGPD> OFEMBBNDNMM;

		private Vector3 KMBIJLGIOKK;

		private bool IFFGEBJJALD;

		private FIHGBEHGLGB LBGLBKPMJAP;

		private FIHGBEHGLGB EFFDADGLBCF;

		private Player JCPLJCIFGFK;

		private global::MOBDJNEDDKC<bool> IGEFKPAIKKG;

		private global::MOBDJNEDDKC<bool> JDPNJEMKDLO;

		private TapToOpenVisual HHPCNCCNHLC;

		private global::KPBNLENPEPO<bool, Vector3, Quaternion, float> CEFGHKELPJH;

		private NKNEMPIFGPD? AFOMIILBELM;

public Player Player
{
get 		{
			return null;
		}

private set {
		}
}

public Renderer ProjectionRenderer
{
get 		{
			return null;
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

private bool PMJPAJEFLMH
{
get 		{
			return false;
		}

set {
		}
}

public TapToOpenVisual WatchVisual
{
get 		{
			return null;
		}

private set {
		}
}

public WatchGazeTracker WatchGazeTracker
{
get 		{
			return null;
		}

}

public PlayerHand AttachedHand
{
get 		{
			return null;
		}

set {
		}
}

public bool AttachedToWrist
{
get 		{
			return false;
		}

}

private Vector3 PFPPMADHGKJ
{
get 		{
			return default;
		}

}

public bool IsMenuAnimationVisible
{
get 		{
			return false;
		}

}

public NKNEMPIFGPD MenuAnimationState
{
get 		{
			return NKNEMPIFGPD.Hidden;
		}

}

public bool ForceMenuToRemainOpen
{
get 		{
			return false;
		}

}

 Transform global::HENLAGEACNC.KeyboardAnchor
{
get 		{
			return null;
		}

}

 bool global::HENLAGEACNC.ShouldKeyboardBeVisible
{
get 		{
			return false;
		}

}

		protected void Awake()
		{
		}

		private void Start()
		{
		}

		protected void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void PHCFGDHNIDC()
		{
		}

		private void IPBLJHFDKDO()
		{
		}

		private void AHOCKACKKGI()
		{
		}

		private void NIIMOJCLLDM()
		{
		}

		private void MJOPDLCLNJC(Player EKOFNPFCLMO, Vector3 OJJNPNOEJDC, Vector3 NHOAENGJMLK)
		{
		}

		private void AAOFGNNAFFF()
		{
		}

		private void LJNOHPPOMNP()
		{
		}

		private void PPKOLGPELII()
		{
		}

		public void UpdateControls(bool NNNNPHAGHFH, bool ODCJCCJOKPL, bool CPOGKGBDCBN, bool NDOFBHBOPIF)
		{
		}

		public void AuthorityOpenMenuAttached(PlayerHand PMNLJGLDMJN, bool COPOILGLIAJ = false)
		{
		}

		public void AuthorityOpenMenuDetached(bool COPOILGLIAJ = false)
		{
		}

		public void AuthorityOpenMenuDetached(Vector3 INLGLHIPOMC, bool COPOILGLIAJ)
		{
		}

		public void AuthorityOpenMenuDetached(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO, bool COPOILGLIAJ)
		{
		}

		public void AuthorityDetachMenu()
		{
		}

		public void AuthorityReattachMenu()
		{
		}

		public void AuthorityCloseMenu()
		{
		}

		private void BNJBPHJPJPO(Vector3 DILCIPNLOGC, Quaternion CGMFAEGBIKB, float IHNJLJDHHKN)
		{
		}

		private void HOKLBLFFDHD()
		{
		}

		private void AENCDHBBKCK()
		{
		}

		public void SetForceMenuToRemainOpen(bool ICNBKBGJJDJ, object IALNODEHBNN)
		{
		}

		public void SetCustomSetChildrenActiveBehaviour(Action<bool> NPODHMILIGI)
		{
		}

		private void MNKHNNOGKMJ(bool FBHDABEFLKL)
		{
		}

		public void TriggerTransition()
		{
		}

		public void TriggerRefresh()
		{
		}

		public void ShowProjectionVisuals(object IALNODEHBNN)
		{
		}

		public void HideProjectionVisuals(object IALNODEHBNN)
		{
		}

		private void AHAAAFJFJDP(bool BMGEHFPFCBJ, object IALNODEHBNN)
		{
		}

		private void HGNFCIHHGGL(float FGBPJMKCMAO)
		{
		}

		private IEnumerator CJPNCADNKMK(float FGBPJMKCMAO)
		{
			return null;
		}

		private void EKKIAAEDDIO(Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI, float KIJDIOHEBHG)
		{
		}

		private bool LLJLMHOCJLF()
		{
			return false;
		}

		private void HKGGCMMICFL()
		{
		}

		private void BMEJNMGAACE()
		{
		}

		void HENLAGEACNC.OnKeyboardAttached()
		{
			//ILSpy generated this explicit interface implementation from .override directive in BMEJNMGAACE
			this.BMEJNMGAACE();
		}

		[CompilerGenerated]
		private void CLLBMLHCJBN()
		{
		}
	}
}
