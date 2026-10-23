using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom
{
	public class LocalPlayerController : InjectedSingletonMonoBehaviour<CPBPJLLMKDB, LocalPlayerController>, CPBPJLLMKDB
	{
		private enum ADLGEHKGLIC
		{
			APP_INITIALIZING = 0,
			PLAYER_INITIALIZED = 1
		}

		private sealed class OFJOPIDNNPG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float numSeconds;

			public LocalPlayerController _003C_003E4__this;

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
			public OFJOPIDNNPG(int _003C_003E1__state)
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

		private const string PHBIMAPIAFG = "+forcemode:";

		private const string HJNDLCGJNBH = "+mode:";

		private const string PBCMBCFPAIE = "screen";

		private const string NKBMBKHMOFF = "vr";

		[SerializeField]
		private VRPlayerController vrPlayerController;

		[SerializeField]
		private VRTitleScreenController vrLoginPlayerController;

		[SerializeField]
		private ScreenPlayerController screenController;

		[SerializeField]
		private ScreenTitleScreenController screenUILoginScreenController;

		private ADLGEHKGLIC DADHJJNJEFA;

		private ONDBFDFPGBE DKGIMMOJOLK;

		private ONDBFDFPGBE BELHDNFNNEL;

		private MJLJBHNFNAP APPHJBDKCLA;

		private bool JPMBAMKOHDF;

		private PlayerController NLDFOMHEMGB;

		private bool BEIDMFPDODP;

		private bool INFLMLFEEOF;

		private bool NNMLNJKPAGF;

		private Action AOFBLMAOOCA;

		public Action CurrentPlayerTypeChange;

		private NLOBDKDEACH? IMAELBNPCKO;

public bool InScreenDisplayMode
{
get 		{
			return false;
		}

}

public bool InVRDisplayMode
{
get 		{
			return false;
		}

}

public ONDBFDFPGBE CurrentPlayerType
{
get 		{
			return ONDBFDFPGBE.UNINITIALIZED;
		}

private set {
		}
}

public ONDBFDFPGBE PermanentPlayerType
{
get 		{
			return ONDBFDFPGBE.UNINITIALIZED;
		}

private set {
		}
}

public MJLJBHNFNAP CurrentDisplayMode
{
get 		{
			return MJLJBHNFNAP.UNINITIALIZED;
		}

private set {
		}
}

public bool IsControlCustomizationRequested
{
get 		{
			return this.JPMBAMKOHDF;
		}

private set {
			this.JPMBAMKOHDF = value;
		}
}

private bool GGEEEOCKBIM
{
get 		{
			return true;
		}

}

public PlayerController ActiveController
{
get 		{
			return this.NLDFOMHEMGB;
		}

private set {
		}
}

public bool HasInputThisFrame
{
get 		{
			return false;
		}

}

public bool GameViewFocused
{
get 		{
			return this.INFLMLFEEOF;
		}

private set {
		}
}

public bool CanDynamicallySwitchDisplayMode
{
get 		{
			return false;
		}

}

public bool IsCursorLocked
{
get 		{
			return this.NNMLNJKPAGF;
		}

set {
		}
}

public ScreenPlayerController ScreenPlayerController
{
get 		{
			return this.screenController;
		}

}

public static ScreenPlayerController ScreenPlayerControllerInstance
{
get 		{
			return null;
		}

}

public VRPlayerController VRPlayerController
{
get 		{
			return this.vrPlayerController;
		}

}

public Action DisplayModeChange
{
get 		{
			return null;
		}

set {
		}
}

		private IEnumerator<EGGPGCCKPCO> MKEJEOFMFPM(float IGOFBHCMLGF)
		{
			return null;
		}

		private void DPBMNHKEJNI()
		{
		}

		private bool FBFHBPOIOBO(JCDPHCELKHI KPFNANKNKLE, ONDBFDFPGBE NPJNNPDMEJF)
		{
			return false;
		}

		public void SetMovementModeForNextRoom(NLOBDKDEACH PGAKOAKLJDA)
		{
		}

		public void SetScreenDisplayMode()
		{
		}

		public void SetVRDisplayMode()
		{
		}

		private void KOIMDNDBAGA(MJLJBHNFNAP DNLPIHIBJDP)
		{
		}

		public Player InstantiateLocalPlayer(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
		{
			return null;
		}

		public void EnterAppInitializingState()
		{
		}

		public void EnterPlayerInitializedState()
		{
		}

		public void OnLoginScreenLoad(LoginScreenSpawnPoint FPDAFHFAEIC)
		{
		}

		public void RequestControlCustomization()
		{
		}

		public void ClearControlCustomizationRequest()
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void GIHKGIMINNE(float OKBAJEAPIHG)
		{
		}

		private void FIJFIPFIDOO(float OKBAJEAPIHG)
		{
		}

		private void LateUpdate()
		{
		}

		private void OnApplicationFocus(bool BADJIEDMGHC)
		{
		}

		private void HADBNNANGFK()
		{
		}

		private void NMJKIJBBDKO(Player MHCOBIPKGNI)
		{
		}

		private void ELEHDDBCDCL()
		{
		}

		private void PBKJDJBBOJE()
		{
		}

		private void AILNPOOGPAL()
		{
		}

		private MJLJBHNFNAP IHMGFOBLNPM()
		{
			return MJLJBHNFNAP.UNINITIALIZED;
		}

		private ONDBFDFPGBE DHHCLKMIOCC()
		{
			return ONDBFDFPGBE.UNINITIALIZED;
		}

		private void DEKPKIONMMH()
		{
		}

		private void ECHKHGFIDPJ()
		{
		}

		private void MJILPCFCDIO()
		{
		}
	}
}
