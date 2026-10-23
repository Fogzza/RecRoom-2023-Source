using UnityEngine;

namespace RecRoom.Core.Gestures
{
	public class HandshakeGesture : HandGestureBase
	{
		public enum FINJNKMKNBA
		{
			Inactive = 0,
			Ready_Open = 1,
			Ready_Gripped = 2,
			Running = 3,
			Finished = 4,
			Broken = 5
		}

		[SerializeField]
		private float cooldown;

		[SerializeField]
		private float handOpenBufferDuration;

		[SerializeField]
		private float palmsTogetherDotThreshold;

		[SerializeField]
		private float fingerDotThreshold;

		[SerializeField]
		private float maxStartDistance;

		[SerializeField]
		private float requiredHoldDuration;

		[SerializeField]
		private float maxHoldDriftDistance;

		private float LOGFGAGCGFD;

		private float ICDCOAEGAIB;

		private Vector3 GNNNMFKPMBP;

		private JOJOABLFOBA ICBGHODIDDA;

		private float DGOOEFIMAHA;

		private NonPlayerGestureTarget KAJIFLBNNCK;

		private NonPlayerGestureTarget EEEGEGIGKJL;

		private global::MOBDJNEDDKC<int> LEHFHGLEGJP;

		private PlayerHand PNHLCLMEPFB;

public override bool IsBlockingOtherGestures
{
get 		{
			return false;
		}

}

public override bool IgnoreGestureCooldown
{
get 		{
			return false;
		}

}

private FINJNKMKNBA MBHNCCMHIPK
{
get 		{
			return FINJNKMKNBA.Inactive;
		}

}

private NonPlayerGestureTarget BDALMOOGOKG
{
get 		{
			return null;
		}

set {
		}
}

private PlayerHand ACACJGJPCGA
{
get 		{
			return null;
		}

set {
		}
}

private HandshakeGesture BNMODCPDOLC
{
get 		{
			return null;
		}

}

private PlayerHand CJINGGNKMIA
{
get 		{
			return null;
		}

set {
		}
}

private FINJNKMKNBA CJKILBFPHJI
{
get 		{
			return FINJNKMKNBA.Inactive;
		}

}

private Player ACOGOJOHGEJ
{
get 		{
			return null;
		}

}

private bool HDGJOCBIFLP
{
get 		{
			return false;
		}

}

private bool PAPPAEFGEMC
{
get 		{
			return false;
		}

}

private bool JMCKCDGGHDB
{
get 		{
			return false;
		}

}

private bool KKLGKNLNKLG
{
get 		{
			return false;
		}

}

private bool IMLGLEDEKEF
{
get 		{
			return false;
		}

}

private bool LDJLGNFOOIM
{
get 		{
			return false;
		}

}

private bool KFAEOCGKEDB
{
get 		{
			return false;
		}

}

private bool BILIJKNBANC
{
get 		{
			return false;
		}

}

private bool BEJHPOLNHNO
{
get 		{
			return false;
		}

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

		public override void ProcessHandCollision(PlayerHand MCGMBMMJMBM)
		{
		}

		public override void ProcessNonPlayerHandCollision(NonPlayerGestureTarget GFCPAMJILIO)
		{
		}

		public override void Cancel()
		{
		}

		private void HBJCEKGBGNO(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		private void ONCKMBEJGAD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void IMBPNONHJCO()
		{
		}

		private void BLBMOOHOKGC()
		{
		}

		private void MCEHGFOHDIC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void AEJCJGCNDCL()
		{
		}

		private void JOPGJKMAMLF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void ONNNFMFCHIH()
		{
		}

		private void EMGEPPGGJKA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void NMCHAPHEPMI()
		{
		}
	}
}
