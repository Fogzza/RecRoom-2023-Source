using RecRoom.Core.Creation;
using RecRoom.Inputs;

namespace RecRoom.Tools
{
	public class SandboxGunHandleVRController : VRToolController
	{
		private enum DAMEHIAHCJP
		{
			DISABLED = 0,
			IDLE = 1,
			FIRING = 2,
			RELOAD = 3
		}

		private MDEJADHJOEJ primaryStateMachine;

		private SandboxGunHandle gunHandle;

		private SandboxGunHandleReloader reloader;

		private Player player;

		private VRInputHandler handInput;

		private VRInputHandler offHandInput;

		private float reloadStartTime;

		private const float RELOAD_HAIR_TRIGGER_BUTTON_TIME_SECONDS = 0.1f;

		private bool HasReloadTimeCompleted => false;

		private float HairTriggerTimeHeld => 0f;

		public override bool HKPHNNBHELJ(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Tool IEGMBEPJMGC, PlayerHand LIEHAPOPALF, PlayerHand AOBDJCJLKOL, VRInputHandler COHAGCOFPIE, VRInputHandler LHAOJGAGGLM)
		{
			return false;
		}

		public override void BJDNGFKFKPK(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Tool IEGMBEPJMGC, PlayerHand LIEHAPOPALF, PlayerHand AOBDJCJLKOL, VRInputHandler COHAGCOFPIE, VRInputHandler LHAOJGAGGLM)
		{
		}

		public override void KENBMBNOMKI(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Tool IEGMBEPJMGC, PlayerHand LIEHAPOPALF, PlayerHand AOBDJCJLKOL, VRInputHandler COHAGCOFPIE, VRInputHandler LHAOJGAGGLM)
		{
		}

		public override bool EHMICKMBCPH(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Tool IEGMBEPJMGC, PlayerHand LIEHAPOPALF, PlayerHand AOBDJCJLKOL, VRInputHandler COHAGCOFPIE, VRInputHandler LHAOJGAGGLM)
		{
			return false;
		}

		private void KFGKALPCCPA(VRInputHandler COHAGCOFPIE)
		{
		}

		private void MPBJLGJNLMD()
		{
		}

		private void AHKLHABNGEB()
		{
		}

		private void EGKDFECDPBH(ushort BFCAFJCFELI, ushort JIDAFOMKMGC)
		{
		}

		private void NHMCEEOEAGE()
		{
		}

		private void DNMFJFHMCKL(ushort BFCAFJCFELI, ushort JIDAFOMKMGC)
		{
		}

		private bool MNBLHKAOGHJ()
		{
			return false;
		}

		private bool IAGGPGPEENM()
		{
			return false;
		}
	}
}
