using UnityEngine;
using UnityEngine.Localization;

namespace RecRoom.Core.Encounters
{
	public class ShowNotificationEncounterStep : GameEncounterStep
	{
		public enum KEDPJEIJBBG
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		[SerializeField]
		private string mainNotificationText;

		[SerializeField]
		private LocalizedString mainNotificationTextLocalized;

		[SerializeField]
		private string secondaryNotificationText;

		[SerializeField]
		private LocalizedString secondaryNotificationTextLocalized;

		[SerializeField]
		private float notificationDuration;

		[SerializeField]
		private PCBHIGOMCDE notificationType;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnEncounterStart()
		{
		}

		public override void OnEncounterStop()
		{
		}

		public override void OnStartRunning()
		{
		}

		public override void OnUpdateRunning()
		{
		}

		public override void OnStopRunning()
		{
		}

		public override void OnSkipRunning()
		{
		}

		public override bool IsBlockingEncounterEnd()
		{
			return false;
		}

		public override bool IsCompleted()
		{
			return false;
		}
	}
}
