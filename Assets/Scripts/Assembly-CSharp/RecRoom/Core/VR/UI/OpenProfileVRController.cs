using System;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Core.VR.UI
{
	[Serializable]
	public class OpenProfileVRController
	{
		private enum HMOGMKCIKHF
		{
			Point = 0,
			Look = 1
		}

		private class DJPLIBMFFKB
		{
			public VRInputHandler JLFMCCADIKH;

			public PlayerHand BJBDPCNDCLN;

			public DJPLIBMFFKB MNEFINLGBAO;

			private bool FHNCMIKIEPI;

			private float HCJMAMFOKJE;

			private bool DDKOLHKEAFJ;

			private Player OFDGIMCAGED;

			private bool DKMCBHNDIIN;

private int LDHIBGALEDK
{
get 			{
				return 0;
			}

}

public Sprite HMCOMNEBABM
{
get 			{
				return null;
			}

}

public Player ODILGOLGKOO
{
get 			{
				return null;
			}

set {
			}
}

public bool MECFJKJHCDO
{
get 			{
				return false;
			}

}

public bool EOBNGEOLAGC
{
get 			{
				return false;
			}

}

			public void CDJHKCNAIKI(float MJJEOMMNJDB)
			{
			}

			private void KJBMLJDLMBH()
			{
			}

			private void LOPOMGMOEBH()
			{
			}
		}

		private HMOGMKCIKHF targetingMethod;

		[SerializeField]
		private float preciseSphereCastRadius;

		[SerializeField]
		private float preciseSphereCastDistance;

		[SerializeField]
		public float broadSphereCastRadius;

		[SerializeField]
		public float broadSphereCastDistance;

		[SerializeField]
		private float maxViewportDistanceFromCenter;

		private float requiredInputHoldTime;

		private const float TIME_BETWEEN_TARGETING_UPDATES = 0.1f;

		private float lastTargetingUpdateTime;

		private DJPLIBMFFKB leftHandState;

		private DJPLIBMFFKB rightHandState;

		public void IHEKMEOIBOI(Player EKOFNPFCLMO, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE)
		{
		}

		public void EHMICKMBCPH(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera DGAEHOFGAIH, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE)
		{
		}

		private void ACDIMNIGAFF(Camera FABOOBMDLAK, DJPLIBMFFKB BELKECMBLOD)
		{
		}
	}
}
