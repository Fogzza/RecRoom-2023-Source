using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class OpenableChestInteractionEncounterStartTrigger : GameEncounterStartTrigger
	{
		private enum CIHOMHHMFMN
		{
			OPEN = 0,
			OPENING = 1,
			CLOSE = 2
		}

		[SerializeField]
		private BaseOpenableChest chest;

		[SerializeField]
		private CIHOMHHMFMN requiredInteraction;

		private bool IFALFDBKPLK;

		private bool HGEHALPDGMF;

		private bool HGGHCHIPPND;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnAwake(GameEncounter CGBFJFNKJFN, int IJNHGKCENED)
		{
		}

		public override void OnCleanup()
		{
		}

		public override bool IsTriggered()
		{
			return false;
		}

		public override void StartListening()
		{
		}

		public override void StopListening()
		{
		}

		private void IEEHHONMJGK(BaseOpenableChest LAPCEBGFIOK)
		{
		}

		private void MJCNPOOKNHM(BaseOpenableChest LAPCEBGFIOK)
		{
		}

		private void LAOMOJONPPG(BaseOpenableChest LAPCEBGFIOK)
		{
		}
	}
}
