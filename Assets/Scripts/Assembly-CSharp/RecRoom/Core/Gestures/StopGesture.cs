using UnityEngine;

namespace RecRoom.Core.Gestures
{
	public class StopGesture : HandGestureBase
	{
		private enum GKIMGDDPFDI
		{
			Inactive = 0,
			Started = 1,
			Charging = 2,
			Completed = 3
		}

		[SerializeField]
		private float handHeadDotThreshold;

		[SerializeField]
		private float palmDirectionDotThreshold;

		[SerializeField]
		private float fingerUpDotThreshold;

		[SerializeField]
		private float maximumDistance;

		[SerializeField]
		private float chargingDelay;

		[SerializeField]
		private float chargingDuration;

		private MDEJADHJOEJ BGBIFFLGANM;

		private float GMLFJEDECFO;

		private GestureTarget HALDNKMFNEK;

public override bool IsBlockingOtherGestures
{
get 		{
			return false;
		}

}

private GKIMGDDPFDI MBHNCCMHIPK
{
get 		{
			return GKIMGDDPFDI.Inactive;
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

		private void LMMHKJJDDBL()
		{
		}

		private void MBPHEIAKBMH(ushort PLPOPJIKGFK, ushort LNKOCAGCFLP)
		{
		}

		private void NDPCOMMPBBN()
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

		private void KNODMLGLAEF(PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, bool MAOKBDCHHGG)
		{
		}

		private bool EECKKMNCFDA()
		{
			return false;
		}

		private GestureTarget MECCDGCGPFA(Ray HAAAJDJGEFF)
		{
			return null;
		}

		private bool CHAOMBFLHMI()
		{
			return false;
		}

		private bool FBJEAILMDHJ()
		{
			return false;
		}
	}
}
