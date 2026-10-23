using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class WheelAudio : VehicleAudio
	{
		[SerializeField]
		private GroundVehicle vehicle;

		[SerializeField]
		private Wheel[] wheels;

		[SerializeField]
		private Transform audioFollowTransform;

		[SerializeField]
		private bool verboseLog;

		[SerializeField]
		private RecRoomAudioClip rollingClipLowSpeed;

		[SerializeField]
		private float maxRollingVolume;

		[SerializeField]
		private float maxRollingWhileSlippingVolume;

		[SerializeField]
		private AnimationCurve rollingVolumeCurve;

		[SerializeField]
		private RecRoomAudioClip rollingClipHighSpeed;

		[SerializeField]
		private float maxHighSpeedRollingVolume;

		[SerializeField]
		private float maxHighSpeedRollingWhileSlippingVolume;

		[SerializeField]
		private AnimationCurve rollingVolumeCurveHighSpeed;

		[SerializeField]
		private float minSpeedForVolume;

		[SerializeField]
		private float maxSpeedForVolume;

		[SerializeField]
		private float rollingVolumeSmoothTime;

		[SerializeField]
		private RecRoomAudioClip slippingClip;

		[SerializeField]
		private float minSlippingSpeed;

		[SerializeField]
		private float maxSlippingSpeed;

		[SerializeField]
		private float maxSlippingVolume;

		[SerializeField]
		private AnimationCurve slippingVolumeCurve;

		[SerializeField]
		private float slippingVolumeSmoothTime;

		[SerializeField]
		private RecRoomAudioClip spinningClip;

		[SerializeField]
		private float minSpinningSpeed;

		[SerializeField]
		private float maxSpinningSpeed;

		[SerializeField]
		private float maxSpinningVolume;

		[SerializeField]
		private AnimationCurve spinningVolumeCurve;

		[SerializeField]
		private float spinningVolumeSmoothTime;

		[SerializeField]
		private RecRoomAudioClip handbrakingClip;

		[SerializeField]
		private float maxHandbrakingVolume;

		[SerializeField]
		private AnimationCurve handbrakingVolumeCurve;

		[SerializeField]
		private RecRoomAudioClip absBrakingClip;

		[SerializeField]
		private float maxABSBrakingVolume;

		[SerializeField]
		private AnimationCurve absBrakingVolumeCurve;

		[SerializeField]
		private float minSpeedForBrakingVolume;

		[SerializeField]
		private float maxSpeedForBrakingVolume;

		[SerializeField]
		private float brakingVolumeSmoothTime;

		public float maxRecordedSlippingSpeed;

		public float maxRecordedSpinningSpeed;

		private const float DHNFINCKDOG = 0.02f;

		private bool DBILGIJHLAA;

		private bool OGMEPKDDHCN;

		private bool FADNMONGMHG;

		private bool KLOFPMHHDCK;

		private bool DINAOLMFCBD;

		private bool NJAAKNPOHBJ;

		private float FNBGIJCCKHA;

		private float JINFOEMNDOP;

		private float ADDLMBKHOMG;

		private float JCILBEJOBOM;

		private float MPBCKEJPBBJ;

		private float AHJGMPDIIKN;

		private float IJLMMNKMGJH;

		private float JLDKLCKKKEB;

		private float OMOHKPBFALA;

		private float CGHGEAKLIDP;

		private float GGJLEPIJNAB;

		private float OLBNPJNAFJO;

		private float EDCPPPJHPAN;

		private float JNLODJLLPLP;

		private string BPEFLMNLLOM;

		private string PEHBNEJIIIE;

		private SFXAudioSource GHIBFNNHCDB;

		private SFXAudioSource KIHGDCJDBCL;

		private SFXAudioSource OHHDCMMNGFF;

		private SFXAudioSource HIILAGPMBEI;

		private SFXAudioSource GGKEEOJILBP;

		private SFXAudioSource MMMCLIAMJBE;

private bool GBHENLLJCNC
{
get 		{
			return false;
		}

}

private bool HMEBCOFPFME
{
get 		{
			return false;
		}

}

private bool HNMLLFEPDDJ
{
get 		{
			return false;
		}

}

private bool PLHHILGJKPE
{
get 		{
			return false;
		}

}

private bool BMLOBFNLHIH
{
get 		{
			return false;
		}

}

private bool BMMBIHIOALI
{
get 		{
			return false;
		}

}

private bool ANOHHEIPECK
{
get 		{
			return false;
		}

}

private Vector2 CIIBNBCEADG
{
get 		{
			return default;
		}

}

private Vector2 OHJGLEACACE
{
get 		{
			return default;
		}

}

private Vector2 PILMAEHLFGP
{
get 		{
			return default;
		}

}

private Vector2 LECCBAAKJCB
{
get 		{
			return default;
		}

}

private bool HAJEMMECGEA
{
get 		{
			return false;
		}

set {
		}
}

private bool PCLKAKMJPNM
{
get 		{
			return false;
		}

set {
		}
}

private bool BGLGFFDEHNC
{
get 		{
			return false;
		}

set {
		}
}

private bool ENADHMDBKJH
{
get 		{
			return false;
		}

}

private bool NNEMOFNCFME
{
get 		{
			return false;
		}

set {
		}
}

private bool GMAOKHCJPFJ
{
get 		{
			return false;
		}

set {
		}
}

private bool EHJJILCPJCH
{
get 		{
			return false;
		}

set {
		}
}

private float MJOHNGJKLFA
{
get 		{
			return 0f;
		}

set {
		}
}

private float DONBJHPNPEO
{
get 		{
			return 0f;
		}

set {
		}
}

		public void Update()
		{
		}

		private void BNOIDKCCFOH()
		{
		}

		private void GILPLKBPNFI()
		{
		}

		private void LBJBFMJLAPP()
		{
		}

		private void LFKHCKCDECO()
		{
		}

		private void IAMKJMJMHEN()
		{
		}

		private void IKLNIHDODDC()
		{
		}

		private void DDKDPBEHNIL(ref SFXAudioSource PLIJJENJJOP, RecRoomAudioClip OCCKBMENBDI, float JDBNLCGDLEG)
		{
		}
	}
}
