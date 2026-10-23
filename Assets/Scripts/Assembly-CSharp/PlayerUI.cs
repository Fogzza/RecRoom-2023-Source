using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom;
using RecRoom.AGUI.Expresso;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.Core.Gestures;
using RecRoom.Core.Pools;
using RecRoom.Core.UI;
using RecRoom.Players.Watch;
using RecRoom.UI;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerUI : MonoBehaviourPun
{
	private sealed class ILBPAMLHBIP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerUI _003C_003E4__this;

		public PlayerHand thisHand;

		private float _003Ctimer_003E5__2;

		private ParticleSystem.MainModule _003Cmain_003E5__3;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public ILBPAMLHBIP(int _003C_003E1__state)
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

	private sealed class KMNABPILHJE : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerUI _003C_003E4__this;

		public PlayerHand thisHand;

		private float _003Ctimer_003E5__2;

		private ParticleSystem.MainModule _003Cmain_003E5__3;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public KMNABPILHJE(int _003C_003E1__state)
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

	private sealed class NOKFHDFFEJM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerUI _003C_003E4__this;

		public PlayerHand otherHand;

		public PlayerHand thisHand;

		public float duration;

		private float _003Ctimer_003E5__2;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public NOKFHDFFEJM(int _003C_003E1__state)
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

	private const string PNBJDAPDBGK = "PlayerUI";

	private const int DHIIHDNGHGB = -1;

	private const string PHGLBIPDDLI = "PromptEnabled";

	private const string FIFCBJCFDMP = "OpenProfile_FadeOut";

	[SerializeField]
	private Player thisPlayer;

	[SerializeField]
	private PlayerAvatar playerAvatar;

	[SerializeField]
	private WatchMenuProjector watchMenuProjector;

	[SerializeField]
	private Animator openProfileAnimator;

	[SerializeField]
	private CircularProgressBar openProfileCircularProgressBar;

	[SerializeField]
	private Image openProfileActionIcon;

	[SerializeField]
	private Transform combatUIAnchor;

	[SerializeField]
	[HideInInspector]
	private UIAnchorFollower combatUIAnchorParentAnchor;

	[SerializeField]
	private WatchUI watchMenuPrefab;

	[SerializeField]
	private Transform watchMenuBase;

	[SerializeField]
	private ExpressoUI expressoMenuPrefab;

	[SerializeField]
	private AGVirtualKeyboard keyboardPrefab;

	[SerializeField]
	private ParticleSystem highFiveParticles;

	[SerializeField]
	private PooledParticle handshakeChargeParticles;

	[SerializeField]
	private ParticleSystem handshakeSuccessParticles;

	[SerializeField]
	private RecRoomAudioClip handshakeChargeAudio;

	[SerializeField]
	private RecRoomAudioClip handshakeSuccessAudio;

	[SerializeField]
	private ParticleSystem stopGestureChargeParticles;

	[SerializeField]
	private ParticleSystem stopGestureSuccessParticles;

	[SerializeField]
	private ParticleSystem cheerGestureChargeParticles;

	[SerializeField]
	private ParticleSystem cheerGestureSuccessParticles;

	[SerializeField]
	private PlayerWorldUIModel playerWorldUIModel;

	private bool OEAONLGBBPN;

	public FIHGBEHGLGB NamesHiddenFlag;

	private bool EAADMPEADHF;

	private WatchUI OIFFKLHIDFN;

	private WatchAttractor DHFGHOLHHLA;

	private RenderTexture DKLKOHDOEJJ;

	private int PBJLLDJHAIC;

	private DINMFHPHBEG.MMCGOCLBAEG? HBDBLGCPHPK;

	private Color AEPFHGCGEKA;

	private bool PBIOMBMOGBH;

	private SFXAudioSource FCLMOHBINMH;

	private PooledParticle FDHACAAFEHC;

	private Coroutine LEFJNEAAEHC;

	private SFXAudioSource IMHDMCDDFEE;

	private ParticleSystem MJEMIEFHMNH;

	private Coroutine GOEFDDKLAAE;

	private SFXAudioSource GHCLPOJNBGA;

	private ParticleSystem DDNAEJFGNJK;

	private Coroutine MCJBLCFPFOF;

	private JNKNMMDAHCF DHCLACKALOF;

	private AGVirtualKeyboard KIAKLBDEDFM;

	private bool MGIEIPFAGCL;

	[NonSerialized]
	private Color? AIAHCAAIJCP;

	private global::CDLJMENCODC<int> DHKIGMJBLOD;

	private readonly EEANDDJEMJC BHFCIPIKFFN;

	private readonly global::MKJNCDLHHNA<Sprite> HHHCIGBACBM;

	private readonly int OPHBDNFBCDJ;

	private readonly int IDBGHDGEJAD;

	private ALFNPNHKGCE ILONNMLPPCN;

public bool VRWatchMenuCanBeOpened
{
get 	{
		return false;
	}

}

public bool VRRoomChatMenuCanBeOpened
{
get 	{
		return false;
	}

set {
	}
}

public WatchUI WatchMenu
{
get 	{
		return null;
	}

private set {
	}
}

public WatchMenuProjector WatchMenuProjector
{
get 	{
		return null;
	}

}

public bool IsWatchMenuOpen
{
get 	{
		return false;
	}

}

public WatchAttractor WatchAttractor
{
get 	{
		return null;
	}

set {
	}
}

public Transform CombatUIAnchor
{
get 	{
		return null;
	}

}

public UIAnchorFollower CombatUIAnchorParentAnchor
{
get 	{
		return null;
	}

}

public PlayerWorldUIModel WorldUIModel
{
get 	{
		return null;
	}

}

public PlayerHand HandUsingExpresso
{
get 	{
		return null;
	}

}

public AGVirtualKeyboard LocalVirtualKeyboard
{
get 	{
		return null;
	}

private set {
	}
}

private int HJCOFHOINKB
{
get 	{
		return 0;
	}

set {
	}
}

public EEANDDJEMJC CV2PlayerNameColorChanged
{
get 	{
		return null;
	}

}

public Color? CV2PlayerNameColor
{
get 	{
		return null;
	}

}

public OKDILJPIEJF CurrentExpressoState
{
get 	{
		return OKDILJPIEJF.Closed;
	}

}

	public void AddOpenProfileActionIconRequested(object IALNODEHBNN, Sprite AGOJMHBGLCN)
	{
	}

	public void RemoveOpenProfileActionIconRequested(object IALNODEHBNN)
	{
	}

	public void SetOpenProfileActionIconProgress(float IPMIIEAGJKC)
	{
	}

	public void SetOpenProfileProgressEnabled(bool CGHLJMKOIGD)
	{
	}

	protected override void Awake()
	{
	}

	private void OnValidate()
	{
	}

	public void CancelExpresso()
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void UpdateInput(bool JBMAHMBPBED, bool NNNNPHAGHFH, bool ODCJCCJOKPL, PlayerHand GBHOAABLEKO, bool LCAJGONKOOH, bool MKPOOECHLAE, PlayerHand BCLLPMALPJK, bool FNIJECKBEIB, bool HCEJIEJJJMM)
	{
	}

	public void CV2SetPlayerNameColor(JLHLKDMLBPK HMCAFGCGFJF)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetPlayerNameColor(JEGAPHLGBJA GCBHEJANCJK, JLHLKDMLBPK IPMIIEAGJKC)
	{
		return default;
	}

	private Color JKFBECKGNCJ(int IPMIIEAGJKC)
	{
		return default;
	}

	public void CV2ResetPlayerUI()
	{
	}

	private void KNNJCIJLFFO()
	{
	}

	private void HCMKLHAIPPB(FMEDMCFGHFM AAMFKNLLGDC)
	{
	}

	private void FKBDDNICMAO(DMAIEODHOGA OFCFPGACNJB)
	{
	}

	private static bool FFHMKGMNCAK(DMAIEODHOGA OFCFPGACNJB)
	{
		return false;
	}

	private void ENLPGLEFMJB(PlayerHand DLCHNMNIOHL, PlayerHand MCGMBMMJMBM, PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, Player MHCOBIPKGNI, Player ANDCAFFMODA)
	{
	}

	private void ACEAPCIJJDL(ParticleSystem BENMDFOMAME, Vector3 INLGLHIPOMC)
	{
	}

	private void LFJCINGOGNL(PlayerHand GBHOAABLEKO, bool OPLHCOOIBLG, bool FLGKAOAFGGD, PlayerHand BCLLPMALPJK, bool AHAOENAMEEG, bool HGHIBOCIPPL)
	{
	}

	private bool PGAMNKGOEOD(PlayerHand PMNLJGLDMJN)
	{
		return false;
	}

	private bool IPDAAFJOEMB()
	{
		return false;
	}

	private void FAMCMKAHEDI(PlayerHand FOFPLOLGNHJ)
	{
	}

	private void AOFFBJNNPPJ()
	{
	}

	private IEnumerator BFPCAEIAMED(PlayerHand FOFPLOLGNHJ)
	{
		return null;
	}

	private void CCJGKCHDGAJ(PlayerHand FOFPLOLGNHJ)
	{
	}

	private void JOFAMJDHJFM()
	{
	}

	private IEnumerator ICNJOLKGEME(PlayerHand FOFPLOLGNHJ)
	{
		return null;
	}

	private void FBNCKEGGJNE(PlayerHand FOFPLOLGNHJ, PlayerHand MCGMBMMJMBM, float FGBPJMKCMAO)
	{
	}

	private void LNIELFHPCLM()
	{
	}

	private IEnumerator NHAFNEOFKNN(PlayerHand FOFPLOLGNHJ, PlayerHand MCGMBMMJMBM, float FGBPJMKCMAO)
	{
		return null;
	}

	private void LHNCMJIGOMF(PlayerHand FOFPLOLGNHJ, PlayerHand MCGMBMMJMBM)
	{
	}
}
