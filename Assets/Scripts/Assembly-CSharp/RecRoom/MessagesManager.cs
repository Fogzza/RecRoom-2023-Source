using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RecRoom
{
	public class MessagesManager : SingletonMonoBehaviour<MessagesManager>
	{
		private sealed class CJIJONJEPEF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MessagesManager _003C_003E4__this;

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
			public CJIJONJEPEF(int _003C_003E1__state)
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

		public const string LAST_VIEWED_NOTIFICATIONS_PREF = "LastViewedNotificationsTimestamp";

		private Action<DMAIEODHOGA> KBGKLEOIDMJ__BackingField;

		private DateTime? JPHKAJKAJAN;

		private LKGILLBEJEK PPNLNPCDNKI;

		private readonly HashSet<DMAIEODHOGA> EOPEHJFCNAF;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private CDLILHDKGGD HEKDJDKMAPC;

public event Action<DMAIEODHOGA> NotificationRead {
add {
		}
remove {
		}
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

		public void UpdateMessageCounts()
		{
		}

		public bool IsNotificationUnread(DMAIEODHOGA PBOPFHHBNPO)
		{
			return false;
		}

		public bool IsNonMessageNotificationUnread(DateTime BHDBFLMGENC, EOOFCNPHMKG.KLOEDHJLIFF JNKJFJLJKNJ, int DNENAPMBGDO)
		{
			return false;
		}

		public void MarkNotificationAsRead(DMAIEODHOGA PBOPFHHBNPO)
		{
		}

		public void MarkAllNotificationsAsRead()
		{
		}

		public void MarkAllCategoryNotificationsAsRead(EOOFCNPHMKG.KLOEDHJLIFF JNKJFJLJKNJ, int MKNOBDHGMAH)
		{
		}

		public void GetUnreadNotificationsAndChatsCount(out int AEECGLNEHBH, out int CPEFHMCAHJP)
		{
			AEECGLNEHBH = default;
			CPEFHMCAHJP = default;
		}

		private bool BFKBPLHOKLH(DateTime BHDBFLMGENC, EOOFCNPHMKG.KLOEDHJLIFF JNKJFJLJKNJ, int MKNOBDHGMAH)
		{
			return false;
		}

		private DateTime BDNIFDLMBNN()
		{
			return default;
		}

		private IEnumerator<EGGPGCCKPCO> AOJJGBNNFMB()
		{
			return null;
		}

		private void BBFAJKIBPNO(FMEDMCFGHFM FEDCNPJJGCF)
		{
		}

		[CompilerGenerated]
		private bool FFPACGHMBHP(DMAIEODHOGA OPFODHFENED)
		{
			return false;
		}

		[CompilerGenerated]
		private bool NKEMINMOHIA()
		{
			return false;
		}
	}
}
