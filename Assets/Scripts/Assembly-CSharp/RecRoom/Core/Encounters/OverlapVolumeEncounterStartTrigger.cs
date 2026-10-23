using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Activities.Quest;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class OverlapVolumeEncounterStartTrigger : GameEncounterStartTrigger
	{
		public enum GIEIODMAFND
		{
			ONE_PLAYER = 0,
			ALL_PLAYERS = 1
		}

		[Serializable]
		public struct StoryStateDependantNotification
		{
			public QuestManager.PCGJIMCMLHD roomStoryState;

			public string notYetTriggeredNotification;
		}

		private sealed class AGHGDKKNFPK : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string notification;

			public OverlapVolumeEncounterStartTrigger _003C_003E4__this;

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
			public AGHGDKKNFPK(int _003C_003E1__state)
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
		public EncounterOverlapVolume[] volumes;

		[SerializeField]
		public GIEIODMAFND playerRequirement;

		[SerializeField]
		private string defaultNotYetTriggeredNotification;

		[SerializeField]
		private StoryStateDependantNotification[] roomStoryStateNotifications;

		private Coroutine ENCJNBIJNDE;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnCleanup()
		{
		}

		public override void StartListening()
		{
		}

		public override void StopListening()
		{
		}

		public override bool IsTriggered()
		{
			return false;
		}

		private void HLHDPILMGDD(OverlapVolume KBAMDKNOBOG)
		{
		}

		private void FIKADMBMCIE()
		{
		}

		private IEnumerator FEBFGAKEIMH(string PBOPFHHBNPO)
		{
			return null;
		}

		private string IDDJEHPKEKH()
		{
			return null;
		}
	}
}
