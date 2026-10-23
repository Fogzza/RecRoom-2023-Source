using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RRUI.Navigation;
using RecNet;
using RecRoom.Core;

namespace RecRoom.Sharing
{
	public class FriendCode : ActionCode
	{
		private sealed class MMAKIAKKGHC
		{
			public Route RRUIShareRoute;

			public FriendCode _003C_003E4__this;

			public bool removeCurrentUriFromHistory;

			internal void _003CCreateAndShare_003Eb__0(NMLEIPDLABI result)
			{
			}
		}

		private sealed class JFPIKNDDECE
		{
			public LinkManager.OPICCOMKOOF pendingLink;

			internal global::NCOKFFGPIJM<bool> _003CHandle_003Eb__0(DFDECAEJBIO account)
			{
				return null;
			}
		}

		private sealed class HJBEEONDOAK
		{
			public DFDECAEJBIO friend;

			public BootSequence.NJIJPADHPEC launchTarget;

			public FriendCode _003C_003E4__this;

			public string friendAddFailureTitle;

			public string friendAddFailureBody;

			public Action<string> onError;

			public Action onSuccess;

			public Action<bool> _003C_003E9__7;

			public Func<PJFDADLIKCD, LAHBDKNMNHN> _003C_003E9__6;

			internal LAHBDKNMNHN _003CFriendAndChatOrGoToAccount_003Eb__0()
			{
				return null;
			}

			internal LAHBDKNMNHN _003CFriendAndChatOrGoToAccount_003Eb__1()
			{
				return null;
			}

			internal global::NCOKFFGPIJM<EOKKPHLOBBD> _003CFriendAndChatOrGoToAccount_003Eb__2()
			{
				return null;
			}

			internal LAHBDKNMNHN _003CFriendAndChatOrGoToAccount_003Eb__3(EOKKPHLOBBD relationship)
			{
				return null;
			}

			internal LAHBDKNMNHN _003CFriendAndChatOrGoToAccount_003Eb__6(PJFDADLIKCD friendPresence)
			{
				return null;
			}

			internal void _003CFriendAndChatOrGoToAccount_003Eb__7(bool willGoToFriend)
			{
			}

			internal void _003CFriendAndChatOrGoToAccount_003Eb__4(string x)
			{
			}

			internal void _003CFriendAndChatOrGoToAccount_003Eb__5()
			{
			}
		}

		private sealed class LGNEGHHJDBH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public DFDECAEJBIO friendAccount;

			public FriendCode _003C_003E4__this;

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
			public LGNEGHHJDBH(int _003C_003E1__state)
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

		private sealed class EKMJBBPONMB
		{
			public FriendCode _003C_003E4__this;

			public DFDECAEJBIO friendAccount;

			internal bool _003CGoToAddedFriendAndAutoParty_003Eb__0(Matchmaking.DABKEMNEPLM matchmakingErrorCode)
			{
				return false;
			}
		}

		private sealed class FAJAHCFHMEM
		{
			public WatchUI watchUI;

			public string friendAddFailureTitle;

			public string friendAddFailureBody;

			public DBIPHDIEBCM promise;

			public Action _003C_003E9__1;

			internal void _003CMessageUserForFriendAddFailure_003Eb__0(string url)
			{
			}

			internal void _003CMessageUserForFriendAddFailure_003Eb__1()
			{
			}
		}

		private sealed class JHLNFDPFPIE
		{
			public NMLEIPDLABI result;

			public string copyableText;

			public FAJAHCFHMEM CS_0024_003C_003E8__locals1;

			internal void _003CMessageUserForFriendAddFailure_003Eb__2(HGKINAOMNIF response)
			{
			}
		}

		private static DFDECAEJBIO CBEMJKOHOGN;

		public override global::NCOKFFGPIJM<NMLEIPDLABI> Create(object ADCFFAJGNAM)
		{
			return null;
		}

		public override string GetTitleText()
		{
			return null;
		}

		public override string GetDescriptionText()
		{
			return null;
		}

		public override LAHBDKNMNHN CreateAndShare(Route JGMLNNDKOOH, bool GMEKLDALJKC, object ADCFFAJGNAM)
		{
			return null;
		}

		public override string GetFullShareMessage(string FKKHPIMPJBP, string PEDLJMJDBPA, bool MHIOBEJKDFA)
		{
			return null;
		}

		public override LAHBDKNMNHN Handle(LinkManager.OPICCOMKOOF EDDMIJOKMNC)
		{
			return null;
		}

		public override void ModifyPreAuthLaunchTarget(BootSequence.NJIJPADHPEC DBGKIJIDIGJ, LinkManager.OPICCOMKOOF EDDMIJOKMNC)
		{
		}

		public void FriendAndChatOrGoToAccount(DFDECAEJBIO NFBLEIFBPBP, string EMLJIHEPIFJ, string MMPNJNNBJJC, string CPNJIJPBFHH, string OFNJCMLAPMK, string CELAIKDIPME, string JNJFGLCKLIN, Action CIGLFDHALPM = null, Action<string> KDEMNGCACLF = null)
		{
		}

		private void EFIJGBIEHBE(int AFBGIPGHBMO, string EMLJIHEPIFJ, string OPBGAHFLOHI)
		{
		}

		private void MIOMIHCMPPF()
		{
		}

		private IEnumerator<EGGPGCCKPCO> FIELBHJGJLE(DFDECAEJBIO OANJBBGNEEO)
		{
			return null;
		}

		private global::NCOKFFGPIJM<bool> KJHHLECKPHN(DFDECAEJBIO OANJBBGNEEO)
		{
			return null;
		}

		private LAHBDKNMNHN KPOGIEJBPIG(string CELAIKDIPME, string JNJFGLCKLIN)
		{
			return null;
		}
	}
}
