using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RRUI.Navigation;

namespace RecRoom.Sharing
{
	public class MeetupCode : ActionCode
	{
		[Serializable]
		private struct MeetupData
		{
			public long RoomId;

			public long SubRoomId;
		}

		private sealed class OIDKJMKJPMF
		{
			public MeetupCode _003C_003E4__this;

			public LinkManager.OPICCOMKOOF pendingLink;

			public long roomId;

			public string actionCode;

			internal void _003CHandle_003Eb__0(bool success)
			{
			}
		}

		private sealed class NCGGFDFBLEK
		{
			public JCDPHCELKHI room;

			public string roomCode;

			public OPKEAIOICLJ subRoom;

			public Action onSuccess;

			public Action<string> onError;

			public Action<ANAGHNCECEB> _003C_003E9__1;

			internal void _003CGoToMeetup_003Eb__0()
			{
			}

			internal void _003CGoToMeetup_003Eb__1(ANAGHNCECEB result)
			{
			}
		}

		private sealed class MECOMKBNDGM
		{
			public Route RRUIShareRoute;

			public Configuration config;

			public bool removeCurrentUriFromHistory;

			internal global::NCOKFFGPIJM<NMLEIPDLABI> _003CGetOrCreateAndShareMeetupLink_003Eb__0(string url)
			{
				return null;
			}
		}

		private sealed class BHDNBIKFDBG
		{
			public NMLEIPDLABI result;

			internal NMLEIPDLABI _003CGetOrCreateAndShareMeetupLink_003Eb__2(string x)
			{
				return default;
			}
		}

		private sealed class MHENDKNMNLG
		{
			private sealed class _003C_003CMeetupHostFlow_003Eg__WaitForRoomChangeAndRecallMeetupFlow_007C4_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				private NIOFDDAOAHB _003C_003E8__1;

				public MHENDKNMNLG _003C_003E4__this;

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
				public _003C_003CMeetupHostFlow_003Eg__WaitForRoomChangeAndRecallMeetupFlow_007C4_003Ed(int _003C_003E1__state)
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

			public Route RRUIShareRoute;

			public bool removeCurrentUriFromHistory;

			public Action<ANAGHNCECEB> _003C_003E9__5;

			public Action _003C_003E9__6;

			internal void _003CMeetupHostFlow_003Eb__0(HGKINAOMNIF result)
			{
			}

			internal void _003CMeetupHostFlow_003Eb__5(ANAGHNCECEB joinRoomResult)
			{
			}

			internal void _003CMeetupHostFlow_003Eb__1(HGKINAOMNIF result)
			{
			}

			internal void _003CMeetupHostFlow_003Eb__6()
			{
			}

			internal void _003CMeetupHostFlow_003Eb__2(HGKINAOMNIF result)
			{
			}

			internal void _003CMeetupHostFlow_003Eg__CreateOrShowMeetupInfo_007C3()
			{
			}

			internal IEnumerator<EGGPGCCKPCO> _003CMeetupHostFlow_003Eg__WaitForRoomChangeAndRecallMeetupFlow_007C4()
			{
				return null;
			}
		}

		private sealed class NIOFDDAOAHB
		{
			public EGGMEJDMHKF room;

			internal bool _003CMeetupHostFlow_003Eb__8()
			{
				return false;
			}
		}

		private sealed class KAJPAGJCKGD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

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
			public KAJPAGJCKGD(int _003C_003E1__state)
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

		private static string JGKCBKFJNOF;

		public override global::NCOKFFGPIJM<NMLEIPDLABI> Create(object ADCFFAJGNAM)
		{
			return null;
		}

		public override LAHBDKNMNHN CreateAndShare(Route JGMLNNDKOOH, bool GMEKLDALJKC, object ADCFFAJGNAM)
		{
			return null;
		}

		public override LAHBDKNMNHN Handle(LinkManager.OPICCOMKOOF EDDMIJOKMNC)
		{
			return null;
		}

		public static void GoToMeetup(JCDPHCELKHI KPFNANKNKLE, OPKEAIOICLJ FPDPBAPDONJ, string IKPMEAIFENP, Action CIGLFDHALPM = null, Action<string> KDEMNGCACLF = null)
		{
		}

		public override void ModifyPreAuthLaunchTarget(BootSequence.NJIJPADHPEC DBGKIJIDIGJ, LinkManager.OPICCOMKOOF EDDMIJOKMNC)
		{
		}

		private static global::NCOKFFGPIJM<NMLEIPDLABI> IIDDAFMKNAG(Route JGMLNNDKOOH, bool GMEKLDALJKC)
		{
			return null;
		}

		private static void FKKICGLFIDB(bool PJJDLMEBKIH, Route JGMLNNDKOOH, bool GMEKLDALJKC)
		{
		}

		private static void HOAHOFEFGBK()
		{
		}

		[CompilerGenerated]
		internal static IEnumerator<EGGPGCCKPCO> NFJHHFHHKEB()
		{
			return null;
		}
	}
}
