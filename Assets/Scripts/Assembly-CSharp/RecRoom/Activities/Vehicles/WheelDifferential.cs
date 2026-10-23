using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Google.Protobuf;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class WheelDifferential : MonoBehaviourPun, DJLCHGFCFAD
	{
		[Serializable]
		public struct WheelAxle
		{
			public Transform axleTransform;

			public Wheel[] wheels;
		}

		public enum MCFHKNPDHEI
		{
			STOPPED = 0,
			FORWARD = 1,
			REVERSE = 2
		}

		private const float AFFBPKGGOMP = 1f;

		private const float NGAIAPNCHGG = 0.001f;

		private const float DIGIGNFOMOP = 0.02f;

		[SerializeField]
		private WheelAxle steeringAxle;

		[SerializeField]
		private WheelAxle rearAxle;

		[SerializeField]
		private float maxSteeringAngle;

		[SerializeField]
		private float maxStoppedWheelAngularSpeed;

		private readonly List<Wheel> GAOPMHDNJKO;

		private MCFHKNPDHEI FHLLCPDIHHH;

		private global::MOBDJNEDDKC<float> OGOJIGPNAKE;

private float MEIDCEPGNJC
{
get 		{
			return 0f;
		}

}

public MCFHKNPDHEI CurrentDriveDirection
{
get 		{
			return MCFHKNPDHEI.STOPPED;
		}

private set {
		}
}

public WheelAxle SteeringAxle
{
get 		{
			return default;
		}

}

public WheelAxle RearAxle
{
get 		{
			return default;
		}

}

public float MaxSteeringAngle
{
get 		{
			return 0f;
		}

set {
		}
}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		public void SetWheelSupportedMass(WheelSuspension JFKHHKGPGIF, RigidbodyEx PADCNKAEIIG)
		{
		}

		public void SetSteering(float GIEEFNMNPPK)
		{
		}

		public float GetMaxWheelSpeed(bool CHFNKGIJOPE = false)
		{
			return 0f;
		}

		public float GetMaxWheelRPM()
		{
			return 0f;
		}

		public int GetNumDrivingWheels()
		{
			return 0;
		}

		public MCFHKNPDHEI UpdateDriveDirection(float FPJGAJJKGMN, bool DKAFAEAPKCC = true)
		{
			return MCFHKNPDHEI.STOPPED;
		}

		public bool IsWheelOnSteeringAxle(Wheel BOBKGBOPGIJ)
		{
			return false;
		}

		public bool IsWheelOnRearAxle(Wheel BOBKGBOPGIJ)
		{
			return false;
		}

		public bool CanAnySteeringAxleWheelSteer()
		{
			return false;
		}

		public bool CanAnyRearAxleWheelSteer()
		{
			return false;
		}

		public bool CanAnySteeringAxleWheelDrive()
		{
			return false;
		}

		public bool CanAnyRearAxleWheelDrive()
		{
			return false;
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private void CLILONDKGEI(IEnumerable<ByteString> EBJPHIOALPL, List<Wheel> KJJLBOFMMEH)
		{
		}

		[CompilerGenerated]
		private int OAAKAABPECC(Wheel FOPCDMABHDL, Wheel FBLHNPJOMBM)
		{
			return 0;
		}
	}
}
