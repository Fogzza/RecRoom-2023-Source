using System;
using RecRoom.Inputs;
using RecRoom.Tools;
using RecRoom.Tools.MakerPenTools;
using UnityEngine;

namespace RecRoom.Core
{
	[Serializable]
	public class VRCreationController : CreationController
	{
		[SerializeField]
		private MakerPenVROffHandTranslate_Object translateObjectOffHandOperation;

		[SerializeField]
		private MakerPenVROffHandTranslate_Shape translateShapeOffHandOperation;

		[NonSerialized]
		private MDEJADHJOEJ offHandStateMachine;

		[NonSerialized]
		private bool isInitialized;

		[NonSerialized]
		private IDisposable updateToken;

		public VRPlayerController VRPlayerController { get; private set; }

		public VRInputHandler ToolInput { get; private set; }

		public VRInputHandler OffHandInput { get; private set; }

		public PlayerHand OffHand { get; private set; }

		protected override Transform InternalTransform => null;

		public override DLLIMLHNBON SelectInputButtonState => default;

		public override float AnalogInputValue => 0f;

		public override Ray GFDICPJIEJB()
		{
			return default;
		}

		public override Vector3 ILLMHPKDFLD(float PNJHHGDHBEC)
		{
			return default;
		}

		public override void IHEKMEOIBOI()
		{
		}

		public void BJDNGFKFKPK(VRPlayerController PEKNCFLMOPM, Player EKOFNPFCLMO, MakerPen BHCCDMJFHEO, PlayerHand AOBDJCJLKOL, VRInputHandler COHAGCOFPIE, VRInputHandler LHAOJGAGGLM)
		{
		}

		public bool EHMICKMBCPH(VRPlayerController PEKNCFLMOPM, Player EKOFNPFCLMO, VRInputHandler BOJFBCHDIDI, VRInputHandler LHAOJGAGGLM)
		{
			return false;
		}

		public void KENBMBNOMKI(VRPlayerController PEKNCFLMOPM)
		{
		}

		public void DHKKHNECCLK(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO)
		{
		}

		private bool KIMCABJHFCJ(LMFLCFFHNOF PCNPMPMHGHF, Player EKOFNPFCLMO, Vector3 GFIGODPPIKP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}

		private void LFJAOFNBBJO(HHNPLBOFAGE IACECANFEKI, MakerPenVROffHandOperation MBPAJKHNIHF)
		{
		}

		protected override void HHLDDEGPLKP(FBEHJNCKJPN CIMCLAFMGFE, HHNPLBOFAGE IACECANFEKI)
		{
		}
	}
}
