using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleEngine : MonoBehaviourPun, DJLCHGFCFAD
	{
		private enum DAIBAJAKPFI
		{
			DISABLED = 0,
			OFF = 1,
			IDLE = 2,
			ACCELERATE = 3,
			SLOWING_DOWN = 4
		}

		private enum JPCBMEEIEIK
		{
			UseHighestTorque = 0,
			ApplySuccessive = 1
		}

		public delegate float LBLDEHDNGEF(float FHMMCMOGNFE, float JFGDAEILDGE);

		public struct KFLKAINDAAB
		{
			public bool HLGAAHPBDJI;

			public float CGAKDCJEBGH;

			public float LEODIAIGHHL;

			public void KMDJNOCMKDB(ELFDKCLHAMN DGJEOFHPNDP)
			{
			}

			public static KFLKAINDAAB JFDMJLPIIPF(ELFDKCLHAMN DGJEOFHPNDP)
			{
				return default;
			}
		}

		[SerializeField]
		private GroundVehicle vehicle;

		[SerializeField]
		private AnimationCurve torqueCurve;

		[SerializeField]
		private float maxTorque;

		[SerializeField]
		private float maxRPM;

		[SerializeField]
		private AnimationCurve reverseTorqueCurve;

		[SerializeField]
		private float maxTorqueReverse;

		[SerializeField]
		private float maxRPMReverse;

		[SerializeField]
		private JPCBMEEIEIK torqueModifierApplicationMode;

		[SerializeField]
		private VehicleEngineAudio engineAudio;

		[SerializeField]
		private VehicleVFX vehicleVFX;

		private float ONOALGGFKKG;

		private float IBIGFHHEFLG;

		private float MLNHNNFOHNP;

		private bool PEMNOAFBPBK;

		private bool FGAMLBKJMNG;

		private MDEJADHJOEJ AKAAIDGALKA;

		private const float MIEMMBKDNPJ = 10f;

		private global::MOBDJNEDDKC<float> OPFEOLJMJHF;

		private global::MOBDJNEDDKC<float> FOPLCDAFAKP;

		private readonly List<LBLDEHDNGEF> OEBLJIMPEOI;

public float MaxTorque
{
get 		{
			return 0f;
		}

set {
		}
}

public float MaxReverseTorque
{
get 		{
			return 0f;
		}

set {
		}
}

private bool IDFLFKDDEOK
{
get 		{
			return false;
		}

}

private bool IPHCFJIMACF
{
get 		{
			return false;
		}

}

private bool PICMKBDPAEF
{
get 		{
			return false;
		}

}

private bool HKCKLICMKAK
{
get 		{
			return false;
		}

}

private float NJHMLIOCBIP
{
get 		{
			return 0f;
		}

}

private DAIBAJAKPFI MBHNCCMHIPK
{
get 		{
			return DAIBAJAKPFI.DISABLED;
		}

}

private bool KEGFDNDLNDL
{
get 		{
			return false;
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

		private void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		public float GetDriveTorque(float CGAKDCJEBGH, float FPJGAJJKGMN)
		{
			return 0f;
		}

		public void AuthorityStartEngine(bool EMKJGIDIHDC)
		{
		}

		public void StartEngine(bool EMKJGIDIHDC)
		{
		}

		private static float NEJALGCOLHL(float FHMMCMOGNFE, float JFGDAEILDGE)
		{
			return 0f;
		}

		public void AddTorqueModifier(LBLDEHDNGEF OONACCDEFKJ)
		{
		}

		public void RemoveTorqueModifier(LBLDEHDNGEF OONACCDEFKJ)
		{
		}

		private float FEBBEOKFEGP(float FHMMCMOGNFE, float JFGDAEILDGE)
		{
			return 0f;
		}

		private float LNLOEJKAMOB(float FHMMCMOGNFE, float JFGDAEILDGE)
		{
			return 0f;
		}

		public void SetSyncData(KFLKAINDAAB KBKJADAEFED)
		{
		}

		public KFLKAINDAAB GetSyncData()
		{
			return default;
		}

		private void DLFAKPCMELN(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void KHCLBMBFPLC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MPBJLGJNLMD()
		{
		}

		private void JDBOLOHPFEF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void DOLDJMGIDJE(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MHLFIPNPHNH()
		{
		}

		private void ECHACGOLOOH(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GBOKFBPJICA()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}
	}
}
