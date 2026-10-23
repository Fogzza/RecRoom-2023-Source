using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom
{
	public class PlayerEventEngagementManager : SingletonMonoBehaviour<PlayerEventEngagementManager>
	{
		private sealed class DBENDPJNCGH
		{
			public PlayerEventEngagementManager _003C_003E4__this;

			public long roomInstanceId;

			internal void _003COnFirstTimeEnteringEventCoroutine_003Eb__0(IMIJPHJKLIM playerEvent)
			{
			}
		}

		private sealed class PFDNPGKEAOA
		{
			public IMIJPHJKLIM playerEvent;

			public DBENDPJNCGH CS_0024_003C_003E8__locals1;

			internal void _003COnFirstTimeEnteringEventCoroutine_003Eb__1(HGKINAOMNIF response)
			{
			}
		}

		private sealed class MCKLMKBKHKE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PlayerEventEngagementManager _003C_003E4__this;

			public long playerEventId;

			private DBENDPJNCGH _003C_003E8__1;

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
			public MCKLMKBKHKE(int _003C_003E1__state)
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

		private readonly HashSet<long> LNHJKHDBGMM;

		[SerializeField]
		private float invitePromptEventCapacityThreshold;

		[SerializeField]
		private InviteFriendsDialog inviteFriendsDialogPrefab;

		[SerializeField]
		private float invitePromptDelaySeconds;

		protected override void Awake()
		{
		}

		private void OHFNLPLADGL()
		{
		}

		private IEnumerator<EGGPGCCKPCO> CBHFKPKDNEJ(long NJJFDENHGKK)
		{
			return null;
		}

		private void CMPPIJDEKJF(IMIJPHJKLIM IGGPIMCKMBP)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
