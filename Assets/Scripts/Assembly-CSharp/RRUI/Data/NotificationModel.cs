using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using RecNet;
using UnityEngine;

namespace RRUI.Data
{
	public class NotificationModel : RRUIModel
	{
		public class IFKGMHMDDIO : IDisposable
		{
			private Action NGJEMBBNPCM;

			public IFKGMHMDDIO(Action NGJEMBBNPCM)
			{
			}

			public void Dispose()
			{
			}
		}

		private sealed class EFBEOAFPNCC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public NotificationModel _003C_003E4__this;

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
			public EFBEOAFPNCC(int _003C_003E1__state)
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

		private sealed class EPKEHGBOBJH
		{
			public ChatMessage chatMessage;

			public NotificationModel _003C_003E4__this;

			public Action _003C_003E9__2;

			internal void _003CToastForNewMessage_003Eb__0(string text)
			{
			}

			internal void _003CToastForNewMessage_003Eb__2()
			{
			}
		}

		private sealed class JMNOOIJOAEO
		{
			public string text;

			public EPKEHGBOBJH CS_0024_003C_003E8__locals1;

			internal void _003CToastForNewMessage_003Eb__1(DFDECAEJBIO account)
			{
			}
		}

		private sealed class ANICBDNBFHN
		{
			public NotificationModel _003C_003E4__this;

			public IFKGMHMDDIO token;

			internal void _003CDisableAllChatNotifications_003Eb__0()
			{
			}
		}

		private sealed class AFPAGHCIOBA
		{
			public NotificationModel _003C_003E4__this;

			public FMEDMCFGHFM chatThread;

			internal void _003CDisableChatNotificationsForThread_003Eb__0()
			{
			}
		}

		private AHJNDOAGBDE AJCHGBGGJFK;

		[SerializeField]
		private Route chatThreadRoute;

		private List<IFKGMHMDDIO> DDBKIPEOOKA;

		private List<long> BCHNMLFIFMM;

		private CDLILHDKGGD HEKDJDKMAPC;

		private int MILIOCCBOEF;

		private int JCGJIMMPLOK;

		private int GBBHEHHBPPP;

		private int JADCNMKBBBO;

		private LKGILLBEJEK CCLFOIDMIDA;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

private bool EBBEAAJPIJC
{
get 		{
			return false;
		}

}

public int UnreadNotificationCount
{
get 		{
			return 0;
		}

private set {
		}
}

public int UnreadChatThreadsCount
{
get 		{
			return 0;
		}

private set {
		}
}

public int UnreadFriendRequestCount
{
get 		{
			return 0;
		}

private set {
		}
}

public int UnreadNotificationCountIgnoringFriendRequests
{
get 		{
			return 0;
		}

private set {
		}
}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		private void HGCLDCKJLON(PIMDBGKAIBE.MMANGNBCADN EIKNIKMJMOP, DMAIEODHOGA OFCFPGACNJB)
		{
		}

		private void PCJEAMDGGDB(FMEDMCFGHFM FEDCNPJJGCF)
		{
		}

		private void ODDOGAADICE()
		{
		}

		private IEnumerator<EGGPGCCKPCO> KHMJJHAMNNK()
		{
			return null;
		}

		private void LDOJKFDBJDH(ChatMessage EMLJIHEPIFJ)
		{
		}

		private void IENGIOGJIMP(ChatMessage EMLJIHEPIFJ)
		{
		}

		public IFKGMHMDDIO DisableAllChatNotifications()
		{
			return null;
		}

		public IFKGMHMDDIO DisableChatNotificationsForThread(FMEDMCFGHFM AAMFKNLLGDC)
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override void BJPPPBGBLAO()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		[CompilerGenerated]
		private void IEMACFLGKBF()
		{
		}
	}
}
