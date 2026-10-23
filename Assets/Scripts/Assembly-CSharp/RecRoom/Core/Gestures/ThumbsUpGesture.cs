using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Core.Gestures
{
	public class ThumbsUpGesture : HandGestureBase
	{
		private enum ANALIBCONPP
		{
			Inactive = 0,
			Started = 1,
			Playing = 2,
			Charging = 4,
			Completed = 5
		}

		[SerializeField]
		private float startDelay;

		[SerializeField]
		private float startAngleThreshold;

		[SerializeField]
		private float handHeadDotThreshold;

		[SerializeField]
		private float maxChargeDistance;

		[SerializeField]
		private float chargingDuration;

		[SerializeField]
		private float chargingDelay;

		private VRInputHandler NCBEHMGEJPC;

		private MDEJADHJOEJ BGBIFFLGANM;

		private float CHBHJHLJKPD;

		private float GDBNGDJHFLG;

		private float OPBONDALPHD;

		private GestureTarget DJMEHKBBOEL;

public override bool IsBlockingOtherGestures
{
get 		{
			return false;
		}

}

private ANALIBCONPP PDNLFEICPGG
{
get 		{
			return ANALIBCONPP.Inactive;
		}

set {
		}
}

		public override void Cancel()
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void ONCKMBEJGAD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void LMMHKJJDDBL()
		{
		}

		private void NDPCOMMPBBN()
		{
		}

		private void MPFLOKCFABA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void COAJLFMFLDL()
		{
		}

		private void FEDBHKJBAGN(ushort PLPOPJIKGFK, ushort LNKOCAGCFLP)
		{
		}

		private void AJGEKOMOPGO()
		{
		}

		private void NAGDEAEKGHF(ushort PLPOPJIKGFK, ushort LNKOCAGCFLP)
		{
		}

		private void NBBLHFOFDJN(ushort PLPOPJIKGFK, ushort LNKOCAGCFLP)
		{
		}

		private bool ELBIKJGDLAI()
		{
			return false;
		}

		private bool GIAPEFPNAIM()
		{
			return false;
		}

		private bool NLELBNEGEHP()
		{
			return false;
		}

		private bool LAEACKFGJPD()
		{
			return false;
		}

		private GestureTarget MECCDGCGPFA(Ray HAAAJDJGEFF)
		{
			return null;
		}

		private bool FELMELKEDAG()
		{
			return false;
		}

		private void KNODMLGLAEF(PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, bool MAOKBDCHHGG)
		{
		}
	}
}
