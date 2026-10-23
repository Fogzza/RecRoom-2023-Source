using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AGUI.StackedUI;
using RRUI.Data;
using RecNet;
using RecRoom.Audio;
using RecRoom.Avatars;
using RecRoom.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class SessionManager : InjectedSingletonMonoBehaviour<FMONDJELBAI, SessionManager>, FMONDJELBAI
{
	public class BEJCOLBHFDI
	{
		private bool FKKHLCMKOGO;

public bool JEKALIHPDFJ
{
get 		{
			return false;
		}

}

		public void KMJJDHJIMIB()
		{
		}
	}

	public enum PFPFLMJDKIB
	{
		None = 0,
		LeaveParty = 1,
		InviteParty = 2,
		PartyAutoFollow = 3,
		EveryoneAutoFollow = 4
	}

	[Serializable]
	private class ServerMaintenanceMinutesVO
	{
		public string name;

		public int minutes;

		public RecRoomAudioClip voClip;
	}

	public struct BOEPHMOPEIM
	{
		public string MFIBMPNBOHH;

		public string PAKNFNFLPFF;
	}

	private struct JNNMFDIKBBC
	{
		public string DKMGLGNLJCJ;

		public BNKIKFBACEL NIFOGEBEDNG;

		public DateTime DNGAFOGEJBB;

		public Matchmaking.DABKEMNEPLM FGPLJFAOPIP;

		public bool OEFANOFBEGG(DateTime LFGCNJNJFLB)
		{
			return false;
		}
	}

	[Serializable]
	private class JuniorUpdateRoutineConfig
	{
		public string Title;

		[TextArea]
		public string Message;
	}

	private sealed class EJODBDNCKPA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool waitForLocalPlayerInitialized;

		public bool showOnlineFriendCount;

		private List<long> _003CplayerIds_003E5__2;

		private IEnumerator _003CgetPlayerIdsEnumerator_003E5__3;

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
		public EJODBDNCKPA(int _003C_003E1__state)
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

	private sealed class AILCCJIKBIK
	{
		public BHNJIBDJFAL prefManager;

		internal bool _003CGetIdsOfFriendAppearingOnlineToMeEnumerator_003Eb__0()
		{
			return false;
		}
	}

	private sealed class INPJIEOGELM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<long> playerIds;

		private EOKKPHLOBBD[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		private EOKKPHLOBBD _003Crelationship_003E5__4;

		private PJFDADLIKCD _003Cpresence_003E5__5;

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
		public INPJIEOGELM(int _003C_003E1__state)
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

	private sealed class BFBGAFCHOED
	{
		public bool suppressPlatformInvite;

		public int invitedPlayerId;

		public bool suppressNotifications;

		public string invitedPlayerName;

		public SessionManager _003C_003E4__this;

		public DBIPHDIEBCM promise;

		internal void _003CInvitePlayerToGame_003Eb__0()
		{
		}

		internal void _003CInvitePlayerToGame_003Eb__1(string error)
		{
		}
	}

	private sealed class CKCNIKOJEPJ : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SessionManager _003C_003E4__this;

		public bool fromInitialize;

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
		public CKCNIKOJEPJ(int _003C_003E1__state)
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

	private sealed class AFOOBLDNEJA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ServerMaintenanceMinutesVO serverMaintenanceVO;

		public SessionManager _003C_003E4__this;

		private bool _003CplayerWasNotReady_003E5__2;

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
		public AFOOBLDNEJA(int _003C_003E1__state)
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

	private sealed class HGBJLFOFAID : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public JuniorUpdateRoutineConfig config;

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
		public HGBJLFOFAID(int _003C_003E1__state)
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

	private sealed class JAIEDCBAJPG : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SessionManager _003C_003E4__this;

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
		public JAIEDCBAJPG(int _003C_003E1__state)
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

	private sealed class CCMBJGHIGMD
	{
		public bool isJunior;

		internal void _003CSetIsJunior_003Eb__0(Action<bool> _)
		{
		}
	}

	private sealed class ANOBFMKLBGB
	{
		public bool? hasReferrers;

		internal void _003CFirstPlayerBootRoutine_003Eb__1(bool success)
		{
		}

		internal void _003CFirstPlayerBootRoutine_003Eb__2(string error)
		{
		}

		internal bool _003CFirstPlayerBootRoutine_003Eb__3()
		{
			return false;
		}
	}

	private sealed class DJPCPKHEDIH
	{
		public WatchUI watchMenu;

		internal void _003CFirstPlayerBootRoutine_003Eb__5(HGKINAOMNIF response)
		{
		}
	}

	private sealed class OAIGFMAGKDD : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SessionManager _003C_003E4__this;

		private ANOBFMKLBGB _003C_003E8__1;

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
		public OAIGFMAGKDD(int _003C_003E1__state)
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

	private sealed class NIJBNMAELKL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public SessionManager _003C_003E4__this;

		public string titleOverride;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public NIJBNMAELKL(int _003C_003E1__state)
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

	private sealed class LDBJJKLHJBH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public SessionManager _003C_003E4__this;

		public string titleOverride;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public LDBJJKLHJBH(int _003C_003E1__state)
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

	private sealed class JNDHJABDOCC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<DirectoryInfo> crashDumps;

		private List<DirectoryInfo>.Enumerator _003C_003E7__wrap1;

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
		public JNDHJABDOCC(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class GILLLHMHEII
	{
		public DBIPHDIEBCM promise;

		internal void _003CRunGoToClubhousePromise_003Eb__0(Matchmaking.DABKEMNEPLM mmError)
		{
		}

		internal void _003CRunGoToClubhousePromise_003Eb__1(string error)
		{
		}
	}

	private sealed class EAKFGJCFFAF
	{
		public EPILDIJELPG club;

		public SessionManager _003C_003E4__this;

		public DBECJLAIPEL loadSceneSource;

		public Action<Matchmaking.DABKEMNEPLM> onResponseCallback;

		public Action<string> OnErrorCallback;

		internal void _003CRunGoToClubhouseInternal_003Eb__0(bool bypassMovementModeRestriction)
		{
		}
	}

	private sealed class DKGFHNMIOCA
	{
		public bool bypassMovementModeRestriction;

		public EAKFGJCFFAF CS_0024_003C_003E8__locals1;

		internal void _003CRunGoToClubhouseInternal_003Eb__1()
		{
		}

		internal void _003CRunGoToClubhouseInternal_003Eb__2()
		{
		}
	}

	private sealed class KLHHHDPHHAN
	{
		public EPILDIJELPG club;

		public bool bypassMovementModeRestriction;

		public Action<Matchmaking.DABKEMNEPLM> onResponseCallback;

		public Action<string> OnErrorCallback;

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CJoinClubhouseHelper_003Eb__0(int[] additionalPlayers)
		{
			return null;
		}

		internal void _003CJoinClubhouseHelper_003Eb__1(Matchmaking.DABKEMNEPLM response)
		{
		}

		internal void _003CJoinClubhouseHelper_003Eb__2(string error)
		{
		}
	}

	private sealed class BNCMKHODFMN
	{
		public SessionManager _003C_003E4__this;

		public IMIJPHJKLIM targetEvent;

		public DBECJLAIPEL loadSceneSource;

		public Matchmaking.KOGKIEBALBG matchmakingJoinMode;

		internal void _003CGoToPlayerEventInternal_003Eb__0(JCDPHCELKHI room)
		{
		}
	}

	private sealed class LKIBNGICLOO
	{
		public JCDPHCELKHI room;

		public BNCMKHODFMN CS_0024_003C_003E8__locals1;

		internal void _003CGoToPlayerEventInternal_003Eb__1(bool bypassMovementModeRestriction)
		{
		}
	}

	private sealed class EJBHJKPGEDD
	{
		public bool bypassMovementModeRestriction;

		public LKIBNGICLOO CS_0024_003C_003E8__locals2;

		internal void _003CGoToPlayerEventInternal_003Eb__2()
		{
		}

		internal void _003CGoToPlayerEventInternal_003Eb__3()
		{
		}
	}

	private sealed class CJKGCKENBEO
	{
		public SessionManager _003C_003E4__this;

		public HHCLMHEOLDA loadSceneSourceData;

		public bool isPrivate;

		public Action<ANAGHNCECEB> onResponseCallback;

		internal void _003CRunJoinRoom_003Eb__0(JCDPHCELKHI room)
		{
		}
	}

	private sealed class DKJGDCFDMHD
	{
		public SessionManager _003C_003E4__this;

		public HHCLMHEOLDA loadSceneSourceData;

		public bool isPrivate;

		public Action<ANAGHNCECEB> onResponseCallback;

		internal void _003CRunJoinRoom_003Eb__0(JCDPHCELKHI room)
		{
		}
	}

	private sealed class EGNNDMPHCGI
	{
		public string subroomName;

		public SessionManager _003C_003E4__this;

		public HHCLMHEOLDA loadSceneSourceData;

		public bool isPrivate;

		public Action<ANAGHNCECEB> onResponseCallback;

		internal void _003CRunJoinRoom_003Eb__0(LCEKCFEIEGJ room)
		{
		}
	}

	private sealed class LKGOGFOKFMO
	{
		public JCDPHCELKHI room;

		public SessionManager _003C_003E4__this;

		public HHCLMHEOLDA loadSceneSourceData;

		public OPKEAIOICLJ subRoom;

		public bool isPrivate;

		public string roomCode;

		public string welcomeMatName;

		public KPGPFEAGMDE customRoomLoadPayload;

		public Action<ANAGHNCECEB> onResponseCallback;

		public Action _003C_003E9__4;

		internal void _003CRunJoinRoom_003Eb__0(bool bypassMovementModeRestriction)
		{
		}

		internal void _003CRunJoinRoom_003Eb__4()
		{
		}

		internal void _003CRunJoinRoom_003Eb__1()
		{
		}
	}

	private sealed class JIJAGILMKGF
	{
		public bool bypassMovementModeRestriction;

		public LKGOGFOKFMO CS_0024_003C_003E8__locals1;

		internal void _003CRunJoinRoom_003Eb__2()
		{
		}

		internal void _003CRunJoinRoom_003Eb__3()
		{
		}
	}

	private sealed class DCJPFJNCODD
	{
		public SessionManager _003C_003E4__this;

		public HHCLMHEOLDA loadSceneSourceData;

		public Action<ANAGHNCECEB> onResponseCallback;

		internal void _003CRunJoinDormRoom_003Eb__0(bool bypassMovementModeRestriction)
		{
			this._003C_003E4__this.APFMLJLPMJD = this.loadSceneSourceData;
			var joinPromise = this._003C_003E4__this.CKIFCJCBNLA("Going to ^DormRoom", PFPFLMJDKIB.LeaveParty, global::SolarNet.Recovery.OriginalDelegateCompatibility.IgnoreInput<int[], global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM>>(Matchmaking.FGKJLHAEJAL));
			this._003C_003E4__this.MLGHBPFMFNL(joinPromise, this.onResponseCallback);
		}

		internal void _003CRunJoinDormRoom_003Eb__1()
		{
			var callback = this.onResponseCallback;
			if (callback != null)
				callback(default(ANAGHNCECEB));
		}
	}

	private sealed class OHJOOFNIBOK
	{
		public Action<Matchmaking.DABKEMNEPLM> optionalOnResponseCallback;

		internal void _003CApplyOptionalResponseCallback_003Eb__0(string error)
		{
			string message = string.Concat("A promise error message is being propagated as an \"unknown error\". Specific message: ", error, ".");
			HJDBOADFHMC? category = HJDBOADFHMC.FBJHBFFDBDJ;
			PNAABCMOHGM.NEGCNMACIEM((object)message, category);
			var callback = this.optionalOnResponseCallback;
			if (callback != null)
				callback((Matchmaking.DABKEMNEPLM)(-1));
		}
	}

	private sealed class HJOICMNILEJ
	{
		public Action<ANAGHNCECEB> optionalOnResponseCallback;

		internal void _003CApplyOptionalResponseCallback_003Eb__0(Matchmaking.DABKEMNEPLM errorCode)
		{
			var callback = this.optionalOnResponseCallback;
			var response = new ANAGHNCECEB(errorCode);
			callback(response);
		}
	}

	private sealed class PFLPNMFCMGM
	{
		public string lookupMessage;

		public Action<ANAGHNCECEB> optionalOnResponseCallback;

		internal void _003CApplyRoomLookupErrorHandler_003Eb__0(string error)
		{
		}
	}

	private sealed class JLPCMKJGNKN
	{
		public PFPFLMJDKIB inviteMode;

		public OPKEAIOICLJ subRoom;

		public SessionManager _003C_003E4__this;

		public DBECJLAIPEL loadSceneSource;

		public bool forceNewInstance;

		public string welcomeMatName;

		public LCEKCFEIEGJ room;

		internal void _003CRunJoinSubRoomOfCurrentRoom_003Eb__0(bool bypassMovementModeRestriction)
		{
		}
	}

	private sealed class NGBIOHFDJHA
	{
		public bool bypassMovementModeRestriction;

		public JLPCMKJGNKN CS_0024_003C_003E8__locals1;

		internal void _003CRunJoinSubRoomOfCurrentRoom_003Eb__1()
		{
		}

		internal void _003CRunJoinSubRoomOfCurrentRoom_003Eb__2()
		{
		}
	}

	private sealed class MDGEHABCEGG
	{
		public DBECJLAIPEL loadSceneSource;

		public SessionManager _003C_003E4__this;

		public int playerId;

		public JCDPHCELKHI room;

		internal void _003CRunJoinPlayer_003Eb__0(bool bypassMovementModeRestriction)
		{
		}
	}

	private sealed class PPLDKGKLLOC
	{
		public bool bypassMovementModeRestriction;

		public MDGEHABCEGG CS_0024_003C_003E8__locals1;

		internal void _003CRunJoinPlayer_003Eb__1()
		{
		}

		internal void _003CRunJoinPlayer_003Eb__2()
		{
		}
	}

	private sealed class LMBDLEIDNEO
	{
		public DBECJLAIPEL loadSceneSource;

		public SessionManager _003C_003E4__this;

		public DMAIEODHOGA roomInviteMessage;

		public int playerId;

		public JCDPHCELKHI room;

		internal void _003CRunAcceptRoomInvite_003Eb__0(bool bypassMovementModeRestriction)
		{
		}
	}

	private sealed class OFLFOKBDHGI
	{
		public bool bypassMovementModeRestriction;

		public LMBDLEIDNEO CS_0024_003C_003E8__locals1;

		internal void _003CRunAcceptRoomInvite_003Eb__1()
		{
		}

		internal void _003CRunAcceptRoomInvite_003Eb__2()
		{
		}
	}

	private sealed class PBGDAJONNBD
	{
		public SessionManager _003C_003E4__this;

		public ChatMessage chatPartyInvite;

		public Action<ANAGHNCECEB> onResponseCallback;

		internal void _003CRunAcceptPartyInvite_003Eb__0(bool bypassMovementModeRestriction)
		{
		}
	}

	private sealed class INENJODFFLO
	{
		public string playerName;

		public SessionManager _003C_003E4__this;

		public int playerId;

		internal void _003CRequestGameInvite_003Eb__0()
		{
		}

		internal void _003CRequestGameInvite_003Eb__1(string error)
		{
		}
	}

	private sealed class GCDPLCKOKMP
	{
		public SessionManager _003C_003E4__this;

		public JCDPHCELKHI room;

		public Action<bool> onConfirmed;

		public Action onCancel;

		public Action _003C_003E9__13;

		public Action _003C_003E9__11;

		public Action _003C_003E9__9;

		public Action _003C_003E9__7;

		public Action _003C_003E9__5;

		public Action _003C_003E9__3;

		internal void _003CDefaultRoomGates_003Eb__0(bool bypassMovementModeRestriction)
		{
			var gate = new OLENAJMENAB();
			gate.CS_0024_003C_003E8__locals1 = this;
			gate.bypassMovementModeRestriction = bypassMovementModeRestriction;
			var session = this._003C_003E4__this;
			Action confirmed = gate._003CDefaultRoomGates_003Eb__2;
			Action cancelled = this._003C_003E9__3;
			if (cancelled == null)
				this._003C_003E9__3 = cancelled = this._003CDefaultRoomGates_003Eb__3;
			session.AIBFFJCEMGJ(confirmed, cancelled);
		}

		internal void _003CDefaultRoomGates_003Eb__13()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__11()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__9()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__7()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__5()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__3()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__1()
		{
			var callback = this.onCancel;
			if (callback != null)
				callback();
		}
	}

	private sealed class OLENAJMENAB
	{
		public bool bypassMovementModeRestriction;

		public GCDPLCKOKMP CS_0024_003C_003E8__locals1;

		public Action _003C_003E9__12;

		public Action _003C_003E9__10;

		public Action _003C_003E9__8;

		public Action _003C_003E9__6;

		public Action _003C_003E9__4;

		internal void _003CDefaultRoomGates_003Eb__2()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__4()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__6()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__8()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__10()
		{
		}

		internal void _003CDefaultRoomGates_003Eb__12()
		{
		}
	}

	private sealed class BOFKECFHDJF
	{
		public bool wasRoomVisitRestricted;

		public BrowserModel browserModel;

		public Action onConfirmed;

		public Action onRejected;

		internal void _003CRoomRestrictionsGate_003Eb__0(List<Matchmaking.MFANGFIMOIC> restrictions)
		{
		}

		internal void _003CRoomRestrictionsGate_003Eb__1()
		{
		}
	}

	private sealed class EGDKDGNIMLG
	{
		public Action onConfirmed;

		public Action onRejected;

		internal void _003CPlayerGoToDestinationGate_003Eb__0(HGKINAOMNIF r)
		{
		}
	}

	private sealed class LGAFCNKHFEN
	{
		public Action onConfirmed;

		public Action onRejected;

		public Action onCancel;

		internal void _003CPartyGate_003Eb__0(HGKINAOMNIF r)
		{
		}
	}

	private sealed class CBHAGJJJLGD
	{
		public SessionManager _003C_003E4__this;

		public Action onConfirmed;

		public Action onRejected;

		internal void _003CRoomOwnerGate_003Eg__OnSaveRoom_007C0((string, bool) data)
		{
		}

		internal void _003CRoomOwnerGate_003Eg__OnDismissed_007C1()
		{
		}

		internal void _003CRoomOwnerGate_003Eg__OnDontSave_007C2()
		{
		}
	}

	private sealed class INFMONMEHKD
	{
		public SessionManager _003C_003E4__this;

		public Action onConfirmed;

		public Action onRejected;

		internal void _003CGameProgressGate_003Eb__0(HGKINAOMNIF r)
		{
		}
	}

	private sealed class OKIGIOGGFLC
	{
		public Action onRejected;

		public SessionManager _003C_003E4__this;

		public Action onConfirmed;

		public Action _003C_003E9__2;

		internal void _003CBundleTrialsGate_003Eb__0(IINOCBCBDGN resolution)
		{
		}

		internal void _003CBundleTrialsGate_003Eb__2()
		{
		}

		internal void _003CBundleTrialsGate_003Eb__1(string err)
		{
		}
	}

	private sealed class OKBMCHNMLMO
	{
		public Action onRejected;

		public Action onConfirmed;

		internal void _003COutfitItemsGate_003Eb__0(HGKINAOMNIF r)
		{
		}
	}

	private sealed class DGHOFECNLBJ
	{
		public bool serverIsDevFlag;

		internal void _003CGateRoutine_003Eb__0(bool isDev)
		{
		}
	}

	private sealed class FHKELKHHLFC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private DGHOFECNLBJ _003C_003E8__1;

		public Action developerAction;

		public Action nonDeveloperAction;

		private bool _003CclientIsDevFlag_003E5__2;

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
		public FHKELKHHLFC(int _003C_003E1__state)
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

	private sealed class IBHDDAEDFNB
	{
		public bool playAttract;

		public OILDLLGEMKP.LKLLEIKDHDD source;

		internal LAHBDKNMNHN _003CRunImportFriends_003Eb__0(List<JJGPKBPPDHH> friends)
		{
			return null;
		}
	}

	private sealed class NIBPIIEOICJ
	{
		public SessionManager _003C_003E4__this;

		public JCDPHCELKHI room;

		public string roomCode;

		public OPKEAIOICLJ subRoom;

		public bool bypassMovementModeRestriction;

		public bool isPrivate;

		public PFPFLMJDKIB inviteMode;

		public string welcomeMatName;

		public KPGPFEAGMDE customRoomLoadPayload;

		public Action<Matchmaking.DABKEMNEPLM> _003C_003E9__1;

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CJoinRoom_003Eb__0(int[] additionalPlayers)
		{
			return null;
		}

		internal void _003CJoinRoom_003Eb__1(Matchmaking.DABKEMNEPLM response)
		{
		}
	}

	private sealed class JCPOOJOJKEM
	{
		public SessionManager _003C_003E4__this;

		public PFPFLMJDKIB inviteMode;

		public OPKEAIOICLJ subRoom;

		public bool bypassMovementModeRestriction;

		public bool forceNewInstance;

		public string welcomeMatName;

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CJoinSubRoomOfCurrentRoom_003Eb__0(int[] additionalPlayers)
		{
			return null;
		}
	}

	private sealed class CGNJAGDPHGJ
	{
		public IMIJPHJKLIM ev;

		public bool bypassMovementModeRestriction;

		public Matchmaking.KOGKIEBALBG matchmakingJoinMode;

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CJoinPlayerEvent_003Eb__0(int[] additionalPlayers)
		{
			return null;
		}
	}

	private sealed class OKMEDPMCEJH
	{
		public int playerId;

		public bool bypassMovementModeRestriction;

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CJoinPlayer_003Eb__0(int[] additionalPlayers)
		{
			return null;
		}
	}

	private sealed class OEGNMDGBION
	{
		public BJCIKFCDBFN.LEKAOGBECBI roomInviteDetails;

		public DMAIEODHOGA roomInviteMessage;

		public bool bypassMovementModeRestriction;

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CAcceptRoomInvite_003Eb__0(int[] additionalPlayers)
		{
			return null;
		}
	}

	private sealed class AGMADNLHELB
	{
		public ChatMessage chatPartyInviteMessage;

		public bool bypassMovementModeRestriction;

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CAcceptPartyInvite_003Eb__0(int[] additionalPlayers)
		{
			return null;
		}
	}

	private sealed class BPNPFOBAJNL
	{
		public int? recipientPlayerId;

		internal bool _003CLocalPlayerRequestJoinRoomScene_003Eb__0(CHILKDJABBF pp)
		{
			return false;
		}
	}

	private sealed class CEEOAHBCIPP
	{
		public int? recipientPlayerId;

		internal bool _003CLocalPlayerRequestJoinRoomSceneV2_003Eb__0(CHILKDJABBF pp)
		{
			return false;
		}
	}

	private sealed class IFMAOFGHNJB : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string message;

		public SessionManager _003C_003E4__this;

		private int _003Cprogress_003E5__2;

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
		public IFMAOFGHNJB(int _003C_003E1__state)
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

	private sealed class JEAHMIMMCOG
	{
		public long clubId;

		internal void _003CNotifyInClubhouse_003Eb__0(FJHBMHDECLE clubDetails)
		{
		}

		internal void _003CNotifyInClubhouse_003Eb__1(string error)
		{
		}
	}

	private sealed class KPKJDBBGGMH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public SessionManager _003C_003E4__this;

		private JEAHMIMMCOG _003C_003E8__1;

		private global::NCOKFFGPIJM<FJHBMHDECLE> _003CclubDetailsPromise_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public KPKJDBBGGMH(int _003C_003E1__state)
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

	private sealed class CFODFIHICEE
	{
		public int statusCode;

		internal void _003CTryApplicationQuit_003Eb__0()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct HDCDJJDKNNP : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		private object _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		private TaskAwaiter<TaskStatus[]> _003C_003Eu__1;

		private TaskAwaiter<Scene> _003C_003Eu__2;

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

	private sealed class LCPOAEGBFJN
	{
		public string chatMessage;

		public SessionManager _003C_003E4__this;

		internal global::NCOKFFGPIJM<DFDECAEJBIO> _003CCheckForAndHandlePlatformFriendOrTextMessageReferrers_003Eb__1(int id)
		{
			return null;
		}
	}

	private sealed class KOMFKHGDBFC
	{
		public string chatMessage;

		public SessionManager _003C_003E4__this;

		public int accountId;

		public Func<OFPDFAGJKLH.CKHCGCPJFHH, global::NCOKFFGPIJM<DFDECAEJBIO>> _003C_003E9__1;

		internal global::NCOKFFGPIJM<DFDECAEJBIO> _003CTryAddFriendAndSendChatMessage_003Eb__0(EOKKPHLOBBD relationship)
		{
			return null;
		}

		internal global::NCOKFFGPIJM<DFDECAEJBIO> _003CTryAddFriendAndSendChatMessage_003Eb__1(OFPDFAGJKLH.CKHCGCPJFHH message)
		{
			return null;
		}
	}

	private sealed class OMJGJEDAIBC
	{
		public OFPDFAGJKLH.CKHCGCPJFHH message;

		internal global::NCOKFFGPIJM<DFDECAEJBIO> _003CTryAddFriendAndSendChatMessage_003Eb__2(DFDECAEJBIO account)
		{
			return null;
		}
	}

	private sealed class KIPMIBJPBAC
	{
		public DFDECAEJBIO account;

		internal global::NCOKFFGPIJM<DFDECAEJBIO> _003CTryAddFriendAndSendChatMessage_003Eb__3(AGBOKPJCFFK response)
		{
			return null;
		}
	}

	private sealed class HECELGDFCEF
	{
		public List<DFDECAEJBIO> accounts;

		public SessionManager _003C_003E4__this;

		internal global::NCOKFFGPIJM<bool> _003CNotifyPlayerOfReferrers_003Eb__0()
		{
			return null;
		}
	}

	private sealed class BHJAPMBDBCH
	{
		public RRUIRootScreen rruiRootScreen;

		public HECELGDFCEF CS_0024_003C_003E8__locals1;

		public Action<FMEDMCFGHFM> _003C_003E9__3;

		public Action<string> _003C_003E9__4;

		internal global::NCOKFFGPIJM<bool> _003CNotifyPlayerOfReferrers_003Eb__2(HGKINAOMNIF response)
		{
			return null;
		}

		internal void _003CNotifyPlayerOfReferrers_003Eb__3(FMEDMCFGHFM chatThread)
		{
		}

		internal void _003CNotifyPlayerOfReferrers_003Eb__4(string error)
		{
		}
	}

	private sealed class HFNMHGEEGNK
	{
		public COMHCCBONLA kickDetails;

		public SessionManager _003C_003E4__this;

		public Action<HGKINAOMNIF> _003C_003E9__3;

		internal void _003COnRecNetModerationKicked_003Eb__0()
		{
		}

		internal void _003COnRecNetModerationKicked_003Eb__3(HGKINAOMNIF dialogResponse)
		{
		}

		internal void _003COnRecNetModerationKicked_003Eb__1()
		{
		}

		internal void _003COnRecNetModerationKicked_003Eg__HandleModerationKicked_007C2()
		{
		}
	}

	private static readonly string IIPKADEEPNK;

	private const float ECBDJOKBMIB = 0.2f;

	[SerializeField]
	private Texture2D defaultProfileImage;

	[SerializeField]
	private Texture2D defaultProfileImagePadded;

	[SerializeField]
	private ColorVault groupColorVault;

	[SerializeField]
	private RecRoomAudioClip updateRequiredAudio;

	[SerializeField]
	private JuniorUpdateRoutineConfig ForcedJunior;

	[SerializeField]
	private int minPromptToSaveRoomTimeSeconds;

	[SerializeField]
	private LocalizedString sessionTakeoverLogoutMessage;

	private string NHJCGGCLAAE;

	private string AIPIDFJHDHJ;

	private string HPBMPAJIEED;

	private string CCINOFCLDOC;

	private int AAGADILNCDH;

	private bool BPNMDPGBEON;

	private int NDNNDBDFGPH;

	private CDLILHDKGGD GDPDKMDOBMH;

	public static bool LoadInSafeMode;

	public bool GaveEmailThisSession;

	public bool GavePhoneThisSession;

	public bool HasSentAudioSpamEventThisSession;

	private long CJBIFKLMOCL;

	private BHNJIBDJFAL NJPJBDDAEFH;

	private HLNFDOBEGJO CHABDOLEEMD;

	private AHJNDOAGBDE AJCHGBGGJFK;

	private Action PNNLIHOKFCJ__BackingField;

	private Action HFAOLPCEEKA__BackingField;

	private Action<bool> HOBKBIIDJGH__BackingField;

	private Action<BEJCOLBHFDI> EHPHBKFLAPL__BackingField;

	private Action<int> KMHPOAPHEGH__BackingField;

	private Action IOGOPLIJIDM__BackingField;

	private static Dictionary<Type, Dictionary<string, object>> NLAEOICNPAI;

	private static bool IFFMONBAAGN;

	private static bool CIGCNLHCBKJ;

	private Dictionary<long, float> JPNFGKDFFGH;

	private Dictionary<long, float> PDGMDGGOHCM;

	private Dictionary<long, float> MOFEHBADEFH;

	private Dictionary<long, float> MIBJHMAHIOC;

	public const float OnlineInviteInterval = 30f;

	public const float RequestInviteInterval = 30f;

	public const float OfflineInviteInterval = 300f;

	public const float TextMessageInterval = 10f;

	[SerializeField]
	private RecRoomAudioClip serverMaintenanceVO;

	[SerializeField]
	private ServerMaintenanceMinutesVO[] serverMaintenanceMinuteVOs;

	private Coroutine DIBPFKNAGGJ;

	private Coroutine FJEBHMPBOEO;

	private bool? EEDPCCCOOMK;

	private Coroutine DAPLONMOPND;

	private LAHBDKNMNHN DBFGLJNKKGM;

	private LAHBDKNMNHN JHDLKAOJHMI;

	private static readonly HashSet<long> ABKGLNDEKNK;

	private FIHGBEHGLGB CADGPKEBFED;

	private global::AFHOAHNAMGF<BOEPHMOPEIM> OCDNICBDGOC;

	private HHCLMHEOLDA APFMLJLPMJD;

	private bool DJPHNJGKJPL;

	private const int FDPFPOBFJBN = 10;

	private List<JNNMFDIKBBC> ALAHAFHAGLE;

public Texture2D DefaultProfileImage
{
get 	{
		return null;
	}

}

public Texture2D DefaultProfileImagePadded
{
get 	{
		return null;
	}

}

public ColorVault GroupColorVault
{
get 	{
		return null;
	}

}

public string PlayerPartyId
{
get 	{
		return null;
	}

set {
	}
}

public string PlayerPartyColorId
{
get 	{
		return null;
	}

set {
	}
}

public string AlertTitle
{
get 	{
		return null;
	}

set {
	}
}

public string AlertMessage
{
get 	{
		return null;
	}

set {
	}
}

public int NumberOfTimesUserGotKicked
{
get 	{
		return 0;
	}

set {
	}
}

public static bool InRecCenter
{
get 	{
		return false;
	}

}

public static bool InDormRoom
{
get 	{
		return false;
	}

}

public static bool InRoomCalibration
{
get 	{
		return false;
	}

}

public static bool InOrientation
{
get 	{
		return false;
	}

}

public static bool InRecRoyale
{
get 	{
		return false;
	}

}

public static bool InPaintball
{
get 	{
		return false;
	}

}

public static bool InLasertag
{
get 	{
		return false;
	}

}

public static bool InDodgeball
{
get 	{
		return false;
	}

}

public static bool InDiscGolf
{
get 	{
		return false;
	}

}

public static bool InBowling
{
get 	{
		return false;
	}

}

public static bool InPrivateSession
{
get 	{
		return false;
	}

}

public static bool IsCurrentSceneActive
{
get 	{
		return false;
	}

}

public static bool IsQuitting
{
get 	{
		return false;
	}

}

public static bool IsLoggingOut
{
get 	{
		return false;
	}

}

public static bool IsQuittingOrLoggingOut
{
get 	{
		return false;
	}

}

public static bool IsLoadingOrQuitting
{
get 	{
		return false;
	}

}

public bool IsApplicationBackgrounded
{
get 	{
		return false;
	}

private set {
	}
}

public int InitializationTimestamp
{
get 	{
		return 0;
	}

private set {
	}
}

private static string OJFENGOJPCC
{
get 	{
		return null;
	}

}

public static bool HasVisitedRecCenterBefore
{
get 	{
		return false;
	}

set {
	}
}

private CDLILHDKGGD FGFFCFFCEPN
{
get 	{
		return null;
	}

}

private bool NODIGMHAHGJ
{
get 	{
		return false;
	}

}

private BOEPHMOPEIM CABOEBMMLEG
{
get 	{
		return default;
	}

}

public static bool IsDeveloper
{
get 	{
		return false;
	}

}

public static bool HasActiveRRPlusSubscription
{
get 	{
		return false;
	}

}

private string OLJBCCAHCPH
{
get 	{
		return null;
	}

}

private DateTime? BHKBBJDCMHO
{
get 	{
		return null;
	}

set {
	}
}

public bool IsSwitchingRooms
{
get 	{
		return false;
	}

}

public bool LeaveSceneStarted
{
get 	{
		return false;
	}

private set {
	}
}

public event Action OnLocalPlayerSpawned {
add {
	}
remove {
	}
}

public event Action OnLocalPlayerDespawned {
add {
	}
remove {
	}
}

public event Action<bool> OnJuniorStatusChanged {
add {
	}
remove {
	}
}

public event Action<BEJCOLBHFDI> OnSwitchRoomRequested {
add {
	}
remove {
	}
}

public event Action<int> OnModerationKicked {
add {
	}
remove {
	}
}

public event Action OnModerationUnkicked {
add {
	}
remove {
	}
}

	public bool GetRecNetAdditionalPlayerAutoFollow(PFPFLMJDKIB KHIJCFMFKHI)
	{
		return false;
	}

	public static void SetProperty<T, U>(string FDAIMOMOHIG, U IPMIIEAGJKC) where T : MonoBehaviour
	{
	}

	public static U GetProperty<T, U>(string FDAIMOMOHIG, U GFLAEOLMKMC) where T : MonoBehaviour
	{
		return default;
	}

	protected override void Awake()
	{
	}

	private void KKCBGDOFNGB(GBAJDOHJDHJ HFEKGOLNKOL)
	{
	}

	public void Initialize()
	{
	}

	protected override void OnDestroy()
	{
	}

	private static void EDLMAOJJALF()
	{
	}

	private void OnApplicationQuit()
	{
	}

	private void OnApplicationPause(bool NFHCNHMLNJG)
	{
	}

	public void SetLocalPlayerBackgrounded(bool NNOPJGPGGDE)
	{
	}

	public static void MasterTryForceSwitchToNewBestMaster()
	{
	}

	private void JGCEBMHGKID(Scene PAKKJAPOGPN, LoadSceneMode FFDKLDFJBMF)
	{
	}

	private void OHFNLPLADGL()
	{
	}

	private void LOPMJNNKHDH()
	{
	}

	public void HandleRoomJoinFailure(Matchmaking.DABKEMNEPLM MLDANHIGANI, string ODMCNLNIJDH)
	{
	}

	private void GMIKECLHDMG()
	{
	}

	private void OOIEGIKOMDN()
	{
	}

	private void CDBBOHBGNNP(int? PCKCPNGPNBJ)
	{
	}

	private void KOJJBEHDNII(JFAAGFOLICM JMJKKGAMABE, JFAAGFOLICM DLEMNBPMGBG)
	{
	}

	public static IEnumerator RunSendStatusUpdateToFriends(bool LDFNJCFHJIF, bool PNGHGNFOBPD)
	{
		return null;
	}

	private static IEnumerator OBHNOJCBMHG(List<long> DCCNDPPOHOG)
	{
		return null;
	}

	private static void GGLHOALOJMO(List<long> DCCNDPPOHOG)
	{
	}

	public bool RateLimitAllowsTextMessage(long NIOBHMNMBCD)
	{
		return false;
	}

	public bool RateLimitAllowsRequestInvite(long NIOBHMNMBCD)
	{
		return false;
	}

	public bool RateLimitAllowsOnlineInvite(long NIOBHMNMBCD)
	{
		return false;
	}

	public bool RateLimitAllowsOfflineInvite(long NIOBHMNMBCD)
	{
		return false;
	}

	private bool LKDOLBANIOF(long NIOBHMNMBCD, float KGGEDFFAENA, Dictionary<long, float> MDGHLNIEGHI)
	{
		return false;
	}

	public DBIPHDIEBCM InvitePlayerToGame(int NIOBHMNMBCD, string JCHDMMPFMFB, bool PBNIIBOOGEG = false, bool PGHNOAPKPMC = false)
	{
		return null;
	}

	private void NBFHEKIAPGC(GJBCKEHFLFM JAELDIEEHPI)
	{
	}

	private void PMKKIMFHMGK(bool DPGCHPHOPFM)
	{
	}

	private IEnumerator BOPLIDANCFB(bool DPGCHPHOPFM)
	{
		return null;
	}

	private IEnumerator NLIFAHBENLJ(ServerMaintenanceMinutesVO BHAEGKCHDAE)
	{
		return null;
	}

	private IEnumerator HBPIDDAMBNP(JuniorUpdateRoutineConfig FPJKGKBOAOA)
	{
		return null;
	}

	private void NNFBGIDBILC()
	{
	}

	private IEnumerator DKEJKEIHPPH()
	{
		return null;
	}

	private void BLKJJBIOCEC()
	{
	}

	public void SetIsJunior()
	{
	}

	private IEnumerator EECPOAJDFAF()
	{
		return null;
	}

	public LAHBDKNMNHN TryStartPromptForEmail(string GFFOMHMCDGE = null)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> CENKPANKHON(string GFFOMHMCDGE)
	{
		return null;
	}

	public LAHBDKNMNHN TryStartPromptForPhone(string GFFOMHMCDGE = null)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> EOKNOGLAMBF(string GFFOMHMCDGE)
	{
		return null;
	}

	private static void IDBDOKHNLPK()
	{
	}

	private IEnumerator DCPLNLPGLLM(List<DirectoryInfo> DHFBAOEMMCK)
	{
		return null;
	}

	public LAHBDKNMNHN RunGoToClubhousePromise(EPILDIJELPG APMHMCKALGG, DBECJLAIPEL CFBNOKOADFB)
	{
		return null;
	}

	private void LLKJAFCJBDM(EPILDIJELPG APMHMCKALGG, DBECJLAIPEL CFBNOKOADFB, Action<Matchmaking.DABKEMNEPLM> PHDGJMDIOFO = null, Action<string> LNNMEDCPLOG = null)
	{
	}

	private void HACICKABELE(EPILDIJELPG APMHMCKALGG, PFPFLMJDKIB KHIJCFMFKHI, bool NKAHNIDHKKE, Action<Matchmaking.DABKEMNEPLM> PHDGJMDIOFO, Action<string> LNNMEDCPLOG = null)
	{
	}

	public bool RunGoToPlayerEvent(IMIJPHJKLIM KOFOMGPFOLF, DBECJLAIPEL CFBNOKOADFB, Matchmaking.KOGKIEBALBG MFHNILIDOBH = Matchmaking.KOGKIEBALBG.PublicMatchmaking)
	{
		return false;
	}

	private void COMGNONFNMF(IMIJPHJKLIM KOFOMGPFOLF, DBECJLAIPEL CFBNOKOADFB, Matchmaking.KOGKIEBALBG HLMMKPAIPOI)
	{
	}

	public void RunJoinRoom(long EPOBIFCHLNM, HHCLMHEOLDA APFMLJLPMJD, bool LPHLJGDKOND, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
	{
	}

	public void RunJoinRoom(JJABENBKBBO KPFNANKNKLE, HHCLMHEOLDA APFMLJLPMJD, bool LPHLJGDKOND, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
	{
	}

	[Obsolete]
	public void RunJoinRoom(string LBGBFPDNKOL, HHCLMHEOLDA APFMLJLPMJD, bool LPHLJGDKOND, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
	{
	}

	[Obsolete]
	public void RunJoinRoom(string LBGBFPDNKOL, string BPFFKFHNHFA, HHCLMHEOLDA APFMLJLPMJD, bool LPHLJGDKOND, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
	{
	}

	public void RunJoinRoom(JCDPHCELKHI KPFNANKNKLE, HHCLMHEOLDA APFMLJLPMJD, bool LPHLJGDKOND, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
	{
	}

	public void RunJoinRoom(JCDPHCELKHI KPFNANKNKLE, OPKEAIOICLJ FPDPBAPDONJ, HHCLMHEOLDA APFMLJLPMJD, bool LPHLJGDKOND, string IKPMEAIFENP = null, Action<ANAGHNCECEB> PHDGJMDIOFO = null, string OCLDAGFLIEO = "", KPGPFEAGMDE IBAPEKGNHHA = null)
	{
	}

	public void RunJoinRoomCode(JCDPHCELKHI KPFNANKNKLE, OPKEAIOICLJ FPDPBAPDONJ, string IKPMEAIFENP, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
	{
	}

	public void RunJoinDormRoom(HHCLMHEOLDA APFMLJLPMJD, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
	{
		var continuation = new DCJPFJNCODD();
		continuation._003C_003E4__this = this;
		continuation.loadSceneSourceData = APFMLJLPMJD;
		continuation.onResponseCallback = PHDGJMDIOFO;
		this.FMONLJPLGGG(null, continuation._003CRunJoinDormRoom_003Eb__0, continuation._003CRunJoinDormRoom_003Eb__1);
	}

	private void MLGHBPFMFNL(global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> BOJDPAGLBLI, Action<Matchmaking.DABKEMNEPLM> FFNHJDNOEKM)
	{
	}

	private void MLGHBPFMFNL(global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> BOJDPAGLBLI, Action<ANAGHNCECEB> FFNHJDNOEKM)
	{
		var response = new HJOICMNILEJ();
		response.optionalOnResponseCallback = FFNHJDNOEKM;
		Action<Matchmaking.DABKEMNEPLM> converted = null;
		if (response.optionalOnResponseCallback != null)
			converted = response._003CApplyOptionalResponseCallback_003Eb__0;
		var error = new OHJOOFNIBOK();
		error.optionalOnResponseCallback = converted;
		var capturedResponse = error.optionalOnResponseCallback;
		if (capturedResponse != null)
			BOJDPAGLBLI = BOJDPAGLBLI.EBIHDILAPPK(capturedResponse);
		BOJDPAGLBLI.LEFPGJEKFGF(error._003CApplyOptionalResponseCallback_003Eb__0);
	}

	private void GBIFOJCIOAC(LAHBDKNMNHN BOJDPAGLBLI, string KFBOLGLKOHF, Action<ANAGHNCECEB> FFNHJDNOEKM)
	{
	}

	public void RunJoinSubRoomOfCurrentRoom(OPKEAIOICLJ FPDPBAPDONJ, DBECJLAIPEL CFBNOKOADFB, PFPFLMJDKIB KHIJCFMFKHI, bool JDMCCJPEFCK, string OCLDAGFLIEO = "")
	{
	}

	public void RunJoinPlayer(JCDPHCELKHI KPFNANKNKLE, int PCKCPNGPNBJ, DBECJLAIPEL CFBNOKOADFB)
	{
	}

	public void RunAcceptRoomInvite(JCDPHCELKHI KPFNANKNKLE, DMAIEODHOGA EKDKLHOHIJD, DBECJLAIPEL CFBNOKOADFB)
	{
	}

	public void RunAcceptPartyInvite(JCDPHCELKHI KPFNANKNKLE, ChatMessage EIHDHHJOLFM, long LAJHHCIKFFH, Action<ANAGHNCECEB> PHDGJMDIOFO = null)
	{
	}

	public void RequestGameInvite(int PCKCPNGPNBJ, string KKMCHAOLGFB)
	{
	}

	private void FMONLJPLGGG(JCDPHCELKHI KPFNANKNKLE, Action<bool> OKDKEJOOEPP, Action ICIJNFGMPCA = null)
	{
		var gates = new GCDPLCKOKMP();
		gates._003C_003E4__this = this;
		gates.room = KPFNANKNKLE;
		gates.onConfirmed = OKDKEJOOEPP;
		gates.onCancel = ICIJNFGMPCA;
		this.MJCOOGAPIIB(gates.room, gates._003CDefaultRoomGates_003Eb__0, gates._003CDefaultRoomGates_003Eb__1);
	}

	public static bool HasLocalPlayerAlreadyAcceptedWarning(JCDPHCELKHI KPFNANKNKLE)
	{
		return false;
	}

	public static void ForceAcceptRoomWarnings(JCDPHCELKHI KPFNANKNKLE)
	{
	}

	private void MJCOOGAPIIB(JCDPHCELKHI KPFNANKNKLE, Action<bool> OKDKEJOOEPP, Action BNPCGIGFEGC = null)
	{
	}

	public void EnforceComfortAndMovementIfNextRoomIdEqualsThisRoomId()
	{
	}

	private static void LLIBLBPEPFI(JCDPHCELKHI KPFNANKNKLE, Action OKDKEJOOEPP, Action BNPCGIGFEGC)
	{
	}

	public bool JuniorPlayerJoinCheck(long BFFHFAKLJGN, bool FAAADCKNPEL = false)
	{
		return false;
	}

	public bool JuniorRoomCheck(OAHIIBBLMCD EJMOCIAPCPJ, bool FAAADCKNPEL = false)
	{
		return false;
	}

	private bool AEEBOJLCCHM(bool FAAADCKNPEL = false)
	{
		return false;
	}

	private void JBIGIDHODGP()
	{
	}

	private void KFGBIOFMANN()
	{
	}

	public void PlayerGoToDestinationGate(string ENKODABKJGB, Action OKDKEJOOEPP, Action BNPCGIGFEGC = null)
	{
	}

	private void NBLHIPAGGNK(string OFMGPNLDCAB, JCDPHCELKHI CEOPKGHMLGD, Action OKDKEJOOEPP, Action BNPCGIGFEGC = null, Action ICIJNFGMPCA = null)
	{
	}

	private void AIBFFJCEMGJ(Action OKDKEJOOEPP, Action BNPCGIGFEGC = null)
	{
	}

	private static string PJHEDNFBBIB(TimeSpan CHFDABLEFCC)
	{
		return null;
	}

	public void AddGameProgressSupport(object IALNODEHBNN)
	{
	}

	public void RemoveGameProgressSupport(object IALNODEHBNN)
	{
	}

	public void AddGameProgressSettings(BOEPHMOPEIM CAOIPCMMNMJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveGameProgressSettings(object IALNODEHBNN)
	{
	}

	private void NNCHOIACCHK(Action OKDKEJOOEPP, Action BNPCGIGFEGC = null)
	{
	}

	private bool HNEMFDPOHDJ()
	{
		return false;
	}

	private void BNDCNOENABP(Action OKDKEJOOEPP, Action BNPCGIGFEGC = null)
	{
	}

	private void FEHFEHGCBCC(Action OKDKEJOOEPP, Action BNPCGIGFEGC = null)
	{
	}

	public void CodeOfConductTutorialGate(JCDPHCELKHI KPFNANKNKLE, Action OKDKEJOOEPP, Action LEMPDDNGAPJ = null)
	{
	}

	public static bool IsCodeOfConductTutorialRequired(JCDPHCELKHI CEOPKGHMLGD)
	{
		return false;
	}

	public HHCLMHEOLDA PeekLastLoadSource()
	{
		return default;
	}

	public void SetLoadSceneSource(DBECJLAIPEL GLLFHCCFIGK)
	{
	}

	private void FNPMBKBLCGI(HHCLMHEOLDA APFMLJLPMJD)
	{
	}

	public void OnExitQuickLaunchSetLoadSceneSource()
	{
	}

	public static void OKCOKEMKAPA(Action JEHCEJMNKBE = null, Action HLMDDLBICJM = null)
	{
	}

	private static IEnumerator KHJHPDJAFGH(Action JEHCEJMNKBE = null, Action HLMDDLBICJM = null)
	{
		return null;
	}

	private LAHBDKNMNHN EOOGLHCLGEP()
	{
		return null;
	}

	public void ImportFriends(OILDLLGEMKP.LKLLEIKDHDD GLLFHCCFIGK, bool HCPJGECPEDN)
	{
	}

	private static LAHBDKNMNHN IMNBDELCIJG(OILDLLGEMKP.LKLLEIKDHDD GLLFHCCFIGK, bool HCPJGECPEDN = true)
	{
		return null;
	}

	public void ClearLeaveSceneStarted()
	{
	}

	private Matchmaking.DABKEMNEPLM? AINBEAHGDJI(string KNOPFGAGMCN, BNKIKFBACEL NIFOGEBEDNG)
	{
		return null;
	}

	private void FEGBDONJKEJ()
	{
	}

	private void LKMDEHBMNKG()
	{
	}

	private void JCFBMMFEFJB(string KNOPFGAGMCN, BNKIKFBACEL NIFOGEBEDNG, Matchmaking.DABKEMNEPLM MLDANHIGANI)
	{
	}

	private global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> IOLAKAGHJFF(JCDPHCELKHI KPFNANKNKLE, OPKEAIOICLJ FPDPBAPDONJ, bool LPHLJGDKOND, PFPFLMJDKIB KHIJCFMFKHI, bool NKAHNIDHKKE, string IKPMEAIFENP, string OCLDAGFLIEO, KPGPFEAGMDE IBAPEKGNHHA)
	{
		return null;
	}

	private global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> BAIJGDHFGKF(JCDPHCELKHI KPFNANKNKLE, OPKEAIOICLJ FPDPBAPDONJ, bool LPHLJGDKOND, PFPFLMJDKIB KHIJCFMFKHI, bool NKAHNIDHKKE, string IKPMEAIFENP, string OCLDAGFLIEO, KPGPFEAGMDE IBAPEKGNHHA = null)
	{
		return null;
	}

	private void EPKLNBOFEPP(OPKEAIOICLJ FPDPBAPDONJ, PFPFLMJDKIB KHIJCFMFKHI, bool NKAHNIDHKKE, bool JDMCCJPEFCK, string OCLDAGFLIEO)
	{
	}

	private void JFEGCLNCJPJ(IMIJPHJKLIM AJHKINNLKAK, PFPFLMJDKIB KHIJCFMFKHI, bool NKAHNIDHKKE, Matchmaking.KOGKIEBALBG HLMMKPAIPOI)
	{
	}

	public void BootLocalPlayerToDormRoom(string GIKEOHLLHFA, DBECJLAIPEL CFBNOKOADFB, bool OGPMCLNONOD = false)
	{
	}

	public void JoinPlayer(int PCKCPNGPNBJ, PFPFLMJDKIB KHIJCFMFKHI, bool NKAHNIDHKKE)
	{
	}

	private void CGNLGDCIEJH(DMAIEODHOGA EKDKLHOHIJD, PFPFLMJDKIB KHIJCFMFKHI, bool NKAHNIDHKKE)
	{
	}

	private global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> PDKODKKCEHJ(ChatMessage PAGMIJDHIEC, PFPFLMJDKIB KHIJCFMFKHI, bool NKAHNIDHKKE)
	{
		return null;
	}

	public int? GetPlayerIdToChangeScenesForParty()
	{
		return null;
	}

	public void LocalPlayerRequestJoinRoomScene(OPKEAIOICLJ FPDPBAPDONJ, DBECJLAIPEL CFBNOKOADFB, PFPFLMJDKIB KHIJCFMFKHI, bool JDMCCJPEFCK)
	{
	}

	public void LocalPlayerRequestJoinRoomSceneV2(OPKEAIOICLJ FPDPBAPDONJ, DBECJLAIPEL CFBNOKOADFB, PFPFLMJDKIB KHIJCFMFKHI, bool JDMCCJPEFCK, string OCLDAGFLIEO = "")
	{
	}

	private bool JLMPMBDDHCB(DBECJLAIPEL GLLFHCCFIGK)
	{
		return false;
	}

	private global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> CKIFCJCBNLA(string OFCFPGACNJB, PFPFLMJDKIB KHIJCFMFKHI, Func<int[], global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM>> AFLCHHFPDKN)
	{
		return null;
	}

	private void BHPLNMNFJOH(Matchmaking.DABKEMNEPLM COKEHKMDIDL)
	{
	}

	public static void GetJoinGameErrorCodeMessage(Matchmaking.DABKEMNEPLM COKEHKMDIDL, out string OFMGPNLDCAB, out string OFCFPGACNJB)
	{
		OFMGPNLDCAB = null;
		OFCFPGACNJB = null;
	}

	private IEnumerator CHPINCIPKCO(string OFCFPGACNJB)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> MNMAFEANEBM()
	{
		return null;
	}

	public bool VerifyAccountRequirements()
	{
		return false;
	}

	private static void IFLKCGJPAAJ(NOFHIODEAHA.OGFFHAFDGDP FJLKFMLMIPK)
	{
	}

	public static void TryApplicationQuit()
	{
	}

	public static void TryApplicationQuit(int PDFNEIPHEDI)
	{
	}

	public static void FatalApplicationQuit(int PDFNEIPHEDI, string OFCFPGACNJB = "")
	{
	}

	public static void ResetForReLogin()
	{
	}

	public static LAHBDKNMNHN LogoutToBootScene()
	{
		return null;
	}

	public static Task LogoutToBootSceneAsync()
	{
		return null;
	}

	private static void PAHCCAIKDML()
	{
	}

	public global::NCOKFFGPIJM<bool> CheckForAndHandlePlatformFriendOrTextMessageReferrers()
	{
		return null;
	}

	private global::NCOKFFGPIJM<DFDECAEJBIO> CGMELOOGNOP(int EJIHLJJMOBD, string EMLJIHEPIFJ)
	{
		return null;
	}

	private global::NCOKFFGPIJM<bool> FIHBKDIOBEI(List<DFDECAEJBIO> AGIGKKMBEKN)
	{
		return null;
	}

	private void GIADBNFAKBN(COMHCCBONLA EPNHKIFLGGK)
	{
	}

	private void COADHAMEBKD()
	{
	}

	[CompilerGenerated]
	private void ONBIAINMIDH(OBJGJAGAOLC DDKCONDPEJF)
	{
	}

	[CompilerGenerated]
	private void LIAFIIGIAHA()
	{
	}

	[CompilerGenerated]
	private bool BGKMHMMAMNK()
	{
		return false;
	}

	[CompilerGenerated]
	private void EHHKENAMHMF()
	{
	}

	[CompilerGenerated]
	private bool ACJLIBJFKOP()
	{
		return false;
	}

	[CompilerGenerated]
	private void NPANFDHHLGI()
	{
	}

	[CompilerGenerated]
	private void GJKHNLEPFIL(string NLJOHEKGNDH)
	{
	}

	[CompilerGenerated]
	private void PPHKGPPJHHG(Matchmaking.DABKEMNEPLM MLDANHIGANI)
	{
	}

	[CompilerGenerated]
	private global::NCOKFFGPIJM<List<DFDECAEJBIO>> LIHOMPAHGGM(Tuple<List<int>, List<int>> HGDEKAIJEGH)
	{
		return null;
	}
}
